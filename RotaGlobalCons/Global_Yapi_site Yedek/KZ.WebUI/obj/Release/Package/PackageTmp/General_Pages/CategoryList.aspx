<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="KZ.WebUI.General_Pages.CategoryList" EnableViewState="false" %>

<%@ Import Namespace="KZ.Core" %>
<%@ Import Namespace="KZ.WebUI.Tool.Concrete" %>
<%@ Import Namespace="KZ.Business.Concrete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/ui@4.0/dist/fancybox.css" />

    <meta property="og:locale" content="tr_TR" />
    <asp:Literal ID="ltlOgTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltlOgSiteName" runat="server"></asp:Literal>
    <asp:Literal ID="ltlOgDesciprion" runat="server"></asp:Literal>

    <meta name="twitter:card" content="summary" />
    <asp:Literal ID="ltlTwitter_Title" runat="server"></asp:Literal>
    <asp:Literal ID="ltlTwitter_Description" runat="server"></asp:Literal>
    <asp:Literal ID="ltlTwitter_Url" runat="server"></asp:Literal>
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
                                <asp:Literal ID="ltlMenuName" runat="server"></asp:Literal>
                            </h2>
                        </div>
                        <div class="breadcrumb-menu">
                            <ul>
                                <li><a href="/<%= Resources.value.url_Folder %>"><%=Resources.value.Anasayfa %></a></li>
                                <asp:Literal ID="ltlMainMenu" runat="server"></asp:Literal>
                                <li><%=ltlMenuName.Text %></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <section class="service-page">
        <div class="container">
            <div class="sec-title text-center">
                <div class="sub-title">
                    <div class="border-left"></div>
                    <h5><%= Resources.value.Projelerimiz %></h5>
                    <div class="border-right"></div>
                </div>
                <h2>
                    <%= ltlMenuName.Text %>
                </h2>

            </div>
            <div class="row">
                <asp:Repeater ID="rptProductList" runat="server">
                    <ItemTemplate>
                        <div class="col-xl-4 col-lg-6 col-md-6">
                            <div class="single-service-style7">
                                <div class="inner">
                                    <img src="/Management/UploadFiles/Product_Images/Small_<%# Eval("Image") %>" alt="<%# Eval("Title") %>" />
                                </div>
                                <div class="title-holder">
                                    <h3>
                                        <a href="/<%= Resources.value.url_Folder %><%= Resources.value.url_Urun %>/<%# Tools.UrlSeo(Eval("Title").ToString()) %>-<%#Eval("Id") %>" title="<%# Eval("Title") %>">
                                            <%# Eval("Title") %>
                                        </a>
                                    </h3>
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="custom" runat="server">
</asp:Content>
