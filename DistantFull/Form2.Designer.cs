namespace DistantFull
{
    partial class InpIP
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
            this.ok_b = new System.Windows.Forms.Button();
            this.IPS = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ok_b
            // 
            this.ok_b.Location = new System.Drawing.Point(172, 74);
            this.ok_b.Name = "ok_b";
            this.ok_b.Size = new System.Drawing.Size(75, 30);
            this.ok_b.TabIndex = 0;
            this.ok_b.Text = "Ок";
            this.ok_b.UseVisualStyleBackColor = true;
            this.ok_b.Click += new System.EventHandler(this.ok_b_Click);
            // 
            // IPS
            // 
            this.IPS.Location = new System.Drawing.Point(95, 26);
            this.IPS.Name = "IPS";
            this.IPS.Size = new System.Drawing.Size(213, 28);
            this.IPS.TabIndex = 1;
            this.IPS.Text = "";
            // 
            // InpIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 139);
            this.Controls.Add(this.IPS);
            this.Controls.Add(this.ok_b);
            this.Name = "InpIP";
            this.Text = "Введите IP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ok_b;
        private System.Windows.Forms.RichTextBox IPS;
    }
}