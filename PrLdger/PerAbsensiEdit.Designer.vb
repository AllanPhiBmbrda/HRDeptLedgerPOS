<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerAbsensiEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerAbsensiEdit))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PAEBtn01 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PAECmb01 = New System.Windows.Forms.ComboBox()
        Me.PAEDP01 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PAETbx04 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PAETbx03 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PAETbx02 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PAETbx01 = New System.Windows.Forms.TextBox()
        Me.PAEGrid01 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PAEGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1132, 582)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(3, 22)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1126, 557)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.PAEBtn01)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.PAECmb01)
        Me.TabPage1.Controls.Add(Me.PAEDP01)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.PAETbx04)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PAETbx03)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.PAETbx02)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.PAETbx01)
        Me.TabPage1.Controls.Add(Me.PAEGrid01)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1118, 529)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Total Absensi"
        '
        'PAEBtn01
        '
        Me.PAEBtn01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAEBtn01.Location = New System.Drawing.Point(942, 110)
        Me.PAEBtn01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PAEBtn01.Name = "PAEBtn01"
        Me.PAEBtn01.Size = New System.Drawing.Size(173, 22)
        Me.PAEBtn01.TabIndex = 32
        Me.PAEBtn01.Text = "Save"
        Me.PAEBtn01.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(833, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Periode :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(610, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Periode Range :"
        '
        'PAECmb01
        '
        Me.PAECmb01.FormattingEnabled = True
        Me.PAECmb01.Items.AddRange(New Object() {"Periode I", "Periode II"})
        Me.PAECmb01.Location = New System.Drawing.Point(836, 25)
        Me.PAECmb01.Name = "PAECmb01"
        Me.PAECmb01.Size = New System.Drawing.Size(158, 23)
        Me.PAECmb01.TabIndex = 29
        Me.PAECmb01.Text = "Periode I"
        '
        'PAEDP01
        '
        Me.PAEDP01.CustomFormat = "MMM yyyy"
        Me.PAEDP01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAEDP01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PAEDP01.Location = New System.Drawing.Point(613, 25)
        Me.PAEDP01.Name = "PAEDP01"
        Me.PAEDP01.Size = New System.Drawing.Size(161, 22)
        Me.PAEDP01.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Search Nik/Nama"
        '
        'PAETbx04
        '
        Me.PAETbx04.Location = New System.Drawing.Point(115, 110)
        Me.PAETbx04.Name = "PAETbx04"
        Me.PAETbx04.Size = New System.Drawing.Size(443, 23)
        Me.PAETbx04.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Value"
        '
        'PAETbx03
        '
        Me.PAETbx03.Location = New System.Drawing.Point(387, 25)
        Me.PAETbx03.Name = "PAETbx03"
        Me.PAETbx03.Size = New System.Drawing.Size(171, 23)
        Me.PAETbx03.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nama"
        '
        'PAETbx02
        '
        Me.PAETbx02.Location = New System.Drawing.Point(6, 69)
        Me.PAETbx02.Name = "PAETbx02"
        Me.PAETbx02.Size = New System.Drawing.Size(352, 23)
        Me.PAETbx02.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nik /  No. Est"
        '
        'PAETbx01
        '
        Me.PAETbx01.Location = New System.Drawing.Point(6, 25)
        Me.PAETbx01.Name = "PAETbx01"
        Me.PAETbx01.Size = New System.Drawing.Size(352, 23)
        Me.PAETbx01.TabIndex = 1
        '
        'PAEGrid01
        '
        Me.PAEGrid01.AllowUserToAddRows = False
        Me.PAEGrid01.AllowUserToDeleteRows = False
        Me.PAEGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.PAEGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PAEGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PAEGrid01.Location = New System.Drawing.Point(3, 139)
        Me.PAEGrid01.Name = "PAEGrid01"
        Me.PAEGrid01.ReadOnly = True
        Me.PAEGrid01.Size = New System.Drawing.Size(1112, 387)
        Me.PAEGrid01.TabIndex = 0
        '
        'PerAbsensiEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 582)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerAbsensiEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Absensi Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PAEGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PAEGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PAETbx01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PAETbx02 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PAETbx03 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PAETbx04 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PAECmb01 As System.Windows.Forms.ComboBox
    Friend WithEvents PAEDP01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PAEBtn01 As System.Windows.Forms.Button
End Class
