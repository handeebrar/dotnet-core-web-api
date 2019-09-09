using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WebApiDemo.DataAccess
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind; Trusted_Connection=true");
        }

        //contextler dbdeki tablolarla nesneleri map ettğimiz ilk noktadır
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
    }
}
