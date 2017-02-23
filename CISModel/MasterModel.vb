

Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient
Public Class MasterModel

    Public Function GetIndustryList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from IndustryMasterTBL"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function

    Public Function GetDepartmentList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from DEPARTMENTMASTERTBL"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function

    Public Function GetBranchList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from BRANCHMASTERTBL"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function

    Public Function GetProfileStatusList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from STATUSMASTERTBL WHERE STATUSTYPE = 'PROFILE'"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function

    Public Function GetDeviceStatusList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from STATUSMASTERTBL WHERE STATUSTYPE = 'DEVICE'"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function
    Public Function GetTRStatusList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from STATUSMASTERTBL WHERE STATUSTYPE = 'TECHREPORT'"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function



    Public Function GetFacultyGroupList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from FACULTYGROUPMASTERTBL"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function

    Public Function GetDesignationList() As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strCmdText As String = "Select * from DESIGNATIONMASTERTBL"
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strCmdText)
    End Function

End Class
