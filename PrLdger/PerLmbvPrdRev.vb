Public Class PerLmbvPrdRev

    Private Sub PerLmbvPrdRev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub GridHeaderLmbPrd()
        With LPGrid01

            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "Nik / Est")
            .Columns.Add("col1", "Nama")
            .Columns.Add("col2", LPCmb01.Text & " - A")
            .Columns.Add("col2", LPCmb01.Text & " - B")
            .Columns.Add("col4", "Lmb Jam")
            .Columns.Add("col5", "Lmb Nilai")
            .Columns.Add("col6", "Remark")

            For c = 0 To .Columns.Count - 1

                .Columns(c).Width = 200

            Next

        End With

    End Sub

    Sub LoadPrdLmb()
        Dim DaSUMonth As String = LPDp01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = LPDp01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)


        GridHeaderLmbPrd()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_lemprdtb "
        SQL = SQL & "Where lmprd_periode = ('" & LPCmb01.Text & "') "
        SQL = SQL & "and lmprd_perrng = ('" & PublicMonth & " " & DaSuYr & "') "
        OpenTbl(PLConn, PLTb10, SQL)
        If PLTb10.RecordCount > 0 Then
            PLTb10.MoveFirst()
            Do While Not PLTb10.EOF

                Dim LmbNik As String = IIf(IsDBNull(PLTb10("lmprd_est").Value), "", PLTb10("lmprd_est").Value)
                Dim LmbNama As String = IIf(IsDBNull(PLTb10("lmprd_nama").Value), "", PLTb10("lmprd_nama").Value)
                Dim LmbAbsenA As String = IIf(IsDBNull(PLTb10("lmprd_absenA").Value), "", PLTb10("lmprd_absenA").Value)
                Dim LmbAbsenB As String = IIf(IsDBNull(PLTb10("lmprd_absenB").Value), "", PLTb10("lmprd_absenB").Value)

                '  Calculation for Nilai

                Dim LmbTotA As Int32 = 7 - Val(LmbAbsenA)
                Dim TotANi As Int32

                Select Case LmbTotA
                    Case Is >= 1
                        TotANi = 0
                    Case Else
                        TotANi = 2
                End Select

                Dim LmbTotB As Int32 = 8 - Val(LmbAbsenB)
                Dim TotBNi As Int32
                Select Case LmbTotB
                    Case Is >= 1
                        TotBNi = 0
                    Case Else
                        TotBNi = 2
                End Select

                Dim FinTotNi As Int32 = TotANi + TotBNi
                Dim NilTot As Int32 = (FinTotNi / 2) * 50001

                LPGrid01.Invoke(DirectCast(Sub() LPGrid01.Rows.Add(LmbNik, LmbNama, LmbAbsenA, LmbAbsenB, FinTotNi.ToString, NilTot.ToString), MethodInvoker))

                'LPGrid01.Rows.Add(LmbNik, LmbNama, LmbAbsenA, LmbAbsenB)
                PLTb10.MoveNext()
            Loop
        End If

    End Sub

    Sub SaveNilaitoMain()

        For g = 0 To LPGrid01.Rows.Count - 1

            Dim DaSUMonth As String = LPDp01.Value.ToString("MMM", CustomtoUS)
            Dim DaSuYr As String = LPDp01.Value.ToString("yyyy", CustomtoUS)
            CheckDateIndoEnglish(DaSUMonth)


            SQL = Nothing
            SQL = SQL & "Select `pgj_ttest`, `pgj_prrng`, `pgj_priode`, `pgj_lpjam`, `pgj_lpnilai` From pgj_trans_tot "
            SQL = SQL & "Where pgj_ttest = ('" & LPGrid01(0, g).Value & "') "
            SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
            SQL = SQL & "and pgj_priode = ('" & LPCmb01.Text & "') "
            OpenTbl(PLConn, PLTb9, SQL)
            If PLTb9.RecordCount > 0 Then

                PLTb9("pgj_lpjam").Value() = LPGrid01(4, g).Value
                PLTb9("pgj_lpnilai").Value() = LPGrid01(5, g).Value

                LPGrid01(6, g).Value = "Saved"
                PLTb9.Update()
            Else
                LPGrid01(6, g).Value = "No Data Found"
            End If
        Next
    End Sub

    Private Sub LPBtn01_Click(sender As Object, e As EventArgs) Handles LPBtn01.Click
        LoadPrdLmb()
    End Sub

    Private Sub LPBtn02_Click(sender As Object, e As EventArgs) Handles LPBtn02.Click
        SaveNilaitoMain()
    End Sub


End Class