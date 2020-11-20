Imports System.Data.SqlClient

Public Class CAudit

    Private _mintukid As Integer
    Private _mstrPID As String
    Private _mdatAccessTimestamp As DateTime
    Private _mblnSuccess As Boolean

    Public Sub New()
        _mintukid = vbNull
        _mstrPID = ""
        _mdatAccessTimestamp = DateTime.Now
        _mblnSuccess = vbNull
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

    Public Property AccessTimestamp As DateTime
        Get
            Return _mdatAccessTimestamp
        End Get
        Set(datVal As DateTime)
            _mdatAccessTimestamp = datVal
        End Set
    End Property

    Public Property Success As Boolean
        Get
            Return _mblnSuccess
        End Get
        Set(blnVal As Boolean)
            _mblnSuccess = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params = New ArrayList

            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("AccessTimestamp", _mdatAccessTimestamp))
            params.Add(New SqlParameter("Success", _mblnSuccess))

            Return params
        End Get
    End Property
#End Region

    Public Function Save() As Integer
        Return myDB.ExecSP("sp_saveAudit", GetSaveParameters())
    End Function
End Class
