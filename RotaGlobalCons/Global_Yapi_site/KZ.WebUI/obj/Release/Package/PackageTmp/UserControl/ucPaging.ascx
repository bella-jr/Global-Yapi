<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPaging.ascx.cs" Inherits="KZ.WebUI.UserControl.ucPaging" %>

<div class="clear">
    <asp:Panel ID="pnlToplam" runat="server" CssClass="sayfalamatoplam">
        <asp:Label ID="lblToplam" runat="server" />
    </asp:Panel>
    <asp:Panel ID="pnlSayfalama" runat="server" class="sayfalama" Visible="false">
        <asp:Literal ID="lblSayfalama" runat="server" />
    </asp:Panel>
</div>
