function DeleteUser(userId) {
    debugger;
    var result = confirm('Are you sure you wish to delete this record?');
    if (result) {
        $.ajax({
            url: '/Home/Delete?id=' + userId,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            async: false,
            success: function (data) {
                //window.reload();

            }

        });

    }
    location.reload();
}