using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public class AdvertisementRepository : BaseRepository<Advertisement>
{
    public AdvertisementRepository(AppDbContext context) : base(context) { }
    
    public override Advertisement Get(long advertisementId)
    {
        return _context.Advertisements.SingleOrDefault(a => a.Id == advertisementId);
    }

    public override IEnumerable<Advertisement> GetAll()
    {
        return _context.Advertisements.Where(a => !a.IsDeleted);
    }

    public override void Update(Advertisement advertisement)
    {
        _context.Update(advertisement);
        _context.SaveChangesAsync();
    }

    public override void Create(Advertisement advertisement)
    {
        _context.Advertisements.Add(advertisement);
        _context.SaveChanges();
    }

    public override void Delete(Advertisement advertisement)
    {
        Update(advertisement);
    }

    public override void Delete(long advertisementId)
    {
        var advertisement = _context.Advertisements.SingleOrDefault(a => a.Id == advertisementId);
        if (advertisement is not null)
        {
            advertisement.IsDeleted = true;
            Update(advertisement);
        }
    }
    
    
}