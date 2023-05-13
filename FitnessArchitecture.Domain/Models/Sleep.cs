namespace FitnessArchitecture.Domain.Models
{
	public class Sleep
	{
		public int sleepID { get; set; }
		public ushort sleepTime { get; set; }
		public int accountID { get; set; }
		public string sleepAccountEmail { get; set; }
		public Account account { get; set; }
	}
}
