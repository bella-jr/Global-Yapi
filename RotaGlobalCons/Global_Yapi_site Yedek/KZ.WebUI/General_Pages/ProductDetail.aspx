<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="KZ.WebUI.General_Pages.ProductDetail" EnableViewState="false" %>

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
                                <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
                            </h2>
                        </div>
                        <div class="breadcrumb-menu">
                            <ul>
                                <li><a href="/<%= Resources.value.url_Folder %>"><%=Resources.value.Anasayfa %></a></li>

                                <li><%=ltlTitle.Text %></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="project-info-area">
        <div class="container">
            <div class="row">
                <div class="col-xl-7">
                    <div class="project-info-img-box">
                        <asp:HiddenField ID="hfImage" runat="server" />
                        <img src="/Management/UploadFiles/Product_Images/Big_<%= hfImage.Value %>" alt="<%= ltlTitle.Text %>" />
                    </div>
                </div>
                <div class="col-xl-5">
                    <div class="project-info-box" style="height: 390px;">
                        <ul>
                            <asp:Repeater ID="rptPropertyList" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <span><%# Eval("PropertyName") %>:</span>
                                        <%# Eval("Value") %>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="colx-xl-12">
                    <div class="project-description-box">
                        <h2>
                            <%=ltlTitle.Text %>
                        </h2>
                        <br />
                        <asp:Literal ID="ltlDescription" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <section class="project-details-style1-area">
        <div class="container">
            <div class="row">

                <asp:Repeater ID="rptProductImageList" runat="server">
                    <ItemTemplate>
                        <div class="col-xl-4 col-md-6 col-sm-12 mb-4">
                            <a data-fancybox="demo" data-src="/Management/UploadFiles/Product_Images/Big_<%# Eval("Image") %>">
                                <img src="/Management/UploadFiles/Product_Images/Small_<%# Eval("Image") %>" alt="<%= ltlTitle.Text %>" />
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="custom" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/@fancyapps/ui@4.0/dist/fancybox.umd.js"></script>
</asp:Content>
