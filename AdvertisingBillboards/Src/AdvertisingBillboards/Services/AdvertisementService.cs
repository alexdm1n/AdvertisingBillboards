using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services.VideoAnalyzer;
using Microsoft.AspNetCore.Hosting;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

internal class AdvertisementService : IAdvertisementService
{
    private readonly IDbRepository<Advertisement> _advertisementRepository;
    private readonly IDbRepository<Device> _deviceRepository;
    private readonly IVideoAnalyzerService _videoAnalyzerService;
    private readonly string _directory;

    public AdvertisementService(
        IDbRepository<Advertisement> advertisementRepository,
        IDbRepository<Device> deviceRepository,
        IHostingEnvironment environment,
        IVideoAnalyzerService videoAnalyzerService)
    {
        _advertisementRepository = advertisementRepository;
        _deviceRepository = deviceRepository;
        _videoAnalyzerService = videoAnalyzerService;
        _directory = environment.WebRootPath;
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

    public async Task<string> Create(Advertisement advertisement, long deviceId, long advLength)
    {
        var device = _deviceRepository.Get(deviceId);

        advertisement.Device = device;
        advertisement.Duration = await _videoAnalyzerService.GetVideoDuration(_directory);

        var blankAdvertisementId = _advertisementRepository.GetAll().LastOrDefault()?.Id ?? 0;

        advertisement.FileName = $"device-{deviceId}-adv-{blankAdvertisementId + 1}.mp4";
        var filePath = Path.Combine(_directory, "Videos");

        advertisement.Path = filePath;
        advertisement.MemoryLength = advLength;

        device.Advertisements = device.Advertisements.Append(advertisement);
        _advertisementRepository.Create(advertisement);
        _deviceRepository.Update(device);
        
        // Todo: add adv statistics

        return filePath;
    }
}