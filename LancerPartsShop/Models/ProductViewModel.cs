﻿using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IQueryable<Image> Images { get; set; }
        public IQueryable<Product> Products { get; set; }
        public IQueryable<Category> Categories { get; set; }
        public TextField Delivery { get; set; }
        public TextField Payment { get; set; }
    }
}
