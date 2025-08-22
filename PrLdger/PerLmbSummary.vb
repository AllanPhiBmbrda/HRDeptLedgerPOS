Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel

Public Class PerLmbSummary

    Private Sub PerLmbSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub GridHeaderMode()
        With LSGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("Col0", "No. ")
            .Columns.Add("Col1", "Kode Jabatan")
            .Columns.Add("Col2", "Jabatan")
            .Columns.Add("Col3", "Jumlah Karyawan I")
            .Columns.Add("Col4", "Total Lembur I ")
            .Columns.Add("Col5", "Jumlah Karyawan II")
            .Columns.Add("Col6", "Total Lembur II")
            .Columns.Add("Col7", "Main Total Lembur ")

            For u = 0 To .Columns.Count - 1
                .Columns(u).Width = 200
            Next
        End With
    End Sub

    Sub LoadJabatanNow()

        Dim DaSUMonth As String = LSDp01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = LSDp01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        GridHeaderMode()

        Dim TotaPer1 As Int64 = 0
        Dim TotaPer2 As Int64 = 0
        Dim KarCnt1 As Int32 = 0
        Dim KarCnt2 As Int32 = 0
        Dim RowNum As Int32 = 0

        SQL = Nothing
        SQL = SQL & "Select `pgj_jabname` , `pgj_jabkode` From pgj_jablist "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF

                Dim Lmbgetjab As String = IIf(IsDBNull(PLTb2("pgj_jabname").Value), "", PLTb2("pgj_jabname").Value)
                Dim Lmbgetkojab As String = IIf(IsDBNull(PLTb2("pgj_jabkode").Value), "", PLTb2("pgj_jabkode").Value)

                SQL = Nothing
                SQL = SQL & "Select `pgj_jaba`, `pgj_prrng`, `pgj_priode`, `pgj_ttllemb` From pgj_trans_tot "
                SQL = SQL & "Where pgj_jaba = ('" & Lmbgetjab & "') "
                SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
                SQL = SQL & "and pgj_priode = ('" & "Periode I" & "') "
                OpenTbl(PLConn, PLTb3, SQL) 
                If PLTb3.RecordCount > 0 Then
                    PLTb3.MoveFirst()
                    Do While Not PLTb3.EOF
                        Dim Get1 As String = IIf(IsDBNull(PLTb3("pgj_ttllemb").Value), 0, (PLTb3("pgj_ttllemb").Value))
                        TotaPer1 += Val(Get1)
                        KarCnt1 += 1
                        PLTb3.MoveNext()
                    Loop
                End If

                SQL = Nothing
                SQL = SQL & "Select `pgj_jaba`, `pgj_prrng`, `pgj_priode`, `pgj_ttllemb` From pgj_trans_tot "
                SQL = SQL & "Where pgj_jaba = ('" & Lmbgetjab & "') "
                SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
                SQL = SQL & "and pgj_priode = ('" & "Periode II" & "') "
                OpenTbl(PLConn, PLTb4, SQL)
                If PLTb4.RecordCount > 0 Then
                    PLTb4.MoveFirst()
                    Do While Not PLTb4.EOF

                        Dim Get2 As String = IIf(IsDBNull(PLTb4("pgj_ttllemb").Value), 0, PLTb4("pgj_ttllemb").Value)
                        TotaPer2 += Val(Get2)
                        KarCnt2 += 2
                        PLTb4.MoveNext()

                    Loop
                End If

                RowNum += 1

                Dim MainTotper As Int64 = TotaPer2 + TotaPer1
                LSGrid01.Invoke(DirectCast(Sub() LSGrid01.Rows.Add(RowNum, Lmbgetkojab, Lmbgetjab, KarCnt1, TotaPer1, KarCnt2, TotaPer2, MainTotper), MethodInvoker))
                TotaPer1 = 0
                TotaPer2 = 0
                KarCnt1 = 0
                KarCnt2 = 0
                PLTb2.MoveNext()
            Loop

        End If
    End Sub

    Private Sub LSBtn01_Click(sender As Object, e As EventArgs) Handles LSBtn01.Click
        LoadJabatanNow()
    End Sub

    Private Sub LSBtn02_Click(sender As Object, e As EventArgs) Handles LSBtn02.Click
        Try
            SaveFileLink()
            ExportExcel()
        Catch ex As Exception
            MessageBox.Show("~~~~~~~~~~~~~~~~~~" & ex.ToString & "~~~~~~~~~~~~~~~~~~~~")
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

                With ExcelNewWSH.Cells("A1:H1")
                    .Merge = True
                    .Value = "PT. UNIVERSAL GLOVES"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 12
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Font.Name = "CALIBRI"
                End With

                With ExcelNewWSH.Cells("A2:H2")
                    .Merge = True
                    .Value = "JL. Pertahanan No. 17 Patumbak 20361 Deli Serdang  - Indonesia"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A3:H3")
                    .Merge = True
                    .Value = "DAFTAR LEMBUR PER BAGIAN"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A4:H4")
                    .Merge = True
                    .Value = "Periode : PERIODE I & II"
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
                    .Value = "Kode Jabatan"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("C6")
                    .Value = "Jabatan"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("D6")
                    .Value = "JUMLAH KARYAWAN I"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("E6")
                    .Value = "TOTAL LEMBUR I"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("F6")
                    .Value = "JUMLAH KARYAWAN II"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("G6")
                    .Value = "TOTAL LEMBUR II"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("H6")
                    .Value = "MAIN TOTAL LEMBUR"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                For KI = 0 To LSGrid01.Rows.Count - 1

                    With ExcelNewWSH.Cells("A" & (KI + 7).ToString)

                        .Value = LSGrid01(0, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("B" & (KI + 7).ToString)

                        .Value = LSGrid01(1, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("C" & (KI + 7).ToString)

                        .Value = LSGrid01(2, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("D" & (KI + 7).ToString)

                        .Value = LSGrid01(3, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("E" & (KI + 7).ToString)

                        .Value = LSGrid01(4, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("F" & (KI + 7).ToString)

                        .Value = LSGrid01(5, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("G" & (KI + 7).ToString)

                        .Value = LSGrid01(6, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("H" & (KI + 7).ToString)

                        .Value = LSGrid01(6, KI).Value
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