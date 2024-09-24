using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EShop.Repository.Validation;

namespace EShop.Models
{
    public class ProductImageModel
    {
        [Key]
        public long Id { get; set; }

        public long ProductId { get; set; }

		//[Required(ErrorMessage = "Yêu cầu chọn hình ảnh")]
		public string ImageUrl { get; set; }

        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }

        // Thuộc tính để tải lên hình ảnh
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

		//public ProductImage()
		//{
		//	ImageUrl = string.Empty; // Khởi tạo giá trị mặc định
		//}
	}
}
