using LancerPartsShop.Domain.Repositories.Abstract;

namespace LancerPartsShop.Domain
{
	public class DataManager
	{
		public ITextFieldsRepository TextFields {get; set;}
		public IBlogItemRepository BlogItems { get; set; }
		public ICategoryRepository Categories { get; set; }
		public IProductRepository Products { get; set; }
		public IImageRepository Imgaes { get; set; }

		public DataManager(ITextFieldsRepository textFields, IBlogItemRepository blogItems,
							ICategoryRepository categories, IProductRepository products,
							IImageRepository images)
		{
			TextFields = textFields;
			BlogItems = blogItems;
			Categories = categories;
			Products= products;
			Imgaes = images;
        }
	}
}
