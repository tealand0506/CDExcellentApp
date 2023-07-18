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

        // Task<User?> GetByIdTaiKhoan(int id);
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
                var token = GenerateToken(user);
                return token;
            }


            /*
//            LoginRes res = new LoginRes();
            string token = CreatedToken(TK);
                       if (isPasswordNeedChange(userDb.PasswordLifeTime))
                       {
                           res.isPasswordNeedChanged = true;
                       }
                       else
                       {
                           res.isPasswordNeedChanged = false;
                       }
           
       // res.token = token;
       //create and set the token
            var refreshToken = RefreshTokenGenerator();
        SetRefreshToken(refreshToken, userDb);
        await _dbContext.SaveChangesAsync();
            return Ok(res);
            */
        }


        // Task<User> PutTaiKhoan(User oldUser, UserDTO newsUser);
        // Task DeleteTaiKhoan(User user);
    }
}