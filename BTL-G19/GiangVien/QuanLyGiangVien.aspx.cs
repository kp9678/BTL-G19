using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using BTL_G19.Models;

namespace BTL_G19.GiangVien
{
    public partial class QuanLyGiangVien : System.Web.UI.Page
    {

        private string filePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            filePath = Server.MapPath("~/App_Data/GiangVien.txt");

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

            if (role == "Student")
            {
                Response.Write(
                    "<script>alert('Bạn không có quyền truy cập!');" +
                    "window.location='../QuanLyHocVien/QuanLyHocVien.aspx';</script>");
                return;
            }

            if (!IsPostBack)
            {
                Application["DanhSachGiangVien"] = DocFile();

                if (role == "Teacher")
                {
                    btnLamMoi.Visible = false;
                    btnTimKiem.Visible = false;
                    txtSearch.Visible = false;
                    btnThem.Visible = false;
                    gvGiangVien.Visible = false;
                    txtMaGV.ReadOnly = true;
                    LoadThongTinGiangVien();
                }
                else
                {
                    txtMaGV.Text = TaoMaGV();
                    HienThiDanhSach();
                }
            }
        }

        private void LoadThongTinGiangVien()
        {
            string maGV = Session["MaGV"].ToString();

            List<Models.GiangVien> ds = DocFile();

            foreach (Models.GiangVien gv in ds)
            {
                if (gv.MaGV == maGV)
                {
                    txtMaGV.Text = gv.MaGV;
                    txtTenGV.Text = gv.TenGV;
                    txtEmail.Text = gv.Email;
                    txtSDT.Text = gv.SDT;
                    txtChuyenMon.Text = gv.ChuyenMon;

                    break;
                }
            }
        }
        // ĐỌC FILE
        private List<Models.GiangVien> DocFile()
        {

            List<Models.GiangVien> ds =
                new List<Models.GiangVien>();


            if (!File.Exists(filePath))
            {
                return ds;
            }


            string[] lines =
                File.ReadAllLines(filePath);



            foreach (string line in lines)
            {

                if (string.IsNullOrWhiteSpace(line))
                    continue;


                string[] data =
                    line.Split('|');


                if (data.Length == 5)
                {

                    Models.GiangVien gv =
                        new Models.GiangVien();


                    gv.MaGV = data[0];
                    gv.TenGV = data[1];
                    gv.Email = data[2];
                    gv.SDT = data[3];
                    gv.ChuyenMon = data[4];


                    ds.Add(gv);

                }

            }
            return ds;

        }

        private void GhiFile(List<Models.GiangVien> ds)
        {
            List<string> lines =
                new List<string>();
            foreach (Models.GiangVien gv in ds)
            {

                lines.Add(
                    gv.MaGV + "|" +
                    gv.TenGV + "|" +
                    gv.Email + "|" +
                    gv.SDT + "|" +
                    gv.ChuyenMon
                );

            }
           File.WriteAllLines(filePath, lines);
        }
        private void HienThiDanhSach()
        {
            List<Models.GiangVien> ds =
                DocFile();
            gvGiangVien.DataSource = ds;
            gvGiangVien.DataBind();
            Application["DanhSachGiangVien"] = ds;

        }

        private string TaoMaGV()
        {
            List<Models.GiangVien> ds = DocFile();

            if (ds.Count == 0)
            {
                return "GV001";
            }

            int max = 0;

            foreach (Models.GiangVien gv in ds)
            {
                string ma = gv.MaGV.Replace("GV", "");

                int so = int.Parse(ma);

                if (so > max)
                {
                    max = so;
                }
            }

            return "GV" + (max + 1).ToString("000");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
           
            List<Models.GiangVien> ds = DocFile();

            Models.GiangVien gv = new Models.GiangVien();

            gv.MaGV = TaoMaGV(); 

            gv.TenGV = txtTenGV.Text.Trim();
            gv.Email = txtEmail.Text.Trim();
            gv.SDT = txtSDT.Text.Trim();
            gv.ChuyenMon = txtChuyenMon.Text.Trim();

            ds.Add(gv);

            GhiFile(ds);

            Script("Thêm giảng viên thành công");

            HienThiDanhSach();

            XoaTrang();

            txtMaGV.Text = TaoMaGV();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            List<Models.GiangVien> ds = DocFile();

            Models.GiangVien gv = null;

            if (Session["Role"].ToString() == "Teacher")
            {
                string maGV = Session["MaGV"].ToString();

                gv = ds.FirstOrDefault(x => x.MaGV == maGV);
            }
            else
            {
                gv = ds.FirstOrDefault(
                    x => x.MaGV == txtMaGV.Text.Trim()
                );
            }

            if (gv == null)
            {
                Script("Không tìm thấy giảng viên");
                return;
            }

            gv.TenGV = txtTenGV.Text.Trim();
            gv.Email = txtEmail.Text.Trim();
            gv.SDT = txtSDT.Text.Trim();
            gv.ChuyenMon = txtChuyenMon.Text.Trim();

            GhiFile(ds);

            Script("Sửa thành công");

            if (Session["Role"].ToString() == "Teacher")
            {
                LoadThongTinGiangVien();
            }
            else
            {
                HienThiDanhSach();
            }
        }
        protected void gvGiangVien_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Xoa")
            {
                string maGV =
                    e.CommandArgument.ToString();
                List<Models.GiangVien> ds =
                    DocFile();
                Models.GiangVien gv =
                    ds.FirstOrDefault(
                        x => x.MaGV == maGV
                    );
                if (gv != null)
                {
                    ds.Remove(gv);
                    GhiFile(ds);
                    Script("Xóa thành công");
                    HienThiDanhSach();

                }


            }
        }
        protected void btnTimKiem_Click(
            object sender,
            EventArgs e)
        {
            List<Models.GiangVien> ds =
                DocFile();
            string key =
                txtSearch.Text.Trim()
                .ToLower();
            if (key != "")
            {

                ds =
                ds.Where(
                    x =>
                    x.MaGV.ToLower().Contains(key)
                    ||
                    x.TenGV.ToLower().Contains(key)
                )
                .ToList();

            }
            gvGiangVien.DataSource = ds;

            gvGiangVien.DataBind();

        }
        protected void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {

            XoaTrang();

            HienThiDanhSach();

        }
        private void XoaTrang()
        {
            txtMaGV.Text = TaoMaGV();
            txtTenGV.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtChuyenMon.Text = "";
        }
        private void Script(string msg)
        {

            Response.Write(
                "<script>alert('"
                + msg +
                "');</script>"
            );

        }


    }
}