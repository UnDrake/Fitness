using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.Exercise
{
    public class ExerciseShortViewModel
	{
		public int exerciseID { get; set; }

        [Display(Name = "Name")]
        public string exerciseName { get; set; }

        [Display(Name = "Calories burned")]
        public uint exerciseCalories { get; set; }

        public string exerciseImg { get; set; }
	}
}