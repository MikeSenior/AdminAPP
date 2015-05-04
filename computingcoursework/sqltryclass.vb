Imports MySql.Data.MySqlClient
Imports System.Threading
Public Class sqltryclass
    Private serverhost As String
    Private db As String
    Private userid As String
    Private pwd As String
    Private Shared cn As New MySqlConnection

    Public Property Server As String
        Get
            Return serverhost
        End Get
        Set(ByVal value As String)
            serverhost = value
        End Set
    End Property
    Public Property Database As String
        Get
            Return db
        End Get
        Set(ByVal value As String)
            db = value
        End Set
    End Property
    Public Property User As String
        Get
            Return userid
        End Get
        Set(ByVal value As String)
            userid = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return pwd
        End Get
        Set(ByVal value As String)
            pwd = value
        End Set
    End Property
    Private Shared ReadOnly Property Conn As MySqlConnection
        Get
            Return cn
        End Get
    End Property

    Public Shared Function TryConn(ByVal obj As sqltryclass) As Boolean
        Try
            Dim connectionstring As String =
            "server=" & obj.Server &
            ";database=" & obj.Database &
            ";user id=" & obj.User &
            ";password=" & obj.Password
            cn = New MySqlConnection
            cn.ConnectionString = connectionstring
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            Return True
            cn.ConnectionString = ""
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function TryLogin(ByVal obj As sqltryclass) As Boolean
        Try
            Dim connectionstring As String =
            "server=" & obj.Server &
            ";database=" & obj.Database &
            ";user id=" & obj.User &
            ";password=" & obj.Password
            cn = New MySqlConnection
            cn.ConnectionString = connectionstring
            If cn.State = ConnectionState.Closed Then
                cn.Open()
                Dim Query As String
                Dim sql As MySqlCommand
                Dim reader As MySqlDataReader
                Query = String.Format("SELECT * FROM users WHERE Username = '{0}' AND Password = '{1}'", LoginForm1.UsernameTextBox.Text.Trim(), LoginForm1.PasswordTextBox.Text.Trim())
                sql = New MySqlCommand(Query, Conn)
                reader = sql.ExecuteReader
                Dim count As Integer
                count = 0
                While reader.Read
                    count = count + 1
                End While
                If count = 1 Then
                    sqlloading.Show()
                    Return True
                ElseIf count > 1 Then
                    errorform.FlatAlertBox1.Text = "Username and password are duplicate"
                    errorform.Show()
                Else
                    errorform.FlatAlertBox1.Text = "Wrong username or password"
                    errorform.Show()
                End If
            End If
            Return False
            cn.ConnectionString = ""
        Catch myerror As MySqlException
            MessageBox.Show("Cannot connect to database: " & myerror.Message, _
                            "AdminAPP - Error connecting")
            Return False
        End Try
    End Function
    Public Shared Function MainLoad(ByVal obj As sqltryclass) As Boolean
        Try
            Dim connectionstring As String =
            "server=" & obj.Server &
            ";database=" & obj.Database &
            ";user id=" & obj.User &
            ";password=" & obj.Password
            Dim sql As MySqlCommand
            cn = New MySqlConnection
            cn.ConnectionString = connectionstring
            If cn.State = ConnectionState.Closed Then
                cn.Open()
                'after test, populate client dataform
                Dim ds As DataSet = New DataSet()
                Dim issueds As DataSet = New DataSet()
                Dim archiveds As DataSet = New DataSet()
                Try
                    If Form1.searchquery = "" Then
                        sql = New MySqlCommand("SELECT * FROM users", Conn)
                    Else
                        sql = New MySqlCommand("SELECT * FROM users WHERE username LIKE """ & Form1.searchquery & """", Conn)
                    End If
                    Dim issuesql As MySqlCommand = New MySqlCommand("SELECT * FROM issues", Conn)
                    Dim archivesql As MySqlCommand = New MySqlCommand("SELECT * FROM fixedissues", Conn)
                    Dim DataAdapter1 As MySqlDataAdapter = New MySqlDataAdapter()
                    Dim DataAdapter2 As MySqlDataAdapter = New MySqlDataAdapter()
                    Dim DataAdapter3 As MySqlDataAdapter = New MySqlDataAdapter()

                    DataAdapter1.SelectCommand = sql
                    DataAdapter1.Fill(ds, "user")
                    Form1.DataGridView1.DataSource = ds
                    Form1.DataGridView1.DataMember = "user"

                    DataAdapter2.SelectCommand = issuesql
                    DataAdapter2.Fill(issueds, "user")
                    Form1.DataGridView2.DataSource = issueds
                    Form1.DataGridView2.DataMember = "user"

                    DataAdapter3.SelectCommand = archivesql
                    DataAdapter3.Fill(archiveds, "user")
                    Form1.DataGridView3.DataSource = archiveds
                    Form1.DataGridView3.DataMember = "user"
                    'error handling to stop runtime errors
                    Form1.FlatAlertBox1.Visible = True
                Catch myerror As MySqlException
                    Form1.FlatAlertBox1.kind = FlatAlertBox._Kind.Error
                    Form1.FlatAlertBox1.Text = "Could not connect to SQL Database"
                    Form1.FlatAlertBox1.Visible = True
                End Try
            End If
            Return True
            cn.ConnectionString = ""
        Catch myerror As MySqlException
            MessageBox.Show("Cannot connect to database: " & myerror.Message, _
                "AdminAPP - Error connecting")
            Return False
        End Try
    End Function
    Public Shared Function clientload(ByVal Obj As sqltryclass) As Boolean
        Try
            Dim sql, sql1, sql2, sql3 As MySqlCommand
            Dim connectionstring As String =
            "server=" & Obj.Server &
            ";database=" & Obj.Database &
            ";user id=" & Obj.User &
            ";password=" & Obj.Password
            cn = New MySqlConnection
            cn.ConnectionString = connectionstring
            If cn.State = ConnectionState.Closed Then
                cn.Open()
                sql = New MySqlCommand("SELECT OneLineAddress FROM users WHERE Username='" & Form1.clientchosen & "';", Conn)
                clientform.FlatTextBox2.Text = Convert.ToString(sql.ExecuteScalar())
                sql1 = New MySqlCommand("SELECT TwoLineAddress FROM users WHERE Username='" & Form1.clientchosen & "';", Conn)
                clientform.FlatTextBox3.Text = Convert.ToString(sql1.ExecuteScalar())
                sql2 = New MySqlCommand("SELECT Postcode FROM users WHERE Username='" & Form1.clientchosen & "';", Conn)
                clientform.FlatTextBox4.Text = Convert.ToString(sql2.ExecuteScalar())
                sql3 = New MySqlCommand("SELECT Telephone FROM users WHERE Username='" & Form1.clientchosen & "';", Conn)
                clientform.FlatTextBox5.Text = Convert.ToString(sql3.ExecuteScalar())
                MsgBox(sql2)
            End If
            Return True
            cn.ConnectionString = ""
        Catch myerror As MySqlException
            MessageBox.Show("Cannot connect to database: " & myerror.Message, _
                "AdminAPP - Error connecting")
            Return False
        End Try
    End Function
    Public Shared Function issueload(ByVal Obj As sqltryclass) As Boolean
        Try
            Dim sql, sql1, sql2, sql3 As MySqlCommand
            Dim connectionstring As String =
            "server=" & Obj.Server &
            ";database=" & Obj.Database &
            ";user id=" & Obj.User &
            ";password=" & Obj.Password
            cn = New MySqlConnection
            cn.ConnectionString = connectionstring
            If cn.State = ConnectionState.Closed Then
                cn.Open()
                sql1 = New MySqlCommand("SELECT HoursReq FROM issues WHERE IssueNo='" & Form1.issuechosen & "';", Conn)
                issueform.FlatTextBox2.Text = Convert.ToString(sql1.ExecuteScalar())
                sql2 = New MySqlCommand("SELECT IssueDescription FROM issues WHERE IssueNo='" & Form1.issuechosen & "';", Conn)
                issueform.FlatTextBox3.Text = Convert.ToString(sql2.ExecuteScalar())
                sql3 = New MySqlCommand("SELECT StepsToFix FROM issues WHERE IssueNo='" & Form1.issuechosen & "';", Conn)
                issueform.FlatTextBox4.Text = Convert.ToString(sql3.ExecuteScalar())
                MsgBox(sql2)
            End If
            Return True
            cn.ConnectionString = ""
        Catch myerror As MySqlException
            MessageBox.Show("Cannot connect to database: " & myerror.Message, _
                "AdminAPP - Error connecting")
            Return False
        End Try
    End Function
    Public Shared Function issuesave(ByVal obj As sqltryclass) As Boolean
        Try
            Dim connectionstring As String =
            "server=" & obj.Server &
            ";database=" & obj.Database &
            ";user id=" & obj.User &
            ";password=" & obj.Password
            cn = New MySqlConnection
            cn.ConnectionString = connectionstring
            If cn.State = ConnectionState.Closed Then
                cn.Open()
                Dim sql As MySqlCommand
                sql = New MySqlCommand("UPDATE issues SET StepsToFix='" & issueform.steps & "' WHERE IssueNo='1';", Conn)
                sql.ExecuteNonQuery()
                MsgBox(issueform.steps)
            End If
            Return True
            cn.ConnectionString = ""
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
