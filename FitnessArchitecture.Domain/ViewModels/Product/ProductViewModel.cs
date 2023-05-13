using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.Product
{
	public class ProductViewModel
	{
		public int productID { get; set; }

        [Display(Name = "Name")]
        public string productName { get; set; }

        [Display(Name = "Number of calories")]
        public uint productCalories { get; set; }

        [Display(Name = "Product weight")]
        public ushort productWeight { get; set; }

        [Display(Name = "Number of proteins")]
        public ushort productProteins { get; set; }

        [Display(Name = "Number of fats")]
        public ushort productFats { get; set; }

        [Display(Name = "Number of carbs")]
        public ushort productCarbs { get; set; }

        public string productImg { get; set; }
    }
}