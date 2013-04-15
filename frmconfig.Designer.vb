<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmconfig))
        Me.Defaults = New System.Windows.Forms.Button()
        Me.Setsettings = New System.Windows.Forms.Button()
        Me.l2 = New System.Windows.Forms.Label()
        Me.About = New System.Windows.Forms.Button()
        Me.AboutLabel = New System.Windows.Forms.Label()
        Me.g1 = New System.Windows.Forms.GroupBox()
        Me.FastExit = New System.Windows.Forms.CheckBox()
        Me.MouseSensAdj = New System.Windows.Forms.TrackBar()
        Me.l1 = New System.Windows.Forms.Label()
        Me.BaseBox = New System.Windows.Forms.NumericUpDown()
        Me.Centered = New System.Windows.Forms.CheckBox()
        Me.Sound = New System.Windows.Forms.CheckBox()
        Me.appear = New System.Windows.Forms.Timer(Me.components)
        Me.disappear = New System.Windows.Forms.Timer(Me.components)
        Me.AboutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AboutTimerEnd = New System.Windows.Forms.Timer(Me.components)
        Me.logo = New System.Windows.Forms.PictureBox()
        Me.LinkLabel = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.HourForm = New System.Windows.Forms.CheckBox()
        Me.g1.SuspendLayout()
        CType(Me.MouseSensAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BaseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Defaults
        '
        Me.Defaults.BackColor = System.Drawing.Color.Black
        Me.Defaults.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Defaults.ForeColor = System.Drawing.Color.White
        Me.Defaults.Location = New System.Drawing.Point(162, 269)
        Me.Defaults.Name = "Defaults"
        Me.Defaults.Size = New System.Drawing.Size(266, 32)
        Me.Defaults.TabIndex = 34
        Me.Defaults.Text = "Defaults"
        Me.Defaults.UseVisualStyleBackColor = False
        '
        'Setsettings
        '
        Me.Setsettings.BackColor = System.Drawing.Color.Black
        Me.Setsettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Setsettings.ForeColor = System.Drawing.Color.White
        Me.Setsettings.Location = New System.Drawing.Point(162, 307)
        Me.Setsettings.Name = "Setsettings"
        Me.Setsettings.Size = New System.Drawing.Size(266, 32)
        Me.Setsettings.TabIndex = 35
        Me.Setsettings.Text = "OK"
        Me.Setsettings.UseVisualStyleBackColor = False
        '
        'l2
        '
        Me.l2.AutoSize = True
        Me.l2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.l2.ForeColor = System.Drawing.Color.White
        Me.l2.Location = New System.Drawing.Point(6, 58)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(148, 24)
        Me.l2.TabIndex = 11
        Me.l2.Text = "Mouse sensivity:"
        '
        'About
        '
        Me.About.BackColor = System.Drawing.Color.Black
        Me.About.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.About.ForeColor = System.Drawing.Color.White
        Me.About.Location = New System.Drawing.Point(162, 231)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(266, 32)
        Me.About.TabIndex = 33
        Me.About.Text = "About"
        Me.About.UseVisualStyleBackColor = False
        '
        'AboutLabel
        '
        Me.AboutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AboutLabel.ForeColor = System.Drawing.Color.White
        Me.AboutLabel.Location = New System.Drawing.Point(470, 47)
        Me.AboutLabel.Name = "AboutLabel"
        Me.AboutLabel.Size = New System.Drawing.Size(230, 229)
        Me.AboutLabel.TabIndex = 32
        Me.AboutLabel.Text = "Nixie Clock Version: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Developer: Alexey Elin" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "E-mail: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Local Runs: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pr" & _
            "oject        "
        '
        'g1
        '
        Me.g1.Controls.Add(Me.HourForm)
        Me.g1.Controls.Add(Me.FastExit)
        Me.g1.Controls.Add(Me.l2)
        Me.g1.Controls.Add(Me.MouseSensAdj)
        Me.g1.Controls.Add(Me.l1)
        Me.g1.Controls.Add(Me.BaseBox)
        Me.g1.Controls.Add(Me.Centered)
        Me.g1.Controls.Add(Me.Sound)
        Me.g1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.g1.ForeColor = System.Drawing.Color.White
        Me.g1.Location = New System.Drawing.Point(162, 5)
        Me.g1.Name = "g1"
        Me.g1.Size = New System.Drawing.Size(266, 220)
        Me.g1.TabIndex = 36
        Me.g1.TabStop = False
        Me.g1.Text = "Options:"
        '
        'FastExit
        '
        Me.FastExit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FastExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FastExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FastExit.ForeColor = System.Drawing.Color.White
        Me.FastExit.Location = New System.Drawing.Point(6, 153)
        Me.FastExit.Name = "FastExit"
        Me.FastExit.Size = New System.Drawing.Size(243, 28)
        Me.FastExit.TabIndex = 12
        Me.FastExit.Text = "Fast exit"
        Me.FastExit.UseVisualStyleBackColor = True
        '
        'MouseSensAdj
        '
        Me.MouseSensAdj.AutoSize = False
        Me.MouseSensAdj.LargeChange = 2
        Me.MouseSensAdj.Location = New System.Drawing.Point(156, 58)
        Me.MouseSensAdj.Maximum = 7
        Me.MouseSensAdj.Name = "MouseSensAdj"
        Me.MouseSensAdj.Size = New System.Drawing.Size(104, 34)
        Me.MouseSensAdj.TabIndex = 1
        '
        'l1
        '
        Me.l1.AutoSize = True
        Me.l1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.l1.ForeColor = System.Drawing.Color.White
        Me.l1.Location = New System.Drawing.Point(5, 26)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(200, 24)
        Me.l1.TabIndex = 9
        Me.l1.Text = "Numeral System Base:"
        '
        'BaseBox
        '
        Me.BaseBox.BackColor = System.Drawing.Color.Black
        Me.BaseBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BaseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BaseBox.ForeColor = System.Drawing.Color.White
        Me.BaseBox.Location = New System.Drawing.Point(199, 27)
        Me.BaseBox.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.BaseBox.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.BaseBox.Name = "BaseBox"
        Me.BaseBox.ReadOnly = True
        Me.BaseBox.Size = New System.Drawing.Size(53, 25)
        Me.BaseBox.TabIndex = 0
        Me.BaseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BaseBox.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Centered
        '
        Me.Centered.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Centered.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Centered.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Centered.ForeColor = System.Drawing.Color.White
        Me.Centered.Location = New System.Drawing.Point(6, 119)
        Me.Centered.Name = "Centered"
        Me.Centered.Size = New System.Drawing.Size(243, 28)
        Me.Centered.TabIndex = 3
        Me.Centered.Text = "Center align"
        Me.Centered.UseVisualStyleBackColor = True
        '
        'Sound
        '
        Me.Sound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Sound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Sound.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Sound.ForeColor = System.Drawing.Color.White
        Me.Sound.Location = New System.Drawing.Point(6, 85)
        Me.Sound.Name = "Sound"
        Me.Sound.Size = New System.Drawing.Size(243, 28)
        Me.Sound.TabIndex = 2
        Me.Sound.Text = "Sound"
        Me.Sound.UseVisualStyleBackColor = True
        '
        'appear
        '
        Me.appear.Interval = 10
        '
        'disappear
        '
        Me.disappear.Interval = 10
        '
        'AboutTimer
        '
        Me.AboutTimer.Interval = 10
        '
        'AboutTimerEnd
        '
        Me.AboutTimerEnd.Interval = 10
        '
        'logo
        '
        Me.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.logo.Location = New System.Drawing.Point(2, -2)
        Me.logo.Name = "logo"
        Me.logo.Size = New System.Drawing.Size(159, 347)
        Me.logo.TabIndex = 37
        Me.logo.TabStop = False
        '
        'LinkLabel
        '
        Me.LinkLabel.AutoSize = True
        Me.LinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel.LinkColor = System.Drawing.Color.RoyalBlue
        Me.LinkLabel.Location = New System.Drawing.Point(538, 240)
        Me.LinkLabel.Name = "LinkLabel"
        Me.LinkLabel.Size = New System.Drawing.Size(38, 24)
        Me.LinkLabel.TabIndex = 39
        Me.LinkLabel.TabStop = True
        Me.LinkLabel.Text = "link"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.RoyalBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(470, 140)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(206, 24)
        Me.LinkLabel1.TabIndex = 38
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "alexey.elin@gmail.com"
        '
        'HourForm
        '
        Me.HourForm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HourForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.HourForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HourForm.ForeColor = System.Drawing.Color.White
        Me.HourForm.Location = New System.Drawing.Point(6, 186)
        Me.HourForm.Name = "HourForm"
        Me.HourForm.Size = New System.Drawing.Size(243, 28)
        Me.HourForm.TabIndex = 13
        Me.HourForm.Text = "Use 24-hour Format"
        Me.HourForm.UseVisualStyleBackColor = True
        '
        'frmconfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(722, 344)
        Me.Controls.Add(Me.LinkLabel)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.logo)
        Me.Controls.Add(Me.Defaults)
        Me.Controls.Add(Me.Setsettings)
        Me.Controls.Add(Me.About)
        Me.Controls.Add(Me.AboutLabel)
        Me.Controls.Add(Me.g1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmconfig"
        Me.Opacity = 0.0R
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Nixie Clock Settings"
        Me.TopMost = True
        Me.g1.ResumeLayout(False)
        Me.g1.PerformLayout()
        CType(Me.MouseSensAdj, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BaseBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Defaults As System.Windows.Forms.Button
    Friend WithEvents Setsettings As System.Windows.Forms.Button
    Friend WithEvents l2 As System.Windows.Forms.Label
    Friend WithEvents About As System.Windows.Forms.Button
    Friend WithEvents AboutLabel As System.Windows.Forms.Label
    Friend WithEvents g1 As System.Windows.Forms.GroupBox
    Friend WithEvents MouseSensAdj As System.Windows.Forms.TrackBar
    Friend WithEvents l1 As System.Windows.Forms.Label
    Friend WithEvents BaseBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents Centered As System.Windows.Forms.CheckBox
    Friend WithEvents Sound As System.Windows.Forms.CheckBox
    Friend WithEvents appear As System.Windows.Forms.Timer
    Friend WithEvents disappear As System.Windows.Forms.Timer
    Friend WithEvents AboutTimer As System.Windows.Forms.Timer
    Friend WithEvents AboutTimerEnd As System.Windows.Forms.Timer
    Friend WithEvents logo As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents FastExit As System.Windows.Forms.CheckBox
    Friend WithEvents HourForm As System.Windows.Forms.CheckBox
End Class
