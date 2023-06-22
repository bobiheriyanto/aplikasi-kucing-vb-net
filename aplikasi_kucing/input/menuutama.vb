Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.Odbc
Imports MySql.Data
Imports System.Data.SqlClient

Public Class menuutama
    Private conn As New MySqlClient.MySqlConnection
    Private strSql As String = String.Empty
    Private PathFile As String = Nothing
    Dim SQL As String
    Public Cn As New MySql.Data.MySqlClient.MySqlConnection
    Public CMD As MySqlCommand
    Dim tulisan(0) As String
    Dim i, j As Integer
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        laporankucing.Show()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        datakucing.Show()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        databooking.Show()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        datapenitipan.Show()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Me.Close()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        laporanbooking.Show()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        laporanpenitipan.Show()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        laporanbookingbln.Show()
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        laporanbookingthn.Show()
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        laporanpenitipanbln.Show()
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        laporanpenitipanthn.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If i.Equals(tulisan(j).Length) Then
            Me.Label1.Text = ""
            If j < tulisan.Length - 1 Then
                j = j + 1
                Me.Label11.Text = tulisan(j)
            Else
                j = 0
            End If
            i = 0
        End If
        Label1.Text = tulisan(j).Substring(0, i)
        i = i + 1
    End Sub

    Private Sub menuutama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ""
        Timer1.Enabled = True
        tulisan(0) = " SISTEM INFORMASI PEMBOOKINGAN "
        Label1.Text = tulisan(j)
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
End Class