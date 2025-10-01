<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="MenuShort.aspx.cs" Inherits="KZ.WebUI.Management.MenuShort" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tab-content ul {
            margin: 0;
            width: 300px;
        }

            .tab-content ul li {
                list-style: none;
                margin: 0 0 4px 0;
                padding: 5px;
                background-color: #7b7b7b;
                color: #fff;
                font-weight: bold;
            }

        .tab-content li:hover {
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
                                <h1>Menü Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Menü Yönetim</a></li>
                                    <li class="active">Menü Sıralama</li>
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
                                    <img src="assets/images/menu_icons/menu.png" />&nbsp;
                                    <h4>Menü Sıralama</h4>
                                </div>
                                <div class="card-body">
                                    <div class="default-tab">
                                        <ul class="nav nav-tabs" role="tablist">

                                            <li role="presentation" class="active"><a href="#tabSubMenuOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Alt Menü Sıralama</b></a></li>

                                            <li role="presentation" class=""><a href="#tabHeaderMenuOrder" aria-controls="home" role="tab" data-toggle="tab" aria-expanded="true"><b>Üst Menüleri Sıralama</b></a></li>

                                            <li role="presentation" class=""><a href="#tabFooterMenuOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Alt Kısım Menülerini Sıralama</b></a></li>

                                            <%--<li role="presentation" class=""><a href="#tabHomeMenuOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Anasayfa Ürünler Sıralama</b></a></li>--%>

                                            <%--<li role="presentation" class=""><a href="#tabHomeMenuOrder2" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Anasayfa Uygulama Alanları Sıralama</b></a></li>--%>

                                            <%--<li role="presentation" class=""><a href="#tabHeaderMenuOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Anasayfa Araçlar Menü Sıralama</b></a></li>


                                            <li role="presentation" class=""><a href="#tab5" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Üst Sol Menü Sıralama</b></a></li>

                                            <li role="presentation" class=""><a href="#tab6" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Üst Sağ Menü Sıralama</b></a></li>--%>

                                            <%--<li role="presentation" class=""><a href="#tabHeaderMenuOrder" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Üst Kısım Açılır Menü Sıralama</b></a></li>
                                            <li role="presentation" class=""><a href="#tab5" aria-controls="profile" role="tab" data-toggle="tab" aria-expanded="false"><b>Listeleme Sol Menü Sıralama</b></a></li>--%>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane active" id="tabSubMenuOrder">
                                                <div id="subMenuOrder">
                                                    <asp:DropDownList runat="server" ID="ddlMenuList" CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuList_OnSelectedIndexChanged" />
                                                    <br />
                                                    <br />
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptSubMenuList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div role="tabpanel" class="tab-pane " id="tabHeaderMenuOrder">
                                                <div id="headerMenuOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHeaderMenuList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tabFooterMenuOrder">
                                                <div id="footerMenuOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptFooterList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                            <%--<div role="tabpanel" class="tab-pane" id="tabHomeMenuOrder">
                                                <div id="homeCategoryOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHomeCategoryList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>--%>

                                            <%--<div role="tabpanel" class="tab-pane" id="tabHomeMenuOrder2">
                                                <div id="homeCategoryOrder2">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHomeCategoryList2">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>--%>

                                            <%--<div role="tabpanel" class="tab-pane" id="tabHeaderMenuOrder">
                                                <div id="homeCategoryOrder2">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHomeCategoryList2">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>

                                            <div role="tabpanel" class="tab-pane" id="tab5">
                                                <div id="leftMenuOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHeaderMenuListLeft">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>

                                            <div role="tabpanel" class="tab-pane" id="tab6">
                                                <div id="rightMenuOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptHeaderMenuListRight">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>--%>

                                            <%--<div role="tabpanel" class="tab-pane" id="tabHeaderMenuOrder">
                                                <div id="accordionOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptAccordionList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div role="tabpanel" class="tab-pane" id="tab5">
                                                <div id="sidebarOrder">
                                                    <ul>
                                                        <asp:Repeater runat="server" ID="rptSidebarList">
                                                            <ItemTemplate>
                                                                <li id="order_<%#Eval("Id") %>"><i class="fa fa-angle-right"></i>&nbsp;<%#Eval("Name") %></li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                </div>
                                            </div>--%>
                                        </div>
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
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#headerMenuOrder ul").sortable({
                    placeholder: 'yeniyer',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/MenuShortSave.aspx", order);
                    }
                });

                $("#footerMenuOrder ul").sortable({
                    placeholder: 'yeniyer2',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/FooterMenuShortSave.aspx", order);
                    }
                });


                $("#homeCategoryOrder ul").sortable({
                    placeholder: 'yeniyer3',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/HomeCategoryShortSave.aspx", order);
                    }
                });

                $("#homeCategoryOrder2 ul").sortable({
                    placeholder: 'yeniyer3',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/HomeCategoryShortSave2.aspx", order);
                    }
                });

                $("#homeCategoryOrder2 ul").sortable({
                    placeholder: 'yeniyer4',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/HomeCategoryShortSave2.aspx", order);
                    }
                });

                $("#accordionOrder ul").sortable({
                    placeholder: 'yeniyer4',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/AccordionCategoryShortSave.aspx", order);
                    }
                });

                $("#sidebarOrder ul").sortable({
                    placeholder: 'yeniyer5',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/SidebarCategoryShortSave.aspx", order);
                    }
                });

                $("#subMenuOrder ul").sortable({
                    placeholder: 'yeniyer6',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/MenuShortSave.aspx", order);
                    }
                });


                $("#leftMenuOrder ul").sortable({
                    placeholder: 'yeniyer5',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/MenuShortSaveLeft.aspx", order);
                    }
                });

                $("#rightMenuOrder ul").sortable({
                    placeholder: 'yeniyer5',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/MenuShortSaveRight.aspx", order);
                    }
                });

            });
        });
    </script>
</asp:Content>
