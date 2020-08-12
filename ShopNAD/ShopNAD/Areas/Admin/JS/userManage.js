var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/UserManage/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (respone) {
                    console.log(respone);
                    if (respone.status == true) {
                        btn.text('Hoạt động');
                    }
                    else {
                        btn.text('Khóa');
                    }
                }
            });
        });
    }
}
user.init();