using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using BTL_G19.Models;

namespace BTL_G19.LopHoc
{
    public partial class QuanLyLopHoc : System.Web.UI.Page
    {
        string path = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath("~/App_Data/LopHoc.txt");

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
            List<LopHocModel> ds = new List<LopHocModel>();

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split('|');

                if (data.Length >= 7)
                {
                    LopHocModel lh = new LopHocModel();

                    lh.MaLop = data[0];
                    lh.GiangVien = data[1];
                    lh.KhoaHoc = data[2];
                    lh.NgayKhaiGiang = data[3];
                    lh.NgayKetThuc = data[4];
                    lh.SoLuongToiDa = data[5];
                    lh.PhongHoc = data[6];

                    ds.Add(lh);
                }
            }

            gvLopHoc.DataSource = ds;
            gvLopHoc.DataBind();
        }

        void Clear()
        {
            txtMaLop.Text = "";
            txtGiangVien.Text = "";
            txtKhoaHoc.Text = "";
            txtNgayKhaiGiang.Text = "";
            txtNgayKetThuc.Text = "";
            txtSoLuongToiDa.Text = "";
            txtPhongHoc.Text = "";
        }


        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (File.ReadAllLines(path)
                .Any(x => x.Split('|')[0] == txtMaLop.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "tb",
                    "alert('Mã lớp đã tồn tại!');",
                    true);

                return;
            }

            string dong =
                txtMaLop.Text.Trim() + "|" +
                txtGiangVien.Text.Trim() + "|" +
                txtKhoaHoc.Text.Trim() + "|" +
                txtNgayKhaiGiang.Text + "|" +
                txtNgayKetThuc.Text + "|" +
                txtSoLuongToiDa.Text.Trim() + "|" +
                txtPhongHoc.Text.Trim();

            File.AppendAllText(path, dong + Environment.NewLine);

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "tb",
                "alert('Lưu thành công!');",
                true);

            Clear();
            LoadData();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<string> ds = File.ReadAllLines(path).ToList();

            for (int i = 0; i < ds.Count; i++)
            {
                string[] data = ds[i].Split('|');

                if (data[0] == txtMaLop.Text.Trim())
                {
                    ds[i] =
                        txtMaLop.Text.Trim() + "|" +
                        txtGiangVien.Text.Trim() + "|" +
                        txtKhoaHoc.Text.Trim() + "|" +
                        txtNgayKhaiGiang.Text + "|" +
                        txtNgayKetThuc.Text + "|" +
                        txtSoLuongToiDa.Text.Trim() + "|" +
                        txtPhongHoc.Text.Trim();

                    break;
                }
            }

            File.WriteAllLines(path, ds);

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "tb",
                "alert('Cập nhật thành công!');",
                true);

            Clear();
            LoadData();
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            List<string> ds = File.ReadAllLines(path).ToList();

            ds.RemoveAll(x => x.Split('|')[0] == txtMaLop.Text.Trim());

            File.WriteAllLines(path, ds);

            ClientScript.RegisterStartupScript(
                this.GetType(),
                "tb",
                "alert('Đã xóa lớp học!');",
                true);

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
            List<LopHocModel> ds = new List<LopHocModel>();

            foreach (string line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] data = line.Split('|');

                if (data.Length >= 7)
                {
                    LopHocModel lh = new LopHocModel();

                    lh.MaLop = data[0];
                    lh.GiangVien = data[1];
                    lh.KhoaHoc = data[2];
                    lh.NgayKhaiGiang = data[3];
                    lh.NgayKetThuc = data[4];
                    lh.SoLuongToiDa = data[5];
                    lh.PhongHoc = data[6];

                    if (lh.MaLop.ToLower().Contains(txtTimKiem.Text.Trim().ToLower()) ||
                        lh.GiangVien.ToLower().Contains(txtTimKiem.Text.Trim().ToLower()) ||
                        lh.KhoaHoc.ToLower().Contains(txtTimKiem.Text.Trim().ToLower()))
                    {
                        ds.Add(lh);
                    }
                }
            }
            Response.Write("Số dòng: " + ds.Count);

            gvLopHoc.DataSource = ds;
            gvLopHoc.DataBind();
        }
        protected void gvLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvLopHoc.SelectedRow == null)
                return;

            GridViewRow row = gvLopHoc.SelectedRow;

            txtMaLop.Text = Server.HtmlDecode(row.Cells[1].Text);
            txtGiangVien.Text = Server.HtmlDecode(row.Cells[2].Text);
            txtKhoaHoc.Text = Server.HtmlDecode(row.Cells[3].Text);
            txtNgayKhaiGiang.Text = Server.HtmlDecode(row.Cells[4].Text);
            txtNgayKetThuc.Text = Server.HtmlDecode(row.Cells[5].Text);
            txtSoLuongToiDa.Text = Server.HtmlDecode(row.Cells[6].Text);
            txtPhongHoc.Text = Server.HtmlDecode(row.Cells[7].Text);
        }

    }
}