
namespace Kino
{
    partial class AboutFilm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutFilm));
            this.comboBoxSelectFilm = new System.Windows.Forms.ComboBox();
            this.textBoxFilmDesc = new System.Windows.Forms.TextBox();
            this.buttonBuyTicketAbout = new System.Windows.Forms.Button();
            this.posterPictureBox = new System.Windows.Forms.PictureBox();
            this.labelFilm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectFilm
            // 
            this.comboBoxSelectFilm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxSelectFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSelectFilm.FormattingEnabled = true;
            this.comboBoxSelectFilm.Location = new System.Drawing.Point(392, 64);
            this.comboBoxSelectFilm.Name = "comboBoxSelectFilm";
            this.comboBoxSelectFilm.Size = new System.Drawing.Size(320, 28);
            this.comboBoxSelectFilm.TabIndex = 27;
            this.comboBoxSelectFilm.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectFilm_SelectedIndexChanged);
            // 
            // textBoxFilmDesc
            // 
            this.textBoxFilmDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFilmDesc.Location = new System.Drawing.Point(392, 118);
            this.textBoxFilmDesc.Multiline = true;
            this.textBoxFilmDesc.Name = "textBoxFilmDesc";
            this.textBoxFilmDesc.Size = new System.Drawing.Size(320, 302);
            this.textBoxFilmDesc.TabIndex = 28;
            this.textBoxFilmDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFilmDesc.Enter += new System.EventHandler(this.textBoxFilmDesc_Enter);
            // 
            // buttonBuyTicketAbout
            // 
            this.buttonBuyTicketAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBuyTicketAbout.Font = new System.Drawing.Font("Bad Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuyTicketAbout.Location = new System.Drawing.Point(392, 447);
            this.buttonBuyTicketAbout.Name = "buttonBuyTicketAbout";
            this.buttonBuyTicketAbout.Size = new System.Drawing.Size(320, 85);
            this.buttonBuyTicketAbout.TabIndex = 29;
            this.buttonBuyTicketAbout.Text = "Купить билет";
            this.buttonBuyTicketAbout.UseVisualStyleBackColor = true;
            this.buttonBuyTicketAbout.Click += new System.EventHandler(this.buttonBuyTicketAbout_Click);
            this.buttonBuyTicketAbout.MouseHover += new System.EventHandler(this.buttonBuyTicketAbout_MouseHover);
            // 
            // posterPictureBox
            // 
            this.posterPictureBox.ErrorImage = global::Kino.Properties.Resources.popcorn;
            this.posterPictureBox.Image = global::Kino.Properties.Resources.popcorn;
            this.posterPictureBox.InitialImage = global::Kino.Properties.Resources.popcorn;
            this.posterPictureBox.Location = new System.Drawing.Point(12, 12);
            this.posterPictureBox.Name = "posterPictureBox";
            this.posterPictureBox.Size = new System.Drawing.Size(355, 520);
            this.posterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.posterPictureBox.TabIndex = 26;
            this.posterPictureBox.TabStop = false;
            // 
            // labelFilm
            // 
            this.labelFilm.AutoSize = true;
            this.labelFilm.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFilm.Location = new System.Drawing.Point(477, 12);
            this.labelFilm.Name = "labelFilm";
            this.labelFilm.Size = new System.Drawing.Size(155, 37);
            this.labelFilm.TabIndex = 40;
            this.labelFilm.Text = "Выберите фильм:";
            // 
            // AboutFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 546);
            this.Controls.Add(this.labelFilm);
            this.Controls.Add(this.buttonBuyTicketAbout);
            this.Controls.Add(this.textBoxFilmDesc);
            this.Controls.Add(this.comboBoxSelectFilm);
            this.Controls.Add(this.posterPictureBox);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 585);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(740, 585);
            this.Name = "AboutFilm";
            this.Text = "Кинотеатр \"Звёздный\" - О фильме";
            ((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox posterPictureBox;
        private System.Windows.Forms.ComboBox comboBoxSelectFilm;
        private System.Windows.Forms.TextBox textBoxFilmDesc;
        private System.Windows.Forms.Button buttonBuyTicketAbout;
        private System.Windows.Forms.Label labelFilm;
    }
}