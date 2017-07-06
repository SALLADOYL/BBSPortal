<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default10" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MY WEB UTILITIES - SESSION - ENCRYPTION</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <div id="pnlSession" runat="server">
                            <asp:Label ID="lblSessionContent" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtEncryptval" runat="server" Width="100%"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btndecrypprocess" runat="server" Text="encrypt" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="decrypt" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtresults" runat="server" ReadOnly="true" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <input type="file" id="fileInput1" runat="server" />
                                        <asp:Button ID="btnUpload" runat="server" Text="Upload file" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtPopupURL" runat="server" Width="100%" TextMode="Url"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnPopupURL" runat="server" Text="Load Popup Window" />
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                    </td>
                    </td>
                </tr>
            </table>

        </div>
        </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:TextBox ID="txtssrspath" runat="server" Text="http://10.1.1.18/ReportServer/?/Client+Information+System/Technical Reports/Technical-Report+(Single)&paramTRID=1&rc:Parameters=Collapsed"></asp:TextBox>
            <asp:Button ID="btnRedirSSRS" runat="server" Text="Link to SSRS report" />
            <asp:Button ID="btnProgramRSViewer" runat="server" Text="recode ssrs viewer" />
            <rsweb:ReportViewer Visible="false"  ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="834px"  ShowCredentialPrompts="false">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
