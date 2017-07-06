<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteModal.Master" CodeBehind="default.aspx.vb" Inherits="ClientInformationSystemWeb._default12" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center; width:100%;  overflow:scroll;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:reportviewer visible="false" id="ReportViewer1" runat="server" 
            processingmode="Remote" width="100%" Height="100%" showcredentialprompts="false">
        </rsweb:reportviewer>
    </div>
</asp:Content>
