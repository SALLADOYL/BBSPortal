<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default2" EnableEventValidation="true" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 5px; padding-top: 70px; border-style: solid; border-color: darkblue; border-radius: 3px; padding: 4px; background-color: ActiveBorder;">

            <div style="width: 100%; text-align: left;">
                <h1>Dashboard</h1>
            </div>

        <table style="width: 100%; padding: 15px;">
            <tr>
                <td colspan="2">
                    <%-- SERVICE JOB METRICS --%>
                    <table>
                        <tr><td colspan="2"><hr /><h4>Service-Job Metrics</h4></td></tr>
                        <tr>
                            <td colspan="2" style="text-align:left;">
                                <div>
                                    <label>From:</label>&nbsp;<asp:TextBox ID="txtSJStartDate" runat="server" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgSJStartDate" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="calexSJStartDate" runat="server" PopupButtonID="imgSJStartDate"
                                        TargetControlID="txtSJStartDate" Format="dd/MM/yyyy" />&nbsp;
                                    <label>To:</label>&nbsp;<asp:TextBox ID="txtSJEndDate" runat="server" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgSJEndDate" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="calexSJEndDate" runat="server" PopupButtonID="imgSJEndDate"
                                        TargetControlID="txtSJEndDate" Format="dd/MM/yyyy" />&nbsp;
                                    <asp:Button ID="btnCalSJMetrics" runat="server" Text="Calculate Service Job Metrics" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="overflow-y: scroll; width: 100%; height: 120px;">
                                    <asp:DataGrid runat="server" ID="dgOutstandingSJ" AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333" ShowFooter="False" AllowSorting="True">
                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundColumn DataField="TSWORKID" Visible="false"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CLIENTCODE" HeaderText="Client Code" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CLIENTNAME" HeaderText="Client" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="SERVICENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="SERVICEJOBNUMBER" HeaderText="Job No." ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PONUMBER" HeaderText="P.O. No." ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="QUOTATIONNUMBER" HeaderText="Quotation No." ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="STARTDATE" HeaderText="Start" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ENDDATE" HeaderText="End" ReadOnly="True"></asp:BoundColumn>
                                            <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                        </Columns>
                                        <EditItemStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" Wrap="true" />
                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedItemStyle BackColor="Yellow" Font-Bold="True" ForeColor="Red" />

                                    </asp:DataGrid>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:Chart ID="chrtLineSJ" runat="server" Width="530px">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Bar" BackGradientStyle="HorizontalCenter" IsValueShownAsLabel="true" Font="Calibri, 8.25pt"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                                <Area3DStyle Enable3D="True"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <%--<Legends>
                                            <asp:Legend Name="STATUS" IsDockedInsideChartArea="false" Title="Tech-Reports by Status" ></asp:Legend>
                                        </Legends>--%>
                                    </asp:Chart>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <asp:Chart ID="chrtPieSJ" runat="server" Width="400px">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Pie" IsVisibleInLegend="true"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                                <Area3DStyle Enable3D="True"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend IsDockedInsideChartArea="false" Name="STATUS" Title="Service-Job Status" Alignment="Center" Docking="Bottom">
                                            </asp:Legend>
                                        </Legends>
                                    </asp:Chart>
                                </div>
                            </td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <%--METRIC LINKS--%>
               <%-- <td style="text-align:left; vertical-align:top;">
                    <div>
                        <label>Metrics&nbsp;Today</label>
                        <br />
                        <div >
                            Work Count:<asp:LinkButton runat="server" ID="lnkWorkCount">00</asp:LinkButton><br />
                            UnAssigned:<asp:LinkButton runat="server" ID="lnkWorkUnAssigned">00</asp:LinkButton><br />
                            On-Going:<asp:LinkButton runat="server" ID="lnkWorkOngoing">00</asp:LinkButton><br />
                            Completed:<asp:LinkButton runat="server" ID="lnkWorkCompleted">00</asp:LinkButton><br />
                        </div>
                    </div>
                </td>--%>
                <%--GRAPHS--%>
                <td colspan="2" style="vertical-align:top">
                    <%-- TR METRICS --%>
                    <table>
                        <tr><td colspan="2"><hr /><h4>Technical-Report Metrics</h4></td></tr>
                        <tr>
                            <td colspan="2" style="text-align:left;">
                                <div>
                                    <label>From:</label>&nbsp;<asp:TextBox ID="txtTRStartingDate" runat="server" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgTRStartingDate" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="calexTRStartingDate" runat="server" PopupButtonID="imgTRStartingDate"
                                        TargetControlID="txtTRStartingDate" Format="dd/MM/yyyy" />&nbsp;
                                    <label>To:</label>&nbsp;<asp:TextBox ID="txtTREndingDate" runat="server" ReadOnly="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgTREndingDate" runat="server" ImageUrl="~/Images/calendar-icon.png" Height="20px" Width="20px" />&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="calexTREndingDate" runat="server" PopupButtonID="imgTREndingDate"
                                        TargetControlID="txtTREndingDate" Format="dd/MM/yyyy" />&nbsp;
                                    <asp:Button ID="btnTRMetricsCalculate" runat="server" Text="Calculate Technical-Report Metrics" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="overflow-y: scroll; width: 100%; height: 120px;">
                                    <asp:DataGrid runat="server" ID="dgOutstandingTR" AutoGenerateColumns="False" Width="100%" CellPadding="2" ForeColor="#333333" ShowFooter="False" AllowSorting="True">
                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundColumn DataField="TECHREPID" Visible="false"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CLIENTCODE" HeaderText="Client Code" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CLIENTNAME" HeaderText="Client" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="SERVIENAME" HeaderText="Service" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="STATUS" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="TEAM" HeaderText="Team" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="STARTDT" HeaderText="Start" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="COMPLETEDT" HeaderText="Completed" ReadOnly="True"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ASSIGNEDTO" HeaderText="Assigned To" ReadOnly="True"></asp:BoundColumn>
                                            <asp:ButtonColumn Text="Load" CommandName="Update" ButtonType="PushButton"></asp:ButtonColumn>
                                        </Columns>
                                        <EditItemStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Smaller" Wrap="true" />
                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedItemStyle BackColor="Yellow" Font-Bold="True" ForeColor="Red" />

                                    </asp:DataGrid>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:Chart ID="chrtLineTechReport" runat="server" Width="530px">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Bar" BackGradientStyle="HorizontalCenter" IsValueShownAsLabel="true" Font="Calibri, 8.25pt"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" >
<Area3DStyle Enable3D="True"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <%--<Legends>
                                            <asp:Legend Name="STATUS" IsDockedInsideChartArea="false" Title="Tech-Reports by Status" ></asp:Legend>
                                        </Legends>--%>
                                    </asp:Chart>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <asp:Chart ID="chrtPieTechReport" runat="server" Width="400px">
                                        <Series>
                                            <asp:Series Name="Series1"  ChartType="Pie" IsVisibleInLegend="true" ></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" >
<Area3DStyle Enable3D="True"></Area3DStyle>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend IsDockedInsideChartArea="false" Name="STATUS" Title="TR Status" Alignment="Center" Docking="Bottom"></asp:Legend>
                                        </Legends>
                                    </asp:Chart>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <hr />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
