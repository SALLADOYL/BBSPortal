﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="PageMain" runat="server"  style="width: 100%;">
        <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

        <div style="width: 100%; text-align: left;">
                <h1>Profile Page</h1>
        </div>
        <table>
            <tr>
                <td colspan="2">
                    <div>
                        <%--SEARCH SECTION--%>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeSearch" runat="Server"
                            AutoCollapse="false" AutoExpand="false" Collapsed="true"
                            TargetControlID="pnlSearch" CollapsedSize="40" ExpandedSize="250"
                            ExpandControlID="lblPeopleSearchTool" CollapseControlID="lblPeopleSearchTool" 
                            ExpandDirection="Vertical"  />
                        <asp:Panel ID="pnlSearch" runat="server">
                            <div style="padding: 3px; border-width: medium; border-color: darkblue; border-style: solid; border-radius: 8px; background-color: lightgray;">

                                <table style="width: 100%; text-align: justify; vertical-align: text-top">
                                    <tr>
                                        <td colspan="2">
                                            <h4 id="lblPeopleSearchTool" runat="server">People Search Tool</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: auto; padding: 5px; text-align: left; vertical-align: top">
                                            <label>Search</label>
                                            <div style="width: 270px;">
                                                <label style="width: 50px;">ID:</label><asp:TextBox ID="txtIDSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnSearchID" runat="server" Text="Search" />
                                                <label style="width: 50px;">Name:</label><asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnNameSearch" runat="server" Text="Search" />
                                                <label style="width: 50px;">Code:</label><asp:TextBox ID="txtCodeSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnCodeSearch" runat="server" Text="Search" />
                                                <br />
                                                <asp:Button ID="btnClear" runat="server" Text="Clear All" Width="100%" />
                                            </div>
                                        </td>
                                        <td style="padding: 5px; width: 100%; vertical-align: top; text-align: left;">
                                            <label>Results</label>
                                            <div style="width: 700px; height: 150px; overflow-y: scroll">
                                                <asp:DataGrid runat="server" ID="dgEmpResults" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" ShowFooter="True" AllowSorting="True">
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="PROFILEID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EMPLOYEECODE" HeaderText="Employee Code" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="NAME" HeaderText="Employee Name" ReadOnly="True"></asp:BoundColumn>
                                                        <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
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
                    </div>
                </td>
            </tr>
            <tr>
                <%--EXTRA LINE--%>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <%--INPUT SECTION--%>
                    <div id="pnlInput" runat="server"  style="padding-left: 5px; padding:5px; border-style:solid; border-width:medium; border-color: darkblue; border-radius: 8px;">
                        <table style="text-align: left; vertical-align: top;">
                            <tr>
                                <td colspan="2">
                                    <h4>Profile Information:</h4>
                                </td>
                            </tr>
                            <tr style="visibility:hidden;">
                                <td>Profile&nbsp;ID:</td>
                                <td>
                                    <asp:TextBox Visible="false"  ID="txtProfileID" runat="server" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Employee&nbsp;Code:</td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeCode" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Name:</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="vertical-align:top;">Address:</td>
                                <td>
                                    <asp:TextBox ID="txtADDRESS" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Faculty&nbsp;Group:</td>
                                <td>
                                    <asp:DropDownList ID="ddFacultyGroup" runat="server" Width="250px"></asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>Department:</td>
                                <td>
                                    <asp:DropDownList ID="ddDepartment" runat="server" Width="250px"></asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>Status:</td>
                                <td>
                                    <asp:DropDownList ID="ddStatus" runat="server" Width="250px"></asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>Work&nbsp;Email:</td>
                                <td>
                                   <asp:TextBox ID="txtWorkEmail" runat="server" TextMode="Email" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile&nbsp;Phone:</td>
                                <td>
                                    <asp:TextBox ID="txtMobilePhone" runat="server" TextMode="Phone" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Extension:</td>
                                <td>
                                    <asp:TextBox ID="txtExtension" runat="server" TextMode="Phone" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Branch:</td>
                                <td>
                                    <asp:DropDownList ID="ddBranch" runat="server" Width="250px"></asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>Designation:</td>
                                <td>
                                    <asp:DropDownList ID="ddDesignation" runat="server" Width="250px"></asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td>Affiliated&nbsp;to&nbsp;Company:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsAffiliated" runat="server" /></td>
                            </tr>
                            <tr style="visibility:hidden;">
                                <td>Active:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" Visible="false" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table style="width: 100%">
                                        <tr>
                                            
                                            <td style="text-align: right" colspan="2">
                                                <div style="text-align: right; width: 100%">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="120px" />&nbsp;
                                                    <asp:Button ID="btnNew" runat="server" Text="New Profile" Width="150px" />&nbsp;
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
                <%--INPUT RIGHT SIDE--%>
                <td style="vertical-align: top;">
                    <div>
                        <div style="background-color: cadetblue; padding: 5px;">
                            <h4 id="lblServiceAcquired" runat="server">ID Photo</h4>
                            <div>
                                
                                    <asp:Image ID="imgPhoto" runat="server" Width="150px" Height="150px" style="padding:2px; border-color:darkblue; border-radius:2px; border-style:solid;" />
                                
                                <br /><br />
                                <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload Photo" />
                                <br />
                            </div>
                            
                        </div>
                        <br />
                        <div style="background-color: cadetblue; padding: 5px;">
                            <h4 id="H2" runat="server">Set Username / Password</h4>
                            <div>
                                <asp:Button ID="btnSetProfileAccess" runat="server" Text="Set Username and Password" />
                            </div><br />
                        </div>

                        <%-- UPLOAD PROFILE PICTURE MODAL --%>
                        <ajaxToolkit:ModalPopupExtender ID="mpeUploadPhoto" runat="server" TargetControlID="btnUploadPhoto"
                            PopupControlID="pnlUploadPhotoModal" CancelControlID="btnCancelUpload"
                            BackgroundCssClass="modalBackground">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlUploadPhotoModal" runat="server" Width="400px" Height="300px" Style="display: none;">
                            <div style="background-color: cadetblue; padding: 15px;">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <h4>Upload An ID Photo</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <hr />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                            <td>File ID:</td>
                                            <td>
                                                <asp:TextBox ID="txtFILEID" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        </tr>--%>
                                    <tr>
                                        <td>File:</td>
                                        <td>
                                            <input type="file" id="fileInput1" runat="server"  /></td>
                                    </tr>
                                    <%--<tr>
                                            <td colspan="2"><hr /></td>
                                        </tr>--%>
                                    <%--<tr>
                                            <td>Remarks:</td>
                                            <td>
                                                <asp:TextBox ID="txtAttachmentRemarks" runat="server" Width="250px"></asp:TextBox></td>
                                        </tr>--%>
                                    <tr>
                                        <td colspan="2">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: right;">
                                            <asp:Button ID="btnUploadSavePhoto" runat="server" Text="Upload And Save to Profile" />
                                            &nbsp;<asp:Button ID="btnCancelUpload" runat="server" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>


                        <%-- USERNAME AND PASSWORD MODAL --%>
                        <ajaxToolkit:ModalPopupExtender ID="mpeProfileAccess" runat="server" TargetControlID="btnSetProfileAccess"
                            PopupControlID="pnlProfileAccessModal" CancelControlID="btnCancelProfileAccess"
                            BackgroundCssClass="modalBackground">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="pnlProfileAccessModal" runat="server" Width="400px" Height="300px" Style="display: none;">
                            <div style="background-color: cadetblue; padding: 15px;">
                                <h4 id="H1" runat="server">ID Photo</h4>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <h4>Configure Username and Password</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Username:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Password:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnSaveUsrPwd" runat="server" Text="Set Username / Password" />
                                            <asp:Button ID="btnCancelProfileAccess" runat="server" Text="Cancel" />
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
