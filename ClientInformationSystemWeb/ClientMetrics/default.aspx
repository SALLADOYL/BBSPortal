<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; width: 750px; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

        <div style="width: 100%; text-align: left;">
            <h1>Client Metrics Page</h1>
        </div>
        <table style="width: 100%; padding: 15px;">
            <tr>
                <%-- CLIENT METRICS --%>
                <td colspan="2">
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="Server"
                        TargetControlID="pnlClientMetricSJTR" CollapsedSize="40" ExpandedSize="200"
                        Collapsed="True" ExpandControlID="lblClientMetricSJTR" CollapseControlID="lblClientMetricSJTR"
                        AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                        ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlClientMetricSJTR" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: khaki; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblClientMetricSJTR" runat="server">Client Metric (Service-Job / Tech-Report)</h4>
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
                                                        <asp:TextBox ID="txtSJTRDateFrom" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="ImageButton6" TargetControlID="txtSJTRDateFrom" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Date (To):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSJTRDateTo" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="ImageButton7" TargetControlID="txtSJTRDateTo" Format="dd/MM/yyyy" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnClientMetricSJTR" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves Service-Job and Tech-Report info whose date matches the specified date range.</i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <%-- SERVICES METRIC REPORT --%>
                <td colspan="2">
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
                        TargetControlID="pnlServicesMetric" CollapsedSize="40" ExpandedSize="180"
                        Collapsed="True" ExpandControlID="lblServicesMetric" CollapseControlID="lblServicesMetric"
                        AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                        ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlServicesMetric" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: darkseagreen; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblServicesMetric" runat="server">Metrics for Service Subscription</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>Date (From):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateFromServiceSubs" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="ImageButton4" TargetControlID="txtDateFromServiceSubs" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Date (To):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateToServiceSubs" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="ImageButton5" TargetControlID="txtDateToServiceSubs" Format="dd/MM/yyyy" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnViewServiceSubs" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves the Service subscription information within the specified date range.</i>
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
