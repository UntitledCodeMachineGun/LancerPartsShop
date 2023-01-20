using LancerPartsShop.Domain.Repositories.Abstract;

namespace LancerPartsShop.Domain
{
	public class DataManager
	{
		public ITextFieldsRepository TextFields {get; set;}
		public IBlogItemRepository BlogItems { get; set; }

		public DataManager(ITextFieldsRepository textFields, IBlogItemRepository blogItems)
		{
			TextFields = textFields;
			BlogItems = blogItems;
		}
	}
}
