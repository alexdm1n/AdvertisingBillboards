using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.ViewModels;

public class UserDeviceViewModel
{
    public IEnumerable<Device> Devices { get; set; }
    
    public User User { get; set; }

    public UserDeviceViewModel(User user, IEnumerable<Device> devices)
    {
        User = user;
        Devices = devices;
    }
}