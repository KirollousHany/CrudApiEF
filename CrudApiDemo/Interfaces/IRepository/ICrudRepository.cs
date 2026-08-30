namespace CrudApiDemo.Interfaces.IRepository
{
    public interface ICrudRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<bool> Add(T item);
        Task<bool> Delete(T item);
    }
}
