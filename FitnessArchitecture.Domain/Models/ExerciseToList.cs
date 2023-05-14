namespace FitnessArchitecture.Domain.Models
{
	public class ExerciseToList
	{
		public int addExerciseID { get; set; }
		public int exerciseID { get; set; }
		public int exerciseListID { get; set; }
		public string addedAccountEmail { get; set; }
		public virtual ExerciseList exerciseList { get; set; }
	}
}