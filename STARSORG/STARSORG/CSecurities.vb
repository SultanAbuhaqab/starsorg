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
            FillSecurityObject(objDR.Item("PID"), objDR.Item("UserID"), objDR.Item("SecRole"))
        End If
        objDR.Close()
        Return _Security
    End Function

    Private Sub FillSecurityObject(strPID As String, strUserID As String, strSecRole As String)
        With _Security
            .PID = strPID
            .UserID = strUserID
            .SecRole = strSecRole
            'We wont fill the password when retrieving since normally the password is 
            'usually hashed and wont be relevant in its hashed format
        End With
    End Sub

    Public Function LoginUser(strUserID As String, strPassword As String) As Integer
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
        FillSecurityObject(objDR.Item("PID"), objDR.Item("UserID"), objDR.Item("SecRole"))
        objDR.Close()
        SaveAuthUser()

        Return 1

    End Function

    Public Function LoginGuest() As Integer
        FillSecurityObject(GUEST_MEMBER_PID, GUEST_USER_ID, GUEST)
        SaveAuthUser()

        Return 1
    End Function

    Private Sub SaveAuthUser()
        With _Security
            AuthUser.Save(.PID, .UserID, .SecRole)
        End With
    End Sub
End Class
