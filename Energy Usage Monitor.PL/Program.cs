using Energy_Usage_Monitor.Persistence.Data;
using Energy_Usage_Monitor.Persistence.UOW;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Energy_Usage_Monitor.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configuration Service
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddDbContext<EnergyUsageDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddMapster();
            builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            builder.Services.AddScoped<IMapper, ServiceMapper>();
            builder.Services.AddScoped<IElectricalDeviceService, ElectricalDeviceService>();
            builder.Services.AddScoped<IDeviceUsageService, DeviceUsageService>();


            #endregion

            var app = builder.Build();

            #region Configure Kestrel Middlewares
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            #endregion

            app.Run();
        }
    }
}
