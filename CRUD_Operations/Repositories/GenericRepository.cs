using Lulalend.IRepositories;
using Lulalend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lulalend.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal practiceContext DbContext;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(practiceContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = DbSet;

            return query;
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Update(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}