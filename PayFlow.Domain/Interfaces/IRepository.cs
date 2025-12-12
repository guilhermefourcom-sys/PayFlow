namespace PayFlow.Domain.Interfaces
{
    public interface IRepository
    {
        T? Add<T>(T obj) where T : class;
        Task<T?> AddAsync<T>(T obj) where T : class;
    }
}
