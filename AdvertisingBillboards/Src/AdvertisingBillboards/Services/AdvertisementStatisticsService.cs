using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public class AdvertisementStatisticsService : IAdvertisementStatisticsService
{
    private readonly IDbRepository<AdvertisementStatistics> _advertisementStatisticsRepository;
    private readonly IDbRepository<Advertisement> _advertisementRepository;

    public AdvertisementStatisticsService(IDbRepository<AdvertisementStatistics> advertisementStatisticsRepository,
        IDbRepository<Advertisement> advertisementRepository)
    {
        _advertisementStatisticsRepository = advertisementStatisticsRepository;
        _advertisementRepository = advertisementRepository;
    }

    public IEnumerable<AdvertisementStatistics> Get(long advId)
    {
        return _advertisementStatisticsRepository.GetAll().Where(s => s.AdvertisementId == advId);
    }
    
    public void AddAdvertisingStatistics(long advId)
    {
        var advertisement = _advertisementRepository.Get(advId);
        AdvertisementStatistics advertisementStatistics = new AdvertisementStatistics()
        {
            TotalViews = 0,
            AdvertisementId = advId,
        };

        _advertisementStatisticsRepository.Create(advertisementStatistics);
    }
}