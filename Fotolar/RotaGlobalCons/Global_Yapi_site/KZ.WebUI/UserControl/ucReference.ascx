<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucReference.ascx.cs" Inherits="KZ.WebUI.UserControl.ucReference" %>

<div class="section-full bg-gray">
    <div class="container">

        <div class="section-content p-tb10 owl-btn-vertical-center">
            <div class="owl-carousel home-client-carousel-2">

                <asp:Repeater ID="rptReferenceList" runat="server">
                    <ItemTemplate>
                        <div class="item">
                            <div class="ow-client-logo">
                                <div class="client-logo client-logo-media">
                                    <a href="javascript:void(0);">
                                        <img src="/Management/UploadFiles/Reference_Images/<%# Eval("Image") %>" alt="<%# Eval("Title") %>" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>