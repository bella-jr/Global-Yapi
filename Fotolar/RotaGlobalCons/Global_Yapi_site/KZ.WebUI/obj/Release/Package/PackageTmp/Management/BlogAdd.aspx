<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="BlogAdd.aspx.cs" Inherits="KZ.WebUI.Management.BlogAdd" ValidateRequest="false" %>

<%@ Import Namespace="KZ.WebUI.Tool" %>

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
                                <h1>Blog Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Blog Yönetim</a></li>
                                    <li class="active">Yeni Blog Ekle</li>
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
                                    <img src="assets/images/menu_icons/news.png" />&nbsp; 
                                    <h4>Yeni Blog Ekle</h4>
                                </div>
                                <div class="card-body">
                                    <asp:Panel ID="pnlContent" runat="server" CssClass="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <%--<div class="form-group">
                                                    <label>İçerik Tipi</label>
                                                    <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged">
                                                        <asp:ListItem Text="Blog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>--%>
                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="150" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Link</label>
                                            <asp:TextBox runat="server" ID="txtLink" CssClass="form-control" MaxLength="250" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvLink" ForeColor="#e74c3c" ControlToValidate="txtLink" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                            <asp:Label runat="server" ID="lblMessage" ForeColor="#e74c3c"></asp:Label>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>Kapak Resmi</label>&nbsp;<span style="color: red;">(Width (Genişlik):&nbsp;<%= StaticDataTool.getBlogImageWidth() %>px&nbsp;-&nbsp;Height (Yükseklik):&nbsp;<%= StaticDataTool.getBlogImageHeight() %>px)</span>
                                            <br />
                                            <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" />
                                            <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                            <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpImage"></asp:RegularExpressionValidator>
                                        </div>

                                        <div class="form-group" style="padding: 0px !important;">
                                            <label>Açıklama</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <b>Durum:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" Text="Aktif / Pasif" />
                                        </div>
                                        <div class="form-group">
                                            <label>Galeri</label>
                                            <asp:DropDownList runat="server" ID="ddlGallery" CssClass="form-control" />
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
