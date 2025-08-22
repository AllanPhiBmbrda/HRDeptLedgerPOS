<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerAbsInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerAbsInput))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ABGrid01 = New System.Windows.Forms.DataGridView()
        Me.DTBtn01 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AbTbx02 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AbDp01 = New System.Windows.Forms.DateTimePicker()
        Me.AbTbx01 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ABGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ABGrid01)
        Me.GroupBox1.Controls.Add(Me.DTBtn01)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.AbTbx02)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.AbDp01)
        Me.GroupBox1.Controls.Add(Me.AbTbx01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(375, 215)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(6, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Idle"
        '
        'ABGrid01
        '
        Me.ABGrid01.AllowUserToAddRows = False
        Me.ABGrid01.AllowUserToDeleteRows = False
        Me.ABGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.ABGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ABGrid01.Location = New System.Drawing.Point(26, 73)
        Me.ABGrid01.Name = "ABGrid01"
        Me.ABGrid01.ReadOnly = True
        Me.ABGrid01.Size = New System.Drawing.Size(343, 106)
        Me.ABGrid01.TabIndex = 32
        Me.ABGrid01.Visible = False
        '
        'DTBtn01
        '
        Me.DTBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTBtn01.Location = New System.Drawing.Point(238, 182)
        Me.DTBtn01.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DTBtn01.Name = "DTBtn01"
        Me.DTBtn01.Size = New System.Drawing.Size(129, 25)
        Me.DTBtn01.TabIndex = 31
        Me.DTBtn01.Text = "&Save"
        Me.DTBtn01.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Firebrick
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 18)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Nama :"
        '
        'AbTbx02
        '
        Me.AbTbx02.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbTbx02.Location = New System.Drawing.Point(12, 90)
        Me.AbTbx02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AbTbx02.Name = "AbTbx02"
        Me.AbTbx02.Size = New System.Drawing.Size(355, 25)
        Me.AbTbx02.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(9, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 18)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "TGL :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 18)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Nik / Nama :"
        '
        'AbDp01
        '
        Me.AbDp01.CustomFormat = "dd MMM yyyy"
        Me.AbDp01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbDp01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.AbDp01.Location = New System.Drawing.Point(9, 143)
        Me.AbDp01.Name = "AbDp01"
        Me.AbDp01.Size = New System.Drawing.Size(161, 22)
        Me.AbDp01.TabIndex = 24
        '
        'AbTbx01
        '
        Me.AbTbx01.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbTbx01.Location = New System.Drawing.Point(12, 41)
        Me.AbTbx01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AbTbx01.Name = "AbTbx01"
        Me.AbTbx01.Size = New System.Drawing.Size(355, 25)
        Me.AbTbx01.TabIndex = 22
        '
        'PerAbsInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 215)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PerAbsInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Absensi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ABGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AbTbx01 As System.Windows.Forms.TextBox
    Friend WithEvents AbDp01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AbTbx02 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTBtn01 As System.Windows.Forms.Button
    Friend WithEvents ABGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
