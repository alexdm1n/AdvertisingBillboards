using AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;

namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public abstract class BaseRepository<T> 
    : IDbRepository<T> where T: class
{
    protected readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public abstract void Create(T entity);

    public abstract void Delete(T entity);

    public abstract void Delete(long id);

    public abstract T Get(long entityId);

    public abstract IEnumerable<T> GetAll();

    public abstract void Update(T entity);
}