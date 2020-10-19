function EditUserDetails(userId) {
    debugger;
    $.ajax({
        url: '/Home/Edit?Id=' + userId,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        async: true,
        success: function (data) {
            debugger;
            console.log(data);
            $("#gid1").val(data.userId);
            $("#name1").val(data.fullName);
            $("#email1").val(data.userEmail);

            
        }

    });
}

    $(document).ready(function () {

        $("#btnEdit").click(function () {
            $.ajax(
                {
                    type: "POST",
                    url: "Home/Edit",
                    data: {
                        UserId: $("#gid1").val(),
                        FullName: $("#name1").val(),
                        UserEmail: $("#email1").val(),
                        
                    },
                    success: function (data) {
                        location.reload();

                    }

                });
        });
    });

