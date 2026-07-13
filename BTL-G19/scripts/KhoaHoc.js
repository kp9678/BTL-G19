function KiemTraDuLieu() {

    var maKH = document.getElementById("txtMaKH").value.trim();

    var tenKH = document.getElementById("txtTenKH").value.trim();

    var hocPhi = document.getElementById("txtHocPhi").value.trim();

    var thoiLuong = document.getElementById("txtThoiLuong").value.trim();

    var capDo = document.getElementById("ddlCapDo").value;

    var trangThai = document.getElementById("ddlTrangThai").value;

    if (maKH == "") {

        alert("Vui lòng nhập mã khóa học!");

        document.getElementById("txtMaKH").focus();

        return false;
    }



    var regexMa = /^KH[0-9]{2,}$/;

    if (!regexMa.test(maKH)) {

        alert("Mã khóa học phải có dạng KH01, KH02...");

        document.getElementById("txtMaKH").focus();

        return false;
    }

    if (tenKH == "") {

        alert("Vui lòng nhập tên khóa học!");

        document.getElementById("txtTenKH").focus();

        return false;
    }



    if (tenKH.length < 3) {

        alert("Tên khóa học quá ngắn!");

        document.getElementById("txtTenKH").focus();

        return false;
    }


    if (hocPhi == "") {

        alert("Vui lòng nhập học phí!");

        document.getElementById("txtHocPhi").focus();

        return false;
    }



    if (isNaN(hocPhi)) {

        alert("Học phí phải là số!");

        document.getElementById("txtHocPhi").focus();

        return false;
    }



    if (parseInt(hocPhi) <= 0) {

        alert("Học phí phải lớn hơn 0!");

        document.getElementById("txtHocPhi").focus();

        return false;
    }


    if (thoiLuong == "") {

        alert("Vui lòng nhập thời lượng!");

        document.getElementById("txtThoiLuong").focus();

        return false;
    }



    var regexBuoi = /^[0-9]+(\s)?buổi$/i;

    if (!regexBuoi.test(thoiLuong)) {

        alert("Thời lượng phải có dạng: 16 buổi");

        document.getElementById("txtThoiLuong").focus();

        return false;
    }


    if (capDo == "") {

        alert("Vui lòng chọn cấp độ!");

        return false;
    }


    if (trangThai == "") {

        alert("Vui lòng chọn trạng thái!");

        return false;
    }



    return true;
}
function XacNhanXoa() {

    return confirm("Bạn có chắc chắn muốn xóa khóa học này không?");

}

function ChiNhapSo(evt) {

    var kyTu = evt.which ? evt.which : evt.keyCode;

    if (kyTu > 31 && (kyTu < 48 || kyTu > 57)) {

        return false;

    }

    return true;

}

function LamMoiForm() {

    document.getElementById("txtMaKH").value = "";

    document.getElementById("txtTenKH").value = "";

    document.getElementById("txtHocPhi").value = "";

    document.getElementById("txtThoiLuong").value = "";

    document.getElementById("ddlCapDo").selectedIndex = 0;

    document.getElementById("ddlTrangThai").selectedIndex = 0;

}