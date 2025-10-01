<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="SssAdd.aspx.cs" Inherits="KZ.WebUI.Management.SssAdd" %>

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
                                <h1>SSS Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">SSS Yönetim</a></li>
                                    <li class="active">Yeni SSS Ekle</li>
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
                                    <img src="assets/images/menu_icons/question.png" />&nbsp;
                                    <h4>Yeni SSS Ekle</h4>
                                </div>
                                <div class="card-body">
                                    <asp:Panel ID="pnlContent" runat="server" CssClass="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <label>Soru</label>
                                            <asp:TextBox runat="server" ID="txtQuestion" ClientIDMode="Static" CssClass="form-control" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Cevap</label>
                                            <asp:TextBox runat="server" ID="txtAnswer" ClientIDMode="Static" CssClass="form-control" TextMode="MultiLine" Height="150"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <b>Durum:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbIsView" Checked="True" Text="Aktif / Pasif" />
                                        </div>
                                        <div class="form-group">
                                            <b>Anasayfa Göster:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbIsHome" Text="Aktif / Pasif" />
                                        </div>
                                        <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_Click" />
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
