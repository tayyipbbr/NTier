using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default); // parametre almak şart değil default değer kullanmayacağımız anlamını verir.
        void Update(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default); // parameter =>parameter.name == kullanırız, default değil.
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    }
}
