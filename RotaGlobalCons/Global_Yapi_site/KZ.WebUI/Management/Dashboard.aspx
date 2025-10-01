<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="KZ.WebUI.Management.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .max_height_scrool {
            max-height: 400px;
            overflow-y: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="content-wrap">
        <div class="main">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-8 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <h1>Dashboard</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Dashboard</a></li>
                                    <li class="active">Home</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="main-content">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="card">
                                <div class="stat-widget-two">
                                    <div class="stat-content">
                                        <div class="stat-text">Toplam Yazı</div>
                                        <div class="stat-digit">
                                            <asp:Literal runat="server" ID="ltlTotalArticleCount"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="progress">
                                        <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="85" aria-valuemin="0" aria-valuemax="100" style="width: 100%;"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="card">
                                <div class="stat-widget-two">
                                    <div class="stat-content">
                                        <div class="stat-text">Toplam Yönetici</div>
                                        <div class="stat-digit">
                                            <asp:Literal runat="server" ID="ltlTotalAdmin"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="progress">
                                        <div class="progress-bar progress-bar-primary" role="progressbar" aria-valuenow="78" aria-valuemin="0" aria-valuemax="100" style="width: 100%;"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="col-lg-12">
                            <div class="card alert max_height_scrool">
                                <div class="card-header">
                                    <h4>Son Eklenen Yazı</h4>
                                </div>
                                <table class="table table-responsive table-hover">
                                    <thead>
                                        <tr>
                                            <th>Resim</th>
                                            <th>Başlık</th>
                                            <th>Tarih</th>
                                            <th>Düzenle</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptLastProductList" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <img src="UploadFiles/Product_Images/Thumb_<%#Eval("Image") %>" width="50" /></td>
                                                    <td><%#Eval("Title") %></td>
                                                    <td><%# Convert.ToDateTime(Eval("CreationDate")).ToString("dd.MM.yyyy") %></td>
                                                    <td>
                                                        <a href="ProductUpdate-<%#Eval("Id") %>">
                                                            <img src="assets/images/edit.png" /></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>--%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card alert max_height_scrool">
                                <div class="card-header">
                                    <h4>Son Giriş Kayıtları</h4>
                                </div>
                                <table class="table table-responsive table-hover">
                                    <thead>
                                        <tr>
                                            <th>IP Adresi</th>
                                            <th>Giriş Tarih-Saat</th>
                                            <th>Giriş Yapan Kullanıcı</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptLoginLogs" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("Ip") %></td>
                                                    <td><%# Convert.ToDateTime(Eval("CreationDate")).ToString("dd.MM.yyyy - hh:mm") %></td>
                                                    <td><%#Eval("NameSurname") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
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
