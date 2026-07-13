<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="BTL.Sidebar" %>
<aside class="sidebar">
    <div class="sidebar-top">
        <div class="logo-area">
            <i class="fa-solid fa-graduation-cap"></i>
            <div class="logo-text"><h2>LMS</h2><p>Learning Management System</p></div>
        </div>
        <ul class="menu-list">
            <li class='menu-item <%= CurrentPage=="Default.aspx" ? "active" : "" %>'>
    <a href="../TrangChu/Default.aspx">
        <i class="fa-solid fa-house"></i>Tổng Quan
    </a>
</li>

<li class='menu-item <%= CurrentPage=="QuanLyKhoaHoc.aspx" ? "active" : "" %>'>
    <a href="../KhoaHoc/QuanLyKhoaHoc.aspx">
        <i class="fa-solid fa-book"></i>Khóa Học
    </a>
</li>

<li class='menu-item <%= CurrentPage=="DangKyKhoaHoc.aspx" ? "active" : "" %>'>
    <a href="../DangKy/DangKyKhoaHoc.aspx">
        <i class="fa-solid fa-id-card"></i>Đăng Kí Khóa Học
    </a>
</li>

<li class='menu-item <%= CurrentPage=="QuanLyHocVien.aspx" ? "active" : "" %>'>
    <a href="../QuanLyHocVien/QuanLyHocVien.aspx">
        <i class="fa-solid fa-user"></i>Học Viên
    </a>
</li>

<li class='menu-item <%= CurrentPage=="QuanLyGiangVien.aspx" ? "active" : "" %>'>
    <a href="../GiangVien/QuanLyGiangVien.aspx">
        <i class="fa-solid fa-user-tie"></i>Giảng Viên
    </a>
</li>

<li class='menu-item <%= CurrentPage=="QuanLyLopHoc.aspx" ? "active" : "" %>'>
    <a href="../LopHoc/QuanLyLopHoc.aspx">
        <i class="fa-solid fa-users"></i>Lớp Học
    </a>
</li>

<li class='menu-item <%= CurrentPage=="BaoCao.aspx" ? "active" : "" %>'>
    <a href="../BaoCao/BaoCao.aspx">
        <i class="fa-solid fa-chart-simple"></i>Báo Cáo
    </a>
</li>
            
            <li class="menu-item logout">
    <asp:LinkButton ID="btnLogout"
        runat="server"
        OnClick="btnLogout_Click">
        <i class="fa-solid fa-right-from-bracket"></i>
        Đăng Xuất
    </asp:LinkButton>
</li>
        </ul>
    </div>
    <div class="admin-profile">
    <div class="admin-avatar">
        <i class="fa-solid fa-circle-user"></i>
    </div>

    <div class="admin-info">
        <h4>
            <asp:Label ID="lblUser" runat="server" Text="Admin"></asp:Label>
        </h4>
    </div>
</div>
</aside>