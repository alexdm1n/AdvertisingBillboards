using AdvertisingBillboards.ViewModels;

namespace AdvertisingBillboards.Services;

public interface IUserControllerService
{

    AdvertisementViewModel Advertisement(long deviceId);

    UserDeviceViewModel Devices(long? userId = null);

    void SubmitFrequencyForDevice(long deviceId, int frequency);
}