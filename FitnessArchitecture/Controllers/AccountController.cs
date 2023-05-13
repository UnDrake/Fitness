using FitnessArchitecture.Domain.ViewModels.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FitnessArchitecture.Service.Interfaces;

namespace FitnessArchitecture.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService accountService;

		public AccountController(IAccountService accountService)
		{
			this.accountService = accountService;
		}

		[HttpGet]
		public IActionResult Register() => View();


		[HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel registerAccount)
		{
			if (ModelState.IsValid)
			{
				var account = await accountService.Register(registerAccount);

				if (account.StatusCode == System.Net.HttpStatusCode.OK)
				{
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(account.Data));

					return RedirectToAction("RegisterUser", "User");
				}
                ViewBag.Description = account.Description;
                ViewBag.StatusCode = ((int)account.StatusCode);
                return View("Error");
            }
			return View(registerAccount);
		}


		[HttpGet]
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(AccountLoginViewModel loginAccount)
		{
			if (ModelState.IsValid)
			{
				var account = await accountService.Login(loginAccount);

				if (account.StatusCode == System.Net.HttpStatusCode.OK)
				{
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(account.Data));

					return RedirectToAction("Index", "Home");
				}
				ViewBag.Description = account.Description;
				ViewBag.StatusCode = ((int)account.StatusCode);
                return View("Error");
            }
            return View(loginAccount);
		}


        public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return View("Login");
		}


        public async Task<IActionResult> DeleteAccount(int ID)
		{
			var account = await accountService.DeleteAccount(ID);
			if (account.StatusCode == System.Net.HttpStatusCode.OK)
			{
                return RedirectToAction("Login");
            }
            ViewBag.Description = account.Description;
            ViewBag.StatusCode = ((int)account.StatusCode);
            return View("Error");
        }
    }
}