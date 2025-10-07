<%@ Page Language="C#" MasterPageFile="~/Management/MP.Master" AutoEventWireup="true" CodeBehind="PropertyList.aspx.cs" Inherits="KZ.WebUI.Management.PropertyList" %>

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
                                <h1>Özellik Yönetim</h1>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 p-0">
                        <div class="page-header">
                            <div class="page-title">
                                <ol class="breadcrumb text-right">
                                    <li><a href="#">Özellik Yönetim</a></li>
                                    <li class="active">Özellik Listele</li>
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
                                    <h4>Özellik Listele</h4>
                                </div>
                                <div class="bootstrap-data-table-panel order-list-item">
                                    <a href="#" data-toggle="modal" data-target="#addProperty" class="btn btn-success">Yeni Özellik Ekle</a>
                                    <br />
                                    <br />
                                    <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
                                    <br />
                                    <table id="bootstrap-data-table" class="table table-responsive table-bordered">
                                        <thead>
                                            <tr>
                                                <%--<th>İkon</th>--%>
                                                <th>Grup Adı</th>
                                                <th>Özellik Adı</th>
                                                <th>Düzenle</th>
                                                <th>Sil</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptPropertyList" runat="server" OnItemCommand="rptPropertyList_OnItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <%--<td>
                                                            <%# Eval("Icon") %>
                                                        </td>--%>
                                                        <td>
                                                            <label class="label label-warning"><%#Eval("PropertyGroupName") %></label></td>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <a href="#" onclick="GetData(<%#Eval("Id") %>)" data-toggle="modal" data-target="#updateProperty">
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
    <div class="modal fade none-border" id="updateProperty">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title"><strong>Özellik Düzenleme</strong></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:HiddenField ID="hfId" runat="server" ClientIDMode="Static" />

                            <label class="control-label">Başlık</label>
                            <asp:TextBox ID="txtUpdateName" runat="server" CssClass="form-control" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <%-- <div class="row m-t-20">
                        <div class="col-md-12">
                            <label class="control-label">İkon (ör: fa fa-clock-o)</label>
                            <br />
                            <asp:TextBox ID="txtUpdateIcon" runat="server" CssClass="form-control" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                            <a href="https://fontawesome.com/v4.7/icons/" target="_blank"><b>Ikon Seç</b></a>
                        </div>
                    </div>--%>

                    <%--<div class="row">
                        <div class="col-md-12">
                            <span style="color: red;">(Width (Genişlik):&nbsp;<%= StaticDataTool.getPropertyIconWidth() %>px&nbsp;-&nbsp;Height (Yükseklik):&nbsp;<%= StaticDataTool.getPropertyIconHeight() %>px)</span>
                            <br />
                            <asp:FileUpload ID="flpUpdateImage" runat="server" CssClass="form-control" />
                            <asp:Label ID="lblUpdateImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                            <asp:RegularExpressionValidator ID="revUpdateImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpUpdateImage" ValidationGroup="propertyUpdate"></asp:RegularExpressionValidator>
                        </div>
                    </div>--%>
                    <br />
                    <br />
                    <div class="row m-t-20">
                        <div class="col-md-12">
                            <label class="control-label">Grup</label>
                            <asp:DropDownList runat="server" ID="ddlUpdate_ProperyGroup" CssClass="form-control" ClientIDMode="Static" />
                            <asp:RequiredFieldValidator runat="server" ID="rfvUpdate_PropertyGroup" ForeColor="#e74c3c" ControlToValidate="ddlUpdate_ProperyGroup" InitialValue="0" Display="Dynamic" ErrorMessage="Lütfen seçim yapınız." ValidationGroup="propertyUpdate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnUpdateSave" CssClass="btn btn-danger" Text="Kaydet" ValidationGroup="propertyUpdate" OnClick="btnUpdateSave_OnClick" />
                    <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Vazgeç</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade none-border" id="addProperty">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title"><strong>Yeni Özellik Ekle</strong></h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <label class="control-label">Başlık</label>
                            <asp:TextBox ID="txtAddName" runat="server" CssClass="form-control" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <%-- <div class="row m-t-20">
                        <div class="col-md-12">
                            <label class="control-label">İkon (ör: fa fa-clock-o)</label>
                            <br />
                            <asp:TextBox ID="txtAddIcon" runat="server" CssClass="form-control" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                            <a href="https://fontawesome.com/v4.7/icons/" target="_blank"><b>Ikon Seç</b></a>
                        </div>
                    </div>--%>

                    <%--<div class="row">
                        <div class="col-md-12">
                            <span style="color: red;">(Width (Genişlik):&nbsp;<%= StaticDataTool.getPropertyIconWidth() %>px&nbsp;-&nbsp;Height (Yükseklik):&nbsp;<%= StaticDataTool.getPropertyIconHeight() %>px)</span>
                            <br />
                            <asp:FileUpload ID="flpAddImage" runat="server" CssClass="form-control" />
                            <asp:Label ID="lblAddImageError" runat="server" ForeColor="#e74c3c" Visible="False"></asp:Label>
                            <asp:RegularExpressionValidator ID="revAddImage" runat="server" ErrorMessage="Dosya tipi desteklenmemektedir. Sadece jpg ve png uzantılı dosyaları yükleyebilirsiniz." ForeColor="#e74c3c" Display="Dynamic" ValidationExpression="^.+\.((jpg)|(jpeg)|(JPG)|(JPEG)|(png)|(PNG))$" ControlToValidate="flpAddImage" ValidationGroup="propertyAdd"></asp:RegularExpressionValidator>
                        </div>
                    </div>--%>
                    <div class="row m-t-20">
                        <div class="col-md-12">
                            <label class="control-label">Grup</label>
                            <asp:DropDownList runat="server" ID="ddlAdd_PropertyGroup" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ID="rfvAdd_PropertyGroup" ForeColor="#e74c3c" ControlToValidate="ddlAdd_PropertyGroup" InitialValue="0" Display="Dynamic" ErrorMessage="Lütfen seçim yapınız." ValidationGroup="propertyAdd"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnAddSave" CssClass="btn btn-danger" Text="Kaydet" ValidationGroup="propertyAdd" OnClick="btnAddSave_OnClick" />
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
                    url: "PropertyList.aspx/GetProperty",
                    data: '{"propertyId":"' + id + '"}',
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
            var property = response.d;
            $("#hfId").val(property.Id);
            $("#txtUpdateName").val(property.Name);
            //$("#txtUpdateIcon").val(property.Name);
            $("#ddlUpdate_ProperyGroup").val(property.PropertyGroupId);
        }
    </script>
</asp:Content>
