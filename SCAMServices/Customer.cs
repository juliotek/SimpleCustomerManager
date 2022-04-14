using SCAMInterfacesCustomer;

namespace SCAMServices
{
    public class CustomerBase : ICustomer
    {
        private IValidator<ICustomer> _validator;
        public CustomerBase(IValidator<ICustomer> validator)
        {
            _validator = validator;
        }

        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public decimal BillAmount { get; set; } = 0.0m;
        public DateTime BillDate { get; set; } = DateTime.Now;
        public string Address { get; set; } = "";

        public virtual List<string> Validate()
        {
            return _validator.Validate(this);
        }
    }

    public class Customer : CustomerBase
    {
        public Customer(IValidator<ICustomer> validator) : base (validator)
        {
                
        }
    }

    public class Lead : CustomerBase
    {
        public Lead(IValidator<ICustomer> validator): base(validator)
        {

        }
    }
}