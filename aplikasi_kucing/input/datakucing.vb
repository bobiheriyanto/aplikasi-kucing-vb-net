Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.Odbc
Imports MySql.Data
Imports System.Data.SqlClient

Public Class datakucing
    Private conn As New MySqlClient.MySqlConnection
    Private strSql As String = String.Empty
    Private PathFile As String = Nothing
    Dim SQL As String
    Public Cn As New MySql.Data.MySqlClient.MySqlConnection
    Public CMD As MySqlCommand
    Dim tulisan(0) As String
    Dim i, j As Integer

    Public Sub New()
        InitializeComponent()
        Dim strConn As String = "server=127.0.0.1;uid=root;database=dbkucing"
        conn.ConnectionString = strConn
        conn.Open()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            strSql = "Insert into tbkucing(id_kucing,jenis,warna,tgl_lahir,jenis_kel,harga,jumlah,Gambar) VALUES(@1,@3,@4,@5,@6,@7,@8,@picture)"
            Using cmd As New MySqlClient.MySqlCommand(strSql, conn)
                With cmd
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", (t1.Text))
                    .Parameters.AddWithValue("@3", (t3.Text))
                    .Parameters.AddWithValue("@4", (t4.Text))
                    .Parameters.AddWithValue("@5", Format(vtanggal.Value, "yyyy/MM/dd"))
                    .Parameters.AddWithValue("@6", (t5.Text))
                    .Parameters.AddWithValue("@7", (t6.Text))
                    .Parameters.AddWithValue("@8", (t7.Text))
                    .Parameters.AddWithValue("@picture", IO.File.ReadAllBytes(OpenFileDialog1.FileName))
                    .ExecuteNonQuery()
                    da = New MySqlDataAdapter("select * from tbkucing", conn)
                    ds = New DataSet
                    ds.Clear()
                    da.Fill(ds, "tbkucing")
                    tblkucing.DataSource = (ds.Tables("tbkucing"))
                    t1.Text = ""
                    t3.Text = ""
                    t4.Text = ""
                    t5.Text = ""
                    t6.Text = ""
                    t7.Text = ""
                End With
            End Using
            MessageBox.Show("Data sudah disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        PictureBox1.Image = Nothing
    End Sub

    Private Sub datakucing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        koneksi_oke()
        da = New MySqlDataAdapter("select * from tbkucing", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbkucing")
        tblkucing.DataSource = (ds.Tables("tbkucing"))
        Me.Text = "BIMO"
        Timer1.Enabled = True
        tulisan(0) = " INPUT DATA KUCING "
        Label11.Text = tulisan(j)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If i.Equals(tulisan(j).Length) Then
            Me.Label11.Text = ""
            If j < tulisan.Length - 1 Then
                j = j + 1
                Me.Label11.Text = tulisan(j)
            Else
                j = 0
            End If
            i = 0
        End If
        Label11.Text = tulisan(j).Substring(0, i)
        i = i + 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
            Button1.Enabled = True
            PathFile = OpenFileDialog1.FileName
            t8.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)

        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            SQL = "update tbkucing set jenis='" & t3.Text &
                "', warna='" & t4.Text &
                 "', jenis_kel='" & t5.Text &
                  "', harga='" & t6.Text &
                   "', jumlah='" & t7.Text &
                "' where id_kucing='" & t1.Text & "'"
            Dim cmd As New MySqlCommand(SQL, conn)
            cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter("select * from tbkucing", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "tbkucing")
            tblkucing.DataSource = (ds.Tables("tbkucing"))
            t1.Text = ""
            t3.Text = ""
            t4.Text = ""
            t5.Text = ""
            t6.Text = ""
            t7.Text = ""
            PictureBox1.Image = Nothing
            MsgBox("Data Telah Di Edit")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tblkucing_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tblkucing.CellContentClick
        t1.Text = tblkucing.Rows(e.RowIndex).Cells(0).Value
        t3.Text = tblkucing.Rows(e.RowIndex).Cells(1).Value
        t4.Text = tblkucing.Rows(e.RowIndex).Cells(2).Value
        t5.Text = tblkucing.Rows(e.RowIndex).Cells(4).Value
        t6.Text = tblkucing.Rows(e.RowIndex).Cells(5).Value
        t7.Text = tblkucing.Rows(e.RowIndex).Cells(6).Value
        Dim c As New IO.MemoryStream(CType(tblkucing.Item(7, tblkucing.CurrentRow.Index).Value, Byte()))
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = Image.FromStream(c)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If t1.Text = "" Then
            MsgBox("Pengisian Data Belum Lengkap")
            Exit Sub
        Else
            Dim sql As String = "delete from tbkucing where id_kucing='" & t1.Text & "'"
            CMD = New MySqlCommand(sql, conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data Telah Di Hapus")
            da = New MySqlDataAdapter("select * from tbkucing", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "tbkucing")
            tblkucing.DataSource = (ds.Tables("tbkucing"))
            t1.Text = ""
            t3.Text = ""
            t4.Text = ""
            t5.Text = ""
            t6.Text = ""
            t7.Text = ""
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        t1.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        PictureBox1.Image = Nothing
        t1.Focus()
    End Sub
End Class