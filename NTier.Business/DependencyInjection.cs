﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

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
                cfr.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);  
            return services;
        }
}
