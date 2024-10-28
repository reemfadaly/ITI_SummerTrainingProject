using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using STDemo1.Models;
namespace STDemo1.Data
{
    public class ITIContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ITIContext(DbContextOptions options):base(options)
        {

        }
        public ITIContext() //empty constructor for any modifications for db
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        //connect on the local host
        //name of server . DatabaseName
        optionsBuilder.UseSqlServer("Server=LABTOP-OV6A621\\SQLEXPRESS;Database=mvc;Integrated Security=True;Trust Server Certificate=True");
        base.OnConfiguring(optionsBuilder);
        }
    }
}
