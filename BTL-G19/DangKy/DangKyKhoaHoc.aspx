<%@ Page Title="Quản Lý Đăng Kí Khóa Học" Language="C#" MasterPageFile="../TrangChu/Site.Master" AutoEventWireup="true" CodeBehind="DangKyKhoaHoc.aspx.cs" Inherits="BTL_G19.DangKy.DangKyKhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/GiangVien.css" rel="stylesheet" />
    <style>
        .card-header { color: #ffffff !important; font-weight: bold !important; font-size: 16px; }
        .table tbody tr { cursor: pointer; transition: background 0.2s; }
        .table tbody tr:hover { background-color: #f1f5f9 !important; }
        .row-selected { background-color: #e2e8f0 !important; font-weight: bold; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <h2>Quản Lý Đăng Kí Khóa Học</h2>
    </div>

    <div class="card">
        <div class="card-header">Form nhập đăng ký</div>
        <div class="card-body">
            <div class="form-row">
                <div class="form-group">
                    <label>Mã đăng ký</label>
                   <asp:TextBox
    ID="txtMaDK"
    runat="server"
    CssClass="form-control"
    placeholder="Nhập mã đăng ký">
</asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Ngày đăng ký</label>
                    <asp:TextBox
    ID="txtNgayDK"
    runat="server"
    CssClass="form-control"
    TextMode="Date">
</asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Trạng thái</label>
                   <asp:DropDownList
    ID="txtTrangThai"
    runat="server"
    CssClass="form-control">

    <asp:ListItem>Chưa xác nhận</asp:ListItem>
    <asp:ListItem>Đã xác nhận</asp:ListItem>

</asp:DropDownList>
                       
                </div>
            </div>

            <div class="form-row">
                <div class="form-group">
                    <label>Học viên</label>
                    <asp:TextBox
ID="txtHocVien"
runat="server"
CssClass="form-control">
</asp:TextBox> 
                </div>
                <div class="form-group">
                    <label>Phương thức thanh toán</label>
                    <asp:TextBox
ID="txtPhuongThucTT"
runat="server"
CssClass="form-control">
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

            <div class="form-row" style="grid-column: span 3;">
                <div class="form-group" style="width: 100%;">
                    <label>Ghi chú</label>
                    <asp:TextBox
ID="txtGhiChu"
runat="server"
CssClass="form-control"
TextMode="MultiLine"
Rows="3">
</asp:TextBox>
                </div>
            </div>

            <div class="button-group" style="display: flex; justify-content: space-between; margin-top: 15px;">
                <div>
                   <asp:Button
ID="btnLuu"
runat="server"
Text="Lưu"
CssClass="btn btn-primary"
OnClick="btnLuu_Click"/>
                   <asp:Button
ID="btnCapNhat"
runat="server"
Text="Cập nhật"
CssClass="btn btn-secondary"
OnClick="btnCapNhat_Click"/>
                   <asp:Button
    ID="btnHuy"
    runat="server"
    Text="Hủy"
    CssClass="btn btn-danger"
    OnClick="btnHuy_Click"
    OnClientClick="return confirm('Bạn có chắc muốn xóa không?');"
/>
                </div>
               <asp:Button
    ID="btnLamMoi"
    runat="server"
    Text="Làm mới"
    CssClass="btn btn-light"
    OnClick="btnLamMoi_Click" />
            </div>
        </div>
    </div>

    <div class="card" style="margin-top: 20px;">
        <div class="card-header">Danh sách đăng ký</div>
        <div class="card-body">
            <div class="search-box" style="display: flex; gap: 10px; margin-bottom: 15px;">
              <asp:TextBox
    ID="txtTimKiem"
    runat="server"
    CssClass="form-control"
    placeholder="Tìm kiếm..." />
               <asp:Button
    ID="btnTimKiem"
    runat="server"
    Text="Tìm kiếm"
    CssClass="btn btn-primary"
    OnClick="btnTimKiem_Click" />
            </div>

            <div class="table-responsive">

    <<asp:GridView
    ID="gvDangKy"
    runat="server"
    AutoGenerateColumns="False"
    CssClass="table table-bordered table-hover"
    Width="100%"
    DataKeyNames="MaDK"
    OnSelectedIndexChanged="gvDangKy_SelectedIndexChanged">

        <Columns>
            <asp:CommandField
    ShowSelectButton="True"
    SelectText="Chọn"
    HeaderText="" />

            <asp:BoundField HeaderText="Mã đăng ký" DataField="MaDK" />

            <asp:BoundField HeaderText="Ngày đăng ký" DataField="NgayDK" />

            <asp:BoundField HeaderText="Trạng thái" DataField="TrangThai" />

            <asp:BoundField HeaderText="Học viên" DataField="HocVien" />

            <asp:BoundField HeaderText="Phương thức TT" DataField="PhuongThucTT" />

            <asp:BoundField HeaderText="Khóa học" DataField="KhoaHoc" />

            <asp:BoundField HeaderText="Ghi chú" DataField="GhiChu" />

        </Columns>

    </asp:GridView>

</div>
        </div>
    </div>
    
</asp:Content>