Imports MySql.Data.MySqlClient
Public Class sql
    Dim MysqlConn As New MySqlConnection
    Dim sql As MySqlCommand
    Public Sub loading()
        Dim reader As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
             sql = New MySqlCommand(Query, MysqlConn)
            reader = sql.ExecuteReader

            Dim count As Integer
            count = 0
            While reader.Read
                count = count + 1
            End While
            If count = 1 Then
                sqlloading.Show()
            ElseIf count > 1 Then
                errorform.FlatAlertBox1.Text = "Username and password are duplicate"
                errorform.Show()
            Else
                errorform.FlatAlertBox1.Text = "Wrong username or password"
                errorform.Show()
            End If
            MysqlConn.Close()
        Catch ex As MySqlException
            errorform.FlatAlertBox1.Text = ex.Message
            errorform.Show()
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub
End Class
