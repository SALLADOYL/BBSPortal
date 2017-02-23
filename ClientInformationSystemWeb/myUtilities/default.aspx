<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default10" %>

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
                            <asp:Label ID="lblSessionContent" runat="server" ></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td><asp:TextBox ID="txtEncryptval" runat="server" Width="100%"></asp:TextBox></td>
                                    <td><asp:Button ID="btndecrypprocess" runat="server" Text="encrypt" /></td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox></td>
                                    <td><asp:Button ID="Button1" runat="server" Text="decrypt" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtresults" runat="server" ReadOnly="true" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><hr /></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><input type="file" id="fileInput1" runat="server" />
                            <asp:Button ID="btnUpload" runat="server" Text="Upload file" /></td>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtPopupURL" runat="server" Width="100%" TextMode="Url" ></asp:TextBox></td>
                                    <td><asp:Button ID="btnPopupURL" runat="server" Text="Load Popup Window" /></td></td>
                                </tr>
                            </table>
                            
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
