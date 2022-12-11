using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public class UserService : IUserService
{
    private readonly IDbRepository<User> _userRepository;

    public UserService(IDbRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public void Delete(long userId)
    {
        _userRepository.Delete(userId);
    }

    public void Add(string userName)
    {
        var user = new User()
        {
            UserName = userName,
            Devices = new List<Device>(),
            DeviceGroups = new List<DeviceGroup>(),
            IsDeleted = false,
        };
        
        _userRepository.Create(user);
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }
}