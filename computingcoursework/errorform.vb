Public Class errorform

    Private Sub FlatAlertBox1_Click(sender As System.Object, e As System.EventArgs) Handles FlatAlertBox1.Click
        Me.Hide()
    End Sub

    Private Sub errorform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FlatAlertBox1.Visible = True
    End Sub

    Private Sub FormSkin1_Click(sender As System.Object, e As System.EventArgs) Handles FormSkin1.Click

    End Sub

End Class