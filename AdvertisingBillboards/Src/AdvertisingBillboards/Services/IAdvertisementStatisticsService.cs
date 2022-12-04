using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public interface IAdvertisementStatisticsService
{
    IEnumerable<AdvertisementStatistics> Get(long advId);
    
    void AddAdvertisingStatistics(long advId);

    void Update(AdvertisementStatistics advertisementStatistics);
}