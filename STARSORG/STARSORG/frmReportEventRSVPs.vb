Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Public Class frmReportEventRSVPs
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private EventRSVP As CEventRSVP
    Public Property passEventID As String

    Private Sub frmReportEventRSVPs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvReport.RefreshReport()
    End Sub
    Public Sub Display()
        EventRSVP = New CEventRSVP
        rpvReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptEventRSVPs.rdlc"
        ds = New DataSet
        'MessageBox.Show(passEventID & "Retrieved") 'For debugging only
        'MessageBox.Show(EventRSVP.EventID & "Retrieved") 'For debugging only
        EventRSVP.EventID = passEventID
        da = EventRSVP.GetReportData()
        da.Fill(ds)
        rpvReport.LocalReport.DataSources.Add(New ReportDataSource("dsEventRSVPs", ds.Tables(0)))
        rpvReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class