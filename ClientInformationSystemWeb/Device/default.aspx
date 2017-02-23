<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server"  style="width: 100%;">
        <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

            <div style="width: 100%; text-align: left;">
                <h1>Device Maintenance Page</h1>
            </div>
            <table style="padding: 15px;">
                <tr>
                    <td colspan="2">
                        <div>
                            <%--SEARCH SECTION--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeSearch" runat="Server"
                            AutoCollapse="false" AutoExpand="false" Collapsed="true"
                            TargetControlID="pnlSearch" CollapsedSize="40" ExpandedSize="250"
                            ExpandControlID="lblDeviceSearchTool" CollapseControlID="lblDeviceSearchTool" 
                            ExpandDirection="Vertical"  />
                            <asp:Panel ID="pnlSearch" runat="server">
                                <div style="padding: 3px; border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray;">
                                    <table style="width: 900px; text-align: justify; vertical-align: text-top">
                                        <tr>
                                            <td colspan="2">
                                                <h4 id="lblDeviceSearchTool" runat="server">Device Search Tool</h4>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="text-align: justify;">
                                                    <table style="padding:5px;">
                                                        <tr>
                                                            <td style="width: auto; padding: 5px; text-align: left; vertical-align: top">
                                                                <label>Search</label>
                                                                <div style="width: 250px; vertical-align: top; text-align: left;">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                S/N:</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtSNSearch" runat="server"></asp:TextBox></td>
                                                                            <td>&nbsp;<asp:Button ID="btnSearchSN" runat="server" Text="Search" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Name:</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox></td>
                                                                            <td>&nbsp;<asp:Button ID="btnNameSearch" runat="server" Text="Search" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Code:</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtItemCodeSearch" runat="server"></asp:TextBox></td>
                                                                            <td>&nbsp;<asp:Button ID="btnItemCodeSearch" runat="server" Text="Search" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                Installed&nbsp;@&nbsp;Client:<asp:CheckBox ID="chkInstalledatclient" runat="server" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:Button ID="btnClear" runat="server" Text="Clear All" Width="100%" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                            <td style="padding: 5px; width: 100%; vertical-align: top; text-align: left;">
                                                                <label>Results</label>
                                                                <div style="width: 700px; height: 150px; overflow-y: scroll">
                                                                    <asp:DataGrid runat="server" ID="dgResults" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" ShowFooter="True" AllowSorting="True">
                                                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                        <Columns>
                                                                            <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                                            <asp:BoundColumn DataField="DEVID" Visible="false"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="ITEMCODE" HeaderText="Item Code" ReadOnly="True"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="DEVICENAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="DEVICETYPE" HeaderText="Type" ReadOnly="True"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="SERIALNUMBER" HeaderText="S/N" ReadOnly="True"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="NAME" HeaderText="Client Name" ReadOnly="True"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="SERVIENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>

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
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                            
                        </div>
                    </td>
                </tr>
                <tr>
                    <%--EXTRA LINE--%>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <%--INPUT SECTION--%>
                    <td style="vertical-align: top;">
                        <div id="pnlInput" runat="server"  style="padding-left: 5px; width:550px; padding:9px; border-style:solid; border-width:medium; border-color: darkblue; border-radius: 8px;">
                            <table style="text-align: left; vertical-align: top;">
                                <tr>
                                    <td colspan="2">
                                        <H4>Device Information:</H4>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Device&nbsp;ID:</td>
                                    <td>
                                        <asp:TextBox ID="txtDEVID" runat="server" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Item&nbsp;Code:</td>
                                    <td>
                                        <asp:TextBox ID="txtITEMCODE" runat="server" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Device&nbsp;Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtDeviceName" runat="server" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Type:</td>
                                    <td>
                                        <asp:TextBox ID="txtDEVICETYPE" runat="server" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Serial&nbsp;Number:</td>
                                    <td>
                                        <asp:TextBox ID="txtSERIALNUMBER" runat="server" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Specification:</td>
                                    <td>
                                        <asp:TextBox ID="txtDEVICESPECS" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        Status:</td>
                                    <td>
                                        <asp:DropDownList ID="ddStatus" runat="server" Width="250px"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        Manufacture&nbsp;Date:
                                    </td>
                                    <td>
                                        <asp:TextBox TextMode="DateTime" ID="txtMANUFACTUREDATE" runat="server" AutoCompleteType="Disabled" ReadOnly="true" ></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtMANUFACTUREDATE" Format="dd/MM/yyyy" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Receive&nbsp;Date:</td>
                                    <td>
                                        <asp:TextBox TextMode="DateTime" ID="txtRECEIVEDATE" runat="server" AutoCompleteType="Disabled" ReadOnly="true" ></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtRECEIVEDATE" Format="dd/MM/yyyy" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div>
                                            <table style="padding:5px;">
                                                <tr>
                                                    <td>Available:&nbsp;<asp:CheckBox ID="chkIsAvailable" runat="server" />&nbsp;</td>
                                                    <td>IsActive:&nbsp;<asp:CheckBox ID="chkIsActive" runat="server" />&nbsp;</td>
                                                    <td>Purge:&nbsp;<asp:CheckBox ID="chkPurge" runat="server" />&nbsp;</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    
                                </tr>
                                <%--IT DEPT DETAILS--%>
                                <tr>
                                    <td>
                                        IP&nbsp;Address:</td>
                                    <td>
                                        <asp:TextBox ID="txtIPADDRESS" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Brand&nbsp;Type:</td>
                                    <td>
                                        <asp:TextBox ID="txtBRANDTYPE" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Model:</td>
                                    <td>
                                        <asp:TextBox ID="txtModel" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        HostName:</td>
                                    <td>
                                        <asp:TextBox ID="txtHOSTNAME" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Username:</td>
                                    <td>
                                        <asp:TextBox ID="txtUSERNAME" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Password:</td>
                                    <td>
                                        <asp:TextBox ID="txtPASSWORD" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        MAC Address:</td>
                                    <td>
                                        <asp:TextBox ID="txtMAC" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Firmware&nbsp;Version:</td>
                                    <td>
                                        <asp:TextBox ID="txtFIRMWAREVERSION" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Default&nbsp;IP:</td>
                                    <td>
                                        <asp:TextBox ID="txtDEFAULTIPADDRESS" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Stream&nbsp;1&nbsp;Resolution:</td>
                                    <td>
                                        <asp:TextBox ID="txtSTREAM1RESOLUTION" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Stream&nbsp;1&nbsp;FPS:</td>
                                    <td>
                                        <asp:TextBox ID="txtSTREAM1FPS" runat="server" Width="90%" /></td>
                                </tr>
                                <tr>
                                    <td style="vertical-align:top;">
                                        Remarks:</td>
                                    <td>
                                        <asp:TextBox ID="txtREMARKS" runat="server" TextMode="MultiLine"></asp:TextBox></td>
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
                                                    <asp:Button ID="btnNew" runat="server" Text="New Device" Width="150px" />&nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--INPUT RIGHT SIDE--%>
                    <td style="text-align: left; vertical-align: top;">
                        <%--ADD IN SECTION--%>
                        <div>
                            <%--CLIENT SERVICE SECTION--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeClientServices" runat="Server"
                                TargetControlID="pnlServiceInfo" CollapsedSize="40" ExpandedSize="190"
                                ExpandControlID="lblServiceAcquired" CollapseControlID="lblServiceAcquired"
                                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" Collapsed="true" />
                            <asp:Panel ID="pnlServiceInfo" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: cadetblue; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <h4 id="lblServiceAcquired" runat="server" >Client-Services</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 120px;">
                                        <asp:DataGrid runat="server" ID="dgClientServices" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowFooter="True">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundColumn DataField="CLIENTCODE" HeaderText="Client Code" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="CLIENTNAME" HeaderText="Client Name" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="SERVIENAME" HeaderText="Service Name" ReadOnly="True"></asp:BoundColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Smaller" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:DataGrid>
                                    </div>
                                </div>
                            </asp:Panel>


                            <%--TECH REPORT--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeTechReports" runat="Server"
                                TargetControlID="pnlTechreports" CollapsedSize="40" ExpandedSize="340"
                               ExpandControlID="lblTechReports" CollapseControlID="lblTechReports"
                                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" Collapsed="true" />
                            <asp:Panel ID="pnlTechreports" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: coral; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <h4 id="lblTechReports" runat="server">Tech-Report History (Descending)</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 270px;">
                                        <asp:DataGrid runat="server" ID="dgTechReportHistory" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" AllowSorting="True" CellPadding="2" ShowFooter="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="None">
                                            <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                            <Columns>
                                                <asp:ButtonColumn Text="View" ButtonType="PushButton" CommandName="Update"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="TECHREPID" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STARTDT" HeaderText="Date Started" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="TEAM" HeaderText="Team" ReadOnly="True"></asp:BoundColumn>
                                            </Columns>
                                            <FooterStyle BackColor="Tan" />
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                        </asp:DataGrid>
                                    </div>
                                </div>
                            </asp:Panel>

                            <%--DEVICE NOTES--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeDeviceNotes" runat="Server"
                            TargetControlID="pnlDeviceNotes" CollapsedSize="40" ExpandedSize="340"
                            ExpandControlID="lblDeviceNotes" CollapseControlID="lblDeviceNotes" Collapsed="true"
                            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlDeviceNotes" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: darkseagreen; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <h4 id="lblDeviceNotes" runat="server" >Device Notes</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 270px;">
                                        <asp:DataGrid runat="server" ID="dgNotes" AutoGenerateColumns="False" Width="100%"
                                            AllowSorting="True" CellPadding="4" ShowFooter="True" ForeColor="#333333" GridLines="None">
                                            <AlternatingItemStyle BackColor="White" />
                                            <Columns>
                                                <asp:ButtonColumn Text="View" ButtonType="PushButton" CommandName="Update"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="NOTEID" visible="false" ></asp:BoundColumn>
                                                <asp:BoundColumn DataField="NOTEDATE" HeaderText="Date" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="NOTETEXT" HeaderText="Note" ReadOnly="True"></asp:BoundColumn>
                                                <%--<asp:ButtonColumn Text="Remove" ButtonType="PushButton" CommandName="Update"></asp:ButtonColumn>--%>
                                            </Columns>
                                            <EditItemStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="Smaller" ForeColor="White" />
                                            <ItemStyle   Font-Size="X-Small" BackColor="#E3EAEB"/>
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
                                        </asp:DataGrid>
                                    </div>
                                    <asp:Button ID="btnNewNote" runat="server" Text="Add Note" Width="120px" />&nbsp;
                                    
                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="mpeNotes" runat="server" TargetControlID="btnNewNote"
                                PopupControlID="pnlDeviceNoteModal" Drag="true" PopupDragHandleControlID="pnlHndleDeviceNoteModal"
                                BackgroundCssClass="modalBackground" >
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="pnlDeviceNoteModal" runat="server" style="display:none; width:550px; height:300px;">
                                <div style="background-color: darkseagreen; padding:15px;">
                                    <table style="width:100%;">
                                        <tr>
                                            <td colspan="2"><h4 id="pnlHndleDeviceNoteModal" runat="server" >New Device Note</h4></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><hr /></td>
                                        </tr>
                                        <tr>
                                            <td>ID&nbsp;<asp:TextBox ID="txtNoteID" runat="server" ReadOnly="true"></asp:TextBox></td>
                                            <td>Date:&nbsp;<asp:TextBox ID="txtNoteDate" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Note:<br /><asp:TextBox ID="txtNoteText" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><hr /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="btnSaveNote" runat="server" Text="Save Note" Width="120px" />&nbsp;
                                                <asp:Button ID="btnDeleteNote" runat="server" Text="Delete Note" Width="120px" OnClientClick="return confirm('Proceed with Delete?');" />&nbsp;
                                                <asp:Button ID="btnClearNote" runat="server" Text="New Note" Width="120px" />&nbsp;
                                                <asp:Button ID="btnCancelNoteModal" runat="server" Text="Close" Width="120px" />&nbsp;
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
