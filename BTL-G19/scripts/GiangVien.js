function KiemTraDuLieu() {

    var tenGV = document.getElementById("MainContent_txtTenGV").value.trim();
    var email = document.getElementById("MainContent_txtEmail").value.trim();
    var sdt = document.getElementById("MainContent_txtSDT").value.trim();
    var chuyenMon = document.getElementById("MainContent_txtChuyenMon").value.trim();

    if (tenGV == "") {
        alert("Vui lòng nhập tên giảng viên!");
        return false;
    }

    if (email == "") {
        alert("Vui lòng nhập email!");
        return false;
    }

    var regexEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!regexEmail.test(email)) {
        alert("Email không đúng định dạng!");
        return false;
    }

    if (sdt == "") {
        alert("Vui lòng nhập số điện thoại!");
        return false;
    }

    var regexSDT = /^0\d{9}$/;

    if (!regexSDT.test(sdt)) {
        alert("Số điện thoại phải gồm 10 số và bắt đầu bằng 0!");
        return false;
    }

    if (chuyenMon == "") {
        alert("Vui lòng nhập chuyên môn!");
        return false;
    }

    return true;
}