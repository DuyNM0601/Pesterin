using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pesterin.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        Task<List<T>> GetAll(int? pageIndex = null, int? pageSize = null);
        Task<List<T>> Find(Expression<Func<T, bool>> expression);
        T? FirstOrDefault(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
