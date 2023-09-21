namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class SearchCustomerDiscount
    {
        public long ProductId { get;  set; }
        public int DiscountRate { get;  set; }
        public string StartDate { get;  set; }
        public string EndDate { get; set; }
    }
}
