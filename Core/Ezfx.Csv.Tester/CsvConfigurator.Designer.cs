namespace Ezfx.Csv.Tester
{
    partial class CsvConfigurator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.csvClassComboBox = new System.Windows.Forms.ComboBox();
            this.systemRadioButton = new System.Windows.Forms.RadioButton();
            this.titleRadioButton = new System.Windows.Forms.RadioButton();
            this.orderRadioButton = new System.Windows.Forms.RadioButton();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(4, 94);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(427, 241);
            this.mainDataGridView.TabIndex = 0;
            this.mainDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.mainDataGridView_DataBindingComplete);
            // 
            // csvClassComboBox
            // 
            this.csvClassComboBox.FormattingEnabled = true;
            this.csvClassComboBox.Location = new System.Drawing.Point(3, 3);
            this.csvClassComboBox.Name = "csvClassComboBox";
            this.csvClassComboBox.Size = new System.Drawing.Size(428, 21);
            this.csvClassComboBox.TabIndex = 1;
            this.csvClassComboBox.SelectedIndexChanged += new System.EventHandler(this.csvClassComboBox_SelectedIndexChanged);
            // 
            // systemRadioButton
            // 
            this.systemRadioButton.AutoSize = true;
            this.systemRadioButton.Location = new System.Drawing.Point(4, 31);
            this.systemRadioButton.Name = "systemRadioButton";
            this.systemRadioButton.Size = new System.Drawing.Size(59, 17);
            this.systemRadioButton.TabIndex = 2;
            this.systemRadioButton.TabStop = true;
            this.systemRadioButton.Text = "System";
            this.systemRadioButton.UseVisualStyleBackColor = true;
            this.systemRadioButton.CheckedChanged += new System.EventHandler(this.systemRadioButton_CheckedChanged);
            // 
            // titleRadioButton
            // 
            this.titleRadioButton.AutoSize = true;
            this.titleRadioButton.Location = new System.Drawing.Point(96, 31);
            this.titleRadioButton.Name = "titleRadioButton";
            this.titleRadioButton.Size = new System.Drawing.Size(60, 17);
            this.titleRadioButton.TabIndex = 3;
            this.titleRadioButton.TabStop = true;
            this.titleRadioButton.Text = "By Title";
            this.titleRadioButton.UseVisualStyleBackColor = true;
            this.titleRadioButton.CheckedChanged += new System.EventHandler(this.titleRadioButton_CheckedChanged);
            // 
            // orderRadioButton
            // 
            this.orderRadioButton.AutoSize = true;
            this.orderRadioButton.Location = new System.Drawing.Point(188, 31);
            this.orderRadioButton.Name = "orderRadioButton";
            this.orderRadioButton.Size = new System.Drawing.Size(66, 17);
            this.orderRadioButton.TabIndex = 4;
            this.orderRadioButton.TabStop = true;
            this.orderRadioButton.Text = "By Order";
            this.orderRadioButton.UseVisualStyleBackColor = true;
            this.orderRadioButton.CheckedChanged += new System.EventHandler(this.orderRadioButton_CheckedChanged);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(4, 67);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(387, 20);
            this.pathTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Get Orders from CSV file.";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(397, 64);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(34, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // CsvConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.orderRadioButton);
            this.Controls.Add(this.titleRadioButton);
            this.Controls.Add(this.systemRadioButton);
            this.Controls.Add(this.csvClassComboBox);
            this.Controls.Add(this.mainDataGridView);
            this.Name = "CsvConfigurator";
            this.Size = new System.Drawing.Size(447, 351);
            this.Load += new System.EventHandler(this.CsvConfigurator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ComboBox csvClassComboBox;
        private System.Windows.Forms.RadioButton systemRadioButton;
        private System.Windows.Forms.RadioButton titleRadioButton;
        private System.Windows.Forms.RadioButton orderRadioButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
    }
}
