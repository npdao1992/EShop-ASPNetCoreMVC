using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
	public class ProductQuantityModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Yêu cầu không bỏ trống số lượng sản phẩm")]
		public int Quantity { get; set; }
		public long ProductId { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
