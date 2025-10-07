<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="ProductUpdate.aspx.cs" Inherits="KZ.WebUI.Management.ProductUpdate" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.4.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/jquery.multiselect.css" rel="stylesheet" />
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

        .select_button {
            margin-bottom: 10px;
            width: 40px;
            height: 35px;
        }

        select[multiple], select[size] {
            max-height: 180px;
            min-height: 180px;
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
                                <h1>Yeni Proje Ekle</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Proje Yönetim</a></li>
                                    <li class="active">Proje Bilgileri Güncelleme</li>
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
                                    <img src="assets/images/menu_icons/product.png" />&nbsp; 
                                    <h4>Proje Bilgileri</h4>
                                </div>
                                <div class="card-body">

                                    <div class="default-tab">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li role="presentation" class="active"><a href="#tab1" aria-controls="home" role="tab" data-toggle="tab" aria-expanded="true"><b>Genel Bilgiler</b></a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane active" id="tab1">
                                                <div class="basic-form">
                                                    <div class="form-group">
                                                        <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                                    </div>
                                                    <%--<div class="form-group">
                                                        <label>Proje Kodu</label>
                                                        <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" MaxLength="50" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                                    </div>--%>
                                                    <div class="form-group">
                                                        <label>Üst Başlık</label>
                                                        <asp:TextBox runat="server" ID="txtTopTitle" ClientIDMode="Static" CssClass="form-control" MaxLength="150" onkeypress="return isTextNumber(event);" onkeyup="setSeoTitle(this.value);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvTopTitle" ForeColor="#e74c3c" ControlToValidate="txtTopTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Başlık</label>
                                                        <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" MaxLength="150" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvTitle" ForeColor="#e74c3c" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>
                                                    <%--<div class="form-group">
                                                        <label>Referans</label>
                                                        <asp:DropDownList runat="server" ID="ddlReferenceList" CssClass="form-control" />
                                                    </div>--%>
                                                    <%--<div class="form-group">
                                                        <label>Fiyat</label>
                                                        <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" onkeypress="return isPrice(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvPrice" ForeColor="#e74c3c" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>--%>
                                                    <%--<div class="form-group">
                                                        <label>Havale Fiyatı <b>(0 değer olması durumunda sitede gözükmeyecektir.)</b></label>
                                                        <asp:TextBox runat="server" ID="txtHavalePrice" CssClass="form-control" onkeypress="return isPrice(event);" Text="0"></asp:TextBox>
                                                    </div>--%>
                                                    <%--<div class="form-group">
                                                        <label>Eski Fiyat <b>(0 değer olması durumunda sitede gözükmeyecektir.)</b></label>
                                                        <asp:TextBox runat="server" ID="txtOldPrice" CssClass="form-control" onkeypress="return isPrice(event);" Text="0"></asp:TextBox>
                                                    </div>--%>
                                                    <%--<div class="form-group">
                                                        <label>İndirim</label>
                                                        <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" onkeypress="return isPrice(event);" Text="0"></asp:TextBox>
                                                    </div>--%>
                                                    <%--<div class="form-group">
                                                        <label>Minimum Sipariş Adeti</label>
                                                        <asp:TextBox runat="server" ID="txtStartQuantity" CssClass="form-control" onkeypress="return isNumber(event);" Text="1"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvStartQuantity" ForeColor="#e74c3c" ControlToValidate="txtStartQuantity" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>--%>
                                                    <div class="form-group">
                                                        <label>Proje Kategorileri</label>
                                                        <asp:ListBox runat="server" ID="lstCategories" CssClass="form-control" SelectionMode="Multiple" ClientIDMode="Static"></asp:ListBox>
                                                    </div>
                                                    <div class="row m-b-15">
                                                        <div class="col-md-2">
                                                            <b>Durum:&nbsp;</b><br />
                                                            <asp:CheckBox runat="server" ID="cbStatus" Text="Aktif / Pasif" />
                                                        </div>
                                                        <div class="col-md-2">
                                                            <b>Ana Sayfada Göster:&nbsp;</b><br />
                                                            <asp:CheckBox runat="server" ID="cbIsHome" Text="Aktif / Pasif" />
                                                        </div>
                                                        <%--<div class="col-md-2">
                                                            <b>Diğer Projeler Kısmında Göster:&nbsp;</b><br />
                                                            <asp:CheckBox runat="server" ID="cbIsPopular" Text="Aktif / Pasif" />
                                                        </div>--%>
                                                        <%--<div class="col-md-2">
        <b>Yeni Proje:&nbsp;</b><br />
        <asp:CheckBox runat="server" ID="cbIsNew" Text="Evet / Hayır" />
    </div>
    <div class="col-md-2">
        <b>Tükendi :&nbsp;</b><br />
        <asp:CheckBox runat="server" ID="cbIsStock" Text="Evet / Hayır" />
    </div>--%>
                                                        <%-- <div class="col-md-2">
        <b>Yerli Üretim:&nbsp;</b><br />
        <asp:CheckBox runat="server" ID="cbIsMadeInTurkey" Text="Evet / Hayır" />
    </div>
    <div class="col-md-2">
        <b>Yakında:&nbsp;</b><br />
        <asp:CheckBox runat="server" ID="cbIsSoon" Text="Evet / Hayır" />
    </div>--%>
                                                    </div>
                                                    <%--  <div class="row m-b-15">
                                                        <div class="col-md-12">
                                                            <b>Diğer Projeler Kısmında Göster:&nbsp;</b><br />
                                                            <asp:CheckBox runat="server" ID="cbIsPopular" Text="Aktif / Pasif" />
                                                        </div>
                                                    </div>--%>
                                                    <%-- <div class="row m-b-15">
    <div class="col-md-2">
        <b>İndirimli Proje :&nbsp;</b><br />
        <asp:CheckBox runat="server" ID="cbIsDiscount" Text="Evet / Hayır" />
    </div>
</div>--%>


                                                    <div class="form-group">
                                                        <label>Açıklama</label>
                                                        <CKEditor:CKEditorControl ID="ckeDescription1" runat="server" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Açıklama 2</label>
                                                        <CKEditor:CKEditorControl ID="ckeDescription2" runat="server" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Seo Başlık</label>
                                                        <asp:TextBox runat="server" ID="txtSeoTitle" ClientIDMode="Static" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="rfvSeoTitle" ForeColor="#e74c3c" ControlToValidate="txtSeoTitle" Display="Dynamic" ErrorMessage="Lütfen gerekli alanı doldurunuz."></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Seo Açıklama</label>
                                                        <asp:TextBox runat="server" ID="txtSeoDescription" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Seo Anahtar Kelime</label>
                                                        <asp:TextBox runat="server" ID="txtSeoKeyword" CssClass="form-control" MaxLength="300" onkeypress="return isTextNumber(event);" data-role="tagsinput"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card alert">
                                <div class="card-header">
                                    <img src="assets/images/menu_icons/property.png" />&nbsp; 
                                    <h4>Proje Özellikleri</h4>
                                </div>
                                <asp:UpdatePanel runat="server" ID="upProductProperties">
                                    <ContentTemplate>
                                        <div class="card-body">
                                            <div class="form-group">
                                                <label>Grup</label>
                                                <asp:DropDownList runat="server" ID="ddlPropertyGroup" CssClass="form-control" OnSelectedIndexChanged="ddlPropertyGroup_OnSelectedIndexChanged" AutoPostBack="True" />
                                            </div>
                                            <div class="clearfix"></div>
                                            <br />
                                            <asp:Repeater runat="server" ID="rptPropertyList">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div class="col-md-2" style="padding-top: 10px;"><b><%# Eval("Name") %>:</b></div>
                                                        <div class="col-md-4">
                                                            <asp:TextBox runat="server" ID="txtPropertyValue" CssClass="form-control" onkeypress="return isTextNumber(event)"></asp:TextBox>
                                                            <asp:HiddenField runat="server" ID="hfPropertyId" Value='<%# Eval("Id") %>' />
                                                        </div>
                                                    </div>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Panel runat="server" ID="pnlProperties"></asp:Panel>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="col-lg-12">
                            <div class="card alert">
                                <div class="card-header">
                                    <img src="assets/images/menu_icons/filter.png" />&nbsp; 
                                    <h4>Tab Filtre Özellikleri</h4>
                                </div>

                                <div class="card-body">
                                    <asp:UpdatePanel runat="server" ID="upTabFilter">
                                        <ContentTemplate>
                                            <div class="col-lg-5">
                                                <asp:ListBox runat="server" ID="lstTabFilter" SelectionMode="Multiple" CssClass="form-control" ClientIDMode="Static"></asp:ListBox>
                                            </div>
                                            <div class="col-lg-2 text-center">
                                                <br />
                                                <br />
                                                <asp:Button runat="server" ID="btnMoveRight" Text=">" CssClass="btn btn-default select_button" OnClick="MoveRight" CausesValidation="False" /><br />
                                                <br />
                                                <asp:Button runat="server" ID="btnMoveLeft" Text="<" CssClass="btn btn-default select_button" OnClick="MoveLeft" CausesValidation="False" />
                                            </div>

                                            <div class="col-lg-5">
                                                <asp:ListBox runat="server" ID="lstSelectedTabFilter" SelectionMode="Multiple" CssClass="form-control" ClientIDMode="Static"></asp:ListBox>
                                            </div>
                                            <div class="clearfix"></div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card alert">
                                <div class="card-header">
                                    <img src="assets/images/menu_icons/gallery.png" />&nbsp; 
                                    <h4>Proje Fotoğrafları</h4>
                                </div>
                                <div class="card-body">
                                    <div class="form-group">
                                        <label>Yüklenecek Fotoğraflar</label>
                                        <br />
                                        <asp:FileUpload ID="flpImage" runat="server" CssClass="form-control" AllowMultiple="True" />
                                        <asp:Label ID="lblImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                                        <asp:RegularExpressionValidator ID="revImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpImage"></asp:RegularExpressionValidator>
                                    </div>
                                    <asp:Button runat="server" ID="btnProductPhotoUpload" Text="Yükle" CssClass="btn btn-success" OnClick="btnProductPhotoUpload_OnClick" />
                                    <asp:Button runat="server" ID="btnAllDelete" CssClass="btn btn-danger" Text="Tümünü Sil" OnClick="btnAllDelete_OnClick" OnClientClick="return window.confirm('Tümünü silmek istediğinize eminmisiniz ?');" />
                                    <asp:Button runat="server" ID="btnSelectedAllDelete" CssClass="btn btn-warning" Text="Seçilenlerin Tümünü Sil" OnClick="btnSelectedAllDelete_OnClick" OnClientClick="return window.confirm('Tümünü silmek istediğinize eminmisiniz ?');" />
                                    <br />
                                    <br />
                                    <div id="mainMenuOrder">
                                        <asp:Repeater ID="rptProductImageList" runat="server" OnItemCommand="rptProductImageList_OnItemCommand">
                                            <ItemTemplate>
                                                <div class="col-lg-2 custom_border" id="order_<%#Eval("Id") %>">
                                                    <a data-fancybox="images" href="UploadFiles/Product_Images/Big_<%#Eval("Image") %>">
                                                        <img src="UploadFiles/Product_Images/Small_<%#Eval("Image") %>" class="img-responsive" /></a>
                                                    <br />
                                                    <br />
                                                    <asp:LinkButton ID="lnkDelete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' runat="server" OnClientClick="return window.confirm('Silmek istediğinize eminmisiniz ?');" CausesValidation="False"><img src="assets/images/delete.png" /></asp:LinkButton>&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkCoverImage" CommandName="CoverImage" CommandArgument='<%#Eval("Id") %>' runat="server" CausesValidation="False"><img src="assets/images/cover_image.png" /></asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkCoverImage2" CommandName="CoverImage2" CommandArgument='<%#Eval("Id") %>' runat="server" CausesValidation="False"><img src="assets/images/two_cover_image.png" /></asp:LinkButton>&nbsp;&nbsp;
                                                    <input type="checkbox" value='<%#Eval("Id")%>' id='chkDisplayTitle' runat="server" /><b>Seç</b>
                                                    <br />
                                                    <br />
                                                    <%# Eval("ProductImage").ToString() == Eval("Image").ToString() ? "<b>Varsayılan Kapak Resmi</b><br/>" : "" %>
                                                    <%# Eval("ProductImage2").ToString() == Eval("Image").ToString() ? "<b>2. Varsayılan Kapak Resmi</b>" : "" %>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button runat="server" ID="btnSave" Text="Kaydet" CssClass="btn btn-success btn-lg pull-left mr15" OnClick="btnSave_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfProductId" ClientIDMode="Static" />
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
                        $.post("ShortSavePages/ProductImageShortSave.aspx", order);
                    }
                });
            });

            var productId = $('#hfProductId').val();

            GetAllProductSize(productId);
        });
    </script>
    <script src="assets/js/jquery.multiselect.js"></script>
    <script>
        $(function () {
            $('#lstCategories').multiselect({
                columns: 1,
                placeholder: 'Kategoriler',
                search: true,
                searchOptions: {
                    'default': 'Kategori Ara'
                },
                selectAll: true
            });
        });
    </script>
    <script src="assets/js/tableSearch.js"></script>
    <script src="assets/js/data/productSize.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.3.5/jquery.fancybox.min.js"></script>
</asp:Content>
