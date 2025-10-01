<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BlogDetail.aspx.cs" Inherits="KZ.WebUI.General_Pages.BlogDetail" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fancyapps/ui@4.0/dist/fancybox.css" />

    <meta property="og:locale" content="tr_TR" />
    <asp:Literal ID="ltlOgTitle" runat="server"></asp:Literal>
    <asp:Literal ID="ltlOgImage" runat="server"></asp:Literal>
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
                                <li><a href="/<%= Resources.value.url_Folder %><%=Resources.value.url_Blog %>"><%=Resources.value.Blog %></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="project-info-area p-0">
        <div class="container">
            <div class="row">
                <div class="colx-xl-12">
                    <div class="project-description-box">
                        <h2>
                            <%= ltlTitle.Text %>
                        </h2>
                        <asp:Literal ID="ltlDescription" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="row mt-5">
                <asp:Repeater ID="rptGalleryImageList" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6 col-sm-6 col-12">
                            <a data-fancybox="demo" data-src="/Management/UploadFiles/Gallery_Images/Big_<%# Eval("Image") %>">
                                <img src="/Management/UploadFiles/Gallery_Images/<%# Eval("Image") %>" alt="<%= ltlTitle.Text %>" />
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
