using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public class AdvertisementRepository : BaseRepository<Advertisement>
{
    public AdvertisementRepository(AppDbContext context) : base(context) { }
    
    public override Advertisement Get(long entityId)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Advertisement> GetAll()
    {
        throw new NotImplementedException();
    }

    public override void Update(Advertisement entity)
    {
        throw new NotImplementedException();
    }

    public override void Create(Advertisement entity)
    {
        _context.Advertisements.Add(entity);
        _context.SaveChanges();
    }

    public override void Delete(Advertisement entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long id)
    {
        throw new NotImplementedException();
    }
}