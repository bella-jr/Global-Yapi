<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CategorySubList.aspx.cs" Inherits="KZ.WebUI.General_Pages.CategorySubList" EnableViewState="false" %>

<%@ Import Namespace="KZ.Core" %>
<%@ Import Namespace="KZ.WebUI.Tool" %>
<%@ Import Namespace="KZ.Entity.Enums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <div class="row">
                <asp:Repeater ID="rptSubCategoryList" runat="server">
                    <ItemTemplate>
                        <div class="col-xl-4 col-lg-6 col-md-6">
                            <div class="single-service-style7">
                                <div class="inner">
                                    <img src="/Management/UploadFiles/Menu_Images/<%# Eval("Image") %>" alt="<%# Eval("Name") %>" />
                                </div>
                                <div class="title-holder">
                                    <h3>
                                        <a href="<%# Convert.ToBoolean(Eval("IsExternal")) ? Eval("Link") : "" %><%# Convert.ToBoolean(Eval("IsExternal")) == false && Convert.ToBoolean(Eval("IsSubMenuListView")) == false && Convert.ToByte(Eval("TypeId")) == (byte)MenuType.Menu ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(Eval("Name").ToString()), Eval("Id")) : "" %><%# Convert.ToBoolean(Eval("IsExternal")) == false && Convert.ToBoolean(Eval("IsSubMenuListView")) == false && Convert.ToByte(Eval("TypeId")) == (byte)MenuType.Kategori ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(Eval("Name").ToString()), Eval("Id")) : "" %><%# Convert.ToBoolean(Eval("IsExternal")) == false && Convert.ToBoolean(Eval("IsSubMenuListView")) ? String.Format("/{0}{1}/{2}/{3}", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(Eval("Name").ToString()), Eval("Id")) : "" %>" title="<%# Eval("Name") %>">

                                            <%# Eval("Name") %>

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
