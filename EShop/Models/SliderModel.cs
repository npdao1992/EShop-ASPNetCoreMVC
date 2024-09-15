using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using EShop.Repository.Validation;

namespace EShop.Models
{
	public class SliderModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Yêu cầu không được bỏ trống tên slider")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Yêu cầu không được bỏ trống mô tả")]
		public string Description { get; set; }
		public int? Status { get; set; }

		public string Image { get; set; }

		[NotMapped]
		[FileExtension]
		public IFormFile? ImageUpload { get; set; }
	}
}
