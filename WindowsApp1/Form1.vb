Imports System.Runtime.CompilerServices

Public Class Form1

    Dim cod As Int64
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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        VerificarDatos()

        cod = CULng(TextBox1.Text)
        desc = RichTextBox1.Text
        fecha = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        status = TextBox2.Text
        origen = TextBox3.Text

        Console.WriteLine(cod)
        Console.WriteLine(desc)
        Console.WriteLine(fecha)
        Console.WriteLine(status)
        Console.WriteLine(origen)

        MessageBox.Show("Datos ingresados de forma Correcta", "Informacion")


    End Sub

End Class
