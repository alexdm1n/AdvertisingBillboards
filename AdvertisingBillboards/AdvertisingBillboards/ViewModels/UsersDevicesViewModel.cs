using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.ViewModels;

public class UsersDevicesViewModel
{
    public IEnumerable<User> Users { get; set; }

    public IEnumerable<Device> Devices { get; set; }

    public UsersDevicesViewModel(IEnumerable<User> users, IEnumerable<Device> devices)
    {
        Users = users;
        Devices = devices;
    }
}