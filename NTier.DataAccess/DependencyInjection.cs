using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTier.DataAccess.Context;
using NTier.Entities.Models;

// db bağlantı burada  <>   {}

namespace NTier.DataAccess
{
    public  static class DependencyInjection
    {

        public static IServiceCollection AddDataAccess  // this ile iservicecol içerisinde scoped transit ve singelton var bunları kullanicaz.
            (
            this IServiceCollection services,           
            IConfiguration configuration
            )
        {
            /*
            string connectionString = configuration.GetConnectionString("SqlServer"); // program.cs içine gömülecek
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                //opt.UseSqlServer(connectionString);
            });

            */

            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));


            services.AddIdentityCore<AppUser>(cfr =>
            {
                cfr.Password.RequiredLength = 8;        // en az 8 haneli olmak zorunda.
                cfr.Password.RequireUppercase = true;   // en az 1 adet uppercase olmak zorunda.
                cfr.Password.RequireLowercase = true;   // en az 1 adet lowercase olmak zorunda.
                cfr.Password.RequiredUniqueChars = 1;   // en az 1 adet uniqchar olmak zorunda.

                cfr.User.RequireUniqueEmail = true;     // her e-mail ile 1 kayıt hakkı.
                cfr.User.AllowedUserNameCharacters += ""; //default; ? null mü eklenmiş oldu?


            }).AddEntityFrameworkStores<ApplicationDbContext>();
            // Cannot convert lambda expression to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type
            services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICategoryRepository, CategoryRepository>();              // Burada amaç consta her repo interface'i istenildiğinde
            services.AddScoped<IProductRepository, ProductRepository>();                // class'ının new'lenmi halini her requestte verecek
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();              // scope yaşam döngüsü içerisinde.

            /* yukarıda dep inj kodlarını otomatik oluşturan kütüphane mevcut. çoklu durumlarda kullanmak gerekir.
             * interface ve class oluşturmak gerekir ancak yukarıdaki kodu kendisi yapıyor.
             * nuget paket: scrutor kütüphanesi
             * services.Scan(selector=> selector
             * .FromAssemblies(
             * typeof.DependencyInjection).Assembly)
             * .AddClasses(publicOnly : false)
             * .LoginRegistrationStrategy(RegistrationStrategy.Skip)
             * .AsMatchingInterface()
             * .WithScopedLifeTime();
             * 
             * bununla birlikte artık dep inj. gerek kalmıyor. scoped döngüde otomatikten bu işlemleri yapıypr.
             */

            return services;
        }

    }
}
