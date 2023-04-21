Imports System.IO
Public Class Form1
    Dim Num1, Num2, Num3, Num4, num5 As Integer
    Dim Path1 As String
    Dim Data() As Byte
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog Then
            Path1 = OpenFileDialog1.FileName
            Data = File.ReadAllBytes(Path1)
            Data(&H3BFE) = &HFF
            Data(&H3BFF) = &HFF
            For n As Integer = 0 To &H3FFF
                Num1 = data(n * 2)
                Num2 = data(1 + (n * 2))
                Num3 = Num3 + ((Num2 * 256) + Num1)
            Next
            Num4 = Num3 And &HFFFF
            If (Num4 >= &H87A6) Then num5 = &HFFFF - (Num4 - &H87A6) Else num5 = &HFFFF + ((&H87A6 - Num4) And &HFFFF)
            data(&H3BFE) = num5 And &HFF
            data(&H3BFF) = num5 >> 8 And &HFF
            File.WriteAllBytes(Path1, Data)
        End If
    End Sub
End Class
