using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public class DeviceGroupRepository : BaseRepository<DeviceGroup>
{
    public DeviceGroupRepository(AppDbContext context) : base(context) { }

    public override DeviceGroup Get(long id)
    {
        return _context.DeviceGroups.SingleOrDefault(g => g.Id == id);
    }

    public override IEnumerable<DeviceGroup> GetAll()
    {
        return _context.DeviceGroups.Where(g => !g.IsDeleted);
    }

    public override void Update(DeviceGroup deviceGroup)
    {
        _context.Update(deviceGroup);
        _context.SaveChangesAsync();
    }

    public override void Create(DeviceGroup deviceGroup)
    {
        _context.DeviceGroups.Add(deviceGroup);
        _context.SaveChangesAsync();
    }

    public override void Delete(DeviceGroup deviceGroup)
    {
        Update(deviceGroup);
    }

    public override void Delete(long id)
    {
        var deviceGroup = Get(id);
        deviceGroup.IsDeleted = true;
        Update(deviceGroup);
    }
}