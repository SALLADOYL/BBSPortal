<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server" style="width: 100%;">
        <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

            <div style="width: 100%; text-align: left;">
                <h1>Role/Access&nbsp;Management&nbsp;Page</h1>
            </div>
            <table style="padding: 15px;">
                <tr>
                    <td colspan="2">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray; text-align: left; vertical-align: top; padding: 8px;">
                            <table style="text-align: left; width: 810px;">
                                <tr>
                                    <td colspan="2">Role:&nbsp;<asp:DropDownList ID="ddRoleList" runat="server" Width="300px"></asp:DropDownList>
                                        &nbsp;<asp:Button ID="btnView" runat="server" Text="View Role" Width="120px" />
                                    </td>
                                </tr>
                                <tr>
                                    <%-- ROLE INFO --%>
                                    <td style="vertical-align:top;">
                                        <div style="padding:6px;">
                                            <table style="text-align: left; vertical-align: top; ">
                                                <tr>
                                                    <td colspan="2">
                                                        <h4>Role Information:</h4>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align:top;">Role&nbsp;Name:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtRoleID" runat="server" ReadOnly="true"  Visible="false" ></asp:TextBox>
                                                        <asp:TextBox ID="txtRoleName" runat="server" Width="300px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align:top;">Remarks:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <%-- ENROLLED USER LIST --%>
                                    <td>
                                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: darkseagreen; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <h4 id="lblUsersinRole" runat="server">Enrolled Users</h4>
                                                    </td>
                                                    <td style="text-align:right;">
                                                        <asp:Button ID="btnAddUser" runat="server" Text="Add a User" Width="120px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="overflow-y: scroll; width: 380px; height: 210px;">
                                                            <asp:DataGrid runat="server" ID="dgRoleUsers" AutoGenerateColumns="False" Width="100%"
                                                                CellPadding="4" BackColor="White" BorderColor="#336666" BorderWidth="3px" BorderStyle="Double" GridLines="Horizontal">
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="PRFLOBJACCID" Visible="false"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="PROFILEID" Visible="false"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="EMPLOYEECODE" HeaderText="Employee Code"></asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="NAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                                    <asp:ButtonColumn Text="Remove" CommandName="Delete" ButtonType="PushButton"></asp:ButtonColumn>
                                                                </Columns>
                                                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                                                <ItemStyle BackColor="White" ForeColor="#333333" Font-Size="X-Small" />
                                                                <PagerStyle ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" BackColor="#336666" />
                                                                <SelectedItemStyle BackColor="#339966" ForeColor="White" Font-Bold="True" />
                                                            </asp:DataGrid>
                                                        </div>

                                                        <%-- ADD USER MODAL --%>
                                                        <ajaxToolkit:ModalPopupExtender ID="mpeAddUserModal" runat="server"
                                                            TargetControlID="btnAddUser"
                                                            PopupControlID="pnlAddUserModal" CancelControlID="btnCancelAddUser"
                                                            BackgroundCssClass="modalBackground">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <asp:Panel ID="pnlAddUserModal" runat="server" Width="400px" Height="300px" Style="display: none;">
                                                            <div style="background-color: darkseagreen; padding: 8px;">
                                                                <div style="overflow-y: scroll; width: 380px; height: 110px;">
                                                                    <asp:DataGrid runat="server" ID="dgAddUserModal" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowFooter="True">
                                                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                        <Columns>
                                                                            <asp:ButtonColumn Text="Add to Role" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                                            <asp:BoundColumn DataField="PROFILEID" Visible="false"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="EMPLOYEECODE" HeaderText="Employee Code"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="NAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                                            <%--<asp:ButtonColumn Text="Unsubscribe"></asp:ButtonColumn>--%>
                                                                        </Columns>
                                                                        <EditItemStyle BackColor="#999999" />
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    </asp:DataGrid>
                                                                </div>
                                                                <hr />
                                                                <asp:Button ID="btnCancelAddUser" runat="server" Text="Cancel" />


                                                            </div>
                                                        </asp:Panel>

                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

    </div>
</asp:Content>
