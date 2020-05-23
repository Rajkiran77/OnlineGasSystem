
$(document).ready(function () {

    $("#loginbtn").click(function () {
        if (validateLogin() == true) {
            var userName = $("#userNametxt").val();
            var password = $("#passwordtxt").val();
            var url = 'https://localhost:44326/UserAccess/Login' + "?userName=" + userName + "&password=" + password;

            $.ajax({
                type: "POST",
                dataType: "json",
                cache: false,
                url: url,
                success: function (result) {
                    if (result.status == true) {
                        for (i = 1; i < result.value.length; i++) {
                            alert(result.value[i]);
                        }
                        window.location = result.redirectUrl;
                    }
                    else {
                        var stringMessage = result.errorMessage;
                        alert(stringMessage);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Error loginbtn");
                }
            });
        }
    });
    $("#registerbtn").click(function () {
        if (validateRegister()==true) {
            var url = window.location.origin + '/UserAccess/Register';
            var userData = {
                "username": $("#userNameRegtxt").val(),
                "useremail": $("#email").val(),
                "useraddress": $("#addressregtxt").val(),
                "userphone": $("#phoneregtxt").val(),
                "userpassword": $("#passwordRegtxt").val()
            };
            $.ajax({
                type: "POST",
                dataType: "json",
                cache: false,
                url: url,
                data: { "userProfile": userData },
                success: function (result) {
                    if (result.status == true) {
                        $(".back-to-login-link").trigger("click");
                        clearData();
                        //  window.location = result.url;
                    }

                    var stringMessage = result.Message;
                    alert(stringMessage);

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Error loginbtn");
                }
            });
        }
    });
});

function clearData() {
    $("#userNameRegtxt").val("");
    $("#email").val("");
    $("#addressregtxt").val("");
    $("#phoneregtxt").val("");
    $("#passwordRegtxt").val("");
}

function validateRegister() {
    var flag = true;
    if ($.trim($("#userNameRegtxt").val()) == "") {
        alert("Username is mandatory");
        return false;
    }
    else if ($.trim($("#email").val()) == "") {
        alert("Email is mandatory");
        return false;
    }
    else if ($.trim($("#addressregtxt").val()) == "") {
        alert("Address is mandatory");
        return false;
    }
    else if ($.trim($("#phoneregtxt").val()) == "") {
        alert("PhoneNumber is mandatory");
        return false;
    }
    else if ($.trim($("#passwordRegtxt").val()) == "") {
        alert("Password is mandatory");
        return false;
    }
    else if ($.trim($("#passwordRegtxt").val()) != $.trim($("#repeatpasswordRegtxt").val())) {
        alert("Password is not matched");
        return false;
    }

    return flag;
}

function validateLogin() {
    var flag = true;
    if ($.trim($("#userNametxt").val()) == "") {
        alert("Please Enter Username");
        return false;
    }
    else if ($.trim($("#passwordtxt").val()) == "") {
        alert("Please Enter Password");
        return false;
    }
 
    return flag;
}