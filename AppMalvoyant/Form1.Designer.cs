
namespace AppMalvoyant
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.stop1 = new System.Windows.Forms.Button();
            this.Dgrv_News = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.premier = new System.Windows.Forms.Button();
            this.résume = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.détails = new System.Windows.Forms.Button();
            this.suivant = new System.Windows.Forms.Button();
            this.précédent = new System.Windows.Forms.Button();
            this.dernier = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgrv_News)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.stop1);
            this.panel1.Controls.Add(this.Dgrv_News);
            this.panel1.Controls.Add(this.premier);
            this.panel1.Controls.Add(this.résume);
            this.panel1.Controls.Add(this.stop);
            this.panel1.Controls.Add(this.détails);
            this.panel1.Controls.Add(this.suivant);
            this.panel1.Controls.Add(this.précédent);
            this.panel1.Controls.Add(this.dernier);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1514, 661);
            this.panel1.TabIndex = 8;
            // 
            // stop1
            // 
            this.stop1.Location = new System.Drawing.Point(424, 25);
            this.stop1.Name = "stop1";
            this.stop1.Size = new System.Drawing.Size(239, 44);
            this.stop1.TabIndex = 10;
            this.stop1.Text = "button1";
            this.stop1.UseVisualStyleBackColor = true;
            this.stop1.Click += new System.EventHandler(this.stop1_Click);
            // 
            // Dgrv_News
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Dgrv_News.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgrv_News.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgrv_News.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Dgrv_News.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgrv_News.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgrv_News.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgrv_News.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgrv_News.DoubleBuffered = true;
            this.Dgrv_News.EnableHeadersVisualStyles = false;
            this.Dgrv_News.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Dgrv_News.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Dgrv_News.Location = new System.Drawing.Point(385, 0);
            this.Dgrv_News.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Dgrv_News.Name = "Dgrv_News";
            this.Dgrv_News.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgrv_News.RowHeadersWidth = 51;
            this.Dgrv_News.RowTemplate.Height = 24;
            this.Dgrv_News.Size = new System.Drawing.Size(1126, 661);
            this.Dgrv_News.TabIndex = 9;
            // 
            // premier
            // 
            this.premier.BackColor = System.Drawing.Color.Transparent;
            this.premier.FlatAppearance.BorderSize = 0;
            this.premier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.premier.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.premier.ForeColor = System.Drawing.Color.White;
            this.premier.Location = new System.Drawing.Point(0, 18);
            this.premier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.premier.Name = "premier";
            this.premier.Size = new System.Drawing.Size(380, 69);
            this.premier.TabIndex = 1;
            this.premier.Text = "PREMIER";
            this.premier.UseVisualStyleBackColor = false;
            this.premier.Click += new System.EventHandler(this.premier_Click);
            // 
            // résume
            // 
            this.résume.BackColor = System.Drawing.Color.Transparent;
            this.résume.FlatAppearance.BorderSize = 0;
            this.résume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.résume.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.résume.ForeColor = System.Drawing.Color.White;
            this.résume.Location = new System.Drawing.Point(3, 551);
            this.résume.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.résume.Name = "résume";
            this.résume.Size = new System.Drawing.Size(380, 68);
            this.résume.TabIndex = 8;
            this.résume.Text = "PARLE";
            this.résume.UseVisualStyleBackColor = false;
            this.résume.Click += new System.EventHandler(this.résume_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.Transparent;
            this.stop.FlatAppearance.BorderSize = 0;
            this.stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.ForeColor = System.Drawing.Color.White;
            this.stop.Location = new System.Drawing.Point(0, 476);
            this.stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(380, 68);
            this.stop.TabIndex = 6;
            this.stop.Text = "PAUSE";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // détails
            // 
            this.détails.BackColor = System.Drawing.Color.Transparent;
            this.détails.FlatAppearance.BorderSize = 0;
            this.détails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.détails.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.détails.ForeColor = System.Drawing.Color.White;
            this.détails.Location = new System.Drawing.Point(-2, 381);
            this.détails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.détails.Name = "détails";
            this.détails.Size = new System.Drawing.Size(380, 68);
            this.détails.TabIndex = 5;
            this.détails.Text = "DETAILS";
            this.détails.UseVisualStyleBackColor = false;
            // 
            // suivant
            // 
            this.suivant.BackColor = System.Drawing.Color.Transparent;
            this.suivant.FlatAppearance.BorderSize = 0;
            this.suivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suivant.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suivant.ForeColor = System.Drawing.Color.White;
            this.suivant.Location = new System.Drawing.Point(0, 111);
            this.suivant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.suivant.Name = "suivant";
            this.suivant.Size = new System.Drawing.Size(380, 69);
            this.suivant.TabIndex = 1;
            this.suivant.Text = "SUIVANT";
            this.suivant.UseVisualStyleBackColor = false;
            this.suivant.Click += new System.EventHandler(this.suivant_Click);
            // 
            // précédent
            // 
            this.précédent.BackColor = System.Drawing.Color.Transparent;
            this.précédent.FlatAppearance.BorderSize = 0;
            this.précédent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.précédent.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.précédent.ForeColor = System.Drawing.Color.White;
            this.précédent.Location = new System.Drawing.Point(0, 209);
            this.précédent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.précédent.Name = "précédent";
            this.précédent.Size = new System.Drawing.Size(380, 69);
            this.précédent.TabIndex = 1;
            this.précédent.Text = "PRECEDENT";
            this.précédent.UseVisualStyleBackColor = false;
            this.précédent.Click += new System.EventHandler(this.précédent_Click);
            // 
            // dernier
            // 
            this.dernier.BackColor = System.Drawing.Color.Transparent;
            this.dernier.FlatAppearance.BorderSize = 0;
            this.dernier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dernier.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dernier.ForeColor = System.Drawing.Color.White;
            this.dernier.Location = new System.Drawing.Point(0, 305);
            this.dernier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dernier.Name = "dernier";
            this.dernier.Size = new System.Drawing.Size(380, 69);
            this.dernier.TabIndex = 3;
            this.dernier.Text = "DERNIER";
            this.dernier.UseVisualStyleBackColor = false;
            this.dernier.Click += new System.EventHandler(this.dernier_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1514, 661);
            this.panel2.TabIndex = 11;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1514, 660);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1515, 659);
            this.panel3.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 659);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Les nouvelles en Français";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgrv_News)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button stop1;

        private System.Windows.Forms.Panel panel3;

        #endregion

        public System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid Dgrv_News;
        private System.Windows.Forms.Button premier;
        private System.Windows.Forms.Button résume;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button détails;
        private System.Windows.Forms.Button suivant;
        private System.Windows.Forms.Button précédent;
        private System.Windows.Forms.Button dernier;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

