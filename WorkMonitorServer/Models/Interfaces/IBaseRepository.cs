namespace WorkMonitorServer.Models.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task Add (T entity);
        //Task<T> AddIfNotExist(T entity);
        void Update(T entity);
        void Delete(T entity);
        //Task<T?> Find(T entity);
        Task<List<T>> Get();
        Task Save();
    }
}
