Option Explicit On
'Option Strict On
Imports System.Windows.Forms
Imports System

'To Do:
'- Count Down
'- Languages


Public Class frmscr

    'http://www.mista.ru/net/vbnet_types.htm - what is faster
    Dim shift_hour As Integer, shift_minute As Integer, _
        shift_second As Integer, _
        h As Integer, m As Integer, s As Integer, _
        soundstate As Integer, finalcount As Integer, mouseposx As Integer, _
        mouseposy As Integer, mouseposxdef As Integer, mouseposydef As Integer, formclose As Double
    Public Declare Function GetActiveWindow& Lib "user32" ()
    Dim sec() As System.Windows.Forms.PictureBox = {s0, s1, s2, s3, s4, s5}
    Dim min() As System.Windows.Forms.PictureBox = {m0, m1, m2, m3, m4, m5}
    Dim hou() As System.Windows.Forms.PictureBox = {h0, h1, h2, h3, h4, h5}
    Dim sound As New System.Media.SoundPlayer
    Dim ex As Boolean, fast As Boolean, hourformat24 As Boolean



    Private Sub f_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' System.Windows.Forms.Cursor.Hide()
        'Dim column As Integer, row As Integer
        'Dim frmctrlarray(5, 2) As PictureBox
        '   column = 5
        '  row = 2
        ' For Each tmpControl In Me.Controls
        ' MsgBox("Column: " & Str(column) & Chr(13) & "Row: " & Str(row) & Chr(13) & "Name: " & tmpControl.name)
        'frmctrlarray(column, row) = CType(tmpControl, PictureBox)
        'If column = 0 Then
        'column = 6
        'row -= 1
        'End If
        'column -= 1
        'Next tmpControl
        'End If
        'Hising cursor and moving pointer

        'allsounds = True
        My.Settings.Reload()
        base = My.Settings.base_setting
        allsounds = My.Settings.allsounds_setting
        centered = My.Settings.centered_setting
        fast = My.Settings.FastExit_setting
        hourformat24 = My.Settings.hourformat24_setting
        baselabel.Text = "Base: " & Str(base)





        My.Settings.runs += 1
        My.Settings.Save()

        'Counting length of converted number
        Do While (base ^ arraylen) < 59
            arraylen += 1
        Loop

        arraylen -= 1

        ReDim converted(arraylen)

        formclose = CDbl(GetActiveWindow)
      

        'Making arrays of form elements
        sec(0) = s0 : sec(1) = s1 : sec(2) = s2
        sec(3) = s3 : sec(4) = s4 : sec(5) = s5

        min(0) = m0 : min(1) = m1 : min(2) = m2
        min(3) = m3 : min(4) = m4 : min(5) = m5

        hou(0) = h0 : hou(1) = h1 : hou(2) = h2
        hou(3) = h3 : hou(4) = h4 : hou(5) = h5

        Call visual_preload(allsounds)

        If CBool(Screen.PrimaryScreen.Bounds.Width <> 640) And CBool(Screen.PrimaryScreen.Bounds.Height <> 480) Then Call resizer()


       

        For Each tmpControl In Me.Controls
            tmpControl.backgroundimage = images(0)
        Next tmpControl


        mouseposx = System.Windows.Forms.Cursor.Position.X
        mouseposy = System.Windows.Forms.Cursor.Position.Y
        mouseposxdef = mouseposx
        mouseposydef = mouseposy

        System.Windows.Forms.Cursor.Hide()
        'Cursor.Position = New Point(0, 3000)

        'Adding Handlers
        Dim ctl As Control
        For Each ctl In MyBase.Controls
            AddHandler ctl.Click, New System.EventHandler(AddressOf exitflagmouse)
            AddHandler ctl.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf mousetrack)
        Next ctl

        AddHandler Me.Click, New System.EventHandler(AddressOf exitflagmouse)
        AddHandler Me.KeyDown, New System.Windows.Forms.KeyEventHandler(AddressOf Me.exitflag)
        AddHandler Me.MouseWheel, New System.Windows.Forms.MouseEventHandler(AddressOf Me.exitflagmouse)
        AddHandler Me.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf Me.mousetrack)




        Dim Pn As Process = Process.GetCurrentProcess
        EmptyWorkingSet(CInt(Pn.Handle))


        'Magic Begins



        Appear.Enabled = True

    End Sub
    Private Sub visual_preload(ByRef sound_enabled As Boolean)
        If sound_enabled = True Then
            SoundTiming.Enabled = True
        Else
            Select Case base
                Case 2
                    'For base 2 (6 digits)
                    For Each tmpControl In Me.Controls
                        tmpControl.visible = True
                    Next tmpControl
                    shift_hour = 0
                    shift_minute = 0
                    shift_second = 0



                Case 3
                    'For base 3 (4 digits)

                    If centered = True Then
                        h1.Visible = True
                        h2.Visible = True
                        h3.Visible = True
                        h4.Visible = True
                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True
                        s1.Visible = True
                        s2.Visible = True
                        s3.Visible = True
                        s4.Visible = True

                        shift_hour = 1
                        shift_minute = 1
                        shift_second = 1
                    Else
                        h0.Visible = True
                        h1.Visible = True
                        h2.Visible = True
                        h3.Visible = True
                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True
                        s2.Visible = True
                        s3.Visible = True
                        s4.Visible = True
                        s5.Visible = True
                        shift_hour = 0
                        shift_minute = 1
                        shift_second = 2
                    End If

                Case 4 To 7
                    ' For base 7 to 4 (3 digits)
                    If centered = True Then
                        h1.Visible = True
                        h2.Visible = True
                        h3.Visible = True
                        h4.Visible = True
                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True
                        s1.Visible = True
                        s2.Visible = True
                        s3.Visible = True
                        s4.Visible = True
                        shift_hour = 2
                        shift_minute = 2
                        shift_second = 2
                    Else
                        h0.Visible = True
                        h1.Visible = True
                        h2.Visible = True
                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True
                        s3.Visible = True
                        s4.Visible = True
                        s5.Visible = True
                        shift_hour = 0
                        shift_minute = 2
                        shift_second = 3
                    End If

                Case 8 To 10
                    'For base 10 to 8 (2 digits)
                    If centered = True Then
                        m0.Visible = True
                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True
                        m5.Visible = True
                        hou(0) = Me.m0
                        hou(1) = Me.m1
                        min(2) = Me.m2
                        min(3) = Me.m3
                        sec(4) = Me.m4
                        sec(5) = Me.m5
                        shift_hour = 0
                        shift_minute = 2
                        shift_second = 4
                    Else
                        h0.Visible = True
                        h1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        s4.Visible = True
                        s5.Visible = True
                        shift_hour = 0
                        shift_minute = 2
                        shift_second = 4
                    End If
                Case Else
                    End
            End Select
            Clock.Enabled = True
        End If
    End Sub

    Private Sub new_numeral_system_number_in_array(ByVal numb As Integer)

        i = arraylen

        Do While (numb >= 1)
            converted(i) = CInt(numb Mod base)
            numb = CInt(numb \ base)
            i -= 1
        Loop

    End Sub

    Private Sub resizer()
        If CBool(base > 7) And CBool(centered = True) Then
            m1.Location = New Point(m1.Location.X - 10, m1.Location.Y)
            m2.Location = New Point(m2.Location.X + 5, m1.Location.Y)
            m3.Location = New Point(m3.Location.X - 5, m1.Location.Y)
            m4.Location = New Point(m4.Location.X + 10, m1.Location.Y)
        End If
        For Each tmpControl In Me.Controls
            tmpControl.Left = (tmpControl.Left * Screen.PrimaryScreen.Bounds.Width / 640)
            tmpControl.Top = (tmpControl.Top * Screen.PrimaryScreen.Bounds.Height / 480)
            tmpControl.Width = tmpControl.Width * Screen.PrimaryScreen.Bounds.Width / 640
            tmpControl.Height = tmpControl.Height * Screen.PrimaryScreen.Bounds.Height / 480
        Next tmpControl
    End Sub


    Private Sub TicTac(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        s = Second(Now)



        new_numeral_system_number_in_array(s)

        For i As Integer = 0 To arraylen
            sec(i + shift_second).BackgroundImage = images(converted(i))
        Next

        Array.Clear(converted, 0, converted.Length)



        If m <> Minute(Now) Then


            m = Minute(Now)
            new_numeral_system_number_in_array(m)


            For i As Integer = 0 To arraylen

                min(i + shift_minute).BackgroundImage = images(converted(i))



            Next
            Array.Clear(converted, 0, converted.Length)
        End If



        If h <> Hour(Now) Then
            h = Hour(Now)
            'Console.WriteLine(now.ToShortTimeString())
            If hourformat24 = False Then
                new_numeral_system_number_in_array(CInt(System.DateTime.Now.ToString("hh")))
            Else
                new_numeral_system_number_in_array(h)
            End If



            For i As Integer = 0 To arraylen

                hou(i + shift_hour).BackgroundImage = images(converted(i))

            Next

            Array.Clear(converted, 0, converted.Length)
        End If



        If GetActiveWindow <> formclose Then

            If fast = True Then End

            If My.Settings.allsounds_setting = True Then
                soundstate = 0
                Disappear.Enabled = True
            Else
                Disappear.Enabled = True
            End If
        End If
    End Sub



    Private Sub Disappear_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Disappear.Tick
        If allsounds = True Then
            allsounds = False
            sound.Stream = My.Resources.ShutDown
            sound.Play()
        End If


        Me.Opacity -= 0.02
        finalcount += 1

        If finalcount = 50 Then Cursor.Position = New Point(mouseposxdef, mouseposydef) : End

    End Sub
    Private Sub exitflag(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode <> 17 Then

            If (e.KeyCode = Keys.F1 Or e.KeyCode = Keys.F2) And ex = False Then



                Clock.Enabled = False
                MsgBox("Nixie Clock" & Chr(13) & "Version: " & My.Settings.Version & Chr(13) & Chr(13) & "Developer: Alexey Elin" & Chr(13) & _
                                       "E-mail: alexey.elin@gmail.com" & Chr(13) & Chr(13) & "More info in settings.", vbInformation, "About:")
                Clock.Enabled = True
                ex = True
            Else

                If fast = True Then End

                Disappear.Enabled = True
            End If
        End If
    End Sub
    Private Sub transperonctrlon(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 17 Then Me.Opacity = 0.1
        Me.WindowState = vbMinimizedFocus
    End Sub
    Private Sub transperoffctrlon(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = 17 Then Me.Opacity = 1
        Me.WindowState = vbNormal

    End Sub

    Private Sub exitflagmouse(ByVal sender As Object, ByVal e As System.EventArgs)
        If fast = True Then End

        Disappear.Enabled = True


    End Sub
    Private Sub mousetrack(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If CBool(System.Windows.Forms.Cursor.Position.X > (mouseposx + My.Settings.mouse_sens_setting)) Or CBool(System.Windows.Forms.Cursor.Position.Y > (mouseposy + _
 My.Settings.mouse_sens_setting)) Then

            If fast = True Then
                Cursor.Position = New Point(mouseposxdef, mouseposydef)
                Me.Close()
            End If
            Disappear.Enabled = True
        Else
            mouseposx = System.Windows.Forms.Cursor.Position.X
            mouseposy = System.Windows.Forms.Cursor.Position.Y
        End If
    End Sub
    Private Sub Appear_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Appear.Tick
        If Me.Opacity < 1 Then
            Me.Opacity += 0.02
        Else

            'Dont ask me why it's working.
            baselabel.Visible = True
            Cursor.Hide()
            baselabel.Visible = False
            Appear.Dispose()
        End If

    End Sub


    Private Sub frmscr_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub SoundTiming_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundTiming.Tick

        Select Case base
            Case 2
                'For base 2 (6 digits)
                Select Case soundstate

                    Case 1
                        sound.Stream = My.Resources._On
                        sound.Play()
                    Case 30
                        For i As Integer = 0 To UBound(hou)
                            hou(i).Visible = True
                        Next
                    Case 130
                        For i As Integer = 0 To UBound(min)
                            min(i).Visible = True
                        Next
                    Case 184
                        For i As Integer = 0 To UBound(sec)
                            sec(i).Visible = True
                        Next
                    Case 235
                        Clock.Enabled = True
                        SoundTiming.Dispose()

                End Select



            Case 3
                'For base 3 (4 digits)
                Select Case soundstate
                    Case 1
                        sound.Stream = My.Resources._On
                        sound.Play()
                        If centered = True Then
                            shift_hour = 1
                            shift_minute = 1
                            shift_second = 1
                        Else
                            shift_hour = 0
                            shift_minute = 1
                            shift_second = 2
                        End If
                    Case 30
                        If centered = True Then
                            h1.Visible = True
                            h2.Visible = True
                            h3.Visible = True
                            h4.Visible = True
                        Else
                            h0.Visible = True
                            h1.Visible = True
                            h2.Visible = True
                            h3.Visible = True
                        End If
                    Case 130
                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True
                    Case 184
                        If centered = True Then
                            s1.Visible = True
                            s2.Visible = True
                            s3.Visible = True
                            s4.Visible = True
                        Else
                            s2.Visible = True
                            s3.Visible = True
                            s4.Visible = True
                            s5.Visible = True
                        End If
                    Case 235
                        Clock.Enabled = True
                        SoundTiming.Dispose()
                End Select



            Case 4 To 7
                ' For base 7 to 4 (3 digits)

                Select Case soundstate
                    Case 1
                        sound.Stream = My.Resources._On
                        sound.Play()
                    Case 30
                        If centered = True Then
                            h1.Visible = True
                            h2.Visible = True
                            h3.Visible = True
                            h4.Visible = True
                            shift_hour = 2
                            shift_minute = 2
                            shift_second = 2
                        Else
                            h0.Visible = True
                            h1.Visible = True
                            h2.Visible = True
                            shift_hour = 0
                            shift_minute = 2
                            shift_second = 3
                        End If
                    Case 130

                        m1.Visible = True
                        m2.Visible = True
                        m3.Visible = True
                        m4.Visible = True

                    Case 184

                        If centered = True Then

                            s1.Visible = True
                            s2.Visible = True
                            s3.Visible = True
                            s4.Visible = True
                        Else
                            s3.Visible = True
                            s4.Visible = True
                            s5.Visible = True
                        End If
                    Case 235
                        Clock.Enabled = True
                        SoundTiming.Dispose()
                End Select




            Case 8 To 10
                'For base 10 to 8 (2 digits)

                Select Case soundstate
                    Case 1
                        sound.Stream = My.Resources._On
                        sound.Play()
                    Case 30
                        If centered = True Then
                            m0.Visible = True
                            m1.Visible = True
                            hou(0) = Me.m0
                            hou(1) = Me.m1
                            min(2) = Me.m2
                            min(3) = Me.m3
                            sec(4) = Me.m4
                            sec(5) = Me.m5
                            shift_hour = 0
                            shift_minute = 2
                            shift_second = 4
                        Else
                            h0.Visible = True
                            h1.Visible = True
                            shift_hour = 0
                            shift_minute = 2
                            shift_second = 4
                        End If
                    Case 130

                        m2.Visible = True
                        m3.Visible = True


                    Case 184

                        If centered = True Then
                            m4.Visible = True
                            m5.Visible = True

                        Else
                            s4.Visible = True
                            s5.Visible = True
                        End If
                    Case 235
                        Clock.Enabled = True
                        SoundTiming.Dispose()
                End Select

        End Select

        soundstate += 1
    End Sub

    Private Sub CountDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountDownTimer.Tick

    End Sub
End Class
