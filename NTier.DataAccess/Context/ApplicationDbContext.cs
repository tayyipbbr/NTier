using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTier.Entities.Models;

namespace NTier.DataAccess.Context
{
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IUnitOfWork // sorulacak.
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            protected override void OnModelCreating(ModelBuilder builder)  
        {
            builder.Ignore<IdentityUserRole<Guid>>();                       // user ve role tablosu hariç kalanların oluşmasını engellemek için.
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityUserLogin<Guid>>(); 
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }           
    }
}

/*
 * assembly, mevcut katmanın derlenmiş halidir
 * typeof, reflectiondur. class, imp, interfacei property vs her şeyi okuyabilir.
 * assembly ile projenin derli hali metoda gider ve reflection sayesinde IEntityTypeConf ile imp edilmiş tüm classları bulur.
 * Class içerisindeki tüm metodları da okur ve tek tek işler. Otomatik olarak dependency inject. kısmında yapabilmektedir.
 * Yeni class eklemke için tek yapılması gereken yeni bir conf dosyası oluşturmaktır.
 */




/* 
 * identity yani kimli ktanımlama gibi düşünebilirim. user ve role alır.
 * internal sebebi sadece db katmanından appdbcotext erişim sağlar.
 * diğer katmanlar repository pattern üzerinden erişim sağlaması lazım.
 * override ile onconfig metodunu ezebiliriz veya; constructer üzerinden appdbcontext'in option'u çağırılabilir.
 * ctrl + . ile cons (opt) çağırdım. bu sayede use sql ile bağlanabileceğim.
 * şimdi entity ile bağlanmam gerekiyor.
 * appdbcontext'in 'OnModelCreating' isimli bir metodu var bunu override ederek dbye bir classı entity olarak bağlamayı ve alanları özelleştirebilmeyi sağlar. modelbuilder class ile
 * builder.entity<T>().totable("TT"); yapısı ile T= products vs.
 * BUNUN da daha profesyoneli vardır. Her dosya için ayrı configuration oluşturarak daha kılcal bir yapıya kavuşturabiliriz.
 */