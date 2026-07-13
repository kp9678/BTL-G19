function KiemTraDuLieu() {

    var ma = document.getElementById("txtMaHV").value.trim();
    var ten = document.getElementById("txtTenHV").value.trim();
    var ns = document.getElementById("txtNgaySinh").value.trim();
    var sdt = document.getElementById("txtSoDienThoai").value.trim();
    var dc = document.getElementById("txtDiaChi").value.trim();
    var email = document.getElementById("txtEmail").value.trim();
    var kh = document.getElementById("txtKhoaHoc").value.trim();
    var lop = document.getElementById("txtLopHoc").value.trim();

    if (ma == "") {
        alert("Nhập mã học viên");
        return false;
    }

    var regexMa = /^HV\d{2}$/;

    if (!regexMa.test(ma)) {
        alert("Mã phải có dạng HV01");
        return false;
    }

    if (ten == "") {
        alert("Nhập tên học viên");
        return false;
    }

    var ngaySinh = document.getElementById("txtNgaySinh").value.trim();

    if (ngaySinh == "") {
        alert("Vui lòng chọn ngày sinh!");
        document.getElementById("txtNgaySinh").focus();
        return false;
    }

    var regexNgay = /^\d{4}-\d{2}-\d{2}$/;

    if (!regexNgay.test(ngaySinh)) {
        alert("Ngày sinh phải có dạng yyyy-MM-dd");
        document.getElementById("txtNgaySinh").focus();
        return false;
    }
    var regexSDT = /^0\d{9}$/;

    if (!regexSDT.test(sdt)) {
        alert("Số điện thoại không hợp lệ");
        return false;
    }

    if (dc == "") {
        alert("Nhập địa chỉ");
        return false;
    }

    var regexEmail = /^\S+@\S+\.\S+$/;

    if (!regexEmail.test(email)) {
        alert("Email không hợp lệ");
        return false;
    }

    if (kh == "") {
        alert("Nhập khóa học");
        return false;
    }

    if (lop == "") {
        alert("Nhập lớp học");
        return false;
    }

    return true;
}

function ChiNhapSo(evt) {
    var c = evt.which ? evt.which : evt.keyCode;

    if (c > 31 && (c < 48 || c > 57))
        return false;

    return true;
}