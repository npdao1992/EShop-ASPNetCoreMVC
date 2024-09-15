$(function () {

    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }

});

function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        // Ẩn hình ảnh hiện tại
        $("#currentImage").hide();


        reader.onload = function (e) {
            $("img#imgpreview")
                .attr("src", e.target.result)
                .width(200)
                .height(200)
                .show();  // Hiển thị hình ảnh mới
        };

        reader.readAsDataURL(input.files[0]);
    }
}


function readURLs(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        // Ẩn hình ảnh hiện tại
        $("#currentImage").hide();

        reader.onload = function (e) {
            // Hiển thị hình ảnh mới và gán src cho hình ảnh xem trước
            $("img#imgpreview")
                .attr("src", e.target.result)
                .width(400)
                .height(200)
                .show();  // Hiển thị hình ảnh mới
        };

        reader.readAsDataURL(input.files[0]);
    }
}