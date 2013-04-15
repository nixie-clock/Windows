Option Explicit On
Option Strict On
Public Class frmconfig
    Dim smallsize As Integer, bigsize As Integer
    ' Dim newPoint As New System.Drawing.Point()
    'Dim a, b As Integer

    '    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '       a = Control.MousePosition.X - Me.Location.X
    '      b = Control.MousePosition.Y - Me.Location.Y
    '  End Sub
    ' Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = MouseButtons.Left Then
    '       newPoint = Control.MousePosition
    '      newPoint.X = newPoint.X - (a)
    '     newPoint.Y = newPoint.Y - (b)
    '     Me.Location = newPoint
    ' End If
    'End Sub


    ' Private Sub str_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
    '   Me.Capture = FalseSS
    '    Me.WndProc(Message.Create(Me.Handle, &HA1, New IntPtr(2), IntPtr.Zero))
    'End Sub
    Private Sub frmconfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oldtopLabel As Integer, shift As Integer
        frmstart.Dispose()
        smallsize = logo.Width + g1.Width + CInt(g1.Width / 15)
        bigsize = logo.Width + CInt(2 * g1.Width) + CInt(g1.Width / 10)
        Me.Width = smallsize

        oldtopLabel = AboutLabel.Top
        AboutLabel.Top = CInt((Me.Height - AboutLabel.Height) / 2)
        shift = AboutLabel.Top - oldtopLabel

        LinkLabel.Top += shift
        LinkLabel1.Top += shift


        appear.Enabled = True
        Dim ctl As Control
        For Each ctl In MyBase.Controls
            AddHandler ctl.KeyDown, New System.Windows.Forms.KeyEventHandler(AddressOf exitflag)
        Next ctl
        For Each ctl In g1.Controls
            AddHandler ctl.KeyDown, New System.Windows.Forms.KeyEventHandler(AddressOf exitflag)
        Next ctl
        BaseBox.Text = Str(My.Settings.base_setting)
        If CInt(BaseBox.Text) = 10 Then
            logo.BackgroundImage = images(0)
        Else
            logo.BackgroundImage = images(CInt(BaseBox.Text))
        End If

        'If My.Settings.centered_setting = True Then Centered.Checked = True
        Centered.Checked = My.Settings.centered_setting
        'If My.Settings.allsounds_setting = True Then Sound.Checked = True
        Sound.Checked = My.Settings.allsounds_setting
        ' If My.Settings.Transparency_setting = True Then TranspKey.Checked = True
        FastExit.Checked = My.Settings.FastExit_setting
        HourForm.Checked = My.Settings.hourformat24_setting
        MouseSensAdj.Value = 7 - CInt(My.Settings.mouse_sens_setting)
        appear.Enabled = True
        Dim Pn As Process = Process.GetCurrentProcess
        EmptyWorkingSet(CInt(Pn.Handle))
        GC.Collect()
    End Sub
    Private Sub okclicksub()
        My.Settings.allsounds_setting = Sound.Checked
        My.Settings.centered_setting = Centered.Checked
        My.Settings.FastExit_setting = FastExit.Checked
        My.Settings.base_setting = CInt(BaseBox.Value)
        My.Settings.hourformat24_setting = HourForm.Checked
        My.Settings.mouse_sens_setting = 7 - MouseSensAdj.Value
        My.Settings.Save()
        My.Settings.Reload()
        disappear.Enabled = True
    End Sub

    Private Sub Setsettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Setsettings.Click
        Call okclicksub()
    End Sub

    Private Sub Defaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Defaults.Click
        BaseBox.Value = 2
        Sound.Checked = False
        Centered.Checked = False
        FastExit.Checked = True
        HourForm.Checked = True
        MouseSensAdj.Value = 0
    End Sub
    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        If Screen.PrimaryScreen.Bounds.Width < Me.Width Then
            MsgBox("Nixie Clock" & Chr(13) & "Version: " & My.Settings.Version & Chr(13) & Chr(13) & "Developer: Alexey Elin" & Chr(13) & _
                          "E-mail: alexey.elin@gmail.com" & Chr(13) & Chr(13) & "Local Runs:" & Str(My.Settings.runs) & Chr(13), vbInformation, "About:")
        ElseIf Me.Width < bigsize Then
            AboutTimerEnd.Enabled = False
            AboutTimer.Enabled = True
            AboutLabel.Text = "Nixie Clock Version: " & My.Settings.Version & Chr(13) & Chr(13) & "Developer: Alexey Elin" & Chr(13) & "E-mail: " & _
  Chr(13) & Chr(13) & Chr(13) & "Local Runs: " & Str(My.Settings.runs) & Chr(13) & Chr(13) & "Project"

        Else
            AboutTimer.Enabled = False
            AboutTimerEnd.Enabled = True

        End If

    End Sub
    Private Sub Base_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseBox.ValueChanged
        If BaseBox.Value = 10 Then
            logo.BackgroundImage = images(0)
        Else
            logo.BackgroundImage = images(CInt(BaseBox.Value))
        End If
    End Sub


    Private Sub LinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel.LinkClicked
        System.Diagnostics.Process.Start("http://nim579.ru/android/nixie-clock.html")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:" & "alexey@rhino.ru")
        End
    End Sub

    Private Sub appear_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles appear.Tick
        Me.Opacity += 0.05
        If Me.Opacity = 1 Then appear.Enabled = False
    End Sub

    Private Sub AboutTimerEnd_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTimerEnd.Tick
        If Me.Width > smallsize Then
            Me.Width -= 9
        Else
            AboutTimerEnd.Enabled = False
        End If
    End Sub

    Private Sub AboutTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutTimer.Tick
        If Me.Width < bigsize Then
            Me.Width += 9
        Else
            AboutTimer.Enabled = False
        End If
    End Sub
    Private Sub disappear_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disappear.Tick
        Me.Opacity = Me.Opacity - 0.05
        If Me.Opacity = 0 Then Me.Dispose() : End
    End Sub
    Private Sub frmcnfg_UnLoad(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If MsgBox("Exit program without saving settings?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        'e.Cancel = True
        'Else
        'disappear.Enabled = True
        'End
        'End If
        Call okclicksub()
        End
    End Sub
    Private Sub exitflag(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then Call okclicksub() : End
    End Sub
End Class
