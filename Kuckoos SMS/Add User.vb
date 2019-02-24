Imports System.Data.OleDb
Public Class Add_User

    Private Sub Add_User_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Add_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()


        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()

        'cn.Open()
        str = "select * from Users"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Users")
        Dim LastNo As Integer
        LastNo = ds.Tables("Users").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "UID" & LastNo
        Else
            TextBox1.Text = "UID" & 0
        End If
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
        If er = 0 Then
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into Users(UID,UName,Pass,UType) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')"
                cmd.ExecuteNonQuery()
                'MsgBox("New Class Added.")
                Dim result As Integer = MessageBox.Show("New User Added. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.Close()
                ElseIf result = DialogResult.Yes Then
                    ds.Clear()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    ComboBox1.ResetText()
                    str = "select * from Users"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Users")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Users").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "UID" & LastNo
                    Else
                        TextBox1.Text = "UID" & 0
                    End If

                End If
            Catch ex As Exception
                MsgBox(" User Not Added.")
                TextBox2.Clear()
                TextBox3.Clear()
                ComboBox1.ResetText()
            End Try
            'insert closed
        End If
        'cn.Close()
    End Sub
End Class