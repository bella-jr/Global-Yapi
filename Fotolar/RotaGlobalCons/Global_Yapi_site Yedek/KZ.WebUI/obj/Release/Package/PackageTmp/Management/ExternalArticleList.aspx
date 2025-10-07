<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="ExternalArticleList.aspx.cs" Inherits="KZ.WebUI.Management.ExternalArticleList" %>

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
                                <h1>Yazı Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Yazı Yönetim</a></li>
                                    <li class="active">Yazı Listele</li>
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
                                    <img src="assets/images/menu_icons/external.png" />&nbsp; 
                                    <h4>Yazı Listele</h4>
                                </div>
                                <div class="bootstrap-data-table-panel order-list-item">
                                    <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                    <br />
                                    <table id="bootstrap-data-table" class="table table-responsive table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Başlık</th>
                                                <th>Link</th>
                                                <th>Durum</th>
                                                <th>Tarih</th>
                                                <th>Düzenle</th>
                                                <th>Sil</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptExternalArticle" runat="server" OnItemCommand="rptExternalArticle_OnItemCommand" OnItemDataBound="rptExternalArticle_OnItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%#Eval("Title") %>
                                                        </td>
                                                        <td><a href="/<%= Resources.value.url_Folder %><%= Resources.value.url_Sayfa %>/<%#Eval("Link") %>" target="_blank">/<%= Resources.value.url_Folder %><%= Resources.value.url_Sayfa %>/<%#Eval("Link") %></a>&nbsp;<i class="fa fa-link"></i>
                                                        </td>
                                                        <td>
                                                            <asp:HiddenField ID="hfStatus" runat="server" Value='<%#Eval("IsStatus").ToString() %>'></asp:HiddenField>
                                                            <asp:Button ID="btnActive" runat="server" CommandName="Active" CommandArgument='<%#Eval("Id")%>' Text="Aktif" CssClass="btn btn-success" />
                                                            <asp:Button ID="btnPasive" runat="server" CommandName="Pasive" CommandArgument='<%#Eval("Id")%>' Text="Pasif" CssClass="btn btn-danger" />
                                                        </td>
                                                        <td>
                                                            <%# Convert.ToDateTime(Eval("CreationDate")).ToString("dd.MM.yyyy") %>
                                                        </td>
                                                        <td>
                                                            <a href="ExternalArticleUpdate-<%#Eval("Id") %>">
                                                                <img src="assets/images/edit.png" />
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' runat="server" OnClientClick="return window.confirm('Silmek istediğinize emin misiniz ?');"><img src="assets/images/delete.png"/></asp:LinkButton>
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
