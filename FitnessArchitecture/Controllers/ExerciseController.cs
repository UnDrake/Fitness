using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessArchitecture.Controllers
{
    public class ExerciseController : Controller 
    {
        private readonly IExerciseService exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> GetExercise(int ID)
        {
            var exercise = await exerciseService.GetExercise(ID);
            if (exercise.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(exercise.Data);
            }
            ViewBag.Description = exercise.Description;
            ViewBag.StatusCode = ((int)exercise.StatusCode);
            return View("Error");
        }


        public IActionResult GetExercises()
        {
            var exercises = exerciseService.GetExercises();
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