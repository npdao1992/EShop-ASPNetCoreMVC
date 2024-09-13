$(document).ready(function () {
    $('#toggleBrandsBtn').click(function () {
        var $moreBrands = $('#moreBrands');
        var $btn = $(this);

        // Hiển thị/ẩn các thương hiệu còn lại
        $moreBrands.slideToggle(function () {
            // Thay đổi nút giữa "Xem thêm" và "Thu gọn" sau khi hiệu ứng hoàn tất
            if ($moreBrands.is(':visible')) {
                $btn.html('Thu gọn');
            } else {
                $btn.html('Xem thêm');
            }
        });
    });
});
