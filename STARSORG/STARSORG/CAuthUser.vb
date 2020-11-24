Public Class CAuthUser
    Private _mstrPID As String
    Private _mstrUserID As String
    Private _mstrSecRole As String

    Public Sub New()
        _mstrPID = ""
        _mstrUserID = ""
        _mstrSecRole = ""
    End Sub

    Public Function Save(strPID As String, strUserID As String, strSecRole As String) As CAuthUser
        _mstrPID = strPID
        _mstrUserID = strUserID
        _mstrSecRole = strSecRole

        Return Me
    End Function

    Public Function Clear() As CAuthUser
        Return New CAuthUser
    End Function

#Region "Expose Properties"
    Public ReadOnly Property PID As String
        Get
            Return _mstrPID
        End Get
    End Property

    Public ReadOnly Property UserID As String
        Get
            Return _mstrUserID
        End Get
    End Property

    Public ReadOnly Property SecRole As String
        Get
            Return _mstrSecRole
        End Get
    End Property

#End Region

#Region "Security Role Methods"
    Public Function IsAdmin() As Boolean
        Return _mstrSecRole = ADMIN
    End Function

    Public Function IsOfficer() As Boolean
        Return _mstrSecRole = OFFICER
    End Function

    Public Function IsMember() As Boolean
        Return _mstrSecRole = MEMBER
    End Function

    Public Function IsGuest() As Boolean
        Return _mstrSecRole = GUEST
    End Function

    Public Function HasSecRole(strSecRole As String) As Boolean
        Return _mstrSecRole = strSecRole
    End Function
#End Region

End Class
