<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEventManagement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.grpEdit = New System.Windows.Forms.GroupBox()
        Me.txtEventID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboSemesterID = New System.Windows.Forms.ComboBox()
        Me.cboEventTypeID = New System.Windows.Forms.ComboBox()
        Me.dtpEventEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEventStartDate = New System.Windows.Forms.DateTimePicker()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEventDescription = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.errP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpEvents = New System.Windows.Forms.GroupBox()
        Me.tvwEvents = New System.Windows.Forms.TreeView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHome = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMember = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRole = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSecurity = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEvent = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRSVP = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCourse = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSemester = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbTutor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLogOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpNew = New System.Windows.Forms.GroupBox()
        Me.chkNew = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.grpEdit.SuspendLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEvents.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpNew.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 509)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 11, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(921, 22)
        Me.StatusStrip1.TabIndex = 23
        '
        'sslStatus
        '
        Me.sslStatus.Name = "sslStatus"
        Me.sslStatus.Size = New System.Drawing.Size(119, 17)
        Me.sslStatus.Text = "ToolStripStatusLabel1"
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(228, 343)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(112, 33)
        Me.btnReport.TabIndex = 10
        Me.btnReport.Text = "RSVP Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'grpEdit
        '
        Me.grpEdit.Controls.Add(Me.txtEventID)
        Me.grpEdit.Controls.Add(Me.Label8)
        Me.grpEdit.Controls.Add(Me.btnSave)
        Me.grpEdit.Controls.Add(Me.btnCancel)
        Me.grpEdit.Controls.Add(Me.cboSemesterID)
        Me.grpEdit.Controls.Add(Me.cboEventTypeID)
        Me.grpEdit.Controls.Add(Me.dtpEventEndDate)
        Me.grpEdit.Controls.Add(Me.dtpEventStartDate)
        Me.grpEdit.Controls.Add(Me.txtLocation)
        Me.grpEdit.Controls.Add(Me.Label2)
        Me.grpEdit.Controls.Add(Me.Label1)
        Me.grpEdit.Controls.Add(Me.txtEventDescription)
        Me.grpEdit.Controls.Add(Me.Label7)
        Me.grpEdit.Controls.Add(Me.Label6)
        Me.grpEdit.Controls.Add(Me.Label5)
        Me.grpEdit.Controls.Add(Me.Label4)
        Me.grpEdit.Location = New System.Drawing.Point(610, 194)
        Me.grpEdit.Name = "grpEdit"
        Me.grpEdit.Size = New System.Drawing.Size(279, 312)
        Me.grpEdit.TabIndex = 22
        Me.grpEdit.TabStop = False
        Me.grpEdit.Text = "Event Details"
        '
        'txtEventID
        '
        Me.txtEventID.Location = New System.Drawing.Point(111, 22)
        Me.txtEventID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEventID.MaxLength = 100
        Me.txtEventID.Name = "txtEventID"
        Me.txtEventID.Size = New System.Drawing.Size(148, 20)
        Me.txtEventID.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 25)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Event ID: "
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(168, 273)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 33)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(6, 273)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 33)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboSemesterID
        '
        Me.cboSemesterID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSemesterID.FormattingEnabled = True
        Me.cboSemesterID.Location = New System.Drawing.Point(111, 121)
        Me.cboSemesterID.MaxLength = 4
        Me.cboSemesterID.Name = "cboSemesterID"
        Me.cboSemesterID.Size = New System.Drawing.Size(148, 21)
        Me.cboSemesterID.TabIndex = 31
        '
        'cboEventTypeID
        '
        Me.cboEventTypeID.BackColor = System.Drawing.SystemColors.Window
        Me.cboEventTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEventTypeID.FormattingEnabled = True
        Me.cboEventTypeID.Location = New System.Drawing.Point(111, 86)
        Me.cboEventTypeID.MaxLength = 15
        Me.cboEventTypeID.Name = "cboEventTypeID"
        Me.cboEventTypeID.Size = New System.Drawing.Size(148, 21)
        Me.cboEventTypeID.TabIndex = 30
        '
        'dtpEventEndDate
        '
        Me.dtpEventEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEventEndDate.Location = New System.Drawing.Point(111, 192)
        Me.dtpEventEndDate.Name = "dtpEventEndDate"
        Me.dtpEventEndDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpEventEndDate.TabIndex = 29
        Me.dtpEventEndDate.Value = New Date(2020, 12, 2, 0, 0, 0, 0)
        '
        'dtpEventStartDate
        '
        Me.dtpEventStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEventStartDate.Location = New System.Drawing.Point(111, 159)
        Me.dtpEventStartDate.Name = "dtpEventStartDate"
        Me.dtpEventStartDate.Size = New System.Drawing.Size(148, 20)
        Me.dtpEventStartDate.TabIndex = 28
        Me.dtpEventStartDate.Value = New Date(2020, 12, 2, 20, 29, 17, 0)
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(111, 222)
        Me.txtLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLocation.MaxLength = 30
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(148, 20)
        Me.txtLocation.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 225)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Location:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 192)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "End Date:"
        '
        'txtEventDescription
        '
        Me.txtEventDescription.Location = New System.Drawing.Point(111, 51)
        Me.txtEventDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEventDescription.MaxLength = 100
        Me.txtEventDescription.Name = "txtEventDescription"
        Me.txtEventDescription.Size = New System.Drawing.Size(148, 20)
        Me.txtEventDescription.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 159)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Start Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 124)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Semester ID:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 89)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Event Type ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Event Description:"
        '
        'errP
        '
        Me.errP.ContainerControl = Me
        '
        'grpEvents
        '
        Me.grpEvents.Controls.Add(Me.tvwEvents)
        Me.grpEvents.Controls.Add(Me.btnReport)
        Me.grpEvents.Location = New System.Drawing.Point(12, 124)
        Me.grpEvents.Name = "grpEvents"
        Me.grpEvents.Size = New System.Drawing.Size(577, 382)
        Me.grpEvents.TabIndex = 20
        Me.grpEvents.TabStop = False
        Me.grpEvents.Text = "Event Manager"
        '
        'tvwEvents
        '
        Me.tvwEvents.Location = New System.Drawing.Point(7, 20)
        Me.tvwEvents.Name = "tvwEvents"
        Me.tvwEvents.Size = New System.Drawing.Size(551, 292)
        Me.tvwEvents.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.tsbHome, Me.ToolStripSeparator2, Me.tsbMember, Me.ToolStripSeparator1, Me.tsbRole, Me.ToolStripSeparator13, Me.tsbSecurity, Me.ToolStripSeparator6, Me.tsbEvent, Me.ToolStripSeparator7, Me.tsbRSVP, Me.ToolStripSeparator3, Me.tsbCourse, Me.ToolStripSeparator8, Me.tsbSemester, Me.ToolStripSeparator5, Me.tsbTutor, Me.ToolStripSeparator11, Me.tsbLogOut, Me.ToolStripSeparator10, Me.tsbHelp, Me.ToolStripSeparator9, Me.ToolStripSeparator12})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(921, 51)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(10, 51)
        '
        'tsbHome
        '
        Me.tsbHome.AutoSize = False
        Me.tsbHome.BackgroundImage = Global.STARSORG.My.Resources.Resources.home
        Me.tsbHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHome.Name = "tsbHome"
        Me.tsbHome.Size = New System.Drawing.Size(48, 48)
        Me.tsbHome.Text = "Home"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(10, 51)
        '
        'tsbMember
        '
        Me.tsbMember.AutoSize = False
        Me.tsbMember.BackgroundImage = Global.STARSORG.My.Resources.Resources.member
        Me.tsbMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMember.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMember.Name = "tsbMember"
        Me.tsbMember.Size = New System.Drawing.Size(48, 48)
        Me.tsbMember.Text = "Member"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(10, 51)
        '
        'tsbRole
        '
        Me.tsbRole.AutoSize = False
        Me.tsbRole.BackgroundImage = Global.STARSORG.My.Resources.Resources.roles
        Me.tsbRole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRole.Name = "tsbRole"
        Me.tsbRole.Size = New System.Drawing.Size(48, 48)
        Me.tsbRole.Text = "Role"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.AutoSize = False
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(10, 51)
        '
        'tsbSecurity
        '
        Me.tsbSecurity.AutoSize = False
        Me.tsbSecurity.BackgroundImage = Global.STARSORG.My.Resources.Resources.admin
        Me.tsbSecurity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbSecurity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSecurity.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSecurity.Name = "tsbSecurity"
        Me.tsbSecurity.Size = New System.Drawing.Size(48, 48)
        Me.tsbSecurity.Text = "Security"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(10, 51)
        '
        'tsbEvent
        '
        Me.tsbEvent.AutoSize = False
        Me.tsbEvent.BackgroundImage = Global.STARSORG.My.Resources.Resources.events
        Me.tsbEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEvent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEvent.Name = "tsbEvent"
        Me.tsbEvent.Size = New System.Drawing.Size(48, 48)
        Me.tsbEvent.Text = "Event"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(10, 51)
        '
        'tsbRSVP
        '
        Me.tsbRSVP.AutoSize = False
        Me.tsbRSVP.BackgroundImage = Global.STARSORG.My.Resources.Resources.rsvp
        Me.tsbRSVP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRSVP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRSVP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRSVP.Name = "tsbRSVP"
        Me.tsbRSVP.Size = New System.Drawing.Size(48, 48)
        Me.tsbRSVP.Text = "RSVP"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(10, 51)
        '
        'tsbCourse
        '
        Me.tsbCourse.AutoSize = False
        Me.tsbCourse.BackgroundImage = Global.STARSORG.My.Resources.Resources.courses
        Me.tsbCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbCourse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCourse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCourse.Name = "tsbCourse"
        Me.tsbCourse.Size = New System.Drawing.Size(48, 48)
        Me.tsbCourse.Text = "Course"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(10, 51)
        '
        'tsbSemester
        '
        Me.tsbSemester.AutoSize = False
        Me.tsbSemester.BackgroundImage = Global.STARSORG.My.Resources.Resources.semesters
        Me.tsbSemester.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbSemester.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSemester.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSemester.Name = "tsbSemester"
        Me.tsbSemester.Size = New System.Drawing.Size(48, 48)
        Me.tsbSemester.Text = "Semester"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.AutoSize = False
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(10, 51)
        '
        'tsbTutor
        '
        Me.tsbTutor.AutoSize = False
        Me.tsbTutor.BackgroundImage = Global.STARSORG.My.Resources.Resources.tutors
        Me.tsbTutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbTutor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbTutor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTutor.Name = "tsbTutor"
        Me.tsbTutor.Size = New System.Drawing.Size(48, 48)
        Me.tsbTutor.Text = "Tutor"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator11.AutoSize = False
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(10, 51)
        '
        'tsbLogOut
        '
        Me.tsbLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbLogOut.AutoSize = False
        Me.tsbLogOut.BackgroundImage = Global.STARSORG.My.Resources.Resources.logout
        Me.tsbLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbLogOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLogOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogOut.Name = "tsbLogOut"
        Me.tsbLogOut.Size = New System.Drawing.Size(48, 48)
        Me.tsbLogOut.Text = "Logout"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator10.AutoSize = False
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(10, 51)
        '
        'tsbHelp
        '
        Me.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHelp.AutoSize = False
        Me.tsbHelp.BackgroundImage = Global.STARSORG.My.Resources.Resources.help
        Me.tsbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(48, 48)
        Me.tsbHelp.Text = "Help"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.AutoSize = False
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(10, 51)
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator12.AutoSize = False
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(10, 51)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(897, 55)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Event Management"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpNew
        '
        Me.grpNew.Controls.Add(Me.chkNew)
        Me.grpNew.Location = New System.Drawing.Point(621, 124)
        Me.grpNew.Name = "grpNew"
        Me.grpNew.Size = New System.Drawing.Size(268, 52)
        Me.grpNew.TabIndex = 26
        Me.grpNew.TabStop = False
        Me.grpNew.Text = "New Event"
        '
        'chkNew
        '
        Me.chkNew.AutoSize = True
        Me.chkNew.Location = New System.Drawing.Point(19, 20)
        Me.chkNew.Name = "chkNew"
        Me.chkNew.Size = New System.Drawing.Size(113, 17)
        Me.chkNew.TabIndex = 0
        Me.chkNew.Text = "Create New Event"
        Me.chkNew.UseVisualStyleBackColor = True
        '
        'frmEventManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(921, 531)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpNew)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grpEdit)
        Me.Controls.Add(Me.grpEvents)
        Me.Name = "frmEventManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Event Management"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpEdit.ResumeLayout(False)
        Me.grpEdit.PerformLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEvents.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpNew.ResumeLayout(False)
        Me.grpNew.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btnReport As Button
    Friend WithEvents grpEdit As GroupBox
    Friend WithEvents dtpEventEndDate As DateTimePicker
    Friend WithEvents dtpEventStartDate As DateTimePicker
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEventDescription As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents errP As ErrorProvider
    Friend WithEvents grpEvents As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbHome As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbMember As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbRole As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbEvent As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsbRSVP As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbCourse As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsbSemester As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbTutor As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents tsbLogOut As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsbHelp As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents Label3 As Label
    Friend WithEvents cboSemesterID As ComboBox
    Friend WithEvents cboEventTypeID As ComboBox
    Friend WithEvents grpNew As GroupBox
    Friend WithEvents chkNew As CheckBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents sslStatus As ToolStripStatusLabel
    Friend WithEvents btnSave As Button
    Friend WithEvents tvwEvents As TreeView
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents tsbSecurity As ToolStripButton
    Friend WithEvents txtEventID As TextBox
    Friend WithEvents Label8 As Label
End Class
