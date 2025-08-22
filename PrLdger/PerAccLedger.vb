Imports System.Net.Mail

Public Class PerAccLedger
    Private ErrorCount As Integer
    Sub SaveAccount()
        Try
            SQL = Nothing
            SQL = SQL & "Select * From pgj_acc "
            SQL = SQL & "Where pgj_usern = ('" & AccTbx01.Text & "') "
            OpenTbl(PLConn, PLTb1, SQL)
            If Not PLTb1.RecordCount <> 0 Then
                PLTb1.AddNew()
            End If

            PLTb1("pgj_usern").Value() = AccTbx01.Text
            PLTb1("pgj_pass").Value() = AccTbx02.Text
            PLTb1("pgj_nama").Value() = AccTbx03.Text
            PLTb1("pgj_level").Value() = AccCmb01.Text

            PLTb1.Update()
            MessageBoxSuc("Success", Me.Text + " : Success")
            LoadAccount()
            AccTbx01.Clear()
            AccTbx02.Clear()
            AccTbx03.Clear()
        Catch ex As Exception
            MessageBoxPrb(ex.Message, Me.Text + " : ERROR ")
        End Try
    End Sub

    Sub AccountFieldErrorLook()
        TallyingError(AccTbx01, IIf(AccTbx01.Text = Nothing, "Silakan masukkan yang USER ID", Nothing))
        TallyingError(AccTbx02, IIf(AccTbx02.Text = Nothing, "Silakan masukkan yang Kata Sandi", Nothing))
        TallyingError(AccTbx03, IIf(AccTbx03.Text = Nothing, "Silakan masukkan yang Nama Asli", Nothing))
        'TallyingError(AccTbx04, IIf(ValidEmail = False Or AccTbx04.Text = Nothing, "Invalid Email", Nothing))
        If ErrorCount = 0 Then
            LookUserDup()
        Else
            MessageBoxPrb("Failed : Number of Invalid Item found (" + ErrorCount.ToString + ")", Me.Text + " : Invalid Item")
        End If
    End Sub

    Sub CheckMail(ByVal EmailMode As String)
        'Try
        '    If Not AccTbx04.Text = Nothing Then
        '        Dim testAddress = New MailAddress(EmailMode)
        '        ValidEmail = True
        '    End If
        'Catch ex As FormatException
        '    ValidEmail = False
        ' Trial Item Code
        'End Try
    End Sub

    Sub TallyingError(ByVal MyCtrl As Control, ByVal MyMsg As String) ' Counting Error for Saving
        Dim currentlyInError As Boolean = (Me.AccErrorPro.GetError(MyCtrl) <> String.Empty)
        Dim nowInError As Boolean = Not String.IsNullOrEmpty(MyMsg)
        If Not currentlyInError AndAlso nowInError Then
            'This is a new error    
            Me.ErrorCount += 1
        ElseIf currentlyInError AndAlso Not nowInError Then
            'An error is being cleared.
            Me.ErrorCount -= 1
        End If
        AccErrorPro.SetError(MyCtrl, MyMsg)
    End Sub
    Sub LookUserDup()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_acc "
        SQL = SQL & "Where pgj_usern = ('" & AccTbx01.Text & "') "
        OpenTbl(PLConn, PLTb10, SQL)
        If PLTb10.RecordCount > 0 Then
            MessageBoxPrb("USER ID : [" + AccTbx01.Text + "] is already taken", Me.Text)
        Else
            SaveAccount()
        End If
    End Sub
    Sub LoadAccount()
        GridHeader01()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_acc "
        OpenTbl(PLConn, PLTb12, SQL)
        If PLTb12.RecordCount > 0 Then
            PLTb12.MoveFirst()
            Do While Not PLTb12.EOF
                GridAcc01.Rows.Add(IIf(IsDBNull(PLTb12("pgj_usern").Value), "", PLTb12("pgj_usern").Value), _
                           IIf(IsDBNull(PLTb12("pgj_pass").Value), "", PLTb12("pgj_pass").Value.ToString), _
                           IIf(IsDBNull(PLTb12("pgj_level").Value), "", PLTb12("pgj_level").Value), _
                           IIf(IsDBNull(PLTb12("pgj_nama").Value), "", PLTb12("pgj_nama").Value))
                PLTb12.MoveNext()
            Loop
        End If
    End Sub

    Sub GridHeader01()
        With GridAcc01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "User ID")
            .Columns.Add("col1", "User Pass")
            .Columns.Add("col2", "Privilege")
            .Columns.Add("col3", "Real Name")
            .Columns(0).Width = 120
            .Columns(1).Width = 120
            .Columns(2).Width = 100
            .Columns(3).Width = 200
            .Font = New Font("Palatino Linotype", 9, FontStyle.Regular)
        End With
    End Sub
    Private Sub AccCmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AccCmb01.KeyPress
        e.Handled = True
    End Sub
    Private Sub AccBtn01_Click(sender As Object, e As EventArgs) Handles AccBtn01.Click
        AccountFieldErrorLook()
    End Sub
    Private Sub AccTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AccTbx02.KeyPress
        If Not InValid4.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub
    Dim GetRow As Int32
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GridAcc01.RowCount <> 0 Then
            Dim R As Integer = MessageBox.Show("Are you sure to DELETE this [ " & GridAcc01.CurrentRow.Cells(0).Value.ToString & " ]?", "DELETE MODE", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If R = DialogResult.Yes Then
                If GridAcc01.Rows.Count <> 0 Then
                    DeleteAccount()
                    GridAcc01.Rows.RemoveAt(GetRow)
                End If
            End If
        End If
    End Sub
    Sub DeleteAccount()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_acc "
        SQL = SQL & "Where pgj_usern = ('" & GridAcc01.CurrentRow.Cells(0).Value.ToString & "') "
        OpenTbl(PLConn, PLTb9, SQL)
        If PLTb9.RecordCount > 0 Then
            PLTb9.Delete()
        End If
    End Sub

    Private Sub PerAccLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        LoadAccount()
    End Sub

    Private Sub GridAcc01_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GridAcc01.CellMouseDown
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        GridAcc01.CurrentCell = GridAcc01(e.ColumnIndex, e.RowIndex)
        GetRow = e.RowIndex
    End Sub
End Class