using AdvertisingBillboards.DataAccessLayer.Repositories;
using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AdvertisingBillboards.Tests.Src.Tests.Services;

public class AdvertisementStatisticsServiceTest
{
    private Mock<IDbRepository<AdvertisementStatistics>> _advertisementStatisticsRepositoryMock;
    private Mock<IDbRepository<Advertisement>> _advertisementMock;
    private AdvertisementStatisticsService _sut;
    
    [SetUp]
    public void SetUp()
    {
        var mock = AutoMock.GetLoose();
        _advertisementStatisticsRepositoryMock = mock.Mock<IDbRepository<AdvertisementStatistics>>();
        _advertisementMock = mock.Mock<IDbRepository<Advertisement>>();

        _sut = mock.Create<AdvertisementStatisticsService>();
    }

    [Test]
    public void Get_ShouldReturnAdvertisementStatistics()
    {
        //Arrange
        const long advId = 2;

        var advertisementStatistics1 = new AdvertisementStatistics()
        {
            AdvertisementId = 2,
        };

        var advertisementStatistics2 = new AdvertisementStatistics()
        {
            AdvertisementId = 10,
        };

        _advertisementStatisticsRepositoryMock.Setup(r =>
            r.GetAll()).Returns(new[] { advertisementStatistics1, advertisementStatistics2 });
        
        //Act 
        var result = _sut.Get(advId);
        
        //Assert
        result.Should().Satisfy(r => r.AdvertisementId == advId);

    }

    [Test]
    public void Add_ShouldAddAdvertisementStatistics()
    {
        //Arrange
        const long advId = 7;
        
        //Act 
        _sut.AddAdvertisingStatistics(advId);
        
        //Assert
        _advertisementStatisticsRepositoryMock.Verify(r =>
            r.Create(It.Is<AdvertisementStatistics>(s => s.AdvertisementId == advId)));

    }
}