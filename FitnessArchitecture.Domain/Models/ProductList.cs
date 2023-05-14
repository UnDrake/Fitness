namespace FitnessArchitecture.Domain.Models
{
	public class ProductList
	{
		public int productListID { get; set; }
		public int accountID { get; set; }
		public Account account { get; set; }
		public List<ProductToList> addedProducts { get; set; }
	}
}