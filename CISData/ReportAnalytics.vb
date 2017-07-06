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
        STRSQL = STRSQL + " ,(SELECT COUNT(G.TECHREPID) AS REPORTCOUNT"
        STRSQL = STRSQL + " FROM "
        STRSQL = STRSQL + " CLIENTTBL AS A INNER JOIN "
        STRSQL = STRSQL + " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL = STRSQL + " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL = STRSQL + " TECHREPORTTBL AS G ON B.CLIENTSVCID = G.CLIENTSVCID "
        'STRSQL = STRSQL + " WHERE A.CLIENTID = CLIENTTBL.CLIENTID And G.CRTDT BETWEEN CONVERT(DATETIME,'" + dtFrom.ToString("dd/MM/yyyy") + "',103) AND CONVERT(DATETIME,'" + dtTo.ToString("dd/MM/yyyy") + "',103)) AS TECHREPORTCOUNT"
        STRSQL = STRSQL + " WHERE A.CLIENTID = CLIENTTBL.CLIENTID AND G.STARTDT BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "') AS TECHREPORTCOUNT"
        STRSQL = STRSQL + " ,(Select        COUNT(G.TSWORKID) "
        STRSQL = STRSQL + " FROM "
        STRSQL = STRSQL + " CLIENTTBL AS A INNER JOIN"
        STRSQL = STRSQL + " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN"
        STRSQL = STRSQL + " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN"
        STRSQL = STRSQL + " TSWORKTBL AS F ON B.CLIENTSVCID = F.CLSVCID"
        STRSQL = STRSQL + " WHERE        A.CLIENTID = CLIENTTBL.CLIENTID And G.JOBAPPROVALDATE BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "' ) As WORKCOUNT"
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

    Public Function GetSJStatusPieData(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.SQLHelper
        Dim STRSQL As String = ""
        Dim fromstr As String = dtFrom.ToString("MM/dd/yyyy")
        Dim tostr As String = dtTo.ToString("MM/dd/yyyy")

        STRSQL &= " SELECT "
        STRSQL &= " 'NEW-NOT STARTED' AS STATUS, COUNT(TSWORKTBL.TSWORKID ) AS RECCOUNT "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TSWORKTBL ON B.CLIENTSVCID = TSWORKTBL.CLSVCID "
        STRSQL &= " WHERE TSWORKTBL.STATUS= 'NEW-NOT STARTED' "
        STRSQL &= " And TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + fromstr + "' AND '" + tostr + "' "
        STRSQL &= " UNION SELECT "
        STRSQL &= " 'IN PROGRESS' AS STATUS, COUNT(TSWORKTBL.TSWORKID ) AS RECCOUNT "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TSWORKTBL ON B.CLIENTSVCID = TSWORKTBL.CLSVCID "
        STRSQL &= " WHERE TSWORKTBL.STATUS= 'IN PROGRESS' "
        STRSQL &= " And TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + fromstr + "' AND '" + tostr + "' "
        STRSQL &= " UNION SELECT "
        STRSQL &= " 'COMPLETED' AS STATUS, COUNT(TSWORKTBL.TSWORKID ) AS RECCOUNT "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TSWORKTBL ON B.CLIENTSVCID = TSWORKTBL.CLSVCID "
        STRSQL &= " WHERE TSWORKTBL.STATUS= 'COMPLETED' "
        STRSQL &= " And TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + fromstr + "' AND '" + tostr + "' "
        STRSQL &= " UNION SELECT "
        STRSQL &= " 'CANCELED' AS STATUS, COUNT(TSWORKTBL.TSWORKID ) AS RECCOUNT "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TSWORKTBL ON B.CLIENTSVCID = TSWORKTBL.CLSVCID "
        STRSQL &= " WHERE TSWORKTBL.STATUS= 'CANCELED' "
        STRSQL &= " And TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + fromstr + "' AND '" + tostr + "' "
        STRSQL &= " UNION SELECT "
        STRSQL &= " 'ON-HOLD' AS STATUS, COUNT(TSWORKTBL.TSWORKID ) AS RECCOUNT "
        STRSQL &= " FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TSWORKTBL ON B.CLIENTSVCID = TSWORKTBL.CLSVCID "
        STRSQL &= " WHERE TSWORKTBL.STATUS= 'ON-HOLD' "
        STRSQL &= " And TSWORKTBL.JOBAPPROVALDATE BETWEEN '" + fromstr + "' AND '" + tostr + "' "

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

    Public Function GetTRStatusPieData(ByVal dtFrom As DateTime, ByVal dtTo As DateTime) As DataTable
        Dim oData As New CISData.SQLHelper
        Dim STRSQL As String = ""
        Dim fromstr As String = dtFrom.ToString("MM/dd/yyyy")
        Dim tostr As String = dtTo.ToString("MM/dd/yyyy")

        STRSQL &= " Select 'ON-GOING' AS STATUS, COUNT(G.TECHREPID) AS REPORTCOUNT FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TECHREPORTTBL AS G ON B.CLIENTSVCID = G.CLIENTSVCID "
        STRSQL &= "  WHERE "
        STRSQL &= "  G.STATUS = 'ON-GOING' "
        STRSQL &= "  AND G.STARTDT BETWEEN '" + fromstr + "' AND '" + tostr + "'"
        STRSQL &= " UNION SELECT 'DONE' AS STATUS,COUNT(G.TECHREPID) AS REPORTCOUNT FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TECHREPORTTBL AS G ON B.CLIENTSVCID = G.CLIENTSVCID "
        STRSQL &= "  WHERE "
        STRSQL &= "  G.STATUS = 'DONE' "
        STRSQL &= "  AND G.STARTDT BETWEEN '" + fromstr + "' AND '" + tostr + "' "
        STRSQL &= " UNION SELECT 'ON-HOLD' AS STATUS, COUNT(G.TECHREPID) AS REPORTCOUNT FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TECHREPORTTBL AS G ON B.CLIENTSVCID = G.CLIENTSVCID "
        STRSQL &= "  WHERE "
        STRSQL &= "  G.STATUS = 'ON-HOLD' "
        STRSQL &= "  AND G.STARTDT BETWEEN '" + fromstr + "' AND '" + tostr + "' "
        STRSQL &= " UNION SELECT 'NOT STARTED' AS STATUS, COUNT(G.TECHREPID) AS REPORTCOUNT FROM "
        STRSQL &= " CLIENTTBL AS A INNER JOIN "
        STRSQL &= " CLIENTSERVICETBL AS B ON A.CLIENTID = B.CLIENTID INNER JOIN "
        STRSQL &= " SERVICETBL AS D ON B.SVCID = D.SVCID INNER JOIN "
        STRSQL &= " TECHREPORTTBL AS G ON B.CLIENTSVCID = G.CLIENTSVCID "
        STRSQL &= "  WHERE "
        STRSQL &= "  G.STATUS = 'NOT STARTED' "
        STRSQL &= "  AND G.STARTDT BETWEEN '" + fromstr + "' AND '" + tostr + "' "


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
        STRSQL = STRSQL + " WHERE A.ISACTIVEFLG = 1 And A.PURGEFLG = 0 AND G.CRTDT BETWEEN '" + dtFrom.ToString("MM/dd/yyyy") + "' AND '" + dtTo.ToString("MM/dd/yyyy") + "'"


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
