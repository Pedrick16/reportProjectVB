Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reportform As New Form2


        reportform.SiteValue = TXTSite.Text
        reportform.EmpValue = TXTEmp.Text

        reportform.Show()


    End Sub




End Class
