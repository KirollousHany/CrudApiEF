namespace CrudApiDemo.Interfaces.IService
{
    public interface ICrudService<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Add(T item);
        bool Delete(int id);
    }
}
