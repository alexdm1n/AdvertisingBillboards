using AdvertisingBillboards.Models.Models;
using Microsoft.AspNetCore.Http;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public interface IAdvertisementService
{
    IEnumerable<Advertisement> GetAllForDevice(long deviceId);

    void Delete(long advertisementId);

    void Update(Advertisement advertisement);

    void Create(IFormFile uploadedVideo, long deviceId, string directory);
}