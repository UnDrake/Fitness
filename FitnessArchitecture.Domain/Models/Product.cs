namespace FitnessArchitecture.Domain.Models
{
	public class Product
	{
		public int productID { get; set; }
		public string productName { get; set; }
		public uint productCalories { get; set; }
		public ushort productWeight { get; set; }
		public ushort productProteins { get; set; }
		public ushort productFats { get; set; }
		public ushort productCarbs { get; set; }
        public string productImg { get; set; }
    }
}