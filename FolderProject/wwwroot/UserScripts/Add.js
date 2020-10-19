
    $(document).ready(function () {
        
        $("#btnSave").click(function () {
            $.ajax(
                {
                    type: "POST",
                    url: "Home/AddUser",
                    data: {
                        FullName: $("#Name").val(),
                        UserEmail: $("#Email").val(),
                        
                    },
                        success: function (data) {
                        location.reload();

                    }

                });
           
        });
        
    });
  



