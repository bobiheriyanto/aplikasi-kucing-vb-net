Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.Odbc
Imports MySql.Data
Imports System.Data.SqlClient
Public Class login
    Private Sub cmdlogin_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogin.Click
        Dim user, pass, hak As String
        user = t22.Text
        pass = t33.Text
        hak = t1.Text
        sql = "select * from admin where idlevel='" + hak + "' and username='" + user + "' and pass='" + pass + "'"
        cmd = New MySqlCommand(sql, conn)
        rd = cmd.ExecuteReader()
        MessageBox.Show("LOGIN BERHASIL", "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        t22.Text = ""
        t33.Text = ""
        If rd.HasRows = True Then
            If hak = "admin" Then
                splash.Show()
                Me.Hide()
        ElseIf hak="pimpinan" Then
                splash2.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Kombinasi Username ,Password dan Hak Akses Salah", "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            t1.Focus()
        End If
        rd.Close()
        cmd.Dispose()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            t33.UseSystemPasswordChar = True
        Else
            t33.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        koneksi_oke()
    End Sub
End Class