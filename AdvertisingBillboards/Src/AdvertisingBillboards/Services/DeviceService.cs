using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

internal class DeviceService : IDeviceService
{
    private readonly IDbRepository<Device> _deviceRepository;
    private readonly IDbRepository<User> _userRepository;

    public DeviceService(IDbRepository<Device> deviceRepository, IDbRepository<User> userRepository)
    {
        _deviceRepository = deviceRepository;
        _userRepository = userRepository;
    }

    public void Add(long userId)
    {
        var user = _userRepository.Get(userId);
        var device = new Device()
        {
            User = user,
            Frequency = 1,
        };

        user.Devices = user.Devices.Append(device);
        
        _deviceRepository.Create(device);
        _userRepository.Update(user);
    }

    public IEnumerable<Device> GetAll(long? userId = null)
    {
        var devices = _deviceRepository.GetAll();
        if (userId is null)
        {
            return devices;
        }

        return devices.Where(d => d.User.Id == userId);
    }

    public void Update(Device device)
    {
        _deviceRepository.Update(device);
    }

    public IEnumerable<Device> GetByDeviceGroupId(long deviceGroupId)
    {
        return _deviceRepository.GetAll().Where(d => d.DeviceGroup.Id == deviceGroupId);
    }

    public void SetFrequency(long deviceId, int frequency)
    {
        var device = _deviceRepository.Get(deviceId);
        device.Frequency = frequency;
        _deviceRepository.Update(device);
    }
}