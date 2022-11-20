using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;
using AdvertisingBillboards.Models.Models;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(AppDbContext context) : base(context) { }

    public override User Get(long id)
    {
        return _context.Users.SingleOrDefault(u => u.Id == id);
    }

    public override IEnumerable<User> GetAll()
    {
        return _context.Users.Where(u => !u.IsDeleted);
    }

    public override void Update(User user)
    {
        _context.Update(user);
        _context.SaveChangesAsync();
    }

    public override void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChangesAsync();
    }

    public override void Delete(User user)
    {
        Update(user);
    }

    public override void Delete(long id)
    {
        var user = Get(id);
        user.IsDeleted = true;
        Update(user);
    }
}