<%@ Page Title="Báo Cáo"
Language="C#"
MasterPageFile="~/TrangChu/Site.Master"
AutoEventWireup="true"
CodeBehind="BaoCao.aspx.cs"
Inherits="BTL_G19.BaoCao.BaoCao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../CSS/BaoCao.css" rel="stylesheet" />

<script>

    function DongHo() {

        var d = new Date();

        var h = d.getHours();
        var m = d.getMinutes();
        var s = d.getSeconds();

        if (m < 10) m = "0" + m;
        if (s < 10) s = "0" + s;

        document.getElementById("clock").innerHTML = h + ":" + m + ":" + s;

    }

    setInterval(DongHo, 1000);

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-title">

<h2>TỔNG QUAN THỐNG KÊ</h2>

<div class="time">

Ngày:
<asp:Label ID="lblNgay" runat="server"></asp:Label>

&nbsp;&nbsp;&nbsp;

Giờ:

<span id="clock"></span>

</div>

</div>


<div class="dashboard">

<div class="card blue">

<h3>Khóa học</h3>

<asp:Label
ID="lblKhoaHoc"
runat="server">
</asp:Label>

</div>


<div class="card pink">

<h3>Học viên</h3>

<asp:Label
ID="lblHocVien"
runat="server">
</asp:Label>

</div>


<div class="card green">

<h3>Giảng viên</h3>

<asp:Label
ID="lblGiangVien"
runat="server">
</asp:Label>

</div>


<div class="card yellow">

<h3>Lớp học</h3>

<asp:Label
ID="lblLopHoc"
runat="server">
</asp:Label>

</div>

</div>



<div class="register">

<h3>Đăng ký khóa học </h3>

<asp:Label
ID="lblDangKy"
runat="server">
</asp:Label>

</div>



<div class="search">

<asp:TextBox
ID="txtSearch"
runat="server"
CssClass="txtSearch"
placeholder="Nhập tên khóa học...">
</asp:TextBox>

<asp:Button
ID="btnTim"
runat="server"
Text="Tìm kiếm"
CssClass="btn"
OnClick="btnTim_Click"/>

<asp:Button
ID="btnRefresh"
runat="server"
Text="Làm mới"
CssClass="btn"
OnClick="btnRefresh_Click"/>

</div>



<asp:GridView

ID="gvBaoCao"

runat="server"

CssClass="table"

AutoGenerateColumns="False"

GridLines="None">

<Columns>

<asp:BoundField
HeaderText="Khóa học"
DataField="TenKhoaHoc"/>

<asp:BoundField
HeaderText="Số học viên"
DataField="SoHocVien"/>

</Columns>

</asp:GridView>

</asp:Content>