using System;
using System.Data;
using System.IO;
using System.Linq;

namespace BTL_G19.BaoCao
{
    public partial class BaoCao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("../DangNhap/login.aspx");
                return;
            }

            if (Session["Role"] == null)
            {
                Response.Redirect("../DangNhap/login.aspx");
                return;
            }

            string role = Session["Role"].ToString();

            if (role == "Teacher")
            {
                Response.Write(
                    "<script>alert('Bạn không có quyền truy cập!');" +
                    "window.location='../GiangVien/QuanLyGiangVien.aspx';</script>");
                return;
            }

            if (role == "Student")
            {
                Response.Write(
                    "<script>alert('Bạn không có quyền truy cập!');" +
                    "window.location='../QuanLyHocVien/QuanLyHocVien.aspx';</script>");
                return;
            }

            if (!IsPostBack)
            {
                LoadThongKe();
                LoadData();
            }
        }
        private void LoadThongKe()
        {
            lblGiangVien.Text = DemDong("~/App_Data/GiangVien.txt").ToString();

            lblHocVien.Text = DemDong("~/App_Data/HocVien.txt").ToString();

            lblKhoaHoc.Text = DemDong("~/App_Data/KhoaHoc.txt").ToString();

            // Chưa có LopHoc.txt nên tạm lấy số lớp khác nhau
            lblLopHoc.Text = DemDong("~/App_Data/LopHoc.txt").ToString();

            // Tổng đăng ký = số học viên
            lblDangKy.Text = DemDong("~/App_Data/DangKy.txt").ToString();

            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private int DemDong(string path)
        {
            string file = Server.MapPath(path);

            if (!File.Exists(file))
                return 0;

            return File.ReadAllLines(file).Length;
        }

        private int DemSoLop()
        {
            string path = Server.MapPath("~/App_Data/HocVien.txt");

            if (!File.Exists(path))
                return 0;

            return File.ReadAllLines(path)
                .Select(x => x.Split('|'))
                .Where(x => x.Length >= 9)
                .Select(x => x[8])
                .Distinct()
                .Count();
        }
        private int DemDangKy()
        {
            string path = Server.MapPath("~/App_Data/HocVien.txt");

            if (!File.Exists(path))
                return 0;

            return File.ReadAllLines(path)
                .Select(x => x.Split('|'))
                .Where(x =>
                    x.Length >= 10 &&
                    !string.IsNullOrWhiteSpace(x[8]) &&
                    x[9].Trim() == "Đang học")
                .Count();
        }
        private DataTable TaoBangThongKe()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("TenKhoaHoc");
            dt.Columns.Add("SoHocVien");

            string pathKH = Server.MapPath("~/App_Data/KhoaHoc.txt");
            string pathHV = Server.MapPath("~/App_Data/HocVien.txt");

            if (!File.Exists(pathKH))
                return dt;

            string[] khoaHoc = File.ReadAllLines(pathKH);

            string[] hocVien = File.Exists(pathHV)
                ? File.ReadAllLines(pathHV)
                : new string[0];

            foreach (string kh in khoaHoc)
            {
                string[] info = kh.Split('|');

                if (info.Length < 2)
                    continue;

                string tenKH = info[1];

                int soHV = hocVien.Count(x =>
                {
                    string[] hv = x.Split('|');

                    return hv.Length >= 8 &&
                           hv[7].Trim().Equals(tenKH,
                           StringComparison.OrdinalIgnoreCase);
                });

                dt.Rows.Add(tenKH, soHV);
            }

            return dt;
        }

        private void LoadData()
        {
            gvBaoCao.DataSource = TaoBangThongKe();

            gvBaoCao.DataBind();
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = TaoBangThongKe();

            string key = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(key))
            {
                DataView dv = dt.DefaultView;

                dv.RowFilter = "TenKhoaHoc LIKE '%" + key + "%'";

                gvBaoCao.DataSource = dv;
            }
            else
            {
                gvBaoCao.DataSource = dt;
            }

            gvBaoCao.DataBind();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            LoadThongKe();

            LoadData();
        }
    }
}