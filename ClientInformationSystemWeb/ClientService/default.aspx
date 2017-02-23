<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default7" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server"  style="width: 100%;">
        <div style="padding-left: 5px; padding-top:70px; border-style:solid; border-color:darkblue; border-radius:3px; padding: 4px; background-color:ActiveBorder;">
            <div style="width: 100%; text-align: left;">
                <h1>Client-Service Page</h1>
            </div>

            <table style="padding: 15px;">
                <tr>
                    <%--Client Info Section--%>
                    <td colspan="2">
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpe" runat="Server"
                            TargetControlID="pnlClientInfo" CollapsedSize="35" ExpandedSize="210"
                            Collapsed="false" ExpandControlID="lblClientInfoCollapse" CollapseControlID="lblClientInfoCollapse"
                            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
                        <asp:Panel ID="pnlClientInfo" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <div style="padding: 3px; border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray;">
                                            <table style="width: 100%; text-align: left; vertical-align: top; padding: 3px;">
                                                <tr>
                                                    <td colspan="2">
                                                        <h4 id="lblClientInfoCollapse" runat="server">Client Information Section</h4>
                                                    </td>
                                                    <td colspan="2" style="text-align: right; vertical-align: top;">
                                                        <asp:Button ID="btnReturnClient" runat="server" Text="Return to Client" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Client&nbsp;ID:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtClientID" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>

                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td>Client&nbsp;Code:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtClientCode" runat="server" ReadOnly="true" Width="200px"></asp:TextBox></td>

                                                    <td>Client&nbsp;Name:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtClientName" runat="server" ReadOnly="true" Width="200px"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <td>Address:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddress" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                                                    </td>
                                                    <td>Remarks:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtRemarks" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                                                    </td>

                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <%--EXTRA LINE--%>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr style="padding:5px;">
                    <td style="vertical-align: top;">
                        <%--INPUT SECTION--%>
                        <div style="width: 530px; padding: 8px; border-style: solid; border-width: medium; border-color: darkblue; border-radius: 8px;">
                            <table style="width: 100%; text-align: left;">
                                <tr>
                                    <td colspan="2">
                                        <h4>Service Information</h4>
                                    </td>
                                </tr>
                                <tr style="text-align: left; vertical-align: top;">
                                    <td>ID:</td>
                                    <td>
                                        <asp:TextBox ID="txtServiceID" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                                        <asp:TextBox ID="txtClSvcID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="text-align: left; vertical-align: top;">
                                    <td>Service&nbsp;Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtServiceName" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="text-align: left; vertical-align: top;">
                                    <td>Description:</td>
                                    <td>
                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" ReadOnly="true"></asp:TextBox></td>
                                </tr>
                                <tr style="text-align: left; vertical-align: top;">
                                    <td>Active:</td>
                                    <td>
                                        <asp:CheckBox ID="chkIsActiveFlg" runat="server" /></td>
                                </tr>
                                <tr style="text-align: right;">
                                    <td colspan="2">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Service Information" />

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%--RIGHT SECTION--%>
                    <td style="vertical-align: top;">
                        <div>
                            <%--DEVICE SECTION--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeDevice" runat="Server"
                                TargetControlID="pnlDevice" CollapsedSize="52" ExpandedSize="360"
                                Collapsed="True" ExpandControlID="lblDeviceSectionCollapse" CollapseControlID="lblDeviceSectionCollapse"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlDevice" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; 
                                background-color: cadetblue; text-align: left; vertical-align: top; padding: 8px; width: 430px;">
                                    <h4 id="lblDeviceSectionCollapse" runat="server">Installed&nbsp;Devices</h4>
                                    <div style="overflow-y: scroll; width: 410px; height: 250px;">
                                        <asp:DataGrid runat="server" ID="dgClSvcDevices" AutoGenerateColumns="False" Width="100%" CellPadding="3" ForeColor="#333333"
                                            GridLines="Horizontal" ShowFooter="false" AllowPaging="true">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Open" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="CLSVCDEVID" Visible="false" ReadOnly="true"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVID" Visible="false" ReadOnly="true"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ITEMCODE" HeaderText="Item Code" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVICENAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DEVICETYPE" HeaderText="Type" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                <asp:ButtonColumn Text="Remove" CommandName="Delete" ButtonType="PushButton"></asp:ButtonColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:DataGrid>
                                    </div>
                                    <asp:button ID="btnUnAssignedDevice" runat="server" text="New Device" Width="130px"></asp:button>&nbsp;
                                    <asp:Button ID="btnAddDevice" runat="server" Text="Add Device" Width="130px" />
                                    
                                </div>
                            </asp:Panel>


                            <%--TSWORK SECTION--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
                                TargetControlID="pnlWork" CollapsedSize="52" ExpandedSize="360"
                                Collapsed="True" ExpandControlID="lblWorkSectionCollapse" CollapseControlID="lblWorkSectionCollapse"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlWork" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: coral; text-align: left; vertical-align: top; padding: 8px; width: 430px;">
                                    <h4 id="lblWorkSectionCollapse" runat="server">Service Jobs</h4>
                                    <div style="overflow-y: scroll; width: 410px; height: 250px;">
                                        <asp:DataGrid runat="server" ID="dgWork" AutoGenerateColumns="False" Width="100%" CellPadding="3" ForeColor="#333333" GridLines="Horizontal" AllowPaging="true">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Open" ButtonType="PushButton" CommandName="Update"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="TSWORKID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="QUOTATIONNUMBER" HeaderText="Job #" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PONUMBER" HeaderText="PO #" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="QUOTEDATE" HeaderText="Date" ReadOnly="True"></asp:BoundColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:DataGrid>
                                    </div>
                                    <asp:Button ID="btnNewJob" runat="server" Text="New Job Request" Width="140px" />
                               
                                </div>
                            </asp:Panel>


                            <%--TECH REP SECTION--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server"
                                TargetControlID="pnlTechRep" CollapsedSize="52" ExpandedSize="360"
                                Collapsed="True" ExpandControlID="lblTRSectionCollapse" CollapseControlID="lblTRSectionCollapse"
                                AutoCollapse="False" AutoExpand="False" CollapsedText="Show Details..."
                                ExpandedText="Hide Details" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlTechRep" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color:darkseagreen; text-align: left; vertical-align: top; padding: 8px; width: 430px;">
                                    <h4 id="lblTRSectionCollapse" runat="server">Technical Reports List</h4>
                                    <div style="overflow-y: scroll; width: 410px; height: 250px;">
                                        <asp:DataGrid runat="server" ID="dgTechReports" AutoGenerateColumns="False" Width="100%" CellPadding="3" ForeColor="#333333" GridLines="Horizontal" AllowPaging="true">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Open" ButtonType="PushButton" CommandName="Update"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="TECHREPID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="SERVICEJOBNUMBER" HeaderText="Job #" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="TEAM" HeaderText="Team" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STARTDT" HeaderText="Date" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:DataGrid>
                                    </div>
                                    <asp:Button ID="btnNewTechReport" runat="server" Text="New Technical Report" Width="160px" />
                                </div>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><hr /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%-- DEVICE MODAL --%>
                        <ajaxToolkit:ModalPopupExtender ID="mpDevice" runat="server"
                            TargetControlID="btnAddDevice" PopupControlID="pnlDeviceSearch"
                            BackgroundCssClass="modalBackground" CancelControlID="btnCancelModalDevice">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlDeviceSearch" runat="server" style="display:none;">
                            <div style="background-color: cadetblue; padding:15px; text-align:left;">
                                <h4>Add Device</h4>
                                <%--SEARCH SECTION--%>
                                <table class="search-table">
                                    <tr>
                                        <td style="padding: 5px; text-align: left; vertical-align: top">
                                            <label>Search</label>
                                            <div style="width: 250px; vertical-align: top; text-align: left;">
                                                <table>
                                                    <tr style="vertical-align:middle;">
                                                        <td>S/N:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtSNSearch" runat="server"></asp:TextBox></td>
                                                        <td>&nbsp;<asp:Button ID="btnSearchSN" runat="server" Text="Search" /></td>
                                                    </tr>
                                                    <tr style="vertical-align:middle;">
                                                        <td>Name:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox></td>
                                                        <td>&nbsp;<asp:Button ID="btnNameSearch" runat="server" Text="Search" /></td>
                                                    </tr>
                                                    <tr style="vertical-align:middle;">
                                                        <td>Code:</td>
                                                        <td>
                                                            <asp:TextBox ID="txtItemCodeSearch" runat="server"></asp:TextBox></td>
                                                        <td>&nbsp;<asp:Button ID="btnItemCodeSearch" runat="server" Text="Search" /></td>
                                                    </tr>
                                                    <tr style="vertical-align:middle;">
                                                        <td colspan="3">&nbsp;<asp:Button ID="btnClearDeviceResults" runat="server" Text="Clear All Searches" /></td>
                                                    </tr>
                                                    
                                                </table>
                                            </div>
                                        </td>
                                        <td style="padding: 5px; width: 100%; vertical-align: top; text-align: left;">
                                            <label>Results</label>
                                            <div style="width: 520px; height: 150px; overflow-y: scroll;">
                                                <asp:DataGrid runat="server" ID="dgResults" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" CellPadding="1" ForeColor="#333333" AllowSorting="True">
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                        <asp:BoundColumn DataField="DEVID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ITEMCODE" HeaderText="Item Code" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="DEVICENAME" HeaderText="Name" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="DEVICETYPE" HeaderText="Type" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SERIALNUMBER" HeaderText="S/N" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333"  Font-Size="X-Small"/>
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"><hr /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <%--VIEW DETAILS--%>
                                            <table>
                                                <tr>
                                                    <td style="vertical-align:top;">
                                                        <table style="text-align: left; vertical-align: top; padding: 5px;">
                                                            <tr>
                                                                <td>Device&nbsp;ID:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCLSSVCDEVID" runat="server" ReadOnly="True" Visible="false" Text="0" ></asp:TextBox>
                                                                    <asp:TextBox ID="txtDEVID" runat="server" ReadOnly="True"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Item&nbsp;Code:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtITEMCODE" runat="server" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Device&nbsp;Name:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDeviceName" runat="server" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Type:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDEVICETYPE" runat="server" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Serial&nbsp;Number:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSERIALNUMBER" runat="server" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td>Status:</td>
                                                                <td>
                                                                    <%--<asp:DropDownList ID="ddStatus" runat="server" Width="250px"></asp:DropDownList>--%>
                                                                    <asp:TextBox ID="ddStatus" runat="server" ReadOnly="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td>Available:</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkIsAvailable" runat="server" /></td>
                                                            </tr>
                                                            
                                                        </table>
                                                    </td>
                                                    <td style="vertical-align:top;">
                                                        <table>
                                                            <%--IT DEPT DETAILS--%>
                                                            <tr>
                                                                <td>IP&nbsp;Address:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIPADDRESS" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Brand&nbsp;Type:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBRANDTYPE" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Model:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtModel" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>HostName:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtHOSTNAME" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Username:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtUSERNAME" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Password:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPASSWORD" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>MAC&nbsp;Address:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMAC" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            
                                                            
                                                        </table>
                                                    </td>
                                                    <td style="vertical-align:top;">
                                                        <table>
                                                            <tr>
                                                                <td>Firmware&nbsp;Version:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFIRMWAREVERSION" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Default&nbsp;IP:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDEFAULTIPADDRESS" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Stream&nbsp;1&nbsp;Resolution:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSTREAM1RESOLUTION" runat="server" Width="90%" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Stream&nbsp;1&nbsp;FPS:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtSTREAM1FPS" runat="server" Width="90%" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <div style="text-align: right;">
                                                            <asp:Button ID="btnSelectDevice" runat="server" Text="Add Device" Width="120px" />&nbsp;
                                                            <%--<asp:Button ID="btnRemoveDevice" runat="server" Text="Remove Device" Width="120px" />--%>&nbsp;
                                                            <asp:Button ID="btnCancelModalDevice" runat="server" Text="Cancel"  Width="100px"/>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>

                        <%--  SERVICE JOB LINK MODAL --%>

                       

                    </td>
                </tr>
            </table>
        </div>
    </div>
    
</asp:Content>


