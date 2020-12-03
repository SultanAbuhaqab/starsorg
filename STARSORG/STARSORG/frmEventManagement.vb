Imports System.Data.SqlClient
Public Class frmEventManagement
    Private objEvents As CEvents
    Private blnReloading As Boolean
    Private blnClearing As Boolean
    Private RSVPReport As frmReportEventRSVPs
#Region "Toolbar stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogOut.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter, tsbTutor.MouseEnter, tsbSecurity.MouseEnter
        'We need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogOut.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave, tsbTutor.MouseLeave, tsbSecurity.MouseLeave
        'We need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        'no action needed - we are alreadt in this form
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbLogOut_Click(sender As Object, e As EventArgs) Handles tsbLogOut.Click
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        Me.Hide()
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        If Not AuthUser.IsAdmin() And Not AuthUser.IsOfficer() Then
            MessageBox.Show("Access Denied : You dont have the required credentials to access this page", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intNextAction = ACTION_ROLE
        Me.Hide()
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

    Private Sub tsbSecurity_Click(sender As Object, e As EventArgs) Handles tsbSecurity.Click
        If Not AuthUser.IsAdmin() Then
            MessageBox.Show("Access Denied : You dont have the required credentials to access this page", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        intNextAction = ACTION_SECURITY
        Me.Hide()
    End Sub
#End Region

#Region "Textboxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtEventID.GotFocus, txtEventDescription.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtEventID.LostFocus, txtEventDescription.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region

    Private Sub frmEventManagement_Load(sender As Object, e As EventArgs) Handles Me.Load
        objEvents = New CEvents
    End Sub

    Private Sub frmEventManagement_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        dtpEventStartDate.Value = Today()
        dtpEventEndDate.Value = Today()
        LoadEvents()
        LoadComboOptions()
        SetInputFieldsToUpdateMode()
    End Sub

    Private Sub LoadComboOptions()
        If cboEventTypeID.Items.Count = 0 Then
            cboEventTypeID.Items.Add(eBoard_Mtg)
            cboEventTypeID.Items.Add(Gen_Mtg)
            cboEventTypeID.Items.Add(Outreach)
            cboEventTypeID.Items.Add(RISE_Mtg)
            cboEventTypeID.Items.Add(Special)
        End If

        If cboSemesterID.Items.Count = 0 Then
            cboSemesterID.Items.Add(fa16)
            cboSemesterID.Items.Add(fa17)
            cboSemesterID.Items.Add(sp17)
            cboSemesterID.Items.Add(su17)
        End If
    End Sub

    Private Sub SetInputFieldsToUpdateMode()
        sslStatus.Text = "Select an event from the list to update"
        grpEvents.Enabled = True
        grpEdit.Enabled = True
        txtEventID.Enabled = False
        txtEventDescription.Enabled = True
        txtLocation.Enabled = True
        cboEventTypeID.Enabled = True
        cboSemesterID.Enabled = True
        dtpEventStartDate.Enabled = True
        dtpEventEndDate.Enabled = True
        objEvents.CurrentObject.IsNewEvent = False
    End Sub

    Private Sub SetInputFieldsToNewMode()
        sslStatus.Text = "Fill out the details for the new event"
        ClearScreenControls(grpEdit)
        grpEvents.Enabled = False
        grpEdit.Enabled = True
        ClearScreenControls(grpEdit)
        txtEventID.Focus()
        txtEventID.Enabled = True
        txtEventDescription.Enabled = True
        txtLocation.Enabled = True
        cboEventTypeID.Enabled = True
        cboSemesterID.Enabled = True
        dtpEventStartDate.Enabled = True
        dtpEventEndDate.Enabled = True
        dtpEventStartDate.Value = Today()
        dtpEventEndDate.Value = Today()
        objEvents.CreateNewEvent()
        objEvents.CurrentObject.IsNewEvent = True
    End Sub

    Private Sub VerifyEventDateBR()
        If dtpEventEndDate.Value < Today() Then
            txtEventDescription.Enabled = False
            txtLocation.Enabled = False
            cboSemesterID.Enabled = False
            dtpEventStartDate.Enabled = False
            dtpEventEndDate.Enabled = False
        Else
            txtEventDescription.Enabled = True
            txtLocation.Enabled = True
            cboEventTypeID.Enabled = True
            cboSemesterID.Enabled = True
            dtpEventStartDate.Enabled = True
            dtpEventEndDate.Enabled = True
        End If
    End Sub
    Private Sub LoadEvents()
        Dim objDR As SqlDataReader
        Dim strEventOverview As String
        Dim strEventID As String
        Dim strEventType As String

        tvwEvents.Nodes.Clear()

        Try
            objDR = objEvents.GetAllEvents()

            Do While objDR.Read
                Dim parentNode() As TreeNode

                strEventID = objDR("EventID")
                strEventType = "Event Type: " & StrConv(objDR.Item("EventTypeID"), vbProperCase)
                strEventOverview = "Location: " & StrConv(objDR.Item("Location"), vbProperCase) & " | " & "Event Description: " & StrConv(objDR.Item("EventDescription"), vbProperCase) & " | " & "Start Date: " & StrConv(objDR.Item("StartDate"), vbProperCase) & " | " & "End date: " & StrConv(objDR.Item("EndDate"), vbProperCase)

                parentNode = tvwEvents.Nodes.Find(strEventType, True)

                If parentNode.Length > 0 Then
                    parentNode(0).Nodes.Add(strEventID, strEventOverview)
                Else
                    Dim newParentNode As TreeNode
                    newParentNode = tvwEvents.Nodes.Add(strEventType, strEventType)
                    newParentNode.Nodes.Add(strEventID, strEventOverview)
                    'tvwEvents.Nodes.Add(strEventID, strEventOverview)
                End If
            Loop

            objDR.Close()

            If objEvents.CurrentObject.EventID <> "" Then
                Dim currentNode() As TreeNode
                currentNode = tvwEvents.Nodes.Find(objEvents.CurrentObject.EventID, True)

                If currentNode.Length > 0 Then
                    tvwEvents.SelectedNode = currentNode(0)
                End If
            End If

            tvwEvents.ExpandAll()
            tvwEvents.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error occured while loading events " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tvwEvents_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwEvents.NodeMouseClick
        Dim eventNode As TreeNode = DirectCast(e.Node, TreeNode)
        LoadSelectedEvent(eventNode.Name)
        'MessageBox.Show(eventNode.Name & "Append Click")
        SetInputFieldsToUpdateMode()
        VerifyEventDateBR()
    End Sub

    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If

        If chkNew.Checked Then
            SetInputFieldsToNewMode()
        Else
            SetInputFieldsToUpdateMode()
        End If
    End Sub

    Private Sub LoadSelectedEvent(strEventID As String)
        objEvents.CurrentObject.IsNewEvent = False
        Try
            objEvents.GetEventByID(strEventID)
            'MessageBox.Show(objEvents.CurrentObject.EventDescription & "Retrieved")

            With objEvents.CurrentObject
                txtEventID.Text = .EventID
                txtEventDescription.Text = .EventDescription
                txtLocation.Text = .Location
                cboEventTypeID.SelectedItem = .EventTypeID
                cboSemesterID.SelectedItem = .SemesterID
                dtpEventStartDate.Value = .StartDate
                dtpEventEndDate.Value = .EndDate

            End With
        Catch ex As Exception
            MessageBox.Show("Error while loading event: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Dim intResult As Integer
        Dim blnErrors As Boolean
        sslStatus.Text = ""
        errP.Clear()

        If Not modErrHandler.ValidateTextBoxLength(txtEventDescription, errP) Then
            blnErrors = True
        End If
        For Each character In txtLocation.Text
            If IsNumeric(character) Then
                errP.SetError(txtLocation, "Error, you cannot put digits here.")
                blnErrors = True
            End If
            If blnErrors Then
                Exit Sub
            End If
        Next

        'if we get this far, all of the input data is acceptable

        If chkNew.Checked Then
            AddEvent()
        Else
            UpdateEvent()
        End If

        blnReloading = True
        LoadEvents()
        chkNew.Checked = False
        grpEdit.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        ClearScreenControls(grpEdit)
        SetInputFieldsToUpdateMode()
        dtpEventStartDate.Value = Today()
        dtpEventEndDate.Value = Today()
        chkNew.Checked = False
        errP.Clear()

        blnClearing = False
        grpEvents.Enabled = True
    End Sub

    Private Sub AddEvent()
        Dim intAddEventResult As Integer

        With objEvents.CurrentObject
            .EventID = txtEventID.Text
            .EventDescription = txtEventDescription.Text
            .EventTypeID = cboEventTypeID.Text
            .SemesterID = cboSemesterID.Text
            .StartDate = dtpEventStartDate.Text
            .EndDate = dtpEventEndDate.Text
            .Location = txtLocation.Text
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            intAddEventResult = objEvents.Save()

            If intAddEventResult = 1 Then
                sslStatus.Text = "Event added successfully"
            ElseIf intAddEventResult = -1 Then
                MessageBox.Show("There is an existing event with the same event ID", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sslStatus.Text = "There is an existing event with the same event ID"
            Else
                MessageBox.Show("Addition of new event failed", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sslStatus.Text = "Addition of new Event failed"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to add new Event: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sslStatus.Text = "Unable to add new Event"
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UpdateEvent()
        Dim intUpdateEventResult As Integer

        With objEvents.CurrentObject
            .EventID = txtEventID.Text
            .EventDescription = txtEventDescription.Text
            .EventTypeID = cboEventTypeID.Text
            .SemesterID = cboSemesterID.Text
            .StartDate = dtpEventStartDate.Text
            .EndDate = dtpEventEndDate.Text
            .Location = txtLocation.Text
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            intUpdateEventResult = objEvents.UpdateEvent()

            If intUpdateEventResult = 1 Then
                sslStatus.Text = "Event details updated successfully"
            Else
                MessageBox.Show("Event details update failed " & objEvents.CurrentObject.EventID, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sslStatus.Text = "Event details update failed"
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to update event details : " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sslStatus.Text = "Unable to update event details"
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        RSVPReport = New frmReportEventRSVPs
        If tvwEvents.Nodes.Count = 0 Then 'Nothing to print
            MessageBox.Show("No records to print")
            Exit Sub
        End If
        If txtEventID.Text = Nothing Then 'Nothing to pull report for
            MessageBox.Show("Please seect an event from the list first", "Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Else
            RSVPReport.passEventID = objEvents.CurrentObject.EventID
            'MessageBox.Show(RSVPReport.passEventID & "Retrieved") 'For debugging only
            Me.Cursor = Cursors.WaitCursor
            RSVPReport.Display()
            Me.Cursor = Cursors.Default
        End If
    End Sub
End Class