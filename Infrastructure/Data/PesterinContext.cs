using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pesterin.Core.Entities;

namespace Pesterin.Infrastructure.Data
{
    public class PesterinContext : DbContext
    {
        public PesterinContext()
        {

        }
        public PesterinContext(DbContextOptions<PesterinContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString(), x => x.MigrationsAssembly("Pesterin.Infrastructure"));
            }
        }


        private string GetConnectionString()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return configurationRoot.GetConnectionString("PesterinDb") + "";
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var primaryKey = entityType.FindPrimaryKey();
                if (primaryKey != null)
                {
                    var primaryKeyProperty = primaryKey.Properties.FirstOrDefault(p => p.ClrType == typeof(Guid));
                    if (primaryKeyProperty != null)
                    {
                        modelBuilder.Entity(entityType.ClrType)
                                    .Property(primaryKeyProperty.Name)
                                    .ValueGeneratedOnAdd();
                    }
                }
            }
        }
    }
}
