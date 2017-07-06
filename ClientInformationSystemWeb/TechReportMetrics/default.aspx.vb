Imports CISModel
Imports CISData
Imports System.Data.SqlClient

Public Class _default14
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

    Private Sub btnDailyReport_Click(sender As Object, e As EventArgs) Handles btnDailyReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=TRDailyMetrics&DT=" + Me.txtDailyStartDate.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnRangeDateReport_Click(sender As Object, e As EventArgs) Handles btnRangeDateReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=TRRangeDateMetrics&DT1=" + Me.txtStartDateFrom.Text + "&DT2=" + Me.txtStartDateTo.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnClSvcDateReport_Click(sender As Object, e As EventArgs) Handles btnClSvcDateReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=TRMetricsClientServiceStart&DT1=" + Me.txtDateFrom.Text + "&DT2=" + Me.txtDateTo.Text + "&ID=" + Me.ddClSvc.SelectedValue
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub
End Class