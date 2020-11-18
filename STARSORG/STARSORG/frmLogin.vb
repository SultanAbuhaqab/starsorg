Imports System.Data.SqlClient

Public Class frmLogin
    Private objSecurities As CSecurities

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
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim blnErrors As Boolean
        Dim intLoginResult As Integer
        Dim strAuditPatherID As String

        If Not ValidateTextBoxLength(txtUserID, errP) Then
            blnErrors = True
        End If

        If Not ValidateTextBoxLength(txtPassword, errP) Then
            blnErrors = True
        End If

        If blnErrors Then
            Exit Sub
        End If

        intLoginResult = objSecurities.LoginUser(txtUserID.Text, txtPassword.Text)




    End Sub
End Class