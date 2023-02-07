using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IQueryable<Product> Products { get; set; }
        public TextField Delivery { get; set; }
        public TextField Payment { get; set; }
    }
}
