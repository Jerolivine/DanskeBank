using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.API.Core.Extensions.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection ConfigureIdentityAuthentication(this IServiceCollection services, IConfiguration configuration, string JWTHeader)
        {

            CheckJwtSettings(configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            }); ;

            return services;
        }

        private static void CheckJwtSettings(IConfiguration configuration)
        {
            var validAudience = configuration["JWT:ValidAudience"];
            var validIssuer = configuration["JWT:ValidIssuer"];
            var issuerSigningKey = configuration["JWT:Secret"];

            if(string.IsNullOrEmpty(validAudience))
            {
                throw new Exception("JWT:ValidAudience is undefined");
            }

            if (string.IsNullOrEmpty(validIssuer))
            {
                throw new Exception("JWT:ValidIssuer is undefined");
            }

            if (string.IsNullOrEmpty(issuerSigningKey))
            {
                throw new Exception("JWT:Secret is undefined");
            }
        }


    }
}
