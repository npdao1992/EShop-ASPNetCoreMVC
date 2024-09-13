namespace EShop.Models.ViewModels
{
	public class CategoryViewModel
	{
		public CategoryModel Category { get; set; }
		public List<ProductModel> Products { get; set; }
		public int ProductCount { get; set; } // Số lượng sản phẩm
	}

}
