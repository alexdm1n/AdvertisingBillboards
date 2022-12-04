using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public interface IDeviceService
{
    void Add(long userId);

    IEnumerable<Device> GetAll(long? userId = null);

    void Update(Device device);

    IEnumerable<Device> GetByDeviceGroupId(long deviceGroupId);

    void SetFrequency(long deviceId, int frequency);

    void Delete(long id);
}