using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NTier.DataAccess.Context;
using NTier.Entities.Repositories;

namespace NTier.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>.AddAsync(entity, cancellationToken = default); // asenkronlar her zaman canc token alır ve default alır.
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().AnyAsync(expression, cancellationToken);// boolen döner.
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            await _context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken); // not alındı.
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _context.Set().AsNoTracking().Where(expression).AsQueryable(); // asnoTracking listlerde gerek yok, düşür perfor artar.
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
