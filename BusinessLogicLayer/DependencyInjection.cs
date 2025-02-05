using eCommerce.OrdersMicroservice.BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessAccessLayer(this IServiceCollection services,
            IConfiguration configuration)
        {
            //TO DO: Add business logic layer services into the IoC container
            services.AddValidatorsFromAssemblyContaining<OrderAddRequestValidator>();

            return services;
        }
    }
}


