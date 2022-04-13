using BusinessLogic;
using InterfacesCustomer;


namespace FactoryCustomer
{
    public class FactoryCustumerService<T> where T : ICustomer
    {
        private readonly IServiceProvider _serviceProvider;
        
        public FactoryCustumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICustomer? Create(string type)
        {
            if(type == "Customer")
            {
                return (ICustomer)_serviceProvider.GetService(typeof(Customer));
            }

            return (ICustomer)_serviceProvider.GetService(typeof(Lead));
        }
    }
}