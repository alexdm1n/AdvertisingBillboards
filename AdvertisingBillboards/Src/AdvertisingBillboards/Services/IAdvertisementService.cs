using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public interface IAdvertisementService
{
    IEnumerable<Advertisement> GetAllForDevice(long deviceId);

    void Delete(long advertisementId);

    void Update(Advertisement advertisement);

    Task<string> Create(Advertisement advertisement, long deviceId, long advLength);
}