namespace AdvertisingBillboards.Models.Models;

public class DeviceGroup
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }

    public User User { get; set; }

    public IEnumerable<Device> Devices { get; set; }
}