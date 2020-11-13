<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.btnSignIn = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.grpGuests = New System.Windows.Forms.GroupBox()
        Me.btnGuestSignIn = New System.Windows.Forms.Button()
        Me.radSignIn = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpActions = New System.Windows.Forms.GroupBox()
        Me.radChangePassword = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.grpMembers.SuspendLayout()
        Me.grpGuests.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(395, 36)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "STARSORG LOGIN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpMembers
        '
        Me.grpMembers.Controls.Add(Me.btnChangePassword)
        Me.grpMembers.Controls.Add(Me.Label6)
        Me.grpMembers.Controls.Add(Me.txtConfirmPassword)
        Me.grpMembers.Controls.Add(Me.txtNewPassword)
        Me.grpMembers.Controls.Add(Me.Label5)
        Me.grpMembers.Controls.Add(Me.grpActions)
        Me.grpMembers.Controls.Add(Me.Label4)
        Me.grpMembers.Controls.Add(Me.txtPassword)
        Me.grpMembers.Controls.Add(Me.btnSignIn)
        Me.grpMembers.Controls.Add(Me.Label2)
        Me.grpMembers.Controls.Add(Me.txtUserID)
        Me.grpMembers.Controls.Add(Me.lblPassword)
        Me.grpMembers.Location = New System.Drawing.Point(35, 74)
        Me.grpMembers.Name = "grpMembers"
        Me.grpMembers.Size = New System.Drawing.Size(396, 336)
        Me.grpMembers.TabIndex = 6
        Me.grpMembers.TabStop = False
        Me.grpMembers.Text = "Members"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "User ID"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(120, 32)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(257, 20)
        Me.txtUserID.TabIndex = 1
        '
        'btnSignIn
        '
        Me.btnSignIn.Location = New System.Drawing.Point(120, 297)
        Me.btnSignIn.Name = "btnSignIn"
        Me.btnSignIn.Size = New System.Drawing.Size(75, 23)
        Me.btnSignIn.TabIndex = 4
        Me.btnSignIn.Text = "Sign In"
        Me.btnSignIn.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(120, 136)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(257, 20)
        Me.txtPassword.TabIndex = 3
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(18, 139)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'grpGuests
        '
        Me.grpGuests.Controls.Add(Me.btnGuestSignIn)
        Me.grpGuests.Location = New System.Drawing.Point(36, 426)
        Me.grpGuests.Name = "grpGuests"
        Me.grpGuests.Size = New System.Drawing.Size(395, 68)
        Me.grpGuests.TabIndex = 7
        Me.grpGuests.TabStop = False
        Me.grpGuests.Text = "Guests"
        '
        'btnGuestSignIn
        '
        Me.btnGuestSignIn.Location = New System.Drawing.Point(21, 29)
        Me.btnGuestSignIn.Name = "btnGuestSignIn"
        Me.btnGuestSignIn.Size = New System.Drawing.Size(96, 23)
        Me.btnGuestSignIn.TabIndex = 5
        Me.btnGuestSignIn.Text = "Sign in as Guest"
        Me.btnGuestSignIn.UseVisualStyleBackColor = True
        '
        'radSignIn
        '
        Me.radSignIn.AutoSize = True
        Me.radSignIn.Location = New System.Drawing.Point(17, 10)
        Me.radSignIn.Name = "radSignIn"
        Me.radSignIn.Size = New System.Drawing.Size(58, 17)
        Me.radSignIn.TabIndex = 5
        Me.radSignIn.TabStop = True
        Me.radSignIn.Text = "Sign In"
        Me.radSignIn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Action"
        '
        'grpActions
        '
        Me.grpActions.Controls.Add(Me.radChangePassword)
        Me.grpActions.Controls.Add(Me.radSignIn)
        Me.grpActions.Location = New System.Drawing.Point(120, 66)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Size = New System.Drawing.Size(257, 39)
        Me.grpActions.TabIndex = 7
        Me.grpActions.TabStop = False
        '
        'radChangePassword
        '
        Me.radChangePassword.AutoSize = True
        Me.radChangePassword.Location = New System.Drawing.Point(113, 10)
        Me.radChangePassword.Name = "radChangePassword"
        Me.radChangePassword.Size = New System.Drawing.Size(111, 17)
        Me.radChangePassword.TabIndex = 6
        Me.radChangePassword.TabStop = True
        Me.radChangePassword.Text = "Change Password"
        Me.radChangePassword.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "New Password"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(120, 194)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(257, 20)
        Me.txtNewPassword.TabIndex = 9
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(120, 251)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(257, 20)
        Me.txtConfirmPassword.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Confirm Password"
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(267, 297)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(110, 23)
        Me.btnChangePassword.TabIndex = 12
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 522)
        Me.Controls.Add(Me.grpGuests)
        Me.Controls.Add(Me.grpMembers)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLogin"
        Me.Text = "STARSORG LOGIN"
        Me.grpMembers.ResumeLayout(False)
        Me.grpMembers.PerformLayout()
        Me.grpGuests.ResumeLayout(False)
        Me.grpActions.ResumeLayout(False)
        Me.grpActions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents grpMembers As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents btnSignIn As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents grpGuests As GroupBox
    Friend WithEvents btnGuestSignIn As Button
    Friend WithEvents btnChangePassword As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents grpActions As GroupBox
    Friend WithEvents radChangePassword As RadioButton
    Friend WithEvents radSignIn As RadioButton
    Friend WithEvents Label4 As Label
End Class
