using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Areas.Admin.VeiwModels
{
	public class EditProductViewModel
	{
		public Product Product { get; set; }
		public IQueryable<Image>? Images { get; set; }
	}
}
