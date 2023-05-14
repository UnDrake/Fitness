using FitnessArchitecture.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.User
{
    public class UserViewModel
	{
        public int userID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter name")]
        public string userName { get; set; }

        [Display(Name = "Age")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150")]
        [Required(ErrorMessage = "Enter age")]
        public uint userAge { get; set; }

        [Display(Name = "Weight")]
        [Range(1, 700, ErrorMessage = "Weight must be between 1 and 700")]
        [Required(ErrorMessage = "Enter weight")]
        public double userWeight { get; set; }

        [Display(Name = "Height")]
        [Range(1, 300, ErrorMessage = "Height must be between 1 and 300")]
        [Required(ErrorMessage = "Enter height")]
        public double userHeight { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Enter gender")]
        public Gender userGender { get; set; }

        [Display(Name = "Activity Level")]
        [Required(ErrorMessage = "Enter activity level")]
        public ActivityLevel userActivity { get; set; }

        [Display(Name = "Calorie norm")]
        public double userNorm { get; set; }
	}
}