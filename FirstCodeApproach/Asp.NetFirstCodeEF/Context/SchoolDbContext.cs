using System.Security.Cryptography.X509Certificates;
using Asp.NetFirstCodeEF.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetFirstCodeEF.Context
{
    public class SchoolDbContext:DbContext //DBContext is a parent class
    {
        //Create a constructor (parameterized)
        public SchoolDbContext(DbContextOptions<SchoolDbContext>options) : 
            base(options)
        {

        }

        public DbSet<Employee>Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product>products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data source=DESKTOP-NU1F9GM;" +
                "Initial Catalog=EFSchoolDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
    }
}
