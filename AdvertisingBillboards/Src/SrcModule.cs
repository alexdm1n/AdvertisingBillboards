using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services.VideoAnalyzer;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingBillboards.Src;

public static class SrcModule
{
    public static void AddSrcModule(this IServiceCollection services)
    {
        services.AddTransient<IVideoAnalyzerService, VideoAnalyzerService>();
        services.AddTransient<IAdvertisementService, AdvertisementService>();
        services.AddTransient<IDeviceService, DeviceService>();
        services.AddTransient<IUserService, UserService>();
    }
}