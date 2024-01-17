using API.Helpers;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Repository;
using Service;

namespace API.ServicesExtension
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {

            // --- Bad Way To Register Dependancy Injection Of Generic Repositories
            //builder.Services.AddScoped<IGenericRepositories<Product>, GenericRepositories<Product>>();
            //builder.Services.AddScoped<IGenericRepositories<ProductBrand>, GenericRepositories<ProductBrand>>();
            //builder.Services.AddScoped<IGenericRepositories<ProductCategory>, GenericRepositories<ProductCategory>>();
            // --- Right Way To Register Dependancy Injection Of Generic Repositories
            //services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));
            // --- but I commented this line because i used unit-of-work then
            // --- I at all time create instance in unit-of-work then instead of dependency injection

            // Register Unit Of Work
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // Register Product Service
            services.AddScoped(typeof(IProductService), typeof(ProductService));

            // --- Two Ways To Register AutoMapper
            // - First (harder)
            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            // - Second (easier)
            services.AddAutoMapper(typeof(MappingProfiles));

            // Register Basket Repository
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

            // Register Order Service
            services.AddScoped(typeof(IOrderService), typeof(OrderService));

            return services;
        }
    }
}