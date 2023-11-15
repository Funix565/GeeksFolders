using GeeksFolders.Data;
using Microsoft.EntityFrameworkCore;

namespace GeeksFolders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<GeeksFolderContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("GeeksFolderContext")
                    ?? throw new InvalidOperationException("Connection string 'GeeksFolderContext' not found."));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<GeeksFolderContext>();
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();

            app.Run();
        }
    }
}