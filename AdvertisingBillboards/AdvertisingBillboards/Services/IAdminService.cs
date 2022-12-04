using AdvertisingBillboards.ViewModels;

namespace AdvertisingBillboards.Services;

public interface IAdminService
{
    ViewBagModel GetModelsCount();

    AdvertisementViewModel Advertisement(long deviceId);
}