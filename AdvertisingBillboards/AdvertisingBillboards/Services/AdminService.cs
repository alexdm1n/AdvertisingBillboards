using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using AdvertisingBillboards.ViewModels;

namespace AdvertisingBillboards.Services;

internal class AdminService : IAdminService
{
    private readonly IDeviceService _deviceService;
    private readonly IUserService _userService;
    private readonly IAdvertisementService _advertisementService;
    private readonly IAdvertisementStatisticsService _advertisementStatisticsService;
    private readonly IDeviceGroupService _deviceGroupService;
    private readonly IDbRepository<User> _userRepository;
    
    private readonly string _dir;

    public AdminService(
        IDeviceService deviceService,
        IUserService userService,
        IAdvertisementService advertisementService,
        IAdvertisementStatisticsService advertisementStatisticsService,
        IDeviceGroupService deviceGroupService,
        IDbRepository<User> userRepository, 
        IWebHostEnvironment env)
    {
        _deviceService = deviceService;
        _userService = userService;
        _advertisementService = advertisementService;
        _advertisementStatisticsService = advertisementStatisticsService;
        _deviceGroupService = deviceGroupService;
        _userRepository = userRepository;
        _dir = env.WebRootPath;
    }

    public ViewBagModel GetModelsCount()
    {
        return new()
        {
            DevicesAmount = _deviceService.GetAll().Count(),
            UsersAmount = _userService.GetAll().Count(),
            AdvertisementsAmount = _advertisementService.GetAllForDevice(0).Count(),
        };
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
                    Device = new()
                    {
                        Id = deviceId,
                    }
                },
                Device = _deviceService.GetAll().SingleOrDefault(d => d.Id == deviceId),
            };
        }

        var statistics = _advertisementStatisticsService.Get(advertisement.Id)?.SingleOrDefault();
        if (statistics != null) statistics.TotalViews += 1;
        _advertisementStatisticsService.Update(statistics);
            
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

    public UsersDevicesViewModel Devices(long? userId = null)
    {
        var devices = _deviceService.GetAll(userId);
        var users = _userService.GetAll();
            
        return new (users, devices);
    }

    public IEnumerable<User> UsersList()
    {
        return _userService.GetAll();
    }

    public void AddUser(string name)
    {
        _userService.Add(name);
    }

    public void DeleteUser(long userId)
    {
        _userService.Delete(userId);
    }

    public void AddDevice(long userId)
    {
        _deviceService.Add(userId);
    }

    public void DeleteDevice(long id)
    {
        _deviceService.Delete(id);
    }

    public void AddDeviceGroup(long userId)
    {
        var user = _userService.GetAll().SingleOrDefault(u => u.Id == userId);
        var deviceGroup = new DeviceGroup { User = user, UserId = user.Id };

        if (user.DeviceGroups != null)
        {
            user.DeviceGroups = user.DeviceGroups.Append(deviceGroup);
        }
        else
        {
            user.DeviceGroups = new[]
            {
                deviceGroup,
            };
        }
        
        _deviceGroupService.Create(deviceGroup);
        _userRepository.Update(user);
    }

    public void SubmitFrequencyForDevice(long deviceId, int frequency)
    {
        _deviceService.SetFrequency(deviceId, frequency);
    }

    public void SubmitFrequencyForDeviceGroup(long deviceGroupId, int frequency)
    {
        _deviceGroupService.AddFrequency(deviceGroupId, frequency);
    }

    public void DeleteDeviceGroup(long deviceGroupId)
    {
        _deviceGroupService.Delete(deviceGroupId);
    }

    public AdvertisementStatistics AdvertisementStatistics(long advertisementId)
    {
        return _advertisementStatisticsService.Get(advertisementId).FirstOrDefault();
    }

    public void DeleteAdvertisement(long advId)
    {
        _advertisementService.Delete(advId);
    }

    public void UploadVideo(IFormFile uploadedVideo, long deviceId)
    {
        using (var fileStream = new FileStream(Path.Combine(_dir, "file.mp4"), FileMode.Create, FileAccess.Write))
        {
            uploadedVideo.CopyTo(fileStream);
        }

        var advertisement = new Advertisement();
        _advertisementService.Create(advertisement, deviceId);
    }
}