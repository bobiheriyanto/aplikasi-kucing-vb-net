Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.Odbc
Imports MySql.Data
Imports System.Data.SqlClient

Public Class datapenitipan

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
            t11.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)

        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            strSql = "Insert into tbpenitipan(kd_penitipan,nm_penitip,id_kucing,umur,tgl_penitipan,tgl_pengambilan,lama_penitipan,jumlah,harga_penitipan,bayar,foto) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@picture)"
            Using cmd As New MySqlClient.MySqlCommand(strSql, conn)
                With cmd
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@1", (t1.Text))
                    .Parameters.AddWithValue("@2", (t2.Text))
                    .Parameters.AddWithValue("@3", (t3.Text))
                    .Parameters.AddWithValue("@4", (t4.Text))
                    .Parameters.AddWithValue("@5", Format(DateTimePicker1.Value, "yyyy/MM/dd"))
                    .Parameters.AddWithValue("@6", Format(DateTimePicker2.Value, "yyyy/MM/dd"))
                    .Parameters.AddWithValue("@7", (txhari.Text))
                    .Parameters.AddWithValue("@8", (t8.Text))
                    .Parameters.AddWithValue("@9", (t9.Text))
                    .Parameters.AddWithValue("@10", (t10.Text))
                    .Parameters.AddWithValue("@picture", IO.File.ReadAllBytes(OpenFileDialog1.FileName))
                    .ExecuteNonQuery()
                    da = New MySqlDataAdapter("select * from tbpenitipan", conn)
                    ds = New DataSet
                    ds.Clear()
                    da.Fill(ds, "tbpenitipan")
                    tblpenitipan.DataSource = (ds.Tables("tbpenitipan"))
                    t1.Text = ""
                    t2.Text = ""
                    t3.Text = ""
                    t4.Text = ""


                    txhari.Text = ""
                    t8.Text = ""
                    t9.Text = ""
                    t10.Text = ""
                End With
            End Using
            MessageBox.Show("Data sudah disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        PictureBox1.Image = Nothing
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            SQL = "update tbpenitipan set nm_penitip='" & t2.Text &
                "', id_kucing='" & t3.Text &
                "', umur='" & t4.Text &
                 "', lama_penitipan='" & txhari.Text &
                 "', jumlah='" & t8.Text &
                   "', harga_penitipan='" & t9.Text &
                   "', bayar='" & t10.Text &
                "' where kd_penitipan='" & t1.Text & "'"
            Dim cmd As New MySqlCommand(SQL, conn)
            cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter("select * from tbpenitipan", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "tbpenitipan")
            tblpenitipan.DataSource = (ds.Tables("tbpenitipan"))
            t1.Text = ""
            t2.Text = ""
            t3.Text = ""
            t4.Text = ""
            txhari.Text = ""
            t8.Text = ""
            t9.Text = ""
            t10.Text = ""
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
            Dim sql As String = "delete from tbpenitipan where kd_penitipan='" & t1.Text & "'"
            CMD = New MySqlCommand(sql, conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data Telah Di Hapus")
            da = New MySqlDataAdapter("select * from tbpenitipan", conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "tbpenitipan")
            tblpenitipan.DataSource = (ds.Tables("tbpenitipan"))
            t1.Text = ""
            t2.Text = ""
            t3.Text = ""
            t4.Text = ""
            txhari.Text = ""
            t8.Text = ""
            t9.Text = ""
            t10.Text = ""
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        txhari.Text = ""
        t8.Text = ""
        t9.Text = ""
        t10.Text = ""
    End Sub

    Private Sub tblpenitipan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tblpenitipan.CellContentClick
        t1.Text = tblpenitipan.Rows(e.RowIndex).Cells(0).Value
        t2.Text = tblpenitipan.Rows(e.RowIndex).Cells(1).Value
        t3.Text = tblpenitipan.Rows(e.RowIndex).Cells(2).Value
        t4.Text = tblpenitipan.Rows(e.RowIndex).Cells(3).Value
        txhari.Text = tblpenitipan.Rows(e.RowIndex).Cells(6).Value
        t8.Text = tblpenitipan.Rows(e.RowIndex).Cells(7).Value
        t9.Text = tblpenitipan.Rows(e.RowIndex).Cells(8).Value
        t10.Text = tblpenitipan.Rows(e.RowIndex).Cells(9).Value
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

    Private Sub datapenitipan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        koneksi_oke()
        da = New MySqlDataAdapter("select * from tbpenitipan", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbpenitipan")
        tblpenitipan.DataSource = (ds.Tables("tbpenitipan"))
        
        Me.Text = "BIMO"
        Timer1.Enabled = True
        tulisan(0) = " INPUT DATA PENITIPAN "
        Label11.Text = tulisan(j)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        t10.Text = Val(t9.Text) * Val(t8.Text)
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        t10.Text = Val(t9.Text) * Val(t8.Text)
    End Sub

    Private Sub DateTimePicker1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            DateTimePicker1.Value = DateTimePicker2.Value
        Else
            
            txhari.Text = DateDiff(DateInterval.Day, CDate(DateTimePicker1.Text), CDate(DateTimePicker2.Text))
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker2.Value < DateTimePicker1.Value Then
            DateTimePicker2.Value = DateTimePicker1.Value
        Else
           
            txhari.Text = DateDiff(DateInterval.Day, CDate(DateTimePicker1.Text), CDate(DateTimePicker2.Text))
        End If
    End Sub
End Class