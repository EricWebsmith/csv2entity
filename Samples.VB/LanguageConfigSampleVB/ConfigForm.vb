Imports System.Text
Imports Ezfx.Csv
Imports System.ComponentModel

Public Class ConfigForm

    Dim config As CsvConfig = Nothing
    Public Sub New()
        InitializeComponent()
        LoadEncoding()
        config = New CsvConfig(GetType(LanguagePopularity))
    End Sub

    Private Sub ConfigForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CsvConfigBindingSource.DataSource = Me.config
        dataGridView1.DataSource = config.Columns
        AddHandler config.PropertyChanged, AddressOf config_PropertyChanged
        '   config.PropertyChanged += new PropertyChangedEventHandler(config_PropertyChanged);
    End Sub

    Private Sub LoadEncoding()
        Me.encodingComboBox.Items.Clear()
        For Each enc As EncodingInfo In Encoding.GetEncodings().OrderBy(Function(c) c.DisplayName)
            Me.encodingComboBox.Items.Add(enc.DisplayName)
        Next
    End Sub

    Private Sub config_PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        changedLabel.ForeColor = Color.Red
        changedPropertyLabel.ForeColor = Color.Red
        changedPropertyLabel.Text = e.PropertyName
    End Sub


    Private Sub dataGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellEndEdit
        changedLabel.ForeColor = Color.Red
        config.IsChanged = True
    End Sub

    Private Sub okeyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okeyButton.Click
        Save()
        Me.Close()
    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        If config.IsChanged Then
            Dim dialogResult As DialogResult = MessageBox.Show("Changes have been made, Save?", "", MessageBoxButtons.YesNoCancel, Nothing)
            If dialogResult = dialogResult.Yes Then
                Save()
            ElseIf dialogResult = dialogResult.No Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Save()
        MessageBox.Show("Save method not implement.")
    End Sub

End Class
