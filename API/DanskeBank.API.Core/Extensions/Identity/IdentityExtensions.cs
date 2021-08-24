using DanskeBank.Application.Core.Abstract;
using DanskeBank.Application.Core.Concrete;
using DanskeBank.Domain.Core.Repository;
using DanskeBank.Infrastructure.EntityFramework.Core;
using DanskeBank.Infrastructure.EntityFramework.Core.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DanskeBank.API.Core.Extensions.Identity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection ConfigureEFCoreIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<IRoleManagerService, RoleManagerService>();
            //services.AddScoped<IUserManagerService, UserManagerService>();

            // TODO Accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.UseEFCoreIdentityDbContext(configuration);

            services.AddTransient(typeof(IRepository<,>), typeof(EFCoreGenericRepository<,>));

            // TODO Move to Core
            services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            return services;
        }


        //public static IServiceCollection AddIdentityAuthorization(this IServiceCollection services)
        //{
        //    services.AddAuthorization(options =>
        //    {
        //        options.AddPolicy(Policy.RequireAdministratorRole, policy => policy.RequireRole(UserRoles.Admin));
        //    });

        //    return services;
        //}
    }
}
