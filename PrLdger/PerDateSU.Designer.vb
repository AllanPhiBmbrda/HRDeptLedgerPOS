<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerDateSU
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTBtn01 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DSDT01 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DSCmb01 = New System.Windows.Forms.ComboBox()
        Me.DSDT03 = New System.Windows.Forms.DateTimePicker()
        Me.DSDT02 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.DTBtn01)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DSDT01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DSCmb01)
        Me.GroupBox1.Controls.Add(Me.DSDT03)
        Me.GroupBox1.Controls.Add(Me.DSDT02)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 150)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DTBtn01
        '
        Me.DTBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTBtn01.Location = New System.Drawing.Point(249, 119)
        Me.DTBtn01.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DTBtn01.Name = "DTBtn01"
        Me.DTBtn01.Size = New System.Drawing.Size(129, 25)
        Me.DTBtn01.TabIndex = 29
        Me.DTBtn01.Text = "&Save"
        Me.DTBtn01.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(180, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "s/d :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(10, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "TGL :"
        '
        'DSDT01
        '
        Me.DSDT01.CustomFormat = "MMM yyyy"
        Me.DSDT01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DSDT01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DSDT01.Location = New System.Drawing.Point(130, 43)
        Me.DSDT01.Name = "DSDT01"
        Me.DSDT01.Size = New System.Drawing.Size(179, 22)
        Me.DSDT01.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Periode Range :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label8.Location = New System.Drawing.Point(10, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Periode :"
        '
        'DSCmb01
        '
        Me.DSCmb01.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DSCmb01.FormattingEnabled = True
        Me.DSCmb01.Items.AddRange(New Object() {"Periode I", "Periode II"})
        Me.DSCmb01.Location = New System.Drawing.Point(130, 15)
        Me.DSCmb01.Name = "DSCmb01"
        Me.DSCmb01.Size = New System.Drawing.Size(179, 25)
        Me.DSCmb01.TabIndex = 23
        '
        'DSDT03
        '
        Me.DSDT03.CustomFormat = "dd MMM yyyy"
        Me.DSDT03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DSDT03.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DSDT03.Location = New System.Drawing.Point(217, 89)
        Me.DSDT03.Name = "DSDT03"
        Me.DSDT03.Size = New System.Drawing.Size(161, 22)
        Me.DSDT03.TabIndex = 17
        '
        'DSDT02
        '
        Me.DSDT02.CustomFormat = "dd MMM yyyy"
        Me.DSDT02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DSDT02.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DSDT02.Location = New System.Drawing.Point(13, 89)
        Me.DSDT02.Name = "DSDT02"
        Me.DSDT02.Size = New System.Drawing.Size(161, 22)
        Me.DSDT02.TabIndex = 16
        '
        'PerDateSU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 150)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PerDateSU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date Set-up"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DSCmb01 As System.Windows.Forms.ComboBox
    Friend WithEvents DSDT03 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DSDT01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DSDT02 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTBtn01 As System.Windows.Forms.Button
End Class
