Imports System.Data.SqlClient
Module modDB
    Public objSQLConn As SqlConnection
    Public objSqlCommand As SqlCommand
    Public objSQLDR As SqlDataReader
    Public gstrConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=D:\Development\VisualStudio\WindowsProgramming\starsorg-events\STARSORG\STARSDB.mdf;Integrated Security=True"
End Module
