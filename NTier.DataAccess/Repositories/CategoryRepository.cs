using NTier.DataAccess.Context;
using NTier.DataAccess.Repositories;
using NTier.Entities.Models;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository // yalnız interface kullanıp class bağımlılığı azaltılır.
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
