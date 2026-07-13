using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using BTL_G19.Models;

namespace BTL_G19.KhoaHoc
{
    public partial class QuanLyKhoaHoc : System.Web.UI.Page
    {
        private string filePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePath = Server.MapPath("~/App_Data/KhoaHoc.txt");

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
                HienThiDanhSach();
                Application["DanhSachKhoaHoc"] = DocFile();
            }
        }

        private List<Models.KhoaHoc> DocFile()
        {
            List<Models.KhoaHoc> ds =
                new List<Models.KhoaHoc>();

            if (!File.Exists(filePath))
                return ds;

            string[] lines =
                File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data =
                    line.Split('|');

                if (data.Length == 6)
                {
                    Models.KhoaHoc kh =
                        new Models.KhoaHoc();

                    kh.MaKH = data[0];
                    kh.TenKH = data[1];
                    kh.CapDo = data[2];
                    kh.TrangThai = data[3];
                    kh.HocPhi = data[4];
                    kh.ThoiLuong = data[5];

                    ds.Add(kh);
                }
            }

            return ds;
        }

        private void GhiFile(List<Models.KhoaHoc> ds)
        {
            List<string> lines =
                new List<string>();

            foreach (Models.KhoaHoc kh in ds)
            {
                lines.Add(
                    kh.MaKH + "|" +
                    kh.TenKH + "|" +
                    kh.CapDo + "|" +
                    kh.TrangThai + "|" +
                    kh.HocPhi + "|" +
                    kh.ThoiLuong
                    );
            }

            File.WriteAllLines(filePath, lines);
        }
        private void HienThiDanhSach()
        {
            List<Models.KhoaHoc> ds =
                DocFile();

            gvKhoaHoc.DataSource = ds;
            gvKhoaHoc.DataBind();

            Application["DanhSachKhoaHoc"] = ds;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            List<Models.KhoaHoc> ds =
                DocFile();

            Models.KhoaHoc kh =
                new Models.KhoaHoc();

            kh.MaKH = txtMaKH.Text.Trim();
            kh.TenKH = txtTenKH.Text.Trim();
            kh.CapDo = ddlCapDo.SelectedValue;
            kh.TrangThai = ddlTrangThai.SelectedValue;
            kh.HocPhi = txtHocPhi.Text.Trim();
            kh.ThoiLuong = txtThoiLuong.Text.Trim();

            if (ds.Any(x => x.MaKH == kh.MaKH))
            {
                Script("Mã khóa học đã tồn tại!");
                return;
            }

            ds.Add(kh);

            GhiFile(ds);

            Script("Thêm khóa học thành công!");

            HienThiDanhSach();

            XoaTrang();
        }

        private void XoaTrang()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtHocPhi.Text = "";
            txtThoiLuong.Text = "";

            ddlCapDo.SelectedIndex = 0;
            ddlTrangThai.SelectedIndex = 0;
        }

        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrang();
            HienThiDanhSach();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Models.KhoaHoc> ds = DocFile();

            string key = txtSearch.Text.Trim().ToLower();

            if (key != "")
            {
                ds = ds.Where(x =>
                    x.MaKH.ToLower().Contains(key) ||
                    x.TenKH.ToLower().Contains(key)
                ).ToList();
            }

            gvKhoaHoc.DataSource = ds;
            gvKhoaHoc.DataBind();
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            List<Models.KhoaHoc> ds = DocFile();

            Models.KhoaHoc kh = ds.FirstOrDefault(x => x.MaKH == txtMaKH.Text.Trim());

            if (kh == null)
            {
                Script("Không tìm thấy khóa học");
                return;
            }

            kh.TenKH = txtTenKH.Text.Trim();
            kh.CapDo = ddlCapDo.SelectedValue;
            kh.TrangThai = ddlTrangThai.SelectedValue;
            kh.HocPhi = txtHocPhi.Text.Trim();
            kh.ThoiLuong = txtThoiLuong.Text.Trim();

            GhiFile(ds);
            HienThiDanhSach();

            Script("Cập nhật thành công");
        }
        protected void gvKhoaHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ThongTin")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                string maKH =
                    gvKhoaHoc.DataKeys[index].Value.ToString();

                List<Models.KhoaHoc> ds = DocFile();

                Models.KhoaHoc kh =
                    ds.FirstOrDefault(x => x.MaKH == maKH);

                if (kh != null)
                {
                    txtMaKH.Text = kh.MaKH;
                    txtTenKH.Text = kh.TenKH;
                    txtHocPhi.Text = kh.HocPhi;
                    txtThoiLuong.Text = kh.ThoiLuong;

                    ddlCapDo.SelectedValue = kh.CapDo;
                    ddlTrangThai.SelectedValue = kh.TrangThai;
                }
            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            List<Models.KhoaHoc> ds = DocFile();

            Models.KhoaHoc kh =
                ds.FirstOrDefault(x => x.MaKH == txtMaKH.Text.Trim());

            if (kh == null)
            {
                Script("Không tìm thấy khóa học.");
                return;
            }

            ds.Remove(kh);

            GhiFile(ds);

            HienThiDanhSach();

            XoaTrang();

            Script("Xóa thành công.");
        }
        private void Script(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}