<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KZ.WebUI.Management.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title><%= ConfigurationManager.AppSettings["DomainName"] %> | Yönetim Paneli</title>

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
                            <span>Yönetim Paneli Giriş | <%= KZ.WebUI.Tool.StaticDataTool.getDomainName() %></span>
                        </div>
                        <div class="login-form">
                            <form id="form1" runat="server">
                                <div class="form-group">
                                    <label>E-Mail</label>
                                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="Lütfen mail adresinizi giriniz." ControlToValidate="txtMail" ForeColor="#e74c3c" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexMail" runat="server" ErrorMessage="Mail formatına uygun değil." ForeColor="#e74c3c" ControlToValidate="txtMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Şifre</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Lütfen şifrenizi giriniz." ControlToValidate="txtPassword" ForeColor="#e74c3c" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Dil</label>
                                    <asp:DropDownList runat="server" ID="ddlLanguage" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ErrorMessage="Lütfen seçim yapınız." ControlToValidate="ddlLanguage" InitialValue="0" ForeColor="#e74c3c" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="checkbox">
                                    <label class="pull-right">
                                        <a href="ForgetPassword"><b>Şifremi Unuttum ?</b></a>
                                    </label>
                                </div>
                                <br />
                                <br />
                                <div class="form-group">
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-danger btn-lg" Text="Giriş Yap" OnClick="btnLogin_OnClick" />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblMessage" ForeColor="#e74c3c" runat="server"></asp:Label>
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
