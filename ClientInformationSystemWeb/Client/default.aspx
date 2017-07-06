<%@ Page Title="CLIENT INFORMATION SYSTEM: CLIENT MAINTENANCE PAGE" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server" style="width: 100%;">
        <%--<div style="padding-left: 5px; padding-top:70px; width: 100%; top: 70px; left:5px;">--%>
        <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">
            <div style="width: 100%; text-align: left;">
                <h1>Client Maintenance Page</h1>
            </div>
            <table style="padding: 15px;">
                <tr>
                    <td colspan="2">
                        <%--SEARCH SECTION--%>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeSearch" runat="Server"
                            AutoCollapse="false" AutoExpand="false" Collapsed="true"
                            TargetControlID="pnlSearch" CollapsedSize="40" ExpandedSize="250"
                            ExpandControlID="lblClientSearchTool" CollapseControlID="lblClientSearchTool"
                            ExpandDirection="Vertical" />
                        <asp:Panel ID="pnlSearch" runat="server">
                            <div style="padding: 3px; border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray;">
                                <table style="width: 900px; text-align: justify; vertical-align: text-top">
                                    <tr>
                                        <td colspan="2">
                                            <div style="text-align: justify;">
                                                <table style="padding: 5px;">
                                                    <tr>
                                                        <td>
                                                            <h4 id="lblClientSearchTool" runat="server">Client Search Tool&nbsp;</h4>
                                                        </td>
                                                        <td>
                                                            <h4>&nbsp;|&nbsp;</h4>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnShareURL" runat="server" Text="Share URL" Width="120px" />
                                                        </td>
                                                        <td>
                                                            <h4>&nbsp;|&nbsp;</h4>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnPrintPrev" runat="server" Text="Print Preview" Width="120px" />
                                                        </td>
                                                    </tr>
                                                </table>


                                            </div>
                                        </td>
                                        <%--<td>
                                            
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td style="width: auto; padding: 5px; text-align: center; vertical-align: top">
                                            <label>Navigation</label>
                                            <div style="width: 270px;">
                                                <label style="width: 50px;">ID:</label><asp:TextBox ID="txtIDSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnSearchID" runat="server" Text="Search" />
                                                <label style="width: 50px;">Name:</label><asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnNameSearch" runat="server" Text="Search" />
                                                <label style="width: 50px;">Code:</label><asp:TextBox ID="txtCodeSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnCodeSearch" runat="server" Text="Search" />
                                                <br />
                                                <asp:Button ID="btnClear" runat="server" Text="Clear All" Width="100%" />
                                            </div>
                                        </td>
                                        <td style="padding: 5px; width: 100%; text-align: center;">
                                            <label id="lblResults" runat="server">Results</label>
                                            <div style="overflow-y: scroll; width: 600px; height: 150px;">
                                                <asp:DataGrid runat="server" ID="dgClientResults" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" ShowFooter="True" AllowSorting="True">
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="CLIENTID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CLIENTCODE" HeaderText="Client Code" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="NAME" HeaderText="Client Name" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                    </Columns>
                                                    <EditItemStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedItemStyle BackColor="Yellow" Font-Bold="True" ForeColor="Red" />

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
                <tr style="padding: 5px;">
                    <td style="vertical-align: top;">
                        <%--INPUT SECTION--%>
                        <div id="pnlInput" runat="server" style="padding-left: 5px; width: 520px; padding: 8px; border-style: solid; border-width: medium; border-color: darkblue; border-radius: 8px;">
                            <table style="text-align: left; vertical-align: top;">
                                <tr>
                                    <td colspan="2">
                                        <h4>Client Information:</h4>
                                    </td>
                                </tr>

                                <tr style="visibility: hidden; height: 0px;">
                                    <td>Client ID:</td>
                                    <td>
                                        <asp:TextBox ID="txtCLIENTID" runat="server" ReadOnly="True" Width="250px" Visible="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Client&nbsp;Code:</td>
                                    <td>
                                        <asp:TextBox ID="txtCLIENTCODE" runat="server" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Width="370px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Address:</td>
                                    <td>
                                        <asp:TextBox ID="txtADDRESS" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Industry:</td>
                                    <td>
                                        <asp:DropDownList ID="ddINDUSTRY" runat="server" Width="250px"></asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Contact&nbsp;Number:</td>
                                    <td>
                                        <asp:TextBox ID="txtContactNumber" runat="server" TextMode="Phone" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Fax:</td>
                                    <td>
                                        <asp:TextBox ID="txtFax" runat="server" TextMode="Phone" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Website:</td>
                                    <td>
                                        <asp:TextBox ID="txtWebsite" runat="server" TextMode="Url" Width="370px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>E-mail Address:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="370px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Active:</td>
                                    <td>
                                        <asp:CheckBox ID="chkActive" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>Remarks:</td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <table style="width: 100%">
                                            <tr>

                                                <td colspan="2" style="padding: 8px;">
                                                    <div style="text-align: right; width: 100%;">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" />&nbsp;
                                                        <asp:Button ID="btnNew" runat="server" Text="Register New Client" Width="150px" />&nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>--%>
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
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeServiceInfo" runat="Server"
                                TargetControlID="pnlServiceInfo" CollapsedSize="40" ExpandedSize="240"
                                ExpandControlID="lblServiceAcquired" CollapseControlID="lblServiceAcquired"
                                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" Collapsed="true" />
                            <asp:Panel ID="pnlServiceInfo" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: cadetblue; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <h4 id="lblServiceAcquired" runat="server">Services Acquired</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 110px;">
                                        <asp:DataGrid runat="server" ID="dgClientServices" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowFooter="True">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:ButtonColumn Text="Edit" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="CLIENTSVCID" Visible="false" />
                                                <asp:BoundColumn DataField="SERVIENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>
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
                                    <asp:Button ID="btnAddService" runat="server" Text="Add New Service" />

                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="mpeClServices" runat="server"
                                TargetControlID="btnAddService" PopupControlID="pnlClServices" CancelControlID="btnCancelServiceModal"
                                BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="pnlClServices" runat="server" Width="400px" Height="200px" Style="display: none;">
                                <div style="background-color: cadetblue; padding: 15px;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2">
                                                <h4>New Service Subscription</h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr style="visibility: hidden; height: 0px;">
                                            <td>Service ID:</td>
                                            <td>
                                                <asp:TextBox ID="txtCLServiceID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Service Name:</td>
                                            <td>
                                                <asp:DropDownList ID="ddServiceName" runat="server" Width="300px"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="2" style="text-align: right;">
                                                <asp:Button ID="btnNewService" runat="server" Text="Subscribe/Add" />
                                                &nbsp;<asp:Button ID="btnCancelServiceModal" runat="server" Text="Cancel" /></td>
                                        </tr>
                                    </table>
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
                                            AllowSorting="True" CellPadding="2" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" ShowFooter="True">
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

                            <%--NOTES SECTION--%>
                            <ajaxToolkit:CollapsiblePanelExtender ID="cpeNotes" runat="Server"
                                TargetControlID="pnlNotes" CollapsedSize="40" ExpandedSize="340"
                                ExpandControlID="lblNotes" CollapseControlID="lblNotes" Collapsed="true"
                                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
                            <asp:Panel ID="pnlNotes" runat="server">
                                <div style="border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: darkseagreen; text-align: left; vertical-align: top; padding: 8px; width: 400px;">
                                    <%--<label id="lblNotes" runat="server">Notes</label>--%>
                                    <h4 id="lblNotes" runat="server">Notes</h4>
                                    <div style="overflow-y: scroll; width: 380px; height: 210px;">
                                        <asp:DataGrid runat="server" ID="dgNotes" AutoGenerateColumns="False" Width="100%"
                                            AllowSorting="True" CellPadding="4" ShowFooter="True" BackColor="White" BorderColor="#336666" BorderWidth="3px" GridLines="Horizontal" BorderStyle="Double">
                                            <Columns>
                                                <asp:ButtonColumn Text="Open" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                                <asp:BoundColumn DataField="NOTEID" Visible="false"></asp:BoundColumn>
                                                <%--<asp:BoundColumn DataField="NOTEDATE" HeaderText="Date" ReadOnly="True"></asp:BoundColumn>--%>
                                                <asp:BoundColumn DataField="NOTETEXT" HeaderText="Note" ReadOnly="True"></asp:BoundColumn>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
                                            <ItemStyle BackColor="White" ForeColor="#333333" Font-Size="X-Small" />
                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                                            <SelectedItemStyle BackColor="#339966" ForeColor="White" Font-Bold="True" />
                                        </asp:DataGrid>
                                    </div>
                                    <hr />
                                    <asp:Button ID="btnNewNote" runat="server" Text="New Note" Width="120px" />
                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="mpeNotes" runat="server" TargetControlID="btnNewNote"
                                PopupControlID="pnlNoteModal"
                                BackgroundCssClass="modalBackground">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="pnlNoteModal" runat="server" Style="display: none; width: 550px; height: 300px;">
                                <div style="background-color: darkseagreen; padding: 15px;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td colspan="2">
                                                <h4>New Note</h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ID&nbsp;<asp:TextBox ID="txtNoteID" runat="server" ReadOnly="true"></asp:TextBox></td>
                                            <td>Date:&nbsp;<asp:TextBox ID="txtNoteDate" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Note:<br />
                                                <asp:TextBox ID="txtNoteText" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
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
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right;">
                        <ajaxToolkit:ModalPopupExtender ID="mpeShareURL" runat="server" TargetControlID="btnShareURL"
                            PopupControlID="pnlShareURL" CancelControlID="btnCloseURL"
                            BackgroundCssClass="modalBackground">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlShareURL" runat="server" Style="display: none;">
                            <div style="background-color: darkseagreen; padding: 15px;">
                                <table>
                                    <tr>
                                        <td colspan="3" style="text-align: left;">
                                            <h4>Share Page URL</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>URL:</td>
                                        <td colspan="2" style="text-align: left;">
                                            <asp:TextBox ID="txtURL" runat="server" ReadOnly="true" Width="390px" TextMode="Url"></asp:TextBox>
                                        </td>
                                        <%--<td><asp:Button ID="btnCopyURL" runat="server" Text="Copy" /></td>--%>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td colspan="2">
                                            <i>Copy&nbsp;text&nbsp;for&nbsp;sharing.</i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Button ID="btnEncryptURL" runat="server" Text="Encrypt" Width="120px" />&nbsp;
                                            <asp:Button ID="btnCloseURL" runat="server" Text="Close" Width="120px" />&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

