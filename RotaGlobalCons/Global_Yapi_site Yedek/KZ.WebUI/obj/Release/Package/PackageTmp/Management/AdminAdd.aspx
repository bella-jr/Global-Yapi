<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="KZ.WebUI.Management.AdminAdd" %>

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
                                <h1>Admin Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Admin Yönetim</a></li>
                                    <li class="active">Yeni Admin Ekle</li>
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
                                    <img src="assets/images/menu_icons/admin.png" />&nbsp;
                                    <h4>Yeni Admin Ekle</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <asp:UpdatePanel runat="server" ID="upAdminAdd">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlContent" runat="server">

                                                    <div class="form-group">
                                                        <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Ad</label>
                                                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control" MaxLength="50" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvName" ForeColor="#e74c3c" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Soyad</label>
                                                        <asp:TextBox runat="server" ID="txtSurname" CssClass="form-control" MaxLength="50" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvSurname" ForeColor="#e74c3c" ControlToValidate="txtSurname" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Mail</label>
                                                        <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvMail" ForeColor="#e74c3c" ControlToValidate="txtMail" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rexMail" runat="server" ErrorMessage="Lütfen mail formatına uygun bir değer giriniz." ForeColor="#e74c3c" ControlToValidate="txtMail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        <asp:Label runat="server" ID="lblMailMessage" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Şifre</label>
                                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword1" ForeColor="#e74c3c" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Şifre Tekrar</label>
                                                        <asp:TextBox runat="server" ID="txtPasswordConfirm" CssClass="form-control" MaxLength="20" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvPasswordConfirm" ForeColor="#e74c3c" ControlToValidate="txtPasswordConfirm" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Şifreler birbiri ile uyuşmamaktadır." ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" Display="Dynamic" ForeColor="#e74c3c"></asp:CompareValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <b>Durum:&nbsp;</b><br />
                                                        <asp:CheckBox runat="server" ID="cbStatus" Checked="True" Text="Aktif / Pasif" />
                                                    </div>
                                                    <div class="form-group">
                                                        <b>Mail ile Bilgilendir:&nbsp;</b><br />
                                                        <p>(Kullanıcıya hesabına ait bilgilendirme maili gönderilmesini sağlamaktadır.)</p>
                                                        <asp:CheckBox runat="server" ID="cbMailNotification" Checked="True" Text="Evet / Hayır" />
                                                    </div>
                                                    <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_OnClick" />
                                                </asp:Panel>
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
