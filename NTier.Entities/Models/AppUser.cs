using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NTier.Entities.Models
{
    public sealed class AppUser : IdentityUser<Guid> // ad soyad hariç olabilecek her user default değişken ve metot bu classta var.
    {
        public string Name { get; set; }
        public string Lastname { get; set; } 
    }
}
