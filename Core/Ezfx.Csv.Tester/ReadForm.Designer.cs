namespace Ezfx.Csv.Tester
{
    partial class ReadForm
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
            this.csvDataGridView = new System.Windows.Forms.DataGridView();
            this.byOrderButton = new System.Windows.Forms.Button();
            this.byTitleButton = new System.Windows.Forms.Button();
            this.customButton = new System.Windows.Forms.Button();
            this.cvsPathButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cvsPathTextBox = new System.Windows.Forms.TextBox();
            this.tableTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // csvDataGridView
            // 
            this.csvDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvDataGridView.Location = new System.Drawing.Point(12, 67);
            this.csvDataGridView.Name = "csvDataGridView";
            this.csvDataGridView.Size = new System.Drawing.Size(443, 279);
            this.csvDataGridView.TabIndex = 0;
            // 
            // byOrderButton
            // 
            this.byOrderButton.Location = new System.Drawing.Point(102, 353);
            this.byOrderButton.Name = "byOrderButton";
            this.byOrderButton.Size = new System.Drawing.Size(75, 23);
            this.byOrderButton.TabIndex = 1;
            this.byOrderButton.Text = "System";
            this.byOrderButton.UseVisualStyleBackColor = true;
            this.byOrderButton.Click += new System.EventHandler(this.byOrderButton_Click);
            // 
            // byTitleButton
            // 
            this.byTitleButton.Location = new System.Drawing.Point(183, 353);
            this.byTitleButton.Name = "byTitleButton";
            this.byTitleButton.Size = new System.Drawing.Size(75, 23);
            this.byTitleButton.TabIndex = 2;
            this.byTitleButton.Text = "By Title";
            this.byTitleButton.UseVisualStyleBackColor = true;
            this.byTitleButton.Click += new System.EventHandler(this.byTitleButton_Click);
            // 
            // customButton
            // 
            this.customButton.Location = new System.Drawing.Point(264, 353);
            this.customButton.Name = "customButton";
            this.customButton.Size = new System.Drawing.Size(75, 23);
            this.customButton.TabIndex = 3;
            this.customButton.Text = "By Order";
            this.customButton.UseVisualStyleBackColor = true;
            this.customButton.Click += new System.EventHandler(this.customButton_Click);
            // 
            // cvsPathButton
            // 
            this.cvsPathButton.Location = new System.Drawing.Point(398, 4);
            this.cvsPathButton.Name = "cvsPathButton";
            this.cvsPathButton.Size = new System.Drawing.Size(57, 23);
            this.cvsPathButton.TabIndex = 6;
            this.cvsPathButton.Text = "...";
            this.cvsPathButton.UseVisualStyleBackColor = true;
            this.cvsPathButton.Click += new System.EventHandler(this.cvsPathButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CSV:";
            // 
            // cvsPathTextBox
            // 
            this.cvsPathTextBox.Location = new System.Drawing.Point(49, 6);
            this.cvsPathTextBox.Name = "cvsPathTextBox";
            this.cvsPathTextBox.Size = new System.Drawing.Size(343, 20);
            this.cvsPathTextBox.TabIndex = 4;
            this.cvsPathTextBox.Text = "CSV Path";
            // 
            // tableTextBox
            // 
            this.tableTextBox.Location = new System.Drawing.Point(49, 33);
            this.tableTextBox.Name = "tableTextBox";
            this.tableTextBox.Size = new System.Drawing.Size(100, 20);
            this.tableTextBox.TabIndex = 7;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 383);
            this.Controls.Add(this.tableTextBox);
            this.Controls.Add(this.cvsPathButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cvsPathTextBox);
            this.Controls.Add(this.customButton);
            this.Controls.Add(this.byTitleButton);
            this.Controls.Add(this.byOrderButton);
            this.Controls.Add(this.csvDataGridView);
            this.Name = "ReadForm";
            this.Text = "ReaderForm";
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView csvDataGridView;
        private System.Windows.Forms.Button byOrderButton;
        private System.Windows.Forms.Button byTitleButton;
        private System.Windows.Forms.Button customButton;
        private System.Windows.Forms.Button cvsPathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cvsPathTextBox;
        private System.Windows.Forms.TextBox tableTextBox;
    }
}