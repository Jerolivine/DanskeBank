using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PaketTDanskeBankaxi.API.Core.Extensions.Swagger;
using System;

namespace DanskeBank.API.Core.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration, string swaggerConfigurationKey)
        {
            CheckSwaggerOptions(configuration, swaggerConfigurationKey);

            SwaggerOptions swaggerOptions = GetSwaggerOptions(configuration, swaggerConfigurationKey);

            if (!swaggerOptions.Enable)
            {
                return services;
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerOptions.Version, new OpenApiInfo { Title = swaggerOptions.Title, Version = swaggerOptions.ApplicationVersion });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });


            return services;
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, IConfiguration configuration, string swaggerConfigurationKey)
        {
            CheckSwaggerOptions(configuration, swaggerConfigurationKey);

            SwaggerOptions swaggerOptions = GetSwaggerOptions(configuration, swaggerConfigurationKey);

            if (!swaggerOptions.Enable)
            {
                return;
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                var swaggerUrl = "/swagger/" + swaggerOptions.Version + "/" + swaggerOptions.FileName + ".json";
                c.SwaggerEndpoint(swaggerUrl, swaggerOptions.Title);
                //c.RoutePrefix = "swagger";
            });

        }

        private static void CheckSwaggerOptions(IConfiguration configuration, string swaggerConfigurationKey)
        {
            SwaggerOptions swaggerOptions = GetSwaggerOptions(configuration, swaggerConfigurationKey);

            if (swaggerOptions == null)
            {
                throw new Exception("Swagger Options are undefined");
            }
        }

        private static SwaggerOptions GetSwaggerOptions(IConfiguration configuration, string swaggerConfigurationKey)
        {
            SwaggerOptions swaggerOptions = configuration.GetSection(swaggerConfigurationKey).Get<SwaggerOptions>();

            return swaggerOptions;
        }

    }

}
