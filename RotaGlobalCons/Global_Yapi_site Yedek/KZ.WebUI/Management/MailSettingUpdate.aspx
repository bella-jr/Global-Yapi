<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="MailSettingUpdate.aspx.cs" Inherits="KZ.WebUI.Management.MailSettingUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="content-wrap">
        <div class="main">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-8 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <h1>Genel Ayarlar</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Genel Ayarlar</a></li>
                                    <li class="active">Mail Sunucu Ayarları</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="main-content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card alert">
                                <div class="card-header">
                                    <img src="assets/images/menu_icons/genel.png" />&nbsp; 
                                    <h4>Mail Sunucu Ayarları</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <asp:UpdatePanel runat="server" ID="upMailSetting">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                    <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                                </div>
                                                <div class="form-group">
                                                    <label>Sunucu</label>
                                                    <asp:TextBox runat="server" ID="txtServer" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvServer" ForeColor="#e74c3c" ControlToValidate="txtServer" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Port</label>
                                                    <asp:TextBox runat="server" ID="txtPort" CssClass="form-control" onkeypress="return isNumber(event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPort" ForeColor="#e74c3c" ControlToValidate="txtPort" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>SSL</label><br />
                                                    <asp:CheckBox ID="cbSSL" runat="server" Text="Evet / Hayır" />
                                                </div>
                                                <div class="form-group">
                                                    <label>Hesap</label>
                                                    <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvMail" ForeColor="#e74c3c" ControlToValidate="txtMail" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="rexMail" runat="server" ErrorMessage="Lütfen mail formatına uygun bir değer giriniz." ForeColor="#e74c3c" ControlToValidate="txtMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Şifre</label>
                                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ForeColor="#e74c3c" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Mail Başlık</label>
                                                    <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>İletişim Formu Mail</label>
                                                    <asp:TextBox runat="server" ID="txtContactMail" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvContactMail" ForeColor="#e74c3c" ControlToValidate="txtContactMail" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="rexContactMail" runat="server" ErrorMessage="Mail formatına uygun değil." ForeColor="#e74c3c" ControlToValidate="txtContactMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                                <%--<div class="form-group">
                                                    <label>Teklif Formu Mail</label>
                                                    <asp:TextBox runat="server" ID="txtOrderMail" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfvOrderMail" ForeColor="#e74c3c" ControlToValidate="txtOrderMail" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revOrderMail" runat="server" ErrorMessage="Mail formatına uygun değil." ForeColor="#e74c3c" ControlToValidate="txtOrderMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>--%>
                                                <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_OnClick" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomCode" runat="server">
</asp:Content>
