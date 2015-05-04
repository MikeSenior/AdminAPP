Imports MySql.Data.MySqlClient
Public Class LoginForm1

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UsernameTextBox.Text = My.Settings.Username
        PasswordTextBox.Text = My.Settings.Password
        If My.Settings.checked = True Then
            RadioButton1.Checked = True
        End If
    End Sub
    Private Sub FlatStickyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatStickyButton1.Click
        Try
            Dim Conn As New sqltryclass
            With Conn
                .Server = "localhost"
                .Password = ""
                .User = "root"
                .Database = "adminapp"
            End With
            If sqltryclass.TryLogin(Conn) = True Then
                Me.Hide()
                sqlloading.Show()
            Else
            End If
        Catch
        End Try
    End Sub
    Private Sub FlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles FlatButton1.Click
        errorform.FlatAlertBox1.Text = "Please use the website to reset your password"
        errorform.Show()
    End Sub

End Class
