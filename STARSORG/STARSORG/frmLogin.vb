Imports System.Data.SqlClient

Public Class frmLogin
    Private objSecurities As CSecurities

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        objSecurities = New CSecurities
    End Sub


End Class