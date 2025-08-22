<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerDaftarGaji2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerDaftarGaji2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LDPExcelGrid = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LDPExcelDp06 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LDPExcelDp05 = New System.Windows.Forms.ComboBox()
        Me.LDPExcelDp04 = New System.Windows.Forms.ComboBox()
        Me.LDPExcelDp03 = New System.Windows.Forms.ComboBox()
        Me.DateLbl01 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.LDPExcelDp02 = New System.Windows.Forms.ComboBox()
        Me.LDPExcelDp01 = New System.Windows.Forms.DateTimePicker()
        Me.LDPExcelBtn1 = New System.Windows.Forms.Button()
        Me.LDPExcelBtn3 = New System.Windows.Forms.Button()
        Me.LDPExcelBtn2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.LDPExcelGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LDPExcelGrid)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1282, 597)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LDPExcelGrid
        '
        Me.LDPExcelGrid.AllowUserToAddRows = False
        Me.LDPExcelGrid.AllowUserToDeleteRows = False
        Me.LDPExcelGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.LDPExcelGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LDPExcelGrid.Dock = System.Windows.Forms.DockStyle.Right
        Me.LDPExcelGrid.Location = New System.Drawing.Point(726, 18)
        Me.LDPExcelGrid.Name = "LDPExcelGrid"
        Me.LDPExcelGrid.ReadOnly = True
        Me.LDPExcelGrid.Size = New System.Drawing.Size(553, 576)
        Me.LDPExcelGrid.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.LDPExcelDp06)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.LDPExcelDp05)
        Me.GroupBox2.Controls.Add(Me.LDPExcelDp04)
        Me.GroupBox2.Controls.Add(Me.LDPExcelDp03)
        Me.GroupBox2.Controls.Add(Me.DateLbl01)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.LDPExcelDp02)
        Me.GroupBox2.Controls.Add(Me.LDPExcelDp01)
        Me.GroupBox2.Controls.Add(Me.LDPExcelBtn1)
        Me.GroupBox2.Controls.Add(Me.LDPExcelBtn3)
        Me.GroupBox2.Controls.Add(Me.LDPExcelBtn2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(714, 582)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Firebrick
        Me.Label3.Location = New System.Drawing.Point(3, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Jab. [Jabatan]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(3, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 18)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Code Jab. [Kode Jabatan]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Firebrick
        Me.Label4.Location = New System.Drawing.Point(3, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 18)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Jab. [Jabatan]"
        '
        'LDPExcelDp06
        '
        Me.LDPExcelDp06.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDPExcelDp06.FormattingEnabled = True
        Me.LDPExcelDp06.Location = New System.Drawing.Point(6, 289)
        Me.LDPExcelDp06.Name = "LDPExcelDp06"
        Me.LDPExcelDp06.Size = New System.Drawing.Size(264, 23)
        Me.LDPExcelDp06.TabIndex = 47
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Firebrick
        Me.Label5.Location = New System.Drawing.Point(3, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 18)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Code Jab. [Kode Jabatan]"
        '
        'LDPExcelDp05
        '
        Me.LDPExcelDp05.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDPExcelDp05.FormattingEnabled = True
        Me.LDPExcelDp05.Location = New System.Drawing.Point(6, 237)
        Me.LDPExcelDp05.Name = "LDPExcelDp05"
        Me.LDPExcelDp05.Size = New System.Drawing.Size(111, 23)
        Me.LDPExcelDp05.TabIndex = 45
        '
        'LDPExcelDp04
        '
        Me.LDPExcelDp04.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDPExcelDp04.FormattingEnabled = True
        Me.LDPExcelDp04.Location = New System.Drawing.Point(6, 190)
        Me.LDPExcelDp04.Name = "LDPExcelDp04"
        Me.LDPExcelDp04.Size = New System.Drawing.Size(264, 23)
        Me.LDPExcelDp04.TabIndex = 43
        '
        'LDPExcelDp03
        '
        Me.LDPExcelDp03.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDPExcelDp03.FormattingEnabled = True
        Me.LDPExcelDp03.Location = New System.Drawing.Point(6, 143)
        Me.LDPExcelDp03.Name = "LDPExcelDp03"
        Me.LDPExcelDp03.Size = New System.Drawing.Size(114, 23)
        Me.LDPExcelDp03.TabIndex = 41
        '
        'DateLbl01
        '
        Me.DateLbl01.AutoSize = True
        Me.DateLbl01.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLbl01.ForeColor = System.Drawing.Color.DarkRed
        Me.DateLbl01.Location = New System.Drawing.Point(6, 443)
        Me.DateLbl01.Name = "DateLbl01"
        Me.DateLbl01.Size = New System.Drawing.Size(194, 13)
        Me.DateLbl01.TabIndex = 40
        Me.DateLbl01.Text = "Periode : dd/MM/yyyy s/d dd/MM/yyyy"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(6, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 18)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Periode :"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Firebrick
        Me.Label44.Location = New System.Drawing.Point(6, 12)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(99, 18)
        Me.Label44.TabIndex = 38
        Me.Label44.Text = "Periode Range :"
        '
        'LDPExcelDp02
        '
        Me.LDPExcelDp02.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDPExcelDp02.FormattingEnabled = True
        Me.LDPExcelDp02.Items.AddRange(New Object() {"Periode I", "Periode II"})
        Me.LDPExcelDp02.Location = New System.Drawing.Point(6, 80)
        Me.LDPExcelDp02.Name = "LDPExcelDp02"
        Me.LDPExcelDp02.Size = New System.Drawing.Size(158, 23)
        Me.LDPExcelDp02.TabIndex = 37
        Me.LDPExcelDp02.Text = "Periode I"
        '
        'LDPExcelDp01
        '
        Me.LDPExcelDp01.CustomFormat = "MMM yyyy"
        Me.LDPExcelDp01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDPExcelDp01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.LDPExcelDp01.Location = New System.Drawing.Point(6, 33)
        Me.LDPExcelDp01.Name = "LDPExcelDp01"
        Me.LDPExcelDp01.ShowUpDown = True
        Me.LDPExcelDp01.Size = New System.Drawing.Size(161, 23)
        Me.LDPExcelDp01.TabIndex = 36
        '
        'LDPExcelBtn1
        '
        Me.LDPExcelBtn1.Location = New System.Drawing.Point(9, 482)
        Me.LDPExcelBtn1.Name = "LDPExcelBtn1"
        Me.LDPExcelBtn1.Size = New System.Drawing.Size(155, 25)
        Me.LDPExcelBtn1.TabIndex = 2
        Me.LDPExcelBtn1.Text = "Generate"
        Me.LDPExcelBtn1.UseVisualStyleBackColor = True
        '
        'LDPExcelBtn3
        '
        Me.LDPExcelBtn3.Location = New System.Drawing.Point(9, 544)
        Me.LDPExcelBtn3.Name = "LDPExcelBtn3"
        Me.LDPExcelBtn3.Size = New System.Drawing.Size(155, 25)
        Me.LDPExcelBtn3.TabIndex = 1
        Me.LDPExcelBtn3.Text = "Excel"
        Me.LDPExcelBtn3.UseVisualStyleBackColor = True
        '
        'LDPExcelBtn2
        '
        Me.LDPExcelBtn2.Location = New System.Drawing.Point(9, 513)
        Me.LDPExcelBtn2.Name = "LDPExcelBtn2"
        Me.LDPExcelBtn2.Size = New System.Drawing.Size(155, 25)
        Me.LDPExcelBtn2.TabIndex = 0
        Me.LDPExcelBtn2.Text = "Crystal Report"
        Me.LDPExcelBtn2.UseVisualStyleBackColor = True
        '
        'PerDaftarGaji2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 597)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerDaftarGaji2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Daftar Perincian Gaji ALL Excel"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.LDPExcelGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LDPExcelBtn3 As System.Windows.Forms.Button
    Friend WithEvents LDPExcelBtn2 As System.Windows.Forms.Button
    Friend WithEvents LDPExcelBtn1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents LDPExcelDp02 As System.Windows.Forms.ComboBox
    Friend WithEvents LDPExcelDp01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LDPExcelGrid As System.Windows.Forms.DataGridView
    Friend WithEvents DateLbl01 As System.Windows.Forms.Label
    Friend WithEvents LDPExcelDp03 As System.Windows.Forms.ComboBox
    Friend WithEvents LDPExcelDp04 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LDPExcelDp06 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LDPExcelDp05 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
