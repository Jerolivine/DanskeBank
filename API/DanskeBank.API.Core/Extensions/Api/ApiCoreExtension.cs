﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.API.Core.Extensions.Api
{
    public static class ApiCoreExtension
    {
        public static IServiceCollection AddApiCore(this IServiceCollection services)
        {
            services.AddOptions()
                .AddMvcCore(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddApiExplorer()
                .AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials());
                });
            return services;
        }
    }
}
