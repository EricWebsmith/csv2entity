namespace LanguageConfigSample
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.csvConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.okeyButton = new System.Windows.Forms.Button();
            this.changedLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OrdinalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AliasColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.encodingComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.changedPropertyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.csvConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.csvConfigBindingSource, "HasHeader", true));
            this.checkBox1.Location = new System.Drawing.Point(139, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Has Header";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // csvConfigBindingSource
            // 
            this.csvConfigBindingSource.DataSource = typeof(Ezfx.Csv.CsvConfig);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.csvConfigBindingSource, "IsCustomized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(258, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(83, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Use Custom";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // okeyButton
            // 
            this.okeyButton.Location = new System.Drawing.Point(282, 447);
            this.okeyButton.Name = "okeyButton";
            this.okeyButton.Size = new System.Drawing.Size(75, 23);
            this.okeyButton.TabIndex = 2;
            this.okeyButton.Text = "Okey";
            this.okeyButton.UseVisualStyleBackColor = true;
            this.okeyButton.Click += new System.EventHandler(this.okeyButton_Click);
            // 
            // changedLabel
            // 
            this.changedLabel.AutoSize = true;
            this.changedLabel.Location = new System.Drawing.Point(9, 457);
            this.changedLabel.Name = "changedLabel";
            this.changedLabel.Size = new System.Drawing.Size(50, 13);
            this.changedLabel.TabIndex = 3;
            this.changedLabel.Text = "Changed";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.csvConfigBindingSource, "MappingType", true));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Title",
            "Order"});
            this.comboBox1.Location = new System.Drawing.Point(70, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdinalColumn,
            this.nameDataGridViewTextBoxColumn,
            this.AliasColumn});
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.csvConfigBindingSource, "IsCustomized", true));
            this.dataGridView1.DataSource = this.columnsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(470, 378);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // OrdinalColumn
            // 
            this.OrdinalColumn.DataPropertyName = "Ordinal";
            this.OrdinalColumn.HeaderText = "Ordinal";
            this.OrdinalColumn.Name = "OrdinalColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // AliasColumn
            // 
            this.AliasColumn.DataPropertyName = "Alias";
            this.AliasColumn.HeaderText = "Alias";
            this.AliasColumn.Name = "AliasColumn";
            this.AliasColumn.ToolTipText = "Use Comma as the seperater";
            // 
            // columnsBindingSource
            // 
            this.columnsBindingSource.DataMember = "Columns";
            this.columnsBindingSource.DataSource = this.csvConfigBindingSource;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mapping:";
            // 
            // encodingComboBox
            // 
            this.encodingComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.csvConfigBindingSource, "EncodingName", true));
            this.encodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingComboBox.FormattingEnabled = true;
            this.encodingComboBox.Location = new System.Drawing.Point(258, 10);
            this.encodingComboBox.Name = "encodingComboBox";
            this.encodingComboBox.Size = new System.Drawing.Size(224, 21);
            this.encodingComboBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Encoding:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(385, 447);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // changedPropertyLabel
            // 
            this.changedPropertyLabel.AutoSize = true;
            this.changedPropertyLabel.Location = new System.Drawing.Point(65, 457);
            this.changedPropertyLabel.Name = "changedPropertyLabel";
            this.changedPropertyLabel.Size = new System.Drawing.Size(0, 13);
            this.changedPropertyLabel.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Delimiter:";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.csvConfigBindingSource, "Delimiter", true));
            this.textBox1.Location = new System.Drawing.Point(70, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(30, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = ",";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 482);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.changedPropertyLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.encodingComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.changedLabel);
            this.Controls.Add(this.okeyButton);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.csvConfigBindingSource, "Name", true));
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.csvConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource csvConfigBindingSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button okeyButton;
        private System.Windows.Forms.Label changedLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox encodingComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.BindingSource columnsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AliasColumn;
        private System.Windows.Forms.Label changedPropertyLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

