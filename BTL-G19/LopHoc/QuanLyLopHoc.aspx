<%@ Page Title="Quản Lý Lớp Học" Language="C#" MasterPageFile="../TrangChu/Site.Master"
    AutoEventWireup="true" CodeBehind="QuanLyLopHoc.aspx.cs"
    Inherits="BTL_G19.LopHoc.QuanLyLopHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../CSS/GiangVien.css" rel="stylesheet" />

    <style>
        .card-header {
            color: #fff !important;
            font-size:16px;
            font-weight:bold;
        }

        .table tbody tr{
            cursor:pointer;
        }

        .table tbody tr:hover{
            background:#eef5ff;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-title">
    <h2>Quản Lý Lớp Học</h2>
</div>


<div class="card">

<div class="card-header">
Form nhập lớp học
</div>

<div class="card-body">

<div class="form-row">

<div class="form-group">
<label>Mã lớp</label>

<asp:TextBox
ID="txtMaLop"
runat="server"
CssClass="form-control">
</asp:TextBox>

</div>


<div class="form-group">

<label>Ngày khai giảng</label>

<asp:TextBox
ID="txtNgayKhaiGiang"
runat="server"
CssClass="form-control"
TextMode="Date">
</asp:TextBox>

</div>


<div class="form-group">

<label>Phòng học</label>

<asp:TextBox
ID="txtPhongHoc"
runat="server"
CssClass="form-control">
</asp:TextBox>

</div>

</div>



<div class="form-row">

<div class="form-group">

<label>Giảng viên</label>

<asp:TextBox
ID="txtGiangVien"
runat="server"
CssClass="form-control">
</asp:TextBox>

</div>



<div class="form-group">

<label>Ngày kết thúc</label>

<asp:TextBox
ID="txtNgayKetThuc"
runat="server"
CssClass="form-control"
TextMode="Date">
</asp:TextBox>

</div>



<div class="form-group">

<label>Khóa học</label>

<asp:TextBox
ID="txtKhoaHoc"
runat="server"
CssClass="form-control">
</asp:TextBox>

</div>

</div>




<div class="form-row">

<div class="form-group">

<label>Số lượng tối đa</label>

<asp:TextBox
ID="txtSoLuongToiDa"
runat="server"
TextMode="Number"
CssClass="form-control">
</asp:TextBox>

</div>

</div>




<div class="button-group"
style="display:flex;
justify-content:space-between;
margin-top:20px;">

<div>

<asp:Button
ID="btnLuu"
runat="server"
Text="Lưu"
CssClass="btn btn-primary"
OnClick="btnLuu_Click" />


<asp:Button
ID="btnCapNhat"
runat="server"
Text="Cập nhật"
CssClass="btn btn-secondary"
OnClick="btnCapNhat_Click" />


<asp:Button
ID="btnHuy"
runat="server"
Text="Hủy"
CssClass="btn btn-danger"
OnClick="btnHuy_Click"
OnClientClick="return confirm('Bạn có chắc muốn xóa?');"/>

</div>


<asp:Button
ID="btnLamMoi"
runat="server"
Text="Làm mới"
CssClass="btn btn-light"
OnClick="btnLamMoi_Click"/>

</div>

</div>

</div>





<div class="card" style="margin-top:20px;">

<div class="card-header">
Danh sách lớp học
</div>

<div class="card-body">


<div class="search-box"
style="display:flex;
gap:10px;
margin-bottom:15px;">

<asp:TextBox
ID="txtTimKiem"
runat="server"
CssClass="form-control"
placeholder="Tìm kiếm..."/>


<asp:Button
ID="btnTimKiem"
runat="server"
Text="Tìm kiếm"
CssClass="btn btn-primary"
OnClick="btnTimKiem_Click"/>

</div>




<div class="table-responsive">

<asp:GridView
    ID="gvLopHoc"
    runat="server"
    AutoGenerateColumns="False"
    CssClass="table table-bordered table-hover"
    Width="100%"
    DataKeyNames="MaLop"
    OnSelectedIndexChanged="gvLopHoc_SelectedIndexChanged">

    <Columns>

        <asp:CommandField
            ShowSelectButton="True"
            HeaderText=""
            SelectText="Chọn" />

        <asp:BoundField HeaderText="Mã lớp" DataField="MaLop" />
        <asp:BoundField HeaderText="Giảng viên" DataField="GiangVien" />
        <asp:BoundField HeaderText="Khóa học" DataField="KhoaHoc" />
        <asp:BoundField HeaderText="Ngày khai giảng" DataField="NgayKhaiGiang" />
        <asp:BoundField HeaderText="Ngày kết thúc" DataField="NgayKetThuc" />
        <asp:BoundField HeaderText="Số lượng tối đa" DataField="SoLuongToiDa" />
        <asp:BoundField HeaderText="Phòng học" DataField="PhongHoc" />

    </Columns>

</asp:GridView>

</div>

</div>

</div>

</asp:Content>