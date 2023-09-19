namespace ShopManagement.Application.Contracts.ProductCategorys
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreateDate { get; set; }

        public long ProductCount {  get; set; }
    }
}
