using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public IQueryable<Product> Products { get; set; }
        public IQueryable<Image> Images { get; set; }
    }
}
