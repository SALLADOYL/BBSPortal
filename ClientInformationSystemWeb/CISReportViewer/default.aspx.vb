Imports CISData
Imports Microsoft.Reporting.WebForms
Imports System.Net

Public Class _default12
    Inherits System.Web.UI.Page


    Private Sub SetReportProperties(ByVal ReportType As String)
        Select Case ReportType
            Case "ClientReportSingle"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Client Reports/Client Report (Single)"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamTRID As New ReportParameter
                rptParamTRID.Name = "paramClientID"
                rptParamTRID.Values.Add(CType(Request.QueryString("ID"), Long))
                lstrptParam.Add(rptParamTRID)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()


            Case "TRSingle"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Technical Reports/Technical-Report (Single)"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamTRID As New ReportParameter
                rptParamTRID.Name = "paramTRID"
                rptParamTRID.Values.Add(CType(Request.QueryString("id"), Long))
                lstrptParam.Add(rptParamTRID)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()

            Case "SJSingle"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Service Job Reports/Service-Job (Single)"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamSJID As New ReportParameter
                rptParamSJID.Name = "paramSJID"
                rptParamSJID.Values.Add(CType(Request.QueryString("id"), Long))
                lstrptParam.Add(rptParamSJID)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()
            Case "SJDailyMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Service Job Reports/Service-Job Daily Report"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamFromDT As New ReportParameter
                rptParamFromDT.Name = "rptParamFromDT"
                rptParamFromDT.Values.Add(CDate(Request.QueryString("DT")).ToShortDateString)
                '(CType(Request.QueryString("DT"), Date))
                lstrptParam.Add(rptParamFromDT)
                Dim rptParamToDT As New ReportParameter
                rptParamToDT.Name = "rptParamToDT"
                rptParamToDT.Values.Add(CDate(Request.QueryString("DT")).AddDays(1).ToShortDateString)
                '(CType(Request.QueryString("DT"), Date).AddDays(1))
                lstrptParam.Add(rptParamToDT)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()
            Case "SJQuotationDateMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Service Job Reports/Service-Job Quotation Date Metric Report"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                'CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()
            Case "SJStartDateMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Service Job Reports/Service-Job Start Date Metric Report"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()
            Case "SJEndDateMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Service Job Reports/Service-Job End Date Metric Report"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()

            Case "TRDailyMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Technical Reports/TR Daily Metrics"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamFromDT As New ReportParameter
                rptParamFromDT.Name = "rptParamFromDT"
                rptParamFromDT.Values.Add(CDate(Request.QueryString("DT")).ToShortDateString)
                '(CType(Request.QueryString("DT"), Date))
                lstrptParam.Add(rptParamFromDT)
                Dim rptParamToDT As New ReportParameter
                rptParamToDT.Name = "rptParamToDT"
                rptParamToDT.Values.Add(CDate(Request.QueryString("DT")).AddDays(1).ToShortDateString)
                '(CType(Request.QueryString("DT"), Date).AddDays(1))
                lstrptParam.Add(rptParamToDT)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()

            Case "TRRangeDateMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Technical Reports/Tech-Report Date Range Metrics"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()

            Case "TRMetricsClientServiceStart"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Technical Reports/Tech-Report Metrics (Client-Service-Start Date)"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                Dim rptParam3 As New ReportParameter
                rptParam3.Name = "rptParamClientServiceID"
                rptParam3.Values.Add(CType(Request.QueryString("ID"), Long))
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParam3)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()

            Case "ClientServiceMetrics"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Client Reports/Client-Service Metrics"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                'Dim rptParam3 As New ReportParameter
                'rptParam3.Name = "rptParamClientServiceID"
                'rptParam3.Values.Add(CType(Request.QueryString("ID"), Long))
                ''(CType(Request.QueryString("DT2"), Date))
                'lstrptParam.Add(rptParam3)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()

            Case "ClientMetricsSJTR"
                Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Client Reports/Client Metrics (Service-Jobs and Tech-Reports)"
                Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")

                Dim lstrptParam As New List(Of ReportParameter)
                Dim rptParamDT1 As New ReportParameter
                rptParamDT1.Name = "rptParamFromDT"
                rptParamDT1.Values.Add(CDate(Request.QueryString("DT1")).ToShortDateString)
                '(CType(Request.QueryString("DT1"), Date))
                lstrptParam.Add(rptParamDT1)
                Dim rptParamDT2 As New ReportParameter
                rptParamDT2.Name = "rptParamToDT"
                rptParamDT2.Values.Add(CDate(Request.QueryString("DT2")).ToShortDateString)
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParamDT2)
                Dim rptParam3 As New ReportParameter
                rptParam3.Name = "rptParamClientServiceID"
                rptParam3.Values.Add(CType(Request.QueryString("ID"), Long))
                '(CType(Request.QueryString("DT2"), Date))
                lstrptParam.Add(rptParam3)
                Me.ReportViewer1.ServerReport.SetParameters(lstrptParam)

                ReportViewer1.ServerReport.Refresh()
                ReportViewer1.DataBind()


        End Select

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.ReportViewer1.ShowParameterPrompts = False
            Dim irepCred As IReportServerCredentials = New CustomReportCredentials("sl.it.sysad", "Ll0yd123", "BBS")
            ReportViewer1.ServerReport.ReportServerCredentials = irepCred
            SetReportProperties(Request.QueryString("RptType"))
            Me.ReportViewer1.Visible = True
        End If
    End Sub

End Class

Public Class CustomReportCredentials
    Implements IReportServerCredentials
    Private _UserName As String
    Private _PassWord As String
    Private _DomainName As String

    Public Sub New(UserName As String, PassWord As String, DomainName As String)
        _UserName = UserName
        _PassWord = PassWord
        _DomainName = DomainName
    End Sub

    Public ReadOnly Property ImpersonationUser() As System.Security.Principal.WindowsIdentity Implements IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property NetworkCredentials() As ICredentials Implements IReportServerCredentials.NetworkCredentials
        Get
            Return New NetworkCredential(_UserName, _PassWord, _DomainName)
        End Get
    End Property

    Public Function GetFormsCredentials(ByRef authCookie As Cookie, ByRef user As String, ByRef password As String, ByRef authority As String) As Boolean Implements IReportServerCredentials.GetFormsCredentials
        authCookie = Nothing
        user = InlineAssignHelper(password, InlineAssignHelper(authority, Nothing))
        Return False
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class