Module modGlobal
    'Contains all variables, constants, procedures and functions
    'that need to be accessed in more than one form

#Region "Action Constants"
    Public Const ACTION_NONE As Integer = 0
    Public Const ACTION_HOME As Integer = 1
    Public Const ACTION_MEMBER As Integer = 2
    Public Const ACTION_ROLE As Integer = 3
    Public Const ACTION_EVENT As Integer = 4
    Public Const ACTION_RSVP As Integer = 5
    Public Const ACTION_COURSE As Integer = 6
    Public Const ACTION_SEMESTER As Integer = 7
    Public Const ACTION_TUTOR As Integer = 8
    Public Const ACTION_HELP As Integer = 9
    Public Const ACTION_LOGOUT As Integer = 10
    Public Const ACTION_SECURITY As Integer = 11
<<<<<<< Updated upstream
=======
    Public Const ACTION_LOGIN As Integer = 12
    Public Const ACTION_EXIT As Integer = 13
>>>>>>> Stashed changes
#End Region

#Region "Supported Security Roles"
    Public Const ADMIN As String = "ADMIN"
    Public Const OFFICER As String = "OFFICER"
    Public Const MEMBER As String = "MEMBER"
    Public Const GUEST As String = "GUEST"
#End Region

#Region "Default Member Panther IDs"
    Public Const GUEST_MEMBER_PID As String = "0000001"
    Public Const UNSUCCESSFUL_LOGIN_MEMBER_PID As String = "9999999"
#End Region

    Public Const GUEST_USER_ID As String = "guest"
    Public intNextAction As Integer
    Public myDB As New CDB
    Public AuthUser As New CAuthUser

#Region "Toolbar Stuff"
    Public Sub ToolStripMouseEnter(sender As Object)
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Public Sub ToolStripMouseLeave(sender As Object)
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub
#End Region

#Region "Valid Semester IDs"
    Public Const fa16 As String = "fa16"
    Public Const fa17 As String = "fa17"
    Public Const sp17 As String = "sp17"
    Public Const su17 As String = "su17"
#End Region

End Module
