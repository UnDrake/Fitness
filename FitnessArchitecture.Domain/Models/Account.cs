using FitnessArchitecture.Domain.Enum;

namespace FitnessArchitecture.Domain.Models
{
	public class Account
	{
		public int accountID { get; set; }
		public string accountEmail { get; set; }
		public string accountPassword { get; set; }
		public User user { get; set; }
		public ExerciseList exerciseList { get; set; }
		public ProductList productList { get; set; }
		public Sleep sleep { get; set; }
	}
}
