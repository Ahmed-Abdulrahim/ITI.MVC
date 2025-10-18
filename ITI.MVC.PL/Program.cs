using ITI.MVC.BLL.Interface;
using ITI.MVC.BLL.Repo;
using ITI.MVC.DAL.Context;
using ITI.MVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace ITI.MVC.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IEntityType<Department> , DepartmentRepo>();
            builder.Services.AddScoped<IEntityType<Student>, StudentRepo>();

            builder.Services.AddDbContext<SchoolDBContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conn1"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
