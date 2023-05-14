using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.Sleep
{
	public class SleepViewModel
	{
		public string? sleepAccountEmail { get; set; }

		[Display(Name = "Sleep Time")]
		[Range(0, 24, ErrorMessage = "Sleep time must be between 0 and 24")]
		[Required(ErrorMessage = "Enter sleep time")]
		public ushort sleepTime { get; set; }
	}
}