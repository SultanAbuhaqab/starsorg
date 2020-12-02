<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMembers
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.errP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lstMembers = New System.Windows.Forms.ListBox()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.grpMemberInfo = New System.Windows.Forms.GroupBox()
        Me.mtbPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtPID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtMI = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbMember = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMembers.SuspendLayout()
        Me.grpMemberInfo.SuspendLayout()
        CType(Me.pbMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(684, 46)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "MEMBERS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'errP
        '
        Me.errP.ContainerControl = Me
        '
        'lstMembers
        '
        Me.lstMembers.FormattingEnabled = True
        Me.lstMembers.Location = New System.Drawing.Point(6, 19)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(208, 225)
        Me.lstMembers.TabIndex = 5
        '
        'grpMembers
        '
        Me.grpMembers.Controls.Add(Me.lstMembers)
        Me.grpMembers.Location = New System.Drawing.Point(12, 177)
        Me.grpMembers.Name = "grpMembers"
        Me.grpMembers.Size = New System.Drawing.Size(220, 257)
        Me.grpMembers.TabIndex = 7
        Me.grpMembers.TabStop = False
        Me.grpMembers.Text = "MEMBERS"
        '
        'grpMemberInfo
        '
        Me.grpMemberInfo.Controls.Add(Me.mtbPhone)
        Me.grpMemberInfo.Controls.Add(Me.txtPID)
        Me.grpMemberInfo.Controls.Add(Me.Label9)
        Me.grpMemberInfo.Controls.Add(Me.btnSave)
        Me.grpMemberInfo.Controls.Add(Me.btnCancel)
        Me.grpMemberInfo.Controls.Add(Me.btnBrowse)
        Me.grpMemberInfo.Controls.Add(Me.txtEmail)
        Me.grpMemberInfo.Controls.Add(Me.txtMI)
        Me.grpMemberInfo.Controls.Add(Me.txtLName)
        Me.grpMemberInfo.Controls.Add(Me.txtFName)
        Me.grpMemberInfo.Controls.Add(Me.Label7)
        Me.grpMemberInfo.Controls.Add(Me.Label6)
        Me.grpMemberInfo.Controls.Add(Me.Label5)
        Me.grpMemberInfo.Controls.Add(Me.pbMember)
        Me.grpMemberInfo.Controls.Add(Me.Label4)
        Me.grpMemberInfo.Controls.Add(Me.Label3)
        Me.grpMemberInfo.Location = New System.Drawing.Point(255, 120)
        Me.grpMemberInfo.Name = "grpMemberInfo"
        Me.grpMemberInfo.Size = New System.Drawing.Size(441, 314)
        Me.grpMemberInfo.TabIndex = 8
        Me.grpMemberInfo.TabStop = False
        Me.grpMemberInfo.Text = "MEMBER INFORMATION"
        '
        'mtbPhone
        '
        Me.mtbPhone.Location = New System.Drawing.Point(71, 226)
        Me.mtbPhone.Margin = New System.Windows.Forms.Padding(2)
        Me.mtbPhone.Mask = "(999) 000-0000"
        Me.mtbPhone.Name = "mtbPhone"
        Me.mtbPhone.Size = New System.Drawing.Size(164, 20)
        Me.mtbPhone.TabIndex = 20
        Me.mtbPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtPID
        '
        Me.txtPID.Location = New System.Drawing.Point(73, 32)
        Me.txtPID.MaxLength = 7
        Me.txtPID.Name = "txtPID"
        Me.txtPID.Size = New System.Drawing.Size(163, 20)
        Me.txtPID.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "PID"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(279, 283)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(360, 283)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(198, 283)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 25)
        Me.btnBrowse.TabIndex = 14
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(73, 184)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(163, 20)
        Me.txtEmail.TabIndex = 10
        '
        'txtMI
        '
        Me.txtMI.Location = New System.Drawing.Point(73, 109)
        Me.txtMI.MaxLength = 1
        Me.txtMI.Name = "txtMI"
        Me.txtMI.Size = New System.Drawing.Size(163, 20)
        Me.txtMI.TabIndex = 9
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(73, 147)
        Me.txtLName.MaxLength = 75
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(163, 20)
        Me.txtLName.TabIndex = 8
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(74, 69)
        Me.txtFName.MaxLength = 50
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(163, 20)
        Me.txtFName.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Phone"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "M.I."
        '
        'pbMember
        '
        Me.pbMember.BackColor = System.Drawing.Color.White
        Me.pbMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMember.Location = New System.Drawing.Point(250, 32)
        Me.pbMember.Name = "pbMember"
        Me.pbMember.Size = New System.Drawing.Size(185, 191)
        Me.pbMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbMember.TabIndex = 2
        Me.pbMember.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Last Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "First Name"
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(588, 440)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(102, 29)
        Me.btnReport.TabIndex = 9
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 485)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(714, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.AutoSize = False
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(600, 17)
        Me.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Location = New System.Drawing.Point(11, 122)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(221, 49)
        Me.grpSearch.TabIndex = 12
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "SEARCH"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(181, 15)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(29, 26)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Go"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(6, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(169, 20)
        Me.txtSearch.TabIndex = 7
        '
        'frmMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 507)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.grpMemberInfo)
        Me.Controls.Add(Me.grpMembers)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMembers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMembers"
        CType(Me.errP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMembers.ResumeLayout(False)
        Me.grpMemberInfo.ResumeLayout(False)
        Me.grpMemberInfo.PerformLayout()
        CType(Me.pbMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents errP As ErrorProvider
    Friend WithEvents lstMembers As ListBox
    Friend WithEvents grpMembers As GroupBox
    Friend WithEvents btnReport As Button
    Friend WithEvents grpMemberInfo As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtMI As TextBox
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtFName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pbMember As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtPID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents mtbPhone As MaskedTextBox
    Friend WithEvents grpSearch As GroupBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnBrowse As Button
End Class
