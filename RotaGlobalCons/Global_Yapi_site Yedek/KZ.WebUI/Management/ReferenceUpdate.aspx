<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="ReferenceUpdate.aspx.cs" Inherits="KZ.WebUI.Management.ReferenceUpdate" %>

<%@ Import Namespace="KZ.WebUI.Tool" %>

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
                                <h1>Referans Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Referans Yönetim</a></li>
                                    <li class="active">Referans Bilgileri Düzenleme</li>
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
                                    <img src="assets/images/menu_icons/reference.png" />&nbsp;
                                    <h4>Referans Bilgileri Düzenleme</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <label>Kapak Resmi</label>
                                            &nbsp;<span style="color: red;">(Width (Genişlik):&nbsp;<%= StaticDataTool.getReferenceImageWidth() %>px&nbsp;-&nbsp;Height (Yükseklik):&nbsp;<%= StaticDataTool.getReferenceImageHeight() %>px)</span>
                                            <br />
                                            <asp:Literal runat="server" ID="ltlImage"></asp:Literal>
                                            <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" />
                                            <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                            <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpImage"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="250"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Tip</label>
                                            <asp:DropDownList ID="ddlTypeList" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="1" Text="Referans"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Bayilik"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>--%>
                                        <div class="form-group">
                                            <b>Durum:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" Text="Aktif / Pasif" />
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
