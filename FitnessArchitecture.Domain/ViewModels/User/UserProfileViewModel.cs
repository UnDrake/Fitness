using FitnessArchitecture.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.User
{
    public class UserProfileViewModel
	{
        public int userID { get; set; }

        [Display(Name = "Name")]
        public string userName { get; set; }

        [Display(Name = "Age")]
        public uint userAge { get; set; }

        [Display(Name = "Weight")]
        public double userWeight { get; set; }

        [Display(Name = "Height")]
        public double userHeight { get; set; }

        [Display(Name = "Gender")]
        public Gender userGender { get; set; }

        [Display(Name = "Activity Level")]
        public ActivityLevel userActivity { get; set; }

        [Display(Name = "Calorie norm")]
        public double userNorm { get; set; }

        [Display(Name = "Email")]
        public string userEmail { get; set; }
	}
}