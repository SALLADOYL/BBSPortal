Imports System.Data.SqlClient
Imports CISModel
Imports CISEntity
Public Class _default2
    Inherits System.Web.UI.Page

    Private Sub CalculateTRMetrics()
        Dim DT As New DataTable
        Dim ODATA As New CISModel.AnalyticsModel
        Dim stDate As Date = CType(Me.txtTRStartingDate.Text, Date)
        Dim endDate As Date = CType(Me.txtTREndingDate.Text, Date)

        DT = ODATA.GetTRStatusPieData(stDate, endDate)

        Me.chrtLineTechReport.DataSource = DT
        chrtLineTechReport.Series("Series1").XValueMember = "STATUS"
        chrtLineTechReport.Series("Series1").YValueMembers = "REPORTCOUNT"
        chrtLineTechReport.DataBind()

        Me.chrtPieTechReport.DataSource = DT
        chrtPieTechReport.Series("Series1").XValueMember = "STATUS"
        chrtPieTechReport.Series("Series1").YValueMembers = "REPORTCOUNT"
        chrtPieTechReport.DataBind()

        DT = Nothing
        ODATA = Nothing
    End Sub

    Private Sub CalculateSJMetrics()
        Dim DT As New DataTable
        Dim ODATA As New CISModel.AnalyticsModel
        Dim stDate As Date = CType(Me.txtSJStartDate.Text, Date)
        Dim endDate As Date = CType(Me.txtSJEndDate.Text, Date)

        DT = ODATA.GetSJStatusPieData(stDate, endDate)

        Me.chrtLineSJ.DataSource = DT
        chrtLineSJ.Series("Series1").XValueMember = "STATUS"
        chrtLineSJ.Series("Series1").YValueMembers = "RECCOUNT"
        chrtLineSJ.DataBind()

        Me.chrtPieSJ.DataSource = DT
        chrtPieSJ.Series("Series1").XValueMember = "STATUS"
        chrtPieSJ.Series("Series1").YValueMembers = "RECCOUNT"
        chrtPieSJ.DataBind()

        Me.dgOutstandingSJ.DataSource = ODATA.GetOutstandingSJ(stDate, endDate)
        dgOutstandingSJ.DataBind()

        Me.dgOutstandingTR.DataSource = ODATA.GetOutstandingTR(stDate, endDate)
        dgOutstandingTR.DataBind()

        DT = Nothing
        ODATA = Nothing
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.txtTRStartingDate.Text = CDate("1/1/" & Now.Year)
            'Now.AddDays(-20).ToShortDateString
            Me.txtSJStartDate.Text = CDate("1/1/" & Now.Year) 'Now.AddDays(-20).ToShortDateString

            Me.txtTREndingDate.Text = CDate("1/1/" & Now.Year + 1) 'Now.AddDays(+20).ToShortDateString
            Me.txtSJEndDate.Text = CDate("1/1/" & Now.Year + 1) 'Now.AddDays(+20).ToShortDateString

            CalculateSJMetrics()
            CalculateTRMetrics()

        End If

    End Sub

    Private Sub btnTRMetricsCalculate_Click(sender As Object, e As EventArgs) Handles btnTRMetricsCalculate.Click
        CalculateTRMetrics()
        'CalculateSJMetrics()

    End Sub

    Private Sub btnCalSJMetrics_Click(sender As Object, e As EventArgs) Handles btnCalSJMetrics.Click
        CalculateSJMetrics()
        ' CalculateTRMetrics()
    End Sub

    Private Sub dgOutstandingSJ_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgOutstandingSJ.UpdateCommand
        Dim ID As Long = CType(e.Item.Cells(0).Text, Long)
        Response.Redirect("~/ServiceJob/?ID=" + ID.ToString)
    End Sub

    Private Sub dgOutstandingTR_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgOutstandingTR.UpdateCommand
        Dim ID As Long = CType(e.Item.Cells(0).Text, Long)
        Response.Redirect("~/TechReport/?ID=" + ID.ToString)
    End Sub
End Class