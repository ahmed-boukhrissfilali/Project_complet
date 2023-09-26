
namespace AppMalvoyant
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.EngPanel1 = new System.Windows.Forms.Panel();
            this.stop = new System.Windows.Forms.Button();
            this.EngPlay = new System.Windows.Forms.Button();
            this.Dgrv_EngNews = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.EngStop = new System.Windows.Forms.Button();
            this.EngPremier = new System.Windows.Forms.Button();
            this.EngDetails = new System.Windows.Forms.Button();
            this.EngSuivant = new System.Windows.Forms.Button();
            this.EngPrecedent = new System.Windows.Forms.Button();
            this.EngDernier = new System.Windows.Forms.Button();
            this.stop1 = new System.Windows.Forms.Button();
            this.EngPanel2 = new System.Windows.Forms.Panel();
            this.richTextBoxEng = new System.Windows.Forms.RichTextBox();
            this.EngPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgrv_EngNews)).BeginInit();
            this.EngPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EngPanel1
            // 
            this.EngPanel1.BackColor = System.Drawing.Color.Yellow;
            this.EngPanel1.Controls.Add(this.stop);
            this.EngPanel1.Controls.Add(this.EngPlay);
            this.EngPanel1.Controls.Add(this.Dgrv_EngNews);
            this.EngPanel1.Controls.Add(this.EngStop);
            this.EngPanel1.Controls.Add(this.EngPremier);
            this.EngPanel1.Controls.Add(this.EngDetails);
            this.EngPanel1.Controls.Add(this.EngSuivant);
            this.EngPanel1.Controls.Add(this.EngPrecedent);
            this.EngPanel1.Controls.Add(this.EngDernier);
            this.EngPanel1.Location = new System.Drawing.Point(0, 2);
            this.EngPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngPanel1.Name = "EngPanel1";
            this.EngPanel1.Size = new System.Drawing.Size(1514, 662);
            this.EngPanel1.TabIndex = 10;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(507, 68);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(447, 70);
            this.stop.TabIndex = 9;
            this.stop.Text = "button1";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // EngPlay
            // 
            this.EngPlay.BackColor = System.Drawing.Color.Transparent;
            this.EngPlay.FlatAppearance.BorderSize = 0;
            this.EngPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngPlay.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngPlay.ForeColor = System.Drawing.Color.Black;
            this.EngPlay.Location = new System.Drawing.Point(3, 585);
            this.EngPlay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngPlay.Name = "EngPlay";
            this.EngPlay.Size = new System.Drawing.Size(380, 68);
            this.EngPlay.TabIndex = 8;
            this.EngPlay.Text = "PLAY";
            this.EngPlay.UseVisualStyleBackColor = false;
            this.EngPlay.Click += new System.EventHandler(this.EngPlay_Click);
            // 
            // Dgrv_EngNews
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Dgrv_EngNews.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgrv_EngNews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgrv_EngNews.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Dgrv_EngNews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgrv_EngNews.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgrv_EngNews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgrv_EngNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgrv_EngNews.DoubleBuffered = true;
            this.Dgrv_EngNews.EnableHeadersVisualStyles = false;
            this.Dgrv_EngNews.HeaderBgColor = System.Drawing.Color.Yellow;
            this.Dgrv_EngNews.HeaderForeColor = System.Drawing.Color.Yellow;
            this.Dgrv_EngNews.Location = new System.Drawing.Point(387, 0);
            this.Dgrv_EngNews.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dgrv_EngNews.Name = "Dgrv_EngNews";
            this.Dgrv_EngNews.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgrv_EngNews.RowHeadersWidth = 51;
            this.Dgrv_EngNews.RowTemplate.Height = 24;
            this.Dgrv_EngNews.Size = new System.Drawing.Size(1127, 662);
            this.Dgrv_EngNews.TabIndex = 7;
            // 
            // EngStop
            // 
            this.EngStop.BackColor = System.Drawing.Color.Transparent;
            this.EngStop.FlatAppearance.BorderSize = 0;
            this.EngStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngStop.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngStop.ForeColor = System.Drawing.Color.Black;
            this.EngStop.Location = new System.Drawing.Point(0, 491);
            this.EngStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngStop.Name = "EngStop";
            this.EngStop.Size = new System.Drawing.Size(380, 68);
            this.EngStop.TabIndex = 6;
            this.EngStop.Text = "STOP";
            this.EngStop.UseVisualStyleBackColor = false;
            this.EngStop.Click += new System.EventHandler(this.EngStop_Click);
            // 
            // EngPremier
            // 
            this.EngPremier.BackColor = System.Drawing.Color.Transparent;
            this.EngPremier.FlatAppearance.BorderSize = 0;
            this.EngPremier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngPremier.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngPremier.ForeColor = System.Drawing.Color.Black;
            this.EngPremier.Location = new System.Drawing.Point(0, 14);
            this.EngPremier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngPremier.Name = "EngPremier";
            this.EngPremier.Size = new System.Drawing.Size(380, 69);
            this.EngPremier.TabIndex = 1;
            this.EngPremier.Text = "FIRST";
            this.EngPremier.UseVisualStyleBackColor = false;
            this.EngPremier.Click += new System.EventHandler(this.EngPremier_Click);
            // 
            // EngDetails
            // 
            this.EngDetails.BackColor = System.Drawing.Color.Transparent;
            this.EngDetails.FlatAppearance.BorderSize = 0;
            this.EngDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngDetails.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngDetails.ForeColor = System.Drawing.Color.Black;
            this.EngDetails.Location = new System.Drawing.Point(0, 398);
            this.EngDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngDetails.Name = "EngDetails";
            this.EngDetails.Size = new System.Drawing.Size(380, 68);
            this.EngDetails.TabIndex = 5;
            this.EngDetails.Text = "DETAILS";
            this.EngDetails.UseVisualStyleBackColor = false;
            this.EngDetails.Click += new System.EventHandler(this.EngDetails_Click);
            // 
            // EngSuivant
            // 
            this.EngSuivant.BackColor = System.Drawing.Color.Transparent;
            this.EngSuivant.FlatAppearance.BorderSize = 0;
            this.EngSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngSuivant.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngSuivant.ForeColor = System.Drawing.Color.Black;
            this.EngSuivant.Location = new System.Drawing.Point(0, 101);
            this.EngSuivant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngSuivant.Name = "EngSuivant";
            this.EngSuivant.Size = new System.Drawing.Size(380, 69);
            this.EngSuivant.TabIndex = 1;
            this.EngSuivant.Text = "NEXT";
            this.EngSuivant.UseVisualStyleBackColor = false;
            this.EngSuivant.Click += new System.EventHandler(this.EngSuivant_Click);
            // 
            // EngPrecedent
            // 
            this.EngPrecedent.BackColor = System.Drawing.Color.Transparent;
            this.EngPrecedent.FlatAppearance.BorderSize = 0;
            this.EngPrecedent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngPrecedent.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngPrecedent.ForeColor = System.Drawing.Color.Black;
            this.EngPrecedent.Location = new System.Drawing.Point(0, 204);
            this.EngPrecedent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngPrecedent.Name = "EngPrecedent";
            this.EngPrecedent.Size = new System.Drawing.Size(380, 69);
            this.EngPrecedent.TabIndex = 1;
            this.EngPrecedent.Text = "PREVIOUS";
            this.EngPrecedent.UseVisualStyleBackColor = false;
            this.EngPrecedent.Click += new System.EventHandler(this.EngPrecedent_Click);
            // 
            // EngDernier
            // 
            this.EngDernier.BackColor = System.Drawing.Color.Transparent;
            this.EngDernier.FlatAppearance.BorderSize = 0;
            this.EngDernier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EngDernier.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngDernier.ForeColor = System.Drawing.Color.Black;
            this.EngDernier.Location = new System.Drawing.Point(3, 300);
            this.EngDernier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngDernier.Name = "EngDernier";
            this.EngDernier.Size = new System.Drawing.Size(380, 69);
            this.EngDernier.TabIndex = 3;
            this.EngDernier.Text = "LAST";
            this.EngDernier.UseVisualStyleBackColor = false;
            this.EngDernier.Click += new System.EventHandler(this.EngDernier_Click);
            // 
            // stop1
            // 
            this.stop1.Location = new System.Drawing.Point(944, 672);
            this.stop1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stop1.Name = "stop1";
            this.stop1.Size = new System.Drawing.Size(75, 22);
            this.stop1.TabIndex = 9;
            this.stop1.Text = "stop";
            this.stop1.UseVisualStyleBackColor = true;
            // 
            // EngPanel2
            // 
            this.EngPanel2.BackColor = System.Drawing.Color.Honeydew;
            this.EngPanel2.Controls.Add(this.richTextBoxEng);
            this.EngPanel2.Location = new System.Drawing.Point(0, 0);
            this.EngPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EngPanel2.Name = "EngPanel2";
            this.EngPanel2.Size = new System.Drawing.Size(1514, 652);
            this.EngPanel2.TabIndex = 9;
            // 
            // richTextBoxEng
            // 
            this.richTextBoxEng.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxEng.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxEng.Name = "richTextBoxEng";
            this.richTextBoxEng.Size = new System.Drawing.Size(1514, 652);
            this.richTextBoxEng.TabIndex = 0;
            this.richTextBoxEng.Text = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 665);
            this.Controls.Add(this.stop1);
            this.Controls.Add(this.EngPanel1);
            this.Controls.Add(this.EngPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The news in english";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.EngPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgrv_EngNews)).EndInit();
            this.EngPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button stop;

        private System.Windows.Forms.Button stop1;

        #endregion

        private System.Windows.Forms.Panel EngPanel1;
        private System.Windows.Forms.Button EngPlay;
        private Bunifu.Framework.UI.BunifuCustomDataGrid Dgrv_EngNews;
        private System.Windows.Forms.Button EngStop;
        private System.Windows.Forms.Button EngPremier;
        private System.Windows.Forms.Button EngDetails;
        private System.Windows.Forms.Button EngSuivant;
        private System.Windows.Forms.Button EngPrecedent;
        private System.Windows.Forms.Button EngDernier;
        private System.Windows.Forms.Panel EngPanel2;
        private System.Windows.Forms.RichTextBox richTextBoxEng;
    }
}