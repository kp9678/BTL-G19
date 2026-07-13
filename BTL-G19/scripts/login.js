function checkLogin() {

    var txtUser = document.getElementById("txtUser");
    var txtPassword = document.getElementById("txtPassword");

    if (txtUser == null || txtPassword == null) {
        alert("Không tìm thấy các ô nhập liệu.");
        return false;
    }

    var user = txtUser.value.trim();
    var pass = txtPassword.value.trim();

    if (user === "") {
        alert("Vui lòng nhập tên đăng nhập hoặc Email.");
        txtUser.focus();
        return false;
    }

    if (user.includes("@")) {

        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailRegex.test(user)) {
            alert("Email không đúng định dạng.");
            txtUser.focus();
            return false;
        }
    }

    if (pass === "") {
        alert("Vui lòng nhập mật khẩu.");
        txtPassword.focus();
        return false;
    }

    return true;
}