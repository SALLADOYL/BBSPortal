Imports CISModel
Imports CISData
Imports System.Data.SqlClient
Public Class _default15
    Inherits System.Web.UI.Page

    Private Sub PopulateClientServiceDropdown()
        Dim mdlAnalytics As New CISModel.AnalyticsModel

        Me.ddClSvc.DataSource = mdlAnalytics.GetClientServiceList
        Me.ddClSvc.DataTextField = "NAMESERVICE"
        Me.ddClSvc.DataValueField = "CLIENTSVCID"
        Me.ddClSvc.DataBind()

        mdlAnalytics = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PopulateClientServiceDropdown()
        End If
    End Sub

    Private Sub btnClientMetricSJTR_Click(sender As Object, e As EventArgs) Handles btnClientMetricSJTR.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=ClientMetricsSJTR&DT1=" + Me.txtSJTRDateFrom.Text + "&DT2=" + Me.txtSJTRDateTo.Text + "&ID=" + Me.ddClSvc.SelectedValue
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnViewServiceSubs_Click(sender As Object, e As EventArgs) Handles btnViewServiceSubs.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=ClientServiceMetrics&DT1=" + Me.txtDateFromServiceSubs.Text + "&DT2=" + Me.txtDateToServiceSubs.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub
End Class