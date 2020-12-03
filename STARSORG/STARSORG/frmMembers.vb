Imports System.Data.SqlClient
Public Class frmMembers
    Private objMembers As CMembers
    Private blnClearing As Boolean
    Private blnReloading As Boolean
#Region "Toolbar Stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) 
        ' We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) 
        ' We need to do this only because we are not putting our images in the Image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvents_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_EVENT
        Me.Hide()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbLogOut_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) 
        ' Nothing to do here, because we are on this form
        ' Copy and modify to respective 
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

    Private Sub tsbTutor_Click(sender As Object, e As EventArgs) 
        intNextAction = ACTION_TUTOR
        Me.Hide()
    End Sub
#End Region

#Region "Textboxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtPID.GotFocus, txtFName.GotFocus, txtLName.GotFocus, txtMI.GotFocus, txtEmail.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtPID.LostFocus, txtFName.LostFocus, txtLName.LostFocus, txtMI.LostFocus, txtEmail.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region

    Private Sub LoadMembers()
        Dim objReader As SqlDataReader
        lstMembers.Items.Clear()
        Try
            objReader = objMembers.GetAllMembers
            Do While objReader.Read
                lstMembers.Items.Add(objReader.Item("PID") & " - " & objReader.Item("FName") & " " & objReader.Item("LName"))
            Loop
            objReader.Close()
        Catch ex As Exception
            ' CBD might throw the error and trap it here
        End Try
        If objMembers.CurrentObject.PID <> "" Then
            lstMembers.SelectedIndex = lstMembers.FindStringExact(objMembers.CurrentObject.PID)
        End If
        blnReloading = False
    End Sub

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles Me.Load
        objMembers = New CMembers
    End Sub

    Private Sub frmMembers_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadMembers()
        pbMember.Image = Nothing
        ' This form is accesed by users with appropriate permissions only.
        ' They can edit member information as they desire
        ' grpMemberInfo.Enabled = False
    End Sub

    Private Sub lstMembers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If blnReloading Then
            tslStatus.Text = ""
            Exit Sub
        End If
        If lstMembers.SelectedIndex = -1 Then
            Exit Sub
        End If
        ' chkNew.Checked = False
        LoadSelectedMember() ' Have to update with search implementation
        ' grpMemberInfo.Enabled = True
    End Sub
    Private Sub LoadSelectedMember()
        Try
            objMembers.GetMemberByPID(lstMembers.SelectedItem.ToString)
            With objMembers.CurrentObject
                txtPID.Text = .PID
                txtFName.Text = .FName
                txtLName.Text = .LName
                txtMI.Text = .MI
                txtEmail.Text = .Email
                mtbPhone.Text = .Phone
                ' UPDATE LOAD PATH BEFORE RELEASE - ASK PROFESSOR
                pbMember.Load("G:\My Drive\Academics\Fall 2020\COP 4005 - Win Prog IT\project-amota012\STARTSOrg\STARTSOrg\Resources" & .PhotoPath)
                pbMember.SizeMode = PictureBoxSizeMode.StretchImage

            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Member values: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Pending checking new member info is being added (chkNew_CheckChanged)
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        tslStatus.Text = ""
        ' ----- add your validation code here -----
        If Not ValidateTextBoxLength(txtPID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtFName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtMI, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        ' Verify mtbPhone validation (below) with the professor
        If Not ValidateMaskedTextBoxLength(mtbPhone, errP) Then
            blnErrors = True
        End If
        ' MISSING Picture Location (Path) validation | Less than or equal to 300
        If blnErrors Then
            Exit Sub
        End If
        With objMembers.CurrentObject
            .PID = txtPID.Text
            .FName = txtFName.Text
            .LName = txtLName.Text
            .MI = txtMI.Text
            .Email = txtEmail.Text
            .Phone = mtbPhone.Text
            .PhotoPath = pbMember.ImageLocation.ToString.Remove(0, 101)
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objMembers.Save()
            If intResult = 1 Then
                tslStatus.Text = "Member record saved"
                ' Create record for MEMBER_ROLE
            End If
            If intResult = -1 Then ' Member PID was not unique when addind a new record
                MessageBox.Show("PID must be unique. Unable to save Member record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save Member record:" & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadMembers() ' Reload so that a newly saved record will appear in the list
        'chkNew.Checked = False
        'grpRoles.Enabled = True ' In case it was disabled for a new record
    End Sub


End Class