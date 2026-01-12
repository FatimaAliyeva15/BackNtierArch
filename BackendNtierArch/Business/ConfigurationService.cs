using Business.Services.Abstracts;
using Business.Services.Concretes;
using Business.Utilities.Profilies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
