using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public class DeviceGroupService : IDeviceGroupService
{
    private readonly IDbRepository<Device> _deviceRepository;
    private readonly IDbRepository<DeviceGroup> _deviceGroupRepository;
    private readonly IDbRepository<User> _userRepository;
    
    public DeviceGroupService(
        IDbRepository<User> userRepository, 
        IDbRepository<DeviceGroup> deviceGroupRepository, 
        IDbRepository<Device> deviceRepository)
    {
        _userRepository = userRepository;
        _deviceGroupRepository = deviceGroupRepository;
        _deviceRepository = deviceRepository;
    }

    public IEnumerable<DeviceGroup> Get(long? userId = null)
    {
        var deviceGroups = _deviceGroupRepository.GetAll();
        return userId != null ? deviceGroups.Where(g => g.User.Id == userId) : deviceGroups;
    }

    public void Add(long id)
    {
        var user = _userRepository.GetAll().SingleOrDefault(u => u.Id == id);
        if (user == null)
        {
            return;
        }
        var deviceGroup = new DeviceGroup { User = user };
        user.DeviceGroups = user.DeviceGroups.Append(deviceGroup);
        _deviceGroupRepository.Create(deviceGroup);
        _userRepository.Update(user);
    }

    public void Delete(long id)
    {
        var deviceGroup = _deviceGroupRepository.GetAll().SingleOrDefault(dg => dg.Id == id);
        if (deviceGroup != null)
        {
            deviceGroup.IsDeleted = true;
            _deviceGroupRepository.Delete(deviceGroup);
        }
    }

    public void AddDeviceInGroup(long deviceGroupId, long deviceId)
    {
        var deviceGroup = _deviceGroupRepository.Get(deviceGroupId);
        var device = _deviceRepository.Get(deviceId);
        deviceGroup.Devices = deviceGroup.Devices.Append(device);
        device.DeviceGroup = deviceGroup;
        
        _deviceGroupRepository.Update(deviceGroup);
        _deviceRepository.Update(device);
    }
    
    public void AddFrequency(long deviceGroupId, int frequence)
    {
        var deviceGroup = _deviceGroupRepository.Get(deviceGroupId);
        foreach (var device in deviceGroup.Devices)
        {
            device.Frequency = frequence;
            _deviceRepository.Update(device);
        }
        _deviceGroupRepository.Update(deviceGroup);
    }
    
    public void DeleteDeviceInGroup(long deviceGroupId, long deviceId)
    {
        var deviceGroup = _deviceGroupRepository.Get(deviceGroupId);
        var device = _deviceRepository.Get(deviceId);
        deviceGroup.Devices = deviceGroup.Devices.Where(d => d.Id != deviceId);
        device.DeviceGroup = null;

        _deviceGroupRepository.Update(deviceGroup);
        _deviceRepository.Update(device);
    }
}
