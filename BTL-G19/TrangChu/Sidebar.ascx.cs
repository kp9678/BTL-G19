using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL
{
    public partial class Sidebar : System.Web.UI.UserControl
    {
        protected string CurrentPage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            if (Session["User"] != null)
            {
                lblUser.Text = Session["User"].ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/DangNhap/login.aspx");
        }
    }
}