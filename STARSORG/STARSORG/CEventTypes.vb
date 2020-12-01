Imports System.Data.SqlClient
Public Class CEventTypes
    'Represents the EVENT_TYPE table and its associated business rules
    Private _EventType As CEventType
    'constructor
    Public Sub New()
        'instantiate the CEventType object
        _EventType = New CEventType
    End Sub

    Public ReadOnly Property CurrentObject() As CEventType
        Get
            Return _EventType
        End Get
    End Property

    Public Sub Clear()
        _EventType = New CEventType
    End Sub

    Public Sub CreateNewEventType()
        'call this routine when clearing the edit portion of the screen to add a new event type
        Clear()
        _EventType.IsNewEventType = True
    End Sub
    Public Function Save() As Integer
        Return _EventType.Save
    End Function

    Public Function GetAllEventTypes() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllEventTypes", Nothing)
        Return objDR
    End Function

    Public Function GetEventTypeByID(strID As String) As CEventType
        Dim params As New ArrayList
        params.Add(New SqlParameter("EventTypeID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventTypeByID", params))
        Return _EventType
    End Function

    Private Function FillObject(objDR As SqlDataReader) As CEventType
        If objDR.Read() Then 'found the event type record
            With _EventType
                .EventTypeID = objDR.Item("EventTypeID") & ""
                .EventTypeDescription = objDR.Item("EventTypeDescription") & ""
            End With
        Else
            'did not get a matching event type record
        End If
        objDR.Close()
        Return _EventType
    End Function
End Class
