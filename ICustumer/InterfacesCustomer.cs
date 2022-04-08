namespace InterfacesCustomer
{
    public interface ICustomer
    {
        string Type { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        List<string> Validate();

    }

    public interface IValidator<T>
    {
        List<string> Validate(T entity);
    }
}