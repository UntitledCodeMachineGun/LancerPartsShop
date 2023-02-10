using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LancerPartsShop.Domain.Repositories.EntityFramework
{
	public class EFCategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext context;

		public EFCategoryRepository(AppDbContext context)
		{
			this.context = context;
		}
		public void DeleteCategory(Guid id)
		{
			context.Categories.Remove(new Category() { Id = id });
            context.SaveChanges();
		}

		public Category GetCategory(Guid id)
		{
			return context.Categories.FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<Category> GetCategories()
		{
			return context.Categories;
		}

		public void SaveCategory(Category entity)
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
