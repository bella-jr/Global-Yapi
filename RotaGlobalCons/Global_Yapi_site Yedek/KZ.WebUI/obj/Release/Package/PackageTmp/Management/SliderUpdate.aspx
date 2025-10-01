<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="SliderUpdate.aspx.cs" Inherits="KZ.WebUI.Management.SliderUpdate" %>

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
                                <h1>Slider Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Slider Yönetim</a></li>
                                    <li class="active">Slider Bilgileri Düzenleme</li>
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
                                    <img src="assets/images/menu_icons/slider.png" />&nbsp;
                                    <h4>Slider Bilgileri Düzenleme</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>

                                        <div class="form-group">
                                            <label>Kapak Resmi</label>
                                            &nbsp;<span style="color: red;">(Width (Genişlik):&nbsp;<%= StaticDataTool.getSliderImageWidth() %>px&nbsp;-&nbsp;Height (Yükseklik):&nbsp;<%= StaticDataTool.getSliderImageHeight() %>px)</span>
                                            <br />
                                            <asp:Literal runat="server" ID="ltlImage"></asp:Literal>
                                            <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" />
                                            <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık 1</label>
                                            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık 2</label>
                                            <asp:TextBox runat="server" ID="txtTitle2" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık 3</label>
                                            <asp:TextBox runat="server" ID="txtTitle3" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                        </div>
                                        <%--<div class="form-group">
                                            <label>Başlık 4</label>
                                            <asp:TextBox runat="server" ID="txtTitle4" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Link</label>
                                            <asp:TextBox runat="server" ID="txtLink" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Button Başlık</label>
                                            <asp:TextBox runat="server" ID="txtButtonTitle" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Link 2</label>
                                            <asp:TextBox runat="server" ID="txtLink2" CssClass="form-control" MaxLength="500"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
                                            <label>Button Başlık 2</label>
                                            <asp:TextBox runat="server" ID="txtButtonTitle2" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="form-group">
    <label>Metin Yönü</label>
    <asp:DropDownList ID="ddlDirectionType" CssClass="form-control" runat="server">
        <asp:ListItem Text="Sol" Value="Left"></asp:ListItem>
        <asp:ListItem Text="Sağ" Value="Right"></asp:ListItem>
    </asp:DropDownList>
</div>--%>
                                        <%--<div class="form-group">
                                            <b>Video Slider:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbIsVideo" Text="Aktif / Pasif" />
                                        </div>--%>
                                        <div class="form-group">
                                            <b>Durum:&nbsp;</b><br />
                                            <asp:CheckBox runat="server" ID="cbStatus" Checked="True" Text="Aktif / Pasif" />
                                        </div>
                                        <%--<div class="form-group">
    <b>Harici Sekmede Aç:&nbsp;</b><br />
    <asp:CheckBox runat="server" ID="cbIsExternal" Text="Evet / Hayıt" />
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
