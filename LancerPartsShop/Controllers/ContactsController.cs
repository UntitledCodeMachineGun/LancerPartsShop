using LancerPartsShop.Domain;
using LancerPartsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
	public class ContactsController : Controller
	{
        private readonly DataManager dataManager;

		public ContactsController(DataManager dataManager) 
		{
			this.dataManager = dataManager;
		}

        public IActionResult Contacts()
		{ 
            return View(dataManager.TextFields.GetTextFieldByCodeWord("ContactsPage"));
		}
	}
}
