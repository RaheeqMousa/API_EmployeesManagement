using API_EmployeesManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace API_EmployeesManagement.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=BirzeitUniversity;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Category>().HasData(
        //            new Category { Id=1, Name="Mobiles" },
        //            new Category { Id=2, Name="Kitchen Accessories" },
        //            new Category { Id=3, Name="Toys" },
        //            new Category{Id=4, Name="Home & Living" }
        //        );

        //}
    }
}
