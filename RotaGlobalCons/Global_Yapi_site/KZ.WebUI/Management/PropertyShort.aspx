<%@ Page  Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="PropertyShort.aspx.cs" Inherits="KZ.WebUI.Management.PropertyShort" %>

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
                                <h1>Özellik Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Özellik Yönetim</a></li>
                                    <li class="active">Özellik Sıralama</li>
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
                                    <img src="assets/images/menu_icons/property.png" />&nbsp;
                                    <h4>Özellik Sıralama</h4>
                                </div>
                                <div class="card-body">
                                    <div class="default-tab">
                                        <div class="tab-content">
                                            <div class="form-group">
                                                <label>Grup</label>
                                                <asp:DropDownList runat="server" ID="ddlPropertyGroup" CssClass="form-control" OnSelectedIndexChanged="ddlPropertyGroup_OnSelectedIndexChanged" AutoPostBack="True" />
                                            </div>
                                            <div role="tabpanel" class="tab-pane active" id="tab1">
                                                <div id="mainMenuOrder">
                                                    <ul>
                                                        <asp:Literal runat="server" ID="ltlProperty"></asp:Literal>
                                                    </ul>
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
                        $.post("ShortSavePages/PropertyShortSave.aspx", order);
                    }
                });
            });
        });
    </script>
</asp:Content>
