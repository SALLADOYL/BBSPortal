<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; width:750px;
        border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

            <div style="width: 100%; text-align: left;">
                <h1>Service-Job Metrics Page</h1>
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
                            <h4 id="lblDailyReport" runat="server">Daily Report (Service-Job)</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                        Date (Approval Date):
                                        <asp:TextBox ID="txtDailyApprovalDate" TextMode="Date"  runat="server"  Width="100px"></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtDailyApprovalDate" Format="dd/MM/yyyy" />
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
                                        <i>This will launch a report which retrieves the list of Service-Jobs that matches the Approval Date with the selected date.</i>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
             <tr>
                <%-- QUOTE DATE REPORT --%>
                <td colspan="2">
                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
                                TargetControlID="pnlQuotationDateReport" CollapsedSize="40" ExpandedSize="180"
                                Collapsed="True" ExpandControlID="lblQuotationDateReport" CollapseControlID="lblQuotationDateReport"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlQuotationDateReport" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: cornflowerblue; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblQuotationDateReport" runat="server">Quotation Date Report</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>Quotation Date (From):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtQuoteDateReportFrom" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtQuoteDateReportFrom" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Quotation Date (To):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtQuoteDateReportTo" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton3" TargetControlID="txtQuoteDateReportTo" Format="dd/MM/yyyy" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnQuotationDateReport" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves the list of Service-Jobs that matches the Quotation Date with the specified date range.</i>
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
                            <h4 id="lblStartDateReport" runat="server">Start Date Report</h4>
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
                                        <asp:Button ID="btnStartDateReport" runat="server" Text="View Report" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <i>This will launch a report which retrieves the list of Service-Jobs that  matches the Start Date with the specified date range.</i>
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
                        TargetControlID="pnlEndDateReport" CollapsedSize="40" ExpandedSize="180"
                        Collapsed="True" ExpandControlID="lblEndDateReport" CollapseControlID="lblEndDateReport"
                        AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                        ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlEndDateReport" runat="server" Width="500px">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: khaki; text-align: left; vertical-align: top; padding: 8px;">
                            <h4 id="lblEndDateReport" runat="server">End Date Report</h4>
                            <table style="padding: 5px; ">
                                <tr>
                                    <td style="vertical-align:middle;">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>End Date (From):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEndDateFrom" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="ImageButton6" TargetControlID="txtEndDateFrom" Format="dd/MM/yyyy" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        End Date (To):&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEndDateTo" TextMode="Date" runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="ImageButton7" TargetControlID="txtEndDateTo" Format="dd/MM/yyyy" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:Button ID="btnEndDateReport" runat="server" Text="View Report" />
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
    <br />
</asp:Content>
