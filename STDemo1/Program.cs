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

            // Add services to the DI container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>(); 
            builder.Services.AddTransient<IStudentRepo,  StudentRepo>();
            builder.Services.AddTransient<ICourseRepo, CourseRepo>();
            builder.Services.AddDbContext<ITIContext>(a =>
            {
                a.UseSqlServer("Server=LABTOP-OV6A621\\SQLEXPRESS;Database=mvc;Integrated Security=True;Trust Server Certificate=True");
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //******order of middlewares is important*****
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); //like bootstrap

            app.UseRouting();   //name of controller/name of action

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //if we changes the pattern order pattern: "{{action=Index}/controller=Home}/{id?}"); i need to use ip the same pattern as defined here
            //create/department

            app.Run();

            //app.Use(async (context, next) =>    //going to next middleware //use
            //{
            //    //context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync("Welcome from first middleware"); //1
            //    await next.Invoke(); //call the next middleware
            //    await context.Response.WriteAsync("\n after return from next middleware"); //3
            //});

            //app.Run(async context =>    //short circuit the request //run ***with only middle ware (nothing before or after)*** 
            //{
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync("\n Welcome from first middleware"); //2
            //});
        }
    }
}
