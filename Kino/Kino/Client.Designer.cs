
namespace Kino
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.dataGridViewShedule = new System.Windows.Forms.DataGridView();
            this.dateTimePickerShedule = new System.Windows.Forms.DateTimePicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAboutFilm = new System.Windows.Forms.Button();
            this.buttonBuyTicket = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShedule
            // 
            this.dataGridViewShedule.AllowUserToAddRows = false;
            this.dataGridViewShedule.AllowUserToDeleteRows = false;
            this.dataGridViewShedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewShedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewShedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewShedule.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewShedule.Location = new System.Drawing.Point(24, 157);
            this.dataGridViewShedule.Name = "dataGridViewShedule";
            this.dataGridViewShedule.ReadOnly = true;
            this.dataGridViewShedule.Size = new System.Drawing.Size(465, 168);
            this.dataGridViewShedule.TabIndex = 27;
            // 
            // dateTimePickerShedule
            // 
            this.dateTimePickerShedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerShedule.Location = new System.Drawing.Point(325, 110);
            this.dateTimePickerShedule.MinDate = new System.DateTime(2021, 6, 6, 0, 0, 0, 0);
            this.dateTimePickerShedule.Name = "dateTimePickerShedule";
            this.dateTimePickerShedule.Size = new System.Drawing.Size(164, 26);
            this.dateTimePickerShedule.TabIndex = 26;
            this.dateTimePickerShedule.TabStop = false;
            this.dateTimePickerShedule.ValueChanged += new System.EventHandler(this.dateTimePickerShedule_ValueChanged);
            // 
            // pictureBox2
            // 
            //this.pictureBox2.Image = global::Kino.Properties.Resources.kinolenta;
            this.pictureBox2.Location = new System.Drawing.Point(322, 414);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(325, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            //this.pictureBox1.Image = global::Kino.Properties.Resources.kinolenta;
            this.pictureBox1.Location = new System.Drawing.Point(1, 414);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            //this.pictureBox3.Image = global::Kino.Properties.Resources.kinolenta;
            this.pictureBox3.Location = new System.Drawing.Point(322, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(325, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            //this.pictureBox5.Image = global::Kino.Properties.Resources.kinolenta;
            this.pictureBox5.Location = new System.Drawing.Point(1, 1);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(325, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdate.Location = new System.Drawing.Point(24, 343);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(145, 50);
            this.buttonUpdate.TabIndex = 28;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAboutFilm
            // 
            this.buttonAboutFilm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAboutFilm.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAboutFilm.Location = new System.Drawing.Point(184, 343);
            this.buttonAboutFilm.Name = "buttonAboutFilm";
            this.buttonAboutFilm.Size = new System.Drawing.Size(145, 50);
            this.buttonAboutFilm.TabIndex = 29;
            this.buttonAboutFilm.Text = "О фильме";
            this.buttonAboutFilm.UseVisualStyleBackColor = true;
            this.buttonAboutFilm.Click += new System.EventHandler(this.buttonAboutFilm_Click);
            // 
            // buttonBuyTicket
            // 
            this.buttonBuyTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBuyTicket.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuyTicket.Location = new System.Drawing.Point(344, 343);
            this.buttonBuyTicket.Name = "buttonBuyTicket";
            this.buttonBuyTicket.Size = new System.Drawing.Size(145, 50);
            this.buttonBuyTicket.TabIndex = 30;
            this.buttonBuyTicket.Text = "Купить билет";
            this.buttonBuyTicket.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(20, 102);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(139, 37);
            this.label.TabIndex = 31;
            this.label.Text = "Выберите дату:";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 501);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonBuyTicket);
            this.Controls.Add(this.buttonAboutFilm);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.dataGridViewShedule);
            this.Controls.Add(this.dateTimePickerShedule);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox5);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(530, 540);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 540);
            this.Name = "Client";
            this.Text = "Кинотеатр \"Звёздный\" - Расписание";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShedule;
        private System.Windows.Forms.DateTimePicker dateTimePickerShedule;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAboutFilm;
        private System.Windows.Forms.Button buttonBuyTicket;
        private System.Windows.Forms.Label label;
    }
}