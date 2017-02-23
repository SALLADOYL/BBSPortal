<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%;">
        <h4>Dashboard</h4>
        <table style="width: 100%; padding: 15px;">
            <tr>
                <%--METRIC LINKS--%>
                <td style="text-align:left; vertical-align:top;">
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
                </td>
                <%--GRAPHS--%>
                <td style="vertical-align:top">
                    <table>
                        <tr><td colspan="2"><label>Today</label></td></tr>
                        <tr>
                            <td>
                                <div style="width: 250px">
                                    <asp:Chart ID="Chart1" runat="server">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Bar"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </td>
                            <td>
                                <div style="width: 250px">
                                    <asp:Chart ID="Chart2" runat="server">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </td>
                        </tr>
                        <tr><td colspan="2"><h4>Monthly</h4></td></tr>
                        <tr>
                            <td>
                                <div style="width: 250px">
                                    <asp:Chart ID="Chart3" runat="server">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Bar"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </td>
                            <td>
                                <div style="width: 250px">
                                    <asp:Chart ID="Chart4" runat="server">
                                        <Series>
                                            <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </div>
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
