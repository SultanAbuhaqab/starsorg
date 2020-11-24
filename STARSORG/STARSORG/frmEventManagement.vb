Imports System.Data.SqlClient
Public Class frmEventManagement
    Private objEvents As CEvents
    Private blnReloading As Boolean
    Private blnClearing As Boolean
#Region "Toolbar stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogOut.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter, tsbTutor.MouseEnter
        'We need to do this only because we are not putting our images in the image property of the toolbar buttons
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogOut.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave, tsbTutor.MouseLeave
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
        intNextAction = ACTION_SECURITY
        Me.Hide()
    End Sub
#End Region

    '#Region "Textboxes"
    '    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtLocation.GotFocus, txtEventDescription.GotFocus
    '        Dim txtBox As TextBox
    '        txtBox = DirectCast(sender, TextBox)
    '        txtBox.SelectAll()
    '    End Sub

    '    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtLocation.LostFocus, txtEventDescription.LostFocus
    '        Dim txtBox As TextBox
    '        txtBox = DirectCast(sender, TextBox)
    '        txtBox.DeselectAll()
    '    End Sub
    '#End Region

    Private Sub frmEventManagement_Load(sender As Object, e As EventArgs) Handles Me.Load
        objEvents = New CEvents
    End Sub

    Private Sub frmEventManagement_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadEvents()
        LoadEventsList()
        LoadComboOptions()

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

    Private Sub LoadEventsList()
        Dim objDR As SqlDataReader
        lstEvents.Items.Clear()

        Try
            objDR = objEvents.GetAllEvents()
            Do While objDR.Read
                lstEvents.Items.Add(objDR.Item("EventID"))
            Loop
            objDR.Close()
        Catch ex As Exception
            MessageBox.Show("Error occured while loading events " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If objEvents.CurrentObject.EventID <> "" Then
            lstEvents.SelectedIndex = lstEvents.FindStringExact(objEvents.CurrentObject.EventID)
        End If

        blnReloading = False
    End Sub

    Private Sub LoadEvents()
        Dim objDR As SqlDataReader
        Dim strEventOverview As String
        Dim strEventID As String

        tvwEvents.Nodes.Clear()

        Try
            objDR = objEvents.GetAllEvents()

            Do While objDR.Read
                Dim parentNode() As TreeNode

                strEventID = objDR("EventID")
                strEventOverview = "Location: " & StrConv(objDR.Item("Location"), vbProperCase) & " | " & "Event Description: " & StrConv(objDR.Item("EventDescription"), vbProperCase) & " | " & "Start Date: " & StrConv(objDR.Item("StartDate"), vbProperCase) & " | " & "End date: " & StrConv(objDR.Item("EndDate"), vbProperCase)

                parentNode = tvwEvents.Nodes.Find(strEventID, True)

                If parentNode.Length > 0 Then
                    parentNode(0).Nodes.Add(strEventID)
                Else
                    Dim newParentNode As TreeNode
                    newParentNode = tvwEvents.Nodes.Add(strEventID)
                    newParentNode.Nodes.Add(strEventID, strEventOverview)
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
    End Sub

    Private Sub lstEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEvents.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If

        If blnReloading Then
            tssStatus.Text = ""
            Exit Sub
        End If

        If lstEvents.SelectedIndex = -1 Then
            Exit Sub
        End If

        chkNew.Checked = False

        LoadSelectedRecord()
        grpEdit.Enabled = True
    End Sub

    Private Sub LoadSelectedRecord()
        Try
            objEvents.GetEventByID(lstEvents.SelectedItem.ToString)
            With objEvents.CurrentObject
                txtEventID.Text = .EventID.ToString
                txtEventDescription.Text = .EventDescription.ToString
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
            tssStatus.Text = ""
            txtEventID.Clear()
            txtEventDescription.Clear()
            lstEvents.SelectedIndex = -1
            grpEvents.Enabled = False
            grpEdit.Enabled = True
            txtEventID.Focus()
            objEvents.CreateNewEvent()
        Else
            grpEvents.Enabled = True
            grpEdit.Enabled = True
            objEvents.CurrentObject.IsNewEvent = False
        End If
    End Sub

    Private Sub LoadSelectedEvent(strEventID As String)
        Try
            objEvents.GetEventByID(strEventID)

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

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        txtEventDescription.Clear()
        cboEventTypeID.SelectedIndex = -1
        txtLocation.Clear()
        cboSemesterID.SelectedIndex = -1
        Me.Hide()

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        tssStatus.Text = ""
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
            intResult = objEvents.Save()
            If intResult = 1 Then
                tssStatus.Text = "Event record saved"
            End If
            If intResult = -1 Then 'Member ID was not unique
                'MessageBox Event ID must be unique unable to save this record, warning
                MessageBox.Show("Error Event ID already exists in the database, must be a unique identifier", "Warning")
                tssStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Error unable to save event in frmEventManagement:btnAdd_Click" & ex.ToString(), "Error")
        End Try
        Me.Cursor = Cursors.Default

        blnReloading = True
        LoadEvents()
        chkNew.Checked = False
        grpEdit.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        tssStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()

        If lstEvents.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'Reload what was selected in case user has messed up the form
        Else
            grpEdit.Enabled = True
        End If

        blnClearing = False
        'objEvents.CurrentObject.IsNewEvent = False
        grpEvents.Enabled = True
    End Sub
End Class