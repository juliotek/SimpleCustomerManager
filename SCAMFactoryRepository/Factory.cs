using SCAMInterfacesData;
using SCAMDataAccessAdo;

namespace SCAMFactoryRepository
{
    public class FactoryRepositoryService<T>
    {
        private readonly IServiceProvider _serviceProvider;

        public FactoryRepositoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Create(string type)
        {
            return (T)_serviceProvider.GetService(typeof(CustomerADO));
        }

    }
}