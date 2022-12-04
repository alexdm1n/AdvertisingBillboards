using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.ViewModels;

public class UsersDeviceGroupsViewModel
{
    public IEnumerable<User> Users { get; set; }

    public IEnumerable<DeviceGroup> DeviceGroups { get; set; }

    public UsersDeviceGroupsViewModel(IEnumerable<User> user, IEnumerable<DeviceGroup> deviceGroups)
    {
        Users = user;
        DeviceGroups = deviceGroups;
    }
}