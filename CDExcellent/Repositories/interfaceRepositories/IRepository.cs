using System.Linq.Expressions;

namespace CDExcellent.Repositories.interfaceRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task PostAsync(TEntity entity);
        Task PutAsync(TEntity entity);  
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(int Id);
        Task<List<TEntity>> TruyXuatTheoLoai( params Expression<Func<TEntity, object>>[] PhanLoai);
    }
}
