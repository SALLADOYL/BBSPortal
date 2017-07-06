<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default6" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server" style="width: 100%;">
        <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

            <div style="width: 100%; text-align: left;">
                <h1>Technical-Report Page</h1>
            </div>
            <table style="padding: 15px;">
                <tr>
                    <td colspan="2">
                        <%--SEARCH SECTION--%>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpe" runat="Server"
                            TargetControlID="pnlSearch" CollapsedSize="45" ExpandedSize="230"
                            Collapsed="True" ExpandControlID="lblTechRepSearch" CollapseControlID="lblTechRepSearch"
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
                                                                <h4 id="lblTechRepSearch" runat="server">Technical-Request Search</h4>
                                                            </td>
                                                            <td>
                                                                <h4>&nbsp;|&nbsp;</h4>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnPrintTR" runat="server" Text="Print Preview" Width="120px" />
                                                            </td>
                                                        </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: auto; padding: 5px; text-align: left; vertical-align: top">
                                            <label>Navigation</label>
                                            <div style="width: 540px;">
                                                <table>
                                                    <tr>
                                                        <td>Client:&nbsp;<asp:DropDownList ID="ddClientNameSearch" runat="server" Width="180px"></asp:DropDownList>&nbsp;
                                                        Service&nbsp;<asp:DropDownList ID="ddServiceListSearch" runat="server" Width="180px"></asp:DropDownList>

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnClientServiceSearch" runat="server" Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Start&nbsp;Date:&nbsp;
                                                        <asp:TextBox TextMode="Date" ID="txtStartDateFrom" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                                                            <asp:ImageButton ID="imgStartfromCalImage" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgStartfromCalImage"
                                                            TargetControlID="txtStartDateFrom" Format="dd/MM/yyyy" />
                                                            &nbsp;to&nbsp;
                                                        <asp:TextBox TextMode="Date" ID="txtStartDateTo" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>
                                                            <asp:ImageButton ID="imgStartftoCalImage" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgStartftoCalImage"
                                                            TargetControlID="txtStartDateTo" Format="dd/MM/yyyy" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnStartDTSearch" runat="server" Text="Search" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div>
                                                                <table>
                                                                    <tr>
                                                                        <td colspan="3">Completion Date:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox TextMode="Date" ID="txtCompleteDTFrom" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgCompleteDTFrom" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="imgCompleteDTFrom"
                                                                            TargetControlID="txtCompleteDTFrom" Format="dd/MM/yyyy" />
                                                                        </td>
                                                                        <td>&nbsp;to&nbsp;</td>
                                                                        <td>
                                                                            <asp:TextBox TextMode="Date" ID="txtCompleteDTTo" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgCompleteDTTo" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="imgCompleteDTTo"
                                                                            TargetControlID="txtCompleteDTTo" Format="dd/MM/yyyy" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnCompleteDateSearch" runat="server" Text="Search" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Status:&nbsp;<asp:DropDownList ID="ddTRStatusSearchList" runat="server" Width="200px"></asp:DropDownList>

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnStatusSearch" runat="server" Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Team:&nbsp;<asp:DropDownList ID="ddTeamSearchList" runat="server" Width="200px">
                                                            <asp:ListItem>IT</asp:ListItem>
                                                            <asp:ListItem>ELECTRONICS</asp:ListItem>
                                                        </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnTeamSearch" runat="server" Text="Search" />
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
                                                        <asp:BoundColumn DataField="TECHREPID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CLIENTNAME" HeaderText="Client" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SERVICENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TRSTATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PONUMBER" HeaderText="PO #" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TRTEAM" HeaderText="Team" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="STARTDT" HeaderText="Start Date" ReadOnly="True"></asp:BoundColumn>
                                                    </Columns>
                                                    <EditItemStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
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
                            TargetControlID="pnlClientService" CollapsedSize="40" ExpandedSize="120"
                            Collapsed="True" ExpandControlID="lblClientService" CollapseControlID="lblClientService"
                            AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                            ExpandedText="Hide Details" ExpandDirection="Vertical" />
                        <asp:Panel ID="pnlClientService" runat="server">
                            <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray; text-align: left; vertical-align: top; padding: 8px;">
                                <table style="text-align: left; width: 410px;">
                                    <tr>
                                        <td colspan="7">
                                            <h4 id="lblClientService">Client-Service Information</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Client:</td>
                                        <td>
                                            <asp:DropDownList ID="ddClientList" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                        <td>Service:</td>
                                        <td>
                                            <asp:DropDownList ID="ddServiceList" runat="server" Width="200px" AutoPostBack="True"></asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                        <td>PO&nbsp;Number:</td>
                                        <td>
                                            <asp:DropDownList ID="ddPONumber" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>Client&nbsp;Code:</td>
                                        <td>
                                            <asp:TextBox ID="txtClientCode" runat="server" Width="290px" ReadOnly="true"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td style="visibility: hidden;">Client&nbsp;Service&nbsp;ID:</td>
                                        <td style="visibility: hidden;">
                                            <asp:TextBox ID="txtCLSSVCID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox></td>
                                        <td>&nbsp;</td>
                                        <td style="visibility: hidden;">TS Work ID:</td>
                                        <td style="visibility: hidden;">
                                            <asp:TextBox ID="txtTSWorkID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox></td>

                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <%--INPUT SECTION--%>
                        <div id="pnlInput" runat="server" style="padding-left: 5px; width: 550px; padding: 9px; border-style: solid; border-width: medium; border-color: darkblue; border-radius: 8px;">
                            <table style="text-align: left; vertical-align: top;">
                                <tr>
                                    <td colspan="2">
                                        <h4>Technical-Report Information:</h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="visibility: hidden;">Technical&nbsp;Report&nbsp;ID:</td>
                                    <td>
                                        <asp:TextBox ID="txtTRID" runat="server" ReadOnly="True" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Team:</td>
                                    <td>
                                        <asp:DropDownList ID="ddTRTeam" runat="server" Width="90%">
                                            <asp:ListItem>IT</asp:ListItem>
                                            <asp:ListItem>ELECTRONICS</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Assigned&nbsp;To:</td>
                                    <td>
                                        <asp:DropDownList ID="ddPerformedBy" runat="server" Width="90%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Status:</td>
                                    <td>
                                        <asp:DropDownList ID="ddStatus" runat="server" Width="90%"></asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Start&nbsp;Date:</td>
                                    <td>
                                        <asp:TextBox TextMode="Date" ID="txtStartDate" runat="server" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgStartDate" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="imgStartDate"
                                        TargetControlID="txtStartDate" Format="dd/MM/yyyy" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>Completed&nbsp;Date:</td>
                                    <td>
                                        <asp:TextBox TextMode="Date" ID="txtCompleteDate" runat="server" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgCompleteDate" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="imgCompleteDate"
                                        TargetControlID="txtCompleteDate" Format="dd/MM/yyyy" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Search&nbsp;Tags:</td>
                                    <td>
                                        <asp:TextBox ID="txtSearchTags" runat="server" Width="90%"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td style="vertical-align: top;">Issue&nbsp;Cause:</td>
                                    <td>
                                        <asp:TextBox TextMode="MultiLine" ID="txtIssueCause" runat="server"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top;">Resolution&nbsp;Details:</td>
                                    <td>
                                        <asp:TextBox TextMode="MultiLine" ID="txtResolutionDetails" runat="server"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td style="vertical-align: top;">Remarks:</td>
                                    <td>
                                        <asp:TextBox TextMode="MultiLine" ID="txtRemarks" runat="server"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 100%">
                                            <tr>

                                                <td colspan="2" style="text-align: right">
                                                    <div style="text-align: right; width: 100%">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" />&nbsp;
                                                        <asp:Button ID="btnNew" runat="server" Text="New Tech-Report" Width="150px" />&nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
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

                        </div>
                    </td>
                    <td style="text-align: left; vertical-align: top;">
                        <%--ADD IN SECTION--%>
                        <div>
                            <%--SERVICE INFORMATION LIST--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeAffectedDevices" runat="Server"
                                TargetControlID="pnlAffectedDevices" CollapsedSize="40" ExpandedSize="310"
                                Collapsed="True" ExpandControlID="lblAffectedDevices" CollapseControlID="lblAffectedDevices"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlAffectedDevices" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: darkseagreen; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <h4 id="lblAffectedDevices" runat="server">Affected Devices</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 210px;">
                                        <asp:DataGrid runat="server" ID="dgAffectedDevices" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" BackColor="White" BorderColor="#336666" BorderWidth="3px" BorderStyle="Double" GridLines="Horizontal">
                                            <Columns>
                                                <asp:ButtonColumn Text="Open" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="AFFECTEDDEVICEID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ITEMCODE" HeaderText="Item Code" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVICENAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                <asp:ButtonColumn Text="Remove" CommandName="Delete" ButtonType="PushButton"></asp:ButtonColumn>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="White" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" BackColor="#336666" />
                                            <SelectedItemStyle BackColor="#339966" ForeColor="White" Font-Bold="True" />
                                        </asp:DataGrid>
                                    </div>
                                    <asp:Button ID="btnAddAffectedDevice" runat="server" Text="Add a Device" Width="120px" />&nbsp;
                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="mpeAffectedDeviceModal" runat="server"
                                TargetControlID="btnAddAffectedDevice"
                                PopupControlID="pnlAffectedDeviceModal" CancelControlID="btnCancelAddAffectedDeviceModal"
                                BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="pnlAffectedDeviceModal" runat="server" Width="400px" Height="300px" Style="display: none;">
                                <div style="background-color: darkseagreen; padding: 8px;">
                                    <div style="overflow-y: scroll; width: 380px; height: 110px;">
                                        <asp:DataGrid runat="server" ID="dgAddAffectedDeviceModal" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowFooter="True">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Link to TR" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="DEVID" Visible="false" />
                                                <asp:BoundColumn DataField="ITEMCODE" HeaderText="Item Code" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVICETYPE" HeaderText="Type" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVICENAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
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
                                    <asp:Button ID="btnCancelAddAffectedDeviceModal" runat="server" Text="Cancel" />


                                </div>
                            </asp:Panel>

                            <%--FILE ATTACHMENTS--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeFileAttachments" runat="Server"
                                TargetControlID="pnlFileAttachments" CollapsedSize="40" ExpandedSize="340"
                                ExpandControlID="lblFileAttachments" CollapseControlID="lblFileAttachments"
                                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" Collapsed="true" />
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
                                            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
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
