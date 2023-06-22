Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.Odbc
Imports MySql.Data
Imports System.Data.SqlClient

Public Class databooking
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
            Button1.Enabled = True
            PathFile = OpenFileDialog1.FileName
            t10.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)

        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            strSql = "Insert into tbbooking(kd_booking,id_kucing,nm_kucing,nm_pelanggan,tgl_booking,tgl_pengambilan,no_telp,alamat,jumlah,harga,bayar,foto) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@picture)"
            Using cmd As New MySqlClient.MySqlCommand(strSql, conn)
                With cmd
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", (t1.Text))
                    .Parameters.AddWithValue("@2", (t2.Text))
                    .Parameters.AddWithValue("@3", (t3.Text))
                    .Parameters.AddWithValue("@4", (t4.Text))
                    .Parameters.AddWithValue("@5", Format(vtgl1.Value, "yyyy/MM/dd"))
                    .Parameters.AddWithValue("@6", Format(vtgl2.Value, "yyyy/MM/dd"))
                    .Parameters.AddWithValue("@7", (t5.Text))
                    .Parameters.AddWithValue("@8", (t6.Text))
                    .Parameters.AddWithValue("@9", (t7.Text))
                    .Parameters.AddWithValue("@10", (t8.Text))
                    .Parameters.AddWithValue("@11", (t9.Text))
                    .Parameters.AddWithValue("@picture", IO.File.ReadAllBytes(OpenFileDialog1.FileName))
                    .ExecuteNonQuery()
                    da = New MySqlDataAdapter("select * from tbbooking", conn)
                    ds = New DataSet
                    ds.Clear()
                    da.Fill(ds, "tbbooking")
                    tblbooking.DataSource = (ds.Tables("tbbooking"))
                    t1.Text = ""
                    t2.Text = ""
                    t3.Text = ""
                    t4.Text = ""
                    t5.Text = ""
                    t6.Text = ""
                    t7.Text = ""
                    t8.Text = ""
                    t9.Text = ""
                End With
            End Using
            MessageBox.Show("Data sudah disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        PictureBox1.Image = Nothing

        Try
            Call koneksi_oke()
            Dim edit2 As String = "update tbkucing set jumlah= '" & stok_akhir.Text & "' where id_kucing='" & t2.Text & "'"
            Dim cmd As New MySqlCommand(edit2, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
       
    End Sub

    Private Sub databooking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        koneksi_oke()
        da = New MySqlDataAdapter("select * from tbbooking", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbbooking")
        tblbooking.DataSource = (ds.Tables("tbbooking"))
        

        Me.Text = "BIMO"
        Timer1.Enabled = True
        tulisan(0) = " INPUT DATA BOOKING "
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

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            SQL = "update tbbooking set id_kucing='" & t2.Text &
                "', nm_kucing='" & t3.Text &
                "', nm_pelanggan='" & t4.Text &
                 "', no_telp='" & t5.Text &
                  "', alamat='" & t6.Text &
                   "', jumlah='" & t7.Text &
                   "', harga='" & t8.Text &
                   "', bayar='" & t9.Text &
                "' where kd_booking='" & t1.Text & "'"
            Dim cmd As New MySqlCommand(SQL, conn)
            cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter("select * from tbbooking", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "tbbooking")
            tblbooking.DataSource = (ds.Tables("tbbooking"))
            t1.Text = ""
            t2.Text = ""
            t3.Text = ""
            t4.Text = ""
            t5.Text = ""
            t6.Text = ""
            t7.Text = ""
            t8.Text = ""
            t9.Text = ""
            MsgBox("Data Telah Di Edit")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If t1.Text = "" Then
            MsgBox("Pengisian Data Belum Lengkap")
            Exit Sub
        Else
            Dim sql As String = "delete from tbbooking where kd_booking='" & t1.Text & "'"
            CMD = New MySqlCommand(sql, conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data Telah Di Hapus")
            da = New MySqlDataAdapter("select * from tbbooking", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "tbbooking")
            tblbooking.DataSource = (ds.Tables("tbbooking"))
            t1.Text = ""
            t2.Text = ""
            t3.Text = ""
            t4.Text = ""
            t5.Text = ""
            t6.Text = ""
            t7.Text = ""
            t8.Text = ""
            t9.Text = ""
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        t9.Text = ""
        t10.Text = ""
        stok.Text = ""
        stok_akhir.Text = ""
    End Sub

    Private Sub tblbooking_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tblbooking.CellContentClick
        t1.Text = tblbooking.Rows(e.RowIndex).Cells(0).Value
        t2.Text = tblbooking.Rows(e.RowIndex).Cells(1).Value
        t3.Text = tblbooking.Rows(e.RowIndex).Cells(2).Value
        t4.Text = tblbooking.Rows(e.RowIndex).Cells(3).Value
        t5.Text = tblbooking.Rows(e.RowIndex).Cells(6).Value
        t6.Text = tblbooking.Rows(e.RowIndex).Cells(7).Value
        t7.Text = tblbooking.Rows(e.RowIndex).Cells(8).Value
        t8.Text = tblbooking.Rows(e.RowIndex).Cells(9).Value
        t9.Text = tblbooking.Rows(e.RowIndex).Cells(10).Value
        Dim c As New IO.MemoryStream(CType(tblbooking.Item(11, tblbooking.CurrentRow.Index).Value, Byte()))
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = Image.FromStream(c)


        stok.Text = ""
        stok_akhir.Text = ""
    End Sub

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        t9.Text = Val(t8.Text) * Val(t7.Text)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        da = New MySqlDataAdapter("select * from tbkucing", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbkucing")
        tbl.DataSource = (ds.Tables("tbkucing"))
    End Sub

    Private Sub t7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles t7.KeyPress
        If Val(t7.Text) > Val(stok.Text) Then
            MsgBox("Stok Tidak Mencukupi")
            t7.Text = ""
            t7.Focus()
        ElseIf Val(t7.Text) <= Val(stok.Text) Then
            t9.Text = Val(t8.Text) * Val(t7.Text)
            stok_akhir.Text = Val(stok.Text) - Val(t7.Text)
        Else
        End If
    End Sub
    Private Sub tbl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl.CellContentClick
        t2.Text = tbl.Rows(e.RowIndex).Cells(0).Value
        t3.Text = tbl.Rows(e.RowIndex).Cells(1).Value
        stok.Text = tbl.Rows(e.RowIndex).Cells(6).Value
        Dim c As New IO.MemoryStream(CType(tbl.Item(7, tbl.CurrentRow.Index).Value, Byte()))
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = Image.FromStream(c)
        t1.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        t9.Text = ""
       
    End Sub
End Class