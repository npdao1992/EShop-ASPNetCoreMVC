$(document).ready(function () {
    $('#toggleCategoriesBtn').click(function () {
        var $moreCategories = $('#moreCategories');
        var $btn = $(this);

        // Hiển thị/ẩn các category còn lại
        $moreCategories.slideToggle(function () {
            // Thay đổi nút giữa "Xem thêm" và "Thu gọn" sau khi hiệu ứng hoàn tất
            if ($moreCategories.is(':visible')) {
                $btn.html('Thu gọn');
            } else {
                $btn.html('Xem thêm');
            }
        });
    });
});

