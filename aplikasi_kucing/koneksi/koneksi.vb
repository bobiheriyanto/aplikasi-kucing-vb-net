Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Module koneksi
    Public conn As MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public str, sql As String
    Public hasil As Integer
    Public database As New MySqlConnection
    Public tampil As New MySql.Data.MySqlClient.MySqlCommand
    Public tampilkan As MySql.Data.MySqlClient.MySqlDataReader
    Public cari As OleDbDataReader
    Public dml As New OleDbCommand

    Public Sub koneksi_oke()
        str = "server=localhost;user=root;database=dbkucing"
        conn = New MySqlConnection(str)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
End Module