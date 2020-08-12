var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtName').val();
            var phone = $('#txtPhone').val();
            var email = $('#txtEmail').val();
            var content = $('#txtContent').val();

            $.ajax({
                url: 'Contact/SendFeedBack',
                type: 'POST',
                dataType: 'json',   
                data: {
                    name: name,
                    phone: phone,
                    email: email,
                    content: content
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi thành công');
                        res.resetForm();
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtPhone').val('');
        $('#txtContent').val('');
    }
}
contact.init();