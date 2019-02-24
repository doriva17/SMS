Imports System.Data.OleDb
Public Class Add_Class

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Add_Class_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Add_Class_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()

        'cn.Open()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")

        Dim LastNo As Integer
        LastNo = ds.Tables("Class").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "CLS" & LastNo
        Else
            TextBox1.Text = "CLS" & 0
        End If
        'cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cn.Open()
        Dim er As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            er = 1
            MsgBox("Please Fill All The Detail's.")
        End If
        'insert
        If er = 0 Then
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into Class(CID,CName,ClassNo,MaxStudents,Fees) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                cmd.ExecuteNonQuery()
                'MsgBox("New Class Added.")
                Dim result As Integer = MessageBox.Show("New Class Added. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.Close()
                ElseIf result = DialogResult.Yes Then
                    ds.Clear()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()

                    str = "select * from Class"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Class")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Class").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "CLS" & LastNo
                    Else
                        TextBox1.Text = "CLS" & 0
                    End If

                End If
            Catch ex As Exception
                MsgBox(" Class Not Added.")
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
            End Try
            'insert closed
        End If
        'cn.Close()
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub



    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class