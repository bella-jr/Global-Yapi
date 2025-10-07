<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="PropertyGroupList.aspx.cs" Inherits="KZ.WebUI.Management.PropertyGroupList" %>

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
                                <h1>Özellik Grup Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Özellik Grup Yönetim</a></li>
                                    <li class="active">Özellik Grup Listele</li>
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
                                    <img src="assets/images/menu_icons/property.png" />&nbsp;
                                    <h4>Özellik Grupları Listele</h4>
                                </div>
                                <div class="bootstrap-data-table-panel order-list-item">
                                    <a href="#" data-toggle="modal" data-target="#addPropertyGroup" class="btn btn-success">Yeni Grup Ekle</a>
                                    <br />
                                    <br />
                                    <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                    <br />
                                    <table id="bootstrap-data-table" class="table table-responsive table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Adı</th>
                                                <th>Düzenle</th>
                                                <th>Sil</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptPropertyGroupList" runat="server" OnItemCommand="rptPropertyGroupList_OnItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Eval("Name") %></td>
                                                        <td>
                                                            <a href="#" onclick="GetData(<%#Eval("Id") %>)" data-toggle="modal" data-target="#updatePropertyGroup">
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
    <div class="modal fade none-border" id="updatePropertyGroup">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title"><strong>Grup Düzenleme</strong></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:HiddenField runat="server" ID="hfId" ClientIDMode="Static" />
                            <label class="control-label">Başlık</label>
                            <asp:TextBox runat="server" ID="txtName" ClientIDMode="Static" CssClass="form-control" MaxLength="50" onkeypress="return isTextNumber(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnUpdateSave" CssClass="btn btn-danger" Text="Kaydet" ValidationGroup="groupUpdate" OnClick="btnUpdateSave_OnClick" OnClientClick="return updateClientFunction();" />
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Vazgeç</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade none-border" id="addPropertyGroup">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title"><strong>Yeni Grup Ekle</strong></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <label class="control-label">Başlık</label>
                            <asp:TextBox runat="server" ID="txtAddName" ClientIDMode="Static" CssClass="form-control" MaxLength="50" onkeypress="return isTextNumber(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnAddSave" CssClass="btn btn-danger" Text="Kaydet" ValidationGroup="groupAdd" OnClick="btnAddSave_OnClick" OnClientClick="return addClientFunction();" />
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Vazgeç</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomCode" runat="server">
    <script type="text/javascript">
        function GetData(id) {
            $(function () {
                $.ajax({
                    type: "POST",
                    url: "PropertyGroupList.aspx/GetGroup",
                    data: '{"groupId":"' + id + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    },
                    error: function (response) {
                        alert(response.d);
                    }
                });
            });
        }
        function OnSuccess(response) {
            var group = response.d;
            $("#hfId").val(group.Id);
            $("#txtName").val(group.Name);
        }
    </script>

    <script>
        function updateClientFunction() {
            var isValid = true;
            $('#txtName').each(function () {
                if ($.trim($(this).val()) == '0' || $.trim($(this).val()) == '') {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red",
                        "background": "#FFCECE"
                    });
                }
                else {
                    $(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });

            if (isValid == false) {
                return false;
            }
            else {
                return true;
            }
        };

        function addClientFunction() {
            var isValid = true;
            $('#txtAddName').each(function () {
                if ($.trim($(this).val()) == '0' || $.trim($(this).val()) == '') {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red",
                        "background": "#FFCECE"
                    });
                }
                else {
                    $(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });

            if (isValid == false) {
                return false;
            }
            else {
                return true;
            }
        };
    </script>

</asp:Content>
