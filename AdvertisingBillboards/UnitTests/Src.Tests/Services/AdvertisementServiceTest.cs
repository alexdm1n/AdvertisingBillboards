using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AdvertisingBillboards.Tests.Src.Tests.Services;

public class AdvertisementServiceTest
{
    private Mock<IDbRepository<Advertisement>> _advertisementRepositoryMock;
    private AdvertisementService _sut;

    [SetUp]
    public void SetUp()
    {
        var mock = AutoMock.GetLoose();
        _advertisementRepositoryMock = mock.Mock<IDbRepository<Advertisement>>();
        _sut = mock.Create<AdvertisementService>();
    }

    [Test]
    public void GetAllForDevice_ShouldReturnAdvertisementsOfDevice()
    {
        // Arrange
        const long deviceId = 12;

        var advertisement1 = new Advertisement()
        {
            Device = new()
            {
                Id = 12,
            },
        };

        var advertisement2 = new Advertisement()
        {
            Device = new()
            {
                Id = 13,
            }
        };

        _advertisementRepositoryMock
            .Setup(r => r.GetAll()).Returns(new[] { advertisement1, advertisement2 });
        
        // Act
        var result = _sut.GetAllForDevice(deviceId);
        
        // Assert
        result.Should().Satisfy(r => r.Device.Id == deviceId);
    }

    [Test]
    public void Delete_ShouldDeleteAdvertisement()
    {
        // Arrange
        const long advertisementId = 3;

        var advertisement = new Advertisement()
        {
            Id = advertisementId,
            IsDeleted = false,
        };

        _advertisementRepositoryMock.Setup(r => r.Get(advertisementId)).Returns(advertisement);
        
        // Act
        _sut.Delete(advertisementId);
        
        // Assert
        _advertisementRepositoryMock
            .Verify(r => r
                .Delete(It.Is<Advertisement>(a => a.Id == advertisementId && a.IsDeleted)));
    }

    [Test]
    public void Update_ShouldUpdateAdvertisement()
    {
        // Arrange
        var advertisement = new Advertisement();
        
        // Act
        _sut.Update(advertisement);
        
        // Assert
        _advertisementRepositoryMock.Verify(r => r.Update(advertisement));
    }
}