using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lulalend.IRepositories
{
    public interface IGenericRepository<TEntity> 
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);
        void Add(TEntity entity);
        void Update(int id);
        void Delete(int id);
        Task Save();
    }
}