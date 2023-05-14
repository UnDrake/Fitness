namespace FitnessArchitecture.Domain.Models
{
	public class ExerciseList
	{
		public int exerciseListID { get; set; }
		public int accountID { get; set; }
		public Account account { get; set; }
		public List<ExerciseToList> addedExercises { get; set; }
	}
}