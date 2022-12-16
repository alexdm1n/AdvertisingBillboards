using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services.VideoAnalyzer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

internal class AdvertisementService : IAdvertisementService
{
    private readonly IDbRepository<Advertisement> _advertisementRepository;
    private readonly IDbRepository<Device> _deviceRepository;
    private readonly IAdvertisementStatisticsService _advertisementStatisticsService;

    public AdvertisementService(
        IDbRepository<Advertisement> advertisementRepository,
        IDbRepository<Device> deviceRepository,
        IVideoAnalyzerService videoAnalyzerService,
        IAdvertisementStatisticsService advertisementStatisticsService)
    {
        _advertisementRepository = advertisementRepository;
        _deviceRepository = deviceRepository;
        _advertisementStatisticsService = advertisementStatisticsService;
    }

    public IEnumerable<Advertisement> GetAllForDevice(long deviceId)
    {
        return _advertisementRepository.GetAll().Where(a => a.Device.Id == deviceId);
    }

    public void Delete(long advertisementId)
    {
        var advertisement = _advertisementRepository.Get(advertisementId);
        if (File.Exists(advertisement.Path))
        {
            File.Delete(advertisement.Path);
        }

        advertisement.IsDeleted = true;
        _advertisementRepository.Delete(advertisement);
    }

    public void Update(Advertisement advertisement)
    {
        _advertisementRepository.Update(advertisement);
    }

    public void Create(IFormFile uploadedVideo, long deviceId, string dir)
    {
        var advertisement = new Advertisement();

        var device = _deviceRepository.Get(deviceId);

        var blankAdvertisementId = _advertisementRepository.GetAll().LastOrDefault()?.Id ?? 0;

        advertisement.FileName = $"device-{deviceId}-adv-{blankAdvertisementId + 1}.mp4";
        
        using (var fileStream = new FileStream(Path.Combine(dir, $"Videos/{advertisement.FileName}"), FileMode.Create, FileAccess.Write))
        {
            uploadedVideo.CopyTo(fileStream);
        }
        var filePath = Path.Combine(dir, "Videos");

        advertisement.Path = filePath;
        advertisement.DeviceId = deviceId;

        if (device.Advertisements == null)
        {
            device.Advertisements = new[]
            {
                advertisement
            };
        }
        else
        {
            device.Advertisements = device.Advertisements.Append(advertisement);
        }

        _advertisementRepository.Create(advertisement);
        _deviceRepository.Update(device);
        _advertisementStatisticsService.AddAdvertisingStatistics(advertisement.Id);
    }
}