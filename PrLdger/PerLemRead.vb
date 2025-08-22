Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel

Public Class PerLemRead

    Private Sub PerLemRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub GridHeaderMode()
        With PLemGrid01
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "No. Est")
            .Columns.Add("col1", "Nama")
            .Columns.Add("col2", "Date")
            .Columns.Add("col3", "Periode")
            .Columns.Add("col4", "Periode Range")
            .Columns.Add("col5", "Jam 1")
            .Columns.Add("col6", "Value")
            .Columns.Add("col7", "Jam 2")
            .Columns.Add("col8", "Value")
            .Columns.Add("col9", "Jam 3")
            .Columns.Add("col10", "Value")
            .Columns.Add("col11", "Tot Lembur Jam")
            .Columns.Add("col12", "Jumlah")
            .Columns.Add("col13", "Remark")

            For t = 0 To .Columns.Count - 1
                .Columns(t).Width = 150
            Next

        End With
    End Sub
    Sub RevLoadLemburMode()

        Dim DaSUMonth As String = PLemDP01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = PLemDP01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)

        GridHeaderMode()

        SQL = Nothing
        SQL = SQL & "Select * From prj_revlembur "
        SQL = SQL & "Where prj_revnik like ('" & PLemTbx01.Text + "%" & "') "
        SQL = SQL & "and prj_revrpiode = ('" & PLemCmb01.Text & "') "
        SQL = SQL & "and prj_revprng = ('" & PublicMonth & " " & DaSuYr & "') "
        SQL = SQL & "or prj_revnama like ('" & PLemTbx01.Text + "%" & "') "
        SQL = SQL & "and prj_revrpiode = ('" & PLemCmb01.Text & "') "
        SQL = SQL & "and prj_revprng = ('" & PublicMonth & " " & DaSuYr & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount <> 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF

                Dim LemDate As Date = IIf(IsDBNull(PLTb3("prj_revdate").Value), Today, PLTb3("prj_revdate").Value)

                Dim GetLemVal1 As Int32 = IIf(IsDBNull(PLTb3("prj_revalue1").Value), 0, PLTb3("prj_revalue1").Value)
                Dim GetLemVal2 As Int32 = IIf(IsDBNull(PLTb3("prj_revalue2").Value), 0, PLTb3("prj_revalue2").Value)
                Dim GetLemVal3 As Int32 = IIf(IsDBNull(PLTb3("prj_revalue3").Value), 0, PLTb3("prj_revalue3").Value)

                Dim GetTtlJam1 As String = IIf(IsDBNull(PLTb3("prj_revjam1").Value), 0, PLTb3("prj_revjam1").Value)
                Dim GetTtlJam2 As String = IIf(IsDBNull(PLTb3("prj_revjam2").Value), 0, PLTb3("prj_revjam2").Value)
                Dim GetTtlJam3 As String = IIf(IsDBNull(PLTb3("prj_revjam3").Value), 0, PLTb3("prj_revjam3").Value)

                Dim GetTotLemVal As Int32 = GetLemVal1 + GetLemVal2 + GetLemVal3
                Dim GetTtlJamAll As Single = Val(GetTtlJam1) + Val(GetTtlJam2) + Val(GetTtlJam3)

                PLemGrid01.Invoke(DirectCast(Sub() PLemGrid01.Rows.Add(IIf(IsDBNull(PLTb3("prj_revnik").Value), "", PLTb3("prj_revnik").Value), _
                                                                    IIf(IsDBNull(PLTb3("prj_revnama").Value), "", PLTb3("prj_revnama").Value), _
                                                                    LemDate.ToString("dd MMM yyyy"), _
                                                                    IIf(IsDBNull(PLTb3("prj_revrpiode").Value), "", PLTb3("prj_revrpiode").Value), _
                                                                    IIf(IsDBNull(PLTb3("prj_revprng").Value), "", PLTb3("prj_revprng").Value), _
                                                                    GetTtlJam1, _
                                                                    GetLemVal1.ToString, _
                                                                    GetTtlJam2, _
                                                                    GetLemVal2.ToString, _
                                                                    GetTtlJam3, _
                                                                    GetLemVal3.ToString, GetTtlJamAll.ToString("N2"), GetTotLemVal), MethodInvoker))
                PLTb3.MoveNext()
            Loop
        End If
    End Sub

    Sub LoadLemburMode()

        GridHeaderMode()

        Dim LemRec(5) As String
        SQL = Nothing
        SQL = SQL & "Select * From pgj_lembur "
        SQL = SQL & "Where lem_est like ('" & PLemTbx01.Text + "%" & "') "
        SQL = SQL & "and lem_prde = ('" & PLemCmb01.Text & "') "
        SQL = SQL & "and lem_prdrng = ('" & PLemDP01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        SQL = SQL & "or lem_nama like ('" & PLemTbx01.Text + "%" & "') "
        SQL = SQL & "and lem_prde = ('" & PLemCmb01.Text & "') "
        SQL = SQL & "and lem_prdrng = ('" & PLemDP01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount <> 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF
                LemRec(0) = IIf(IsDBNull(PLTb3("lem_est").Value), "", PLTb3("lem_est").Value)
                LemRec(1) = IIf(IsDBNull(PLTb3("lem_nama").Value), "", PLTb3("lem_nama").Value)
                LemRec(2) = IIf(IsDBNull(PLTb3("lem_jam").Value), "", PLTb3("lem_jam").Value)
                LemRec(3) = IIf(IsDBNull(PLTb3("lem_min").Value), "", PLTb3("lem_min").Value)
                LemRec(4) = IIf(IsDBNull(PLTb3("lem_date").Value), "", PLTb3("lem_date").Value)
                LemRec(5) = IIf(IsDBNull(PLTb3("pgj_salvalue").Value), "", PLTb3("pgj_salvalue").Value)
                PLemGrid01.Invoke(DirectCast(Sub() PLemGrid01.Rows.Add(LemRec(0), LemRec(1), LemRec(2), LemRec(3), LemRec(4), LemRec(5)), MethodInvoker))
                PLTb3.MoveNext()
            Loop
        End If
    End Sub
    Private Sub PLemBtn01_Click(sender As Object, e As EventArgs) Handles PLemBtn01.Click
        Try
            '  LoadLemburMode()
            RevLoadLemburMode()
        Catch ex As Exception
        End Try
    End Sub

    Sub SaveLemtoMain()

        Dim DaSUMonth As String = PLemDP01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = PLemDP01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)

        For TM = 0 To PLemGrid01.Rows.Count - 1
            SQL = Nothing
            SQL = SQL & "Select * From pgj_trans_tot "
            SQL = SQL & "Where pgj_ttest = ('" & PLemGrid01(0, TM).Value.ToString & "') "
            SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
            SQL = SQL & "and pgj_priode = ('" & PLemCmb01.Text & "') "
            OpenTbl(PLConn, PLTb5, SQL)
            If PLTb5.RecordCount > 0 Then
                PLTb5("pgj_jamlmb").Value = PLemGrid01(11, TM).Value
                PLTb5("pgj_ttllemb").Value = PLemGrid01(12, TM).Value
                PLTb5.Update()
                PLemGrid01.Invoke(DirectCast(Sub() PLemGrid01(13, TM).Value = "Has been uploaded", MethodInvoker))
            Else
                PLemGrid01.Invoke(DirectCast(Sub() PLemGrid01(13, TM).Value = "Data Not found", MethodInvoker))
            End If
        Next
        MessageBox.Show("Done")

    End Sub
    Private Sub PLemBtn02_Click(sender As Object, e As EventArgs) Handles PLemBtn02.Click
        Try
            Select Case PLemGrid01.Rows.Count
                Case Is >= 1
                    SaveLemtoMain()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PLemTbx01_TextChanged(sender As Object, e As EventArgs) Handles PLemTbx01.TextChanged
        RevLoadLemburMode()
    End Sub
    Private Sub PLemBtn03_Click(sender As Object, e As EventArgs) Handles PLemBtn03.Click
        Try
            SaveFileLink()
            ExportExcel()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
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

                With ExcelNewWSH.Cells("A1:M1")
                    .Merge = True
                    .Value = "PT. UNIVERSAL GLOVES"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 12
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Font.Name = "CALIBRI"
                End With

                With ExcelNewWSH.Cells("A2:M2")
                    .Merge = True
                    .Value = "JL. Pertahanan No. 17 Patumbak 20361 Deli Serdang  - Indonesia"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A3:M3")
                    .Merge = True
                    .Value = "DAFTAR LEMBUR PER JAM"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A4:M4")
                    .Merge = True
                    .Value = "Periode Range : " & PLemDP01.Value.ToString("MMM yyyy") & " Periode : " & PLemCmb01.Text
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A6")
                    .Value = "No. Est / Nik "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("B6")
                    .Value = "Nama"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("C6")
                    .Value = "TGL. "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("D6")
                    .Value = "Periode "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("E6")
                    .Value = "Periode Range "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("F6")
                    .Value = "Jam 1 "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("G6")
                    .Value = "Value 1 "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("H6")
                    .Value = "Jam 2 "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("I6")
                    .Value = "Value 2"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("J6")
                    .Value = "Jam 3 "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("K6")
                    .Value = "Value 3"
                    .Style.Font.Bold = True
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Font.Size = 10
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("L6")
                    .Value = "Total Lembur Jam "
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("M6")
                    .Value = "Jumlah"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                For KI = 0 To PLemGrid01.Rows.Count - 1

                    With ExcelNewWSH.Cells("A" & (KI + 7).ToString)
                        .Value = PLemGrid01(0, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                    End With

                    With ExcelNewWSH.Cells("B" & (KI + 7).ToString)

                        .Value = PLemGrid01(1, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("C" & (KI + 7).ToString)

                        .Value = PLemGrid01(2, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("D" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("E" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("F" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("G" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("H" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("I" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("J" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("K" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("L" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("M" & (KI + 7).ToString)

                        .Value = PLemGrid01(3, KI).Value
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

End Class