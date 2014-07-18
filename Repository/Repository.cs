using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Utils.Repository
{    
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            protected DbSet<TEntity> DbSet;

            private readonly DbContext _dbContext;

            public Repository(DbContext dbContext)
            {
                _dbContext = dbContext;
                DbSet = _dbContext.Set<TEntity>();
            }

            public Repository()
            {
            }

            public IQueryable<TEntity> GetAll()
            {
                return DbSet;
            }

            public async Task<TEntity> GetByIdAsync(int id)
            {
                return await DbSet.FindAsync(id);
            }

            public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
            {
                return DbSet.Where(predicate);
            }

            public async Task EditAsync(TEntity entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            public async Task InsertAsync(TEntity entity)
            {

                DbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
            }

            public async Task DeleteAsync(TEntity entity)
            {
                DbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
}
