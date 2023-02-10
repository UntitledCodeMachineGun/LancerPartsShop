using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Domain.Entities
{
    public class Image
    {
		[Required]
		public Guid Id { get; set; }
		public string Path { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

		[DataType(DataType.Time)]
		public DateTime DateAdded { get; set; }

        public Image() { DateAdded = DateTime.UtcNow; }

		public Image(string path, Product product)
        {
            Path = path;
		    Product = product;
		    ProductId = product.Id;

            DateAdded = DateTime.UtcNow;
        }
	}
}
