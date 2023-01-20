using LancerPartsShop.Service;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Domain.Entities
{
    // is this class a mistake?
    public abstract class EntityBase
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Name (title)")]
        public virtual string Name { get; set; }

        [Display(Name = "Short description")]
        public virtual string? Subtitle { get; set; }

        [Display(Name="Full description")]
        public virtual string? Description { get; set; }

        [Display(Name = "Image in .jpg or .png extension")]
        public virtual string? TitleImagePath { get; set; } = "slide1.jpg";

        [Display(Name = "Seo metatag title")]
        public string? MetaTitle { get; set; }

        [Display(Name = "Seo metatag description")]
        public string? MetaDescription { get; set; }

		[Display(Name = "Seo metatag keywords")]
        public string? MetaKeyords { get; set; }

		[DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

        protected EntityBase() => DateAdded = DateTime.UtcNow;
    }
}
