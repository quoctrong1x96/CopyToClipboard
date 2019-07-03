Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.IO
Imports System.Windows.Forms

Public Class FileFolderDialog
    Inherits CommonDialog

    Private _dialog As OpenFileDialog = New OpenFileDialog()

    Public Property Dialog As OpenFileDialog
        Get
            Return _dialog
        End Get
        Set(ByVal value As OpenFileDialog)
            _dialog = value
        End Set
    End Property

    Public Overloads Function ShowDialog() As DialogResult
        Return Me.ShowDialog(Nothing)
    End Function

    Public Overloads Function ShowDialog(ByVal owner As IWin32Window) As DialogResult
        _dialog.ValidateNames = False
        _dialog.CheckFileExists = False
        _dialog.CheckPathExists = True
        _dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        _dialog.Filter = "XML Files (*.xml)|*.xml|All File (*.*)|*.*"

        Try

            If _dialog.FileName IsNot Nothing AndAlso _dialog.FileName <> "" Then

                If Directory.Exists(_dialog.FileName) Then
                    _dialog.InitialDirectory = _dialog.FileName
                Else
                    _dialog.InitialDirectory = Path.GetDirectoryName(_dialog.FileName)
                End If
            End If

        Catch ex As Exception
        End Try

        _dialog.FileName = "Folder Selection."

        If owner Is Nothing Then
            Return _dialog.ShowDialog()
        Else
            Return _dialog.ShowDialog(owner)
        End If
    End Function

    Public Property SelectedPath As String
        Get

            Try

                If _dialog.FileName IsNot Nothing AndAlso (_dialog.FileName.EndsWith("Folder Selection.") OrElse Not File.Exists(_dialog.FileName)) AndAlso Not Directory.Exists(_dialog.FileName) Then
                    Return Path.GetDirectoryName(_dialog.FileName)
                Else
                    Return _dialog.FileName
                End If

            Catch ex As Exception
                Return _dialog.FileName
            End Try
        End Get
        Set(ByVal value As String)

            If value IsNot Nothing AndAlso value <> "" Then
                _dialog.FileName = value
            End If
        End Set
    End Property

    Public ReadOnly Property SelectedPaths As String
        Get

            If _dialog.FileNames IsNot Nothing AndAlso _dialog.FileNames.Length > 1 Then
                Dim sb As StringBuilder = New StringBuilder()

                For Each fileName As String In _dialog.FileNames

                    Try
                        If File.Exists(fileName) Then sb.Append(fileName & ";")
                    Catch ex As Exception
                    End Try
                Next

                Return sb.ToString()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Overrides Sub Reset()
        _dialog.Reset()
    End Sub

    Protected Overrides Function RunDialog(ByVal hwndOwner As IntPtr) As Boolean
        Return True
    End Function
End Class
