Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel

Public Class PerLemburJam


    Private Sub PerLemburJam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub GridHeaderMode()
        With PLJamGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "No.")
            .Columns.Add("col1", "Kode Jabatan")
            .Columns.Add("col2", "Jabatan")
            .Columns.Add("col3", "Jam Lembur " & PLJamDp01.Value.ToString("dd MMM yyyy") & " - " & PLJamDp02.Value.ToString("dd MMM yyyy"))
            For g = 0 To .Columns.Count - 1
                .Columns(g).Width = 300
            Next
        End With
    End Sub

    Sub LoadMyDataJam()

        Dim Count As Int32 = 0
        Dim GetJabKode As String = Nothing
        Dim GetJabNama As String = Nothing
        Dim GetMyNik As String = Nothing

        Dim GetFiTime As Double
        Dim GetFiTime2 As Double

        Dim GetValTime1 As String = Nothing
        Dim GetValTime2 As String = Nothing
        Dim GetValTime3 As String = Nothing

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Order by pgj_jabkode Asc "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount <> 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF
                Count += 1
                GetFiTime = 0
                GetFiTime2 = 0

                GetJabKode = IIf(IsDBNull(PLTb3("pgj_jabkode").Value), "", PLTb3("pgj_jabkode").Value)
                GetJabNama = IIf(IsDBNull(PLTb3("pgj_jabname").Value), "", PLTb3("pgj_jabname").Value)

                SQL = Nothing
                SQL = SQL & "Select `rev_nik`, `rev_kojabatan` From pgj_empdatrev "
                SQL = SQL & "Where rev_kojabatan = ('" & GetJabKode & "') "
                OpenTbl(PLConn, PLTb4, SQL)
                If PLTb4.RecordCount <> 0 Then
                    PLTb4.MoveFirst()
                    Do While Not PLTb4.EOF

                        GetMyNik = IIf(IsDBNull(PLTb4("rev_nik").Value), "", PLTb4("rev_nik").Value)

                        SQL = Nothing
                        SQL = SQL & "Select `prj_revdate`, `prj_revnik`, `prj_revjam1`, `prj_revjam2`, `prj_revjam3` From prj_revlembur "
                        SQL = SQL & "Where prj_revdate between ('" & PLJamDp01.Value.ToString("yyyy-MM-dd", CustomtoUS) & "') "
                        SQL = SQL & "and ('" & PLJamDp02.Value.ToString("yyyy-MM-dd", CustomtoUS) & "') "
                        SQL = SQL & "and prj_revnik = ('" & GetMyNik & "') "
                        OpenTbl(PLConn, PLTb5, SQL)
                        If PLTb5.RecordCount <> 0 Then
                            PLTb5.MoveFirst()
                            Do While Not PLTb5.EOF

                                GetValTime1 = IIf(IsDBNull(PLTb5("prj_revjam1").Value), 0, PLTb5("prj_revjam1").Value)
                                GetValTime2 = IIf(IsDBNull(PLTb5("prj_revjam2").Value), 0, PLTb5("prj_revjam2").Value)
                                GetValTime3 = IIf(IsDBNull(PLTb5("prj_revjam3").Value), 0, PLTb5("prj_revjam3").Value)

                                GetFiTime += Val(GetValTime1) + Val(GetValTime2) + Val(GetValTime3)
                                '  PLJamGrid01.Invoke(DirectCast(Sub() PLJamGrid01.Rows.Add(Count, GetJabKode, GetJabNama, GetFinalVal), MethodInvoker))
                                PLTb5.MoveNext()
                            Loop
                        Else
                            GetFiTime = 0
                        End If

                        GetFiTime2 += GetFiTime
                        PLTb4.MoveNext()
                    Loop
                End If

                PLJamGrid01.Invoke(DirectCast(Sub() PLJamGrid01.Rows.Add(Count, GetJabKode, GetJabNama, GetFiTime2.ToString("N2")), MethodInvoker))
                PLTb3.MoveNext()
            Loop
        End If
    End Sub

    Private Sub PLJamBtn01_Click(sender As Object, e As EventArgs) Handles PLJamBtn01.Click
        GridHeaderMode()
        LoadMyDataJam()
    End Sub

    Private Sub PLJamDp01_ValueChanged(sender As Object, e As EventArgs) Handles PLJamDp01.ValueChanged
        PLJamDp02.Text = PLJamDp01.Text
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

                With ExcelNewWSH.Cells("A1:D1")
                    .Merge = True
                    .Value = "PT. UNIVERSAL GLOVES"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 12
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Font.Name = "CALIBRI"
                End With

                With ExcelNewWSH.Cells("A2:D2")
                    .Merge = True
                    .Value = "JL. Pertahanan No. 17 Patumbak 20361 Deli Serdang  - Indonesia"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A3:D3")
                    .Merge = True
                    .Value = "DAFTAR LEMBUR PER JAM"
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End With

                With ExcelNewWSH.Cells("A4:D4")
                    .Merge = True
                    .Value = "TANGGAL : " & PLJamDp01.Value.ToString("dd MMM yyyy") & " " & PLJamDp02.Value.ToString("dd MMM yyyy")
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
                    .Value = "TOTAL LEMBUR TGL " & PLJamDp01.Value.ToString("dd MMM yyyy") & " " & PLJamDp02.Value.ToString("dd MMM yyyy")
                    .Style.Font.Bold = True
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                For KI = 0 To PLJamGrid01.Rows.Count - 1

                    With ExcelNewWSH.Cells("A" & (KI + 7).ToString)

                        .Value = PLJamGrid01(0, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("B" & (KI + 7).ToString)

                        .Value = PLJamGrid01(1, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("C" & (KI + 7).ToString)

                        .Value = PLJamGrid01(2, KI).Value
                        .Style.Font.Bold = False
                        .Style.Font.Size = 10
                        .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                        .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                    End With

                    With ExcelNewWSH.Cells("D" & (KI + 7).ToString)

                        .Value = PLJamGrid01(3, KI).Value
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

    Private Sub PLJamBtn02_Click(sender As Object, e As EventArgs) Handles PLJamBtn02.Click

        Try
            SaveFileLink()
            ExportExcel()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

End Class