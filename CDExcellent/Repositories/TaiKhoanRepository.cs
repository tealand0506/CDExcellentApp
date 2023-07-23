using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using CDExcellent.Middlewares;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace CDExcellent.Repositories
{
    public class TaiKhoanRepository : Repository<TaiKhoan>, ITaiKhoanRepository
    {
        private readonly IConfiguration _config;
        private readonly CDE_Dbcontext _context;
        public TaiKhoanRepository(CDE_Dbcontext context, IConfiguration config): base(context)
        {
            _config = config;   
            _context = context;
        }
        public async Task<List<TaiKhoan>> GetAllTaiKhoan()
        {
            return await GetAllAsync();
        }

        public async Task<TaiKhoan> PostTaiKhoan(string idUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.IdUser == idUser);

            var TaiKhoanMoi = new TaiKhoan{
                IdUser = user.IdUser,
                TenDN = user.Email,
                Password = Generate.GetMD5Hash(user.SDT),
                tgThamGia = DateTime.Now,
            };
            await PostAsync(TaiKhoanMoi);
            return TaiKhoanMoi;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private Token GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

            string JwtId = DateTime.Now.ToString("ddMMyyhhmmssfffffff");
            var role = _context.ChucVus.FirstOrDefault(r => r.IdChucVu == user.IdChucVu);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.IdUser),
                    new Claim(ClaimTypes.Name, user.HoTen),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, JwtId),
                    new Claim(ClaimTypes.Role, role.TenChucVu)
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = signinCredentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            string refreshToken = GenerateRefreshToken();

            _context.Add(new RefreshToken
            {   
                UserId = user.IdUser,
                RefToken = refreshToken,
                JwtId = JwtId,
                Expires = DateTime.Now.AddDays(7)
            });
            _context.SaveChanges();


            var themToken = new Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            _context.Add(themToken);
            _context.SaveChanges();

            return themToken;
            
        }
        public async Task<object> DangNhap(string email, string pass)
        {
            var TK =  _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == email);
            if(TK == null)
            {
                string kq="Tên đăng nhập không chính xác!";
                return kq;
            }
            if(TK.Password != Generate.GetMD5Hash(pass))
            {
                string kq="Mật khẩu không chính xác!";
                return kq;
            }

            var user = _context.Users.FirstOrDefault(u => u.IdUser == TK.IdUser);
            if(user == null)
            {
                string kq = "Người dùng không tồn tại!";
                return kq;
            }
            else
            {
                TK.tgDangNhap = DateTime.Now;
                await PutAsync(TK);
                var token = GenerateToken(user);
                return token;
            }
        }
            public async Task DangXuat(string IdUser)
        {
            var storedToken = _context.RefreshTokens.Where(r => r.UserId == IdUser).ToList();

            if (storedToken == null)
                throw new Exception("Not found");

            foreach (var token in storedToken) {
                _context.Remove(token);
                await _context.SaveChangesAsync();
            }
        }

        private string GenerateConfirmMailToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("SecretKey").Value));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

            string JwtId = DateTime.Now.ToString("ddMMyyhhmmssfffffff");

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.HoTen),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, JwtId)
            }),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = signinCredentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);

            return accessToken;
        }

        public async Task<dynamic> ForgotPassword(string emailUser, string url)
        {
            var user = await _context.Users.Where(u => u.Email == emailUser)
                .SingleOrDefaultAsync();

            if (user == null)
            {
                return new { Message = "Email không chính xác!" };

            }

            string token = GenerateConfirmMailToken(user);

            return token;
        }
    
        public async Task<object> ResetPassword(DoiMatKhau resetPassword)
        {
                var user = await _context.Users.Where(u => u.Email == resetPassword.Email).SingleOrDefaultAsync();

                if (user == null)
                {
                    return new{Message = "Email không chính xác!"};                    
                }
                var taiKhoan = await _context.TaiKhoans.Where(u => u.IdUser == user.IdUser).SingleOrDefaultAsync();

                if (!CheckTokenConfirmMail(resetPassword.Token))
                {
                    return new{Message = "Không tìm thấy xác thực!"};
                }

                if (resetPassword.NewPassword != resetPassword.ConfirmNewPassword) {
                    return new{Message = "Xác nhận mật khẩu không khớp"};
                }

                taiKhoan.Password = Generate.GetMD5Hash(resetPassword.ConfirmNewPassword);

                await PutAsync(taiKhoan);
                return new{Mess="Đặt lại mật khẩu thành công!"};
        }
        private bool CheckTokenConfirmMail(string token)
        {
            if (token is null) throw new Exception("Invalid client request");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("SecretKey").Value)),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var tokenInVerification = jwtTokenHandler.ValidateToken(token,
                tokenValidationParameters, out var validateToken);
            if (!(validateToken is JwtSecurityToken jwtSecurityToken)) throw new Exception("access token invalid format");

            var result = jwtSecurityToken.Header.Alg.Equals
                    (SecurityAlgorithms.HmacSha512,
                    StringComparison.InvariantCultureIgnoreCase);

            if (!result) throw new SecurityTokenException("Invalid token");

            var expireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var now = DateTimeOffset.Now.ToUnixTimeSeconds();

            if (expireDate <= now) throw new Exception("Token has expired");

            return true;
        }

        // Task<User> PutTaiKhoan(User oldUser, UserDTO newsUser);
        // Task DeleteTaiKhoan(User user);
    }
}