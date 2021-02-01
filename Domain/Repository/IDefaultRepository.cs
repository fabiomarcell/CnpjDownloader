namespace Domain.Repository
{
    public interface IDefaultRepository<T>
    {
        void Save(T entity);
    }
}