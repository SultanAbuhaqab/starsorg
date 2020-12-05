Imports System.Data.SqlClient
Public Class CMember
    ' Represents a single record in the Member TABLE
    ' NAMING CONVENTION: 
    '   Class Instance Varibles start With an underscore
    '   Include "m" to indicate it is at the module level oposed to being in a form

    Private _mstrPID As String ' Max length is 7
    Private _mstrFName As String ' Max length is 50
    Private _mstrLName As String ' Max Length is 75
    Private _mstrMI As String ' Max Length is 1
    Private _mstrEmail As String ' Max Length is 50
    Private _mstrPhone As String ' Max Length is 13
    Private _mstrPhotoPath As String ' Max Length is 300
    Private _isNewMember As Boolean

    ' Constructor
    Public Sub New()
        _mstrPID = ""
        _mstrFName = ""
        _mstrLName = ""
        _mstrMI = ""
        _mstrEmail = ""
        _mstrPhone = ""
        _mstrPhotoPath = ""
    End Sub

#Region "Exposed Property"
    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
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

    Public Property MI As String
        Get
            Return _mstrMI
        End Get
        Set(strVal As String)
            _mstrMI = strVal
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

    Public Property Phone As String
        Get
            Return _mstrPhone
        End Get
        Set(strVal As String)
            _mstrPhone = strVal
        End Set
    End Property

    Public Property PhotoPath As String
        Get
            Return _mstrPhotoPath
        End Get
        Set(strVal As String)
            _mstrPhotoPath = strVal
        End Set
    End Property

    Public Property isNewMember As Boolean
        Get
            Return _isNewMember
        End Get
        Set(blnVal As Boolean)
            _isNewMember = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        ' This property's code will create the parameters for the stored procedure to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("FName", _mstrFName))
            params.Add(New SqlParameter("LName", _mstrLName))
            params.Add(New SqlParameter("MI", _mstrMI))
            params.Add(New SqlParameter("Email", _mstrEmail))
            params.Add(New SqlParameter("Phone", _mstrPhone))
            params.Add(New SqlParameter("PhotoPath", _mstrPhotoPath))
            Return params
        End Get
    End Property
#End Region

    Public Function Save() As Integer
        ' Return -1 if the PID already exists (and we cannot create a new record with duplicate ID)
        If isNewMember Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkPIDExistsInMember", params)
            If Not strResult = 0 Then
                Return -1 'Not Unique
            End If
        End If
        ' If not a new role, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveMember", GetSaveParameters())
    End Function
End Class
