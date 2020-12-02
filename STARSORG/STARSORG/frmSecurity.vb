Imports System.Data.SqlClient

Public Class frmSecurity
    Private objSecurities As CSecurities
    Private strSecurityAction As String = ""

#Region "Toolbar Stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvent.MouseEnter,
        tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogout.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter,
        tsbSemester.MouseEnter, tsbTutor.MouseEnter, tsbSecurity.MouseEnter
        'We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        ToolStripMouseEnter(sender)
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvent.MouseLeave,
        tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogout.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave,
        tsbSemester.MouseLeave, tsbTutor.MouseLeave, tsbSecurity.MouseLeave
        'We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        ToolStripMouseLeave(sender)
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvents_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        intNextAction = ACTION_EVENT
        Me.Hide()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        Me.Hide()
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub
    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbSecurity.Click
        'No action needed as we already on security page
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

    Private Sub tsbTutor_Click(sender As Object, e As EventArgs) Handles tsbTutor.Click
        intNextAction = ACTION_TUTOR
        Me.Hide()
    End Sub
#End Region

#Region "Textboxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtPID.GotFocus, txtUserID.GotFocus, txtPassword.GotFocus,
        txtPasswordConfirm.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtPID.LostFocus, txtUserID.LostFocus, txtPassword.LostFocus,
            txtPasswordConfirm.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region

#Region "Supported Security Actions"
    Private Const ADD_USER As String = "Add User"
    Private Const UPDATE_ROLE As String = "Update Security Role"
    Private Const RESET_PASSWORD As String = "Reset Password"
    Private Const NO_ACTION As String = ""
#End Region

    Private Sub frmSecurity_Load(sender As Object, e As EventArgs) Handles Me.Load
        objSecurities = New CSecurities
    End Sub

    Private Sub frmSecurity_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadComboBoxes()
        ClearScreenControls(Me)
        LoadUsers()
        grpManageUser.Enabled = False
    End Sub

    Private Sub LoadComboBoxes()
        If cboActions.Items.Count = 0 Then
            cboActions.Items.Add(ADD_USER)
            cboActions.Items.Add(UPDATE_ROLE)
            cboActions.Items.Add(RESET_PASSWORD)
        End If

        If cboSecRole.Items.Count = 0 Then
            cboSecRole.Items.Add(ADMIN)
            cboSecRole.Items.Add(OFFICER)
            cboSecRole.Items.Add(MEMBER)
            cboSecRole.Items.Add(GUEST)
        End If
    End Sub

    Private Sub LoadUsers()
        Dim objDR As SqlDataReader
        Dim strFullName As String
        Dim strFirstCharacter As String
        Dim strUserID As String

        tvwUsers.Nodes.Clear()

        Try
            objDR = objSecurities.GetAllSecurities()

            Do While objDR.Read
                Dim parentNode() As TreeNode

                strUserID = objDR("UserID")
                strFullName = StrConv(objDR.Item("FNAME"), vbProperCase) & ", " & StrConv(objDR.Item("LNAME"), vbProperCase) & "<" & strUserID & ">"
                strFirstCharacter = strFullName.Substring(0, 1)

                parentNode = tvwUsers.Nodes.Find(strFirstCharacter, True)

                If parentNode.Length > 0 Then
                    parentNode(0).Nodes.Add(strUserID, strFullName)
                Else
                    Dim newParentNode As TreeNode
                    newParentNode = tvwUsers.Nodes.Add(strFirstCharacter, strFirstCharacter)
                    newParentNode.Nodes.Add(strUserID, strFullName)
                End If
            Loop

            objDR.Close()

            If objSecurities.CurrentObject.UserID <> "" Then
                Dim currentNode() As TreeNode
                currentNode = tvwUsers.Nodes.Find(objSecurities.CurrentObject.UserID, True)

                If currentNode.Length > 0 Then
                    tvwUsers.SelectedNode = currentNode(0)
                End If
            End If

            tvwUsers.ExpandAll()
            tvwUsers.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error occured while loading users " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tvwUsers_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwUsers.NodeMouseClick
        Dim userNode As TreeNode = DirectCast(e.Node, TreeNode)
        LoadSelectedUser(userNode.Name)
    End Sub

    Private Sub LoadSelectedUser(strUserId As String)
        Try
            objSecurities.GetSecurityByUserID(strUserId)

            With objSecurities.CurrentObject
                txtPID.Text = .PID
                txtUserID.Text = .UserID
                cboSecRole.SelectedItem = .SecRole
            End With
        Catch ex As Exception
            MessageBox.Show("Error while loading user: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboActions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActions.SelectedIndexChanged
        Dim cboSelectedAction As ComboBox
        Dim strSelectedAction As String
        cboSelectedAction = DirectCast(sender, ComboBox)

        If cboSelectedAction.SelectedIndex <> -1 Then
            strSelectedAction = cboSelectedAction.SelectedItem.ToString
        Else
            strSelectedAction = NO_ACTION
        End If

        If strSelectedAction = strSecurityAction Then
            MessageBox.Show("Existing Sub " & strSecurityAction & strSecurityAction)
            Exit Sub
        End If

        strSecurityAction = strSelectedAction

        UpdateManageUserForm()
    End Sub

    Private Sub UpdateManageUserForm()
        Select Case strSecurityAction
            Case ADD_USER
                grpManageUser.Enabled = True
                grpUsers.Enabled = False
                ClearScreenControls(grpManageUser)
                txtPID.Enabled = True
                txtUserID.Enabled = True
                cboSecRole.Enabled = True
                cboSecRole.SelectedIndex = -1
                txtPassword.Enabled = True
                txtPasswordConfirm.Enabled = True
            Case UPDATE_ROLE
                grpManageUser.Enabled = True
                grpUsers.Enabled = True
                txtPID.Enabled = False
                txtUserID.Enabled = True
                cboSecRole.Enabled = True
                txtPassword.Enabled = False
                txtPasswordConfirm.Enabled = False
            Case RESET_PASSWORD
                grpManageUser.Enabled = True
                grpUsers.Enabled = True
                txtPID.Enabled = False
                txtUserID.Enabled = True
                cboSecRole.Enabled = False
                cboSecRole.SelectedIndex = -1
                txtPassword.Enabled = True
                txtPasswordConfirm.Enabled = True
            Case NO_ACTION
                ClearScreenControls(grpManageUser)
                grpManageUser.Enabled = False
                grpUsers.Enabled = True
            Case Else
                MessageBox.Show("Invalid security action selected : " & strSecurityAction, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        tslStatus.Text = ""

        If Not AuthUser.IsAdmin() Then
            MessageBox.Show("Access Denied : You dont have the required credentials to perform this action", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Access Denied : You dont have the required credentials to perform this action"
            Exit Sub
        End If

        If ValidateSecurityForm() Then
            Exit Sub
        End If

        Select Case strSecurityAction
            Case ADD_USER
                AddUser()
            Case UPDATE_ROLE
                UpdateRole()
            Case RESET_PASSWORD
                ResetPassword()
            Case Else
                MessageBox.Show("Invalid security action selected", "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Function ValidateSecurityForm() As Boolean
        Dim blnErrors As Boolean = False

        errP.Clear()

        If Not ValidateTextBoxLength(txtUserID, errP) Then
            blnErrors = True
        End If

        Select Case strSecurityAction
            Case ADD_USER
                If Not ValidateTextBoxLength(txtPID, errP) Then
                    blnErrors = True
                End If

                If Not ValidateCombo(cboSecRole, errP) Then
                    blnErrors = True
                End If

                If Not ValidateTextBoxLength(txtPassword, errP) Then
                    blnErrors = True
                End If

                If Not ValidateTextBoxLength(txtPasswordConfirm, errP) Then
                    blnErrors = True
                End If

                If txtPassword.Text <> txtPasswordConfirm.Text Then
                    blnErrors = True
                    errP.SetError(txtPasswordConfirm, "The password confirmation does not match")
                End If
            Case RESET_PASSWORD
                If Not ValidateTextBoxLength(txtPassword, errP) Then
                    blnErrors = True
                End If

                If Not ValidateTextBoxLength(txtPasswordConfirm, errP) Then
                    blnErrors = True
                End If

                If txtPassword.Text <> txtPasswordConfirm.Text Then
                    blnErrors = True
                    errP.SetError(txtPasswordConfirm, "The password confirmation does not match")
                End If
            Case UPDATE_ROLE
                If Not ValidateCombo(cboSecRole, errP) Then
                    blnErrors = True
                End If
            Case Else
        End Select

        Return blnErrors
    End Function

    Private Sub ResetPassword()
        Dim intResetPasswordResult As Integer

        With objSecurities.CurrentObject
            .UserID = txtUserID.Text
            .Password = txtPassword.Text
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            intResetPasswordResult = objSecurities.ResetPassword()

            If intResetPasswordResult = 1 Then
                cboActions.SelectedIndex = -1
                tslStatus.Text = "Password for user " & objSecurities.CurrentObject.UserID & " reset successfully"
            Else
                MessageBox.Show("Password reset failed for user " & objSecurities.CurrentObject.UserID, "Reset Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Password reset failed"
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to reset user password : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Unable to reset user password"
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UpdateRole()
        Dim intUpdateRoleResult As Integer

        With objSecurities.CurrentObject
            .UserID = txtUserID.Text
            .SecRole = cboSecRole.SelectedItem.ToString
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            intUpdateRoleResult = objSecurities.UpdateRole()

            If intUpdateRoleResult = 1 Then
                cboActions.SelectedIndex = -1
                tslStatus.Text = "User security role updated successfully"
            Else
                MessageBox.Show("Security role update failed for user " & objSecurities.CurrentObject.UserID, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Security role update failed"
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to update user security role : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Unable to update user security role"
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AddUser()
        Dim intAddUserResult As Integer

        With objSecurities.CurrentObject
            .PID = txtPID.Text
            .UserID = txtUserID.Text
            .SecRole = cboSecRole.SelectedItem.ToString
            .Password = txtPassword.Text
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            intAddUserResult = objSecurities.Save()

            If intAddUserResult = 1 Then
                tslStatus.Text = "User added successfully"
                cboActions.SelectedIndex = -1
                LoadUsers()
            ElseIf intAddUserResult = -2 Then
                MessageBox.Show("No member exists with the supplied Panther ID", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "No member exists with the supplied Panther ID"
            ElseIf intAddUserResult = -3 Then
                MessageBox.Show("There is an existing user with the same user id", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "There is an existing user with the same user id"
            ElseIf intAddUserResult = -4 Then
                MessageBox.Show("There is an existing user with the same panther id", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "There is an existing user with the same panther id"
            Else
                MessageBox.Show("Addition of new user failed", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Addition of new user failed"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to add new user : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Unable to add new user"
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cboActions.SelectedIndex = -1
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim SecurityReport As New frmSecurityReport
        If tvwUsers.Nodes.Count = 0 Then
            MessageBox.Show("There are no security records to print")
        End If

        SecurityReport.Display()
    End Sub
End Class