Public Class _default13
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnDailyReport_Click(sender As Object, e As EventArgs) Handles btnDailyReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=SJDailyMetrics&DT=" + Me.txtDailyApprovalDate.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnEndDateReport_Click(sender As Object, e As EventArgs) Handles btnEndDateReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=SJEndDateMetrics&DT1=" + Me.txtEndDateFrom.Text + "&DT2=" + Me.txtEndDateTo.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnQuotationDateReport_Click(sender As Object, e As EventArgs) Handles btnQuotationDateReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=SJQuotationDateMetrics&DT1=" + Me.txtQuoteDateReportFrom.Text + "&DT2=" + Me.txtQuoteDateReportTo.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnStartDateReport_Click(sender As Object, e As EventArgs) Handles btnStartDateReport.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=SJStartDateMetrics&DT1=" + Me.txtStartDateFrom.Text + "&DT2=" + Me.txtStartDateTo.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
        modWeb = Nothing
    End Sub


End Class