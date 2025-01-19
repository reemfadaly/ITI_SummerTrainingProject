using STDemo1.Repository;
using STDemo1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace STDemo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>(); 
            builder.Services.AddTransient<IStudentRepo,  StudentRepo>();
            builder.Services.AddTransient<ICourseRepo, CourseRepo>();
            builder.Services.AddDbContext<ITIContext>(a =>
            {
                a.UseSqlServer("Server=LABTOP-OV6A621\\SQLEXPRESS;Database=mvc;Integrated Security=True;Trust Server Certificate=True");
            });


            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); 

            app.UseRouting();  

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

           

            app.Run();

           
        }
    }
}
