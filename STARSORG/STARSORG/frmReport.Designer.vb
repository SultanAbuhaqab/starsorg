﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.rpvReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rpvReport
        '
        Me.rpvReport.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton
        Me.rpvReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rpvReport.AutoSize = True
        Me.rpvReport.Location = New System.Drawing.Point(13, 12)
        Me.rpvReport.Name = "rpvReport"
        Me.rpvReport.ServerReport.BearerToken = Nothing
        Me.rpvReport.Size = New System.Drawing.Size(775, 403)
        Me.rpvReport.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(713, 421)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(802, 459)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.rpvReport)
        Me.Name = "frmReport"
        Me.Text = "Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rpvReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnClose As Button
End Class
