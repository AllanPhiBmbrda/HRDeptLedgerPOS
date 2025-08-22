Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel

Public Class PerMainLaporan
    Private Sub PerMainLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        LoadJabMode()
    End Sub

    Sub LoadJabMode()
        PMLCmb02.Items.Clear()
        SQL = Nothing
        SQL = SQL & "Select * From p_jablist "
        SQL = SQL & "Order by p_jabname asc "
        OpenTbl(PCConn, PCTb5, SQL)
        If PCTb5.RecordCount > 0 Then
            PCTb5.MoveFirst()
            Do While Not PCTb5.EOF
                PMLCmb02.Invoke(DirectCast(Sub() PMLCmb02.Items.Add(PCTb5("p_jabname").Value.ToString), MethodInvoker))
                PCTb5.MoveNext()
            Loop
        End If
    End Sub
    Sub GridHeaderMode()

        With PMLGrid01
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "No")
            .Columns.Add("col1", "No. Est")
            .Columns.Add("col2", "Nama")
            .Columns.Add("col3", "Gaji 1/2b ")
            .Columns.Add("col4", "Absen")
            .Columns.Add("col5", "Pot. ATM")
            .Columns.Add("col6", "Tj. Lain ")
            .Columns.Add("col7", "L. Prd Jam")
            .Columns.Add("col8", "L. Prd Nilai")
            .Columns.Add("col9", "Total Gaji")
            .Columns.Add("col10", "Jam Lmb")
            .Columns.Add("col11", "Ttl Lembur")
            .Columns.Add("col12", "Tj. MsKerja")
            .Columns.Add("col13", "Tj. Kerajinan")
            .Columns.Add("col14", "Tj. Jabatan")
            .Columns.Add("col15", " ")
            .Columns.Add("col16", "Ketidak Hadiran")
            .Columns.Add("col17", "BPJS  T. Kerja")
            .Columns.Add("col18", "BPJS  Kesihatan")
            .Columns.Add("col19", "GAJI NETTO")
      
            For b = 1 To .Columns.Count - 1
                .Columns(b).Width = 200
            Next

        End With

        End Sub
    Private Sub PMLBtn01_Click(sender As Object, e As EventArgs) Handles PMLBtn01.Click
        GridHeaderMode()
        LockButton()

        Try
            ' LoadTransTot()
            OnClickTheWorker2()
        Catch ex As Exception
        End Try
    End Sub
    Sub LockButton()
        Select Case True
            Case PMLBtn01.Enabled
                PMLBtn01.Enabled = False
                PMLBtn02.Enabled = False
                PMLBtn03.Enabled = False
                PMLBtn04.Enabled = False
                LoadPic01.Visible = True

            Case Else
                PMLBtn01.Enabled = True
                PMLBtn02.Enabled = True
                PMLBtn03.Enabled = True
                PMLBtn04.Enabled = True
                LoadPic01.Visible = False
        End Select
    End Sub
    Private Sub PMLCmb02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PMLCmb02.KeyPress
        e.Handled = True
    End Sub
    Private Sub PMLCmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PMLCmb01.KeyPress
        e.Handled = True
    End Sub
    Sub LoadJabatanMode()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                PMLCmb02.Items.Add(PLTb1("pgj_jabname").Value)
                PLTb1.MoveNext()
            Loop
        End If
    End Sub
    Dim GetDTransTot(30) As String
    Sub LoadTransTot()
        Dim Cnt As Int32 = 0

        SQL = Nothing
        SQL = SQL & "Select * From pgj_trans_tot "
        SQL = SQL & "Where pgj_prrng = ('" & PMLDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        SQL = SQL & "and pgj_priode = ('" & PMLCmb01.Text & "') "
        SQL = SQL & "and pgj_jaba = ('" & PMLCmb02.Text & "') "
        SQL = SQL & "Order by pgj_ttest "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF

                GetDTransTot(0) = IIf(IsDBNull(PLTb2("pgj_ttest").Value), "", PLTb2("pgj_ttest").Value)
                GetDTransTot(1) = IIf(IsDBNull(PLTb2("pgj_ttname").Value), "", PLTb2("pgj_ttname").Value)
                GetDTransTot(2) = IIf(IsDBNull(PLTb2("pgj_gjpok").Value), "", PLTb2("pgj_gjpok").Value)
                GetDTransTot(3) = IIf(IsDBNull(PLTb2("pgj_absen").Value), "", PLTb2("pgj_absen").Value)
                GetDTransTot(4) = IIf(IsDBNull(PLTb2("pgj_potatm").Value), "", PLTb2("pgj_potatm").Value)
                GetDTransTot(5) = IIf(IsDBNull(PLTb2("pgj_tunlain").Value), "", PLTb2("pgj_tunlain").Value)
                GetDTransTot(6) = IIf(IsDBNull(PLTb2("pgj_lpjam").Value), "", PLTb2("pgj_lpjam").Value)
                GetDTransTot(7) = IIf(IsDBNull(PLTb2("pgj_lpnilai").Value), "", PLTb2("pgj_lpnilai").Value)
                'GetDTransTot(8) = IIf(IsDBNull(PLTb2("pgj_totgj").Value), "", PLTb2("pgj_totgj").Value)
                GetDTransTot(9) = IIf(IsDBNull(PLTb2("pgj_jamlmb").Value), "", PLTb2("pgj_jamlmb").Value)
                GetDTransTot(10) = IIf(IsDBNull(PLTb2("pgj_ttllemb").Value), "", PLTb2("pgj_ttllemb").Value)
                GetDTransTot(11) = IIf(IsDBNull(PLTb2("pgj_tunmskerj").Value), "", PLTb2("pgj_tunmskerj").Value)
                GetDTransTot(12) = IIf(IsDBNull(PLTb2("pgj_tjkera").Value), "", PLTb2("pgj_tjkera").Value)
                GetDTransTot(13) = IIf(IsDBNull(PLTb2("pgj_tjjab").Value), "", PLTb2("pgj_tjjab").Value)
                GetDTransTot(14) = IIf(IsDBNull(PLTb2("pgj_kethad").Value), "", PLTb2("pgj_kethad").Value)
                GetDTransTot(15) = IIf(IsDBNull(PLTb2("pgj_bpjstkerj").Value), "", PLTb2("pgj_bpjstkerj").Value)
                GetDTransTot(16) = IIf(IsDBNull(PLTb2("pgj_bpjskese").Value), "", PLTb2("pgj_bpjskese").Value)
                'GetDTransTot(17) = IIf(IsDBNull(PLTb2("pgj_gjinetto").Value), "", PLTb2("pgj_gjinetto").Value)

                Cnt += 1
                PMLGrid01.Invoke(DirectCast(Sub() PMLGrid01.Rows.Add(Cnt, GetDTransTot(0), _
                                                             GetDTransTot(1), _
                                                             Val(GetDTransTot(2)).ToString("N0", CustomtoUS), _
                                                             GetDTransTot(3), _
                                                             GetDTransTot(4), _
                                                             GetDTransTot(5), _
                                                             GetDTransTot(6), _
                                                             GetDTransTot(7), _
                                                             "", _
                                                             GetDTransTot(9), _
                                                             GetDTransTot(10), _
                                                             GetDTransTot(11), _
                                                             GetDTransTot(12), _
                                                             GetDTransTot(13), _
                                                             "", _
                                                             IIf(GetDTransTot(14) = Nothing, Nothing, Val(GetDTransTot(14)).ToString("N0", CustomtoUS)), _
                                                             GetDTransTot(15), _
                                                             GetDTransTot(16), _
                                                            ""), MethodInvoker))

                Dim GetTotal As Int32 = (Val(GetDTransTot(2).Replace(",", Nothing)) + Val(GetDTransTot(7).Replace(",", Nothing)) + Val(GetDTransTot(5).Replace(",", Nothing))) - Val(GetDTransTot(4).Replace(",", Nothing))
                Dim GetTotal2 As Int32 = (GetTotal + Val(GetDTransTot(10).Replace(",", Nothing)) + Val(GetDTransTot(11).Replace(",", Nothing)) + Val(GetDTransTot(12).Replace(",", Nothing)) + Val(GetDTransTot(13).Replace(",", Nothing))) - (Val(GetDTransTot(14).Replace(",", Nothing)) + Val(GetDTransTot(15).Replace(",", Nothing)) + Val(GetDTransTot(16).Replace(",", Nothing)))

                GetTotal2 = CustomRound(GetTotal2)

                PMLGrid01.Invoke(DirectCast(Sub() PMLGrid01(9, (Cnt - 1)).Value = GetTotal.ToString("N0", CustomtoUS), MethodInvoker))
                PMLGrid01.Invoke(DirectCast(Sub() PMLGrid01(19, (Cnt - 1)).Value = GetTotal2.ToString("N0", CustomtoUS), MethodInvoker))

                For g = 0 To 17
                    GetDTransTot(g) = Nothing
                Next
                PLTb2.MoveNext()
            Loop
        End If
    End Sub
    Dim SuperNik(10000) As String
    Sub AllocateNik()
        Select Case PMLGrid01.Rows.Count
            Case Is >= 1
                For SN = 0 To PMLGrid01.Rows.Count - 1
                    SuperNik(SN) = PMLGrid01(1, SN).Value
                Next
                '   AllocateAbsen()
        End Select
    End Sub
    Private Sub PMLBtn02_Click(sender As Object, e As EventArgs) Handles PMLBtn02.Click
        '   SavetoMainReport()
        LockButton()
        OnClickTheWorker3()
    End Sub
    Sub SavetoMainReport()
        For i = 0 To PMLGrid01.Rows.Count - 1
            SQL = Nothing
            SQL = SQL & "Select * From pgj_trans_tot "
            SQL = SQL & "Where pgj_ttest = ('" & PMLGrid01(1, i).Value.ToString & "') "
            SQL = SQL & "and pgj_prrng = ('" & PMLDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
            SQL = SQL & "and pgj_priode = ('" & PMLCmb01.Text & "') "
            OpenTbl(PLConn, PLTb5, SQL)
            If PLTb5.RecordCount > 0 Then
                'For Continuation
                PLTb5("pgj_totgj").Value = PMLGrid01(9, i).Value.ToString.Replace(",", Nothing)
                PLTb5("pgj_gjinetto").Value = PMLGrid01(19, i).Value.ToString.Replace(",", Nothing)
                PLTb5.Update()
            End If
        Next
        MessageBox.Show("DONE")
    End Sub
#Region "BGW on MODE"
    Private BGWorkMode() As BackgroundWorker
    Private i = 0
    Sub OnClickTheWorker()
        i += 1
        ReDim BGWorkMode(i)
        BGWorkMode(i) = New BackgroundWorker
        BGWorkMode(i).WorkerReportsProgress = True
        BGWorkMode(i).WorkerSupportsCancellation = True
        AddHandler BGWorkMode(i).DoWork, AddressOf WorkerDoWork
        AddHandler BGWorkMode(i).ProgressChanged, AddressOf WorkerProgressChanged
        AddHandler BGWorkMode(i).RunWorkerCompleted, AddressOf WorkerCompleted
        BGWorkMode(i).RunWorkerAsync()
    End Sub
    Private Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        PMLProg01.Invoke(DirectCast(Sub() PMLProg01.Maximum = PLTb2.RecordCount, MethodInvoker))
        ExportExcel()
    End Sub
    Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub
    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LockButtonMode()
        PMLProg01.Visible = False
        If e.Error IsNot Nothing Then
            MessageBox.Show(e.Error, Me.Text)
        Else
            MessageBoxSuc("Done", Me.Text)
        End If
    End Sub

    Sub OnClickTheWorker2()

        i += 1
        ReDim BGWorkMode(i)
        BGWorkMode(i) = New BackgroundWorker
        BGWorkMode(i).WorkerReportsProgress = True
        BGWorkMode(i).WorkerSupportsCancellation = True
        AddHandler BGWorkMode(i).DoWork, AddressOf WorkerDoWork2
        AddHandler BGWorkMode(i).ProgressChanged, AddressOf WorkerProgressChanged2
        AddHandler BGWorkMode(i).RunWorkerCompleted, AddressOf WorkerCompleted2
        BGWorkMode(i).RunWorkerAsync()

    End Sub

    Private Sub WorkerDoWork2(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        LoadTransTot()
    End Sub

    Private Sub WorkerProgressChanged2(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub

    Private Sub WorkerCompleted2(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LockButton()
    End Sub

    Sub OnClickTheWorker3()

        i += 1
        ReDim BGWorkMode(i)
        BGWorkMode(i) = New BackgroundWorker
        BGWorkMode(i).WorkerReportsProgress = True
        BGWorkMode(i).WorkerSupportsCancellation = True
        AddHandler BGWorkMode(i).DoWork, AddressOf WorkerDoWork3
        AddHandler BGWorkMode(i).ProgressChanged, AddressOf WorkerProgressChanged3
        AddHandler BGWorkMode(i).RunWorkerCompleted, AddressOf WorkerCompleted3
        BGWorkMode(i).RunWorkerAsync()

    End Sub

    Private Sub WorkerDoWork3(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        SavetoMainReport()
    End Sub

    Private Sub WorkerProgressChanged3(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub

    Private Sub WorkerCompleted3(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LockButton()
    End Sub


#End Region

    Sub ExportExcel()
        Try
            Dim NewFile As New FileInfo(SaveName)
            If NewFile.Exists Then
                NewFile.Delete()
            End If

            Using ExcelModPkg = New ExcelPackage(NewFile)

                Dim ExcelNewWSH As ExcelWorksheet = ExcelModPkg.Workbook.Worksheets.Add(IIf(PMLCmb02.Text = Nothing, "ALL", PMLCmb02.Text))

                ExcelNewWSH.PrinterSettings.PaperSize = ePaperSize.Legal
                ExcelNewWSH.PrinterSettings.Orientation = eOrientation.Landscape

                With ExcelNewWSH.Cells("A1:T1")
                    .Merge = True
                    .Value = "PT. UNIVERSAL GLOVES"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 12
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Font.Name = "CALIBRI"
                End With

                With ExcelNewWSH.Cells("A2:T2")
                    .Merge = True
                    .Value = "JL. Pertahanan No. 17 Patumbak 20361 Deli Serdang  - Indonesia"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A3:T3")
                    .Merge = True
                    .Value = "LAPORAN DAFTAR PERINCOAN GAJI"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A4:T4")
                    .Merge = True
                    .Value = "Periode : " & PMLDp01.Text & " " & PMLCmb01.Text
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A6")
                    .Value = "No. "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("B6")
                    .Value = "NIK"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("C6")
                    .Value = "Nama"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("D6")
                    .Value = "GAJI 1/2 b"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("E6")
                    .Value = "Absen"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("F6")
                    .Value = "Pot ATM"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("G6")
                    .Value = "Tunj. Lain"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("H6")
                    .Value = "Lembur Prd : JAM"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("I6")
                    .Value = "Lembur Prd  : Nilai"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("J6")
                    .Value = "Total Gaji"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("K6")

                    .Value = "Jam Lmb"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("L6")

                    .Value = "Ttl Lembur"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("M6")

                    .Value = "Tunj. Masa Kerja"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("N6")

                    .Value = "Tunj. Kerajinan"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("O6")

                    .Value = "Tun. Jabatan"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("P6")

                    .Value = " "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("Q6")

                    .Value = "Ketidak Hadiran"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("R6")

                    .Value = "BPJS T.Kerja"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("S6")

                    .Value = "BPRJS. Kesehatan"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("T6")

                    .Value = "GAJI NETTO"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                For KI = 0 To PMLGrid01.Rows.Count - 1

                    With ExcelNewWSH.Cells("A" & (KI + 7).ToString)

                        .Value = PMLGrid01(0, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("B" & (KI + 7).ToString)

                        .Value = PMLGrid01(1, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("C" & (KI + 7).ToString)

                        .Value = PMLGrid01(2, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("D" & (KI + 7).ToString)

                        .Value = PMLGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("E" & (KI + 7).ToString)

                        .Value = PMLGrid01(4, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("F" & (KI + 7).ToString)

                        .Value = PMLGrid01(5, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("G" & (KI + 7).ToString)

                        .Value = PMLGrid01(6, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("H" & (KI + 7).ToString)

                        .Value = PMLGrid01(7, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("I" & (KI + 7).ToString)

                        .Value = PMLGrid01(8, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("J" & (KI + 7).ToString)

                        .Value = PMLGrid01(9, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("K" & (KI + 7).ToString)

                        .Value = PMLGrid01(10, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("L" & (KI + 7).ToString)

                        .Value = PMLGrid01(11, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("M" & (KI + 7).ToString)

                        .Value = PMLGrid01(12, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("N" & (KI + 7).ToString)

                        .Value = PMLGrid01(13, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("O" & (KI + 7).ToString)

                        .Value = PMLGrid01(14, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("P" & (KI + 7).ToString)

                        .Value = PMLGrid01(15, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("Q" & (KI + 7).ToString)

                        .Value = PMLGrid01(16, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("R" & (KI + 7).ToString)

                        .Value = PMLGrid01(17, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("S" & (KI + 7).ToString)

                        .Value = PMLGrid01(18, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("T" & (KI + 7).ToString)

                        .Value = PMLGrid01(19, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    End With

                    PMLProg01.Value += 1

                Next

                For AF = 1 To 30
                    ExcelNewWSH.Column(AF).AutoFit()
                Next

                ExcelModPkg.Save()
                Dim LookMe As New ProcessStartInfo(SaveName)
                Process.Start(LookMe)

            End Using

        Catch ex As Exception

        End Try

        ' Create Work Sheet

    End Sub

    Dim SaveName As String
    Sub SaveFileLink()

        Dim SaveFileName As New SaveFileDialog
        SaveFileName.Filter = "Excel File (*.xlsx)|*.xlsx"
        SaveFileName.FilterIndex = 1
        If SaveFileName.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            SaveName = SaveFileName.FileName
        End If

    End Sub

    Private Sub PMLBtn03_Click(sender As Object, e As EventArgs) Handles PMLBtn03.Click
        Try
            Select Case PMLGrid01.Rows.Count
                Case Is >= 1
                    PMLProg01.Visible = True
                    ResetProbar()
                    SaveFileLink()
                    LockButtonMode()
                    OnClickTheWorker()

                    'ExportExcel()
            End Select
        Catch ex As Exception
        End Try
 
    End Sub

    Sub ResetProbar()
        PMLProg01.Maximum = Nothing
        PMLProg01.Value = 0

    End Sub

    Sub LockButtonMode()
        Select Case True
            Case PMLBtn01.Enabled
                PMLBtn01.Enabled = False
                PMLBtn02.Enabled = False
                PMLBtn03.Enabled = False
                PMLBtn04.Enabled = False
            Case Else
                PMLBtn01.Enabled = True
                PMLBtn02.Enabled = True
                PMLBtn03.Enabled = True
                PMLBtn04.Enabled = True
        End Select


    End Sub

    Private Sub PMLBtn04_Click(sender As Object, e As EventArgs) Handles PMLBtn04.Click
        Select Case PMLCmb02.Text
            Case Nothing
            Case Else
                LDCrysRep.MdiParent = PerLedgMain
                LDCrysRep.Show()
        End Select
    End Sub
End Class