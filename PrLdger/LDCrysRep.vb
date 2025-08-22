Imports CrystalDecisions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class LDCrysRep
    Dim crpath As String

    Private Sub LDCrysRep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMyEmpRepsort()
        ' Me.ReportViewer1.RefreshReport()
    End Sub

    Sub LoadMyEmpRepsort()

        Dim cryrpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        crpath = Application.StartupPath + "\MKReport01.rpt"
        'cryrpt.DataDefinition.FormulaFields("GroupSortField").Text = "{Table.Bagian}"
        cryrpt.Load(crpath)
        cryrpt.SetDataSource(ds)
        NewCrpViewer01.ReportSource = cryrpt
        NewCrpViewer01.Refresh()

        'Dim cr = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        'cr.SetDataSource(ds)
        'NewCrpViewer01.ReportSource = cr


    End Sub

End Class