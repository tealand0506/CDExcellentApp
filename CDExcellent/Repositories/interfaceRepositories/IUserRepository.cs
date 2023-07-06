using CDExcellent.DTO;
using CDExcellent.Models;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllUser();
        Task<User> GetByIdUser(int id);
        Task<User> PostUser(UserDTO u);
        Task<User> PutUser(User oldUser, UserDTO newsUser);
        Task DeleteUser(User user);
    }
}