namespace Ezfx.Csv.Tester
{
    partial class ReadDataTableForm
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
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.browseButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(12, 41);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(268, 220);
            this.mainDataGridView.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(253, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(27, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 12);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(235, 20);
            this.pathTextBox.TabIndex = 2;
            // 
            // ReadDataTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.mainDataGridView);
            this.Name = "ReadDataTableForm";
            this.Text = "ReadDataTableForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pathTextBox;
    }
}