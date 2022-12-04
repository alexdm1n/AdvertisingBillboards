﻿using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services;

public class UserService : IUserService
{
    private readonly IDbRepository<User> _userRepository;

    public UserService(IDbRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public void Delete(User user)
    {
        _userRepository.Delete(user);
    }

    public void Add(string userName)
    {
        var user = new User()
        {
            UserName = userName
        };
        
        _userRepository.Create(user);
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }
}