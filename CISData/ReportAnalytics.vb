Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ReportAnalytics

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
        'STRSQL = STRSQL + " WHERE A.CLIENTID = CLIENTTBL.CLIENTID AND G.CRTDT BETWEEN CONVERT(DATETIME,'" + dtFrom.ToString("dd/MM/yyyy") + "',103) AND CONVERT(DATETIME,'" + dtTo.ToString("dd/MM/yyyy") + "',103)) AS TECHREPORTCOUNT"
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

    Public Function GetTechReportByDateRange(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.SQLHelper

        Dim STRSQL As String = " Select A.NAME, D.SERVIENAME, G.TECHREPID, G.TEAM, G.PERFORMEDBY, G.REMARKS "
        STRSQL = STRSQL + " From CLIENTTBL As A INNER Join "
        STRSQL = STRSQL + " CLIENTSERVICETBL As B On A.CLIENTID = B.CLIENTID INNER Join "
        STRSQL = STRSQL + " CLIENTSERVICEDEVICETBL As C On B.CLIENTSVCID = C.CLSVCDEVID INNER Join"
        STRSQL = STRSQL + " SERVICETBL As D On B.SVCID = D.SVCID INNER Join "
        STRSQL = STRSQL + " DEVICETBL As E On C.DEVID = E.DEVID LEFT OUTER Join "
        STRSQL = STRSQL + " TSWORKTBL As F On B.CLIENTSVCID = F.CLSVCID LEFT OUTER Join "
        STRSQL = STRSQL + " TECHREPORTTBL As G On F.TSWORKID = G.TSWORKID"
        STRSQL = STRSQL + " WHERE A.ISACTIVEFLG = 1 And A.PURGEFLG = 0 AND G.CRTDT BETWEEN '" + dtFrom.ToString + "' AND '" + dtTo.ToString + "'"


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

End Class
