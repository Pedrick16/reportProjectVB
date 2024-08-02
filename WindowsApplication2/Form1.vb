Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reportPath As String = System.IO.Path.Combine(Application.StartupPath, "Sales Orders.rdl")

        ' Set up the ReportViewer control.
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = reportPath

        ' Define the data source
        Dim dataSource1 As New ReportDataSource("DataSet1", GetData())


        ' Clear existing data sources (optional, depending on your needs)
        ReportViewer1.LocalReport.DataSources.Clear()


        ' Add the new data source
        ReportViewer1.LocalReport.DataSources.Add(dataSource1)




        Dim reportParameters As New List(Of ReportParameter)()

        ' Add parameters to the list. Replace "ParameterName" with the actual name of the parameter
        ' defined in your report, and provide the value you want to pass.
        reportParameters.Add(New ReportParameter("site", "PI-SP"))
        reportParameters.Add(New ReportParameter("empnum", "123"))

        ' Set the parameters to the report.
        ReportViewer1.LocalReport.SetParameters(reportParameters)


        ' Refresh the ReportViewer control to display the report.
        ReportViewer1.RefreshReport()
    End Sub


    Private Function GetData() As DataTable
        Dim connectionString As String = "Data Source = erp-svr;Initial Catalog=Pallet_Tagging;User ID=sa;Password=pi_dc_2011"
        Dim query As String = "SELECT * FROM Employee"
        Dim dataTable As New DataTable()



        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to the SQL command

                    Dim adapter As New SqlDataAdapter(command)

                    ' Fill the DataTable with data from the database
                    adapter.Fill(dataTable)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                connection.Close()
            End Try

        End Using

        Return dataTable
    End Function
End Class
