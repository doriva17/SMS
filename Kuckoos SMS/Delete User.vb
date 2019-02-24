Imports System.Data.OleDb
Public Class Delete_User

    Private Sub Delete_User_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Delete_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()

        Dim ctr As Integer
        'cn.Open()
        str = "select * from Users"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Users")
        ctr = ds.Tables("Users").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Users").Rows(i)(0).ToString)
        Next
        'cn.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox2.Clear()
        TextBox1.Clear()
        TextBox3.Clear()
        Dim ctr As Integer
        'cn.Open()
        str = "select * from Users"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Users")
        ctr = ds.Tables("Users").Rows.Count - 1
        For i = 0 To ctr
            TextBox1.Text = ds.Tables("Users").Rows(i)(1).ToString
            TextBox2.Text = ds.Tables("Users").Rows(i)(2).ToString
            TextBox3.Text = ds.Tables("Users").Rows(i)(3).ToString
        Next
        'cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cn.Open()
        Dim er As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            er = 1
            MsgBox("Please Fill All The Detail's.")
        End If
        'insert

        Dim msg As Integer
        msg = MsgBox("Do You Really Want To Delete User :- '" & TextBox1.Text & "' ?", MsgBoxStyle.YesNoCancel, "Delete User ?")
        If msg = DialogResult.Yes Then
            Try

                cmd.Connection = cn
                cmd.CommandText = "Delete from Users where UID='" & ComboBox1.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("User Deleted.")
                TextBox2.Clear()
                TextBox1.Clear()
                TextBox3.Clear()
                ComboBox1.Items.Clear()

                Dim ctr As Integer
                'cn.Open()
                str = "select * from Users"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Users")
                ctr = ds.Tables("Users").Rows.Count - 1
                For i = 0 To ctr
                    ComboBox1.Items.Add(ds.Tables("Users").Rows(i)(0).ToString)
                Next
            Catch ex As Exception
                MsgBox(" User Not Deleted.")
            End Try
        End If
        'cn.Close()
    End Sub


End Class