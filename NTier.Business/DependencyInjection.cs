using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NTier.Business.Behaivors;
using NTier.Business.Features.Categories.CreateCategory;

// <>   {}          
namespace NTier.Business
{

    public static class DependencyInjection
    {

        public static IServiceCollection AddBusiness(
            this IServiceCollection services) 
        {
            services.AddMediatR(cfr =>
            {
                cfr.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
                cfr.AddOpenBehavior(typeof(ValidationBehavior<,>));          // <,> req ve resp
            });
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);  
            return services;
        }
    }
}
