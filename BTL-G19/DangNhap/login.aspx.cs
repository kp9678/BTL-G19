using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Trang_đăng_nhập
{
    public partial class login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Login"] != null)
                {
                    txtUser.Text = Request.Cookies["Login"]["User"];
                    txtPassword.Attributes["value"] = Request.Cookies["Login"]["Password"];
                    chkRemember.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            string path = Server.MapPath("~/App_Data/user.txt");

            if (!File.Exists(path))
            {
                lblMessage.Text = "Không tìm thấy file user.txt";
                return;
            }

            string[] lines = File.ReadAllLines(path);

            bool loginSuccess = false;
            string username = "";
            string role = "";

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] item = line.Split('|');

                if (item.Length < 4)
                    continue;

                string fileUsername = item[0];
                string fileEmail = item[1];
                string filePassword = item[2];
                string filerole = item[3];

                if ((account == fileUsername || account == fileEmail) &&
                    password == filePassword)
                {
                    loginSuccess = true;
                    username = fileUsername;
                    role = filerole;
                    break;
                }
            }

            if (loginSuccess)
            {
                Session["User"] = username;
                Session["Role"] = role;
                Session["MaGV"] = username;

                if (chkRemember.Checked)
                {
                    Response.Cookies["Login"]["User"] = account;
                    Response.Cookies["Login"]["Password"] = password;
                    Response.Cookies["Login"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["Login"].Expires = DateTime.Now.AddDays(-1);
                }

                if (role == "Admin")
                {
                    Response.Redirect("../TrangChu/Default.aspx");
                }
                else if (role == "Teacher")
                {
                    Response.Redirect("../GiangVien/QuanLyGiangVien.aspx");
                }
                else if (role == "Student")
                {
                    Response.Redirect("../TrangChu/Default.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
            }
        }
    }
}