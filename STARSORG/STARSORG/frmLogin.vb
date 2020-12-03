Imports System.Data.SqlClient

Public Class frmLogin
    Private objSecurities As CSecurities
    Private objAudits As CAudits
    Private MainForm As frmMain

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

        errP.Clear()

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
            txtUserID.Clear()
            txtPassword.Clear()
            intNextAction = ACTION_HOME
            Me.Close()
        Else
            MessageBox.Show("The UserID or Password is incorrect", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnGuestLogin_Click(sender As Object, e As EventArgs) Handles btnGuestLogin.Click
        Dim intLoginResult As Integer

        Try
            Me.Cursor = Cursors.WaitCursor()

            intLoginResult = objSecurities.LoginGuest()

            With objAudits.CurrentObject
                .PID = objSecurities.CurrentObject.PID
                .AccessTimestamp = DateTime.Now
                .Success = True
            End With

            objAudits.Save()
        Catch ex As Exception
            MessageBox.Show("Unable to login user : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If intLoginResult = 1 Then
            intNextAction = ACTION_HOME
            Me.Close()
        Else
            MessageBox.Show("Failed to login as guest", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim blnErrors As Boolean
        Dim intChangePasswordResult As Integer

        errP.Clear()

        If Not ValidateTextBoxLength(txtChangePasswordUserID, errP) Then
            blnErrors = True
        End If

        If Not ValidateTextBoxLength(txtOldPassword, errP) Then
            blnErrors = True
        End If

        If Not ValidateTextBoxLength(txtNewPassword, errP) Then
            blnErrors = True
        End If

        If Not ValidateTextBoxLength(txtConfirmPassword, errP) Then
            blnErrors = True
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            blnErrors = True
            errP.SetError(txtConfirmPassword, "The password confirmation does not match")
        End If

        If blnErrors Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            intChangePasswordResult = objSecurities.ChangePassword(txtChangePasswordUserID.Text, txtOldPassword.Text, txtNewPassword.Text)

            If intChangePasswordResult = 1 Then
                MessageBox.Show("You have successfully changed your password", "Change Password Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Clear the controls
                txtChangePasswordUserID.Clear()
                txtOldPassword.Clear()
                txtNewPassword.Clear()
                txtConfirmPassword.Clear()

                'Give focus to the login text box
                txtUserID.Focus()
            Else
                MessageBox.Show("Change password failed, The UserID or Password is incorrect", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to change user password : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        intNextAction = ACTION_EXIT
        Me.Close()
    End Sub
End Class