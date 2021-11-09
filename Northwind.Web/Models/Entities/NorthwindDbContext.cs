using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Northwind.Web.Models.Entities
{
    public class NorthwindDbContext : DbContext
    {
        // ROLLBACK = update-database MigrName şekilinde kullanırsan o zamanki haline geri dönüş yapabilirsin. 

        public NorthwindDbContext()
        {
            //this.Database.Connection.ConnectionString = "Server=. ; Database=NorthwindDev; User Id = sa ; Password =123;"; //içi boş bir database oluşturcaz

            this.Database.Connection.ConnectionString = "Server=. ; Database=NorthwindDev0; User= sa ; Password = Password1";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}