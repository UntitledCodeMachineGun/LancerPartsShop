using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Domain.Repositories.Abstract
{
	public interface ICategoryRepository
    {
		IQueryable<Category> GetCategories();
        Category GetCategory(Guid id);
		void SaveCategory(Category entity);
		void DeleteCategory(Guid id);
	}
}
