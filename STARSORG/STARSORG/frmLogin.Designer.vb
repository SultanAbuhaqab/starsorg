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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpMemberLogin = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuestLogin = New System.Windows.Forms.Button()
        Me.grpChangePassword = New System.Windows.Forms.GroupBox()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtChangePasswordUserID = New System.Windows.Forms.TextBox()
        Me.LabelUserId = New System.Windows.Forms.Label()
        Me.grpGuestLogin = New System.Windows.Forms.GroupBox()
        Me.errP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpMemberLogin.SuspendLayout()
        Me.grpChangePassword.SuspendLayout()
        Me.grpGuestLogin.SuspendLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(714, 36)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "STARSORG LOGIN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpMemberLogin
        '
        Me.grpMemberLogin.Controls.Add(Me.txtPassword)
        Me.grpMemberLogin.Controls.Add(Me.btnLogin)
        Me.grpMemberLogin.Controls.Add(Me.Label2)
        Me.grpMemberLogin.Controls.Add(Me.txtUserID)
        Me.grpMemberLogin.Controls.Add(Me.lblPassword)
        Me.grpMemberLogin.Location = New System.Drawing.Point(35, 74)
        Me.grpMemberLogin.Name = "grpMemberLogin"
        Me.grpMemberLogin.Size = New System.Drawing.Size(333, 179)
        Me.grpMemberLogin.TabIndex = 6
        Me.grpMemberLogin.TabStop = False
        Me.grpMemberLogin.Text = "Member Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(92, 80)
        Me.txtPassword.MaxLength = 8
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(211, 20)
        Me.txtPassword.TabIndex = 3
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(92, 126)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
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
        Me.txtUserID.Location = New System.Drawing.Point(92, 32)
        Me.txtUserID.MaxLength = 15
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(211, 20)
        Me.txtUserID.TabIndex = 1
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(18, 83)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(123, 229)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(110, 23)
        Me.btnChangePassword.TabIndex = 8
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Confirm Password"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(123, 176)
        Me.txtConfirmPassword.MaxLength = 8
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(203, 20)
        Me.txtConfirmPassword.TabIndex = 7
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(123, 128)
        Me.txtNewPassword.MaxLength = 8
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(203, 20)
        Me.txtNewPassword.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "New Password"
        '
        'btnGuestLogin
        '
        Me.btnGuestLogin.Location = New System.Drawing.Point(20, 28)
        Me.btnGuestLogin.Name = "btnGuestLogin"
        Me.btnGuestLogin.Size = New System.Drawing.Size(96, 23)
        Me.btnGuestLogin.TabIndex = 0
        Me.btnGuestLogin.Text = "Login as Guest"
        Me.btnGuestLogin.UseVisualStyleBackColor = True
        '
        'grpChangePassword
        '
        Me.grpChangePassword.Controls.Add(Me.btnChangePassword)
        Me.grpChangePassword.Controls.Add(Me.txtOldPassword)
        Me.grpChangePassword.Controls.Add(Me.Label4)
        Me.grpChangePassword.Controls.Add(Me.txtChangePasswordUserID)
        Me.grpChangePassword.Controls.Add(Me.LabelUserId)
        Me.grpChangePassword.Controls.Add(Me.Label6)
        Me.grpChangePassword.Controls.Add(Me.txtNewPassword)
        Me.grpChangePassword.Controls.Add(Me.Label5)
        Me.grpChangePassword.Controls.Add(Me.txtConfirmPassword)
        Me.grpChangePassword.Location = New System.Drawing.Point(393, 74)
        Me.grpChangePassword.Name = "grpChangePassword"
        Me.grpChangePassword.Size = New System.Drawing.Size(357, 278)
        Me.grpChangePassword.TabIndex = 8
        Me.grpChangePassword.TabStop = False
        Me.grpChangePassword.Text = "Change Password"
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Location = New System.Drawing.Point(123, 80)
        Me.txtOldPassword.MaxLength = 8
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPassword.Size = New System.Drawing.Size(203, 20)
        Me.txtOldPassword.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Old Password"
        '
        'txtChangePasswordUserID
        '
        Me.txtChangePasswordUserID.Location = New System.Drawing.Point(123, 32)
        Me.txtChangePasswordUserID.MaxLength = 15
        Me.txtChangePasswordUserID.Name = "txtChangePasswordUserID"
        Me.txtChangePasswordUserID.Size = New System.Drawing.Size(203, 20)
        Me.txtChangePasswordUserID.TabIndex = 1
        '
        'LabelUserId
        '
        Me.LabelUserId.AutoSize = True
        Me.LabelUserId.Location = New System.Drawing.Point(13, 35)
        Me.LabelUserId.Name = "LabelUserId"
        Me.LabelUserId.Size = New System.Drawing.Size(43, 13)
        Me.LabelUserId.TabIndex = 0
        Me.LabelUserId.Text = "User ID"
        '
        'grpGuestLogin
        '
        Me.grpGuestLogin.Controls.Add(Me.btnGuestLogin)
        Me.grpGuestLogin.Location = New System.Drawing.Point(36, 275)
        Me.grpGuestLogin.Name = "grpGuestLogin"
        Me.grpGuestLogin.Size = New System.Drawing.Size(332, 77)
        Me.grpGuestLogin.TabIndex = 7
        Me.grpGuestLogin.TabStop = False
        Me.grpGuestLogin.Text = "Guest Login"
        '
        'errP
        '
        Me.errP.ContainerControl = Me
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(675, 374)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 409)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.grpChangePassword)
        Me.Controls.Add(Me.grpGuestLogin)
        Me.Controls.Add(Me.grpMemberLogin)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STARSORG LOGIN"
        Me.grpMemberLogin.ResumeLayout(False)
        Me.grpMemberLogin.PerformLayout()
        Me.grpChangePassword.ResumeLayout(False)
        Me.grpChangePassword.PerformLayout()
        Me.grpGuestLogin.ResumeLayout(False)
        CType(Me.errP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents grpMemberLogin As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents btnGuestLogin As Button
    Friend WithEvents btnChangePassword As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents grpChangePassword As GroupBox
    Friend WithEvents txtOldPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtChangePasswordUserID As TextBox
    Friend WithEvents LabelUserId As Label
    Friend WithEvents grpGuestLogin As GroupBox
    Friend WithEvents errP As ErrorProvider
    Friend WithEvents btnExit As Button
End Class
