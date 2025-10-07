<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KZ.WebUI.Default" EnableViewState="false" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="KZ.Core" %>
<%@ Import Namespace="KZ.WebUI.Tool.Concrete" %>
<%@ Import Namespace="KZ.Entity.Enums" %>
<%@ Import Namespace="KZ.Business.Concrete" %>
<%@ Register Src="~/UserControl/ucReference.ascx" TagPrefix="uc1" TagName="ucReference" %>


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
    <section class="main-slider main-slider-style1">
        <div class="swiper-container thm-swiper__slider" data-swiper-options='{"slidesPerView": 1, "loop": true,
                "effect": "fade",
                "pagination": {
                    "el": "#main-slider-pagination",
                    "type": "bullets",
                    "clickable": true
                },
                "navigation": {
                    "nextEl": "#main-slider__swiper-button-next",
                    "prevEl": "#main-slider__swiper-button-prev"
                },
                "autoplay": {
                    "delay": 8000
                }}'>
            <div class="swiper-wrapper">
                <asp:Repeater ID="rptSliderList" runat="server">
                    <ItemTemplate>
                        <div class="swiper-slide">
                            <div class="image-layer" style="background-image: url(/Management/UploadFiles/Slider_Images/<%# Eval("Image") %>);">
                            </div>
                            <div class="container">
                                <div class="row sl">
                                    <div class="col-xl-12">
                                        <div class="main-slider-content">
                                            <div class="main-slider-content__inner">
                                                <div class="big-title">
                                                    <h2>
                                                        <%# Eval("Title") %>
                                                        <br>
                                                        <%# Eval("Title2") %>
                                                    </h2>
                                                </div>
                                                <div class="text">
                                                    <p>
                                                        <%# Eval("Title3") %>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="main-slider__nav">
                <div class="swiper-button-prev" id="main-slider__swiper-button-next">
                    <i class="icon-left-arrow left"></i>
                </div>
                <div class="swiper-button-next" id="main-slider__swiper-button-prev">
                    <i class="icon-right-arrow right"></i>
                </div>
            </div>

        </div>
    </section>

    <asp:Literal ID="ltlContent1" runat="server"></asp:Literal>
    <asp:Literal ID="ltlContent2" runat="server"></asp:Literal>

    <section class="project-style1-area">
        <div class="container">
            <div class="row">
                <div class="col-xl-12">
                    <div class="project-style1-area__top">
                        <div class="sec-title">
                            <div class="sub-title">
                                <div class="border-left"></div>
                                <h5><%= Resources.value.Projelerimiz.ToUpper() %></h5>
                            </div>
                            <h2>
                                <%= Resources.value.Yapilan_Projeler %>
                            </h2>
                        </div>
                        <%--<div class="btn-box">
                            <a class="btn-one" href="/<%= Resources.value.url_Folder %><%=Resources.value.url_Projeler %>">
                                <span class="txt">
                                    <%= Resources.value.TumunuGor %>
                                    <i class="icon-right"></i>
                                </span>
                            </a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>

        <div class="auto-container">
            <div class="row">
                <div class="col-xl-12">
                    <div class="owl-carousel owl-theme thm-owl__carousel project-style1-carousel"
                        data-owl-options='{"loop": false, "autoplay": false, "margin": 30, "nav": false, "dots": true, "smartSpeed": 500, "autoplayTimeout": 10000, "navText": ["<span class=\"left icon-right-arrow\"></span>","<span class=\"right icon-right-arrow\"></span>"], "responsive": {"0": {"items": 1}, "768": {"items": 2}, "992": {"items": 3}, "1200": {"items": 4}}}'>

                        <asp:Repeater ID="rptProductList" runat="server">
                            <ItemTemplate>
                                <div class="single-project-item">
                                    <div class="img-holder">
                                        <img src="/Management/UploadFiles/Product_Images/Small_<%# Eval("Image") %>" alt="<%# Eval("Title") %>">
                                        <div class="img-holder-img-bg"></div>
                                        <div class="overlay-title">
                                            <p><%# Eval("TopTitle") %></p>
                                            <h4>
                                                <a href="/<%= Resources.value.url_Folder %><%= Resources.value.url_Urun %>/<%# Tools.UrlSeo(Eval("Title").ToString()) %>-<%#Eval("Id") %>" title="<%# Eval("Title") %>">
                                                    <%# Eval("Title") %>
                                                </a>

                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="testimonials-style1-area">
        <div class="map-layer paroller" style="background-image: url(/site_files/images/shapes/map-1.png);"></div>
        <div class="container">
            <div class="row">
                <div class="col-xl-4">
                    <div class="testimonial-style1-title-box">
                        <div class="sec-title">
                            <div class="sub-title">
                                <div class="border-left"></div>
                                <h5><%= Resources.value.Yorumlar.ToUpper() %></h5>
                            </div>
                            <h2><%= Resources.value.Yorumlar_Alt_Baslik %></h2>
                        </div>
                    </div>
                </div>

                <div class="col-xl-8">
                    <div class="testimonial-style1-content-box">
                        <div class="owl-carousel owl-theme thm-owl__carousel testimonial-style1-carousel owl-nav-style-one"
                            data-owl-options='{"loop": true, "autoplay": true, "margin": 30, "nav": true, "dots": false, "smartSpeed": 500, "autoplayTimeout": 10000, "navText": ["<span class=\"left icon-left-arrow\"></span>","<span class=\"right icon-right-arrow\"></span>"], "responsive": {"0": {"items": 1}, "768": {"items": 2}, "992": {"items": 2}, "1200": {"items": 2}}}'>

                            <asp:Repeater ID="rptCommentList" runat="server">
                                <ItemTemplate>
                                    <div class="single-testimonials-style1">
                                        <div class="single-testimonials-style1__inner">
                                            <div class="quote-box">
                                                <span class="icon-quotation"></span>
                                            </div>
                                            <div class="text-box">
                                                <p>
                                                    <%# Eval("Description") %>
                                                </p>
                                            </div>
                                        </div>
                                        <div class="customer-info">
                                            <div class="img-box">
                                                <img src="/site_files/images/yorum.png" alt="<%# Eval("Name") %> <%# Eval("Surname") %>">
                                            </div>
                                            <div class="title-box">
                                                <h3>
                                                    <%# Eval("Name") %> <%# Eval("Surname") %>
                                                </h3>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <asp:Literal ID="ltlContent3" runat="server"></asp:Literal>

    <section class="blog-style1-area">
        <div class="container">
            <div class="row">
                <div class="col-xl-12">
                    <div class="blog-style1-area__top">
                        <div class="sec-title">
                            <div class="sub-title">
                                <div class="border-left"></div>
                                <h5><%=Resources.value.Blog.ToUpper() %></h5>
                            </div>
                            <h2><%= Resources.value.Yeni_Haberler %></h2>
                        </div>
                    </div>
                </div>
            </div>

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
