<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="ProductShort.aspx.cs" Inherits="KZ.WebUI.Management.ProductShort" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .short ul {
            margin: 0;
        }

            .short ul li {
                list-style: none;
                margin: 0 0 4px 0;
                padding: 5px;
                color: #fff;
                font-weight: bold;
                float: left;
                width: 150px;
                height: 250px;
                margin: 1%;
                margin-bottom: 100px;
                border: 1px solid #ccc;
                text-align: center;
            }

        .short li:hover {
            cursor: move;
        }

        .yeniyer {
            border: 2px dotted #860101;
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
                                <h1>Proje Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Proje Yönetim</a></li>
                                    <li class="active">Proje Sıralama</li>
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
                                    <h4>Proje Sıralama</h4>
                                </div>
                                <div class="card-body">
                                    <div class="default-tab">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <%--                                            <li role="presentation" class="active"><a href="#tab1" aria-controls="home" role="tab" data-toggle="tab" aria-expanded="true"><b>En Çok Satanlar</b></a></li>--%>
                                            
                                            <%--                                            <li role="presentation" class=""><a href="#tab2" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Fırsat Projeleri</b></a></li>--%>
                                            
                                            <li role="presentation" class="active"><a href="#tabCategoryProductOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Kategori Projeleri</b></a></li>

                                            <li role="presentation" class=""><a href="#tabHomeProductOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Anasayfa Projeleri Sıralama</b></a></li>

                                            <%--<li role="presentation" class=""><a href="#tabOtherProductOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Diğer Projeler</b></a></li>--%>
                                        </ul>
                                        <div class="tab-content">
                                            <%--<div role="tabpanel" class="tab-pane active" id="tab1">
                                                <div id="popularProductOrder" class="short">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptPopularList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>">
                                                                    <img src="UploadFiles/Product_Images/Small_<%#Eval("Image") %>" width="150" />
                                                                    <br />
                                                                    <br />
                                                                    <span style="color: #000;"><%# Eval("Title") %></span>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <asp:Literal runat="server" ID="ltlMenu"></asp:Literal>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tab2">
                                                <div id="opportunityProductOrder" class="short">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptOpportunityList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>">
                                                                    <img src="UploadFiles/Product_Images/Small_<%#Eval("Image") %>" width="150" />
                                                                    <br />
                                                                    <br />
                                                                    <span style="color: #000;"><%# Eval("Title") %></span>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>--%>

                                            <div role="tabpanel" class="tab-pane active" id="tabCategoryProductOrder">
                                                <div id="categoryProductOrder" class="short">
                                                    <asp:DropDownList runat="server" ID="ddlMenuList" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuList_OnSelectedIndexChanged" />
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptCategoryProductList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("MenuId") %>">
                                                                    <img src="UploadFiles/Product_Images/Small_<%#Eval("Image") %>" width="100" />
                                                                    <br />
                                                                    <br />
                                                                    <span style="color: #000;"><%# Eval("Title") %></span>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>

                                             <div role="tabpanel" class="tab-pane" id="tabHomeProductOrder">
                                                <div id="homeProductOrder" class="short">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHomeProductList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>">
                                                                    <img src="UploadFiles/Product_Images/Small_<%#Eval("Image") %>" width="100" />
                                                                    <br />
                                                                    <br />
                                                                    <span style="color: #000;"><%# Eval("Title") %></span>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>

                                            <%--<div role="tabpanel" class="tab-pane" id="tabOtherProductOrder">
                                                <div id="otherProductOrder" class="short">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptOtherList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>">
                                                                    <img src="UploadFiles/Product_Images/Small_<%#Eval("Image") %>" width="100" />
                                                                    <br />
                                                                    <br />
                                                                    <span style="color: #000;"><%# Eval("Title") %></span>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
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
                //$("#popularProductOrder ul").sortable({
                //    placeholder: 'yeniyer',
                //    opacity: 0.6,
                //    cursor: 'move',
                //    update: function () {
                //        var order = $(this).sortable("serialize");
                //        $.post("ShortSavePages/ProductPopularSave.aspx", order);
                //    }
                //});

                //$("#opportunityProductOrder ul").sortable({
                //    placeholder: 'yeniyer2',
                //    opacity: 0.6,
                //    cursor: 'move',
                //    update: function () {
                //        var order = $(this).sortable("serialize");
                //        $.post("ShortSavePages/ProductOpportunitySave.aspx", order);
                //    }
                //});

                $("#otherProductOrder ul").sortable({
                    placeholder: 'yeniyer3',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/ProductOtherSave.aspx", order);
                    }
                });

                $("#categoryProductOrder ul").sortable({
                    placeholder: 'yeniyer2',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/ProductCategoryOtherSave.aspx", order);
                    }
                });

                $("#homeProductOrder ul").sortable({
                    placeholder: 'yeniyer22',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/ProductHomeSave.aspx", order);
                    }
                });

            });
        });

    </script>


</asp:Content>
