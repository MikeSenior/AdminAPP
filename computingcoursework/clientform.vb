Public Class clientform
    Public cellvalue As String
    Private Sub FlatClose1_Click(sender As System.Object, e As System.EventArgs) Handles FlatClose1.Click
        Me.Close()
    End Sub
    Private Sub clientform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FlatTextBox1.Text = cellvalue
        Try
            Dim Conn As New sqltryclass
            With Conn
                .Server = "localhost"
                .Password = ""
                .User = "root"
                .Database = "adminapp"
            End With
            If sqltryclass.clientload(Conn) = True Then

            Else
            End If
        Catch
        End Try
    End Sub
End Class