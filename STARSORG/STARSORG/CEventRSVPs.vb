Imports System.Data.SqlClient
Public Class CEventRSVPs
    'Represents the EVENT_RSVP table and its associated business rules
    Private _EventRSVP As CEventRSVP
    'constructor
    Public Sub New()
        'instantiate the CEventRSVP object
        _EventRSVP = New CEventRSVP
    End Sub

    Public ReadOnly Property CurrentObject() As CEventRSVP
        Get
            Return _EventRSVP
        End Get
    End Property

    Public Sub Clear()
        _EventRSVP = New CEventRSVP
    End Sub

    Public Sub CreateNewEventRSVP()
        'call this routine when clearing the edit portion of the screen to add a new eventRSVP
        Clear()
        _EventRSVP.isNewUkid = True
    End Sub
    Public Function Save() As Integer
        Return _EventRSVP.Save
    End Function

    Public Function GetAllEventRSVPs() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_GetAllEventRSVPs", Nothing)
        Return objDR
    End Function

    Public Function GetEventTypeByID(strID As String) As CEventRSVP
        Dim params As New ArrayList
        params.Add(New SqlParameter("Ukid", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventRSVPByID", params))
        Return _EventRSVP
    End Function

    Private Function FillObject(objDR As SqlDataReader) As CEventRSVP
        If objDR.Read() Then 'found the EventRSVP record
            With _EventRSVP
                .Ukid = objDR.Item("Ukid") & ""
                .EventID = objDR.Item("EventID") & ""
                .FName = objDR.Item("FName") & ""
                .LName = objDR.Item("LName") & ""
                .Email = objDR.Item("Email") & ""
            End With
        Else
            'did not get a matching EventRSVP record
        End If
        objDR.Close()
        Return _EventRSVP
    End Function
End Class
