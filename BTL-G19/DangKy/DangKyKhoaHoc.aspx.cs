using BTL_G19.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace BTL_G19.DangKy
{
    public partial class DangKyKhoaHoc : System.Web.UI.Page
    {
        private string path = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath("~/App_Data/DangKy.txt");

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            if (Session["User"] == null)
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
                LoadData();
            }
        }
        private void LoadData()
        {
            List<DangKy1    > ds = new List<DangKy1 >();

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split('|');

                if (data.Length >= 7)
                {
                    DangKy1 dk = new DangKy1    ();

                    dk.MaDK = data[0];
                    dk.NgayDK = data[1];
                    dk.TrangThai = data[2];
                    dk.HocVien = data[3];
                    dk.PhuongThucTT = data[4];
                    dk.KhoaHoc = data[5];
                    dk.GhiChu = data[6];

                    ds.Add(dk);
                }
            }

            gvDangKy.DataSource = ds;
            gvDangKy.DataBind();
        }
        private void Clear()
        {
            txtMaDK.Text = "";
            txtNgayDK.Text = "";
            txtTrangThai.SelectedIndex = 0;
            txtHocVien.Text = "";
            txtPhuongThucTT.Text = "";
            txtKhoaHoc.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";

            txtMaDK.Focus();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (File.ReadAllLines(path).Any(x => x.Split('|')[0] == txtMaDK.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "tb",
                    "alert('Mã đăng ký đã tồn tại!');", true);
                return;
            }

            string dong =
                txtMaDK.Text.Trim() + "|" +
                txtNgayDK.Text + "|" +
                txtTrangThai.SelectedValue + "|" +
                txtHocVien.Text.Trim() + "|" +
                txtPhuongThucTT.Text.Trim() + "|" +
                txtKhoaHoc.Text.Trim() + "|" +
                txtGhiChu.Text.Trim();

            File.AppendAllText(path, dong + Environment.NewLine);

            ClientScript.RegisterStartupScript(this.GetType(), "tb",
                "alert('Lưu thành công!');", true);

            Clear();
            LoadData();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<string> ds = File.ReadAllLines(path).ToList();

            for (int i = 0; i < ds.Count; i++)
            {
                string[] data = ds[i].Split('|');

                if (data[0] == txtMaDK.Text.Trim())
                {
                    ds[i] =
                        txtMaDK.Text.Trim() + "|" +
                        txtNgayDK.Text + "|" +
                        txtTrangThai.SelectedValue + "|" +
                        txtHocVien.Text.Trim() + "|" +
                        txtPhuongThucTT.Text.Trim() + "|" +
                        txtKhoaHoc.Text.Trim() + "|" +
                        txtGhiChu.Text.Trim();

                    break;
                }
            }

            File.WriteAllLines(path, ds);

            ClientScript.RegisterStartupScript(this.GetType(), "tb",
                "alert('Cập nhật thành công!');", true);

            Clear();
            LoadData();
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            List<string> ds = File.ReadAllLines(path).ToList();

            ds.RemoveAll(x => x.Split('|')[0] == txtMaDK.Text.Trim());

            File.WriteAllLines(path, ds);

            ClientScript.RegisterStartupScript(this.GetType(), "tb",
                "alert('Đã xóa đăng ký!');", true);

            Clear();
            LoadData();
        }
        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
            LoadData();
        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<DangKy1> ds = new List<DangKy1>();

            foreach (string line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split('|');

                DangKy1 dk = new DangKy1();

                dk.MaDK = data[0];
                dk.NgayDK = data[1];
                dk.TrangThai = data[2];
                dk.HocVien = data[3];
                dk.PhuongThucTT = data[4];
                dk.KhoaHoc = data[5];
                dk.GhiChu = data[6];

                if (dk.MaDK.ToLower().Contains(txtTimKiem.Text.Trim().ToLower()) ||
                    dk.HocVien.ToLower().Contains(txtTimKiem.Text.Trim().ToLower()) ||
                    dk.KhoaHoc.ToLower().Contains(txtTimKiem.Text.Trim().ToLower()))
                {
                    ds.Add(dk);
                }
            }

            gvDangKy.DataSource = ds;
            gvDangKy.DataBind();
        }
        protected void gvDangKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDangKy.SelectedRow;

            txtMaDK.Text = row.Cells[1].Text;
            txtNgayDK.Text = row.Cells[2].Text;
            txtTrangThai.SelectedValue = row.Cells[3].Text;
            txtHocVien.Text = Server.HtmlDecode(row.Cells[4].Text);
            txtPhuongThucTT.Text = row.Cells[5].Text;
            txtKhoaHoc.Text = Server.HtmlDecode(row.Cells[6].Text);
            txtGhiChu.Text = Server.HtmlDecode(row.Cells[7].Text);
        }

    }
}