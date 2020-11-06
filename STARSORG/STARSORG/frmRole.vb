Imports System.Data.SqlClient

Public Class frmRole
    Private objRoles As CRoles
    Private blnClearing As Boolean
    Private blnReloading As Boolean

#Region "Toolbar Stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvents.MouseEnter,
        tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogout.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter,
        tsbSemester.MouseEnter, tsbTutor.MouseEnter
        'We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        frmMain.ToolStripMouseEnter(sender)
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvents.MouseLeave,
        tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogout.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave,
        tsbSemester.MouseLeave, tsbTutor.MouseLeave
        'We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        frmMain.ToolStripMouseLeave(sender)
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
        'No action needed - We are already on te ROLE form
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
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

    Private Sub LoadRoles()
        Dim objDR As SqlDataReader
        lstRoles.Items.Clear()

        Try
            objDR = objRoles.GetAllRoles()
            Do While objDR.Read
                lstRoles.Items.Add(objDR.Item("RoleID"))
            Loop
            objDR.Close()
        Catch ex As Exception
            MessageBox.Show("Error occured while loading roles " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If objRoles.CurrentObject.RoleID <> "" Then
            lstRoles.SelectedIndex = lstRoles.FindStringExact(objRoles.CurrentObject.RoleID)
        End If

        blnReloading = False
    End Sub

    Private Sub frmRole_Load(sender As Object, e As EventArgs) Handles Me.Load
        objRoles = New CRoles
    End Sub

    Private Sub frmRole_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadRoles()
        grpEdit.Enabled = False
    End Sub

    Private Sub lstRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRoles.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If

        If blnReloading Then
            Exit Sub
        End If

        If lstRoles.SelectedIndex = -1 Then
            Exit Sub
        End If

        chkNew.Checked = False

        LoadSelectedRecord()
        grpEdit.Enabled = True
    End Sub

    Private Sub LoadSelectedRecord()
        Try
            objRoles.GetRoleByRoleID(lstRoles.SelectedItem.ToString)
            With objRoles.CurrentObject
                txtRoleID.Text = .RoleID
                txtDesc.Text = .RoleDescription
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading role values: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If

        If chkNew.Checked Then
            tslStatus.Text = ""
            txtRoleID.Clear()
            txtDesc.Clear()
            lstRoles.SelectedIndex = -1
            grpRoles.Enabled = False
            grpEdit.Enabled = True
            txtRoleID.Focus()
            objRoles.CreateNewRole()
        Else
            grpRoles.Enabled = False
            grpEdit.Enabled = True
            objRoles.CurrentObject.IsNewRole = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        tslStatus.Text = ""
        'Add your validation here

        If Not ValidateTextBoxLength(txtRoleID, errP) Then
            blnErrors = True
        End If

        If Not ValidateTextBoxLength(txtDesc, errP) Then
            blnErrors = True
        End If

        If blnErrors Then
            Exit Sub
        End If

        With objRoles.CurrentObject
            .RoleID = txtRoleID.Text
            .RoleDescription = txtDesc.Text
        End With

        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objRoles.Save()

            If intResult = 1 Then
                tslStatus.Text = "Role record saved"
            End If
            If intResult = -1 Then 'Rold ID was not unique when adding a new record
                MessageBox.Show("Role ID must be unique, Unable to save role record", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class