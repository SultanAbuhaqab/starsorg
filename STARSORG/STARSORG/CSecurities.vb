Imports System.Data.SqlClient

Public Class CSecurities

    Private _Security As CSecurity

    Public Sub New()
        _Security = New CSecurity
    End Sub

    Public ReadOnly Property CurrentObject() As CSecurity
        Get
            Return _Security
        End Get
    End Property

    Public Sub Clear()
        _Security = New CSecurity
    End Sub

    Public Function GetAllSecurities() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllSecurities", Nothing)
        Return objDR
    End Function

    Public Function GetSecurityByUserID(strUserID As String) As CSecurity
        Dim params As New ArrayList
        params.Add(New SqlParameter("UserID", strUserID))
        Return FillObject(myDB.GetDataReaderBySP("sp_getSecurityByUserID", params))
    End Function

    Private Function FillObject(objDR As SqlDataReader) As CSecurity
        If objDR.Read Then
            With _Security
                .PID = objDR.Item("PID")
                .UserID = objDR.Item("UserID")
                .SecRole = objDR.Item("SecRole")
                .Password = objDR.Item("Password")
            End With
        End If
        objDR.Close()
        Return _Security
    End Function

End Class
