using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AdvertisingBillboards.Tests.Src.Tests.Services;

public class DeviceGroupServiceTest
{
    private Mock<IDbRepository<Device>> _deviceRepository;
    private Mock<IDbRepository<DeviceGroup>> _deviceGroupRepository;
    private Mock<IDbRepository<User>> _userRepository;
    private DeviceGroupService _sut;

    [SetUp]
    public void SetUp()
    {
        var mock = AutoMock.GetLoose();
        _deviceRepository = mock.Mock<IDbRepository<Device>>();
        _deviceGroupRepository = mock.Mock<IDbRepository<DeviceGroup>>();
        _userRepository = mock.Mock<IDbRepository<User>>();
        _sut = mock.Create<DeviceGroupService>();
    }

    [Test]
    public void Get_ShouldReturnDeviceGroups()
    {

        //Arrange
        const long UserId = 28;

        var User1 = new DeviceGroup()
        {
            User = new User()
            {
                Id = 28,
            },
        };

        var User2 = new DeviceGroup()
        {
            User = new User()
            {
                Id = 29,
            },
        };

        _deviceGroupRepository.Setup(r => r.GetAll()).Returns(new[] { User1, User2 });

        // Act
        var result = _sut.Get(UserId);

    // Assert
        result.Should().Satisfy(r => r.User.Id == UserId);
    }

    [Test]
    public void Delete_ShouldDeleteDeviceGroup()
    {
        
    }

}