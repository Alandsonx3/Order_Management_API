using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.DTOs;
using OrderManagementAPI.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddScoped<IValidator<ProductDTO>, ProductServiceValidator>();

            return service;
        }
    }
}
