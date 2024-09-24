using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Order")]
	[Authorize(Roles = "Admin,Staff")]
	public class OrderController : Controller
	{
		private readonly DataContext _dataContext;
		public OrderController(DataContext context)
		{
			_dataContext = context;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Orders.OrderByDescending(p => p.Id).ToListAsync());
		}

		//[Route("Index")]
		//public async Task<IActionResult> Index(int pg = 1)
		//{
		//	List<OrderModel> order = _dataContext.Orders.OrderByDescending(p => p.CreatedDate).ToList();

		//	const int pageSize = 10;

		//	if (pg < 1)
		//	{
		//		pg = 1;
		//	}
		//	int recsCount = order.Count();

		//	var pager = new Paginate(recsCount, pg, pageSize);

		//	int recSkip = (pg - 1) * pageSize;

		//	var data = order.Skip(recSkip).Take(pager.PageSize).ToList();

		//	// Truyền dữ liệu vào view dưới dạng Tuple ( Xử lý việc truyền tổng số được truy vấn)
		//	var model = new Tuple<IEnumerable<OrderModel>, int>(data, recsCount);

		//	ViewBag.Pager = pager;

		//	return View(model);
		//}

		[Route("ViewOrder")]
		public async Task<IActionResult> ViewOrder(string ordercode)
		{
			// Lấy thông tin chi tiết đơn hàng và thông tin người dùng dựa trên mã đơn hàng
			var order = await _dataContext.Orders
				.FirstOrDefaultAsync(o => o.OrderCode == ordercode);

			var detailsOrder = await _dataContext.OrderDetails
				.Include(od => od.Product)
				.Where(od => od.OrderCode == ordercode)
				.ToListAsync();

			if (order != null)
			{
				ViewBag.UserName = order.UserName;
				ViewBag.OrderCode = order.OrderCode;

                // Giả sử bạn có một cách để kiểm tra Role của người dùng
                ViewBag.IsAdmin = User.IsInRole("Admin"); // Kiểm tra xem người dùng có Role "Admin" hay không

                ViewBag.Status = order.Status; // Lấy giá trị Status
			}

			return View(detailsOrder);
		}



		//[Route("ViewOrder")]
		//public async Task<IActionResult> ViewOrder(string ordercode)
		//{
		//	var DetailsOrder = await _dataContext.OrderDetails.Include(o => o.Product).Where(o => o.OrderCode == ordercode).ToListAsync();
		//	return View(DetailsOrder);
		//}

		/*
		 Phân trang sử dụng ToList() tải toàn bộ dữ liệu lần đầu
		 */

		//[Route("ViewOrder")]
		//public async Task<IActionResult> ViewOrder(int pg = 1, string ordercode="")
		//{
		//	// Tìm các chi tiết đơn hàng theo mã đơn hàng và sắp xếp theo tên sản phẩm
		//	List<OrderDetails> orderDetails = _dataContext.OrderDetails
		//		.Include(o => o.Product)               // Bao gồm thông tin sản phẩm liên quan
		//		.Where(o => o.OrderCode == ordercode)  // Lọc theo mã đơn hàng
		//		.OrderBy(o => o.Product.Name)          // Sắp xếp theo tên sản phẩm
		//		.ToList();                             // Chuyển đổi thành danh sách


		//	const int pageSize = 10;

		//	if (pg < 1)
		//	{
		//		pg = 1;
		//	}
		//	int recsCount = orderDetails.Count();

		//	var pager = new Paginate(recsCount, pg, pageSize);

		//	int recSkip = (pg - 1) * pageSize;

		//	var data = orderDetails.Skip(recSkip).Take(pager.PageSize).ToList();

		//	ViewBag.Pager = pager;

		//	return View(data);
		//}

		/*
		 Cải Tiến Hiệu Suất: Tránh việc sử dụng ToList() trước khi phân trang vì nó có thể dẫn đến 
		việc tải toàn bộ dữ liệu vào bộ nhớ trước khi phân trang.
		Thay vào đó, thực hiện phân trang trực tiếp trong truy vấn.
		 */
		//[Route("ViewOrder")]
		//public async Task<IActionResult> ViewOrder(int pg = 1, string ordercode = "")
		//{
		//	if (string.IsNullOrWhiteSpace(ordercode))
		//	{
		//		// Nếu ordercode không hợp lệ, trả về lỗi hoặc một trang thông báo
		//		TempData["error"] = "Mã đơn hàng không hợp lệ.";
		//		return RedirectToAction("Index"); // Hoặc trang khác phù hợp
		//	}

		//	// Tính toán phân trang
		//	const int pageSize = 10;
		//	var query = _dataContext.OrderDetails
		//		.Include(o => o.Product)
		//		.Where(o => o.OrderCode == ordercode)
		//		.OrderBy(o => o.Product.Name);

		//	int recsCount = await query.CountAsync(); // Số lượng bản ghi tổng cộng

		//	var pager = new Paginate(recsCount, pg, pageSize);

		//	int recSkip = (pg - 1) * pageSize;

		//	var data = await query.Skip(recSkip).Take(pager.PageSize).ToListAsync();

		//	// Truyền dữ liệu vào view dưới dạng Tuple ( Xử lý việc truyền tổng số được truy vấn)
		//	var model = new Tuple<IEnumerable<OrderDetails>, int>(data, recsCount);

		//	ViewBag.Pager = pager;

		//	return View(model);
		//}

		[HttpPost]
		[Route("UpdateOrder")]
		public async Task<IActionResult> UpdateOrder(string ordercode, int status)
		{
            // Lấy thông tin đơn hàng từ database
            var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.OrderCode == ordercode);

            // Kiểm tra nếu đơn hàng không tồn tại
            if (order == null)
			{
				//return NotFound();
                return Json(new { success = false, message = "Đơn hàng không tồn tại." });
            }

            // Kiểm tra Role của người dùng
            var isAdmin = User.IsInRole("Admin");

            // Nếu người dùng không phải là Admin, chỉ cho phép cập nhật từ "Đơn hàng mới" (1) sang "Đã xử lý" (0)
            if (!isAdmin && status == 1 && order.Status == 0)
            {
                return Json(new { success = false, message = "Bạn không có quyền thay đổi trạng thái này." });
            }

            // Cập nhật trạng thái đơn hàng
            order.Status = status;

			try
			{
                // Lưu thay đổi vào cơ sở dữ liệu
                await _dataContext.SaveChangesAsync();
				return Ok(new { success = true, message = "Order status updated successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while updating the order status.");
			}
		}



	}
}
