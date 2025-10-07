<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="MenuAdd.aspx.cs" Inherits="KZ.WebUI.Management.MenuAdd" %>

<%@ Import Namespace="KZ.WebUI.Tool" %>

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
                                <h1>Menü Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Menü Yönetim</a></li>
                                    <li class="active">Yeni Menü Ekle</li>
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
                                    <img src="assets/images/menu_icons/menu.png" />&nbsp;
                                    <h4>Yeni Menü Ekle</h4>
                                </div>
                                <div class="card-body">
                                    <asp:Panel runat="server" ID="pnlContent" CssClass="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <label>Kapak Resmi</label>
                                            &nbsp;<span style="color: red;">(Width (Genişlik):&nbsp;<%= StaticDataTool.getCategoryImageWidth() %>px&nbsp;-&nbsp;Height (Yükseklik):&nbsp;<%= StaticDataTool.getCategoryImageHeight() %>px)</span>
                                            <br />
                                            <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" />
                                            <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                            <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpImage"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" MaxLength="100" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvName" ForeColor="#e74c3c" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <%-- <div class="form-group">
                                            <label>Menü Açıklama</label>
                                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label>İlişkili Menü</label>
                                            <asp:DropDownList runat="server" ID="ddlMenuList" CssClass="form-control" />
                                        </div>

                                        <div class="form-group">
                                            Harici Link Olsun:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbExternalLink" Checked="False" Text="Evet / Hayır" AutoPostBack="True" OnCheckedChanged="cbExternalLink_OnCheckedChanged" />
                                        </div>
                                        <div class="form-group">
                                            <label>Link</label>
                                            <asp:TextBox runat="server" ID="txtLink" CssClass="form-control" MaxLength="250" Enabled="False"></asp:TextBox>
                                            <asp:Label runat="server" ID="lblLinkMessage" ForeColor="#e74c3c"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label>Tip</label>
                                            <asp:DropDownList runat="server" ID="ddlMenuType" CssClass="form-control">
                                                <asp:ListItem Text="Menü" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Kategori" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            Alt Menülerini Listele:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsSubMenuListView" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <%--  <div class="form-group">
                                            Üst Sol Kısımda Göster:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsHeaderLeft" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <div class="form-group">
                                            Üst Sağ Kısımda Göster:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsHeaderRight" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                            Anasayfa Ürün Göster:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsProduct" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                            Detay Sayfası Olarak Seç:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsDetailPage" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%-- <div class="form-group">
                                            Detay Sayfasında Hizmetleri Göster:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsOtherService" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                            Detay Sayfasında Form Göster:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsForm" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                            Listeleme Kısmında Solda Göster:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsSidebar" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                                    Üst Kısımda Açılır Menüde Ana Kategori Olsun:&nbsp;<br />
                                                    <asp:CheckBox runat="server" ID="cbIsMainHeaderAccordion" Checked="False" Text="Evet / Hayır" />
                                                </div>
                                                <div class="form-group">
                                                    Üst Kısımda Açılır Menüde Göster:&nbsp;<br />
                                                    <asp:CheckBox runat="server" ID="cbIsHeaderAccordion" Checked="False" Text="Evet / Hayır" />
                                                </div>
                                                
                                        --%>
                                        <%-- <div class="form-group">
                                            Mega Menü Olarak Listele:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsMega" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <div class="form-group">
                                            Mega Menü Altında Listele:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsMegaSubView" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <div class="form-group">
                                            Farklı Sekmede Açılsın:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsTarget" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <div class="form-group">
                                            En Alt Kısımda Gözüksün:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsFooter" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <div class="form-group">
                                            En Alt Hizmetlerimiz Kısımda Gözüksün:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsFooter2" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <div class="form-group">
                                            En Üst Kısımda Gözüksün:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsHeaderTop" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <%--<div class="form-group">
                                            Anasayfada Ürünler Kısmında Gözüksün:<br />
                                            <asp:CheckBox runat="server" ID="cbIsHome" Checked="False" Text="Evet / Hayır" />
                                        </div>
                                        <div class="form-group">
                                            Anasayfada Uygulama Alanları Kısmında Gözüksün:<br />
                                            <asp:CheckBox runat="server" ID="cbIsHome2" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%-- <div class="form-group">
                                            Anasayfada Araçlarda Gözüksün:<br />
                                            <asp:CheckBox runat="server" ID="cbIsHome2" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%-- <div class="form-group">
                                            Anasayfada Varsayılan Seçili Gelsin:&nbsp;<br />
                                            <asp:CheckBox runat="server" ID="cbIsHomeDefaultSelected" Checked="False" Text="Evet / Hayır" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Seo Açıklama</label>
                                            <asp:TextBox runat="server" ID="txtSeoDescription" CssClass="form-control" MaxLength="300"></asp:TextBox>
                                        </div>--%>
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
</asp:Content>
