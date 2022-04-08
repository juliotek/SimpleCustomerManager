using FactoryCustomer;
using InterfacesCustomer;
using Microsoft.AspNetCore.Mvc;
using SimpleCustomerAppManager.DTO;
using System.Text.Json;

namespace SimpleCustomerAppManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustumerController : ControllerBase
    {
        private readonly FactoryCustumerService<ICustomer> _custumerFactory;
        public CustumerController(FactoryCustumerService<ICustomer> custumerFactory)
        {
            _custumerFactory = custumerFactory;
        }

        [HttpGet(Name = "GetType")]
        public ICustomer? GetType(string type)
        {
            return _custumerFactory.Create(type);                    
        }

        [HttpPost(Name = "Save")]
        public IActionResult Save(CustomerDTO model)
        {
            ICustomer cust = _custumerFactory.Create(model.Type);
            cust.Type = model.Type;
            cust.Name = model.Name;
            cust.PhoneNumber = model.PhoneNumber;
            cust.Address = model.Address;
            cust.BillAmount = model.BillAmount;
            cust.BillDate = model.BillDate;

            return Ok(cust.Validate());

        }
    }
}
