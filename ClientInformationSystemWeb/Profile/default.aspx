<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 5px; width: 100%">
        <h1>Profile Maintenance Page</h1>
        <table>
            <tr>
                <td colspan="2">
                    <div>
                        <%--SEARCH SECTION--%>
                        <table style="width: 100%; text-align: justify; vertical-align: text-top">
                            <tr>
                                <td style="width: auto; padding: 5px; background-color: lightblue; text-align: center; vertical-align:top">
                                    <h4>Navigation</h4>
                                    <div style="width: 270px;">
                                        <label style="width: 50px;">ID:</label><asp:TextBox ID="txtIDSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnSearchID" runat="server" Text="Search" />
                                        <label style="width: 50px;">Name:</label><asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnNameSearch" runat="server" Text="Search" />
                                        <label style="width: 50px;">Code:</label><asp:TextBox ID="txtCodeSearch" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="btnCodeSearch" runat="server" Text="Search" />
                                        <br /><asp:Button ID="btnClear" runat="server" Text="Clear All" Width="100%" />
                                    </div>
                                </td>
                                <td style="background-color: lightblue; padding: 5px; width: 100%; text-align: center;">
                                    <h4>Results</h4>
                                    <div style="width:630px">
                                        <asp:DataGrid runat="server" ID="dgEmpResults" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="3" CellPadding="4" ForeColor="#333333" ShowFooter="True" AllowSorting="True">
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundColumn DataField="PROFILEID" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="EMPLOYEECODE" HeaderText="Employee Code" ReadOnly="True"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="NAME" HeaderText="Employee Name" ReadOnly="True"></asp:BoundColumn>
                                                <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                            </Columns>
                                            <EditItemStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"   Font-Size="Smaller"/>
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333"   Font-Size="X-Small"/>
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
            <tr>
                <%--EXTRA LINE--%>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <%--INPUT SECTION--%>
                    <div style="padding-left: 5px;">
                        <table style="text-align: left; vertical-align: top;">
                            <tr>
                                <td>Profile ID:</td>
                                <td>
                                    <asp:TextBox ID="txtProfileID" runat="server" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Employee Code:</td>
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
                                <td>Address:</td>
                                <td>
                                    <asp:TextBox ID="txtADDRESS" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Faculty Group:</td>
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
                                <td>Work Email:</td>
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
                            <tr>
                                <td>Active:</td>
                                <td>
                                    <asp:CheckBox ID="chkIsActive" runat="server" /></td>
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
                                                    <asp:Button ID="btnNew" runat="server" Text="New Profile" Width="150px" />&nbsp;
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
                    <div style="background-color: darkblue; padding: 5px;">
                        <div>
                            <asp:Image ID="imgPhoto" runat="server" Width="150px" Height="150px" />
                            <br />
                            <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload Photo" />
                        </div><br /><hr />
                        <div>
                            <table>
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
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
