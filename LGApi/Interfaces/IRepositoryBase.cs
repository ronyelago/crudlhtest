namespace LGApi.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<T?> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T type);
    Task Update(T type);
    Task Delete(T type);
}