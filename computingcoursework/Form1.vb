Imports MySql.Data.MySqlClient
Public Class Form1
    Dim cellvalue As String
    Public clientchosen, issuechosen As String
    Dim issuecellvalue As String
    Public searchquery As String = ""

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        sqlsearchquery(searchquery)
    End Sub
    Private Sub FlatAlertBox1_Click(sender As System.Object, e As System.EventArgs) Handles FlatAlertBox1.Click
        FlatTabControl1.Location = New Point(0, 53)
        FlatAlertBox1.Visible = False
    End Sub
    Private Sub Label1_Click_1(sender As System.Object, e As System.EventArgs)
    End Sub
    Private Sub FlatLabel2_Click(sender As System.Object, e As System.EventArgs) Handles FlatLabel2.Click
        Me.Hide()
        LoginForm1.Show()
    End Sub
    Private Sub FlatStickyButton1_Click(sender As System.Object, e As System.EventArgs) Handles FlatStickyButton1.Click
        searchquery = FlatTextBox1.Text
        sqlsearchquery(searchquery)
    End Sub
    Private Sub FlatTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles FlatTextBox1.TextChanged
    End Sub
    Private Sub sqlsearchquery(ByRef searchquery)
              Try
            Dim Conn As New sqltryclass
            With Conn
                .Server = "localhost"
                .Password = ""
                .User = "root"
                .Database = "adminapp"
            End With
            If sqltryclass.MainLoad(Conn) = True Then

            Else
            End If
        Catch
        End Try
    End Sub

    Private Sub PictureBox3_Click_1(sender As System.Object, e As System.EventArgs)
        Dim searchquery = FlatTextBox1.Text
        sqlsearchquery(searchquery)
    End Sub

    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
        End If

        clientchosen = Convert.ToString(DataGridView1.CurrentCell.Value)
        clientform.cellvalue = clientchosen
        clientform.Show()
    End Sub
    Public Sub DataGridView2_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow = DataGridView2.Rows(e.RowIndex)
        End If
        issuechosen = Convert.ToString(DataGridView2.CurrentCell.Value)
        issueform.cellvalue = issuechosen
        issueform.Show()
    End Sub

    Private Sub FlatClose1_Click(sender As System.Object, e As System.EventArgs) Handles FlatClose1.Click
        Me.Close()
    End Sub

    Private Sub FlatLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        generatereport.Show()
    End Sub

    Private Sub FlatStatusBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
End Class
