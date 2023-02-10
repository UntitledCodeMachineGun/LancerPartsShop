using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Domain.Repositories.Abstract
{
	public interface IImageRepository
    {
		IQueryable<Image> GetImages();
		IQueryable<Image> GetImagesByProduct(Guid productId);
        Image GetImage(Guid id);
		void SaveImage(Image entity);
		void DeleteImage(Guid id);
	}
}
