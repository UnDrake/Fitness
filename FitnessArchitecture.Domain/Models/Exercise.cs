namespace FitnessArchitecture.Domain.Models
{
	public class Exercise
	{
		public int exerciseID { get; set; }
		public string exerciseName { get; set; }
		//public string exerciseShortDescription { get; set; }
		public string exerciseLongDescription { get; set; }
        public uint exerciseCalories { get; set; }
        public string exerciseImg { get; set; }
	}
}