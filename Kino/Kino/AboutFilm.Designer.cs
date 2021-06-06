
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.posterPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectFilm
            // 
            this.comboBoxSelectFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSelectFilm.FormattingEnabled = true;
            this.comboBoxSelectFilm.Location = new System.Drawing.Point(413, 12);
            this.comboBoxSelectFilm.Name = "comboBoxSelectFilm";
            this.comboBoxSelectFilm.Size = new System.Drawing.Size(259, 28);
            this.comboBoxSelectFilm.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(413, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 263);
            this.textBox1.TabIndex = 28;
            // 
            // posterPictureBox
            // 
            this.posterPictureBox.Location = new System.Drawing.Point(12, 12);
            this.posterPictureBox.Name = "posterPictureBox";
            this.posterPictureBox.Size = new System.Drawing.Size(355, 520);
            this.posterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.posterPictureBox.TabIndex = 26;
            this.posterPictureBox.TabStop = false;
            // 
            // AboutFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 546);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxSelectFilm);
            this.Controls.Add(this.posterPictureBox);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 585);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 585);
            this.Name = "AboutFilm";
            this.Text = "Кинотеатр \"Звёздный\" - О фильме";
            ((System.ComponentModel.ISupportInitialize)(this.posterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox posterPictureBox;
        private System.Windows.Forms.ComboBox comboBoxSelectFilm;
        private System.Windows.Forms.TextBox textBox1;
    }
}