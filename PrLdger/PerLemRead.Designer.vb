<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerLemRead
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerLemRead))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PLemBtn03 = New System.Windows.Forms.Button()
        Me.PLemBtn02 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PLemCmb01 = New System.Windows.Forms.ComboBox()
        Me.PLemDP01 = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.PLemBtn01 = New System.Windows.Forms.Button()
        Me.PLemTbx01 = New System.Windows.Forms.TextBox()
        Me.PLemGrid01 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PLemGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PLemBtn03)
        Me.GroupBox1.Controls.Add(Me.PLemBtn02)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PLemCmb01)
        Me.GroupBox1.Controls.Add(Me.PLemDP01)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.PLemBtn01)
        Me.GroupBox1.Controls.Add(Me.PLemTbx01)
        Me.GroupBox1.Controls.Add(Me.PLemGrid01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1146, 580)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'PLemBtn03
        '
        Me.PLemBtn03.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLemBtn03.Location = New System.Drawing.Point(1034, 15)
        Me.PLemBtn03.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PLemBtn03.Name = "PLemBtn03"
        Me.PLemBtn03.Size = New System.Drawing.Size(106, 22)
        Me.PLemBtn03.TabIndex = 34
        Me.PLemBtn03.Text = "Excel"
        Me.PLemBtn03.UseVisualStyleBackColor = True
        '
        'PLemBtn02
        '
        Me.PLemBtn02.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLemBtn02.Location = New System.Drawing.Point(856, 15)
        Me.PLemBtn02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PLemBtn02.Name = "PLemBtn02"
        Me.PLemBtn02.Size = New System.Drawing.Size(172, 22)
        Me.PLemBtn02.TabIndex = 27
        Me.PLemBtn02.Text = "To Perincian Daftar Gaji"
        Me.PLemBtn02.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(583, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 18)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Periode :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(359, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 18)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Periode Range :"
        '
        'PLemCmb01
        '
        Me.PLemCmb01.FormattingEnabled = True
        Me.PLemCmb01.Items.AddRange(New Object() {"Periode I", "Periode II"})
        Me.PLemCmb01.Location = New System.Drawing.Point(648, 15)
        Me.PLemCmb01.Name = "PLemCmb01"
        Me.PLemCmb01.Size = New System.Drawing.Size(103, 23)
        Me.PLemCmb01.TabIndex = 31
        Me.PLemCmb01.Text = "Periode I"
        '
        'PLemDP01
        '
        Me.PLemDP01.CustomFormat = "MMM yyyy"
        Me.PLemDP01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLemDP01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PLemDP01.Location = New System.Drawing.Point(464, 15)
        Me.PLemDP01.Name = "PLemDP01"
        Me.PLemDP01.Size = New System.Drawing.Size(112, 22)
        Me.PLemDP01.TabIndex = 30
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Firebrick
        Me.Label44.Location = New System.Drawing.Point(11, 17)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(83, 18)
        Me.Label44.TabIndex = 27
        Me.Label44.Text = "Nik / Nama :"
        '
        'PLemBtn01
        '
        Me.PLemBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLemBtn01.Location = New System.Drawing.Point(757, 16)
        Me.PLemBtn01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PLemBtn01.Name = "PLemBtn01"
        Me.PLemBtn01.Size = New System.Drawing.Size(93, 22)
        Me.PLemBtn01.TabIndex = 26
        Me.PLemBtn01.Text = "Search"
        Me.PLemBtn01.UseVisualStyleBackColor = True
        '
        'PLemTbx01
        '
        Me.PLemTbx01.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLemTbx01.Location = New System.Drawing.Point(100, 13)
        Me.PLemTbx01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PLemTbx01.Name = "PLemTbx01"
        Me.PLemTbx01.Size = New System.Drawing.Size(250, 25)
        Me.PLemTbx01.TabIndex = 25
        '
        'PLemGrid01
        '
        Me.PLemGrid01.AllowUserToAddRows = False
        Me.PLemGrid01.AllowUserToDeleteRows = False
        Me.PLemGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.PLemGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PLemGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PLemGrid01.Location = New System.Drawing.Point(3, 45)
        Me.PLemGrid01.Name = "PLemGrid01"
        Me.PLemGrid01.ReadOnly = True
        Me.PLemGrid01.Size = New System.Drawing.Size(1140, 532)
        Me.PLemGrid01.TabIndex = 24
        '
        'PerLemRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1146, 580)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerLemRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Read Lembur"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PLemGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents PLemBtn01 As System.Windows.Forms.Button
    Friend WithEvents PLemTbx01 As System.Windows.Forms.TextBox
    Friend WithEvents PLemGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PLemCmb01 As System.Windows.Forms.ComboBox
    Friend WithEvents PLemDP01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents PLemBtn02 As System.Windows.Forms.Button
    Friend WithEvents PLemBtn03 As System.Windows.Forms.Button
End Class
