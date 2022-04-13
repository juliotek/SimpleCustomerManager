using FactoryCustomer;
using InterfacesCustomer;
using InterfacesData;
using Microsoft.AspNetCore.Mvc;
using SimpleCustomerAppManager.DTO;
using FactoryRepository;
using System.Text.Json;

namespace SimpleCustomerAppManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustumerController : ControllerBase
    {
        private readonly FactoryCustumerService<ICustomer> _custumerFactory;
        private readonly FactoryRepositoryService<IDataRepository<ICustomer>> _repositoryFactory;
        public CustumerController(FactoryCustumerService<ICustomer> custumerFactory, FactoryRepositoryService<IDataRepository<ICustomer>> repositoryFactory)
        {
            _custumerFactory = custumerFactory;
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        [Route("/GetType")]
        public ICustomer? GetType(string type)
        {
            return _custumerFactory.Create(type);                    
        }

        [HttpPost]
        [Route("/Save")]
        public IActionResult Save(CustomerDTO model)
        {
            ICustomer cust = _custumerFactory.Create(model.Type);
            cust.Type = model.Type;
            cust.Name = model.Name;
            cust.PhoneNumber = model.PhoneNumber;
            cust.Address = model.Address;
            cust.BillAmount = model.BillAmount;
            cust.BillDate = model.BillDate;

            var repo = _repositoryFactory.Create("ADO.NET");

            repo.Add(cust);
            repo.Save();

            return Ok();

        }

        [HttpGet]
        [Route("/GetAll")]
        public List<ICustomer> GetAll()
        {
            var repo = _repositoryFactory.Create("ADO.NET");
            return repo.GetAll();
        }

    }
}
