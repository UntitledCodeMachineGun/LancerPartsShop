using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Domain.Entities
{
    public class BlogItem : EntityBase
    {
        [Required(ErrorMessage = "Fill the name of post")]
        [Display(Name = "Post name (title)")]
        public override string Name { get; set; }

        [Display(Name = "Short post text")]
        public override string Subtitle { get; set; }

        [Display(Name = "Full post text")]
        public override string Description { get; set; }
    }
}
