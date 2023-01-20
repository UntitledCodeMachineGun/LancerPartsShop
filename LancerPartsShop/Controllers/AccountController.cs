using LancerPartsShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LancerPartsShop.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;

		public AccountController(UserManager<IdentityUser> user, SignInManager<IdentityUser> sign)
		{ 
			userManager = user;
			signInManager = sign;
		}

		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View(new LoginViewModel());
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			IdentityUser user = await userManager.FindByNameAsync(model.Username);
			if (user != null)
			{
				await signInManager.SignOutAsync();
				Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{
					return Redirect(returnUrl ?? "/");
				}
			}
			ModelState.AddModelError(nameof(LoginViewModel.Username), "Wrong login or password");
			return View(model);
		}

		[Authorize]
		public async Task<ActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
