using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace BTL
{
    public partial class Default : System.Web.UI.Page
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTongHocVien.Text = DemDong("~/App_Data/HocVien.txt").ToString();
                lblHocVienSubtext.Text = "Đã đăng ký";

                lblGiangVienHoatDong.Text = DemDong("~/App_Data/GiangVien.txt").ToString();

                lblLichKhaiGiang.Text = DemDong("~/App_Data/KhoaHoc.txt").ToString();

                lblYeuCauMoi.Text = "0";
                
                lblTuongTacHoTro.Text = "0";

                LoadBarChart();
                LoadPieChart();
                LoadLineChart();
            }
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
                Response.Redirect("../DangNhap/login.aspx");
            }
        }

        private int DemDong(string path)
        {
            string file = Server.MapPath(path);

            if (!File.Exists(file))
                return 0;

            return File.ReadAllLines(file).Length;
        }

        //==================================================
        // BIỂU ĐỒ CỘT
        //==================================================
        private void LoadBarChart()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            string file = Server.MapPath("~/App_Data/HocVien.txt");

            if (File.Exists(file))
            {
                foreach (string line in File.ReadAllLines(file))
                {
                    string[] p = line.Split('|');

                    if (p.Length >= 8)
                    {
                        string khoaHoc = p[7];

                        if (!data.ContainsKey(khoaHoc))
                            data[khoaHoc] = 0;

                        data[khoaHoc]++;
                    }
                }
            }

            string script =
                "var barLabels=" + js.Serialize(data.Keys.ToList()) + ";" +
                "var barData=" + js.Serialize(data.Values.ToList()) + ";";

            ClientScript.RegisterStartupScript(GetType(), "bar", script, true);
        }

        //==================================================
        // BIỂU ĐỒ TRÒN
        //==================================================
        private void LoadPieChart()
        {
            int dangMo = 0;
            int daDong = 0;

            string file = Server.MapPath("~/App_Data/KhoaHoc.txt");

            if (File.Exists(file))
            {
                foreach (string line in File.ReadAllLines(file))
                {
                    string[] p = line.Split('|');

                    if (p.Length >= 4)
                    {
                        if (p[3].Trim() == "Đang mở")
                            dangMo++;
                        else
                            daDong++;
                    }
                }
            }

            string script =
                "var pieLabels=['Đang mở','Đã đóng'];" +
                "var pieData=[" + dangMo + "," + daDong + "];";

            ClientScript.RegisterStartupScript(GetType(), "pie", script, true);
        }

        //==================================================
        // BIỂU ĐỒ ĐƯỜNG
        //==================================================
        private void LoadLineChart()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            string file = Server.MapPath("~/App_Data/HocVien.txt");

            if (File.Exists(file))
            {
                foreach (string line in File.ReadAllLines(file))
                {
                    string[] p = line.Split('|');

                    if (p.Length >= 9)
                    {
                        string lop = p[8];

                        if (!data.ContainsKey(lop))
                            data[lop] = 0;

                        data[lop]++;
                    }
                }
            }

            string script =
                "var lineLabels=" + js.Serialize(data.Keys.ToList()) + ";" +
                "var lineData=" + js.Serialize(data.Values.ToList()) + ";";

            ClientScript.RegisterStartupScript(GetType(), "line", script, true);
        }
    }
}