<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default8" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 5px; padding-top:70px; width: 100%">
        <div style="width: 100%; text-align: left;">
            <h1>Service-Job Info Page</h1>
        </div>
    </div>
    <table style="padding:15px;">
        <tr>
            <td colspan="2">
                <%--SEARCH SECTION--%>
                <ajaxtoolkit:collapsiblepanelextender id="cpe" runat="Server"
                    targetcontrolid="pnlSearch" collapsedsize="35" expandedsize="240"
                    collapsed="True" expandcontrolid="lblSearch" collapsecontrolid="lblSearch"
                    autocollapse="False" autoexpand="False" collapsedtext="Show Details..."
                    expandedtext="Hide Details" expanddirection="Vertical" />
                <asp:Panel ID="pnlSearch" runat="server">
                    <div style="padding: 3px; border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray;">
                        <table style="width: 1000px; text-align: justify; vertical-align: text-top">
                            <tr>
                                <td colspan="2">
                                    <label id="lblSearch" runat="server">Service-Job Search</label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: auto; padding: 5px; text-align: left; vertical-align: top">
                                    <h4>Navigation</h4>
                                    <div style="width: 550px;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <label>Client:</label>&nbsp;<asp:DropDownList ID="ddClientNameSearch" runat="server" Width="180px"></asp:DropDownList>&nbsp;<label>Service</label>&nbsp;<asp:DropDownList ID="ddServiceListSearch" runat="server" Width="180px"></asp:DropDownList>

                                                </td>
                                                <td>
                                                    <asp:Button ID="btnClientServiceSearch" runat="server" Text="Search" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>PO Number:</label>&nbsp;<asp:TextBox ID="txtPONumberSearch" runat="server"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:Button ID="btnPONumberSearch" runat="server" Text="Search" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>Quotation Number:</label>&nbsp;<asp:TextBox ID="txtQuotationNumberSearch" runat="server"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuotationNumberSearch" runat="server" Text="Search" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>Quotation&nbsp;Date:</label>&nbsp;
                                                    <asp:TextBox ID="txtQuoteDateFrom" runat="server" ReadOnly="true"></asp:TextBox>&nbsp;
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtQuoteDateFrom" Format="MM/dd/yyyy HH:nn" />
                                        
                                                    &nbsp;<label>to</label>&nbsp;
                                                    <asp:TextBox ID="txtQouteDateTo" runat="server" ReadOnly="true"></asp:TextBox>&nbsp;
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtQouteDateTo" Format="MM/dd/yyyy HH:nn" />
                                        
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuoteDateSearch" runat="server" Text="Search" />

                                                </td>
                                            </tr>
                                        </table>

                                    </div>
                                </td>
                                <td>
                                    <h4>Results</h4>
                                    <div style="width: 500px; height: 150px; overflow-y: scroll;">
                                        <asp:DataGrid runat="server" ID="dgResults" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" CellPadding="4" ForeColor="#333333" AllowSorting="True">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="TSWORKID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="CLIENTNAME" HeaderText="Client" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="SERVICENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PONUMBER" HeaderText="PO #" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="QUOTATIONNUMBER" HeaderText="Quotation #" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="QUOTEDATE" HeaderText="Quote Date" ReadOnly="True"></asp:BoundColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="XX-Small" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:DataGrid>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <%--EXTRA LINE--%>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <%--CIENT-SERVICE SECTION--%>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeClientService" runat="Server"
                    TargetControlID="pnlClientService" CollapsedSize="35" ExpandedSize="300"
                    Collapsed="True" ExpandControlID="lblClientService" CollapseControlID="lblClientService"
                    AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                    ExpandedText="Hide Details" ExpandDirection="Vertical" />
                <asp:Panel ID="pnlClientService" runat="server">
                    <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray; text-align: left; vertical-align: top; padding: 8px;">
                        <table style="text-align: left; width: 410px;">
                            <tr>
                                <td colspan="4">
                                    <label id="lblClientService">Client-Service Information</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Client:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddClientList" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td>
                                    <label>Service:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddServiceList" runat="server" Width="200px" AutoPostBack="True"></asp:DropDownList>
                                </td>
                            <tr>
                                <td>
                                    <label>Customer&nbsp;Code:</label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtClientCode" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    <label>Client Service ID:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCLSSVCID" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Name:</label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtClientName" runat="server" ReadOnly="true" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align:top;">
                                    <label>Address:</label>
                                </td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtClientAddress" TextMode="MultiLine" runat="server" ReadOnly="true" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">
                <%--INPUT SECTION--%>
                <div style="padding-left: 5px; width:530px;">
                        <table style="text-align: left; vertical-align: top;">
                            <tr>
                                <td colspan="2">
                                    <H4>Service-Job Information:</H4>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Service-Job&nbsp;ID:</label></td>
                                <td>
                                    <asp:TextBox ID="txtTSWORKID" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Service-Job&nbsp;No#:</label></td>
                                <td>
                                    <asp:TextBox ID="txtServiceJobNo" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Quotation&nbsp;Number:</label></td>
                                <td>
                                    <asp:TextBox ID="txtQuotationNumber" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>PO&nbsp;No.#/Customer&nbsp;Ref#:</label></td>
                                <td>
                                    <asp:TextBox ID="txtPONumber" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Quotation&nbsp;Date:</label></td>
                                <td>
                                    <asp:TextBox ID="txtQuoteDate" runat="server" ReadOnly="true" ></asp:TextBox>
                                    <asp:ImageButton ID="imgbtn1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />
                                    <ajaxToolkit:CalendarExtender ID="extcal2" runat="server" PopupButtonID="imgbtn1" TargetControlID="txtQuoteDate" Format="MM/dd/yyyy HH:nn" />
                                        
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align:top;">
                                    <label>Deliver&nbsp;To/Service&nbsp;Location:</label></td>
                                <td>
                                    <asp:TextBox TextMode="MultiLine" ID="txtDeliverTo" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Job&nbsp;Created&nbsp;By:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddJobCreatedBy" runat="server" Width="220px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Status:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddWorkStatus" runat="server" Width="220px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Signed&nbsp;By&nbsp;[Client]:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddSignedBy" runat="server" Width="220px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Approved&nbsp;By&nbsp;[Internal]:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddApprovedBy" runat="server" Width="220px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Remarks:</label></td>
                                <td>
                                    <asp:TextBox TextMode="MultiLine" ID="txtRemarks" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <div style="font-size: 9px">
                                                    <asp:Label ID="lblCreatedBy" runat="server">Created By:</asp:Label>&nbsp;<br />
                                                    <asp:Label ID="lblCreatedDt" runat="server">Create Date:</asp:Label>&nbsp;<br />
                                                    <asp:Label ID="lblUpdatedBy" runat="server">Update By:</asp:Label>&nbsp;<br />
                                                    <asp:Label ID="lblUpdateDt" runat="server">Update Date:</asp:Label>&nbsp;
                                                </div>
                                            </td>
                                            <td style="text-align: right">
                                                <div style="text-align: right; width: 100%">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" />&nbsp;
                                                    <asp:Button ID="btnNew" runat="server" Text="New Service-Job" Width="150px" />&nbsp;
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </div>
            </td>
            <td style="text-align: left; vertical-align: top;">
                <%--ADD IN SECTION--%>
                <div style="padding-top: 50px;">
                    <%--ATTACHMENT LIST (QUOTATION)--%>
                    <%--FILE ATTACHMENTS--%>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpeFileAttachments" runat="Server"
                        TargetControlID="pnlFileAttachments" CollapsedSize="35" ExpandedSize="400"
                        Collapsed="True" ExpandControlID="lblFileAttachments" CollapseControlID="lblFileAttachments"
                        AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                        ExpandedText="Hide Details" ExpandDirection="Vertical" />
                    <asp:Panel ID="pnlFileAttachments" runat="server">
                        <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: coral; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                            <label id="lblFileAttachments" runat="server">File Attachments</label>
                            <div style="overflow-y: scroll; width: 380px; height: 220px;">
                                <asp:DataGrid runat="server" ID="dgFiles" AutoGenerateColumns="False" AllowPaging="True" Width="100%"
                                    AllowSorting="True" CellPadding="2" PageSize="10" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" ShowFooter="True">
                                    <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:ButtonColumn Text="View" ButtonType="PushButton" CommandName="Update"></asp:ButtonColumn>
                                        <asp:BoundColumn DataField="Remarks" HeaderText="Attachment"></asp:BoundColumn>
                                        <%--<asp:ButtonColumn Text="Remove"></asp:ButtonColumn>--%>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True"   Font-Size="Smaller"/>
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite"   Font-Size="Smaller"/>
                                </asp:DataGrid>
                            </div>
                            <hr />
                            <asp:Button ID="btnNewFile" runat="server" Text="New Attachment" Width="120px" />&nbsp;
                        </div>
                        <hr />
                    </asp:Panel>

                </div>
            </td>
        </tr>
    </table>
</asp:Content>
