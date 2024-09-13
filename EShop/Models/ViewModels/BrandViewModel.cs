namespace EShop.Models.ViewModels
{
	public class BrandViewModel
    {
		public BrandModel Brand { get; set; }
		public List<ProductModel> Products { get; set; }
		public int ProductCount { get; set; } // Số lượng sản phẩm
	}

}
