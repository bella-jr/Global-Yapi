<%@ Page  Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="LoginLogs.aspx.cs" Inherits="KZ.WebUI.Management.LoginLogs" %>

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
                                <h1>İşlem Takip</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">İşlem Takip</a></li>
                                    <li class="active">Giriş Kayıtlarını Listele</li>
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
                                    <img src="assets/images/menu_icons/islem.png" />&nbsp;  
                                    <h4>Giriş Kayıtlarını Listele</h4>
                                </div>
                                <div class="bootstrap-data-table-panel order-list-item">
                                    <table id="bootstrap-data-table" class="table table-responsive table-bordered">
                                        <thead>
                                            <tr>
                                                <th>IP Adresi</th>
                                                <th>İşlem Tarihi</th>
                                                <th>İşlem Yapan Kullanıcı</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptLoginLogs" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("Ip") %></td>
                                                        <td><%# Convert.ToDateTime(Eval("CreationDate")).ToString("dd.MM.yyyy - hh:mm") %></td>
                                                        <td><%#Eval("NameSurname")%></td>
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
