﻿Imports System.Data.SqlClient
Module modDB
    Public objSQLConn As SqlConnection
    Public objSqlCommand As SqlCommand
    Public objSQLDR As SqlDataReader
    Public gstrConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=C:\Users\Ulises\Desktop\project-Ulises-Marcelino\STARSORG\STARSDB.mdf;Integrated Security=True"
End Module
