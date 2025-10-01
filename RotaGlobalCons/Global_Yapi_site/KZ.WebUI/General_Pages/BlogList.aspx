<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BlogList.aspx.cs" Inherits="KZ.WebUI.General_Pages.BlogList" EnableViewState="false" %>

<%@ Import Namespace="KZ.Business.Concrete" %>
<%@ Register Src="~/UserControl/ucPageSeo.ascx" TagPrefix="uc1" TagName="ucPageSeo" %>
<%@ Import Namespace="KZ.WebUI.Tool.Concrete" %>
<%@ Import Namespace="KZ.Core" %>

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
                                <%= Resources.value.Blog %>
                            </h2>
                        </div>
                        <div class="breadcrumb-menu">
                            <ul>
                                <li><a href="/<%= Resources.value.url_Folder %>"><%=Resources.value.Anasayfa %></a></li>
                                <li class="active"><%= Resources.value.Blog %></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="blog-style1-area">
        <div class="container">

            <div class="row">
                <asp:Repeater ID="rptBlogList" runat="server">
                    <ItemTemplate>
                        <div class="col-xl-4">
                            <div class="single-blog-style1 wow fadeInUp" data-wow-delay="00ms" data-wow-duration="1500ms">
                                <div class="img-holder">
                                    <div class="inner">
                                        <img src="/Management/UploadFiles/Blog_Images/Small_<%# Eval("Image") %>" alt="<%# Eval("Title") %>">
                                    </div>
                                </div>
                                <div class="text-holder">
                                    <div class="date-box">
                                        <h3><%# Convert.ToDateTime(Eval("CreationDate")).ToString("dd") %><br>
                                            <span><%# Convert.ToDateTime(Eval("CreationDate")).ToString("MMMM") %></span>
                                        </h3>
                                    </div>
                                    <div class="meta-box">
                                    </div>
                                    <h3 class="blog-title">
                                        <a href="/<%= Resources.value.url_Folder %><%= Resources.value.url_Blog %>/<%# Tools.UrlSeo(Eval("Title").ToString()) %>-<%# Eval("Id") %>" title="<%# Eval("Title") %>">

                                            <%# Eval("Title") %>

                                        </a>
                                    </h3>
                                    <div class="btn-box">
                                        <a href="/<%= Resources.value.url_Folder %><%= Resources.value.url_Blog %>/<%# Tools.UrlSeo(Eval("Title").ToString()) %>-<%# Eval("Id") %>" title="<%# Eval("Title") %>">

                                            <%=Resources.value.Devami %>

                                        </a>
                                    </div>
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
