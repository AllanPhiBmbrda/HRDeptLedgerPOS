Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel

Public Class PerDaftarGaji2

    Private Sub PerDaftarGaji2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        'SampleNode()
        'LoadDepartmentMode2()
        'LDPExcelTV.ExpandAll()
        '  LoadRevDept()
        LoadRevJabatan()
    End Sub

    Dim ArrDept(20) As String

    'Sub LoadDepartmentMode()

    '    For y = 0 To 20
    '        ArrDept(y) = Nothing
    '    Next

    '    ' Dim AllNode As TreeNode = LDPExcelTV.Nodes.Add("ALL")
    '    Dim DeptNode As TreeNode
    '    Dim jabNode As TreeNode
    '    Dim ArCnt As Int32 = 0

    '    SQL = Nothing
    '    SQL = SQL & "Select * From p_deplist "
    '    OpenTbl(PCConn, PCTb5, SQL)
    '    If PCTb5.RecordCount > 0 Then
    '        PCTb5.MoveFirst()
    '        Do While Not PCTb5.EOF
    '            'DeptNode = AllNode.Nodes.Add(PCTb5("p_deptname").Value.ToString)

    '            DeptNode = LDPExcelTV.Nodes.Add(PCTb5("p_deptname").Value.ToString)
    '            ArrDept(ArCnt) = PCTb5("p_deptname").Value.ToString
    '            ArCnt += 1
    '            SQL = Nothing
    '            SQL = SQL & "Select * From p_jablist "
    '            SQL = SQL & "Where p_deplink = ('" & PCTb5("p_deptname").Value.ToString & "') "
    '            OpenTbl(PCConn, PCTb6, SQL)
    '            If PCTb6.RecordCount > 0 Then
    '                PCTb6.MoveFirst()
    '                Do While Not PCTb6.EOF
    '                    jabNode = DeptNode.Nodes.Add(PCTb6("p_jabname").Value.ToString)
    '                    PCTb6.MoveNext()
    '                Loop
    '            End If

    '            PCTb5.MoveNext()
    '        Loop
    '    End If

    'End Sub


    ' Origina Department Load
    'Sub LoadDepartmentMode2()

    '    For y = 0 To 20
    '        ArrDept(y) = Nothing
    '    Next

    '    ' Dim AllNode As TreeNode = LDPExcelTV.Nodes.Add("ALL")
    '    Dim DeptNode As TreeNode
    '    Dim jabNode As TreeNode
    '    Dim ArCnt As Int32 = 0

    '    SQL = Nothing
    '    SQL = SQL & "Select * From pgj_deptlist "
    '    OpenTbl(PLConn, PLTb9, SQL)
    '    If PLTb9.RecordCount > 0 Then
    '        PLTb9.MoveFirst()
    '        Do While Not PLTb9.EOF
    '            'DeptNode = AllNode.Nodes.Add(PCTb5("p_deptname").Value.ToString)

    '            DeptNode = LDPExcelTV.Nodes.Add(PLTb9("dep_depname").Value.ToString)
    '            ArrDept(ArCnt) = PLTb9("dep_depname").Value.ToString
    '            ArCnt += 1
    '            SQL = Nothing
    '            SQL = SQL & "Select * From pgj_jablist "
    '            SQL = SQL & "Where pgj_deplink = ('" & PLTb9("dep_depname").Value.ToString & "') "
    '            OpenTbl(PLConn, PLTb10, SQL)
    '            If PLTb10.RecordCount > 0 Then
    '                PLTb10.MoveFirst()
    '                Do While Not PLTb10.EOF
    '                    jabNode = DeptNode.Nodes.Add(PLTb10("pgj_jabname").Value.ToString)
    '                    PLTb10.MoveNext()
    '                Loop
    '            End If

    '            PLTb9.MoveNext()
    '        Loop
    '    End If

    'End Sub
    Private Sub LDPExcelTV_AfterCheck(sender As Object, e As TreeViewEventArgs)
        Dim t As TreeNode
        For Each t In e.Node.Nodes
            t.Checked = e.Node.Checked
        Next

        'Dim myNode As TreeNode = e.Node

        'TextBox1.Text &= myNode.Text & "<space> "

        '' GetChildNodes(myNode)

    End Sub

    Sub GetChildNodes(tnode As TreeNode)

        'For Each node As TreeNode In tnode.Nodes

        '    TextBox1.Text += node.Text & "<space> "
        '    If tnode.Nodes.Count > 0 Then GetChildNodes(node)

        'Next

    End Sub
    Sub GridHeaderMode()

        With LDPExcelGrid
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
            .Columns.Add("col20", "Bagian")
            .Columns.Add("col21", "Jabatan")

            For b = 1 To .Columns.Count - 1
                .Columns(b).Width = 200
            Next

        End With

    End Sub

    Dim SearchJab(1000) As String
    Dim SearchJabKode(1000) As String

    Sub LookForNode()

    End Sub

    Public Sub GetCheckedNodes(nodes As TreeNodeCollection)

        Dim getCntjab As Int32 = 0
        For Each aNode As System.Windows.Forms.TreeNode In nodes

            Select Case aNode.Checked
                Case True
                    SearchJab(getCntjab) = aNode.Text

                    Console.Write(getCntjab.ToString & " ")
                    getCntjab += 1
            End Select

            If aNode.Nodes.Count <> 0 Then
                GetCheckedNodes(aNode.Nodes)
            End If
        Next
    End Sub

    Sub LookQueryFromNodes()
        ' GetCheckedNodes(LDPExcelTV.Nodes)
    End Sub

#Region "BGW on Mode"
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
        MainSearchMode()
    End Sub
    Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub
    Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        MessageBox.Show("Done")
    End Sub
#End Region
    Sub MakeMeXMLExtra()
        With dtReq
            .Columns.Clear()
            .Rows.Clear()

            .Columns.Add("Periode", GetType(String))
            .Columns.Add("Dibuat Oleh", GetType(String))
            .Columns.Add("Diketahui Oleh", GetType(String))

            dtReq.Rows.Add(DateLbl01.Text, PurUser.PerRN, ManagerStat)

            Try
                dtReq.TableName = "ExtraRep"
                ds.Tables.Add(dtReq)
                'dsReq.WriteXmlSchema("ForSetupCRExtra.xml")
            Catch ex As Exception
            End Try

        End With
    End Sub
    Sub MakeMeXML()
        With dt
            .Columns.Clear()
            .Rows.Clear()

            .Columns.Add("ID", GetType(String))
            .Columns.Add("No. Est", GetType(String))
            .Columns.Add("Nama", GetType(String))
            .Columns.Add("Gaji 1/2b", GetType(Integer))
            .Columns.Add("Absen", GetType(Integer))
            .Columns.Add("Pot. ATM", GetType(Integer))
            .Columns.Add("Tj. Lain ", GetType(Integer))
            .Columns.Add("L. Prd Jam", GetType(Integer))
            .Columns.Add("L. Prd Nilai", GetType(Integer))
            .Columns.Add("Total Gaji", GetType(Integer))
            .Columns.Add("Jam Lmb", GetType(Integer))
            .Columns.Add("Ttl Lembur", GetType(Integer))
            .Columns.Add("Tj. MsKerja", GetType(Integer))
            .Columns.Add("Tj. Kerajinan", GetType(Integer))
            .Columns.Add("Tj. Jabatan", GetType(Integer))
            .Columns.Add("", GetType(Integer))
            .Columns.Add("Ketidak Hadiran", GetType(Integer))
            .Columns.Add("BPJS  T. Kerja", GetType(Integer))
            .Columns.Add("BPJS  Kesihatan", GetType(Integer))
            .Columns.Add("GAJI NETTO", GetType(Integer))
            .Columns.Add("Bagian", GetType(String))
            .Columns.Add("Jabatan", GetType(String))

        End With




        For Each dgv As DataGridViewRow In LDPExcelGrid.Rows

            'dt.Rows.Add(dgv.Cells(0).Value, dgv.Cells(1).Value, dgv.Cells(2).Value, Val(dgv.Cells(3).Value), dgv.Cells(4).Value, dgv.Cells(5).Value, dgv.Cells(6).Value, dgv.Cells(7).Value, dgv.Cells(8).Value, dgv.Cells(9).Value, dgv.Cells(10).Value, _
            '                    dgv.Cells(11).Value, dgv.Cells(12).Value, dgv.Cells(13).Value, dgv.Cells(14).Value, dgv.Cells(15).Value, dgv.Cells(16).Value, dgv.Cells(17).Value, dgv.Cells(18).Value, _
            '                    dgv.Cells(19).Value, dgv.Cells(20).Value, dgv.Cells(21).Value)

            dt.Rows.Add(dgv.Cells(0).Value, dgv.Cells(1).Value, dgv.Cells(2).Value, Val(dgv.Cells(3).Value), Val(dgv.Cells(4).Value), Val(dgv.Cells(5).Value), Val(dgv.Cells(6).Value), Val(dgv.Cells(7).Value), Val(dgv.Cells(8).Value), Val(dgv.Cells(9).Value), Val(dgv.Cells(10).Value), _
                                Val(dgv.Cells(11).Value), Val(dgv.Cells(12).Value), Val(dgv.Cells(13).Value), Val(dgv.Cells(14).Value), Val(dgv.Cells(15).Value), Val(dgv.Cells(16).Value), Val(dgv.Cells(17).Value), Val(dgv.Cells(18).Value), _
                                Val(dgv.Cells(19).Value), dgv.Cells(20).Value, dgv.Cells(21).Value)
        Next


        Try

            dt.TableName = "MainRep"
            ds.Tables.Add(dt)
            ds.WriteXmlSchema("ForSetupCR.xml")
        Catch ex As Exception

        End Try
    End Sub
    Dim ManagerStat As String
    Sub LookForManagerStat()
        ManagerStat = Nothing
        SQL = Nothing
        SQL = SQL & "Select * From pgj_perstan "
        SQL = SQL & "Where prj_aktif = ('" & "Yes" & "') "
        OpenTbl(PLConn, PLTb8, SQL)
        If PLTb8.RecordCount > 0 Then
            ManagerStat = IIf(IsDBNull(PLTb8("prj_head").Value), Nothing, PLTb8("prj_head").Value)
        End If
    End Sub

    'Private Sub LDPExcelBtn1_Click(sender As Object, e As EventArgs) Handles LDPExcelBtn1.Click
    '    Try

    '        For Ce = 0 To 1000
    '            SearchJab(Ce) = ""
    '        Next

    '        Dim tn As TreeNode = LDPExcelTV.SelectedNode

    '        GridHeaderMode()
    '        MainSearchMode()
    '        '  OnClickTheWorker()
    '        LookForPeriodeDate()
    '        LookForManagerStat()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try

    'End Sub
    Dim GetSt As Date
    Dim GetLt As Date

    Sub LookForPeriodeDate()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_periodesu "
        SQL = SQL & "Where psu_periode = ('" & LDPExcelDp02.Text & "') "
        SQL = SQL & "and psu_perioderng = ('" & LDPExcelDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            GetSt = IIf(IsDBNull(PLTb1("psu_awal").Value), Nothing, PLTb1("psu_awal").Value)
            GetLt = IIf(IsDBNull(PLTb1("psu_akhir").Value), Nothing, PLTb1("psu_akhir").Value)
            DateLbl01.Text = "Periode : " & GetSt.ToString("dd MMM yyyy") & " s/d " & GetLt.ToString("dd MMM yyyy")
        Else
            DateLbl01.Text = "Periode : dd/MM/yyyy s/d dd/MM/yyyy"
        End If
    End Sub

    Dim GetDTransTot(30) As String
    Sub MainSearchMode()
        Dim Cnt As Integer

        '  LookQueryFromNodes() Old from July 15 2017

        For cg = 0 To 1000

            ' Select Case SearchJab(cg)
            Select Case SearchJabKode(cg)
                Case Nothing
                    Exit For
                Case Else
                    'SQL = Nothing
                    'SQL = SQL & "Select * From pgj_trans_tot "
                    'SQL = SQL & "Where pgj_prrng = ('" & LDPExcelDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
                    'SQL = SQL & "and pgj_priode = ('" & LDPExcelDp02.Text & "') "
                    'LookQueryFromNodes()

                    SQL = Nothing
                    SQL = SQL & "Select * From pgj_trans_tot "
                    SQL = SQL & "Where pgj_jaba = ('" & SearchJab(cg) & "') "
                    SQL = SQL & "and pgj_prrng = ('" & LDPExcelDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
                    SQL = SQL & "and pgj_priode = ('" & LDPExcelDp02.Text & "') "

                    OpenTbl(PLConn, PLTb2, SQL)
                    If PLTb2.RecordCount > 0 Then
                        PLTb2.MoveFirst()
                        Do While Not PLTb2.EOF

                            GetDTransTot(0) = IIf(IsDBNull(PLTb2("pgj_ttest").Value), "", PLTb2("pgj_ttest").Value)
                            GetDTransTot(1) = IIf(IsDBNull(PLTb2("pgj_ttname").Value), "", PLTb2("pgj_ttname").Value)
                            GetDTransTot(2) = IIf(IsDBNull(PLTb2("pgj_gjpok").Value), "", PLTb2("pgj_gjpok").Value)
                            GetDTransTot(3) = IIf(IsDBNull(PLTb2("pgj_absen").Value), 0, PLTb2("pgj_absen").Value.ToString.Replace(",", ""))
                            GetDTransTot(4) = IIf(IsDBNull(PLTb2("pgj_potatm").Value), 0, PLTb2("pgj_potatm").Value.ToString.Replace(",", ""))
                            GetDTransTot(5) = IIf(IsDBNull(PLTb2("pgj_tunlain").Value), 0, PLTb2("pgj_tunlain").Value.ToString.Replace(",", ""))
                            GetDTransTot(6) = IIf(IsDBNull(PLTb2("pgj_lpjam").Value), 0, PLTb2("pgj_lpjam").Value.ToString.Replace(",", ""))
                            GetDTransTot(7) = IIf(IsDBNull(PLTb2("pgj_lpnilai").Value), 0, PLTb2("pgj_lpnilai").Value.ToString.Replace(",", ""))
                            'GetDTransTot(8) = IIf(IsDBNull(PLTb2("pgj_totgj").Value), "", PLTb2("pgj_totgj").Value)
                            GetDTransTot(9) = IIf(IsDBNull(PLTb2("pgj_jamlmb").Value), 0, PLTb2("pgj_jamlmb").Value.ToString.Replace(",", ""))
                            GetDTransTot(10) = IIf(IsDBNull(PLTb2("pgj_ttllemb").Value), 0, PLTb2("pgj_ttllemb").Value.ToString.Replace(",", ""))
                            GetDTransTot(11) = IIf(IsDBNull(PLTb2("pgj_tunmskerj").Value), 0, PLTb2("pgj_tunmskerj").Value.ToString.Replace(",", ""))
                            GetDTransTot(12) = IIf(IsDBNull(PLTb2("pgj_tjkera").Value), 0, PLTb2("pgj_tjkera").Value.ToString.Replace(",", ""))
                            GetDTransTot(13) = IIf(IsDBNull(PLTb2("pgj_tjjab").Value), 0, PLTb2("pgj_tjjab").Value.ToString.Replace(",", ""))
                            GetDTransTot(14) = IIf(IsDBNull(PLTb2("pgj_kethad").Value), 0, PLTb2("pgj_kethad").Value.ToString.Replace(",", ""))
                            GetDTransTot(15) = IIf(IsDBNull(PLTb2("pgj_bpjstkerj").Value), 0, PLTb2("pgj_bpjstkerj").Value.ToString.Replace(",", ""))
                            GetDTransTot(16) = IIf(IsDBNull(PLTb2("pgj_bpjskese").Value), 0, PLTb2("pgj_bpjskese").Value.ToString.Replace(",", ""))
                            'GetDTransTot(17) = IIf(IsDBNull(PLTb2("pgj_gjinetto").Value), "", PLTb2("pgj_gjinetto").Value)
                            GetDTransTot(17) = IIf(IsDBNull(PLTb2("pgj_bagian").Value), 0, PLTb2("pgj_bagian").Value.ToString.Replace(",", ""))
                            GetDTransTot(18) = IIf(IsDBNull(PLTb2("pgj_jaba").Value), 0, PLTb2("pgj_jaba").Value.ToString.Replace(",", ""))

                            Cnt += 1

                            LDPExcelGrid.Invoke(DirectCast(Sub() LDPExcelGrid.Rows.Add(Cnt.ToString, GetDTransTot(0), _
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
                                                                        "", _
                                                                          GetDTransTot(17), _
                                                                        GetDTransTot(18)), MethodInvoker))

                            Dim GetTotal As Int32 = (Val(GetDTransTot(2).Replace(",", Nothing)) + Val(GetDTransTot(7).Replace(",", Nothing)) + Val(GetDTransTot(5).Replace(",", Nothing))) - Val(GetDTransTot(4).Replace(",", Nothing))
                            Dim GetTotal2 As Int32 = (GetTotal + Val(GetDTransTot(10).Replace(",", Nothing)) + Val(GetDTransTot(11).Replace(",", Nothing)) + Val(GetDTransTot(12).Replace(",", Nothing)) + Val(GetDTransTot(13).Replace(",", Nothing))) - (Val(GetDTransTot(14).Replace(",", Nothing)) + Val(GetDTransTot(15).Replace(",", Nothing)) + Val(GetDTransTot(16).Replace(",", Nothing)))

                            GetTotal2 = CustomRound(GetTotal2)

                            LDPExcelGrid.Invoke(DirectCast(Sub() LDPExcelGrid(9, (Cnt - 1)).Value = GetTotal.ToString("N0", CustomtoUS).Replace(",", Nothing), MethodInvoker))
                            LDPExcelGrid.Invoke(DirectCast(Sub() LDPExcelGrid(19, (Cnt - 1)).Value = GetTotal2.ToString("N0", CustomtoUS).Replace(",", Nothing), MethodInvoker))

                            For g = 0 To 19
                                GetDTransTot(g) = Nothing
                            Next
                            PLTb2.MoveNext()
                        Loop
                    End If
            End Select
        Next
    End Sub

    Private Sub LDPExcelBtn2_Click(sender As Object, e As EventArgs) Handles LDPExcelBtn2.Click
        Select Case LDPExcelGrid.Rows.Count
            Case Is >= 1
                MakeMeXMLExtra()
                MakeMeXML()
                LDCrysRep.MdiParent = PerLedgMain
                LDCrysRep.Show()
        End Select

    End Sub

#Region "Excel Mode"

    Sub ExportExcel()
        Try
            Dim NewFile As New FileInfo(SaveName)
            If NewFile.Exists Then
                NewFile.Delete()
            End If

            Using ExcelModPkg = New ExcelPackage(NewFile)

                Dim ExcelNewWSH As ExcelWorksheet = ExcelModPkg.Workbook.Worksheets.Add("ALL")

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
                    .Value = "Periode : " & LDPExcelDp01.Text & " " & LDPExcelDp02.Text
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

                For KI = 0 To LDPExcelGrid.Rows.Count - 1

                    With ExcelNewWSH.Cells("A" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(0, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("B" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(1, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("C" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(2, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("D" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("E" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(4, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("F" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(5, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("G" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(6, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("H" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(7, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("I" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(8, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("J" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(9, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("K" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(10, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("L" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(11, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("M" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(12, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("N" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(13, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("O" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(14, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("P" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(15, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("Q" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(16, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("R" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(17, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("S" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(18, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("T" & (KI + 7).ToString)

                        .Value = LDPExcelGrid(19, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    End With

                    'PMLProg01.Value += 1

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
#End Region

    Private Sub LDPExcelBtn3_Click(sender As Object, e As EventArgs) Handles LDPExcelBtn3.Click
        Try
            Select Case LDPExcelGrid.Rows.Count
                Case Is >= 1
                    ' PMLProg01.Visible = True
                    'ResetProbar()
                    SaveFileLink()
                    'LockButtonMode()
                    'OnClickTheWorker()

                    ExportExcel()
            End Select
        Catch ex As Exception
        End Try
    End Sub

#Region "LOAD DATA JABATAN"

    Sub LoadRevJabatan()

        Dim RevJabKodeHis As New AutoCompleteStringCollection
        Dim RevJabNamaHis As New AutoCompleteStringCollection

        LDPExcelDp05.Items.Clear()
        LDPExcelDp06.Items.Clear()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount <> 0 Then
            PLTb4.MoveFirst()
            Do While Not PLTb4.EOF
                Dim getjabkode As String = IIf(IsDBNull(PLTb4("pgj_jabkode").Value), "", PLTb4("pgj_jabkode").Value)
                Dim getjab As String = IIf(IsDBNull(PLTb4("pgj_jabname").Value), "", PLTb4("pgj_jabname").Value)

                RevJabKodeHis.Add(getjabkode.ToUpper)
                RevJabNamaHis.Add(getjab.ToUpper)

                LDPExcelDp03.Items.Add(getjabkode.ToUpper)
                LDPExcelDp04.Items.Add(getjab.ToUpper)

                LDPExcelDp05.Items.Add(getjabkode.ToUpper)
                LDPExcelDp06.Items.Add(getjab.ToUpper)
                PLTb4.MoveNext()
            Loop
        End If

        LDPExcelDp03.AutoCompleteMode = AutoCompleteMode.Suggest
        LDPExcelDp03.AutoCompleteSource = AutoCompleteSource.CustomSource
        LDPExcelDp03.AutoCompleteCustomSource = RevJabKodeHis

        LDPExcelDp04.AutoCompleteMode = AutoCompleteMode.Suggest
        LDPExcelDp04.AutoCompleteSource = AutoCompleteSource.CustomSource
        LDPExcelDp04.AutoCompleteCustomSource = RevJabKodeHis

        LDPExcelDp05.AutoCompleteMode = AutoCompleteMode.Suggest
        LDPExcelDp05.AutoCompleteSource = AutoCompleteSource.CustomSource
        LDPExcelDp05.AutoCompleteCustomSource = RevJabKodeHis

        LDPExcelDp06.AutoCompleteMode = AutoCompleteMode.Suggest
        LDPExcelDp06.AutoCompleteSource = AutoCompleteSource.CustomSource
        LDPExcelDp06.AutoCompleteCustomSource = RevJabNamaHis

    End Sub

    Sub SelectingJabKode()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabkode = ('" & LDPExcelDp03.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            LDPExcelDp04.Text = IIf(IsDBNull(PLTb3("pgj_jabname").Value), "", PLTb3("pgj_jabname").Value.ToString.ToUpper)
        End If

    End Sub

    Sub SelectingJabNama()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabname = ('" & LDPExcelDp04.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            LDPExcelDp03.Text = IIf(IsDBNull(PLTb3("pgj_jabkode").Value), "", PLTb3("pgj_jabkode").Value.ToString.ToUpper)
        End If

    End Sub


    ' Sampai Dengan

    Sub SDSelectingJabKode()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabkode = ('" & LDPExcelDp05.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            LDPExcelDp06.Text = IIf(IsDBNull(PLTb3("pgj_jabname").Value), "", PLTb3("pgj_jabname").Value.ToString.ToUpper)
        End If
    End Sub

    Sub SDSelectingJabNama()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabname = ('" & LDPExcelDp06.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            LDPExcelDp05.Text = IIf(IsDBNull(PLTb3("pgj_jabkode").Value), "", PLTb3("pgj_jabkode").Value.ToString.ToUpper)
        End If
    End Sub

#End Region

    Private Sub LDPExcelDp03_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LDPExcelDp03.SelectedIndexChanged
        SelectingJabKode()
    End Sub

    Private Sub LDPExcelDp04_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LDPExcelDp04.SelectedIndexChanged
        SelectingJabNama()
    End Sub

    Private Sub LDPExcelDp05_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LDPExcelDp05.SelectedIndexChanged
        SDSelectingJabKode()
    End Sub

    Private Sub LDPExcelDp06_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LDPExcelDp06.SelectedIndexChanged
        SDSelectingJabNama()
    End Sub

    Sub TrialHeader()
        With LDPExcelGrid
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "Jabatan Kode")
            .Columns.Add("col2", "Jabatan Nama")

            For k = 0 To .Columns.Count - 1
                .Columns(k).Width = 150
            Next

        End With
    End Sub

    Sub TrialLocForDataJabatan()
        TrialHeader()
        Dim CGetCount As Int32 = 0

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabkode between ('" & LDPExcelDp03.Text & "') "
        SQL = SQL & "and ('" & LDPExcelDp05.Text & "') "
        SQL = SQL & "Or pgj_jabkode between ('" & LDPExcelDp05.Text & "') "
        SQL = SQL & "and ('" & LDPExcelDp03.Text & "') "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount > 0 Then
            PLTb4.MoveFirst()
            Do While Not PLTb4.EOF
                '   LDPExcelGrid.Rows.Add(IIf(IsDBNull(PLTb4("pgj_jabkode").Value), "", PLTb4("pgj_jabkode").Value), IIf(IsDBNull(PLTb4("pgj_jabname").Value), "", PLTb4("pgj_jabname").Value))

                SearchJabKode(CGetCount) = IIf(IsDBNull(PLTb4("pgj_jabkode").Value), "", PLTb4("pgj_jabkode").Value)

                CGetCount += 1
                PLTb4.MoveNext()
            Loop
        End If


    End Sub

    Private Sub LDPExcelBtn1_Click(sender As Object, e As EventArgs) Handles LDPExcelBtn1.Click
        Try
            TrialLocForDataJabatan()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class