
'Use only ONE of these Main methods.
Public Module LaunchApp

    Public Sub Main()
        'Turn visual styles back on
        Application.EnableVisualStyles()
        If AlreadyRunning() Then
            MessageBox.Show(
        "Another instance is already running.",
        "Already Running",
        MessageBoxButtons.OK,
        MessageBoxIcon.Exclamation)
        Else
            'Run the application using AppContext
            Application.Run(New AppContext)
        End If


        ''You can also run the application using a main form
        'Application.Run(New MainForm)

        ''Or in a default context with no user interface at all
        'Application.Run()
    End Sub

    'Public Sub Main(ByVal cmdArgs() As String)
    '    Application.EnableVisualStyles()

    '    Dim UseTray As Boolean = False

    '    For Each Cmd As String In cmdArgs
    '        If Cmd.ToLower = "-tray" Then
    '            UseTray = True
    '            Exit For
    '        End If
    '    Next

    '    If UseTray Then
    '        Application.Run(New AppContext)
    '    Else
    '        Application.Run(New MainForm)
    '    End If
    'End Sub

    'Public Function Main() As Integer
    'End Function

    'Public Function Main(ByVal cmdArgs() As String) As Integer
    'End Function


    ''' <summary>
    ''' Return True if another instance
    ''' of this program is already running.
    ''' </summary>
    ''' <returns></returns>
    Private Function AlreadyRunning() As Boolean
        ' Get our process name.
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName

        ' Get information about processes with this name.
        Dim procs() As Process =
            Process.GetProcessesByName(my_name)

        ' If there is only one, it's us.
        If procs.Length = 1 Then Return False

        ' If there is more than one process,
        ' see if one has a StartTime before ours.
        Dim i As Integer
        For i = 0 To procs.Length - 1
            If procs(i).StartTime < my_proc.StartTime Then _
                Return True
        Next i

        ' If we get here, we were first.
        Return False
    End Function
End Module
