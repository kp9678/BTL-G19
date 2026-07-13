<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="login.aspx.cs"
    Inherits="Trang_đăng_nhập.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Đăng nhập</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="../CSS/login.css" rel="stylesheet" />

    <script src="../scripts/login.js" type="text/javascript"></script>

</head>

<body>

<form id="form1" runat="server">

    <div class="background">

        <div class="login-card">

            <div class="logo">
                <img src="Images/logo.jpg" alt="Logo" />
            </div>

            <h2>Chào mừng đến với trung tâm đào tạo</h2>
            <h3>Học viện G-19</h3>

            <div class="textbox">

                <label>Tên đăng nhập hoặc Email</label>

                <asp:TextBox
                    ID="txtUser"
                    runat="server"
                    ClientIDMode="Static"
                    CssClass="input"
                    placeholder="Nhập tên đăng nhập hoặc Email">
                </asp:TextBox>

            </div>

            <div class="textbox">

                <label>Mật khẩu</label>

                <asp:TextBox
                    ID="txtPassword"
                    runat="server"
                    ClientIDMode="Static"
                    CssClass="input"
                    TextMode="Password"
                    placeholder="Nhập mật khẩu">
                </asp:TextBox>

            </div>

            <div class="option">

                <div class="remember">
                    <asp:CheckBox
                        ID="chkRemember"
                        runat="server"
                        Text=" Ghi nhớ đăng nhập" />
                </div>
            </div>

            <asp:Button
                ID="btnLogin"
                runat="server"
                Text="Đăng nhập"
                CssClass="btnLogin"
                OnClientClick="return checkLogin();"
                OnClick="btnLogin_Click" />

            <br /><br />

            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="message"
                ForeColor="Red">
            </asp:Label>

        </div>

    </div>

</form>

</body>
</html>