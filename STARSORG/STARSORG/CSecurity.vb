Imports System.Data.SqlClient

Public Class CSecurity
    Private _mstrPID As String
    Private _mstrUserID As String
    Private _mstrPassword As String
    Private _mstrSecRole As String

    Public Sub New()
        _mstrPID = ""
        _mstrUserID = ""
        _mstrPassword = ""
        _mstrSecRole = ""
    End Sub

#Region "Expose Properties"
    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
        End Set
    End Property

    Public Property UserID As String
        Get
            Return _mstrUserID
        End Get
        Set(strVal As String)
            _mstrUserID = strVal
        End Set
    End Property

    Public Property Password As String
        Get
            Return _mstrPassword
        End Get
        Set(strVal As String)
            _mstrPassword = strVal
        End Set
    End Property

    Public Property SecRole As String
        Get
            Return _mstrSecRole
        End Get
        Set(strVal As String)
            _mstrSecRole = strVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params = New ArrayList

            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("UserID", _mstrUserID))
            params.Add(New SqlParameter("Password", _mstrPassword))
            params.Add(New SqlParameter("SecRole", _mstrSecRole))

            Return params
        End Get
    End Property

#End Region

End Class
