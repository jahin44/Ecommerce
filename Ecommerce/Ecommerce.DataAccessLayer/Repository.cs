using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly DbContext _dbcontext;
        protected readonly DbSet<TEntity> _dbSet;

         public Repository(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = _dbcontext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
           
            _dbSet.Remove(entity);
            _dbcontext.SaveChanges();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int Id)
        {
            return  _dbSet.Find(Id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (_dbcontext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Update(entity);
            _dbcontext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            _dbcontext.SaveChanges();
            return entity;
        }
    }
}
