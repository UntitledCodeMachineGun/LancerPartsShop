using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Domain.Entities
{
    public class Category : EntityBase
    {
        [Required(ErrorMessage = "Fill the name of the category")]
        [Display(Name = "Category name (title)")]
        public override string Name { get; set; }

        [Display(Name = "Full category text")]
        public override string Description { get; set; }

        [Display(Name = "Image in .jpg or .png extension")]
        public override string? TitleImagePath { get; set; } = "catgory1.jpg";
    }
}
