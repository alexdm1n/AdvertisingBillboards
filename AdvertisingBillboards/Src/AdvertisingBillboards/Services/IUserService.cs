using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

internal interface IUserService
{
    void Delete(User user);

    void Add(string userName);

    IEnumerable<User> GetAll();
}