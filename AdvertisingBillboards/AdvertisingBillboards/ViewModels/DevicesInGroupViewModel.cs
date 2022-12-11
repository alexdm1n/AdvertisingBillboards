using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.ViewModels;

public class DevicesInGroupViewModel
{
    public IEnumerable<Device> EnabledDevices { get; set; }

    public IEnumerable<Device> DeviceInGroup { get; set; }

    public DeviceGroup DeviceGroup { get; set; }

    public DevicesInGroupViewModel(
        IEnumerable<Device> enabledDevices, 
        IEnumerable<Device> deviceInGroup, 
        DeviceGroup deviceGroup)
    {
        DeviceGroup = deviceGroup;
        DeviceInGroup = deviceInGroup;
        EnabledDevices = enabledDevices;
    }
}