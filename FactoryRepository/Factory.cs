using InterfacesData;
using ADORepository;

namespace FactoryRepository
{
    public class FactoryRepositoryService<IDataRepository>
    {
        private readonly IServiceProvider _serviceProvider;

        public FactoryRepositoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDataRepository Create(string type)
        {
            return (IDataRepository)_serviceProvider.GetService(typeof(CustomerADO));
        }

    }
}