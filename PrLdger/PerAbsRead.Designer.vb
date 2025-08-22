<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerAbsRead
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerAbsRead))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RABtn02 = New System.Windows.Forms.Button()
        Me.RABtn01 = New System.Windows.Forms.Button()
        Me.RAGrid01 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.RACmb01 = New System.Windows.Forms.ComboBox()
        Me.RADt01 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RAGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RABtn02)
        Me.GroupBox1.Controls.Add(Me.RABtn01)
        Me.GroupBox1.Controls.Add(Me.RAGrid01)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.RACmb01)
        Me.GroupBox1.Controls.Add(Me.RADt01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1192, 605)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'RABtn02
        '
        Me.RABtn02.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RABtn02.Location = New System.Drawing.Point(685, 15)
        Me.RABtn02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RABtn02.Name = "RABtn02"
        Me.RABtn02.Size = New System.Drawing.Size(173, 22)
        Me.RABtn02.TabIndex = 32
        Me.RABtn02.Text = "To Perincian Daftar Gaji"
        Me.RABtn02.UseVisualStyleBackColor = True
        '
        'RABtn01
        '
        Me.RABtn01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RABtn01.Location = New System.Drawing.Point(506, 15)
        Me.RABtn01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RABtn01.Name = "RABtn01"
        Me.RABtn01.Size = New System.Drawing.Size(173, 22)
        Me.RABtn01.TabIndex = 31
        Me.RABtn01.Text = "Generate"
        Me.RABtn01.UseVisualStyleBackColor = True
        '
        'RAGrid01
        '
        Me.RAGrid01.AllowUserToAddRows = False
        Me.RAGrid01.AllowUserToDeleteRows = False
        Me.RAGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.RAGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RAGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RAGrid01.Location = New System.Drawing.Point(3, 54)
        Me.RAGrid01.Name = "RAGrid01"
        Me.RAGrid01.ReadOnly = True
        Me.RAGrid01.Size = New System.Drawing.Size(1186, 548)
        Me.RAGrid01.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(277, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 18)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Periode :"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Firebrick
        Me.Label44.Location = New System.Drawing.Point(5, 15)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(99, 18)
        Me.Label44.TabIndex = 28
        Me.Label44.Text = "Periode Range :"
        '
        'RACmb01
        '
        Me.RACmb01.FormattingEnabled = True
        Me.RACmb01.Items.AddRange(New Object() {"Periode I", "Periode II"})
        Me.RACmb01.Location = New System.Drawing.Point(333, 15)
        Me.RACmb01.Name = "RACmb01"
        Me.RACmb01.Size = New System.Drawing.Size(158, 23)
        Me.RACmb01.TabIndex = 27
        Me.RACmb01.Text = "Periode I"
        '
        'RADt01
        '
        Me.RADt01.CustomFormat = "MMM yyyy"
        Me.RADt01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RADt01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RADt01.Location = New System.Drawing.Point(110, 15)
        Me.RADt01.Name = "RADt01"
        Me.RADt01.Size = New System.Drawing.Size(161, 22)
        Me.RADt01.TabIndex = 26
        '
        'PerAbsRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 605)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerAbsRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Read Absensi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.RAGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RACmb01 As System.Windows.Forms.ComboBox
    Friend WithEvents RADt01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RAGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents RABtn01 As System.Windows.Forms.Button
    Friend WithEvents RABtn02 As System.Windows.Forms.Button
End Class
