using AdvertisingBillboards.Services;

namespace AdvertisingBillboards;

public static class AdvertisingBillboardsModule
{
    internal static void AddAdvertisingBillboardsModule(this IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.AddTransient<IAdminService, AdminService>();

        services.AddMvc();
    }
}