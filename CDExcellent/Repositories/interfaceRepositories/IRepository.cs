using System.Linq.Expressions;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task PostAsync(TEntity entity);
        Task PutAsync(TEntity entity);  
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(int Id);
        Task<List<TEntity>> TruyXuatTheoLoai( params Expression<Func<TEntity, object>>[] PhanLoai);
    }
}
