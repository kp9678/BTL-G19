<%@ Page Title="Quản lý giảng viên"
    Language="C#"
    MasterPageFile="~/TrangChu/Site.Master"
    AutoEventWireup="true"
    CodeBehind="QuanLyGiangVien.aspx.cs"
    Inherits="BTL_G19.GiangVien.QuanLyGiangVien" %>


<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">


<link href="../CSS/GiangVien.css" rel="stylesheet" />


<script src="../scripts/GiangVien.js"></script>


</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="MainContent"
    runat="server">


<div class="page-title">

    <h2>
        Quản Lý Giảng Viên
    </h2>

    <p>
        Quản lý thông tin giảng viên của trung tâm đào tạo
    </p>

</div>



<div class="card">


<div class="card-header">
    Thông Tin Giảng Viên
</div>



<div class="card-body">



<div class="form-row">


<div class="form-group">

<label>
Mã giảng viên
</label>


<asp:TextBox 
    ID="txtMaGV"
    runat="server"
    CssClass="form-control"
    ReadOnly="true">
</asp:TextBox>


</div>



<div class="form-group">


<label>
Tên giảng viên
</label>


<asp:TextBox 
    ID="txtTenGV"
    runat="server"
    CssClass="form-control"
    placeholder="Nhập tên giảng viên">
</asp:TextBox>


</div>


</div>
<div class="form-row">
<div class="form-group">
<label>
Email
</label>


<asp:TextBox 
    ID="txtEmail"
    runat="server"
    CssClass="form-control"
    TextMode="Email"
    placeholder="example@gmail.com">
</asp:TextBox>


</div>




<div class="form-group">


<label>
Số điện thoại
</label>

<asp:TextBox 
    ID="txtSDT"
    runat="server"
    CssClass="form-control"
    placeholder="09xxxxxxxx">
</asp:TextBox>


</div>


</div>





<div class="form-row">


<div class="form-group full">


<label>
Chuyên môn
</label>


<asp:TextBox 
    ID="txtChuyenMon"
    runat="server"
    CssClass="form-control"
    placeholder="Ví dụ: Lập trình Web ASP.NET">
</asp:TextBox>


</div>


</div>




<div class="button-group">


<asp:Button
    ID="btnThem"
    runat="server"
    Text="Thêm"
    CssClass="btn btn-primary"
    OnClick="btnThem_Click"
    OnClientClick="return KiemTraDuLieu();" />



<asp:Button
    ID="btnSua"
    runat="server"
    Text="Sửa"
    CssClass="btn btn-warning"
    OnClick="btnSua_Click" />



<asp:Button
    ID="btnLamMoi"
    runat="server"
    Text="Làm mới"
    CssClass="btn btn-secondary"
    OnClick="btnLamMoi_Click" />


</div>


</div>


</div>





<div class="card">


<div class="card-header">
    Danh Sách Giảng Viên
</div>




<div class="card-body">



<div class="search-box">


<asp:TextBox
    ID="txtSearch"
    runat="server"
    CssClass="form-control"
    placeholder="Tìm kiếm theo mã hoặc tên">
</asp:TextBox>



<asp:Button
    ID="btnTimKiem"
    runat="server"
    Text="Tìm kiếm"
    CssClass="btn btn-primary btn-search"
    OnClick="btnTimKiem_Click"/>

</div>







<div class="table-responsive">


<asp:GridView
    ID="gvGiangVien"
    runat="server"

    AutoGenerateColumns="False"

    CssClass="table"

    OnRowCommand="gvGiangVien_RowCommand">


<Columns>



<asp:BoundField
    HeaderText="Mã giảng viên"
    DataField="MaGV"/>



<asp:BoundField
    HeaderText="Tên Giảng Viên"
    DataField="TenGV"/>



<asp:BoundField
    HeaderText="Email"
    DataField="Email"/>



<asp:BoundField
    HeaderText="Số điện thoại"
    DataField="SDT"/>



<asp:BoundField
    HeaderText="Chuyên Môn"
    DataField="ChuyenMon"/>



<asp:TemplateField HeaderText="Xóa">
    <ItemTemplate>
        <asp:Button
            ID="btnXoa"
            runat="server"
            Text="Xóa"
            CommandName="Xoa"
            CommandArgument='<%# Eval("MaGV") %>'
            OnClientClick="return confirm('Bạn có chắc chắn muốn xóa giảng viên này không?');" />
    </ItemTemplate>
</asp:TemplateField>


</Columns>


</asp:GridView>



</div>


</div>


</div>



</asp:Content>