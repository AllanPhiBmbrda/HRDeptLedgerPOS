<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerHolSU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerHolSU))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.HSBtn02 = New System.Windows.Forms.Button()
        Me.HSGrid01 = New System.Windows.Forms.DataGridView()
        Me.HSBtn01 = New System.Windows.Forms.Button()
        Me.HSTbx01 = New System.Windows.Forms.TextBox()
        Me.HSDPik01 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.HSGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.HSBtn02)
        Me.GroupBox1.Controls.Add(Me.HSGrid01)
        Me.GroupBox1.Controls.Add(Me.HSBtn01)
        Me.GroupBox1.Controls.Add(Me.HSTbx01)
        Me.GroupBox1.Controls.Add(Me.HSDPik01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 408)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'HSBtn02
        '
        Me.HSBtn02.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HSBtn02.Location = New System.Drawing.Point(174, 375)
        Me.HSBtn02.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.HSBtn02.Name = "HSBtn02"
        Me.HSBtn02.Size = New System.Drawing.Size(75, 25)
        Me.HSBtn02.TabIndex = 32
        Me.HSBtn02.Text = "&Delete"
        Me.HSBtn02.UseVisualStyleBackColor = True
        '
        'HSGrid01
        '
        Me.HSGrid01.AllowUserToAddRows = False
        Me.HSGrid01.AllowUserToDeleteRows = False
        Me.HSGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.HSGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HSGrid01.Dock = System.Windows.Forms.DockStyle.Top
        Me.HSGrid01.Location = New System.Drawing.Point(3, 16)
        Me.HSGrid01.Name = "HSGrid01"
        Me.HSGrid01.ReadOnly = True
        Me.HSGrid01.Size = New System.Drawing.Size(324, 238)
        Me.HSGrid01.TabIndex = 31
        '
        'HSBtn01
        '
        Me.HSBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HSBtn01.Location = New System.Drawing.Point(255, 375)
        Me.HSBtn01.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.HSBtn01.Name = "HSBtn01"
        Me.HSBtn01.Size = New System.Drawing.Size(75, 25)
        Me.HSBtn01.TabIndex = 30
        Me.HSBtn01.Text = "&Save"
        Me.HSBtn01.UseVisualStyleBackColor = True
        '
        'HSTbx01
        '
        Me.HSTbx01.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HSTbx01.Location = New System.Drawing.Point(5, 289)
        Me.HSTbx01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.HSTbx01.Multiline = True
        Me.HSTbx01.Name = "HSTbx01"
        Me.HSTbx01.Size = New System.Drawing.Size(319, 77)
        Me.HSTbx01.TabIndex = 29
        '
        'HSDPik01
        '
        Me.HSDPik01.CustomFormat = "dd MMM yyyy"
        Me.HSDPik01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HSDPik01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HSDPik01.Location = New System.Drawing.Point(53, 260)
        Me.HSDPik01.Name = "HSDPik01"
        Me.HSDPik01.Size = New System.Drawing.Size(179, 22)
        Me.HSDPik01.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(6, 265)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Date :"
        '
        'PerHolSU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 408)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PerHolSU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Holiday Setup / Hari Besar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.HSGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents HSDPik01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HSTbx01 As System.Windows.Forms.TextBox
    Friend WithEvents HSBtn01 As System.Windows.Forms.Button
    Friend WithEvents HSGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents HSBtn02 As System.Windows.Forms.Button
End Class
