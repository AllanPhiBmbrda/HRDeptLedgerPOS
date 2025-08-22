Imports System.IO
Public Class PerLedgConn

    Private Sub PerLedgConn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PCETbx01.Text = PurConnect.TapConnect
        PCETbx02.Text = "DRIVER={MySQL ODBC 5.3 ANSI Driver};"
    End Sub

    Sub CreateNewConnect()

        PurConnect.trappath = Application.StartupPath + "\DefaultConnection\ConnectionString.txt"
        If File.Exists(PurConnect.trappath) Then
            File.Delete(PurConnect.trappath)
        End If

        If Not File.Exists(PurConnect.trappath) Then
            ' Create a file to write to. 
            Using sw As StreamWriter = File.CreateText(PurConnect.trappath)
                sw.WriteLine(Encrypt(PCETbx02.Text _
                  & "SERVER=" + PCETbx03.Text + ";" _
                  & "Port=" + PCETbx04.Text + ";"))
            End Using

            Dim ShutDownApp As Integer = MessageBox.Show("Please Restart this Application", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
            If ShutDownApp = DialogResult.OK Then
                PerLedgMain.Dispose()
            End If
        End If

    End Sub

    Private Sub PCEBtn01_Click(sender As Object, e As EventArgs) Handles PCEBtn01.Click
        Try
            CreateNewConnect()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text)
        End Try
    End Sub

End Class