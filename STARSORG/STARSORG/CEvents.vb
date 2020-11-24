Imports System.Data.SqlClient
Public Class CEvents
    'Represents the EVENT table and its associated business rules
    Private _Event As CEvent
    'constructor
    Public Sub New()
        'instantiate the CEvent object
        _Event = New CEvent
    End Sub

    Public ReadOnly Property CurrentObject() As CEvent
        Get
            Return _Event
        End Get
    End Property

    Public Sub Clear()
        _Event = New CEvent
    End Sub

    Public Sub CreateNewEvent()
        'call this routine when clearing the edit portion of the screen to add a new event
        Clear()
        _Event.IsNewEvent = True
    End Sub
    Public Function Save() As Integer
        Return _Event.Save
    End Function

    Public Function GetAllEvents() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllEvents", Nothing)
        Return objDR
    End Function

    Public Function GetEventByID(strEventID As String) As CEvent
        Dim params As New ArrayList
        params.Add(New SqlParameter("EventID", strEventID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventByID", params))
        Return _Event
    End Function

    Private Function FillObject(objDR As SqlDataReader) As CEvent
        If objDR.Read Then
            FillEventObject(objDR.Item("EventID"), objDR.Item("EventDescription"), objDR.Item("EventTypeID"), objDR.Item("SemesterID"), objDR.Item("StartDate"), objDR.Item("EndDate"), objDR.Item("Location"))
        End If
        'If objDR.Read Then
        '    With _Event
        '        .EventID = objDR.Item("EventID")
        '        .EventDescription = objDR.Item("EventDescription")
        '        .EventTypeID = objDR.Item("EventTypeID")
        '        .SemesterID = objDR.Item("SemesterID")
        '        .StartDate = objDR.Item("StartDate")
        '        .EndDate = objDR.Item("EndDate")
        '        .Location = objDR.Item("Location")
        '    End With
        'Else
        '    'No record was returned, Nothing else to do
        'End If
        objDR.Close()
        Return _Event
    End Function

    Private Sub FillEventObject(strEventID As String, strEventDescription As String, strEventTypeID As String, strSemesterID As String, strStartDate As String, strEndDate As String, strLocation As String)
        With _Event
            .EventID = strEventID
            .EventDescription = strEventDescription
            .EventTypeID = strEventTypeID
            .SemesterID = strSemesterID
            .StartDate = strStartDate
            .EndDate = strEndDate
            .Location = strLocation
        End With
    End Sub
End Class