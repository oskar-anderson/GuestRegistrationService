using Contracts.DAL.Base;
using DAL.App.EF;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helpers;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });
            
            // Add services to the container.
            // makes httpcontext injectable - needed to resolve username in dal layer
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserNameProvider, UserNameProvider>();
            
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}