using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitnessArchitecture.Controllers
{
    public class ExerciseToListController : Controller
    {
        private readonly IExerciseToListService addedExerciseService;

        public ExerciseToListController(IExerciseToListService addedExerciseService)
        {
            this.addedExerciseService = addedExerciseService;
        }


        public async Task<IActionResult> Add(ExerciseToList addedExercise)
        {
            if (ModelState.IsValid)
            {
                await addedExerciseService.Create(addedExercise);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateAdd(int ID)
        {
            var addExercise = new ExerciseToList()
            {
                addedAccountEmail = User.Identity.Name,
                exerciseID = ID,
            };
            var exercise = await addedExerciseService.Create(addExercise);
            if (exercise.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("GetExercises", "Exercise");
            }
            ViewBag.Description = exercise.Description;
            ViewBag.StatusCode = ((int)exercise.StatusCode);
            return View("Error");
        }


        public async Task<IActionResult> DeleteAdd(int ID)
        {
            var exercise = await addedExerciseService.Delete(ID);
            if (exercise.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("GetExercises", "ExerciseList");
            }
            ViewBag.Description = exercise.Description;
            ViewBag.StatusCode = ((int)exercise.StatusCode);
            return View("Error");
        }
    }
}