using System;

namespace Tyuiu.Shahab6.Sprint6.Task1.V23
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // buttonDone
            this.buttonDone.Location = new System.Drawing.Point(20, 300);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(100, 30);
            this.buttonDone.Text = "Выполнить";
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);

            // buttonHelp
            this.buttonHelp.Location = new System.Drawing.Point(200, 300);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(100, 30);
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);

            // textBoxResult
            this.textBoxResult.Location = new System.Drawing.Point(20, 20);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(280, 260);
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // FormMain
            this.ClientSize = new System.Drawing.Size(320, 350);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonDone);
            this.Name = "FormMain";
            this.Text = "Спринт 6 | Таск 1 | Вариант 23";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}