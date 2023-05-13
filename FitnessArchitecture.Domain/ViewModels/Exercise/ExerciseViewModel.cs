using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.Exercise
{
    public class ExerciseViewModel
	{
        public int exerciseID { get; set; }

        [Display(Name = "Name")]
        public string exerciseName { get; set; }

        [Display(Name = "Description")]
        public string exerciseLongDescription { get; set; }

        [Display(Name = "Calories burned")]
        public uint exerciseCalories { get; set; }

        public string exerciseImg { get; set; }
    }
}