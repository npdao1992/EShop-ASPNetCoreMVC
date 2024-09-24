using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EShop.Repository.Validation;

namespace EShop.Models
{
	public class ProductModel
	{
		[Key]
		public long Id { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
		public string Name { get; set; }
		public string Slug { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập mô tả sản phẩm")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập giá sản phẩm")]
		//[Range(0.01, double.MaxValue)]
		//[Column(TypeName ="decima(8, 2)")]
		public decimal Price { get; set; }

		//[Required, Range(1, int.MaxValue, ErrorMessage ="Chọn một thương hiệu")]
		public int BrandId { get; set; }

		//[Required, Range(1, int.MaxValue, ErrorMessage = "Chọn một danh mục")]
		public int CategoryId { get; set; }
		public string Image { get; set; }
		public CategoryModel Category { get; set; }
		public BrandModel Brand { get; set; }
		public RatingModel Ratings { get; set; }


        // Danh sách hình ảnh
        public virtual ICollection<ProductImageModel> Images { get; set; } = new List<ProductImageModel>();

        [NotMapped]
		[FileExtension]
		public IFormFile? ImageUpload { get; set; }
	}
}
