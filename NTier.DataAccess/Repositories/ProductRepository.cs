using NTier.DataAccess.Context;
using NTier.DataAccess.Repositories;
using NTier.Entities.Models;

internal sealed class ProductRepository : Repository<Product>, IProductRepository // yalnız interface kullanıp class bağımlılığı azaltılır.
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
