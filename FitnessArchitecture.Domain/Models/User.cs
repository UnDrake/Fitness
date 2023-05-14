using FitnessArchitecture.Domain.Enum;

namespace FitnessArchitecture.Domain.Models
{
	public class User
	{
		public int userID { get; set; }
		public string userName { get; set; }
		public uint userAge { get; set; }
		public double userWeight { get; set; }
		public double userHeight { get; set; }
		public Gender userGender { get; set; }
		public ActivityLevel userActivity { get; set; }
		public double userNorm { get; set; }
		public int accountID { get; set; }
		public Account account { get; set; }


		public void NormCalculation()
		{
			if (userGender == 0)
				userNorm = 66 + (13.7 * userWeight) + (5 * userHeight) - (6.8 * userAge);
			else
				userNorm = 655 + (9.6 * userWeight) + (1.8 * userHeight) - (4.7 * userAge);

			switch (userActivity)
			{
				case ActivityLevel.Minimal:
					userNorm *= 1.2;
					break;
				case ActivityLevel.Low:
					userNorm *= 1.3;
					break;
				case ActivityLevel.Average:
					userNorm *= 1.5;
					break;
				case ActivityLevel.High:
					userNorm *= 1.7;
					break;
				case ActivityLevel.Maximum:
					userNorm *= 1.9;
					break;
			}
		}
	}
}