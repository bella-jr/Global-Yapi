<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReferenceList.aspx.cs" Inherits="KZ.WebUI.General_Pages.ReferenceList" %>

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
                                <%= Resources.value.Referanslar %>
                            </h2>
                        </div>
                        <div class="breadcrumb-menu">
                            <ul>
                                <li><a href="/<%= Resources.value.url_Folder %>"><%=Resources.value.Anasayfa %></a></li>
                                <li class="active"><%= Resources.value.Referanslar %></li>
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
                <asp:Repeater ID="rptReferenceList" runat="server">
                    <ItemTemplate>
                        <div class="col-xl-3 col-lg-3 col-md-3">
                            <div class="single-service-style7">
                                <div class="inner">
                                    <img src="/Management/UploadFiles/Reference_Images/<%# Eval("Image") %>" alt="<%# Eval("Title") %>" />
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
