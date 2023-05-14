using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessArchitecture.Controllers
{
    public class ExerciseListController : Controller
    {
        private readonly IExerciseListService exerciseListService;
        public ExerciseListController(IExerciseListService exerciseListService)
        {
            this.exerciseListService = exerciseListService;
        }

        public async Task<IActionResult> GetExercises()
        {
            var exercises = await exerciseListService.GetExercises(User.Identity.Name);
            if (exercises.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(exercises.Data);
            }
            ViewBag.Description = exercises.Description;
            ViewBag.StatusCode = ((int)exercises.StatusCode);
            return View("Error");
        }
    }
}