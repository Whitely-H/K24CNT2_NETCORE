using Microsoft.EntityFrameworkCore;
using PxcLesson10.Models;

namespace PxcLesson10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký DbContext TRƯỚC builder.Build()
            builder.Services.AddDbContext<PxcK24cnt2lesson10Context>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("PxcK24CNT2Lesson10")
                ));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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