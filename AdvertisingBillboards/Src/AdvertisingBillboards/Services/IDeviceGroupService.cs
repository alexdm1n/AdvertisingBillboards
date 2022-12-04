using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public interface IDeviceGroupService
{
    IEnumerable<DeviceGroup> Get(long? userId = null);

    void Create(DeviceGroup deviceGroup);
    
    void Add(long id);
    
    void Delete(long id);
    
    void AddDeviceInGroup(long deviceGroupId, long deviceId);
    
    void AddFrequency(long deviceGroupId, int frequence);
    
    void DeleteDeviceInGroup(long deviceGroupId, long deviceId);
    
}