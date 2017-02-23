Option Strict On

Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Data.SqlClient

Public Class SQLHelper

    Public Shared Function ExecuteNonQuery(ByVal connString As String,
                                           ByVal cmdType As CommandType, ByVal cmdText As String,
                                           ByRef cmdParms As SqlParameter()) As Integer

        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        'Dim trans As SqlTransaction = conn.BeginTransaction("BuilderTransaction")
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Integer = cmd.ExecuteNonQuery()
            'cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception1 " & ex.Message)
        Catch exx As Exception
            Throw New Exception("ExecuteNonQuery Function", exx)
        Finally                'Add this for finally closing the connection and destroying the command
            conn.Close()
            cmd = Nothing
            'cmdParms = Nothing
        End Try
    End Function

    Public Shared Function ExecuteNonQuery(ByVal connString As String,
                                           ByVal cmdType As CommandType, ByVal cmdText As String,
                                           ByRef cmdParm As SqlParameterCollection) As Integer

        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        'Dim trans As SqlTransaction = conn.BeginTransaction("BuilderTransaction")
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParm)
            Dim val As Integer = cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception1 " & ex.Message)
        Catch exx As Exception
            Throw New Exception("ExecuteNonQuery Function", exx)
        Finally                'Add this for finally closing the connection and destroying the command
            conn.Close()
            cmd = Nothing
            cmdParm = Nothing
        End Try
    End Function

    Public Shared Function ExecuteNonQuery(ByRef conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByRef cmdParms As SqlParameter()) As Integer
        Dim cmd As SqlCommand = New SqlCommand
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim parm As SqlParameter
            For Each parm In cmdParms
                cmd.Parameters.Add(parm)
            Next
            Dim val As Integer = cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteNonQuery", exx)
        Finally
            cmd = Nothing
        End Try
    End Function

    Public Shared Function ExecuteReader(ByRef conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand
        'Dim conn As OleDbConnection = New OleDbConnection(connString)
        ' we use a try/catch here because if the method throws an exception we want to 
        ' close the connection throw ex code, because no datareader will exist, hence the 
        ' commandBehaviour.CloseConnection will not work
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim rdr As SqlDataReader = cmd.ExecuteReader()
            'cmd.Parameters.Clear()
            Return rdr
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteReader", exx)
        Finally
            cmd = Nothing
        End Try
    End Function

    Public Shared Function ExecuteTable(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataTable

        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            'cmd.Parameters = cmdParms
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            Return oDataTable
        Catch ex As SqlException

            Throw New Exception("SQL Exception : " & ex.Message, ex)
        Catch exx As Exception
            Throw New Exception("ExecuteTable Exception :", exx)
        Finally
            conn.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    Public Shared Function ExecuteTable(ByRef oConnection As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataTable

        Dim cmd As SqlCommand = New SqlCommand
        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, oConnection, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            Return oDataTable
        Catch ex As Exception
            Throw New Exception("ExecuteTable", ex)
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
            oDataAdapter.Dispose()
            oDataTable.Dispose()
        End Try
    End Function

    Public Shared Function ExecuteDataSet(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataSet
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)

        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataSet As New DataSet
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            'cmd.Connection = conn
            oDataAdapter.Fill(oDataSet)
            cmd.Parameters.Clear()
            Return oDataSet
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteDataSet", exx)
        Finally
            conn.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    Public Shared Function ExecuteRow(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataRow
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        Dim oDataAdapter As New SqlDataAdapter
        'Dim oDataRow As DataRow
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            If oDataTable.Rows.Count = 0 Then
                Return Nothing
            Else
                Dim oRow As DataRow = oDataTable.Rows(0)
                Return oRow
            End If
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteRow", exx)
        Finally
            conn.Close()
            oDataTable = Nothing
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    Public Shared Function ExecuteRow(ByRef oConnection As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataRow
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = oConnection
        Dim oDataAdapter As New SqlDataAdapter
        'Dim oDataRow As DataRow
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            If oDataTable.Rows.Count = 0 Then
                Return Nothing
            Else
                Dim oRow As DataRow = oDataTable.Rows(0)
                Return oRow
            End If
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            oDataTable = Nothing
            cmd.Connection.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function



    Public Shared Function ExecuteScalar(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As SqlParameter()) As Object
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Object = cmd.ExecuteScalar()

            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            conn.Close()
            conn = Nothing
            cmd = Nothing
        End Try
    End Function




    Public Shared Function ExecuteScalar(ByRef conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As SqlParameter()) As Object

        Dim cmd As SqlCommand = New SqlCommand
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Object = cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            cmd.Connection.Close()
            cmd = Nothing
        End Try
    End Function



    Public Shared Function PrepareCommand(ByRef cmd As SqlCommand, ByRef conn As SqlConnection, ByRef cmdType As CommandType, ByRef cmdText As String, ByRef cmdParms As SqlParameter()) As Boolean
        If Not conn.State = ConnectionState.Open Then
            'MsgBox("Connection open")
            conn.Open()
        End If
        Try
            cmd.Connection = conn
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            '  cmd.ParameterCheck = True
            cmd.CommandType = cmdType
            If Not (IsNothing(cmdParms)) Then
                Dim parm As SqlParameter
                For Each parm In cmdParms
                    cmd.Parameters.Add(parm)
                Next
            End If
            Return True
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("PrepareCommand : ", exx)
        End Try
    End Function

    Public Shared Function PrepareCommand(ByRef cmd As SqlCommand, ByRef conn As SqlConnection, ByRef cmdType As CommandType, ByRef cmdText As String, ByRef cmdParms As SqlParameterCollection) As Boolean
        If Not conn.State = ConnectionState.Open Then
            'MsgBox("Connection open")
            conn.Open()
        End If
        Try
            cmd.Connection = conn
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            '  cmd.ParameterCheck = True
            cmd.CommandType = cmdType
            If Not (IsNothing(cmdParms)) Then
                Dim parm As SqlParameter
                For Each parm In cmdParms
                    cmd.Parameters.Add(parm)
                Next
            End If
            Return True
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("PrepareCommand : ", exx)
        End Try
    End Function

    Public Shared Function ExcuteAdapter(ByVal connString As String, ByVal oTable As DataTable, ByVal cmdText As String, Optional ByRef lngMaxID As Long = 0) As Boolean

        Dim conn As SqlConnection
        Dim oDataAdapter As New SqlDataAdapter
        Dim oSqlCmd As New SqlCommand
        Dim oCmdBuilder As SqlCommandBuilder

        conn = New SqlConnection(connString)

        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If

            oSqlCmd.Connection = conn
            oSqlCmd.CommandText = cmdText
            oSqlCmd.CommandType = CommandType.Text
            oDataAdapter.SelectCommand = oSqlCmd
            oCmdBuilder = New SqlCommandBuilder(oDataAdapter)
            oCmdBuilder.GetUpdateCommand()
            oCmdBuilder.GetInsertCommand()
            oCmdBuilder.GetDeleteCommand()
            oDataAdapter.Update(oTable)
            oDataAdapter.SelectCommand = New SqlCommand("SELECT @@IDENTITY", conn)
            lngMaxID = CType(oDataAdapter.SelectCommand.ExecuteScalar(), Long)

        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateAdapter", exx)
        Finally
            ' cmd.Connection.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
            oSqlCmd = Nothing
            oDataAdapter = Nothing
            oCmdBuilder = Nothing

        End Try

        Return True
    End Function


End Class
