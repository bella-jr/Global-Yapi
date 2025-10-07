<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="SssList.aspx.cs" Inherits="KZ.WebUI.Management.SssList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="content">
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
                                    <li class="active">SSS Listele</li>
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
                                    <img src="assets/images/menu_icons/question.png" />&nbsp;
                                    <h4>SSS Listele</h4>
                                </div>
                                <div class="bootstrap-data-table-panel order-list-item">
                                    <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                    <br />
                                    <table id="bootstrap-data-table" class="table table-responsive table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Soru</th>
                                                <th>Cevap</th>
                                                <th>Durum</th>
                                                <th>Oluşturulma Tarihi</th>
                                                <th>Düzenle</th>
                                                <th>Sil</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptSssList" runat="server" OnItemCommand="rptSssList_OnItemCommand" OnItemDataBound="rptSssList_OnItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("Question") %></td>
                                                        <td><%#Eval("Answer") %></td>
                                                        <td>
                                                            <asp:HiddenField ID="hfStatus" runat="server" Value='<%#Eval("IsView").ToString() %>'></asp:HiddenField>
                                                            <asp:Button ID="btnActive" runat="server" CommandName="Active" CommandArgument='<%#Eval("Id")%>' Text="Aktif" CssClass="btn btn-success" />
                                                            <asp:Button ID="btnPasive" runat="server" CommandName="Pasive" CommandArgument='<%#Eval("Id")%>' Text="Pasif" CssClass="btn btn-danger" />
                                                        </td>
                                                        <td><%# Convert.ToDateTime(Eval("CreationDate")).ToString("dd.MM.yyyy") %></td>
                                                        <td>
                                                            <a href="SssUpdate-<%#Eval("Id") %>">
                                                                <img src="assets/images/edit.png" /></a>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' runat="server" OnClientClick="return window.confirm('Silmek istediğinize eminmisiniz ?');"><img src="assets/images/delete.png" /></asp:LinkButton>
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
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="CustomCode">
</asp:Content>
