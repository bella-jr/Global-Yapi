<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPageSeo.ascx.cs" Inherits="KZ.WebUI.UserControl.ucPageSeo" %>

<meta property="og:locale" content="tr_TR" />
<asp:Literal ID="ltlOgTitle" runat="server"></asp:Literal>
<%--<asp:Literal ID="ltlOgImage" runat="server"></asp:Literal>--%>
<asp:Literal ID="ltlOgSiteName" runat="server"></asp:Literal>
<asp:Literal ID="ltlOgDesciprion" runat="server"></asp:Literal>

<meta name="twitter:card" content="summary" />
<asp:Literal ID="ltlTwitter_Title" runat="server"></asp:Literal>
<asp:Literal ID="ltlTwitter_Description" runat="server"></asp:Literal>
<asp:Literal ID="ltlTwitter_Url" runat="server"></asp:Literal>