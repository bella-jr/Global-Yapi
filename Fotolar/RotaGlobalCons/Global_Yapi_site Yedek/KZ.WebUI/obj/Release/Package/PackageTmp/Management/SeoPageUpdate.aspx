<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="SeoPageUpdate.aspx.cs" Inherits="KZ.WebUI.Management.SeoPageUpdate" %>

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
                                    <li class="active">Sayfa Seo Yönetim</li>
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
                                    <h4>Seo Ayarları</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <label>Sayfa Url</label><br />
                                            <b>
                                                <asp:Literal runat="server" ID="ltlPageUrl"></asp:Literal></b>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="75" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Açıklama</label>
                                            <asp:TextBox runat="server" ID="txtDescription" MaxLength="150" CssClass="form-control" TextMode="MultiLine" Height="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvDescription" ForeColor="#e74c3c" ControlToValidate="txtDescription" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <%-- <div class="form-group">
                                            <label>Anahtar Kelimeler</label>
                                            <asp:TextBox runat="server" ID="txtKeywords" CssClass="form-control" MaxLength="300" data-role="tagsinput" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvKeywords" ForeColor="#e74c3c" ControlToValidate="txtKeywords" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
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
