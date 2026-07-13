<%@ Page Title="Quản lý học viên"
Language="C#"
MasterPageFile="~/TrangChu/Site.Master"
AutoEventWireup="true"
CodeBehind="QuanLyHocVien.aspx.cs"
Inherits="BTL_G19.HocVien.QuanLyHocVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../CSS/HocVien.css?v=<%= DateTime.Now.Ticks %>" rel="stylesheet" />

<script src="../Scripts/HocVien.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-title">

<h2>Quản Lý Học Viên</h2>

<p>Quản lý thông tin học viên của trung tâm</p>

</div>

<div class="card">

<div class="card-header">

Thông Tin Học Viên

</div>

<div class="card-body">

<div class="form-row">

<div class="form-group">

<label>Mã học viên<span class="required">*</span></label>

<asp:TextBox
ID="txtMaHV"
runat="server"
ClientIDMode="Static"
CssClass="form-control" />

</div>

<div class="form-group">

<label>Ngày sinh<span class="required">*</span></label>

<asp:TextBox
ID="txtNgaySinh"
runat="server"
ClientIDMode="Static"
CssClass="form-control"
TextMode="Date"
placeholder="dd/MM/yyyy"/>

</div>

<div class="form-group">

<label>Lớp học</label>

<asp:TextBox
ID="txtLopHoc"
runat="server"
ClientIDMode="Static"
CssClass="form-control"/>

</div>

</div>

<div class="form-row">

<div class="form-group">

<label>Tên học viên<span class="required">*</span></label>

<asp:TextBox
ID="txtTenHV"
runat="server"
ClientIDMode="Static"
CssClass="form-control"/>

</div>

<div class="form-group">

<label>Số điện thoại<span class="required">*</span></label>

<asp:TextBox
ID="txtSoDienThoai"
runat="server"
ClientIDMode="Static"
CssClass="form-control"
onkeypress="return ChiNhapSo(event);" />

</div>

<div class="form-group">

<label>Khóa học</label>

<asp:TextBox
ID="txtKhoaHoc"
runat="server"
ClientIDMode="Static"
CssClass="form-control"/>

</div>

</div>

<div class="form-row">

<div class="form-group">

<label>Địa chỉ<span class="required">*</span></label>

<asp:TextBox
ID="txtDiaChi"
runat="server"
ClientIDMode="Static"
CssClass="form-control"/>

</div>

<div class="form-group">

<label>Giới tính<span class="required">*</span></label>

<asp:DropDownList
ID="ddlGioiTinh"
runat="server"
ClientIDMode="Static"
CssClass="form-control">

<asp:ListItem>Nam</asp:ListItem>
<asp:ListItem>Nữ</asp:ListItem>

</asp:DropDownList>

</div>

<div class="form-group">

<label>Email<span class="required">*</span></label>

<asp:TextBox
ID="txtEmail"
runat="server"
ClientIDMode="Static"
CssClass="form-control"/>

</div>

</div>

<div class="form-row">

<div class="form-group">

<label>Trạng thái</label>

<asp:DropDownList
ID="ddlTrangThai"
runat="server"
ClientIDMode="Static"
CssClass="form-control">

<asp:ListItem>Đang học</asp:ListItem>
<asp:ListItem>Bảo lưu</asp:ListItem>
<asp:ListItem>Đã nghỉ</asp:ListItem>

</asp:DropDownList>

</div>

</div>

<div class="button-group">

<asp:Button
ID="btnThem"
runat="server"
Text="Lưu"
CssClass="btn btn-primary"
OnClick="btnThem_Click"
OnClientClick="return KiemTraDuLieu();" />

<asp:Button
ID="btnSua"
runat="server"
Text="Cập nhật"
CssClass="btn btn-warning"
OnClick="btnSua_Click"/>

<asp:Button
ID="btnXoa"
runat="server"
Text="Xóa"
CssClass="btn btn-danger"
OnClick="btnXoa_Click"
OnClientClick="return confirm('Bạn có chắc muốn xóa?');"/>

<asp:Button
ID="btnLamMoi"
runat="server"
Text="Làm mới"
CssClass="btn btn-secondary"
OnClick="btnLamMoi_Click"/>

</div>

</div>

</div>

<div class="card">

<div class="card-header">

Danh Sách Học Viên

</div>

<div class="card-body">

<div class="search-box">

<asp:TextBox
ID="txtSearch"
runat="server"
CssClass="form-control"
placeholder="Tìm theo mã hoặc tên học viên"/>

<asp:Button
ID="btnSearch"
runat="server"
Text="Tìm kiếm"
CssClass="btn btn-primary"
OnClick="btnSearch_Click"/>

</div>
<div class="table-responsive">
<asp:GridView
ID="gvHocVien"
runat="server"
CssClass="table"
AutoGenerateColumns="False"
DataKeyNames="MaHV"
OnRowCommand="gvHocVien_RowCommand">

<Columns>

<asp:TemplateField HeaderText="STT">

<ItemTemplate>

<%# Container.DataItemIndex+1 %>

</ItemTemplate>

</asp:TemplateField>

    <asp:BoundField DataField="MaHV" HeaderText="Mã HV" />
    <asp:BoundField DataField="TenHV" HeaderText="Tên học viên" />
    <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
    <asp:BoundField DataField="SoDienThoai" HeaderText="SĐT" />
    <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
    <asp:BoundField DataField="Email" HeaderText="Email" />
    <asp:BoundField DataField="KhoaHoc" HeaderText="Khóa học" />
    <asp:BoundField DataField="LopHoc" HeaderText="Lớp học" />
    <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái" />

<asp:TemplateField HeaderText="Thao tác">
    <ItemTemplate>
        <asp:Button
            ID="btnThongTin"
            runat="server"
            Text="Thông tin"
            CommandName="ThongTin"
            CommandArgument="<%# Container.DataItemIndex %>"
            CssClass="btn btn-info btn-grid"/>
    </ItemTemplate>
</asp:TemplateField>



</Columns>

</asp:GridView>

</div>
</div>

</div>

</asp:Content>