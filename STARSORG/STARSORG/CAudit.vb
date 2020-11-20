Imports System.Data.SqlClient

Public Class CAudit

    Private _mintukid As Integer
    Private _mstrPID As String
    Private _mdatAccessTimestamp As Date
    Private _mintSuccess As Integer

    Public Sub New()
        _mintukid = vbNull
        _mstrPID = ""
        _mdatAccessTimestamp = DateTime.Now
        _mintSuccess = vbNull
    End Sub

#Region "Expose Properties"
    Public ReadOnly Property Ukid As Integer
        Get
            Return _mintukid
        End Get
    End Property

    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
        End Set
    End Property

    Public Property AccessTimestamp As Date
        Get
            Return _mdatAccessTimestamp
        End Get
        Set(datVal As Date)
            _mdatAccessTimestamp = datVal
        End Set
    End Property

    Public Property Success As Integer
        Get
            Return _mintSuccess
        End Get
        Set(intVal As Integer)
            _mintSuccess = intVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params = New ArrayList

            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("AccessTimestamp", _mdatAccessTimestamp))
            params.Add(New SqlParameter("Success", _mintSuccess))

            Return params
        End Get
    End Property
#End Region

    Public Function Save() As Integer
        Return myDB.ExecSP("sp_SaveAudit", GetSaveParameters())
    End Function
End Class
