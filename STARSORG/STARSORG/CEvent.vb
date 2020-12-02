Imports System.Data.SqlClient
Public Class CEvent
    Private _mstrEventID As String
    Private _mstrEventDescription As String
    Private _mstrEventTypeID As String
    Private _mstrSemesterID As String
    Private _mstrStartDate As Date
    Private _mstrEndDate As Date
    Private _mstrLocation As String
    Private _isNewEvent As Boolean
    Public Sub New()
        _mstrEventID = ""
        _mstrEventDescription = ""
        _mstrEventTypeID = ""
        _mstrSemesterID = ""
        _mstrStartDate = Today()
        _mstrEndDate = Today()
        _mstrLocation = ""
    End Sub
#Region "ExposedProperties"
    Public Property EventID As String
        Get
            Return _mstrEventID
        End Get
        Set(strVal As String)
            _mstrEventID = strVal
        End Set
    End Property
    Public Property EventDescription As String
        Get
            Return _mstrEventDescription
        End Get
        Set(strVal As String)
            _mstrEventDescription = strVal
        End Set
    End Property
    Public Property EventTypeID As String
        Get
            Return _mstrEventTypeID
        End Get
        Set(strVal As String)
            _mstrEventTypeID = strVal
        End Set
    End Property
    Public Property SemesterID As String
        Get
            Return _mstrSemesterID
        End Get
        Set(strVal As String)
            _mstrSemesterID = strVal
        End Set
    End Property
    Public Property StartDate As String
        Get
            Return _mstrStartDate
        End Get
        Set(strVal As String)
            _mstrStartDate = strVal
        End Set
    End Property
    Public Property EndDate As String
        Get
            Return _mstrEndDate
        End Get
        Set(strVal As String)
            _mstrEndDate = strVal
        End Set
    End Property
    Public Property Location As String
        Get
            Return _mstrLocation
        End Get
        Set(strVal As String)
            _mstrLocation = strVal
        End Set
    End Property
    Public Property IsNewEvent As Boolean
        Get
            Return _isNewEvent
        End Get
        Set(blnVal As Boolean)
            _isNewEvent = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params As New ArrayList

            params.Add(New SqlParameter("EventID", _mstrEventID))
            params.Add(New SqlParameter("EventDescription", _mstrEventDescription))
            params.Add(New SqlParameter("EventTypeID", _mstrEventTypeID))
            params.Add(New SqlParameter("SemesterID", _mstrSemesterID))
            params.Add(New SqlParameter("StartDate", _mstrStartDate))
            params.Add(New SqlParameter("EndDate", _mstrEndDate))
            params.Add(New SqlParameter("Location", _mstrLocation))

            Return params
        End Get
    End Property

    Public ReadOnly Property GetUpdateEventParameters() As ArrayList
        Get
            Dim params As New ArrayList

            params.Add(New SqlParameter("EventID", _mstrEventID))
            params.Add(New SqlParameter("EventDescription", _mstrEventDescription))
            params.Add(New SqlParameter("EventTypeID", _mstrEventTypeID))
            params.Add(New SqlParameter("SemesterID", _mstrSemesterID))
            params.Add(New SqlParameter("StartDate", _mstrStartDate))
            params.Add(New SqlParameter("EndDate", _mstrEndDate))
            params.Add(New SqlParameter("Location", _mstrLocation))

            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        If IsNewEvent Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("EventID", _mstrEventID))
            Dim strRes As String = myDB.GetSingleValueFromSP("sp_CheckEventIDExists", params)
            If Not strRes = 0 Then
                Return -1
            End If
        End If
        Return myDB.ExecSP("sp_SaveEvent", GetSaveParameters())
    End Function

    Public Function UpdateEvent() As Integer
        Return myDB.ExecSP("sp_updateEvent", GetUpdateEventParameters())
    End Function

    Private Function CheckEventIDExists() As Integer
        Dim params As New ArrayList
        params.Add(New SqlParameter("EventID", _mstrEventID))
        Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkEventIDExists", params)
        If strResult = 0 Then
            Return -2 'Not present
        End If

        Return 1
    End Function
End Class
