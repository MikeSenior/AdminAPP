Public Class issueform
    Public cellvalue As String
    Public steps As String
    Public stepstext As String
    Private Sub FlatClose1_Click(sender As System.Object, e As System.EventArgs) Handles FlatClose1.Click
        Me.Close()
    End Sub

    Private Sub FlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles FlatButton1.Click
        steps = FlatTextBox4.Text
        Try
            Dim Conn As New sqltryclass
            With Conn
                .Server = "localhost"
                .Password = ""
                .User = "root"
                .Database = "adminapp"
            End With
            If sqltryclass.issuesave(Conn) = True Then
            Else
            End If
        Catch
        End Try
    End Sub

    Private Sub issueform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim Conn As New sqltryclass
            With Conn
                .Server = "localhost"
                .Password = ""
                .User = "root"
                .Database = "adminapp"
            End With
            If sqltryclass.issueload(Conn) = True Then
            Else
            End If
        Catch
        End Try
    End Sub
End Class