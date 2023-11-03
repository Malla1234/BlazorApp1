using BlazorApp1.Server.Data;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;

namespace BlazorApp1
{
    public class Program
    {
      
        public static async Task Main(string[] args)
        {
            using (var juldatabasContext = new JuldatabasContext())
            {
                #region Inserting Persons
                var persons1 = new Person()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Malin",
                    LastName = "Tomte"
                };
                
                var persons2 = new Person()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Elin",
                    LastName = "Tomte"
                };
                juldatabasContext.Add(persons1);
                juldatabasContext.Add(persons2);


                await juldatabasContext.SaveChangesAsync();

                #endregion

            }



            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}