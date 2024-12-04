using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 //User ve Rol arasındaki ilişkiyi sağlayan tablo
namespace NTier.Entities.Models
{
    public sealed class UserRole 
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } //yukarıdakine erişim sağlar.
        public Guid AppRoleId { get; set; }
        public AppRole AppRole { get; set; }

    }
}
