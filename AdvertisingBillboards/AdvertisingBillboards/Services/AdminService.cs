using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using AdvertisingBillboards.ViewModels;

namespace AdvertisingBillboards.Services;

internal class AdminService : IAdminService
{
    private readonly IDeviceService _deviceService;
    private readonly IUserService _userService;
    private readonly IAdvertisementService _advertisementService;
    private readonly IAdvertisementStatisticsService _advertisementStatisticsService;

    public AdminService(
        IDeviceService deviceService,
        IUserService userService,
        IAdvertisementService advertisementService,
        IAdvertisementStatisticsService advertisementStatisticsService)
    {
        _deviceService = deviceService;
        _userService = userService;
        _advertisementService = advertisementService;
        _advertisementStatisticsService = advertisementStatisticsService;
    }

    public ViewBagModel GetModelsCount()
    {
        return new()
        {
            DevicesAmount = _deviceService.GetAll().Count(),
            UsersAmount = _userService.GetAll().Count(),
            AdvertisementsAmount = _advertisementService.GetAllForDevice(0).Count(),
        };
    }

    public AdvertisementViewModel Advertisement(long deviceId)
    {
        var advertisement = _advertisementService.GetAllForDevice(deviceId)?.FirstOrDefault();
        if (advertisement == null)
        {
            return new();
        }

        var statistics = _advertisementStatisticsService.Get(advertisement.Id)?.FirstOrDefault();
        if (statistics != null) statistics.TotalViews += 1;
        _advertisementStatisticsService.Update(statistics);
            
        return new()
        {
            FileName = advertisement.FileName,
        };
    }
}