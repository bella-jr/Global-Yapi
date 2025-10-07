<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KZ.WebUI.General_Pages.Contact" %>

<%@ Import Namespace="KZ.Business.Concrete" %>
<%@ Register Src="~/UserControl/ucPageSeo.ascx" TagPrefix="uc1" TagName="ucPageSeo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <uc1:ucPageSeo runat="server" ID="ucPageSeo" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <section class="breadcrumb-area">
        <div class="breadcrumb-area-bg paroller" style="background-image: url(/site_files/images/breadcrumb.jpg);">
        </div>
        <div class="container">
            <div class="row">
                <div class="col-xl-12">
                    <div class="inner-content">
                        <div class="title">
                            <h2>
                                <%= Resources.value.iletisim %>
                            </h2>
                        </div>
                        <div class="breadcrumb-menu">
                            <ul>
                                <li><a href="/<%= Resources.value.url_Folder %>"><%=Resources.value.Anasayfa %></a></li>
                                <li class="active"><%= Resources.value.iletisim %></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="main-contact-form-area">
        <div class="container">
            <div class="row">

                <div class="col-xl-8">
                    <div class="contact-form">
                        <div class="sec-title">
                            <div class="sub-title">
                                <div class="border-left"></div>
                                <h5><%= Resources.value.Bizimle_Iletisime_Gec %></h5>
                            </div>
                            <h2><%= Resources.value.Mesaj_Yollayin %></h2>
                        </div>
                        <div class="default-form2">
                            <div class="row">
                                <div class="col-xl-6">
                                    <div class="form-group">
                                        <div class="input-box">
                                            <asp:TextBox ID="txtNameSurname" runat="server" placeholder="<%$ Resources:value, Adiniz_Soyadiniz %>" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6">
                                    <div class="form-group">
                                        <div class="input-box">
                                            <asp:TextBox ID="txtMail" runat="server" placeholder="<%$ Resources:value, E_Posta %>" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="form-group">
                                        <div class="input-box">
                                            <asp:TextBox ID="txtPhone" runat="server" placeholder="<%$ Resources:value, Telefon %>" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-12">
                                    <div class="form-group">
                                        <div class="input-box">
                                            <asp:TextBox ID="txtMessage" runat="server" placeholder="<%$ Resources:value, Mesajiniz %>" TextMode="MultiLine" ClientIDMode="Static" Height="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="form-group">
                                        <div class="input-box">
                                            <asp:Image ID="imgKod" runat="server" />
                                            <br />
                                            <asp:TextBox runat="server" ID="txtCode" ClientIDMode="Static" placeholder="<%$ Resources:value, Guvenlik_Kodu %>"></asp:TextBox>
                                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="button-box">

                                        <asp:Button ID="btnSend" runat="server" CssClass="btn-one" Text="<%$ Resources:value, Gonder %>" OnClientClick="return contactValidation();" OnClick="btnSend_OnClick" />

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-xl-4">
                    <div class="contact-info-box-style1">
                        <div class="title">
                            <h2><%= Resources.value.Bize_Ulasin %></h2>
                        </div>
                        <ul class="contact-info-1">
                            <li>
                                <div class="icon">
                                    <span class="icon-location"></span>
                                </div>
                                <div class="text">
                                    <h3><%= Resources.value.Adres %>:</h3>
                                    <p>
                                        <%= StaticGeneralSettingManager.GeneralSettingData().Address %>
                                    </p>
                                </div>
                            </li>
                            <li>
                                <div class="icon">
                                    <span class="icon-telephone"></span>
                                </div>
                                <div class="text">
                                    <h3><%= Resources.value.Telefon %>:</h3>
                                    <p>
                                        <a href="+<%= StaticGeneralSettingManager.GeneralSettingData().Phone.Replace(" ","").Replace("(","").Replace(")","").Replace("+","") %>">
                                            <%= StaticGeneralSettingManager.GeneralSettingData().Phone %>
                                        </a>
                                    </p>
                                </div>
                            </li>
                            <li>
                                <div class="icon">
                                    <span class="icon-envelope"></span>
                                </div>
                                <div class="text">
                                    <h3><%= Resources.value.E_Posta %>:</h3>

                                    <p>
                                        <a href="mailto:<%= StaticGeneralSettingManager.GeneralSettingData().Mail %>">
                                            <%= StaticGeneralSettingManager.GeneralSettingData().Mail %>
                                        </a>
                                    </p>
                                </div>
                            </li>
                        </ul>

                    </div>
                </div>

            </div>
        </div>


        <div class="container">
            <div class="google-map-outer-box">
                <div class="google-map" id="contactMap">
                    <%= StaticGeneralSettingManager.GeneralSettingData().Maps %>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="custom" runat="server">
    <script>
        function contactValidation() {
            var isValid = true;
            var mail = document.getElementById('txtMail');
            $('#txtNameSurname, #txtMail, #txtPhone, #txtSubject, #txtPhone, #txtMessage, #txtCode').each(function () {
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

            if (mailControl(mail.value) == false) {
                isValid = false;
                $("#txtMail").css({
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


            if (isValid == false) {
                return false;
            }
            else {
                return true;
            }
        };

        function mailControl(mail) {
            var regex = new RegExp(/^[a-z]{1}[\d\w\.-]+@[\d\w-]{3,}\.[\w]{2,3}(\.\w{2})?$/);
            return regex.test(mail);
        }
    </script>
</asp:Content>
