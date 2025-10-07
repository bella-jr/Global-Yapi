<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormSuccess.aspx.cs" Inherits="KZ.WebUI.General_Pages.FormSuccess" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <%= Resources.value.Mesaj_Bilgilendirme %>
                            </h2>
                        </div>
                        <div class="breadcrumb-menu">
                            <ul>
                                <li><a href="/<%= Resources.value.url_Folder %>"><%=Resources.value.Anasayfa %></a></li>
                                <li class="active"><%= Resources.value.Mesaj_Bilgilendirme %></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="about-style1-area">
        <div class="container">
            <div class="row">
                <div class="col-12 col-lg-12 text-center">
                    <img src="/site_files/images/success.png" alt="<%= Resources.value.Mesaj_Bilgilendirme %>" />
                    <br />
                    <br />
                    <h2><%= Resources.value.Mesaj_Bilgilendirme %></h2>
                    <div class="text"><%= Resources.value.formBasariliMesaj %></div>
                    <br />
                    <a href="/<%= Resources.value.url_Folder %>" title="<%= Resources.value.Anasayfa_Don %>" class="btn btn-success">
                        <%= Resources.value.Anasayfa_Don %>
                    </a>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="custom" runat="server">
</asp:Content>
