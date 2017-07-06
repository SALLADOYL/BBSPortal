<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; width: 750px; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

        <div style="width: 100%; text-align: left;">
            <h1>Technical-Report Metrics Page</h1>
        </div>
        <table style="width: 100%; padding: 15px;">
            <tr>
                <%-- DAILY REPORT --%>
                <td colspan="2">
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDailyReport" runat="Server"
                                TargetControlID="pnlDailyReport" CollapsedSize="40" ExpandedSize="160"
                                Collapsed="True" ExpandControlID="lblDailyReport" CollapseControlID="lblDailyReport"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlDailyReport" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: coral; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblDailyReport" runat="server">Daily Metric (Technical-Report)</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                        Date (Start Date):
                                        <asp:TextBox ID="txtDailyStartDate" TextMode="Date"  runat="server"  Width="100px"></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtDailyStartDate" Format="dd/MM/yyyy" />
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnDailyReport" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves the list of Tech-Reports that matches the selected Start Date.</i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <%-- START DATE REPORT --%>
                <td colspan="2">
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server"
                        TargetControlID="pnlStartDateReport" CollapsedSize="40" ExpandedSize="180"
                        Collapsed="True" ExpandControlID="lblStartDateReport" CollapseControlID="lblStartDateReport"
                        AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                        ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlStartDateReport" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: darkseagreen; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblStartDateReport" runat="server">Date Range Report (Start Date)</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>Start Date (From):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStartDateFrom" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="ImageButton4" TargetControlID="txtStartDateFrom" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Start Date (To):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStartDateTo" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="ImageButton5" TargetControlID="txtStartDateTo" Format="dd/MM/yyyy" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnRangeDateReport" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves the list of Technical-Report within the specified date range.</i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <%-- END DATE REPORT --%>
                <td colspan="2">
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="Server"
                        TargetControlID="pnlClientServiceStartDate" CollapsedSize="40" ExpandedSize="180"
                        Collapsed="True" ExpandControlID="lblClientServiceStartDate" CollapseControlID="lblClientServiceStartDate"
                        AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                        ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlClientServiceStartDate" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: khaki; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblClientServiceStartDate" runat="server">Client-Service-Date Report</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        Client-Service:&nbsp;
                                                        <asp:DropDownList id="ddClSvc" runat="server" Width="230px"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Date (From):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateFrom" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="ImageButton6" TargetControlID="txtDateFrom" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Date (To):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateTo" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="ImageButton7" TargetControlID="txtDateTo" Format="dd/MM/yyyy" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnClSvcDateReport" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves the list of Service-Jobs that  matches the End Date with the specified date range.</i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
