namespace DistantFull
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.uname_r = new System.Windows.Forms.RichTextBox();
            this.Create = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.RichTextBox();
            this.view_image = new System.Windows.Forms.PictureBox();
            this.send_t = new System.Windows.Forms.RichTextBox();
            this.send_b = new System.Windows.Forms.Button();
            this.r_id_t = new System.Windows.Forms.RichTextBox();
            this.flag_camera = new System.Windows.Forms.CheckBox();
            this.flag_micro = new System.Windows.Forms.CheckBox();
            this.messages_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.UpFile = new System.Windows.Forms.Button();
            this.UpFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.view_image)).BeginInit();
            this.SuspendLayout();
            // 
            // uname_r
            // 
            this.uname_r.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uname_r.Location = new System.Drawing.Point(551, 250);
            this.uname_r.MaxLength = 20;
            this.uname_r.Multiline = false;
            this.uname_r.Name = "uname_r";
            this.uname_r.Size = new System.Drawing.Size(191, 25);
            this.uname_r.TabIndex = 0;
            this.uname_r.Text = "";
            this.uname_r.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uname_r_KeyDown);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(563, 242);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(160, 36);
            this.Create.TabIndex = 1;
            this.Create.Text = "Создать";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Visible = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(563, 284);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(160, 35);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Подключиться";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Visible = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // id
            // 
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.id.Location = new System.Drawing.Point(551, 281);
            this.id.MaxLength = 6;
            this.id.Multiline = false;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(191, 25);
            this.id.TabIndex = 3;
            this.id.Text = "";
            this.id.Visible = false;
            this.id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_KeyDown);
            // 
            // view_image
            // 
            this.view_image.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.view_image.Location = new System.Drawing.Point(12, 12);
            this.view_image.Name = "view_image";
            this.view_image.Size = new System.Drawing.Size(912, 476);
            this.view_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.view_image.TabIndex = 4;
            this.view_image.TabStop = false;
            this.view_image.Visible = false;
            // 
            // send_t
            // 
            this.send_t.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.send_t.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.send_t.Location = new System.Drawing.Point(12, 494);
            this.send_t.Name = "send_t";
            this.send_t.Size = new System.Drawing.Size(646, 43);
            this.send_t.TabIndex = 5;
            this.send_t.Text = "";
            this.send_t.Visible = false;
            this.send_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.send_t_KeyDown);
            // 
            // send_b
            // 
            this.send_b.Location = new System.Drawing.Point(705, 494);
            this.send_b.Name = "send_b";
            this.send_b.Size = new System.Drawing.Size(219, 43);
            this.send_b.TabIndex = 6;
            this.send_b.Text = "Отправить";
            this.send_b.UseVisualStyleBackColor = true;
            this.send_b.Visible = false;
            this.send_b.Click += new System.EventHandler(this.send_b_Click);
            // 
            // r_id_t
            // 
            this.r_id_t.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.r_id_t.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r_id_t.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.r_id_t.Enabled = false;
            this.r_id_t.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.r_id_t.Location = new System.Drawing.Point(1073, 12);
            this.r_id_t.Multiline = false;
            this.r_id_t.Name = "r_id_t";
            this.r_id_t.Size = new System.Drawing.Size(114, 26);
            this.r_id_t.TabIndex = 7;
            this.r_id_t.Text = "";
            this.r_id_t.Visible = false;
            // 
            // flag_camera
            // 
            this.flag_camera.AutoSize = true;
            this.flag_camera.Location = new System.Drawing.Point(12, 464);
            this.flag_camera.Name = "flag_camera";
            this.flag_camera.Size = new System.Drawing.Size(92, 24);
            this.flag_camera.TabIndex = 8;
            this.flag_camera.Text = "Камера";
            this.flag_camera.UseVisualStyleBackColor = true;
            this.flag_camera.Visible = false;
            this.flag_camera.CheckedChanged += new System.EventHandler(this.flag_camera_CheckedChanged);
            // 
            // flag_micro
            // 
            this.flag_micro.AutoSize = true;
            this.flag_micro.Checked = true;
            this.flag_micro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flag_micro.Location = new System.Drawing.Point(110, 464);
            this.flag_micro.Name = "flag_micro";
            this.flag_micro.Size = new System.Drawing.Size(116, 24);
            this.flag_micro.TabIndex = 9;
            this.flag_micro.Text = "Микрофон";
            this.flag_micro.UseVisualStyleBackColor = true;
            this.flag_micro.Visible = false;
            this.flag_micro.CheckedChanged += new System.EventHandler(this.flag_micro_CheckedChanged);
            // 
            // messages_panel
            // 
            this.messages_panel.AutoScroll = true;
            this.messages_panel.Location = new System.Drawing.Point(955, 49);
            this.messages_panel.Name = "messages_panel";
            this.messages_panel.Size = new System.Drawing.Size(232, 488);
            this.messages_panel.TabIndex = 12;
            // 
            // UpFile
            // 
            this.UpFile.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UpFile.Location = new System.Drawing.Point(655, 494);
            this.UpFile.Name = "UpFile";
            this.UpFile.Size = new System.Drawing.Size(50, 43);
            this.UpFile.TabIndex = 11;
            this.UpFile.Text = "+";
            this.UpFile.UseVisualStyleBackColor = true;
            this.UpFile.Visible = false;
            this.UpFile.Click += new System.EventHandler(this.UpFile_Click);
            // 
            // UpFileDialog
            // 
            this.UpFileDialog.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1216, 539);
            this.Controls.Add(this.UpFile);
            this.Controls.Add(this.r_id_t);
            this.Controls.Add(this.messages_panel);
            this.Controls.Add(this.flag_micro);
            this.Controls.Add(this.flag_camera);
            this.Controls.Add(this.send_b);
            this.Controls.Add(this.send_t);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.uname_r);
            this.Controls.Add(this.id);
            this.Controls.Add(this.view_image);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обучение";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox uname_r;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.PictureBox view_image;
        private System.Windows.Forms.RichTextBox send_t;
        private System.Windows.Forms.Button send_b;
        private System.Windows.Forms.RichTextBox r_id_t;
        private System.Windows.Forms.CheckBox flag_camera;
        private System.Windows.Forms.CheckBox flag_micro;
        private System.Windows.Forms.FlowLayoutPanel messages_panel;
        private System.Windows.Forms.Button UpFile;
        private System.Windows.Forms.OpenFileDialog UpFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFile;
    }
}

