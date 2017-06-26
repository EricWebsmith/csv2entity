namespace Ezfx.Csv.Tester
{
    partial class SettingForm
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
            this.csvConfigurator1 = new Ezfx.Csv.Tester.CsvConfigurator();
            this.SuspendLayout();
            // 
            // csvConfigurator1
            // 
            this.csvConfigurator1.Location = new System.Drawing.Point(38, 33);
            this.csvConfigurator1.Name = "csvConfigurator1";
            this.csvConfigurator1.Size = new System.Drawing.Size(447, 351);
            this.csvConfigurator1.TabIndex = 0;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 396);
            this.Controls.Add(this.csvConfigurator1);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CsvConfigurator csvConfigurator1;

    }
}