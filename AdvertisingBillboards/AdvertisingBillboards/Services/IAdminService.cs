using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.ViewModels;

namespace AdvertisingBillboards.Services;

public interface IAdminService
{
    ViewBagModel GetModelsCount();

    AdvertisementViewModel Advertisement(long deviceId);

    UsersDeviceGroupsViewModel DeviceGroups();

    UsersDevicesViewModel Devices(long? userId = null);

    IEnumerable<User> UsersList();

    void AddUser(string name);

    void DeleteUser(long userId);

    void AddDevice(long userId);

    void DeleteDevice(long id);

    void AddDeviceGroup(long userId);

    void DeleteDeviceGroup(long deviceGroupId);

    AdvertisementStatistics AdvertisementStatistics(long advertisementId);

    void DeleteAdvertisement(long advId);

    void UploadVideo(IFormFile uploadedVideo, long deviceId);

    void SubmitFrequencyForDevice(long deviceId, int frequency);

    void SubmitFrequencyForDeviceGroup(long deviceId, int frequency);
}