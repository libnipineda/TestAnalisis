Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    'Declaracion de variables
    Dim cod As Int64
    Dim desc As String
    Dim fecha As Date
    Dim status As String
    Dim origen As String
    Dim busqueda As Int64

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

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Verificar que no este vacio el campo de busqueda
        If Len(Trim(TextBox4.Text)) = 0 Then
            MessageBox.Show("No es posible realizar la busqueda el campo codigo de activo esta vacio, favor llenar campo.", "Informacion")
        End If

        ' Asignar el TextBox a la variable busqueda
        busqueda = CULng(TextBox4.Text)

        ' Configurar solicitud GET y envio del parametro
        Dim request As WebRequest = WebRequest.Create("http://localhost:3000/api/data" & busqueda)
        request.Method = "GET"
        request.ContentType = "application/json"

        Try
            ' Obtener respuesta del server
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

            ' Leer la respuesta
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseServer As String = reader.ReadToEnd()

            ' Deserealizar el JSON a objeto Data
            Dim item As Data = JsonConvert.DeserializeObject(Of Data)(responseServer)

            ' Mostrar estatus en un label
            Label7.Text = item.estatus

            ' Cerrar los streams y respuesta
            reader.Close()
            dataStream.Close()
            response.Close()

        Catch ex As Exception

            ' Manejar error si no encuentra el dato
            If ex.HResult = HttpStatusCode.NotFound Then
                MessageBox.Show("Dato no encontrado!!", "Advertencia")
            Else
                MessageBox.Show("Error: " & ex.Message, "Advertencia")
            End If

        End Try

    End Sub

End Class
