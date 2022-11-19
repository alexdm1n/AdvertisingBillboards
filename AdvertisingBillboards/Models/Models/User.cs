namespace AdvertisingBillboards.Models.Models;

public class User
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }

    public string UserName { get; set; }

    public IEnumerable<Device> Devices { get; set; }

    public IEnumerable<DeviceGroup> DeviceGroups { get; set; }
}