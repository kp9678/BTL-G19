using BTL_G19.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace BTL_G19.HocVien
{
    public partial class QuanLyHocVien : System.Web.UI.Page
    {
        private string filePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            filePath = Server.MapPath("~/App_Data/HocVien.txt");

            if (Session["User"] == null)
            {
                Response.Redirect("../DangNhap/login.aspx");
            }

            if (Session["Role"] == null)
            {
                Response.Redirect("../DangNhap/login.aspx");
            }

            string role = Session["Role"].ToString();
            if (role == "Teacher")
            {
                Response.Write(
                    "<script>alert('Bạn không có quyền truy cập!');" +
                    "window.location='../GiangVien/QuanLyGiangVien.aspx';</script>");
                return;
            }

            if (role != "Admin" && role != "Student")
            {
                Response.Redirect("../TrangChu/Default.aspx");
            }

            if (!IsPostBack)
            {
                PhanQuyen();

                HienThiThongTinHocVien();

                HienThiDanhSach();
            }
        }
        private void PhanQuyen()
        {
            if (Session["Role"].ToString() == "Student")
            {
                btnLamMoi.Visible = false;
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnSearch.Visible = false;
                txtSearch.Visible = false;
                txtMaHV.Enabled = false;
                txtKhoaHoc.Enabled = false;
                txtLopHoc.Enabled = false;
                ddlTrangThai.Enabled = false;
            }
        }

        private List<Models.HocVien> DocFile()
        {
            List<Models.HocVien> ds =
                new List<Models.HocVien>();

            if (!File.Exists(filePath))
                return ds;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split('|');

                if (data.Length == 10)
                {
                    Models.HocVien hv =
                        new Models.HocVien();

                    hv.MaHV = data[0];
                    hv.TenHV = data[1];
                    hv.NgaySinh = data[2];
                    hv.GioiTinh = data[3];
                    hv.SoDienThoai = data[4];
                    hv.DiaChi = data[5];
                    hv.Email = data[6];
                    hv.KhoaHoc = data[7];
                    hv.LopHoc = data[8];
                    hv.TrangThai = data[9];

                    ds.Add(hv);
                }
            }

            return ds;
        }
        private void GhiFile(List<Models.HocVien> ds)
        {
            List<string> lines =
                new List<string>();

            foreach (Models.HocVien hv in ds)
            {
                lines.Add(
                    hv.MaHV + "|" +
                    hv.TenHV + "|" +
                    hv.NgaySinh + "|" +
                    hv.GioiTinh + "|" +
                    hv.SoDienThoai + "|" +
                    hv.DiaChi + "|" +
                    hv.Email + "|" +
                    hv.KhoaHoc + "|" +
                    hv.LopHoc + "|" +
                    hv.TrangThai
                );
            }

            File.WriteAllLines(filePath, lines);
        }
        private void HienThiDanhSach()
        {
            List<Models.HocVien> ds = DocFile();

            if (Session["Role"].ToString() == "Student")
            {
                string maHV = Session["User"].ToString().ToUpper();

                ds = ds.Where(x => x.MaHV.ToUpper() == maHV).ToList();
            }

            gvHocVien.DataSource = ds;
            gvHocVien.DataBind();

            if (Session["Role"].ToString() == "Student")
            {
                gvHocVien.Columns[10].Visible = false;
            }
        }
        private void HienThiThongTinHocVien()
        {
            if (Session["Role"].ToString() != "Student")
                return;

            string maHV = Session["User"].ToString().ToUpper();

            List<Models.HocVien> ds = DocFile();

            Models.HocVien hv = ds.FirstOrDefault(x => x.MaHV.ToUpper() == maHV);

            if (hv != null)
            {
                txtMaHV.Text = hv.MaHV;
                txtTenHV.Text = hv.TenHV;
                DateTime ngay;

                if (DateTime.TryParseExact(
                        hv.NgaySinh,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out ngay))
                {
                    txtNgaySinh.Text = ngay.ToString("yyyy-MM-dd");
                }
                ddlGioiTinh.SelectedValue = hv.GioiTinh;
                txtSoDienThoai.Text = hv.SoDienThoai;
                txtDiaChi.Text = hv.DiaChi;
                txtEmail.Text = hv.Email;
                txtKhoaHoc.Text = hv.KhoaHoc;
                txtLopHoc.Text = hv.LopHoc;
                ddlTrangThai.SelectedValue = hv.TrangThai;
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            List<Models.HocVien> ds = DocFile();

            Models.HocVien hv =
                new Models.HocVien();

            hv.MaHV = txtMaHV.Text.Trim();
            hv.TenHV = txtTenHV.Text.Trim();
            DateTime ngay = DateTime.Parse(txtNgaySinh.Text);

            hv.NgaySinh = ngay.ToString("dd/MM/yyyy");
            hv.GioiTinh = ddlGioiTinh.SelectedValue;
            hv.SoDienThoai = txtSoDienThoai.Text.Trim();
            hv.DiaChi = txtDiaChi.Text.Trim();
            hv.Email = txtEmail.Text.Trim();
            hv.KhoaHoc = txtKhoaHoc.Text.Trim();
            hv.LopHoc = txtLopHoc.Text.Trim();
            hv.TrangThai = ddlTrangThai.SelectedValue;
            if (Session["Role"].ToString() != "Admin")
            {
                Script("Bạn không có quyền thêm học viên!");
                return;
            }
            if (ds.Any(x => x.MaHV == hv.MaHV))
            {
                Script("Mã học viên đã tồn tại!");
                return;
            }

            ds.Add(hv);

            GhiFile(ds);

            HienThiDanhSach();

            XoaTrang();

            Script("Thêm học viên thành công!");
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            List<Models.HocVien> ds = DocFile();

            Models.HocVien hv =
                ds.FirstOrDefault(x => x.MaHV == txtMaHV.Text.Trim());

            if (hv == null)
            {
                Script("Không tìm thấy học viên!");
                return;
            }
            if (Session["Role"].ToString() == "Student")
            {
                hv.SoDienThoai = txtSoDienThoai.Text.Trim();
                hv.DiaChi = txtDiaChi.Text.Trim();
                hv.Email = txtEmail.Text.Trim();

                GhiFile(ds);
                HienThiDanhSach();

                Script("Cập nhật thành công!");
                return;
            }
            hv.TenHV = txtTenHV.Text.Trim();
            DateTime ngay = DateTime.Parse(txtNgaySinh.Text);

            hv.NgaySinh = ngay.ToString("dd/MM/yyyy");
            hv.GioiTinh = ddlGioiTinh.SelectedValue;
            hv.SoDienThoai = txtSoDienThoai.Text.Trim();
            hv.DiaChi = txtDiaChi.Text.Trim();
            hv.Email = txtEmail.Text.Trim();
            hv.KhoaHoc = txtKhoaHoc.Text.Trim();
            hv.LopHoc = txtLopHoc.Text.Trim();
            hv.TrangThai = ddlTrangThai.SelectedValue;

            GhiFile(ds);

            HienThiDanhSach();

            Script("Cập nhật thành công!");
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            List<Models.HocVien> ds = DocFile();

            Models.HocVien hv =
                ds.FirstOrDefault(x => x.MaHV == txtMaHV.Text.Trim());
            if (Session["Role"].ToString() != "Admin")
            {
                Script("Bạn không có quyền xóa học viên!");
                return;
            }
            if (hv == null)
            {
                Script("Không tìm thấy học viên!");
                return;
            }

            ds.Remove(hv);

            GhiFile(ds);

            HienThiDanhSach();

            XoaTrang();

            Script("Xóa thành công!");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Models.HocVien> ds = DocFile();

            string key =
                txtSearch.Text.Trim().ToLower();

            if (key != "")
            {
                ds = ds.Where(x =>
                    x.MaHV.ToLower().Contains(key) ||
                    x.TenHV.ToLower().Contains(key) ||
                    x.KhoaHoc.ToLower().Contains(key) ||
                    x.LopHoc.ToLower().Contains(key)
                ).ToList();
            }

            gvHocVien.DataSource = ds;
            gvHocVien.DataBind();
        }
        protected void gvHocVien_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ThongTin")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                string maHV =
                    gvHocVien.DataKeys[index].Value.ToString();
                if (Session["Role"].ToString() == "Student")
                {
                    if (maHV.ToUpper() != Session["User"].ToString().ToUpper())
                    {
                        Script("Bạn không có quyền xem học viên này!");
                        return;
                    }
                }
                List<Models.HocVien> ds = DocFile();

                Models.HocVien hv =
                    ds.FirstOrDefault(x => x.MaHV == maHV);

                if (hv != null)
                {
                    txtMaHV.Text = hv.MaHV;
                    txtTenHV.Text = hv.TenHV;
                    DateTime ngay;

                    if (DateTime.TryParseExact(
                            hv.NgaySinh,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out ngay))
                    {
                        txtNgaySinh.Text = ngay.ToString("yyyy-MM-dd");
                    }
                    ddlGioiTinh.SelectedValue = hv.GioiTinh;
                    txtSoDienThoai.Text = hv.SoDienThoai;
                    txtDiaChi.Text = hv.DiaChi;
                    txtEmail.Text = hv.Email;
                    txtKhoaHoc.Text = hv.KhoaHoc;
                    txtLopHoc.Text = hv.LopHoc;
                    ddlTrangThai.SelectedValue = hv.TrangThai;
                }
            }
        }
        private void XoaTrang()
        {
            txtMaHV.Text = "";
            txtTenHV.Text = "";
            txtNgaySinh.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtKhoaHoc.Text = "";
            txtLopHoc.Text = "";

            ddlGioiTinh.SelectedIndex = 0;
            ddlTrangThai.SelectedIndex = 0;
        }
        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrang();

            HienThiDanhSach();
        }
        private void Script(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}