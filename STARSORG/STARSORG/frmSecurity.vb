Imports System.Data.SqlClient

Public Class frmSecurity
    Private objSecurities As CSecurities

#Region "Toolbar Stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvents.MouseEnter,
        tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogout.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter,
        tsbSemester.MouseEnter, tsbTutor.MouseEnter, tsbSecurity.MouseEnter
        'We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        ToolStripMouseEnter(sender)
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvents.MouseLeave,
        tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogout.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave,
        tsbSemester.MouseLeave, tsbTutor.MouseLeave, tsbSecurity.MouseLeave
        'We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        ToolStripMouseLeave(sender)
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvents_Click(sender As Object, e As EventArgs) Handles tsbEvents.Click
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
    Private Const EDIT_USER As String = "Update Security Role"
    Private Const RESET_PASSWORD As String = "Reset Password"
#End Region

#Region "Supported Security Roles"
    Private Const ADMIN As String = "ADMIN"
    Private Const OFFICER As String = "OFFICER"
    Private Const MEMBER As String = "MEMBER"
    Private Const GUEST As String = "GUEST"
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
            cboActions.Items.Add(EDIT_USER)
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
End Class