using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LancerPartsShop.Domain.Repositories.EntityFramework
{
	public class EFImageRepository : IImageRepository
    {
		private readonly AppDbContext context;

		public EFImageRepository(AppDbContext context)
		{
			this.context = context;
		}
		public void DeleteImage(Guid id)
		{
			context.Images.Remove(new Image() { Id = id });
			context.SaveChanges();
		}

		public Image GetImage(Guid id)
		{
			return context.Images.FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<Image> GetImages()
		{
			return context.Images;
		}
        public IQueryable<Image> GetImagesByProduct(Guid productId)
        {
            return context.Images.Where(x=> x.ProductId == productId);
        }

        public void SaveImage(Image entity)
		{
			if (entity.Id == default)
			{
				context.Entry(entity).State = EntityState.Added;
			}
			else
			{ 
				context.Entry(entity).State = EntityState.Modified;
			}
			context.SaveChanges();
		}
	}
}
