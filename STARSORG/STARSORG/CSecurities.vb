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

End Class
