﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TaskMaster.Application.Mapping;
using TaskMaster.Application.Objects.DataValidators;
using TaskMaster.Application.Services;
using TaskMaster.Application.Services.Interfaces;

namespace TaskMaster.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<IWarningService, WarningService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPriorityService, PriorityService>();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ErrorDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<WarningDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
