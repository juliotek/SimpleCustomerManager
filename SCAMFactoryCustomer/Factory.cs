using SCAMServices;
using SCAMInterfacesCustomer;


namespace SCAMFactoryCustomer
{
    public class FactoryCustumerService<T> 
    {
        private readonly IServiceProvider _serviceProvider;
        
        public FactoryCustumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T? Create(string type)
        {
            if(type == "Customer")
            {
                return (T)_serviceProvider.GetService(typeof(Customer));
            }

            return (T)_serviceProvider.GetService(typeof(Lead));
        }
    }
}