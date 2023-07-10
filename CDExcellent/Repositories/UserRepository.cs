using CDExcellent.DTO;
using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;

namespace CDExcellent.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CDE_Dbcontext _context;
        public UserRepository(CDE_Dbcontext context): base(context)
        {
            _context = context;
        }
        public async Task<User> PostUser (UserDTO u)
        {
            var user= new User
            {
                HoTen = u.HoTen,
                NgaySinh = u.NgaySinh,
                SDT = u.SDT,
                Email = u.Email,
                DiaChi=u.DiaChi,
                IdChucVu = u.IdChucVu,
                IdKhuVuc = u.IdKhuVuc,
            };
            await PostAsync(user);
            return user;
        }
        public async Task<List<User>> GetAllUser()
        {
            return await GetAllAsync();
        }

        public async Task<User?> GetByIdUser(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<User> PutUser(User oldUser, UserDTO newUser)
        {
                oldUser.HoTen = newUser.HoTen;
                oldUser.NgaySinh = newUser.NgaySinh;
                oldUser.SDT = newUser.SDT;
                oldUser.Email = newUser.Email;
                oldUser.DiaChi= newUser.DiaChi;
                oldUser.IdChucVu = newUser.IdChucVu;
                oldUser.IdKhuVuc = newUser.IdKhuVuc;
                await PutAsync(oldUser);
                return oldUser;
        }
        public async Task DeleteUser(User user)
        {
            await DeleteAsync(user);
        }
    }
}