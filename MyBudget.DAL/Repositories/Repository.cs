using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IList<TEntity>> GetAll(Expression<Func<TEntity, Object>>[] includeProperties = null);
        Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Object>>[] includeProperties = null);
        Task<TEntity> Find(int id);
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyBudgetContext _context;
        private DbSet<TEntity> _entities;

        public Repository(MyBudgetContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAll(Expression<Func<TEntity, Object>>[] includeProperties = null)
        {
            try
            {
                IQueryable<TEntity> query = _entities.AsQueryable();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.ToListAsync<TEntity>();
            }
            catch { throw; }
        }

        public async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Object>>[] includeProperties = null)
        {
            try
            {
                IQueryable<TEntity> query = _entities.AsQueryable();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return await query.Where(predicate).ToListAsync<TEntity>();
            }
            catch { throw; }
        }

        public async Task<TEntity> Find(int id)
        {
            try
            {
                return await _entities.FindAsync(id);
            }
            catch { throw; }
        }

        public async Task<TEntity> Add(TEntity item)
        {
            try
            {
                await _entities.AddAsync(item);
                return item;
            }
            catch { throw; }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _entities.Remove(entity);
            }
            catch { throw; }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                //var exist = _entities.Find(entity.PK);
                //if (exist != null)
                //{
                //_context.Entry(exist).CurrentValues.SetValues(entity);
                //_context.Entry(entity).CurrentValues.SetValues(entity);
                //}
                _entities.Attach(entity).State = EntityState.Modified;
                return entity;
            }
            catch { throw; }
        }
    }
}
