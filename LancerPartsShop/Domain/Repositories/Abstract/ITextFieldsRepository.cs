﻿using LancerPartsShop.Domain.Entities;

namespace LancerPartsShop.Domain.Repositories.Abstract
{
	public interface ITextFieldsRepository
	{
		IQueryable<TextField> GetTextFields();
		TextField GetTextFieldById(Guid id);
		TextField GetTextFieldByCodeWord(string codeword);
		void SaveTextField(TextField entity);
		void DeleteTextField(Guid id);
	}
}
