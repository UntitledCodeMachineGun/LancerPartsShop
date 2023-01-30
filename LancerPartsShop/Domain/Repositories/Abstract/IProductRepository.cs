using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Domain.Repositories.Abstract
{
	public interface IProductRepository
    {
		IQueryable<Product> GetProducts();
		IQueryable<Product> GetProductsByCategory(Guid categoryId);
		Product GetProduct(Guid id);
		void SaveProduct(Product entity);
		void DeleteProduct(Guid id);
	}
}
