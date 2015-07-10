Imports MySql.Data.MySqlClient
Imports System.Threading
Public Class sqlloading
    Dim MysqlConn As New MySqlConnection
    Private Sub sqlloading_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        sqltest()
    End Sub
    Private Sub sqltest()
        FlatProgressBar1.Value = 20
        Try
            Dim Conn As New sqltryclass
            With Conn
                .Server = "localhost"
                .Password = ""
                .User = "root"
                .Database = "customers"
            End With
            If sqltryclass.TryConn(Conn) = True Then
                FlatProgressBar1.Value = 100
                Me.Hide()
            Else
                FlatProgressBar1.Value = 0
                MessageBox.Show("There was an error communicating with the SQL server")
            End If
        Catch
        End Try
    End Sub
    Private Sub FlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles FlatButton1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub FormSkin1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormSkin1.Click

    End Sub
End Class
