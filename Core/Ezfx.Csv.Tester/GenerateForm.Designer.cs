namespace Ezfx.Csv
{
    partial class GenerateForm
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
            this.cvsPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cvsPathButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.namespaceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cvsPathTextBox
            // 
            this.cvsPathTextBox.Location = new System.Drawing.Point(89, 10);
            this.cvsPathTextBox.Name = "cvsPathTextBox";
            this.cvsPathTextBox.Size = new System.Drawing.Size(343, 20);
            this.cvsPathTextBox.TabIndex = 0;
            this.cvsPathTextBox.Text = "CSV Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CSV:";
            // 
            // cvsPathButton
            // 
            this.cvsPathButton.Location = new System.Drawing.Point(438, 8);
            this.cvsPathButton.Name = "cvsPathButton";
            this.cvsPathButton.Size = new System.Drawing.Size(75, 23);
            this.cvsPathButton.TabIndex = 2;
            this.cvsPathButton.Text = "Browse...";
            this.cvsPathButton.UseVisualStyleBackColor = true;
            this.cvsPathButton.Click += new System.EventHandler(this.cvsPathButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(147, 512);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // namespaceTextBox
            // 
            this.namespaceTextBox.Location = new System.Drawing.Point(89, 36);
            this.namespaceTextBox.Name = "namespaceTextBox";
            this.namespaceTextBox.Size = new System.Drawing.Size(343, 20);
            this.namespaceTextBox.TabIndex = 4;
            this.namespaceTextBox.Text = "Ezfx.Entities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Namespace:";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(16, 62);
            this.codeTextBox.Multiline = true;
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeTextBox.Size = new System.Drawing.Size(497, 444);
            this.codeTextBox.TabIndex = 6;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(294, 512);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 7;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(375, 512);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 8;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 547);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.namespaceTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.cvsPathButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cvsPathTextBox);
            this.Name = "MainForm";
            this.Text = "CSV Entity Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cvsPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cvsPathButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox namespaceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button readButton;
    }
}

