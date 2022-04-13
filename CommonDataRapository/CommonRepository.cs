using InterfacesData;

namespace CommonDataRapository
{
    public abstract class CommonRepository<T> : IDataRepository<T>
    {
        protected string ConnectionString = string.Empty;

        protected List<T> Res = new List<T>();

        public CommonRepository(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;  
        }
        public virtual void Add(T entity)
        {
            Res.Add(entity);
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}