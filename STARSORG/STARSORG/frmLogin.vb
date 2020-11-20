Imports System.Data.SqlClient

Public Class frmLogin
    Private objSecurities As CSecurities
    Private objAudits As CAudits

#Region "Textboxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtUserID.GotFocus, txtPassword.GotFocus,
        txtChangePasswordUserID.GotFocus, txtOldPassword.GotFocus, txtNewPassword.GotFocus, txtConfirmPassword.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus, txtPassword.LostFocus,
        txtChangePasswordUserID.LostFocus, txtOldPassword.LostFocus, txtNewPassword.LostFocus, txtConfirmPassword.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        objSecurities = New CSecurities
        objAudits = New CAudits
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim blnErrors As Boolean
        Dim intLoginResult As Integer
        Dim strAuditPatherID As String
        Dim blnLoginSuccess As Boolean

        If Not ValidateTextBoxLength(txtUserID, errP) Then
            blnErrors = True
        End If

        If Not ValidateTextBoxLength(txtPassword, errP) Then
            blnErrors = True
        End If

        If blnErrors Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            intLoginResult = objSecurities.LoginUser(txtUserID.Text, txtPassword.Text)

            If intLoginResult = 1 Then
                strAuditPatherID = AuthUser.PID
                blnLoginSuccess = True
            Else
                strAuditPatherID = UNSUCCESSFUL_LOGIN_MEMBER_PID
                blnLoginSuccess = False
            End If

            With objAudits.CurrentObject
                .PID = strAuditPatherID
                .AccessTimestamp = DateTime.Now
                .Success = blnLoginSuccess
            End With

            objAudits.Save()

        Catch ex As Exception
            MessageBox.Show("Unable to login user : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Default

        If blnLoginSuccess Then
            Me.Close()
        Else
            MessageBox.Show("The UserID or Password is incorrect", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class