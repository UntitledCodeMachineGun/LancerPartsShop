using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Domain.Repositories.Abstract
{
	public interface IBlogItemRepository
	{
		IQueryable<BlogItem> GetBlogItems();
		BlogItem GetBlogItem(Guid id);
		void SaveBlogItem(BlogItem entity);
		void DeleteBlogItem(Guid id);
	}
}
