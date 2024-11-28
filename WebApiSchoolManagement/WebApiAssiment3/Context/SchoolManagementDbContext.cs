using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiAssiment3.Context
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class>Classes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-NU1F9GM; Initial Catalog = EFSchoolMgmt; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
        }
    }
}
