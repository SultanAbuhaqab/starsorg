Imports System.Data.SqlClient

Public Class CAudits

    Private _Audit As CAudit

    Public Sub New()
        _Audit = New CAudit
    End Sub

    Public ReadOnly Property CurrentObject() As CAudit
        Get
            Return _Audit
        End Get
    End Property

    Public Function Save() As Integer
        Return _Audit.Save()
    End Function

End Class
