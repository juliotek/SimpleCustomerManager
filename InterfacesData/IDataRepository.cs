namespace InterfacesData
{
    public interface IDataRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        List<T> GetAll();
        void Save();

    }
}