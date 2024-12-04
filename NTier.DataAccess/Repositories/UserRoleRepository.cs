using NTier.DataAccess.Context;
using NTier.DataAccess.Repositories;
using NTier.Entities.Models;

internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository // yalnız interface kullanıp class bağımlılığı azaltılır.
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
