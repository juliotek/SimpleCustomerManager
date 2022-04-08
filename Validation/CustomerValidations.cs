using InterfacesCustomer;

namespace Validation
{
    public class ValidatorBase
    {
        protected Lazy<List<string>> _errors;
        public ValidatorBase()
        {
            _errors = new Lazy<List<string>>(()=> new List<string>() );
        }     
        public List<string> errors { get { return _errors.Value;  } }
    }
    public class CustomerValidations : ValidatorBase, IValidator<ICustomer>
    {

        public List<string> Validate(ICustomer obj)
        {
            if (obj.Name.Length == 0)
            {
                _errors.Value.Add("Customer Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                _errors.Value.Add("Phone number is required");
            }
            if (obj.BillAmount == 0)
            {
                _errors.Value.Add("Bill Amount is required");
            }
            if (obj.BillDate >= DateTime.Now)
            {
                _errors.Value.Add("Bill date  is not proper");
            }
            if (obj.Address.Length == 0)
            {
                _errors.Value.Add("Address required");
            }

            return errors;
        }
    }

    public class LeadValidations : ValidatorBase, IValidator<ICustomer>
    {
        public List<string> Validate(ICustomer obj)
        {
            if (obj.Name.Length == 0)
            {
                _errors.Value.Add("Customer Name is required");
            }

            if (obj.PhoneNumber.Length == 0)
            {
                _errors.Value.Add("Phone number is required");
            }

            return errors;
        }
    }
}