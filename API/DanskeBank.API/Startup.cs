using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanskeBank.API.Core.Core.Middleware;
using DanskeBank.API.Core.Extensions;
using DanskeBank.API.Core.Extensions.Api;
using DanskeBank.API.Core.Extensions.Authentication;
using DanskeBank.API.Core.Extensions.Identity;
using DanskeBank.Application.Service.Company.Abstract;
using DanskeBank.Application.Service.Company.Concrete;
using DanskeBank.Application.Service.Notification.Abstract;
using DanskeBank.Application.Service.Notification.Concrete;
using DanskeBank.Domain.Company;
using DanskeBank.Domain.Notification;
using DanskeBank.Infrastructure.EntityFramework.Core;
using DanskeBank.Infrastructure.EntityFramework.Core.Repository;
using DanskeBank.Mapper.Mapster;
using DanskeBank.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanskeBank.API
{
    public class Startup
    {
        private readonly string SWAGGER_OPTIONS_KEY = "SwaggerOptions";
        private readonly string JWT_KEY = "JWT";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // swagger
            services.ConfigureSwagger(Configuration, SWAGGER_OPTIONS_KEY);

            services.AddApiCore();

            // identity configuration
            services.ConfigureEFCoreIdentity(Configuration);
            services.ConfigureIdentityAuthentication(Configuration, JWT_KEY);
            //services.AddIdentityAuthorization();

            // mapper
            services.ConfigureMapster();

            // newtonsoft
            services
                .AddMvc()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICompanyScheduleRepository, CompanyScheduleRepository>();
            services.AddTransient<INofitificationRepository, NofitificationRepository>();

            services.AddTransient(typeof(ICompanyService), typeof(CompanyService));
            services.AddTransient(typeof(ICompanyScheduleService), typeof(CompanyScheduleService));
            services.AddTransient(typeof(INotificationService), typeof(NotificationService));

            services.AddScoped<IUnitOfWork, EFCoreUnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseMiddleware<UnitOfWorkMiddleware>();

            // swagger
            app.ConfigureSwagger(Configuration, SWAGGER_OPTIONS_KEY);

            app.UseAuthentication();
            app.UseAuthorization();

            // logger
            //app.LogRequestResponse();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "api/{controller}/{action}");
            });

        }
    }
}
