namespace CrudApiDemo.Interfaces.IService
{
    public interface ICrudService<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<bool> Add(T item);
        Task<bool> Delete(int id);
    }
}
