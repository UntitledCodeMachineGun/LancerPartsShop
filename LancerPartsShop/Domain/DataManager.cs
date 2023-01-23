using LancerPartsShop.Domain.Repositories.Abstract;

namespace LancerPartsShop.Domain
{
	public class DataManager
	{
		public ITextFieldsRepository TextFields {get; set;}
		public IBlogItemRepository BlogItems { get; set; }
		public ICategoryRepository Categories { get; set; }

		public DataManager(ITextFieldsRepository textFields, IBlogItemRepository blogItems, ICategoryRepository categories)
		{
			TextFields = textFields;
			BlogItems = blogItems;
			Categories = categories;

        }
	}
}
