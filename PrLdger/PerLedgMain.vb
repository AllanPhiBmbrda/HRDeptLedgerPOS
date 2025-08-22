Public Class PerLedgMain

    Private Sub EmployeeDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeDataToolStripMenuItem.Click
        Try
            EmpReg.MdiParent = Me
            EmpReg.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ConnectionSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionSetupToolStripMenuItem.Click
        Try
            PerLedgConn.MdiParent = Me
            PerLedgConn.Show()
        Catch ex As Exception
        End Try
    End Sub
    Sub LoadInitialization()
        If (Not System.IO.Directory.Exists(Application.StartupPath + "\DefaultConnection")) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath + "\DefaultConnection")
        End If
    End Sub

    Private Sub PerLedgMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        PerLogin.LoginTbx01.Focus()
    End Sub
    Private Sub PerLedgMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LockMenuItem()
        LoadInitialization()
        CreateDeConMe()
        LoadDeConMe()
        LoadDB()
        PerLogin.Show()

    End Sub
    Sub LockMenuItem()
        TransactionToolStripMenuItem.Enabled = False
        ReportToolStripMenuItem.Enabled = False
        MasterToolStripMenuItem1.Enabled = False
        UtilityToolStripMenuItem.Enabled = False
    End Sub
    Private Sub PerLedgMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
    Private Sub ClearCacheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearCacheToolStripMenuItem.Click
        FlushMemory()
    End Sub
    Private Sub StandardSetupToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            PerLedgSU.MdiParent = Me
            PerLedgSU.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UploadEmpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadEmpToolStripMenuItem.Click
        Try
            PerUploadEmp.MdiParent = Me
            PerUploadEmp.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DateSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateSetupToolStripMenuItem.Click
        Try
            PerDateSU.MdiParent = Me
            PerDateSU.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UploadAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            PerEmpAbsUp.MdiParent = Me
            PerEmpAbsUp.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub EmployeeListLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeListLedgerToolStripMenuItem.Click
        Try
            PerEmpList.MdiParent = Me
            PerEmpList.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub InputAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            PerAbsInput.MdiParent = Me
            PerAbsInput.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub InputLemburToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            PerLembIn.MdiParent = Me
            PerLembIn.Show()
        Catch ex As Exception
        End Try
    End Sub
  
    Private Sub InputAbsensiToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles InputAbsensiToolStripMenuItem.Click
        Try
            PerAbsInput.MdiParent = Me
            PerAbsInput.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UploadAbsensiToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UploadAbsensiToolStripMenuItem.Click
        PerEmpAbsUp.MdiParent = Me
        PerEmpAbsUp.Show()
    End Sub
    Private Sub InputLemburToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles InputLemburToolStripMenuItem.Click
        Try
            PerLembIn.MdiParent = Me
            PerLembIn.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ReadAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadAbsensiToolStripMenuItem.Click
        Try
            PerAbsRead.MdiParent = Me
            PerAbsRead.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PerincianGajiLoaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerincianGajiLoaderToolStripMenuItem.Click
        Try
            PerGenPerGji.MdiParent = Me
            PerGenPerGji.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ReadLemburToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadLemburToolStripMenuItem.Click
        Try
            PerLemRead.MdiParent = Me
            PerLemRead.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LaporeanDaftarPerincianGajiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporeanDaftarPerincianGajiToolStripMenuItem.Click
        Try
            PerMainLaporan.MdiParent = Me
            PerMainLaporan.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub InputTunjLainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputTunjLainToolStripMenuItem.Click
        PerTunLaInp.MdiParent = Me
        PerTunLaInp.Show()
    End Sub

    Private Sub ReadTunjLainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadTunjLainToolStripMenuItem.Click
        PerTunLaRead.MdiParent = Me
        PerTunLaRead.Show()
    End Sub

    Private Sub LedgerTM01_Tick(sender As Object, e As EventArgs) Handles LedgerTM01.Tick
        ToolStripStatusLabel4.Text = Today.ToString("dd MMM yyyy") & " || " & TimeOfDay.ToString("hh:mm:ss tt", CustomtoUS)
    End Sub

    Private Sub LaporanDaftarPerincianGajiALLExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanDaftarPerincianGajiALLExcelToolStripMenuItem.Click
        PerDaftarGaji2.MdiParent = Me
        PerDaftarGaji2.Show()

    End Sub

    Private Sub LaporanDaftarPerincianEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanDaftarPerincianEditorToolStripMenuItem.Click
        'PerAllGajiView.MdiParent = Me
        'PerAllGajiView.Show()
    End Sub

    Private Sub RevLaporanDaftarPerincianGajiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevLaporanDaftarPerincianGajiToolStripMenuItem.Click
        PerDaftarGaji3.MdiParent = Me
        PerDaftarGaji3.Show()
    End Sub

    Private Sub ReadLemburProduksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadLemburProduksiToolStripMenuItem.Click
        PerLmbvPrdRev.MdiParent = Me
        PerLmbvPrdRev.Show()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        PerLogin.Show()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub AccountToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AccountToolStripMenuItem.Click
        Select Case ToolStripStatusLabel2.Text
            Case "GUEST"
            Case Else
                PerAccLedger.MdiParent = Me
                PerAccLedger.Show()
        End Select
    End Sub

    Private Sub EmployeeDataToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmployeeDataToolStripMenuItem1.Click
        PerEmpListRev.MdiParent = Me
        PerEmpListRev.Show()
    End Sub

    Private Sub HolidayControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolidayControlToolStripMenuItem.Click
        Try
            PerHolSU.MdiParent = Me
            PerHolSU.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PerBulanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerBulanToolStripMenuItem.Click
        PerLmbSummary.MdiParent = Me
        PerLmbSummary.Show()
    End Sub

    Private Sub VariableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VariableToolStripMenuItem.Click
        Try
            PerLedgSU.MdiParent = Me
            PerLedgSU.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BagianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BagianToolStripMenuItem.Click
        PerDeptSet.MdiParent = Me
        PerDeptSet.Show()
    End Sub

    Private Sub PerHariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerHariToolStripMenuItem.Click
        PerLemburHari.MdiParent = Me
        PerLemburHari.Show()
    End Sub

    Private Sub PerJamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerJamToolStripMenuItem.Click
        PerLemburJam.MdiParent = Me
        PerLemburJam.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutCode.MdiParent = Me
        AboutCode.Show()
    End Sub

    Private Sub EmployeeEditGajiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeEditGajiToolStripMenuItem.Click
        PerAllGajiView.MdiParent = Me
        PerAllGajiView.Show()
    End Sub

    Private Sub EmployeeEditAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeEditAbsensiToolStripMenuItem.Click
        PerAbsensiEdit.MdiParent = Me
        PerAbsensiEdit.Show()
    End Sub


End Class
