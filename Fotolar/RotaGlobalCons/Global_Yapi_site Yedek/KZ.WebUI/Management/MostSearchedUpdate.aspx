<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="MostSearchedUpdate.aspx.cs" Inherits="KZ.WebUI.Management.MostSearchedUpdate" %>

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
                                <h1>Çok Arananlar Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Çok Arananlar Yönetim</a></li>
                                    <li class="active">Çok Arananlar Bilgileri Düzenleme</li>
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
                                    <img src="assets/images/menu_icons/search.png" />&nbsp;
                                    <h4>Çok Arananlar Bilgileri Düzenleme</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtTitle" ClientIDMode="Static" CssClass="form-control" MaxLength="150"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Link</label>
                                            <asp:TextBox runat="server" ID="txtLink" ClientIDMode="Static" CssClass="form-control" MaxLength="150"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvLink" ForeColor="#e74c3c" ControlToValidate="txtLink" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>--%>

                                        <div class="form-group">
                                            <b>Durum:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbIsView" Text="Aktif / Pasif" />
                                        </div>
                                        <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_Click" />
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
