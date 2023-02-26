using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Domain.Entities
{
    public class Product : EntityBase
    {
        [Required]
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [Required(ErrorMessage = "Fill the name of the product")]
        [Display(Name = "Product name (title)")]
        public override string Name { get; set; }

        [Display(Name = "Part number")]
        public string PartNumber { get; set; }

        [Display(Name = "Full product text")]
        public override string? Description { get; set; }

        [Display(Name = "Short product text")]
        public override string? Subtitle { get; set; }

        [Display(Name = "Product price")]
        public double Price { get; set; }

        [Display(Name = "Image in .jpg or .png extension")]
        public virtual ICollection<Image> Images { get; set; }

        [Display(Name = "Image in .jpg or .png extension")]
        public override string? TitleImagePath { get; set; } = "slide1.jpg";
    }
}
