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
            FillSecurityObject(objDR.Item("PID"), objDR.Item("UserID"), objDR.Item("Password"), objDR.Item("SecRole"))
        End If
        objDR.Close()
        Return _Security
    End Function

    Private Sub FillSecurityObject(strPID As String, strUserID As String, strPassword As String, strSecRole As String)
        With _Security
            .PID = strPID
            .UserID = strUserID
            .SecRole = strSecRole
            .Password = strPassword
        End With
    End Sub

    Public Function LoginUser(strUserID As String, strPassword As String) As Integer
        Dim intValidateResult As Integer

        intValidateResult = ValidateUserPassword(strUserID, strPassword)

        If intValidateResult = 1 Then
            SaveAuthUser()
        End If

        Return intValidateResult

    End Function

    Private Function ValidateUserPassword(strUserID As String, strPassword As String) As Integer
        Dim params As New ArrayList
        Dim objDR As SqlDataReader

        params.Add(New SqlParameter("UserID", strUserID))
        objDR = myDB.GetDataReaderBySP("sp_getSecurityByUserID", params)

        If Not objDR.Read Then
            objDR.Close()
            Return -1   'No security record found by the supplied user id
        End If

        If objDR.Item("Password") <> strPassword Then
            objDR.Close()
            Return 0    'Password provided doesnt match the users password
        End If

        'Password matches the users saved password
        FillSecurityObject(objDR.Item("PID"), objDR.Item("UserID"), objDR.Item("Password"), objDR.Item("SecRole"))
        objDR.Close()

        Return 1
    End Function

    Public Function LoginGuest() As Integer
        FillSecurityObject(GUEST_MEMBER_PID, GUEST_USER_ID, "", GUEST)
        SaveAuthUser()

        Return 1
    End Function

    Private Sub SaveAuthUser()
        With _Security
            AuthUser.Save(.PID, .UserID, .SecRole)
        End With
    End Sub

    Public Function ChangePassword(strUserID As String, strOldPassword As String, strNewPassword As String) As Integer
        Dim intValidateResult As Integer

        intValidateResult = ValidateUserPassword(strUserID, strOldPassword)

        If intValidateResult <> 1 Then
            Return intValidateResult
        End If

        'Save the new password
        _Security.Password = strNewPassword
        Return _Security.UpdatePassword()
    End Function

    Public Function ResetPassword() As Integer
        Return _Security.UpdatePassword()
    End Function

    Public Function UpdateRole() As Integer
        Return _Security.UpdateRole()
    End Function

    Public Function Save() As Integer
        Return _Security.Save()
    End Function
End Class
