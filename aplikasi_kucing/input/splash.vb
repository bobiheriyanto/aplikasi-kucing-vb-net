Public Class splash

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 1

        Label2.Text += 1

        If ProgressBar1.Value = 100 Then

            Timer1.Dispose()

            Me.Visible = False
            
            menuutama.Show()



        End If
    End Sub

    Private Sub splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = "LOADING.."
        Label2.Text = 1
        Label3.Text = "%"
        Timer1.Enabled = True
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub
End Class