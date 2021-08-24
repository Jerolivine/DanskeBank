using DanskeBank.Infrastructure.EntityFramework.Core.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Infrastructure.EntityFramework.Core.Extensions
{
    public static class UseEFCoreDbContextExtension
    {
        public static IServiceCollection UseEFCoreIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            SetDbContext(services, configuration);

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<EFCoreDbContext>()
              .AddDefaultTokenProviders();

            RegistrationOptions(services);
            LoginOptions(services);

            return services;
        }

        private static void LoginOptions(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
        }

        private static void RegistrationOptions(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
            });
        }

        private static void SetDbContext(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<EFCoreDbContext>(options => options.UseSqlServer(connectionString),ServiceLifetime.Scoped);
            services.AddDbContext<EFCoreDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
