namespace denemeMakbuz
{
    partial class siraNoAyarlar
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
            this.pcKodCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.siraTxt = new System.Windows.Forms.TextBox();
            this.kaydetBtn = new System.Windows.Forms.Button();
            this.genelKullaniciTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pcKodCmb
            // 
            this.pcKodCmb.FormattingEnabled = true;
            this.pcKodCmb.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.pcKodCmb.Location = new System.Drawing.Point(244, 26);
            this.pcKodCmb.Name = "pcKodCmb";
            this.pcKodCmb.Size = new System.Drawing.Size(88, 21);
            this.pcKodCmb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "KULLANILAN BİLGİSAYAR:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SIRA NO BAŞLANGIÇ:";
            // 
            // siraTxt
            // 
            this.siraTxt.Location = new System.Drawing.Point(198, 73);
            this.siraTxt.MaxLength = 10;
            this.siraTxt.Name = "siraTxt";
            this.siraTxt.Size = new System.Drawing.Size(134, 20);
            this.siraTxt.TabIndex = 3;
            this.siraTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.siraTxt_KeyPress);
            // 
            // kaydetBtn
            // 
            this.kaydetBtn.Location = new System.Drawing.Point(244, 171);
            this.kaydetBtn.Name = "kaydetBtn";
            this.kaydetBtn.Size = new System.Drawing.Size(87, 23);
            this.kaydetBtn.TabIndex = 4;
            this.kaydetBtn.Text = "KAYDET";
            this.kaydetBtn.UseVisualStyleBackColor = true;
            this.kaydetBtn.Click += new System.EventHandler(this.kaydetBtn_Click);
            // 
            // genelKullaniciTxt
            // 
            this.genelKullaniciTxt.Location = new System.Drawing.Point(138, 120);
            this.genelKullaniciTxt.MaxLength = 30;
            this.genelKullaniciTxt.Name = "genelKullaniciTxt";
            this.genelKullaniciTxt.Size = new System.Drawing.Size(194, 20);
            this.genelKullaniciTxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "GENEL KULLANICI:";
            // 
            // siraNoAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(344, 206);
            this.Controls.Add(this.genelKullaniciTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kaydetBtn);
            this.Controls.Add(this.siraTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcKodCmb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 244);
            this.MinimumSize = new System.Drawing.Size(360, 244);
            this.Name = "siraNoAyarlar";
            this.Text = "SIRA NO AYARLAR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.siraNoAyarlar_FormClosing);
            this.Load += new System.EventHandler(this.siraNoAyarlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pcKodCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox siraTxt;
        private System.Windows.Forms.Button kaydetBtn;
        private System.Windows.Forms.TextBox genelKullaniciTxt;
        private System.Windows.Forms.Label label3;
    }
}