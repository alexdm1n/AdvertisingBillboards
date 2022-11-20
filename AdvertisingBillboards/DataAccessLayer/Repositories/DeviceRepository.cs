using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public class DeviceRepository : BaseRepository<Device>
{
    public DeviceRepository(AppDbContext context) : base(context) { }

    public override Device Get(long id)
    {
        return _context.Devices.SingleOrDefault(d => d.Id == id);
    }

    public override IEnumerable<Device> GetAll()
    {
        return _context.Devices.Where(d => !d.IsDeleted);
    }

    public override void Update(Device device)
    {
        _context.Update(device);
        _context.SaveChangesAsync();
    }

    public override void Create(Device device)
    {
        _context.Devices.Add(device);
        _context.SaveChangesAsync();
    }

    public override void Delete(Device device)
    {
        Update(device);
    }

    public override void Delete(long id)
    {
        var device = Get(id);
        device.IsDeleted = true;
        Update(device);
    }
}