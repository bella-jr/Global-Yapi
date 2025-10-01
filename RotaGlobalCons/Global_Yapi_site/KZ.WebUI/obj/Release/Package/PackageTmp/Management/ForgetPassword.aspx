<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="KZ.WebUI.Management.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title><%= ConfigurationManager.AppSettings["DomainName"] %> | Şifremi Unuttum ?</title>

    <link rel="shortcut icon" href="/img/favicon.ico" type="image/x-icon" />
    <link rel="icon" href="/img/favicon.ico" type="image/x-icon" />
    <link href="assets/css/lib/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/lib/themify-icons.css" rel="stylesheet" />
    <link href="assets/css/lib/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/lib/unix.css" rel="stylesheet" />
    <link href="assets/css/style.css" rel="stylesheet" />
</head>
<body class="bg-primary">
    <div class="unix-login">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-lg-offset-3">
                    <div class="login-content">
                        <div class="login-logo">
                            <span>Şifremi Unuttum ? | <%= KZ.WebUI.Tool.StaticDataTool.getDomainName() %></span>
                        </div>
                        <div class="login-form">
                            <form id="form1" runat="server">
                                <div class="form-group">
                                    <label>E-Mail</label>
                                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="Lütfen mail adresinizi giriniz." ControlToValidate="txtMail" ForeColor="#e74c3c" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexMail" runat="server" ErrorMessage="Mail formatına uygun değil." ForeColor="#e74c3c" ControlToValidate="txtMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <asp:Button runat="server" ID="btnSendPassword" Text="Gönder" CssClass="btn btn-primary btn-flat m-b-15" OnClick="btnSendPassword_OnClick" />
                                <br />
                                <div class="form-group">
                                    <asp:Label ID="lblMessage" ForeColor="#e74c3c" runat="server"></asp:Label>
                                </div>
                                <div class="register-link text-center">
                                    <p><a href="/Management">Yönetim Paneli Giriş</a></p>
                                </div>
                            </form>
                        </div>
                        <br />
                        <p style="text-align: center; color: #fff;">@ <%= DateTime.Now.Year == 2018 ? "2018" : "2017 -" + DateTime.Now.Year.ToString()  %> FTC YAZILIM | Versiyon: <%= ConfigurationManager.AppSettings["Version"].ToString() %></p>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
