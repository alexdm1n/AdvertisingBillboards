using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using AdvertisingBillboards.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboards.Services;

internal class UserControllerService : IUserControllerService
{
    private readonly IDeviceService _deviceService;
    private readonly IUserService _userService;
    private readonly IAdvertisementService _advertisementService;
    private readonly IAdvertisementStatisticsService _advertisementStatisticsService;
    private readonly IDeviceGroupService _deviceGroupService;
    private readonly IDbRepository<User> _userRepository;
    
    public UserControllerService(
        IDeviceService deviceService,
        IUserService userService,
        IAdvertisementService advertisementService,
        IDeviceGroupService deviceGroupService,
        IDbRepository<User> userRepository)
    {
        _deviceService = deviceService;
        _userService = userService;
        _advertisementService = advertisementService;
        _deviceGroupService = deviceGroupService;
        _userRepository = userRepository;
    }

    public AdvertisementViewModel Advertisement(long deviceId)
    {
        var advertisement = _advertisementService.GetAllForDevice(deviceId)?.FirstOrDefault();
        if (advertisement == null)
        {
            return new()
            {
                Advertisement = new()
                {
                    FileName = "DasAuto.mp4",
                    Id = 1,
                    Device = new()
                    {
                        Id = deviceId,
                    }
                },
                Device = _deviceService.GetAll().SingleOrDefault(d => d.Id == deviceId),
            };
        }

        var statistics = _advertisementStatisticsService.Get(advertisement.Id)?.SingleOrDefault();
        if (statistics != null)
        {
            statistics.TotalViews += 1;
            _advertisementStatisticsService.Update(statistics);
        }

        return new()
        {
            Advertisement = advertisement,
            Device = _deviceService.GetAll().SingleOrDefault(d => d.Id == deviceId),
        };
    }

    public UsersDeviceGroupsViewModel DeviceGroups()
    {
        var deviceGroups = _deviceGroupService.Get();
        var users = _userService.GetAll();
        return new(users, deviceGroups);
    }

    public UserDeviceViewModel Devices(long? userId = null)
    {
        var device = _deviceService.GetAll(userId);
        var user = _userService.GetAll().FirstOrDefault();
            
        return new (user, device);
    }
    
    public void SubmitFrequencyForDevice(long deviceId, int frequency)
    {
        _deviceService.SetFrequency(deviceId, frequency);
    }

    public void SubmitFrequencyForDeviceGroup(long deviceGroupId, int frequency)
    {
        _deviceGroupService.AddFrequency(deviceGroupId, frequency);
    }

}