Imports System.Data.SqlClient
Public Class CEventRSVP
    Private _mstrUkid As String
    Private _mstrEventID As String
    Private _mstrFName As String
    Private _mstrLName As String
    Private _mstrEmail As String
    Private _isNewUkid As Boolean

    Public Sub New()
        _mstrUkid = ""
        _mstrEventID = ""
        _mstrFName = ""
        _mstrLName = ""
        _mstrEmail = ""

    End Sub

#Region "ExposedProperties"
    Public Property ukid As String
        Get
            Return _mstrUkid
        End Get
        Set(strVal As String)
            _mstrUkid = strVal
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
            params.Add(New SqlParameter("uKid", _mstrUkid))
            params.Add(New SqlParameter("eventID", _mstrEventID))
            params.Add(New SqlParameter("fName", _mstrFName))
            params.Add(New SqlParameter("lName", _mstrLName))
            params.Add(New SqlParameter("email", _mstrEmail))

            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        'return -1 if the ID already exists (and we can't create a new record with duplicate ID)
        If isNewUkid Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("ukid", _mstrUkid))
            Dim strRes As String = myDB.GetSingleValueFromSP("sp_CheckRSVPExists", params)
            If Not strRes = 0 Then
                Return -1  'not UNIQUE!
            End If
        End If
        'if not a new role, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveEventRSVP", GetSaveParameters())

    End Function
End Class
