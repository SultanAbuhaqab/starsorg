Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmSecurityReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private Security As CSecurity

    Private Sub frmSecurityReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.rpvSecurityReport.RefreshReport()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub Display()
        Me.Cursor = Cursors.WaitCursor

        Security = New CSecurity
        rpvSecurityReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptSecurities.rdlc"
        ds = New DataSet
        da = Security.GetReportData()
        da.Fill(ds)
        rpvSecurityReport.LocalReport.DataSources.Add(New ReportDataSource("dsSecurities", ds.Tables(0)))
        rpvSecurityReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvSecurityReport.RefreshReport()

        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub
End Class