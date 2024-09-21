
/* Cập nhật ajax Thêm vào giỏ hàng */
{
    $(document).ready(function () {
        $('.add-to-cart').click(function () {
            var Id = $(this).data("product_id");

            // alert(product_id);
            $.ajax({
                type: "POST",
                url: addToCartUrl, // Sử dụng biến từ Razor, vì Url.Action không sử dụng được trong js
                data: { Id: Id }, // Send data to server
                success: function (result) {
                    // Handle successful update
                    if (result) {
                        Swal.fire("Thêm giỏ hàng thành công.");
                    }
                    else {
                        // Handle error
                        Swal.fire("Thêm giỏ hàng thất bại: " + result.message);
                    }
                }
                // ,
                // error: function (reg, status, error) {
                // 	console.error("Error updating order: ", error);
                // }
            });
        });
    });
}
/* Cập nhật ajax Thêm vào giỏ hàng */


/*  Start Add to Wishlist Script */
{
    $(document).ready(function () {
        $('.btn-wishlist').click(function () {
            var Id = $(this).data("product_id");

            // // Lấy CSRF token nếu cần
            // var token = $('input[name="__RequestVerificationToken"]').val();

            $.ajax({
                type: "POST",
                url: addToWishlistUrl,
                data: {
                    Id: Id, // Gửi Id sản phẩm
                    // __RequestVerificationToken: token // Thêm CSRF token nếu cần
                },
                success: function (result) {
                    // Xử lý phản hồi thành công
                    if (result.success) {
                        Swal.fire("Thêm yêu thích sản phẩm thành công.");
                    } else {
                        // Hiển thị thông báo nếu sản phẩm đã có trong danh sách yêu thích
                        Swal.fire(result.message);
                        // Điều hướng về trang chủ nếu cần
                        if (result.message.includes("already exists")) {
                            Swal.fire("Sản phẩm đã tồn tại trong Wishlist.");
                            // window.location.href = '@Url.Action("Index", "Home")';
                        }
                    }
                },
                error: function (xhr, status, error) {
                    // Xử lý lỗi nếu có
                    Swal.fire("Có lỗi xảy ra: " + error);
                }
            });
        });
    });
}
/*  End Add to Wishlist Script */


/* Start Add to Compare Script */
{
    $(document).ready(function () {
        $('.btn-compare').click(function () {
            var Id = $(this).data("product_id");

            // alert(product_id);
            $.ajax({
                type: "POST",
                url: addToComparetUrl,
                data: { Id: Id }, // Send data to server
                success: function (result) {
                    // Xử lý phản hồi thành công
                    if (result.success) {
                        Swal.fire("Thêm so sánh sản phẩm thành công.");
                    } else {
                        // Hiển thị thông báo nếu sản phẩm đã có trong danh sách so sánh
                        Swal.fire(result.message);
                        // Điều hướng về trang chủ nếu cần
                        if (result.message.includes("already exists")) {
                            Swal.fire("Sản phẩm đã tồn tại trong Compare.");
                            // window.location.href = '@Url.Action("Index", "Home")';
                        }
                    }
                },
                error: function (xhr, status, error) {
                    // Xử lý lỗi nếu có
                    Swal.fire("Có lỗi xảy ra: " + error);
                }
            });
        });
    });
}
/* End Add to Compare Script */

// Tham khảo
{
    /*
    @*
	<!-- Start Add to Wishlist Script-->
	<script>
		$(document).ready(function () {
			$('.btn-wishlist').click(function () {
				var Id = $(this).data("product_id");

				// alert(product_id);
				$.ajax({
					type: "POST",
					url: "@Url.Action("AddWishlist", "Home")",
					data: { Id: Id }, // Send data to server
					success: function (result) {
						// Handle successful update
						if (result) {
							Swal.fire("Thêm yêu thích sản phẩm thành công.");
						}
						else {
							// Handle error
							Swal.fire("Thêm yêu thích sản phẩm thất bại: " + result.message);
						}
					}
					// ,
					// error: function (reg, status, error) {
					// 	console.error("Error updating order: ", error);
					// }
				});
			});
		});
	</script>
	<!-- End Add to Wishlist Script--> *@


@* <!-- Start Add to Compare Script-->
	<script>
		$(document).ready(function () {
			$('.btn-compare').click(function () {
				var Id = $(this).data("product_id");

				// alert(product_id);
				$.ajax({
					type: "POST",
					url: "@Url.Action("AddCompare", "Home")",
					data: { Id: Id }, // Send data to server
					success: function (result) {
						// Handle successful update
						if (result) {
							Swal.fire("Thêm so sánh sản phẩm thành công.");
						}
						else {
							// Handle error
							Swal.fire("Thêm so sánh sản phẩm thất bại: " + result.message);
						}
					}
					// ,
					// error: function (reg, status, error) {
					// 	console.error("Error updating order: ", error);
					// }
				});
			});
		});
	</script>
	<!-- End Add to Compare Script--> *@
    */
}