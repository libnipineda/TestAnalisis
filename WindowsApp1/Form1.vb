Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Data
    Public Property codigo As Int64
    Public Property descripcion As String
    Public Property fecha As Date
    Public Property estatus As String
    Public Property origen As String
End Class


Public Class Form1

    'Declaracion de variables
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

        'Asignar los textbox y richtextbox a las variables
        cod = CULng(TextBox1.Text)
        desc = RichTextBox1.Text
        fecha = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        status = TextBox2.Text
        origen = TextBox3.Text

        'Consumir api
        Dim request As WebRequest = WebRequest.Create("http://localhost:3000/api/datos")
        request.Method = "POST"
        request.ContentType = "application/json"

        ' Instancia de la clase data
        Dim data As New Data With {
            .codigo = cod,
            .descripcion = desc,
            .estatus = status,
            .origen = origen
        }

        ' Serializar la instancia a JSON
        Dim postData As String = JsonConvert.SerializeObject(data)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        ' Enviar la solicitud
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        ' Obtener Respuesta del servidor
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseServer As String = reader.ReadToEnd()

        ' Mostrar Respuesta en MessageBox
        MessageBox.Show(responseServer, "Informacion")

        ' Cerrar streams y respuesta
        reader.Close()
        dataStream.Close()
        response.Close()

    End Sub

End Class
