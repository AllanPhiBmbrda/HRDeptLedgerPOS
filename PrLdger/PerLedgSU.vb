Public Class PerLedgSU

    Private Sub SUTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx01.KeyPress
        e.Handled = True
    End Sub

    Private Sub SUTbx01_TextChanged(sender As Object, e As EventArgs) Handles SUTbx01.TextChanged
    End Sub

    Sub DeactOldStandard()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_standard "
        SQL = SQL & "Where st_aktif = ('" & CInt(Int(True)) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2("st_aktif").Value() = CInt(Int(False))
            PLTb2.Update()
        End If
    End Sub

    Sub SaveNewStandard()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_standard "
        SQL = SQL & "Where st_nama = ('" & SUTbx01.Text & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If Not PLTb1.RecordCount <> 0 Then
            PLTb1.AddNew()
        End If

        PLTb1("st_nama").Value() = SUTbx01.Text
        PLTb1("st_date").Value() = Today.ToString("yyyy-MM-dd")
        PLTb1("st_aktif").Value() = CInt(Int(True))
        PLTb1("st_umr").Value() = SUTbx02.Text
        PLTb1("st_subsidi").Value() = SUTbx03.Text
        PLTb1("st_Agr").Value() = SUTbx04.Text
        PLTb1("st_Bgr").Value() = SUTbx05.Text
        PLTb1("st_Cgr").Value() = SUTbx06.Text
        PLTb1("st_Dgr").Value() = SUTbx07.Text
        PLTb1("st_Egr").Value() = SUTbx08.Text
        PLTb1("st_Fgr").Value() = SUTbx09.Text
        PLTb1("st_pdumr").Value() = SUTbx11.Text
        PLTb1.Update()
        MessageBox.Show("Successfully Saved", Me.Text)
        Me.Dispose()
    End Sub

    Sub LoadStandard()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_standard "
        SQL = SQL & "Where st_aktif = ('" & CInt(Int(True)) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            SUTbx01.Text = PLTb2("st_nama").Value()
            SUTbx02.Text = PLTb2("st_umr").Value()
            SUTbx03.Text = PLTb2("st_subsidi").Value()
            SUTbx04.Text = PLTb2("st_Agr").Value()
            SUTbx05.Text = PLTb2("st_Bgr").Value()
            SUTbx06.Text = PLTb2("st_Cgr").Value()
            SUTbx07.Text = PLTb2("st_Dgr").Value()
            SUTbx08.Text = PLTb2("st_Egr").Value()
            SUTbx09.Text = PLTb2("st_Fgr").Value()
            SUTbx11.Text = PLTb2("st_pdumr").Value()
        End If
    End Sub

    Private Sub PerLedgSU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadStandard()
    End Sub

    Private Sub SUTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx02.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub SUTbx03_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx03.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub SUTbx04_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx04.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub SUTbx05_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx05.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub SUTbx06_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx06.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub SUTbx07_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx07.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub SUTbx08_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SUTbx09.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnEmp01_Click(sender As Object, e As EventArgs) Handles BtnEmp01.Click
        SUTbx01.Text = "Standard-" & Today.ToString("ddMMMyyyy")
        DeactOldStandard()
        If Not SUTbx01.Text = Nothing Then
            SaveNewStandard()
        End If
    End Sub

End Class