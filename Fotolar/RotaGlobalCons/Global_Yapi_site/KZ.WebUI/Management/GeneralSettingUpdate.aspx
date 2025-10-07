<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="GeneralSettingUpdate.aspx.cs" Inherits="KZ.WebUI.Management.GeneralSettingUpdate" %>

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
                                <h1>Genel Ayarlar</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Genel Ayarlar</a></li>
                                    <li class="active">Sayfa Genel Ayarları</li>
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
                                    <h4>Sayfa Genel Ayarları</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>

                                        <%--<div class="form-group">
                                            <asp:Literal runat="server" ID="ltlLogo"></asp:Literal>
                                            <br />
                                            <br />
                                            <label>Logo</label>
                                            <br />
                                            <asp:FileUpload ID="flpLogo" runat="server" CssClass="form-control" />
                                            <asp:Literal ID="ltlErrorMessage" runat="server"></asp:Literal>
                                            <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpLogo"></asp:RegularExpressionValidator>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Adres</label>
                                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" MaxLength="250" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Adres 2</label>
                                            <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control" MaxLength="250" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Telefon</label>
                                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" MaxLength="20" onkeypress="return isNumver(event);"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Telefon 2</label>
                                            <asp:TextBox runat="server" ID="txtPhone2" CssClass="form-control" MaxLength="20" onkeypress="return isNumber(event);"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Telefon 3</label>
                                            <asp:TextBox runat="server" ID="txtPhone3" CssClass="form-control" MaxLength="20" onkeypress="return isNumber(event);"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Telefon 4</label>
                                            <asp:TextBox runat="server" ID="txtPhone4" CssClass="form-control" MaxLength="20" onkeypress="return isNumber(event);"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Fax</label>
                                            <asp:TextBox runat="server" ID="txtFax" CssClass="form-control" MaxLength="20" onkeypress="return isNumber(event);"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Whatsapp (Ör: +905324122531)</label>
                                            <asp:TextBox runat="server" ID="txtWhatsapp" CssClass="form-control" MaxLength="20" onkeypress="return isNumver(event);"></asp:TextBox>
                                        </div>
                                        <%-- <div class="form-group">
                                            <label>Whatsapp 2 (Ör: +905324122531)</label>
                                            <asp:TextBox runat="server" ID="txtWhatsapp2" CssClass="form-control" MaxLength="20" onkeypress="return isNumver(event);"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Mail</label>
                                            <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Mail 2</label>
                                            <asp:TextBox runat="server" ID="txtMail2" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Facebook</label>
                                            <asp:TextBox runat="server" ID="txtFacebook" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Twitter</label>
                                            <asp:TextBox runat="server" ID="txtTwitter" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Instagram</label>
                                            <asp:TextBox runat="server" ID="txtInstagram" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Linekdin</label>
                                            <asp:TextBox runat="server" ID="txtLinkedin" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Google Plus</label>
                                            <asp:TextBox runat="server" ID="txtGooglePlus" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>--%>

                                        <%-- <div class="form-group">
                                            <label>Youtube</label>
                                            <asp:TextBox runat="server" ID="txtYoutube" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>--%>
                                        <%-- <div class="form-group">
                                            <label>Pinterest</label>
                                            <asp:TextBox runat="server" ID="txtPinterest" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Seo Başlık</label>
                                            <asp:TextBox runat="server" ID="txtSeoTitle" ClientIDMode="Static" CssClass="form-control" MaxLength="500" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Seo Açıklama</label>
                                            <asp:TextBox runat="server" ID="txtSeoDescription" CssClass="form-control" MaxLength="500" onkeypress="return isTextNumber(event);" TextMode="MultiLine" Height="150"></asp:TextBox>
                                        </div>
                                        <%-- <div class="form-group">
                                            <label>Seo Anahtar Kelime</label>
                                            <asp:TextBox runat="server" ID="txtSeoKeyword" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);" data-role="tagsinput"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>İletişim Harita</label>
                                            <CKEditor:CKEditorControl ID="ckeMaps" runat="server" CssClass="form-control" />
                                        </div>
                                        <div class="form-group">
                                            <label>Html Kod</label>
                                            <CKEditor:CKEditorControl ID="ckeHtmlCode" runat="server" CssClass="form-control" />
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Havale/EFT Hesap Bilgileri</label>
                                            <CKEditor:CKEditorControl ID="chkPaymentDescription" runat="server" CssClass="form-control" />
                                        </div>--%>
                                        <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_OnClick" />
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
