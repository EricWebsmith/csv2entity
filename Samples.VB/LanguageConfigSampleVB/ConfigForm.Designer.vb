<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.changedPropertyLabel = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.encodingComboBox = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OrdinalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AliasColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.comboBox1 = New System.Windows.Forms.ComboBox()
        Me.changedLabel = New System.Windows.Forms.Label()
        Me.okeyButton = New System.Windows.Forms.Button()
        Me.checkBox2 = New System.Windows.Forms.CheckBox()
        Me.checkBox1 = New System.Windows.Forms.CheckBox()
        Me.CsvConfigBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.columnsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CsvConfigBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'changedPropertyLabel
        '
        Me.changedPropertyLabel.AutoSize = True
        Me.changedPropertyLabel.Location = New System.Drawing.Point(64, 453)
        Me.changedPropertyLabel.Name = "changedPropertyLabel"
        Me.changedPropertyLabel.Size = New System.Drawing.Size(0, 13)
        Me.changedPropertyLabel.TabIndex = 24
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(384, 443)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 23
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(196, 9)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(55, 13)
        Me.label2.TabIndex = 22
        Me.label2.Text = "Encoding:"
        '
        'encodingComboBox
        '
        Me.encodingComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CsvConfigBindingSource, "EncodingName", True))
        Me.encodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.encodingComboBox.FormattingEnabled = True
        Me.encodingComboBox.Location = New System.Drawing.Point(257, 6)
        Me.encodingComboBox.Name = "encodingComboBox"
        Me.encodingComboBox.Size = New System.Drawing.Size(224, 21)
        Me.encodingComboBox.TabIndex = 21
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 20
        Me.label1.Text = "Mapping:"
        '
        'dataGridView1
        '
        Me.dataGridView1.AutoGenerateColumns = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrdinalColumn, Me.AliasColumn, Me.NameDataGridViewTextBoxColumn})
        Me.dataGridView1.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Me.CsvConfigBindingSource, "IsCustomized", True))
        Me.dataGridView1.DataSource = Me.columnsBindingSource
        Me.dataGridView1.Location = New System.Drawing.Point(11, 56)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(470, 381)
        Me.dataGridView1.TabIndex = 19
        '
        'OrdinalColumn
        '
        Me.OrdinalColumn.DataPropertyName = "Ordinal"
        Me.OrdinalColumn.HeaderText = "Ordinal"
        Me.OrdinalColumn.Name = "OrdinalColumn"
        '
        'AliasColumn
        '
        Me.AliasColumn.DataPropertyName = "Alias"
        Me.AliasColumn.HeaderText = "Alias"
        Me.AliasColumn.Name = "AliasColumn"
        Me.AliasColumn.ToolTipText = "Use Comma as the seperater"
        '
        'columnsBindingSource
        '
        Me.columnsBindingSource.DataMember = "Columns"
        Me.columnsBindingSource.DataSource = Me.CsvConfigBindingSource
        '
        'comboBox1
        '
        Me.comboBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CsvConfigBindingSource, "MappingType", True))
        Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"Title", "Order"})
        Me.comboBox1.Location = New System.Drawing.Point(69, 6)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 21)
        Me.comboBox1.TabIndex = 18
        '
        'changedLabel
        '
        Me.changedLabel.AutoSize = True
        Me.changedLabel.Location = New System.Drawing.Point(8, 453)
        Me.changedLabel.Name = "changedLabel"
        Me.changedLabel.Size = New System.Drawing.Size(50, 13)
        Me.changedLabel.TabIndex = 17
        Me.changedLabel.Text = "Changed"
        '
        'okeyButton
        '
        Me.okeyButton.Location = New System.Drawing.Point(281, 443)
        Me.okeyButton.Name = "okeyButton"
        Me.okeyButton.Size = New System.Drawing.Size(75, 23)
        Me.okeyButton.TabIndex = 16
        Me.okeyButton.Text = "Okey"
        Me.okeyButton.UseVisualStyleBackColor = True
        '
        'checkBox2
        '
        Me.checkBox2.AutoSize = True
        Me.checkBox2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CsvConfigBindingSource, "IsCustomized", True))
        Me.checkBox2.Location = New System.Drawing.Point(107, 33)
        Me.checkBox2.Name = "checkBox2"
        Me.checkBox2.Size = New System.Drawing.Size(83, 17)
        Me.checkBox2.TabIndex = 15
        Me.checkBox2.Text = "Use Custom"
        Me.checkBox2.UseVisualStyleBackColor = True
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CsvConfigBindingSource, "HasHeader", True))
        Me.checkBox1.Location = New System.Drawing.Point(15, 33)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(83, 17)
        Me.checkBox1.TabIndex = 14
        Me.checkBox1.Text = "Has Header"
        Me.checkBox1.UseVisualStyleBackColor = True
        '
        'CsvConfigBindingSource
        '
        Me.CsvConfigBindingSource.DataSource = GetType(Ezfx.Csv.CsvConfig)
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        '
        'ConfigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 473)
        Me.Controls.Add(Me.changedPropertyLabel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.encodingComboBox)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.changedLabel)
        Me.Controls.Add(Me.okeyButton)
        Me.Controls.Add(Me.checkBox2)
        Me.Controls.Add(Me.checkBox1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CsvConfigBindingSource, "ObjectType", True))
        Me.Name = "ConfigForm"
        Me.Text = "Config"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.columnsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CsvConfigBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents changedPropertyLabel As System.Windows.Forms.Label
    Private WithEvents cancelButton As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents encodingComboBox As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents changedLabel As System.Windows.Forms.Label
    Private WithEvents okeyButton As System.Windows.Forms.Button
    Private WithEvents checkBox2 As System.Windows.Forms.CheckBox
    Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CsvConfigBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdinalColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AliasColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents columnsBindingSource As System.Windows.Forms.BindingSource

End Class
