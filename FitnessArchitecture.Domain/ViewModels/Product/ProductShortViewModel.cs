using System.ComponentModel.DataAnnotations;

namespace FitnessArchitecture.Domain.ViewModels.Product
{
    public class ProductShortViewModel
	{
        public int productID { get; set; }

        [Display(Name = "Name")]
        public string productName { get; set; }

        [Display(Name = "Number of calories")]
        public uint productCalories { get; set; }

        public string productImg { get; set; }
    }
}