namespace AdvertisingBillboards.DataAccessLayer.Repositories;

public interface IDbRepository<T>
    where T : class
{
    IEnumerable<T> GetAll();

    T Get(long entityId);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);

    void Delete(long id);
}