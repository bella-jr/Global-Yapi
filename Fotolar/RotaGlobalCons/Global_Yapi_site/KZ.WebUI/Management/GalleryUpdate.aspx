<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="GalleryUpdate.aspx.cs" Inherits="KZ.WebUI.Management.GalleryUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.3.5/jquery.fancybox.min.css" />
    <style>
        #mainMenuOrder:hover {
            cursor: move;
        }

        .custom_border {
            border: 1px solid #dadada;
            margin: 20px;
            padding: 25px;
            text-align: center;
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
                                <h1>Galeri Bilgileri Güncelleme</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Galeri Yönetim</a></li>
                                    <li class="active">Galeri Bilgileri Güncelleme</li>
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
                                    <img src="assets/images/menu_icons/gallery.png" />&nbsp; 
                                    <h4>Galeri Bilgileri Güncelleme</h4>
                                </div>
                                <div class="card-body">
                                    <div class="basic-form">
                                        <div class="form-group">
                                            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <label>Başlık</label>
                                            <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="150" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="row m-b-15">
                                            <div class="col-md-2">
                                                <b>Durum:&nbsp;</b><br />
                                                <asp:CheckBox runat="server" ID="cbStatus" Text="Aktif / Pasif" />
                                            </div>
                                        </div>
                                        <%--<div class="row m-b-15">
                                            <div class="col-md-2">
                                                <b>Anasayfa'da Göster:&nbsp;</b><br />
                                                <asp:CheckBox runat="server" ID="cbIsHome" Text="Aktif / Pasif" />
                                            </div>
                                        </div>--%>
                                       
                                        <div class="clearfix"></div>
                                        <div class="form-group">
                                            <label>Yüklenecek Fotoğraflar</label>
                                            <br />
                                            <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" AllowMultiple="True" />
                                            <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                            <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpImage"></asp:RegularExpressionValidator>
                                        </div>
                                        <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg" OnClick="btnSave_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card alert">
                                <div class="card-header">
                                    <img src="assets/images/menu_icons/gallery.png" />&nbsp; 
                                    <h4>Galeri Fotoğrafları</h4>
                                </div>
                                <div class="card-body">
                                    <asp:Button runat="server" ID="btnAllDelete" CssClass="btn btn-danger" Text="Tümünü Sil" OnClick="btnAllDelete_OnClick" OnClientClick="return window.confirm('Tümünü silmek istediğinize eminmisiniz ?');" />
                                    <asp:Button runat="server" ID="btnSelectedAllDelete" CssClass="btn btn-warning" Text="Seçilenlerin Tümünü Sil" OnClick="btnSelectedAllDelete_OnClick" OnClientClick="return window.confirm('Tümünü silmek istediğinize eminmisiniz ?');" />
                                    <br />
                                    <div id="mainMenuOrder">
                                        <asp:Repeater ID="rptGalleryImageList" runat="server" OnItemCommand="rptGalleryImageList_OnItemCommand">
                                            <ItemTemplate>
                                                <div class="col-lg-2 custom_border" id="order_<%#Eval("Id") %>">
                                                    <a data-fancybox="images" href="UploadFiles/Gallery_Images/Big_<%#Eval("Image") %>">
                                                        <img src="UploadFiles/Gallery_Images/<%#Eval("Image") %>" class="img-responsive" /></a>
                                                    <br />
                                                    <br />
                                                    <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' runat="server" OnClientClick="return window.confirm('Silmek istediğinize eminmisiniz ?');" CausesValidation="False"><img src="assets/images/delete.png" /></asp:LinkButton>&nbsp;&nbsp;
                                                    <asp:LinkButton ID="lnkCoverImage" CommandName="CoverImage" CommandArgument='<%#Eval("Id") %>' runat="server" OnClientClick="return window.confirm('Kapak resmi yapmak istediğinize eminmisiniz ?');" CausesValidation="False"><img src="assets/images/cover_image.png" /></asp:LinkButton>&nbsp;&nbsp;
                                                    <input type="checkbox" value='<%#Eval("Id")%>' id='chkDisplayTitle' runat="server" /><b>Seç</b>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="clearfix"></div>
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
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#mainMenuOrder").sortable({
                    placeholder: '',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("GalleryImageShortSave.aspx", order);
                    }
                });
            });
        });

        $('#photo img').click(function () {
            $('#cbSelect').checked = "checked";
        });
    </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.3.5/jquery.fancybox.min.js"></script>
</asp:Content>
