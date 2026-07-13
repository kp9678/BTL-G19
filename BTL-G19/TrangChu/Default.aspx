<%@ Page Title="Tổng Quan Hệ Thống" Language="C#" MasterPageFile="../TrangChu/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BTL.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Dashboard.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/Dashboard.js?v=1" defer></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="charts-row">
        <div class="chart-box">
            <h3>[ Khu vực hiển thị Biểu đồ lượng học sinh học trong tuần ]</h3>

            <div class="chart-inner-combined">
                <div class="chart-container-half">
                    <canvas id="mainBarChart"></canvas>
                </div>

                <div class="chart-container-half">
                    <canvas id="mainPieChart"></canvas>
                </div>
            </div>
        </div>

        <div class="chart-box">
            <h3>[ Biểu đồ các môn ]</h3>

            <div class="chart-full-width">
                <canvas id="sideLineChart"></canvas>
            </div>
        </div>
    </div>

    <div class="services-container">

        <div class="services-header">
            Dịch vụ của bạn
        </div>

        <div class="services-scroll-area">

            <div class="services-grid">

                <!-- Tổng học viên -->
                <div class="card clickable"
     onclick="location.href='../QuanLyHocVien/QuanLyHocVien.aspx';">

    <div class="card-title">Tổng Học Viên Đăng Ký</div>

    <div class="card-value red">
        <asp:Label ID="lblTongHocVien" runat="server"></asp:Label>
    </div>

    <div class="card-subtext">
        <asp:Label ID="lblHocVienSubtext" runat="server"></asp:Label>
    </div>

</div>

                <!-- Yêu cầu mới -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=yêu+cầu+mới+trong+hệ+thống+quản+lý','_blank');">

                    <div class="card-title">Yêu Cầu Mới</div>

                    <div class="card-value green">
                        <asp:Label ID="lblYeuCauMoi" runat="server"></asp:Label>
                    </div>

                </div>

                <!-- Yêu cầu chờ phê duyệt -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=yêu+cầu+chờ+phê+duyệt','_blank');">

                    <div class="card-title">Yêu Cầu Chờ Phê Duyệt</div>

                    <div class="card-desc">
                        Danh sách yêu cầu đang chờ xử lý từ hệ thống
                    </div>

                </div>

                <!-- Giảng viên -->
                <div class="card clickable"
     onclick="location.href='../GiangVien/QuanLyGiangVien.aspx';">

    <div class="card-title">Giảng Viên Hoạt Động</div>

    <div class="card-value green">
        <asp:Label ID="lblGiangVienHoatDong" runat="server"></asp:Label>
    </div>

    <div class="card-desc">
        Giám sát lịch trình và hiệu suất giảng dạy thực tế
    </div>

</div>

                <!-- Phản hồi -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=điểm+phản+hồi+sinh+viên','_blank');">

                    <div class="card-title">Điểm Phản Hồi Sinh Viên</div>

                    <div class="card-desc">
                        Theo dõi mức độ hài lòng và chất lượng đào tạo
                    </div>

                </div>

                <!-- Hoạt động -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=hoạt+động+trung+tâm+đào+tạo','_blank');">

                    <div class="card-title">Các Hoạt Động</div>

                    <div class="card-desc">
                        Quản lý danh sách sự kiện, phong trào và tác vụ
                    </div>

                </div>

                <!-- Tài nguyên -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=quản+lý+tài+nguyên+học+tập','_blank');">

                    <div class="card-title">Quản Lý Tài Nguyên</div>

                    <div class="card-desc">
                        Kho tài liệu, slide bài giảng và mã nguồn mẫu của khóa học
                    </div>

                </div>

                <!-- Lịch khai giảng -->
               <div class="card clickable"
     onclick="location.href='../LopHoc/QuanLyLopHoc.aspx';">

    <div class="card-title">Lịch Khai Giảng</div>

    <div class="card-value green">
        <asp:Label ID="lblLichKhaiGiang" runat="server"></asp:Label>
    </div>

    <div class="card-desc">
        Danh sách các lớp học dự kiến mở mới trong tháng
    </div>

</div>

                

                <!-- Chứng chỉ -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=quản+lý+chứng+chỉ','_blank');">

                    <div class="card-title">Quản Lý Chứng Chỉ</div>

                    <div class="card-desc">
                        Xét duyệt và cấp chứng nhận hoàn thành khóa học cho học viên
                    </div>

                </div>

                <!-- Hỗ trợ -->
                <div class="card clickable"
                    onclick="window.open('https://www.google.com/search?q=hỗ+trợ+học+viên','_blank');">

                    <div class="card-title">Tương Tác Hỗ Trợ</div>

                    <div class="card-value green">
                        <asp:Label ID="lblTuongTacHoTro" runat="server"></asp:Label>
                    </div>

                    <div class="card-desc">
                        Số lượng câu hỏi trên diễn đàn thảo luận cần giải đáp
                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>