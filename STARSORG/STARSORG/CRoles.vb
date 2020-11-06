Imports System.Data.SqlClient

Public Class CRoles
    'Represents the ROLE table and its associated business rules
    Private _Role As CRole

    'Constructor
    Public Sub New()
        'Instatiate the CRole Object
        _Role = New CRole
    End Sub

    Public ReadOnly Property CurrentObject() As CRole
        Get
            Return _Role
        End Get
    End Property

    Public Sub Clear()
        _Role = New CRole
    End Sub

    Public Sub CreateNewRole()
        'Call this when creating the edit portion of the screen to add a new role
        Clear()
        _Role.IsNewRole = True
    End Sub

    Public Function Save() As Integer
        Return _Role.Save()
    End Function

End Class
