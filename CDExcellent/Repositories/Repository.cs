using CDExcellent.Models;
using CDExcellent.Repositories.interfaceRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace CDExcellent.Repositories
{   
    public class Repository<TEntity>  : IRepository<TEntity> where TEntity : class
    {
        private readonly CDE_Dbcontext _context;
        public readonly DbSet<TEntity> _dbSet;

        public Repository(CDE_Dbcontext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()//truy xuat
        {
            return await _dbSet.ToListAsync();

        }

        public async Task<List<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
        public async Task PostAsync(TEntity entity)//them
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task PutAsync(TEntity entity)//sua
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(TEntity entity)//xoa
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<TEntity?> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }


        public async Task<List<TEntity>> TruyXuatTheoLoai( params Expression<Func<TEntity, object>>[] PhanLoai)
        {
            var query = _context.Set<TEntity>().AsQueryable();//truy xuat doi tuong

            if (PhanLoai != null)//neu truy van thanh cong + Phanloai
            {
                query = PhanLoai.Aggregate(query, (current, PhanLoai) => current.Include(PhanLoai));
            }

            return await query.ToListAsync();
        }
    }
}
