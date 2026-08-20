namespace CrudApiDemo.Interfaces.IRepository
{
    public interface ICrudRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Add(T item);
        bool Delete(T item);
    }
}
