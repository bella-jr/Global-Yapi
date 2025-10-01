<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="PopupManagement.aspx.cs" Inherits="KZ.WebUI.Management.PopupManagement" %>

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
                                    <h1>Popup Yönetim</h1>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 p-0">
                            <div class="page-header">
                                <div class="page-title">
                                    <ol class="breadcrumb text-right">
                                        <li><a href="#">Genel Ayarlar</a></li>
                                        <li class="active">Popup Yönetim</li>
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
                                        <img src="assets/images/menu_icons/slider.png" />&nbsp;
                                    <h4>Popup Yönetim</h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="basic-form">
                                            <div class="form-group">
                                                <label>Kapak Resmi</label>
                                                <br />
                                                <asp:Literal runat="server" ID="ltlImage"></asp:Literal>
                                                <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" />
                                                <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                                <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpImage"></asp:RegularExpressionValidator>
                                            </div>

                                            <div class="form-group">
                                                <b>Durum:&nbsp;</b><br />
                                                <asp:CheckBox runat="server" ID="cbStatus" Checked="True" Text="Aktif / Pasif" />
                                            </div>
                                            <div class="form-group">
                                                <b>Başlangıç / Bitiş Tarihi Olsun:&nbsp;</b><br />
                                                <asp:CheckBox runat="server" ID="cbDateLimited" Checked="True" Text="Aktif / Pasif" />
                                            </div>
                                            <div class="form-group">
                                                <label>Başlangıç Tarihi</label>
                                                <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label>Bitiş Tarihi</label>
                                                <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            </div>

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
