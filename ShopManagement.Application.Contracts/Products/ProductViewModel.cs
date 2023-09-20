﻿namespace ShopManagement.Application.Contracts.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Code { get; set; }

        public string Picture { get; set; }
        public long CategoryId { get; set; }
        public string Category { get; set; }
        public bool IsInStock { get; set; }
        public string CreationDate { get; set; }
    }
}
