using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LancerPartsShop.Domain.Repositories.EntityFramework
{
    public class EFProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public EFProductRepository(AppDbContext context) 
        {
			this.context = context;
        }

        public void DeleteProduct(Guid id)
        {
            context.Products.Remove(new Product() { Id = id });
            context.SaveChanges();
        }

        public Product GetProduct(Guid id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> GetProducts()
        {
            return context.Products;
        }

        public IQueryable<Product> GetProductsByCategory(Guid categoryId)
        {
            return context.Products.Where(x => x.CategoryId == categoryId);
        }

        public void SaveProduct(Product entity)
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
