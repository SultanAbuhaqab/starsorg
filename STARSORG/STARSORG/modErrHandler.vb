Imports System.Globalization
Imports System.Text.RegularExpressions
Module modErrHandler
    'useful routines for input validation
    Public Function ValidateTextBoxLength(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        'This procedure validates that a textbox is not empty
        If obj.Text.Length = 0 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must enter a value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateTextBoxNumeric(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        'This procedure validates that a textbox has a numeric value
        If Not IsNumeric(obj.Text) Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must enter a numeric value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateTextBoxNotNumeric(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        'This procedure validates that a textbox has a numeric value
        If Not IsNumeric(obj.Text) Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must enter a numeric value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateTextBoxDate(ByRef obj As MaskedTextBox, ByRef errP As ErrorProvider) As Boolean
        'This procedure validates that a textbox has a valid date value
        If Not IsDate(obj.Text) Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must enter a valid date value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateCombo(ByRef obj As ComboBox, ByRef errP As ErrorProvider) As Boolean
        'This procedure validates that a textbox has a valid date value
        If obj.SelectedIndex = -1 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must make a selection here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
    Public Function ValidateMaskedTextBoxLength(ByRef obj As MaskedTextBox, ByRef errP As ErrorProvider) As Boolean
        'This procedure validates that a textbox is not empty
        If obj.Text.Length = 0 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must enter a value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function

    Public Function ValidateEmail(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        Dim regex As Regex = New Regex("^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
        If regex.IsMatch(obj.Text.Trim) Then
            Return True
        Else
            errP.SetError(obj, "")
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleRight)
            errP.SetError(obj, "You must enter a valid email address")
            obj.Focus()
            Return False
        End If
    End Function
End Module
