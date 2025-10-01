<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="ArticleAdd.aspx.cs" Inherits="KZ.WebUI.Management.ArticleAdd" ValidateRequest="false" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.4.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

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
                                <h1>Yazı Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Yazı Yönetim</a></li>
                                    <li class="active">Yeni Yazı Ekle</li>
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
                                    <img src="assets/images/menu_icons/article.png" />&nbsp;
                                    <h4>Yeni Yazı Ekle</h4>
                                </div>
                                <div class="card-body">
                                    <asp:Panel ID="pnlContent" runat="server" CssClass="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>

                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtTitle" ClientIDMode="Static" CssClass="form-control" MaxLength="150" onkeypress="return isTextNumber(event);" onkeyup="setSeoTitle(this.value);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Açıklama</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription" runat="server" CssClass="form-control" />
                                        </div>
                                        <div class="form-group">
                                            <label>Menü</label>
                                            <asp:DropDownList runat="server" ID="ddlMenuList" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ID="rfvMenu" ForeColor="#e74c3c" ControlToValidate="ddlMenuList" InitialValue="0" Display="Dynamic" ErrorMessage="Lütfen menü seçimi yapınız."></asp:RequiredFieldValidator>
                                            <asp:Label runat="server" ID="lblMessage" ForeColor="#e74c3c"></asp:Label>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Şablon Tipi</label>
                                            <asp:DropDownList ID="ddlPageTypleList" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1">Normal Sayfa</asp:ListItem>
                                                <asp:ListItem Value="2">Hizmet Detay Sayfası</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Galeri</label>
                                            <asp:DropDownList runat="server" ID="ddlGallery" CssClass="form-control" />
                                        </div>
                                        <div class="form-group">
                                            <b>Durum:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" Text="Aktif / Pasif" />
                                        </div>
                                        <div class="form-group">
                                            <label>Seo Başlık</label>
                                            <asp:TextBox runat="server" ID="txtSeoTitle" ClientIDMode="Static" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvSeoTitle" ForeColor="#e74c3c" ControlToValidate="txtSeoTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Seo Açıklama</label>
                                            <asp:TextBox runat="server" ID="txtSeoDescription" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvSeoDescription" ForeColor="#e74c3c" ControlToValidate="txtSeoDescription" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Seo Anahtar Kelime</label>
                                            <asp:TextBox runat="server" ID="txtSeoKeyword" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);" data-role="tagsinput"></asp:TextBox>
                                        </div>
                                        <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_OnClick" />
                                    </asp:Panel>
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
    <script>
        function setSeoTitle(text) {
            document.getElementById('txtSeoTitle').value = text;
        }
    </script>
</asp:Content>

