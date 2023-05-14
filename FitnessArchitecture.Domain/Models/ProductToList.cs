namespace FitnessArchitecture.Domain.Models
{
	public class ProductToList
	{
		public int addProductID { get; set; }
		public int productID { get; set; }
		public int productListID { get; set; }
		public string addedAccountEmail { get; set; }
		public virtual ProductList productList { get; set; }
	}
}