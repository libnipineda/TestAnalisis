Imports System.Runtime.CompilerServices

Public Class Form1

    Dim cod As Integer
    Dim desc As String
    Dim fecha As Date
    Dim status As String
    Dim origen As String

    Public Sub VerificarDatos()
        If Len(Trim(TextBox1.Text)) = 0 Then
            MessageBox.Show("Campo codigo de activo esta vacio, favor llenar campo.", "Informacion")
        End If

        If Len((RichTextBox1.Text)) = 0 Then
            MessageBox.Show("Campo descripción esta vacio, favor llenar campo.", "Información")
        End If

        If Len(Trim(TextBox2.Text)) = 0 Then
            MessageBox.Show("Campo codigo de activo esta vacio, favor llenar campo.", "Informacion")
        End If

        If Len(Trim(TextBox3.Text)) = 0 Then
            MessageBox.Show("Campo codigo de activo esta vacio, favor llenar campo.", "Informacion")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        VerificarDatos()

    End Sub
End Class
