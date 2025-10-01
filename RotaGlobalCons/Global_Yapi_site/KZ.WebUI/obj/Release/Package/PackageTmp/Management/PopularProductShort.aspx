<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="PopularProductShort.aspx.cs" Inherits="KZ.WebUI.Management.PopularProductShort" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-body ul {
            margin: 0;
        }

            .card-body ul li {
                list-style: none;
                margin: 0 0 4px 0;
                padding: 5px;
                color: #fff;
                font-weight: bold;
                float: left;
                width: 150px;
                height: 150px;
                margin: 1%;
                margin-bottom: 60px;
            }

        .card-body li:hover {
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
                                <h1>Ürün Sıralama</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Ürün Sıralama</a></li>
                                    <li class="active">Vitrin Ürün Sıralama</li>
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
                                    <h4>Vitrin Ürün Sıralama</h4>
                                </div>
                                <div class="card-body">
                                    <div id="popularProductOrder">
                                        <ul>
                                            <asp:Repeater runat="server" id="rptPopularProductList">
                                                <ItemTemplate>
                                                    <li id="order_<%#Eval("Id") %>">
                                                        <img src="UploadFiles/Product_Images/Thumb_<%#Eval("Image") %>" width="150" height="150" />
                                                        <br/>
                                                        <br/>
                                                        <span style="color: #000;"><%# Eval("Title") %> - <%#Eval("Code") %></span>    
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
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
                $("#popularProductOrder ul").sortable({
                    placeholder: 'yeniyer',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/PopularCourseShortSave.aspx", order);
                    }
                });
            });
        });
    </script>
</asp:Content>
