using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NTier.Entities.Models
{
    public sealed class AppRole : IdentityRole<Guid> // ID, name vs. içeren hazır class
    {
    }
}
