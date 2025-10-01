<%@ Page  Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="BlogShort.aspx.cs" Inherits="KZ.WebUI.Management.BlogShort" %>

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
                width: 250px;
                height: 250px;
                margin: 1%;
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
                                <h1>Blog Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Blog Yönetim</a></li>
                                    <li class="active">Blog Sıralama</li>
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
                                    <img src="assets/images/menu_icons/news.png" />&nbsp;
                                    <h4>Blog Sıralama</h4>
                                </div>
                                <div class="card-body">
                                    <label>İçerik Tipi</label>
                                    <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Blog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <br/>
                                    <div id="mainMenuOrder">
                                        <ul>
                                            <asp:Repeater runat="server" ID="rptBlogList">
                                                <ItemTemplate>
                                                    <li id="order_<%#Eval("Id") %>" style="margin-bottom: 50px;">
                                                        <img src="UploadFiles/Blog_Images/Small_<%#Eval("Image") %>" width="150"  /><br/>
                                                        <span style="color: #000;"><%#Eval("Title") %></span>
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
                $("#mainMenuOrder ul").sortable({
                    placeholder: 'yeniyer',
                    opacity: 0.6,
                    cursor: 'move',
                    update: function () {
                        var order = $(this).sortable("serialize");
                        $.post("ShortSavePages/BlogShortSave.aspx", order);
                    }
                });
            });
        });
    </script>
</asp:Content>
