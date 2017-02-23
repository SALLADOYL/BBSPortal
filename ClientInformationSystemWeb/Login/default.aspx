<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteModal.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
        <h2>BBS IT Sign-on</h2><hr />
        <div style="margin-left:auto; margin-right:auto; width:270px; height:auto; border-style:inset; border-radius:15px; padding:10px;">
            <table style="margin-left:auto; margin-right:auto;">
                <tr>
                    <td>Username:</td>
                    <td style="text-align:right "><asp:TextBox runat="server" ID="txtUsername"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        Password:
                    </td>
                    <td style="text-align:right "><asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox></td>
                </tr>
                <tr><td colspan="2" style="text-align:right"><asp:Button runat="server" Text="Login" ID="bnLogin"  Width="100px"/> </td></tr>
            </table>
        </div>
        <hr />
    </div>
</asp:Content>
