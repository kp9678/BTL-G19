<%@ Page Title="Quản lý khóa học"
Language="C#"
MasterPageFile="~/TrangChu/Site.Master"
AutoEventWireup="true"
CodeBehind="QuanLyKhoaHoc.aspx.cs"
Inherits="BTL_G19.KhoaHoc.QuanLyKhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../CSS/KhoaHoc.css" rel="stylesheet"/>

<script src="../Scripts/KhoaHoc.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-title">

<h2>Quản Lý Khóa Học</h2>

<p>Quản lý thông tin khóa học của trung tâm đào tạo</p>

</div>



<div class="card">

<div class="card-header">

Thông Tin Khóa Học

</div>

<div class="card-body">

<div class="form-row">

<div class="form-group">

<label>Mã khóa học</label>

<asp:TextBox
ID="txtMaKH"
runat="server"
ClientIDMode="Static"
CssClass="form-control">
</asp:TextBox>

</div>

<div class="form-group">

<label>Cấp độ</label>

<asp:DropDownList
ID="ddlCapDo"
runat="server"
ClientIDMode="Static"
CssClass="form-control">

<asp:ListItem>Cơ bản</asp:ListItem>
<asp:ListItem>Nâng cao</asp:ListItem>

</asp:DropDownList>

</div>

<div class="form-group">

<label>Trạng thái</label>

<asp:DropDownList
ID="ddlTrangThai"
runat="server"
ClientIDMode="Static"
CssClass="form-control">

<asp:ListItem>Đang mở</asp:ListItem>
<asp:ListItem>Đã đóng</asp:ListItem>

</asp:DropDownList>

</div>

</div>





<div class="form-row">

<div class="form-group">

<label>Tên khóa học</label>

<asp:TextBox
ID="txtTenKH"
runat="server"
ClientIDMode="Static"
CssClass="form-control">
</asp:TextBox>

</div>

<div class="form-group">

<label>Học phí</label>

<asp:TextBox
ID="txtHocPhi"
runat="server"
ClientIDMode="Static"
CssClass="form-control"
onkeypress="return ChiNhapSo(event)">
</asp:TextBox>

</div>

<div class="form-group">

<label>Thời lượng</label>

<asp:TextBox
ID="txtThoiLuong"
runat="server"
ClientIDMode="Static"
CssClass="form-control">
</asp:TextBox>

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
OnClientClick="return confirm('Bạn có chắc muốn xóa?');" />

<asp:Button
ID="btnLamMoi"
runat="server"
Text="Hủy"
CssClass="btn btn-danger"
OnClick="btnLamMoi_Click"
OnClientClick="LamMoiForm();" />

</div>

</div>

</div>





<div class="card">

<div class="card-header">

Danh Sách Khóa Học

</div>

<div class="card-body">

<div class="search-box">

<asp:TextBox
ID="txtSearch"
runat="server"
CssClass="form-control"
placeholder="Tìm kiếm khóa học">
</asp:TextBox>

<asp:Button
ID="btnSearch"
runat="server"
Text="Tìm kiếm"
CssClass="btn btn-primary"
OnClick="btnSearch_Click"/>

</div>

<div class="table-responsive">

<asp:GridView

ID="gvKhoaHoc"

runat="server"

CssClass="table"

AutoGenerateColumns="False"

DataKeyNames="MaKH"

OnRowCommand="gvKhoaHoc_RowCommand">

<Columns>

    <asp:BoundField DataField="MaKH" HeaderText="Mã khóa học" />

    <asp:BoundField DataField="TenKH" HeaderText="Tên khóa học" />

    <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái" />

    <asp:BoundField DataField="HocPhi" HeaderText="Học phí" />

    <asp:BoundField DataField="ThoiLuong" HeaderText="Thời lượng" />

    <asp:BoundField DataField="CapDo" HeaderText="Cấp độ" />

    <asp:TemplateField HeaderText="Thao tác">

        <ItemTemplate>

            <asp:Button
            ID="btnThongTin"
            runat="server"
            Text="Thông tin"
            CssClass="btn btn-info btn-grid"
            CommandName="ThongTin"
            CommandArgument="<%# Container.DataItemIndex %>" />

        </ItemTemplate>

    </asp:TemplateField>

</Columns>

</asp:GridView>

</div>

</div>

</div>

</asp:Content>