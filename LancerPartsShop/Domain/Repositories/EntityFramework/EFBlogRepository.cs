using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LancerPartsShop.Domain.Repositories.EntityFramework
{
	public class EFBlogRepository : IBlogItemRepository
	{
		private readonly AppDbContext context;

		public EFBlogRepository(AppDbContext context)
		{
			this.context = context;
		}
		public void DeleteBlogItem(Guid id)
		{
			context.BlogItems.Remove(new BlogItem() { Id = id });
			context.SaveChanges();
		}

		public BlogItem GetBlogItem(Guid id)
		{
			return context.BlogItems.FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<BlogItem> GetBlogItems()
		{
			return context.BlogItems;
		}

		public void SaveBlogItem(BlogItem entity)
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
