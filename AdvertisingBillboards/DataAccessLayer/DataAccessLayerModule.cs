using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingBillboards.DataAccessLayer;

public static class DataAccessLayerModule
{
    public static void AddDataAccessLayerModule(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

        services.AddTransient<IDbRepository<Advertisement>, AdvertisementRepository>();
        services.AddTransient<IDbRepository<AdvertisementStatistics>, AdvertisementStatisticsRepository>();
        services.AddTransient<IDbRepository<DeviceGroup>, DeviceGroupRepository>();
        services.AddTransient<IDbRepository<Device>, DeviceRepository>();
        services.AddTransient<IDbRepository<User>, UserRepository>();
    }
}