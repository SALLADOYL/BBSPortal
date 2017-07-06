Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient


Public Class AnalyticsModel

    Public Function GetTRStatusPieData(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.ReportAnalytics
        Return oData.GetTRStatusPieData(dtFrom, dtTo)
    End Function

    Public Function GetSJStatusPieData(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.ReportAnalytics
        Return oData.GetSJStatusPieData(dtFrom, dtTo)
    End Function

    Public Function GetClientServiceList() As DataTable
        Dim oData As New CISData.SQLHelper
        Dim STRSQL As String = ""
        STRSQL &= " SELECT "
        STRSQL &= " CLIENTSERVICETBL.CLIENTSVCID, "
        STRSQL &= " (CLIENTTBL.NAME + ' - ' + SERVICETBL.SERVIENAME) AS NAMESERVICE "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTSERVICETBL INNER JOIN"
        STRSQL &= " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID "
        STRSQL &= " WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG=0 "
        STRSQL &= " And SERVICETBL.ISACTIVEFLG=1 And SERVICETBL.PURGEFLG=0 "
        STRSQL &= " And CLIENTTBL.ISACTIVEFLG=1 And CLIENTTBL.PURGEFLG=0 "
        STRSQL &= " ORDER BY NAMESERVICE ASC"

        Dim OBJCOMMON As New CommonClass
        Dim NN As New SqlParameter()
        Dim DS As DataSet = SQLHelper.ExecuteDataSet(OBJCOMMON.GetConnString, CommandType.Text, STRSQL)

        If Not IsNothing(DS) Then
            Return DS.Tables(0)
        Else
            Return Nothing
        End If
        Return Nothing

    End Function

    Public Function GetOutstandingSJ(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.SQLHelper

        Dim STRSQL As String = ""
        STRSQL &= " SELECT "
        STRSQL &= " TSWORKTBL.TSWORKID, "
        STRSQL &= " CLIENTTBL.CLIENTCODE, "
        STRSQL &= " CLIENTTBL.NAME AS CLIENTNAME, "
        STRSQL &= " SERVICETBL.SERVIENAME AS SERVICENAME, "
        STRSQL &= " TSWORKTBL.SERVICEJOBNUMBER, "
        STRSQL &= " TSWORKTBL.PONUMBER, "
        STRSQL &= " TSWORKTBL.QUOTATIONNUMBER, "
        STRSQL &= " TSWORKTBL.STATUS, "
        STRSQL &= " (SELECT PROFILETBL.NAME FROM PROFILETBL WHERE PROFILETBL.PROFILEID = TSWORKTBL.JOBAPPROVEDBY) AS JOBAPPROVEDBY, "
        STRSQL &= " TSWORKTBL.STARTDATE, "
        STRSQL &= " TSWORKTBL.ENDDATE, "
        STRSQL &= " TSWORKTBL.CLIENTSIGNEDBY "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTSERVICETBL INNER JOIN "
        STRSQL &= " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        STRSQL &= " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        STRSQL &= " WHERE "
        STRSQL &= " (CLIENTSERVICETBL.ISACTIVE = 1) And (CLIENTSERVICETBL.PURGEFLG = 0) "
        STRSQL &= " And (CLIENTTBL.ISACTIVEFLG = 1) And (CLIENTTBL.PURGEFLG = 0) "
        STRSQL &= " And (SERVICETBL.ISACTIVEFLG = 1) And (SERVICETBL.PURGEFLG = 0) "
        STRSQL &= " And (TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "')"
        STRSQL &= " And TSWORKTBL.STATUS != 'COMPLETED' "
        STRSQL &= " ORDER BY TSWORKTBL.STARTDATE ASC "

        Dim OBJCOMMON As New CommonClass
        Dim NN As New SqlParameter()
        Dim DS As DataSet = SQLHelper.ExecuteDataSet(OBJCOMMON.GetConnString, CommandType.Text, STRSQL)

        If Not IsNothing(DS) Then
            Return DS.Tables(0)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function

    Public Function GetOutstandingTR(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.SQLHelper

        Dim STRSQL As String = ""
        STRSQL &= " SELECT "
        STRSQL &= " TECHREPORTTBL.TECHREPID, "
        STRSQL &= " CLIENTTBL.CLIENTCODE, "
        STRSQL &= " CLIENTTBL.NAME AS CLIENTNAME, "
        STRSQL &= " SERVICETBL.SERVIENAME, "
        STRSQL &= " TECHREPORTTBL.STATUS, "
        STRSQL &= " TECHREPORTTBL.TEAM, "
        STRSQL &= " CONVERT(VARCHAR(10), TECHREPORTTBL.STARTDT, 103) AS STARTDT, "
        STRSQL &= " CONVERT(VARCHAR(10), TECHREPORTTBL.COMPLETEDT, 103) AS COMPLETEDT, "
        STRSQL &= " (SELECT NAME FROM PROFILETBL WHERE PROFILEID = TECHREPORTTBL.PERFORMEDBY) AS ASSIGNEDTO "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTTBL INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        STRSQL &= " TECHREPORTTBL ON CLIENTSERVICETBL.CLIENTSVCID = TECHREPORTTBL.CLIENTSVCID "
        STRSQL &= " WHERE TECHREPORTTBL.ISACTIVEFLG=1 And TECHREPORTTBL.PURGEFLG=0 "
        STRSQL &= " And TECHREPORTTBL.STARTDT BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "' "
        STRSQL &= " And CLIENTSERVICETBL.ISACTIVE=1 And CLIENTSERVICETBL.PURGEFLG=0 "
        STRSQL &= " ORDER BY  STARTDT ASC,TECHREPORTTBL.TECHREPID "
        ''STRSQL &= " And (TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "')"


        Dim OBJCOMMON As New CommonClass
        Dim NN As New SqlParameter()
        Dim DS As DataSet = SQLHelper.ExecuteDataSet(OBJCOMMON.GetConnString, CommandType.Text, STRSQL)

        If Not IsNothing(DS) Then
            Return DS.Tables(0)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function

    Public Function GetSummary(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.SQLHelper

        Dim STRSQL As String = " SELECT "
        STRSQL = STRSQL + " CLIENTTBL.CLIENTID"
        STRSQL = STRSQL + " ,CLIENTTBL.CLIENTCODE"
        STRSQL = STRSQL + " ,(SELECT        COUNT(G.TECHREPID) AS REPORTCOUNT"
        STRSQL = STRSQL + " FROM            CLIENTTBL As A INNER JOIN"
        STRSQL = STRSQL + " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN"
        STRSQL = STRSQL + " CLIENTSERVICEDEVICETBL As C On B.CLIENTSVCID = C.CLSVCDEVID INNER JOIN"
        STRSQL = STRSQL + " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN"
        STRSQL = STRSQL + " DEVICETBL As E On C.DEVID = E.DEVID LEFT OUTER JOIN"
        STRSQL = STRSQL + " TSWORKTBL AS F ON B.CLIENTSVCID = F.CLSVCID LEFT OUTER JOIN"
        STRSQL = STRSQL + " TECHREPORTTBL As G On F.TSWORKID = G.TSWORKID"
        STRSQL = STRSQL + " WHERE A.CLIENTID = CLIENTTBL.CLIENTID AND G.CRTDT BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "') AS TECHREPORTCOUNT"
        STRSQL = STRSQL + " ,(Select        COUNT(G.TSWORKID) "
        STRSQL = STRSQL + " FROM            CLIENTTBL As A INNER JOIN"
        STRSQL = STRSQL + " CLIENTSERVICETBL As B On A.CLIENTID = B.CLIENTID INNER JOIN"
        STRSQL = STRSQL + "  CLIENTSERVICEDEVICETBL As C On B.CLIENTSVCID = C.CLSVCDEVID INNER JOIN"
        STRSQL = STRSQL + " SERVICETBL As D On B.SVCID = D.SVCID INNER JOIN"
        STRSQL = STRSQL + " DEVICETBL As E On C.DEVID = E.DEVID LEFT OUTER JOIN"
        STRSQL = STRSQL + " TSWORKTBL As F On B.CLIENTSVCID = F.CLSVCID LEFT OUTER JOIN"
        STRSQL = STRSQL + " TECHREPORTTBL As G On F.TSWORKID = G.TSWORKID"
        STRSQL = STRSQL + " WHERE        A.CLIENTID = CLIENTTBL.CLIENTID AND G.CRTDT BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "' ) As WORKCOUNT"
        STRSQL = STRSQL + " FROM CLIENTTBL WHERE ISACTIVEFLG = 1 And PURGEFLG = 0"

        Dim OBJCOMMON As New CommonClass
        Dim NN As New SqlParameter()
        Dim DS As DataSet = SQLHelper.ExecuteDataSet(OBJCOMMON.GetConnString, CommandType.Text, STRSQL)

        If Not IsNothing(DS) Then
            Return DS.Tables(0)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function



    Public Function GetWorkByDateRange(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.ReportAnalytics
        Return oData.GetSummary(dtFrom, dtTo)
    End Function

    Public Function GetTechReportByDateRange(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.ReportAnalytics

        Return oData.GetTechReportByDateRange(dtFrom, dtTo)
    End Function

End Class
