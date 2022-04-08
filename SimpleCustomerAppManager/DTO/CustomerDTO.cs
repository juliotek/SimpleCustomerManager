namespace SimpleCustomerAppManager.DTO
{
    public class CustomerDTO
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public decimal BillAmount { get; set; } = 0.0m;
        public DateTime BillDate { get; set; } = DateTime.Now;
        public string Address { get; set; } = "";
    }
}
