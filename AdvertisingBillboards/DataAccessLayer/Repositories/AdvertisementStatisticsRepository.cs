using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public class AdvertisementStatisticsRepository : BaseRepository<AdvertisementStatistics>
{
    public AdvertisementStatisticsRepository(AppDbContext context) : base(context) { }

    public override AdvertisementStatistics Get(long advId)
    {
        return _context.AdvertisementStatistics.SingleOrDefault(s => s.AdvertisementId == advId);
    }

    public override IEnumerable<AdvertisementStatistics> GetAll()
    {
        return _context.AdvertisementStatistics;
    }

    public override void Update(AdvertisementStatistics advertisementStatistics)
    {
        _context.Update(advertisementStatistics);
        _context.SaveChangesAsync();
    }

    public override void Create(AdvertisementStatistics advertisementStatistics)
    {
        _context.AdvertisementStatistics.Add(advertisementStatistics);
        _context.SaveChangesAsync();
    }

    public override void Delete(AdvertisementStatistics advertisementStatistics)
    {
        Update(advertisementStatistics);
    }

    public override void Delete(long id)
    {
        var advertisementStatistics = Get(id);
        _context.AdvertisementStatistics.Remove(advertisementStatistics);
    }
}