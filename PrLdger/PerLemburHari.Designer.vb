<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerLemburHari
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerLemburHari))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PLHariDp01 = New System.Windows.Forms.DateTimePicker()
        Me.PLHariGrid01 = New System.Windows.Forms.DataGridView()
        Me.PLHariBtn02 = New System.Windows.Forms.Button()
        Me.PLHariBtn01 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PLHariGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PLHariDp01)
        Me.GroupBox1.Controls.Add(Me.PLHariGrid01)
        Me.GroupBox1.Controls.Add(Me.PLHariBtn02)
        Me.GroupBox1.Controls.Add(Me.PLHariBtn01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 588)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 18)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Date: "
        '
        'PLHariDp01
        '
        Me.PLHariDp01.CustomFormat = "dd MMM yyyy"
        Me.PLHariDp01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLHariDp01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PLHariDp01.Location = New System.Drawing.Point(62, 16)
        Me.PLHariDp01.Name = "PLHariDp01"
        Me.PLHariDp01.Size = New System.Drawing.Size(163, 22)
        Me.PLHariDp01.TabIndex = 31
        '
        'PLHariGrid01
        '
        Me.PLHariGrid01.AllowUserToAddRows = False
        Me.PLHariGrid01.AllowUserToDeleteRows = False
        Me.PLHariGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.PLHariGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PLHariGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PLHariGrid01.Location = New System.Drawing.Point(3, 49)
        Me.PLHariGrid01.Name = "PLHariGrid01"
        Me.PLHariGrid01.ReadOnly = True
        Me.PLHariGrid01.Size = New System.Drawing.Size(1072, 536)
        Me.PLHariGrid01.TabIndex = 30
        '
        'PLHariBtn02
        '
        Me.PLHariBtn02.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLHariBtn02.Location = New System.Drawing.Point(943, 18)
        Me.PLHariBtn02.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PLHariBtn02.Name = "PLHariBtn02"
        Me.PLHariBtn02.Size = New System.Drawing.Size(129, 25)
        Me.PLHariBtn02.TabIndex = 29
        Me.PLHariBtn02.Text = "Excel"
        Me.PLHariBtn02.UseVisualStyleBackColor = True
        '
        'PLHariBtn01
        '
        Me.PLHariBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLHariBtn01.Location = New System.Drawing.Point(808, 18)
        Me.PLHariBtn01.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PLHariBtn01.Name = "PLHariBtn01"
        Me.PLHariBtn01.Size = New System.Drawing.Size(129, 25)
        Me.PLHariBtn01.TabIndex = 28
        Me.PLHariBtn01.Text = "Search"
        Me.PLHariBtn01.UseVisualStyleBackColor = True
        '
        'PerLemburHari
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 588)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerLemburHari"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Harian Lembur"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PLHariGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PLHariBtn02 As System.Windows.Forms.Button
    Friend WithEvents PLHariBtn01 As System.Windows.Forms.Button
    Friend WithEvents PLHariGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents PLHariDp01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
