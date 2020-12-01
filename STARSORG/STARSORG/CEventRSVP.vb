Imports System.Data.SqlClient
Public Class CEventRSVP
    Private _mintUkid As Integer
    Private _mstrEventID As String
    Private _mstrFName As String
    Private _mstrLName As String
    Private _mstrEmail As String
    Private _isNewUkid As Boolean

    Public Sub New()
        _mintUkid = vbNull
        _mstrEventID = ""
        _mstrFName = ""
        _mstrLName = ""
        _mstrEmail = ""

    End Sub

#Region "ExposedProperties"
    Public Property Ukid As String
        Get
            Return _mintUkid
        End Get
        Set(strVal As String)
            _mintUkid = strVal
        End Set
    End Property
    Public Property EventID As String
        Get
            Return _mstrEventID
        End Get
        Set(strVal As String)
            _mstrEventID = strVal
        End Set
    End Property
    Public Property FName As String
        Get
            Return _mstrFName
        End Get
        Set(strVal As String)
            _mstrFName = strVal
        End Set
    End Property
    Public Property LName As String
        Get
            Return _mstrLName
        End Get
        Set(strVal As String)
            _mstrLName = strVal
        End Set
    End Property
    Public Property Email As String
        Get
            Return _mstrEmail
        End Get
        Set(strVal As String)
            _mstrEmail = strVal
        End Set
    End Property
    Public Property isNewUkid As Boolean
        Get
            Return _isNewUkid
        End Get
        Set(blnVal As Boolean)
            _isNewUkid = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params As New ArrayList

            params.Add(New SqlParameter("EventID", _mstrEventID))
            params.Add(New SqlParameter("FName", _mstrFName))
            params.Add(New SqlParameter("LName", _mstrLName))
            params.Add(New SqlParameter("Email", _mstrEmail))

            Return params
        End Get
    End Property
#End Region
    'Public Function Save() As Integer
    '    'return -1 if the ID already exists (and we can't create a new record with duplicate ID)
    '    Dim intSaveResult As Integer

    '    intSaveResult = CheckEventRSVPExists()

    '    If intSaveResult <> 1 Then
    '        Return intSaveResult
    '    End If
    '    'if not a new role, or it is new and has a unique ID, then do the save (update or insert)
    '    Return myDB.ExecSP("sp_SaveEventRsvp", GetSaveParameters())

    'End Function

    'Private Function CheckEventRSVPExists() As Integer
    '    Dim params As New ArrayList
    '    params.Add(New SqlParameter("Email", _mstrEmail))
    '    params.Add(New SqlParameter("EventID", _mstrEventID))
    '    Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkEventRSVPExists", params)
    '    If Not strResult = 0 Then
    '        Return -2 'Not present
    '    End If

    '    Return 1
    'End Function

    Public Function Save() As Integer
        'Return -1 If the ID already exists (and we cannot create a new record with duplicate ID)
        If isNewUkid Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("Email", _mstrEmail))
            params.Add(New SqlParameter("EventID", _mstrEventID))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckEventRSVPExists", params)
            If Not strResult = 0 Then
                Return -1 'Not Unique
            End If
        End If

        'If not a new role, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveEventRsvp", GetSaveParameters())
    End Function
End Class
