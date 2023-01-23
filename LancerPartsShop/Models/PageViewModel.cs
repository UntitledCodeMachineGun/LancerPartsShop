using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Models
{
    public class PageViewModel
    {
        public TextField TextField { get; set; }
        public IQueryable<BlogItem> BlogItems { get; set; }
    }
}
