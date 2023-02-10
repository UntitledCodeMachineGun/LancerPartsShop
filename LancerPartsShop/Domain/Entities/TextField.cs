using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Text name (title)")]
        public override string Name { get; set; }

        [Display(Name = "Text")]
        public override string Description { get; set; }
	}
}
