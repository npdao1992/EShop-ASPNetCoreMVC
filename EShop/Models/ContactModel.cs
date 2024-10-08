﻿using System.ComponentModel.DataAnnotations;
using EShop.Repository.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Models
{
	public class ContactModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập tên liên hệ")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập tiêu đề website")]
		public string ShopName { get; set; }


		[Required(ErrorMessage = "Yêu cầu nhập Bản đồ")]
		public string Map { get; set; }
		
		[Required(ErrorMessage = "Yêu cầu nhập Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập Phone")]
		public string Phone { get; set; }


		[Required(ErrorMessage = "Yêu cầu nhập mô tả thông tin liên hệ")]
		public string Description { get; set; }

		public string LogoImg { get; set; }

		public string LogominiImg { get; set; }


		[NotMapped]
		[FileExtension]
		public IFormFile? ImageUpload { get; set; }


		[NotMapped]
		[FileExtension]
		public IFormFile? ImageminiUpload { get; set; }



	}
}

