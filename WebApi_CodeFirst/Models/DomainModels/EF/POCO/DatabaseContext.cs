using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApi_CodeFirst.Models.DomainModels.EF.POCO
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("name = ProductStoreCodeFirstConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<DTO.Category> Categories { get; set; }
        public DbSet<DTO.Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}