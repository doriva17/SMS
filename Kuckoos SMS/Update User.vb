Imports System.Data.OleDb
Public Class Update_User

    Private Sub Update_User_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Update_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ComboBox2.ResetText()
        TextBox1.Clear()
        TextBox2.Clear()
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
            ComboBox2.SelectedItem = ds.Tables("Users").Rows(i)(3).ToString
        Next
        'cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cn.Open()
        Dim er As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox2.Text = "" Or ComboBox1.Text = "" Then
            er = 1
            MsgBox("Please Fill All The Detail's.")
        End If
        'insert
        If er = 0 Then
            Try
                cmd.Connection = cn
                cmd.CommandText = "Update Users set UName = '" & TextBox1.Text & "',Pass = '" & TextBox2.Text & "', UType = '" & ComboBox2.Text & "' where UID = '" & ComboBox1.Text & "'"
                cmd.ExecuteNonQuery()

                MsgBox("User Details Updated.")

            Catch ex As Exception
                MsgBox(" User Not Updated.")
                TextBox1.Clear()
                TextBox2.Clear()
                ComboBox2.ResetText()
            End Try
            'insert closed
        End If
        'cn.Close()
    End Sub
End Class