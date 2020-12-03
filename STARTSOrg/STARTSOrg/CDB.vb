﻿Imports System.Data.SqlClient
Public Class CDB
    Public Function OpenDB() As Boolean
        objSQLCommand = New SqlCommand ' Instantiate SQL Command
        Dim blnResult As Boolean
        If objSQLConn Is Nothing Then   ' We need to instatiate the connection object
            Try
                objSQLConn = New SqlConnection(gstrConn)
                objSQLConn.Open()
                blnResult = True
            Catch exOpenConnError As Exception
                MessageBox.Show("Cannot open database: " & exOpenConnError.ToString, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                blnResult = False
                ' You should log this error
            End Try
        Else
            If objSQLConn.State = ConnectionState.Open Then
                Return True
            Else
                Return False
            End If
        End If
        Return blnResult
    End Function

    Public Sub CloseDB()
        Try
            objSQLConn.Close()    ' Closing connection to DB
        Catch ex As Exception
            MessageBox.Show("Error attempting to close database: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetDataReaderBySP(ByVal strSP As String, ByRef params As ArrayList) As SqlDataReader
        If Not OpenDB() Then ' Should error log this problem
            Return Nothing
        End If
        objSQLCommand = New SqlCommand(strSP, objSQLConn)
        objSQLCommand.CommandType = CommandType.StoredProcedure
        If Not params Is Nothing Then ' Add each parameter into the command object
            For Each p As SqlParameter In params
                objSQLCommand.Parameters.Add(p)
            Next
        End If
        Try
            Return objSQLCommand.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("Failed to get datareader: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Function GetDataAdapterBySP(ByVal strSP As String, ByRef params As ArrayList) As SqlDataAdapter
        objSQLCommand = New SqlCommand(strSP, objSQLConn)
        Dim sqlDA As SqlDataAdapter
        objSQLCommand.CommandType = CommandType.StoredProcedure
        If Not params Is Nothing Then
            For Each p As SqlParameter In params
                objSQLCommand.Parameters.Add(p)
            Next
        End If
        Try
            sqlDA = New SqlDataAdapter(objSQLCommand)
            Return sqlDA
        Catch ex As Exception
            MessageBox.Show("Failed to get data adapter: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Function ExecSP(ByVal strSP As String, ByRef params As ArrayList) As Integer
        If Not OpenDB() Then
            Return -1
        End If
        objSQLCommand = New SqlCommand(strSP, objSQLConn)
        objSQLCommand.CommandType = CommandType.StoredProcedure
        Try
            If Not params Is Nothing Then
                For Each p As SqlParameter In params
                    objSQLCommand.Parameters.Add(p)
                Next
            End If
            Return objSQLCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error executing SP: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetSingleValueFromSP(ByVal strSP As String, ByRef params As ArrayList) As String
        Dim sqlDR As SqlDataReader = GetDataReaderBySP(strSP, params)
        Dim strResult As String
        If Not sqlDR Is Nothing Then ' We got a data reader
            If sqlDR.Read Then ' We have some data
                strResult = sqlDR.GetValue(0).ToString
                sqlDR.Close()
                Return strResult
            Else
                Return -1
            End If
        End If
        Return -2 ' Failed to connect or even get a data reader
    End Function
End Class
