﻿using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Models
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Login")]
		public string Username { get; set; }

		[Required]
		[UIHint("password")]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set;}
	}
}
