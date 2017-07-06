<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default8" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server" style="width: 100%;">
        <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">
            <div style="width: 100%; text-align: left;">
                <h1>Service-Job Info Page</h1>
            </div>
           <table style="padding: 15px;">
                <tr>
                    <td colspan="2">
                        <%--SEARCH SECTION--%>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeSearch" runat="Server"
                            TargetControlID="pnlSearch" CollapsedSize="45" ExpandedSize="230"
                            Collapsed="True" ExpandControlID="lblSearch" CollapseControlID="lblSearch"
                            AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                            ExpandedText="Hide Details" ExpandDirection="Vertical" />
                        <asp:Panel ID="pnlSearch" runat="server">
                            <div style="padding: 3px; border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray;">
                                <table style="width: 1000px; text-align: justify; vertical-align: text-top">
                                    <tr>
                                        <td colspan="2">
                                            <div style="text-align: justify;">
                                                <table style="padding: 5px;">
                                                        <tr>
                                                            <td>
                                                                <h4 id="lblSearch" runat="server">Service-Job Search</h4>
                                                            </td>
                                                            <td>
                                                                <h4>&nbsp;|&nbsp;</h4>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnPrintSJ" runat="server" Text="Print Preview" Width="120px" />
                                                            </td>
                                                        </tr>
                                                </table>
                                            </div>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: auto; padding: 5px; text-align: left; vertical-align: top">
                                            <label>Navigation</label>
                                            <div style="width: 550px;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Client:&nbsp;<asp:DropDownList ID="ddClientNameSearch" runat="server" Width="180px"></asp:DropDownList>&nbsp;Service:&nbsp;<asp:DropDownList ID="ddServiceListSearch" runat="server" Width="180px"></asp:DropDownList>

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnClientServiceSearch" runat="server" Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Service-Job&nbsp;Number:&nbsp;<asp:TextBox ID="txtServiceJobNumberSearch" runat="server" Width="200px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnServiceJobNumberSearch" runat="server" Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            PO&nbsp;Number:&nbsp;<asp:TextBox ID="txtPONumberSearch" runat="server" Width="200px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnPONumberSearch" runat="server" Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Quotation&nbsp;Number:&nbsp;<asp:TextBox ID="txtQuotationNumberSearch" runat="server" Width="200px"></asp:TextBox>

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnQuotationNumberSearch" runat="server" Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <table>
                                                                    <tr>
                                                                        <td>Quotation&nbsp;Date:&nbsp;</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtQuoteDateFrom" TextMode="Date"  runat="server"  Width="100px"></asp:TextBox>&nbsp;
                                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtQuoteDateFrom" Format="dd/MM/yyyy" />

                                                                        </td>
                                                                        <td>&nbsp;to&nbsp;</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtQouteDateTo" TextMode="Date"  runat="server" Width="100px"></asp:TextBox>&nbsp;
                                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtQouteDateTo" Format="dd/MM/yyyy" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            
                                                    
                                                            
                                                    
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnQuoteDateSearch" runat="server" Text="Search" />

                                                        </td>
                                                    </tr>
                                                </table>

                                            </div>
                                        </td>
                                        <td>
                                            <label>Results</label>
                                            <div style="width: 500px; height: 150px; overflow-y: scroll;">
                                                <asp:DataGrid runat="server" ID="dgResults" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AllowSorting="True">
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                        <asp:BoundColumn DataField="TSWORKID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SERVICEJOBNUMBER" HeaderText="Service-Job #" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PONUMBER" HeaderText="P.O.#" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="QUOTATIONNUMBER" HeaderText="Quotation #" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="QUOTEDATE" HeaderText="Quote Date" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CLIENTNAME" HeaderText="Client" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SERVICENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>
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
                            TargetControlID="pnlClientService" CollapsedSize="40" ExpandedSize="240"
                            Collapsed="True" ExpandControlID="lblClientService" CollapseControlID="lblClientService"
                            AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                            ExpandedText="Hide Details" ExpandDirection="Vertical" />
                        <asp:Panel ID="pnlClientService" runat="server">
                            <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray; text-align: left; vertical-align: top; padding: 8px;">
                                <table style="text-align: left; width: 410px;">
                                    <tr>
                                        <td colspan="4">
                                            <h4 id="lblClientService">Client-Service Information</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Client:</td>
                                        <td>
                                            <asp:DropDownList ID="ddClientList" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="text-align:right;">
                                            Service:&nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddServiceList" runat="server" Width="200px" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <tr>
                                            <td>
                                                Client&nbsp;Code:

                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClientCode" runat="server" ReadOnly="true" Width="150px"></asp:TextBox>
                                            </td>
                                            <td style="visibility:hidden;">
                                                Client&nbsp;Service&nbsp;ID:
                                            </td>
                                            <td style="visibility:hidden;">
                                                <asp:TextBox ID="txtCLSSVCID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    <tr>
                                        <td>
                                            Name:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtClientName" runat="server" ReadOnly="true" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;">
                                            Address:
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
                        <div id="pnlInput" runat="server" style="padding-left: 5px; width: 600px; padding: 9px; border-style: solid; border-width: medium; border-color: darkblue; border-radius: 8px;">
                            <table style="text-align: left; vertical-align: top; padding:5px;">
                                <tr>
                                    <td colspan="2">
                                        <h4>Service-Job Information:</h4>
                                    </td>
                                </tr>
                                <tr style="visibility:hidden;">
                                    <td>
                                        Service-Job&nbsp;ID:</td>
                                    <td>
                                        <asp:TextBox ID="txtTSWORKID" runat="server" ReadOnly="True" Visible="false" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Service-Job&nbsp;No#:</td>
                                    <td>
                                        <asp:TextBox ID="txtServiceJobNo" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Quotation&nbsp;Number:</td>
                                    <td>
                                        <asp:TextBox ID="txtQuotationNumber" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        PO&nbsp;No.#/Customer&nbsp;Ref#:</td>
                                    <td>
                                        <asp:TextBox ID="txtPONumber" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Quotation&nbsp;Date:</td>
                                    <td>
                                        <asp:TextBox ID="txtQuoteDate" runat="server" TextMode="Date"></asp:TextBox>
                                        <asp:ImageButton ID="imgbtn1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />
                                        <ajaxToolkit:CalendarExtender ID="extcal2" runat="server" PopupButtonID="imgbtn1" TargetControlID="txtQuoteDate" Format="dd/MM/yyyy" />

                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top;">
                                        Deliver&nbsp;To/Service&nbsp;Location:</td>
                                    <td>
                                        <asp:TextBox TextMode="MultiLine" ID="txtDeliverTo" runat="server"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Job&nbsp;Created&nbsp;By:</td>
                                    <td>
                                        <asp:DropDownList ID="ddJobCreatedBy" runat="server" Width="220px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Status:</td>
                                    <td>
                                        <asp:DropDownList ID="ddWorkStatus" runat="server" Width="220px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Signed&nbsp;By&nbsp;[Client]:</td>
                                    <td>
                                        <asp:TextBox ID="txtSignedBy" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Approved&nbsp;By&nbsp;[Internal]:</td>
                                    <td>
                                        <asp:DropDownList ID="ddApprovedBy" runat="server" Width="220px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Start&nbsp;Date:</td>
                                    <td>
                                        <asp:TextBox ID="txtSJStartDate" runat="server" TextMode="Date" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />
                                        <ajaxToolkit:CalendarExtender ID="ceStartDate" runat="server" PopupButtonID="ImageButton3" TargetControlID="txtSJStartDate" Format="dd/MM/yyyy" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        End&nbsp;Date:</td>
                                    <td>
                                        <asp:TextBox ID="txtSJEndDate" runat="server" TextMode="Date" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />
                                        <ajaxToolkit:CalendarExtender ID="ceSJEndDate" runat="server" PopupButtonID="ImageButton4" TargetControlID="txtSJEndDate" Format="dd/MM/yyyy" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Remarks:</td>
                                    <td>
                                        <asp:TextBox TextMode="MultiLine" ID="txtRemarks" runat="server"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 100%">
                                            <tr>
                                                
                                                <td style="text-align: right" colspan="2">
                                                    <div style="text-align: right; width: 100%">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" />&nbsp;
                                                    <asp:Button ID="btnNew" runat="server" Text="New Service-Job" Width="150px" />&nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div style="font-size: 9px">
                                                        <asp:Label ID="lblCreatedBy" runat="server">Created By:</asp:Label>&nbsp;<br />
                                                        <asp:Label ID="lblCreatedDt" runat="server">Create Date:</asp:Label>&nbsp;<br />
                                                        <asp:Label ID="lblUpdatedBy" runat="server">Update By:</asp:Label>&nbsp;<br />
                                                        <asp:Label ID="lblUpdateDt" runat="server">Update Date:</asp:Label>&nbsp;
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
                        <div>
                            <%--ATTACHMENT LIST (QUOTATION)--%>
                            <%--FILE ATTACHMENTS--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeFileAttachments" runat="Server"
                                TargetControlID="pnlFileAttachments" CollapsedSize="40" ExpandedSize="340"
                                Collapsed="True" ExpandControlID="lblFileAttachments" CollapseControlID="lblFileAttachments"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlFileAttachments" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: coral; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <h4 id="lblFileAttachments" runat="server">File Attachments</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 210px;">
                                        <asp:DataGrid runat="server" ID="dgFiles" AutoGenerateColumns="False" Width="100%"
                                            AllowSorting="True" CellPadding="2" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal">
                                            <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Download" CommandName="Update" ButtonType="PushButton" />
                                                <asp:BoundColumn DataField="FILEID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="FILEPATH" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="REMARKS" HeaderText="Remarks"></asp:BoundColumn>
                                                <asp:ButtonColumn Text="Remove" CommandName="Delete"></asp:ButtonColumn>
                                            </Columns>
                                            <FooterStyle BackColor="Tan" />
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" Font-Size="Smaller" />
                                        </asp:DataGrid>
                                    </div>
                                    <hr />
                                    <asp:Button ID="btnNewFile" runat="server" Text="New Attachment" Width="120px" />&nbsp;
                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="mpeAttachment" runat="server" TargetControlID="btnNewFile"
                                PopupControlID="pnlAttachmentModal" CancelControlID="btnCancelAttachment"
                                BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="pnlAttachmentModal" runat="server" Width="400px" Height="300px" Style="display: none;">
                                <div style="background-color: coral; padding: 15px;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2">
                                                <h4>Attach File</h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>File ID:</td>
                                            <td>
                                                <asp:TextBox ID="txtFILEID" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>File:</td>
                                            <td>
                                                <input type="file" id="fileInput1" runat="server" /></td>
                                        </tr>
                                        <%--<tr>
                                        <td colspan="2"><hr /></td>
                                    </tr>--%>
                                        <tr>
                                            <td>Remarks:</td>
                                            <td>
                                                <asp:TextBox ID="txtAttachmentRemarks" runat="server" Width="250px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: right;">
                                                <asp:Button ID="btnUploadSaveAttachment" runat="server" Text="Upload/Save Attachment" />
                                                &nbsp;<asp:Button ID="btnCancelAttachment" runat="server" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>

                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
