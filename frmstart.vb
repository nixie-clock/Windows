Option Explicit On
Option Strict On
Public Class frmstart

    'Public Sub Main()
    ' If InStr(Command, "/s") > 0 Then

    '        Dim usercnfg As New frmscr
    '       usercnfg.Show()

    'Me.Dispose()


    'ElseIf InStr(Command, "/c") > 0 Or InStr(Command, "/S") > 0 Then
    'Dim usercnfg As New frmcnfg
    'usercnfg.Show()
    'Me.Dispose()


    'ElseIf InStr(Command, "/l") > 0 Then
    'End
    'Me.Dispose()
    'End If


    'End Sub

    Private Sub frmstart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim arguments() As String
        Console.WriteLine()
        arguments = Environment.GetCommandLineArgs()
        Console.WriteLine("GetCommandLineArgs: {0}", [String].Join(", ", arguments))
        'For i = 0 To UBound(arguments)
        'MsgBox(arguments(i))
        ' Next
        'MsgBox(Str(My.Settings.centered_setting))
        If arguments.Length > 1 Then
            Select Case arguments(1)
                Case "/p"
                    End
                Case "/S"
                    Dim usercnfg As New frmscr
                    usercnfg.Show()

                Case "/c"
                    Dim usercnfg As New frmconfig
                    usercnfg.Show()
                Case "/s"
                    Dim usercnfg As New frmscr
                    usercnfg.Show()
                Case Else
                    Dim usercnfg As New frmconfig
                    usercnfg.Show()
            End Select
        Else
            Dim usercnfg As New frmconfig
            usercnfg.Show()
        End If
        Me.Dispose()
        Me.Close()
    End Sub
End Class