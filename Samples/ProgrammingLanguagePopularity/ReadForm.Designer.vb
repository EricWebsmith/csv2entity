<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadForm
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
        Me.mainDataGridView = New System.Windows.Forms.DataGridView()
        Me.pathTextBox = New System.Windows.Forms.TextBox()
        Me.pathButton = New System.Windows.Forms.Button()
        CType(Me.mainDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainDataGridView
        '
        Me.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mainDataGridView.Location = New System.Drawing.Point(12, 39)
        Me.mainDataGridView.Name = "mainDataGridView"
        Me.mainDataGridView.Size = New System.Drawing.Size(401, 397)
        Me.mainDataGridView.TabIndex = 0
        '
        'pathTextBox
        '
        Me.pathTextBox.Location = New System.Drawing.Point(12, 12)
        Me.pathTextBox.Name = "pathTextBox"
        Me.pathTextBox.ReadOnly = True
        Me.pathTextBox.Size = New System.Drawing.Size(366, 20)
        Me.pathTextBox.TabIndex = 1
        '
        'pathButton
        '
        Me.pathButton.Location = New System.Drawing.Point(384, 10)
        Me.pathButton.Name = "pathButton"
        Me.pathButton.Size = New System.Drawing.Size(29, 23)
        Me.pathButton.TabIndex = 2
        Me.pathButton.Text = "..."
        Me.pathButton.UseVisualStyleBackColor = True
        '
        'ReadForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 448)
        Me.Controls.Add(Me.pathButton)
        Me.Controls.Add(Me.pathTextBox)
        Me.Controls.Add(Me.mainDataGridView)
        Me.Name = "ReadForm"
        Me.Text = "Language Popularity of Nov 2011"
        CType(Me.mainDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents pathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pathButton As System.Windows.Forms.Button

End Class
