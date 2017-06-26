Public Class ReadForm

    Private Sub pathTextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'pathTextBox_Click Goes to here, too
    Private Sub pathButton_Click(ByVal seender As System.Object, ByVal e As System.EventArgs) Handles pathButton.Click, pathTextBox.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.Filter = Ezfx.Csv.CsvContext.DialogFilter
        If DialogResult.OK = ofd.ShowDialog() Then
            'Set a break point here to view the CSV objects
            mainDataGridView.DataSource = Ezfx.Csv.CsvContext.ReadFile(Of LanguagePopularity)(ofd.FileName)
        End If
    End Sub
End Class
