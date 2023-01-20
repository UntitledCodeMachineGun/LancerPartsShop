using LancerPartsShop.Domain.Entities;
using LancerPartsShop.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LancerPartsShop.Domain.Repositories.EntityFramework
{
	public class EFTextFieldsRepository : ITextFieldsRepository
	{
		private readonly AppDbContext context;

		public EFTextFieldsRepository(AppDbContext context) 
		{
			this.context = context;
		}
		public void DeleteTextField(Guid id)
		{
			context.TextFields.Remove(new TextField() { Id = id });
			context.SaveChanges();
		}

		public TextField GetTextFieldById(Guid id)
		{
			return context.TextFields.FirstOrDefault(x => x.Id == id);
		}

		public TextField GetTextFieldByCodeWord(string codeword)
		{
			return context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);
		}

		public IQueryable<TextField> GetTextFields()
		{
			return context.TextFields;
		}

		public void SaveTextField(TextField entity)
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
