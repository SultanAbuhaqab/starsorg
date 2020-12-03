Imports System.Data.SqlClient

Public Class frmEventRSVP

    Private objRSVPs As CEventRSVPs
    Private objEvents As CEvents
    Private objMembers As CMembers
    Private sqlDA As SqlDataAdapter
    Private eventStart As Date
    Private RSVPReport As frmReportEventRSVPs

    Private Sub frmEventRSVP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objRSVPs = New CEventRSVPs
        objEvents = New CEvents
        objMembers = New CMembers
    End Sub

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
        'No action needed already at this screen
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

    Private Sub LoadEventRSVPs()
        Dim objDR As SqlDataReader
        Dim strEventOverview As String
        Dim strEventID As String
        Dim strEventType As String

        tvwEventRSVPs.Nodes.Clear()

        Try
            objDR = objEvents.GetAllEvents()

            Do While objDR.Read
                Dim parentNode() As TreeNode

                strEventID = objDR("EventID")
                strEventType = "Event Type: " & StrConv(objDR.Item("EventTypeID"), vbProperCase)
                strEventOverview = "Location: " & StrConv(objDR.Item("Location"), vbProperCase) & " | " & "Event Description: " & StrConv(objDR.Item("EventDescription"), vbProperCase) & " | " & "Start Date: " & StrConv(objDR.Item("StartDate"), vbProperCase) & " | " & "End date: " & StrConv(objDR.Item("EndDate"), vbProperCase)

                parentNode = tvwEventRSVPs.Nodes.Find(strEventType, True)

                If parentNode.Length > 0 Then
                    parentNode(0).Nodes.Add(strEventID, strEventOverview)
                Else
                    Dim newParentNode As TreeNode
                    newParentNode = tvwEventRSVPs.Nodes.Add(strEventType, strEventType)
                    newParentNode.Nodes.Add(strEventID, strEventOverview)
                    'tvwEventRSVPs.Nodes.Add(strEventID, strEventOverview)
                End If
            Loop

            objDR.Close()

            If objEvents.CurrentObject.EventID <> "" Then
                Dim currentNode() As TreeNode
                currentNode = tvwEventRSVPs.Nodes.Find(objEvents.CurrentObject.EventID, True)

                If currentNode.Length > 0 Then
                    tvwEventRSVPs.SelectedNode = currentNode(0)
                End If
            End If

            tvwEventRSVPs.ExpandAll()
            tvwEventRSVPs.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error occured while loading events " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmEventRSVP_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadEventRSVPs()
        ClearScreen()
        If Not AuthUser.IsAdmin And Not AuthUser.IsOfficer Then
            btnReport.Visible = False
            Exit Sub
        End If
    End Sub

    Private Sub tvwEventRSVPs_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwEventRSVPs.NodeMouseClick
        Dim eventNode As TreeNode = DirectCast(e.Node, TreeNode)
        LoadSelectedEvent(eventNode.Name)
        If eventStart < Today() Then
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtEmail.Enabled = False
            btnSave.Enabled = False
        Else
            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtEmail.Enabled = True
            btnSave.Enabled = True
        End If
        'for debugging purposes only
        'MessageBox.Show(eventNode.Name & "Append Click")
    End Sub

    Private Sub LoadSelectedEvent(strEventID As String)
        objEvents.CurrentObject.IsNewEvent = False
        Try
            objEvents.GetEventByID(strEventID)
            'for debugging purposes only
            'MessageBox.Show(objEvents.CurrentObject.EventDescription & "Retrieved")

            With objEvents.CurrentObject
                lblEventID.Text = .EventID
                eventStart = .StartDate
                lblEventType.Text = .EventTypeID
                lblLocation.Text = .Location
                lblStartDate.Text = .StartDate

            End With

            objMembers.GetMemberByPID(AuthUser.PID.ToString)
            With objMembers.CurrentObject
                txtFirstName.Text = .FName
                txtLastName.Text = .LName
                txtEmail.Text = .Email


            End With
        Catch ex As Exception
            MessageBox.Show("Error while loading event: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        sslStatus.Text = ""

        If Not modErrHandler.ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        For Each character In txtFirstName.Text
            If IsNumeric(character) Then
                errP.SetError(txtFirstName, "Error, you cannot put digits here.")
                blnErrors = True
            End If
            If blnErrors Then
                Exit Sub
            End If
        Next
        For Each character In txtLastName.Text
            If IsNumeric(character) Then
                errP.SetError(txtLastName, "Error, you cannot put digits here.")
                blnErrors = True
            End If
            If blnErrors Then
                Exit Sub
            End If
        Next

        'if we get this far, all of the input data is acceptable
        With objRSVPs.CurrentObject
            .Email = txtEmail.Text
            .FName = txtFirstName.Text
            .LName = txtLastName.Text
            .EventID = lblEventID.Text

        End With

        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objRSVPs.Save()
            If intResult = 1 Then
                sslStatus.Text = "RSVP saved"
            End If
            If intResult = -1 Then 'Member ID was not unique
                'MessageBox Event ID must be unique unable to save this record, warning
                MessageBox.Show("Error Event ID already exists in the database, must be a unique identifier", "Warning")
                sslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Error unable to save member in frmEventRSVP:btnAdd_Click" & ex.ToString(), "Error")
        End Try
        Me.Cursor = Cursors.Default
        LoadEventRSVPs()
        grpAddRSVP.Enabled = True
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        RSVPReport = New frmReportEventRSVPs
        If tvwEventRSVPs.Nodes.Count = 0 Then 'Nothing to print
            MessageBox.Show("No records to print")
            Exit Sub
        End If
        If Not AuthUser.IsAdmin And Not AuthUser.IsOfficer Then
            MessageBox.Show("Access Denied. You do not have permission to view this page", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If lblEventID.Text = Nothing Then 'Nothing to pull report for
            MessageBox.Show("Please select an event from the list first", "Nothing to generate report with", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Else
            RSVPReport.passEventID = objEvents.CurrentObject.EventID
            'MessageBox.Show(RSVPReport.passEventID & "Retrieved") 'For debugging only
            Me.Cursor = Cursors.WaitCursor
            RSVPReport.Display()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearScreen()
    End Sub

    Private Sub ClearScreen()
        ClearScreenControls(grpAddRSVP)
        lblEventID.Text = ""
        lblEventType.Text = ""
        lblLocation.Text = ""
        lblStartDate.Text = ""
        errP.Clear()
    End Sub
End Class