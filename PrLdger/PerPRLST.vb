Public Class PerPRLST

    Private Sub PerPRLST_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDB()
        LoadDB2()

    End Sub

    Sub SaveKAMode()

        Dim DateSaveNote As Date = Today
        SQL = Nothing
        SQL = SQL & "Select * From pgj_perstan "
        SQL = SQL & "Where prj_date = ('" & DateSaveNote.ToString("yyyy-MM-dd", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If Not PLTb2.RecordCount <> 0 Then
            PLTb2.AddNew()
        End If

        PLTb2("prj_date").Value() = DateSaveNote.ToString("yyyy-MM-dd")
        PLTb2("prj_head").Value() = PVTbx01.Text
        PLTb2("prj_aktif").Value() = "Yes"
        PLTb2.Update()

    End Sub

    Sub AdaKAMode()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_perstan "
        SQL = SQL & "Where prj_aktif = ('" & "Yes" & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PLTb3("prj_aktif").Value() = "No"
            PLTb3.Update()
        End If
    End Sub

    Private Sub PVBtn01_Click(sender As Object, e As EventArgs) Handles PVBtn01.Click
        Try
            Select Case PVTbx01.Text
                Case "", Nothing
                    Exit Sub
                Case Else
                    AdaKAMode()
                    SaveKAMode()
                    Me.Dispose()
            End Select
        Catch ex As Exception
        End Try
    End Sub


End Class