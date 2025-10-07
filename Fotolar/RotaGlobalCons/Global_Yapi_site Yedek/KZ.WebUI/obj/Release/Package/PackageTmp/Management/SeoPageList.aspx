<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="SeoPageList.aspx.cs" Inherits="KZ.WebUI.Management.SeoPageList" %>
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
                            <div class="card alert table-responsive">
                                <div class="card-header">
                                    <img src="assets/images/menu_icons/article.png" />&nbsp;
                                    <h4>Sayfa Seo Listele</h4>
                                </div>
                                <div class="bootstrap-data-table-panel order-list-item">
                                    <table id="bootstrap-data-table" class="table table-responsive table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Sayfa Url</th>
                                                <th>Düzenle</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptSeoPageList" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><a href="<%#Eval("Url") %>" target="_blank"><i class="fa fa-link"></i>&nbsp;<%#Eval("Url") %></a></td>
                                                        <td>
                                                            <a href="SeoPageUpdate-<%#Eval("Id") %>">
                                                                <img src="assets/images/edit.png" /></a>
                                                        </td>
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomCode" runat="server">
</asp:Content>
