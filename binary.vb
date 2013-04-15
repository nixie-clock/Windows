Option Explicit On
'Option Strict On
Imports System.Windows.Forms
Public Class binary
    Public Declare Function GetActiveWindow& Lib "user32" ()
    Dim h, m, s, i, base, pause, finalcount, mouseposx, mouseposy As Integer
    Dim formclose As Double
    Dim arraylen, converted(), shift_hour, shift_minute, shift_second As Byte
    Dim visibility_mode As String
    Dim changeh, changem, ex, allsounds, centered As Boolean
    Dim data() As Bitmap = {My.Resources.t0, My.Resources.t1, My.Resources.t2, My.Resources.t3, My.Resources.t4, My.Resources.t5, My.Resources.t6, My.Resources.t7, My.Resources.t8, My.Resources.t9}
    Dim sec() As System.Windows.Forms.PictureBox = {s0, s1, s2, s3, s4, s5}
    Dim min() As System.Windows.Forms.PictureBox = {m0, m1, m2, m3, m4, m5}
    Dim hou() As System.Windows.Forms.PictureBox = {h0, h1, h2, h3, h4, h5}
    Dim sound As New System.Media.SoundPlayer
    Private Sub f_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<settings>
        Dim s As String
        My.Settings.base_setting = CByte(InputBox("Base:", "", My.Settings.base_setting))
        If My.Settings.base_setting > 10 Or My.Settings.base_setting < 2 Then My.Settings.base_setting = 2
        s = InputBox("Centered?", "", My.Settings.centered_setting)
        If s <> "True" Or s <> "False" Then s = "False"
        My.Settings.centered_setting = CBool(s)
        s = InputBox("Sound?", "", My.Settings.allsounds_setting)
        If s <> "True" Or s <> "False" Then s = "True"
        My.Settings.allsounds_setting = CBool(s)
        My.Settings.Save()
        base = My.Settings.base_setting
        centered = My.Settings.centered_setting
        allsounds = My.Settings.allsounds_setting
        '</settings>


        Dim ctl As Control
        For Each ctl In MyBase.Controls
            AddHandler ctl.Click, New EventHandler(AddressOf Me.exitflagmouse)
        Next ctl

        AddHandler Me.KeyDown, New System.Windows.Forms.KeyEventHandler(AddressOf Me.exitflag)
        AddHandler Me.MouseWheel, New System.Windows.Forms.MouseEventHandler(AddressOf Me.exitflagmouse)
        AddHandler Me.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf Me.mousetrack)

        If Screen.PrimaryScreen.Bounds.Width > 640 Then Call resizer()

        formclose = CDbl(GetActiveWindow)

        Cursor.Hide()

        Cursor.Position = New Point(0, 3000)
        mouseposx = System.Windows.Forms.Cursor.Position.X
        mouseposy = System.Windows.Forms.Cursor.Position.Y




        Call declar(arraylen)
        ReDim converted(arraylen)







        Appear.Enabled = True


    End Sub
    Private Sub declar(ByRef arraylensub As Byte)

        sec(0) = s0
        sec(1) = s1
        sec(2) = s2
        sec(3) = s3
        sec(4) = s4
        sec(5) = s5

        min(0) = m0
        min(1) = m1
        min(2) = m2
        min(3) = m3
        min(4) = m4
        min(5) = m5

        hou(0) = h0
        hou(1) = h1
        hou(2) = h2
        hou(3) = h3
        hou(4) = h4
        hou(5) = h5

        Do While (base ^ arraylensub) < 59
            arraylensub = CByte(arraylensub + 1)
        Loop

        arraylensub = CByte(arraylensub - 1)
    End Sub
    Private Sub resizer()

        For Each tmpControl In Me.Controls
            tmpControl.Left = (tmpControl.Left * Screen.PrimaryScreen.Bounds.Width / 640)
            tmpControl.Top = (tmpControl.Top * Screen.PrimaryScreen.Bounds.Height / 480)
            tmpControl.Width = tmpControl.Width * Screen.PrimaryScreen.Bounds.Width / 640
            tmpControl.Height = tmpControl.Height * Screen.PrimaryScreen.Bounds.Height / 480
        Next tmpControl

    End Sub
    Private Sub new_numeral_system_number_in_array(ByVal numb As Byte)

        i = arraylen

        Do While (numb >= 1)
            converted(i) = CByte(numb Mod base)
            numb = CByte(numb \ base)
            i = i - 1
        Loop

    End Sub

    Private Sub TicTac(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        s = Second(Now)

        'SecondDebug.Text = ""

        new_numeral_system_number_in_array(CByte(s))

        For i As Integer = 0 To arraylen
            sec(i + shift_second).BackgroundImage = data(converted(i))

            '   SecondDebug.Text = SecondDebug.Text + Str(converted(i))

        Next

        Array.Clear(converted, 0, converted.Length)



        If m <> Minute(Now) Then

            'MinuteDebug.Text = ""

            m = Minute(Now)
            new_numeral_system_number_in_array(CByte(m))

            For i As Integer = 0 To arraylen
                min(i + shift_minute).BackgroundImage = data(converted(i))

                '   MinuteDebug.Text = MinuteDebug.Text + Str(converted(i))

            Next

            Array.Clear(converted, 0, converted.Length)
        End If



        If h <> Hour(Now) Then

            'HourDebug.Text = ""

            h = Hour(Now)
            new_numeral_system_number_in_array(CByte(h))

            For i As Integer = 0 To arraylen
                hou(i + shift_hour).BackgroundImage = data(converted(i))
                'HourDebug.Text = HourDebug.Text + Str(converted(i))
            Next

            Array.Clear(converted, 0, converted.Length)
        End If

        If GetActiveWindow <> formclose Then
            Final.Enabled = True
        End If

    End Sub

    Private Sub Appearance(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Appear.Tick
        Me.Opacity = Me.Opacity + 0.015
        If Me.Opacity = 1 Then
            pause = pause + 1

            If allsounds = True Then

                Select Case base
                    Case 2
                        'For base 2 (6 digits)
                      
                        Select Case pause
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
                                shift_hour = 0
                                shift_minute = 0
                                shift_second = 0
                            Case 226
                                Clock.Enabled = True

                                Appear.Enabled = False
                        End Select
                        


                    Case 3
                        'For base 3 (4 digits)
                        Select Case pause
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
                                
                            Case 226
                                Clock.Enabled = True

                                Appear.Enabled = False
                        End Select



                    Case 4 To 7
                        ' For base 7 to 4 (3 digits)

                        Select Case pause
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
                                If centered = True Then
                                    m1.Visible = True
                                    m2.Visible = True
                                    m3.Visible = True
                                    m4.Visible = True
                                Else
                                    m1.Visible = True
                                    m2.Visible = True
                                    m3.Visible = True
                                    m4.Visible = True
                                End If
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
                            Case 226
                                Clock.Enabled = True

                                Appear.Enabled = False
                        End Select


                        

                    Case 8 To 10
                        'For base 10 to 8 (2 digits)

                        Select Case pause
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
                            Case 226
                                Clock.Enabled = True

                                Appear.Enabled = False
                        End Select

                End Select






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

                Appear.Enabled = False

            End If
        End If

        'SecondDebug.Visible = True
        'HourDebug.Visible = True
        'MinuteDebug.Visible = True
    End Sub

    Private Sub Final_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Final.Tick

        'TransparencyKey = Color.Black
        If allsounds = True Then


            If finalcount = 0 Then

                sound.Stream = My.Resources.ShutDown
                sound.Play()

            End If

            finalcount = finalcount + 1
            Me.Opacity = Me.Opacity - 0.02
            If finalcount = 50 Then End


        Else

            finalcount = finalcount + 1
            Me.Opacity = Me.Opacity - 0.02
            If finalcount = 40 Then End

        End If
    End Sub
    Private Sub exitflag(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.F1 Or e.KeyCode = Keys.F2) And ex = False Then
            Clock.Enabled = False
            Clock.Enabled = MsgBox("Nixie Clock" + Chr(13) + "Version: 1.24" + Chr(13) + Chr(13) + "Developer: Alexey Elin" + Chr(13) + "E-mail: alexey.elin@gmail.com" + Chr(13) + Chr(13) + "Numeral system base: " + Str(base) + Chr(13) + "Sounds: " + Str(allsounds), vbInformation, "About")
            ex = True
        Else
            Final.Enabled = True
        End If

    End Sub

    Private Sub exitflagmouse(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Final.Enabled = True
    End Sub

    Private Sub mousetrack(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If System.Windows.Forms.Cursor.Position.X > mouseposx + 10 Or System.Windows.Forms.Cursor.Position.Y > mouseposy + 10 Then
            Final.Enabled = True
        Else
            mouseposx = System.Windows.Forms.Cursor.Position.X
            mouseposy = System.Windows.Forms.Cursor.Position.Y
        End If
    End Sub

End Class
