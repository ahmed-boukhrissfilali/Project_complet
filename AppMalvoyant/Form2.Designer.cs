
namespace AppMalvoyant
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ArPanel1 = new System.Windows.Forms.Panel();
            this.ArPlay = new System.Windows.Forms.Button();
            this.Dgrv_ArNews = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ArStop = new System.Windows.Forms.Button();
            this.ArPremier = new System.Windows.Forms.Button();
            this.Ardetails = new System.Windows.Forms.Button();
            this.ArSuivant = new System.Windows.Forms.Button();
            this.ArPrecedent = new System.Windows.Forms.Button();
            this.ArDernier = new System.Windows.Forms.Button();
            this.richTextBoxEng = new System.Windows.Forms.RichTextBox();
            this.EngPanel2 = new System.Windows.Forms.Panel();
            this.stop1 = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.ArPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgrv_ArNews)).BeginInit();
            this.EngPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArPanel1
            // 
            this.ArPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ArPanel1.Controls.Add(this.stop);
            this.ArPanel1.Controls.Add(this.ArPlay);
            this.ArPanel1.Controls.Add(this.Dgrv_ArNews);
            this.ArPanel1.Controls.Add(this.ArStop);
            this.ArPanel1.Controls.Add(this.ArPremier);
            this.ArPanel1.Controls.Add(this.Ardetails);
            this.ArPanel1.Controls.Add(this.ArSuivant);
            this.ArPanel1.Controls.Add(this.ArPrecedent);
            this.ArPanel1.Controls.Add(this.ArDernier);
            this.ArPanel1.Location = new System.Drawing.Point(0, 0);
            this.ArPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArPanel1.Name = "ArPanel1";
            this.ArPanel1.Size = new System.Drawing.Size(1462, 658);
            this.ArPanel1.TabIndex = 9;
            // 
            // ArPlay
            // 
            this.ArPlay.BackColor = System.Drawing.Color.Transparent;
            this.ArPlay.FlatAppearance.BorderSize = 0;
            this.ArPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArPlay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArPlay.ForeColor = System.Drawing.Color.White;
            this.ArPlay.Location = new System.Drawing.Point(3, 608);
            this.ArPlay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArPlay.Name = "ArPlay";
            this.ArPlay.Size = new System.Drawing.Size(328, 45);
            this.ArPlay.TabIndex = 8;
            this.ArPlay.Text = "أكمل";
            this.ArPlay.UseVisualStyleBackColor = false;
            this.ArPlay.Click += new System.EventHandler(this.ArPlay_Click);
            // 
            // Dgrv_ArNews
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Dgrv_ArNews.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgrv_ArNews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgrv_ArNews.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Dgrv_ArNews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgrv_ArNews.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgrv_ArNews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgrv_ArNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgrv_ArNews.DoubleBuffered = true;
            this.Dgrv_ArNews.EnableHeadersVisualStyles = false;
            this.Dgrv_ArNews.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Dgrv_ArNews.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Dgrv_ArNews.Location = new System.Drawing.Point(384, 0);
            this.Dgrv_ArNews.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dgrv_ArNews.Name = "Dgrv_ArNews";
            this.Dgrv_ArNews.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgrv_ArNews.RowHeadersWidth = 51;
            this.Dgrv_ArNews.RowTemplate.Height = 24;
            this.Dgrv_ArNews.Size = new System.Drawing.Size(1076, 652);
            this.Dgrv_ArNews.TabIndex = 7;
            // 
            // ArStop
            // 
            this.ArStop.BackColor = System.Drawing.Color.Transparent;
            this.ArStop.FlatAppearance.BorderSize = 0;
            this.ArStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArStop.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArStop.ForeColor = System.Drawing.Color.White;
            this.ArStop.Location = new System.Drawing.Point(18, 514);
            this.ArStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArStop.Name = "ArStop";
            this.ArStop.Size = new System.Drawing.Size(328, 60);
            this.ArStop.TabIndex = 6;
            this.ArStop.Text = "توقف";
            this.ArStop.UseVisualStyleBackColor = false;
            this.ArStop.Click += new System.EventHandler(this.ArStop_Click);
            // 
            // ArPremier
            // 
            this.ArPremier.BackColor = System.Drawing.Color.Transparent;
            this.ArPremier.FlatAppearance.BorderSize = 0;
            this.ArPremier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArPremier.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArPremier.ForeColor = System.Drawing.Color.White;
            this.ArPremier.Location = new System.Drawing.Point(18, 38);
            this.ArPremier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArPremier.Name = "ArPremier";
            this.ArPremier.Size = new System.Drawing.Size(328, 60);
            this.ArPremier.TabIndex = 1;
            this.ArPremier.Text = "الأول";
            this.ArPremier.UseVisualStyleBackColor = false;
            this.ArPremier.Click += new System.EventHandler(this.ArPremier_Click);
            // 
            // Ardetails
            // 
            this.Ardetails.BackColor = System.Drawing.Color.Transparent;
            this.Ardetails.FlatAppearance.BorderSize = 0;
            this.Ardetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ardetails.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ardetails.ForeColor = System.Drawing.Color.White;
            this.Ardetails.Location = new System.Drawing.Point(18, 421);
            this.Ardetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Ardetails.Name = "Ardetails";
            this.Ardetails.Size = new System.Drawing.Size(328, 60);
            this.Ardetails.TabIndex = 5;
            this.Ardetails.Text = "التفاصيل";
            this.Ardetails.UseVisualStyleBackColor = false;
            this.Ardetails.Click += new System.EventHandler(this.Ardetails_Click);
            // 
            // ArSuivant
            // 
            this.ArSuivant.BackColor = System.Drawing.Color.Transparent;
            this.ArSuivant.FlatAppearance.BorderSize = 0;
            this.ArSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArSuivant.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArSuivant.ForeColor = System.Drawing.Color.White;
            this.ArSuivant.Location = new System.Drawing.Point(18, 125);
            this.ArSuivant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArSuivant.Name = "ArSuivant";
            this.ArSuivant.Size = new System.Drawing.Size(328, 60);
            this.ArSuivant.TabIndex = 1;
            this.ArSuivant.Text = "التالي";
            this.ArSuivant.UseVisualStyleBackColor = false;
            this.ArSuivant.Click += new System.EventHandler(this.ArSuivant_Click);
            // 
            // ArPrecedent
            // 
            this.ArPrecedent.BackColor = System.Drawing.Color.Transparent;
            this.ArPrecedent.FlatAppearance.BorderSize = 0;
            this.ArPrecedent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArPrecedent.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArPrecedent.ForeColor = System.Drawing.Color.White;
            this.ArPrecedent.Location = new System.Drawing.Point(18, 228);
            this.ArPrecedent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArPrecedent.Name = "ArPrecedent";
            this.ArPrecedent.Size = new System.Drawing.Size(328, 60);
            this.ArPrecedent.TabIndex = 1;
            this.ArPrecedent.Text = "السابق";
            this.ArPrecedent.UseVisualStyleBackColor = false;
            this.ArPrecedent.Click += new System.EventHandler(this.ArPrecedent_Click);
            // 
            // ArDernier
            // 
            this.ArDernier.BackColor = System.Drawing.Color.Transparent;
            this.ArDernier.FlatAppearance.BorderSize = 0;
            this.ArDernier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArDernier.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArDernier.ForeColor = System.Drawing.Color.White;
            this.ArDernier.Location = new System.Drawing.Point(21, 324);
            this.ArDernier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArDernier.Name = "ArDernier";
            this.ArDernier.Size = new System.Drawing.Size(328, 60);
            this.ArDernier.TabIndex = 3;
            this.ArDernier.Text = "الأخير";
            this.ArDernier.UseVisualStyleBackColor = false;
            this.ArDernier.Click += new System.EventHandler(this.ArDernier_Click);
            // 
            // richTextBoxEng
            // 
            this.richTextBoxEng.Location = new System.Drawing.Point(-1, 0);
            this.richTextBoxEng.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxEng.Name = "richTextBoxEng";
            this.richTextBoxEng.Size = new System.Drawing.Size(1463, 614);
            this.richTextBoxEng.TabIndex = 0;
            this.richTextBoxEng.Text = "";
            // 
            // EngPanel2
            // 
            this.EngPanel2.BackColor = System.Drawing.Color.White;
            this.EngPanel2.Controls.Add(this.richTextBoxEng);
            this.EngPanel2.Location = new System.Drawing.Point(1, 2);
            this.EngPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngPanel2.Name = "EngPanel2";
            this.EngPanel2.Size = new System.Drawing.Size(1462, 615);
            this.EngPanel2.TabIndex = 12;
            // 
            // stop1
            // 
            this.stop1.Location = new System.Drawing.Point(1225, 612);
            this.stop1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stop1.Name = "stop1";
            this.stop1.Size = new System.Drawing.Size(184, 45);
            this.stop1.TabIndex = 9;
            this.stop1.Text = "button1";
            this.stop1.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(674, 83);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(255, 61);
            this.stop.TabIndex = 9;
            this.stop.Text = "button1";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1462, 654);
            this.Controls.Add(this.ArPanel1);
            this.Controls.Add(this.stop1);
            this.Controls.Add(this.EngPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لأخبار باللغة العربية";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ArPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgrv_ArNews)).EndInit();
            this.EngPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button stop;

        #endregion

        private System.Windows.Forms.Panel ArPanel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid Dgrv_ArNews;
        private System.Windows.Forms.Button ArStop;
        private System.Windows.Forms.Button ArPremier;
        private System.Windows.Forms.Button Ardetails;
        private System.Windows.Forms.Button ArSuivant;
        private System.Windows.Forms.Button ArPrecedent;
        private System.Windows.Forms.Button ArDernier;
        private System.Windows.Forms.RichTextBox richTextBoxEng;
        private System.Windows.Forms.Panel EngPanel2;
        private System.Windows.Forms.Button ArPlay;
        private System.Windows.Forms.Button stop1;
    }
}