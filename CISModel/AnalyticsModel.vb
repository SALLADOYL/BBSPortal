Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient


Public Class AnalyticsModel

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
        STRSQL = STRSQL + " WHERE A.CLIENTID = CLIENTTBL.CLIENTID AND G.CRTDT BETWEEN '" + dtFrom.ToString + "' AND '" + dtTo.ToString + "') AS TECHREPORTCOUNT"
        STRSQL = STRSQL + " ,(Select        COUNT(G.TSWORKID) "
        STRSQL = STRSQL + " FROM            CLIENTTBL As A INNER JOIN"
        STRSQL = STRSQL + " CLIENTSERVICETBL As B On A.CLIENTID = B.CLIENTID INNER JOIN"
        STRSQL = STRSQL + "  CLIENTSERVICEDEVICETBL As C On B.CLIENTSVCID = C.CLSVCDEVID INNER JOIN"
        STRSQL = STRSQL + " SERVICETBL As D On B.SVCID = D.SVCID INNER JOIN"
        STRSQL = STRSQL + " DEVICETBL As E On C.DEVID = E.DEVID LEFT OUTER JOIN"
        STRSQL = STRSQL + " TSWORKTBL As F On B.CLIENTSVCID = F.CLSVCID LEFT OUTER JOIN"
        STRSQL = STRSQL + " TECHREPORTTBL As G On F.TSWORKID = G.TSWORKID"
        STRSQL = STRSQL + " WHERE        A.CLIENTID = CLIENTTBL.CLIENTID AND G.CRTDT BETWEEN '" + dtFrom.ToString + "' AND '" + dtTo.ToString + "' ) As WORKCOUNT"
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
