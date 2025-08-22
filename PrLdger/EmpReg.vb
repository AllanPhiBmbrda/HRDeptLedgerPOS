
Public Class EmpReg

    Dim DetEst As String
    Dim DetName As String

    Private Sub EmpTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB2()
        LoadDB()
        LoadDept()
    End Sub

    Sub LoadDept()
        Dim DeptHist As New AutoCompleteStringCollection
        EmCmb05.Items.Clear()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                Dim StringUp As String = PLTb1("dep_depname").Value
                EmCmb05.Items.Add(StringUp.ToUpper)
                DeptHist.Add(StringUp.ToUpper)
                PLTb1.MoveNext()
            Loop
        End If
        EmCmb05.AutoCompleteMode = AutoCompleteMode.Suggest
        EmCmb05.AutoCompleteSource = AutoCompleteSource.CustomSource
        EmCmb05.AutoCompleteCustomSource = DeptHist

    End Sub

    Sub SaveEmp()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdat "
        SQL = SQL & "Where emp_noest = ('" & EmTbx01.Text & "') "
        SQL = SQL & "And emp_nama = ('" & EmTbx02.Text.Replace("'", "/") & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If Not PLTb1.RecordCount <> 0 Then
            PLTb1.AddNew()
        End If

        PLTb1("emp_nama").Value() = EmTbx02.Text
        PLTb1("emp_noest").Value() = EmTbx01.Text
        PLTb1("emp_noktp").Value() = CInt(Int(True))
        PLTb1("emp_dept").Value() = EmCmb05.Text
        PLTb1("emp_jab").Value() = EmCmb04.Text
        PLTb1("emp_loca").Value() = EmTbx13.Text
        PLTb1("emp_khtkhl").Value() = EmCmb06.Text

        Select Case EmTbx14.Text
            Case Nothing, ""
                PLTb1("emp_gjpokok").Value = DBNull.Value
            Case Else
                PLTb1("emp_gjpokok").Value = (EmTbx14.Text)
        End Select

        Select Case EmTbx15.Text
            Case Nothing, ""
                PLTb1("emp_tjjabatan").Value = DBNull.Value
            Case Else
                PLTb1("emp_tjjabatan").Value = (EmTbx15.Text)
        End Select

        Select Case EmTbx16.Text
            Case Nothing, ""
                PLTb1("emp_tjmasker").Value = DBNull.Value
            Case Else
                PLTb1("emp_tjmasker").Value = (EmTbx16.Text)
        End Select

        Select Case EmTbx17.Text
            Case Nothing, ""
                PLTb1("emp_tjkera").Value = DBNull.Value
            Case Else
                PLTb1("emp_tjkera").Value = (EmTbx17.Text)
        End Select

        Select Case EmCmb07.Text
            Case Nothing, ""
                PLTb1("emp_exkhtkhl").Value() = DBNull.Value
            Case Else
                PLTb1("emp_exkhtkhl").Value() = EmCmb07.Text
        End Select

        PLTb1("emp_mskerja").Value() = EmDp02.Value.ToString("yyyy-MM-dd", CustomtoUS)

        Select Case EmDp03.Value
            Case Today
                PLTb1("emp_efkerja").Value() = DBNull.Value
            Case Else
                PLTb1("emp_efkerja").Value() = EmDp03.Value.ToString("yyyy-MM-dd", CustomtoUS)
        End Select

        ' PLTb1("emp_efkerja").Value() = EmDp03.Value.ToString("yyyy-MM-dd", CustomtoUS)

        Select Case CbDI04.Checked
            Case True
                PLTb1("emp_aktif").Value() = "Yes"
            Case False
                PLTb1("emp_aktif").Value() = "No"
        End Select

        Select Case EmTbx19.Text
            Case Nothing, ""
                PLTb1("emp_bpjstkerj").Value() = DBNull.Value
            Case Else
                PLTb1("emp_bpjstkerj").Value() = EmTbx19.Text
        End Select

        Select Case EmTbx20.Text
            Case Nothing, ""
                PLTb1("emp_bpjskeseh").Value() = DBNull.Value
            Case Else
                PLTb1("emp_bpjskeseh").Value() = EmTbx20.Text
        End Select

        Select Case EmTbx21.Text
            Case Nothing, ""
                PLTb1("emp_potatm").Value() = DBNull.Value
            Case Else
                PLTb1("emp_potatm").Value() = EmTbx21.Text
        End Select

        PLTb1.Update()
        MessageBox.Show("Successfully Saved", Me.Text)

    End Sub

    Sub GenGridHeader()
        With GridEmp01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col1", "No Est.")
            .Columns.Add("col2", "Nama")
            .Columns.Add("col3", "Aktif")
            .Columns.Add("col4", "Kontrak")
            .Columns.Add("col5", "Company")
            .Columns(0).Width = 150
            .Columns(1).Width = 250
            .Columns(2).Width = 70
            .Columns(3).Width = 70
            .Columns(4).Width = 70
            .Font = New Font("Palatino Linotype", 9, FontStyle.Regular)
        End With
    End Sub

    Sub LoadJabMode()
        Dim JabHist As New AutoCompleteStringCollection
        EmCmb04.Items.Clear()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_deplink = ('" & EmCmb05.Text & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                Dim StringUp As String = PLTb1("pgj_jabname").Value
                EmCmb04.Items.Add(StringUp.ToUpper)
                JabHist.Add(StringUp.ToUpper)
                PLTb1.MoveNext()
            Loop
        End If
        EmCmb04.AutoCompleteMode = AutoCompleteMode.Suggest
        EmCmb04.AutoCompleteSource = AutoCompleteSource.CustomSource
        EmCmb04.AutoCompleteCustomSource = JabHist
    End Sub

    Sub LoadtoGrid()

        Dim FEst As String = Nothing
        Dim FNama As String = Nothing
        Dim FActif As String = Nothing
        Dim FKon As String = Nothing
        Dim FCom As String = Nothing

        GenGridHeader()

        Dim ToQuery As String = Nothing
        Dim ToQuery2 As String = Nothing

        'Select Case CmbEmp01.Text

        '    Case "No. Est"
        '        SQL = Nothing
        '        SQL = SQL & "Select `p_est`, `p_nama`, `p_actif`, `p_kontrak`, `p_company` From p_empinfo "
        '        SQL = SQL & "Where p_est like ('" & TbxList01.Text.Replace(" ", "%") + "%" & "') "
        '        SQL = SQL & "And p_actif = ('" & IIf(CmbEmp02.Text = "Yes", "Y", "N") & "') "

        '    Case "Nama"
        '        SQL = Nothing
        '        SQL = SQL & "Select `p_est`, `p_nama`, `p_actif`, `p_kontrak`, `p_company` From p_empinfo "
        '        SQL = SQL & "Where p_actif = ('" & IIf(CmbEmp02.Text = "Yes", "Y", "N") & "') "
        '        SQL = SQL & "And p_nama like ('" & TbxList01.Text.Replace(" ", "%") + "%" & "') "

        'End Select

        SQL = Nothing
        SQL = SQL & "Select `p_est`, `p_nama`, `p_actif`, `p_kontrak`, `p_company` From p_empinfo "
        SQL = SQL & "Where p_actif = ('" & IIf(CmbEmp02.Text = "Yes", "Y", "N") & "') "
        SQL = SQL & "and p_est like ('" & TbxList01.Text.Replace(" ", "%") + "%" & "') "
        SQL = SQL & "or p_actif = ('" & IIf(CmbEmp02.Text = "Yes", "Y", "N") & "') "
        SQL = SQL & "and p_nama like ('" & TbxList01.Text.Replace(" ", "%") + "%" & "') "

        OpenTbl(PCConn, PCTb1, SQL)
        If PCTb1.RecordCount <> 0 Then
            PCTb1.MoveFirst()
            Do While Not PCTb1.EOF
                FEst = IIf(IsDBNull(PCTb1("p_est").Value), "", PCTb1("p_est").Value)
                FNama = IIf(IsDBNull(PCTb1("p_nama").Value), "", PCTb1("p_nama").Value)
                FActif = IIf(IsDBNull(PCTb1("p_actif").Value), "", PCTb1("p_actif").Value)
                FKon = IIf(IsDBNull(PCTb1("p_kontrak").Value), "", PCTb1("p_kontrak").Value)
                FCom = IIf(IsDBNull(PCTb1("p_company").Value), "", PCTb1("p_company").Value)
                FNama = FNama.Replace("?", "'")
                GridEmp01.Rows.Add(FEst, FNama, FActif, FKon, FCom)
                PCTb1.MoveNext()
            Loop
        End If
    End Sub

    Private Sub BtnEmp01_Click(sender As Object, e As EventArgs) Handles BtnEmp01.Click
        Try
            LoadtoGrid()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadRequirement()
        SQL = Nothing
        SQL = SQL & "Select emp_gjpokok, emp_tjjabatan, emp_tjmasker, emp_exkhtkhl, emp_tjkera, emp_bpjstkerj, emp_bpjskeseh From pgj_empdat "
        SQL = SQL & "Where emp_noest = ('" & EmTbx01.Text & "') "
        SQL = SQL & "And emp_nama = ('" & EmTbx02.Text & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            EmTbx14.Text = IIf(IsDBNull(PLTb1("emp_gjpokok").Value), Nothing, (PLTb1("emp_gjpokok").Value))
            EmTbx15.Text = IIf(IsDBNull(PLTb1("emp_tjjabatan").Value), Nothing, (PLTb1("emp_tjjabatan").Value))
            EmTbx16.Text = IIf(IsDBNull(PLTb1("emp_tjmasker").Value), Nothing, (PLTb1("emp_tjmasker").Value))
            EmTbx17.Text = IIf(IsDBNull(PLTb1("emp_tjkera").Value), Nothing, (PLTb1("emp_tjkera").Value))
            EmTbx19.Text = IIf(IsDBNull(PLTb1("emp_bpjstkerj").Value), Nothing, (PLTb1("emp_bpjstkerj").Value))
            EmTbx20.Text = IIf(IsDBNull(PLTb1("emp_bpjskeseh").Value), Nothing, (PLTb1("emp_bpjskeseh").Value))
            EmCmb07.Text = IIf(IsDBNull(PLTb1("emp_exkhtkhl").Value), Nothing, (PLTb1("emp_exkhtkhl").Value))
        Else
            EmTbx14.Clear()
            EmTbx15.Clear()
            EmTbx16.Clear()
            EmTbx17.Clear()
            EmTbx19.Clear()
            EmTbx20.Clear()
        End If
    End Sub

    Private Sub BtnDI01_Click(sender As Object, e As EventArgs) Handles BtnDI01.Click
        Unlock()
    End Sub

    Sub Unlock()
        GroupBox1.Enabled = True
        GroupBox4.Enabled = True
        GroupBox7.Enabled = True
        GroupBox8.Enabled = True
        GroupBox6.Enabled = True
    End Sub

    Sub SaveEmpItems()
        If GridEmp01.Rows.Count > 0 Then
            DetEst = GridEmp01.CurrentRow.Cells(0).Value.ToString ' Est
            DetName = GridEmp01.CurrentRow.Cells(1).Value.ToString ' Nama
        End If
    End Sub
    Private Sub ComDi01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmCmb01.KeyPress
        e.Handled = True
    End Sub
    Sub LoadAnak()
        SQL = Nothing
        SQL = SQL & "Select * From p_anaklist "
        SQL = SQL & "Where p_aest = ('" & DetEst & "') "
        OpenTbl(PCConn, PCTb2, SQL)
        If PCTb2.RecordCount <> 0 Then
            PCTb2.MoveFirst()
            Do While Not PCTb2.EOF
                TbxList01.Text &= (IIf(IsDBNull(PCTb2("p_achild").Value), "", PCTb2("p_achild").Value.ToString.Replace("?", "'"))) + vbNewLine
                PCTb2.MoveNext()
            Loop
        End If
    End Sub

    Sub LoadKeahlian()
        With GridEmp04
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "KEAHLIAN")
            .Columns(0).Width = 450
        End With
        SQL = Nothing
        SQL = SQL & "Select * From p_skill "
        SQL = SQL & "Where p_sest = ('" & DetEst & "') "
        OpenTbl(PCConn, PCTb2, SQL)
        If PCTb2.RecordCount <> 0 Then
            PCTb2.MoveFirst()
            Do While Not PCTb2.EOF
                GridEmp04.Rows.Add(IIf(IsDBNull(PCTb2("p_skeahlian").Value), "", PCTb2("p_skeahlian").Value))
                PCTb2.MoveNext()
            Loop
        End If
    End Sub

    Sub LoadPelatihan()
        With GridEmp05
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "PELATIHAN")
            .Columns(0).Width = 450
        End With
        SQL = Nothing
        SQL = SQL & "Select * From p_training "
        SQL = SQL & "Where p_test = ('" & DetEst & "') "
        OpenTbl(PCConn, PCTb2, SQL)
        If PCTb2.RecordCount <> 0 Then
            PCTb2.MoveFirst()
            Do While Not PCTb2.EOF
                GridEmp05.Rows.Add(IIf(IsDBNull(PCTb2("p_pelatihan").Value), "", PCTb2("p_pelatihan").Value))
                PCTb2.MoveNext()
            Loop
        End If
    End Sub
    Sub LoadPendidikan()
        With GridEmp03
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "PENDIDIKAN")
            .Columns(0).Width = 450
        End With
        SQL = Nothing
        SQL = SQL & "Select * From p_educlist "
        SQL = SQL & "Where p_pest = ('" & DetEst & "') "
        OpenTbl(PCConn, PCTb2, SQL)
        If PCTb2.RecordCount <> 0 Then
            PCTb2.MoveFirst()
            Do While Not PCTb2.EOF
                GridEmp03.Rows.Add(IIf(IsDBNull(PCTb2("p_pendidikan").Value), "", PCTb2("p_pendidikan").Value))
                PCTb2.MoveNext()
            Loop
        End If
    End Sub
    Sub LoadAnakMode()
        SQL = Nothing
        SQL = SQL & "Select * From p_anaklist "
        SQL = SQL & "Where p_aest = ('" & DetEst & "') "
        OpenTbl(PCConn, PCTb2, SQL)
        If PCTb2.RecordCount > 0 Then
            EmTbx18.Text = PCTb2.RecordCount.ToString
        Else
            EmTbx18.Clear()
        End If
    End Sub

    Sub LoadtoTbx()
        Dim GenderCode As String = Nothing
        SQL = Nothing
        SQL = SQL & "Select * From p_empinfo "
        SQL = SQL & "Where p_est = ('" & DetEst & "') "
        SQL = SQL & "And p_nama = ('" & DetName.Replace("'", "?") & "') "
        OpenTbl(PCConn, PCTb2, SQL)
        If PCTb2.RecordCount > 0 Then

            ' Personal Info 
            EmTbx01.Text = IIf(IsDBNull(PCTb2("p_est").Value), "", PCTb2("p_est").Value)
            EmTbx02.Text = IIf(IsDBNull(PCTb2("p_nama").Value), "", PCTb2("p_nama").Value.ToString.Replace("?", "'"))
            EmTbx03.Text = IIf(IsDBNull(PCTb2("p_alamat").Value), "", PCTb2("p_alamat").Value) 'Alamat 
            EmTbx04.Text = IIf(IsDBNull(PCTb2("p_alamatct").Value), "", PCTb2("p_alamatct").Value) ' Alamat Saat Ini  

            EmTbx05.Text = IIf(IsDBNull(PCTb2("p_temlahir").Value), "", PCTb2("p_temlahir").Value) ' Tempat lahir  
            EmTbx06.Text = IIf(IsDBNull(PCTb2("p_nohp").Value), "", PCTb2("p_nohp").Value) ' No. HP  
            EmTbx07.Text = IIf(IsDBNull(PCTb2("p_teldarurat").Value), "", PCTb2("p_teldarurat").Value) ' No. Telp Darurat  
            EmDp01.Text = IIf(IsDBNull(PCTb2("p_tanglahir").Value), "", PCTb2("p_tanglahir").Value) 'Tanggal Lahir  
            EmCmb01.Text = IIf(IsDBNull(PCTb2("p_agama").Value), "", PCTb2("p_agama").Value) ' Agama  
            EmCmb02.Text = IIf(IsDBNull(PCTb2("p_status").Value), "", PCTb2("p_status").Value) ' Status  
            GenderCode = IIf(PCTb2("p_jkelamin").Value = Nothing, Nothing, PCTb2("p_jkelamin").Value) ' Jenis Kelamin 
            If GenderCode = "LK" Then
                EmCk02.Checked = True
            ElseIf GenderCode = "PR" Then
                EmCk01.Checked = True
            End If

            ' Insurance Bank 
            EmTbx08.Text = IIf(IsDBNull(PCTb2("p_notj").Value), "", PCTb2("p_notj").Value) ' No. BPJS Tenaga Kerja 
            EmTbx09.Text = IIf(IsDBNull(PCTb2("p_nokese").Value), "", PCTb2("p_nokese").Value) ' No. BPJS Kesehatan 
            EmTbx10.Text = IIf(IsDBNull(PCTb2("p_noktp").Value), "", PCTb2("p_noktp").Value) ' No. KTP 
            EmTbx11.Text = IIf(IsDBNull(PCTb2("p_norek").Value), "", PCTb2("p_norek").Value) ' No Rekening 
            EmCmb03.Text = IIf(IsDBNull(PCTb2("p_bank").Value), "", PCTb2("p_bank").Value) ' Nama Bank 
            ' Kontrak / Jabatan /  Bagian 
            EmTbx12.Text = IIf(IsDBNull(PCTb2("p_nokontrak").Value), "", PCTb2("p_nokontrak").Value) ' No. Kontrak C

            EmDp02.Text = IIf(IsDBNull(PCTb2("p_tmk2").Value), "", PCTb2("p_tmk2").Value) ' TMK UG 
            Dim CompCod = IIf(IsDBNull(PCTb2("p_company").Value), "", PCTb2("p_company").Value) ' Company Code

            Dim KonCod = IIf(IsDBNull(PCTb2("p_kontrak").Value), "", PCTb2("p_kontrak").Value) ' Kontrak? Yes or No x   
            EmTbx13.Text = IIf(IsDBNull(PCTb2("p_location").Value), "", PCTb2("p_location").Value)
            EmCmb06.Text = IIf(IsDBNull(PCTb2("p_khtkhl").Value), "", PCTb2("p_khtkhl").Value)
            EmCmb05.Text = IIf(IsDBNull(PCTb2("p_dept").Value), Nothing, PCTb2("p_dept").Value) ' Bagian 
            EmCmb04.Text = IIf(IsDBNull(PCTb2("p_jab").Value), Nothing, PCTb2("p_jab").Value) ' Jabatan 

            Select Case PCTb2("p_actif").Value
                Case "Yes", "YES", "Y"
                    CbDI04.Checked = True
                Case Else
                    CbDI04.Checked = False
            End Select
        End If

        LoadKeahlian()
        LoadPendidikan()
        LoadPelatihan()
        LoadAnakMode()

    End Sub
    Private Sub GridEmp01_DoubleClick(sender As Object, e As EventArgs) Handles GridEmp01.DoubleClick
        If GridEmp01.Rows.Count > 0 Then
            DetEst = GridEmp01.CurrentRow.Cells(0).Value.ToString ' Est
            DetName = GridEmp01.CurrentRow.Cells(1).Value.ToString ' Nama
            LoadtoTbx()
            LoadRequirement()
            TabControl1.SelectTab(1)
            Unlock()
        End If
    End Sub
    Private Sub BtnDI02_Click(sender As Object, e As EventArgs) Handles BtnDI02.Click
        If Not EmTbx01.Text = Nothing Then
            SaveEmp()
        End If
    End Sub
    Private Sub EmTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx01.KeyPress
        e.Handled = True
    End Sub
    Private Sub EmTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx02.KeyPress
        e.Handled = True
    End Sub
    Private Sub TbxList01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbxList01.KeyPress
        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            LoadtoGrid()
            GridEmp01.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub CmbEmp01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbEmp01.KeyPress
        e.Handled = True
    End Sub
    Private Sub CmbEmp02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbEmp02.KeyPress
        e.Handled = True
    End Sub
    Private Sub EmCmb06_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmCmb06.KeyPress
        e.Handled = False
    End Sub
    Private Sub EmCmb06_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EmCmb06.SelectedIndexChanged
        Select Case EmCmb06.Text
            Case "KHL"
                EmCmb07.Enabled = True
            Case Else
                EmCmb07.Enabled = False
        End Select
    End Sub
    Private Sub EmCmb07_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmCmb07.KeyPress
        e.Handled = True
    End Sub
    Private Sub EmRa01_CheckedChanged(sender As Object, e As EventArgs)
        'Select Case EmRa01.Checked
        '    Case True
        '        EmDp03.Enabled = True
        '        EmDp04.Enabled = True
        '    Case False
        '        EmDp03.Enabled = False
        '        EmDp04.Enabled = False
        'End Select
    End Sub
    Private Sub EmCmb05_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EmCmb05.SelectedIndexChanged
        LoadJabMode()
    End Sub
    Private Sub EmTbx14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx14.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Private Sub EmTbx15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx15.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Private Sub EmTbx16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx16.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Private Sub EmTbx17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx17.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Private Sub EmTbx19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx19.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Private Sub EmTbx20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx20.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Private Sub EmTbx21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmTbx21.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub

    Private Sub GridEmp01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridEmp01.CellContentClick

    End Sub

    Private Sub CmbEmp02_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEmp02.SelectedIndexChanged

    End Sub

    Private Sub TbxList01_TextChanged(sender As Object, e As EventArgs) Handles TbxList01.TextChanged

    End Sub
End Class