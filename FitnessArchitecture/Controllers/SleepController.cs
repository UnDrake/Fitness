using FitnessArchitecture.Domain.ViewModels.Sleep;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessArchitecture.Controllers
{
    public class SleepController : Controller
    {
        private readonly ISleepService sleepService;
        public SleepController(ISleepService sleepService)
        {
            this.sleepService = sleepService;
        }

        public IActionResult Index() => RedirectToAction("GetSleep");

        public async Task<IActionResult> GetSleep()
        {
            var sleep = await sleepService.GetSleep(User.Identity.Name);
            if (sleep.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(sleep.Data);
            }
			ViewBag.Description = sleep.Description;
			ViewBag.StatusCode = ((int)sleep.StatusCode);
			return View("~/Views/Home/Error.cshtml");
		}

        public async Task<IActionResult> UpdateSleep(SleepViewModel updateSleep)
        {
            if (ModelState.IsValid)
            {
                var s = new SleepViewModel()
                {
                    sleepAccountEmail = User.Identity.Name,
                    sleepTime = updateSleep.sleepTime,
                };
                var sleep = await sleepService.Update(s);
                if (sleep.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
				ViewBag.Description = sleep.Description;
				ViewBag.StatusCode = ((int)sleep.StatusCode);
				return View("~/Views/Home/Error.cshtml");
			}
			return View("GetSleep", updateSleep);
		}
	}
}