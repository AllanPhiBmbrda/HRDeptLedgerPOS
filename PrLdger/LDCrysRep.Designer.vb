<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LDCrysRep
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LDCrysRep))
        Me.NewCrpViewer01 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'NewCrpViewer01
        '
        Me.NewCrpViewer01.ActiveViewIndex = -1
        Me.NewCrpViewer01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NewCrpViewer01.Cursor = System.Windows.Forms.Cursors.Default
        Me.NewCrpViewer01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NewCrpViewer01.Location = New System.Drawing.Point(0, 0)
        Me.NewCrpViewer01.Name = "NewCrpViewer01"
        Me.NewCrpViewer01.Size = New System.Drawing.Size(1021, 508)
        Me.NewCrpViewer01.TabIndex = 0
        Me.NewCrpViewer01.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'LDCrysRep
        '
        Me.ClientSize = New System.Drawing.Size(1021, 508)
        Me.Controls.Add(Me.NewCrpViewer01)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LDCrysRep"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewCrpViewer01 As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class
