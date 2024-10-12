﻿using EShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Repository
{
	public class DataContext :IdentityDbContext<AppUserModel>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{ 

		}

		public DbSet<BrandModel> Brands { get; set; }
		public DbSet<SliderModel> Sliders { get; set; }
		public DbSet<ProductModel> Products { get; set; }

        public DbSet<ProductImageModel> ProductImages { get; set; } // Thêm DbSet cho ProductImage

        public DbSet<RatingModel> Ratings { get; set; }
		public DbSet<CategoryModel> Categories { get; set; }
		public DbSet<OrderModel> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<ContactModel> Contact { get; set; }
		public DbSet<WishlistModel> Wishlists { get; set; }
		public DbSet<CompareModel> Compares { get; set; }
		public DbSet<ProductQuantityModel> ProductQuantities { get; set; }
		public DbSet<ShippingModel> Shippings { get; set; } // Thêm DbSet cho Shipping



	}
}
