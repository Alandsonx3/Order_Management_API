using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.DTOs.Request.Product;
using OrderManagementAPI.Application.Interfaces.Services;
using OrderManagementAPI.Application.Services;
using OrderManagementAPI.Application.Validators;

namespace OrderManagementAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddScoped<IValidator<CreateProductRequestDto>, CreateProductServiceValidator>();
            service.AddScoped<IValidator<UpdateProductRequestDto>, UpdateProductServiceValidator>();

            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IProductService, ProductService>();

            return service;
        }
    }
}
