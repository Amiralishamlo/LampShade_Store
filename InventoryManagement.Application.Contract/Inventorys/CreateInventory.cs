using _0_Framework.Application;
using ShopManagement.Application.Contracts.Products;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.Inventorys
{
    public class CreateInventory
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
