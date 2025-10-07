<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="HomePageContentUpdate.aspx.cs" Inherits="KZ.WebUI.Management.HomePageContentUpdate" %>

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
                                <h1>Anasayfa İçerik Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Anasayfa İçerik Yönetim</a></li>
                                    <li class="active">Anasayfa İçerik Bilgileri Düzenleme</li>
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
                                    <h4>Anasayfa İçerik Bilgileri Düzenleme</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <label>İçerik Alanı 1</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription1" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>İçerik Alanı 2</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription2" runat="server" />
                                        </div>
                                        <div class="form-group">
                                            <label>İçerik Alanı 3</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription3" runat="server" />
                                        </div>
                                        <%--<div class="form-group">
                                            <label>İçerik Alanı 4</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription4" runat="server" />
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>İçerik Alanı 5</label>
                                            <CKEditor:CKEditorControl ID="ckeDescription5" runat="server" />
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
