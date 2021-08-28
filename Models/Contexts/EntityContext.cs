using ModelsLayer.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Contexts
{
    public class EntityContext : DbContext
    {
        private static string connectionString = @"Data Source=WIN-JT2C2OT04D4\SQLEXPRESS;Initial Catalog=phonebook;User ID=Admin;Password=serverSQLtest!!!123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbSet<Phone> phones { get; set; }
        public DbSet<Person> people { get; set; }
        public EntityContext() : base (connectionString) {
            if (!Database.Exists()) Database.Create();
            

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
       
    }
}
