using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.User
{
    public class AccountRegisterViewModel
    {
        [Required(ErrorMessage = "Enter email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string accountEmail { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage = "Length must be greater than 8 characters")]
        [MaxLength(20, ErrorMessage = "Length must be less than 20 characters")]
		[DataType(DataType.Password)]
		public string accountPassword { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [Compare("accountPassword", ErrorMessage = "Password mismatch")]
		[DataType(DataType.Password)]
		public string accountPasswordConfirm { get; set; }
    }
}