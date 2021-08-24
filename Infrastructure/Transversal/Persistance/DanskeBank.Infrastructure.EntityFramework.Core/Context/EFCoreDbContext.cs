using DanskeBank.Domain.Company;
using DanskeBank.Domain.Notification;
using DanskeBank.Infrastructure.EntityFramework.Core.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DanskeBank.Infrastructure.EntityFramework.Core.Context
{
    public class EFCoreDbContext : IdentityDbContext
         <
             IdentityUser, // TUser
             IdentityRole, // TRole
             string, // TKey
             IdentityUserClaim<string>, // TUserClaim
             IdentityUserRole<string>, // TUserRole,
             IdentityUserLogin<string>, // TUserLogin
             IdentityRoleClaim<string>, // TRoleClaim
             IdentityUserToken<string> // TUserToken
         >
    {

        public DbSet<Company> Company { get; set; }
        public DbSet<CompanySchedule> CompanySchedule { get; set; }
        public DbSet<Notification> Notification { get; set; }

        public EFCoreDbContext() : base()
        {
        }

        public EFCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AssemblyConfiguration)));

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    var currentDirectory = Directory.GetCurrentDirectory();

        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //       .SetBasePath(currentDirectory)
        //       .AddJsonFile("appsettings.json")
        //       .Build();

        //    // update-database
        //    string connectionString = configuration.GetConnectionString("MigrationConnection");

        //    //string connectionString = configuration.GetConnectionString("DefaultConnection");

        //    optionsBuilder.UseSqlServer(connectionString);

        //}

    }
}
