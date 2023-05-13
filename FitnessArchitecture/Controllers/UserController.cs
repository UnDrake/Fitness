using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Domain.ViewModels.User;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FitnessArchitecture.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}


		[HttpGet]
		public IActionResult RegisterUser() =>	View();

		[HttpPost]
		public async Task<IActionResult> RegisterUser(UserViewModel userInfo)
		{
            if (ModelState.IsValid)
			{
                userInfo.userID = (await userService.GetUser(User.Identity.Name)).Data.userID;
                var user = await userService.UpdateUser(userInfo);

                if (user.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Home");
                }
				ViewBag.Description = user.Description;
				ViewBag.StatusCode = ((int)user.StatusCode);
				return View("~/Views/Home/Error.cshtml");
			}
			return View(userInfo);
        }


		[HttpGet]
		public IActionResult UpdateUser() => View();

		[HttpPost]
		public async Task<IActionResult> UpdateUser(UserViewModel userInfo)
		{
			if (ModelState.IsValid)
			{
				userInfo.userID = (await userService.GetUser(User.Identity.Name)).Data.userID;
				var user = await userService.UpdateUser(userInfo);

				if (user.StatusCode == System.Net.HttpStatusCode.OK)
				{
					return RedirectToAction("GetUser");
				}
				ViewBag.Description = user.Description;
				ViewBag.StatusCode = ((int)user.StatusCode);
				return View("~/Views/Home/Error.cshtml");
			}
			return View(userInfo);
		}

		public async Task<IActionResult> GetUser()
		{
			var user = await userService.GetUser(User.Identity.Name);

			if (user.StatusCode == System.Net.HttpStatusCode.OK)
			{
				return View(user.Data);
			}
			ViewBag.Description = user.Description;
			ViewBag.StatusCode = ((int)user.StatusCode);
			return View("~/Views/Home/Error.cshtml");
		}
    }
}
