Imports System.Data.SqlClient
Imports CISModel
Imports CISEntity
Public Class _default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim DT As New DataTable
            Dim ODATA As New CISModel.AnalyticsModel
            DT = ODATA.GetSummary(Now, Now)

            Response.Write(DT.ToString())

            DT = ODATA.GetWorkByDateRange(Now.AddDays(-30), Now.AddDays(+20))

            Response.Write(DT.ToString())

            DT = ODATA.GetTechReportByDateRange(Now.AddDays(-30), Now.AddDays(+20))

            Response.Write(DT.ToString())

            DT = Nothing
            ODATA = Nothing
        End If
    End Sub

End Class