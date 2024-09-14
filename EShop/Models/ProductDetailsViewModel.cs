﻿using System.ComponentModel.DataAnnotations;

namespace EShop.Models
{
	public class ProductDetailsViewModel
	{
		public ProductModel ProductDetails { get; set; }


		[Required(ErrorMessage = "Yêu cầu nhập bình luận sản phẩm")]
		public string Comment { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập tên")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập email")]
		public string Email { get; set; }
	}
}
