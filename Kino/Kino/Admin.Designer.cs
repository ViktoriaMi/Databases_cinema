
namespace Kino
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageEditShedule = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonAddSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDeleteSave = new System.Windows.Forms.Button();
            this.buttonSaveEdit = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.dataGridViewShedule = new System.Windows.Forms.DataGridView();
            this.dateTimePickerShedule = new System.Windows.Forms.DateTimePicker();
            this.labelChoiceDate = new System.Windows.Forms.Label();
            this.tabPageAddFilm = new System.Windows.Forms.TabPage();
            this.tabPageEditFilm = new System.Windows.Forms.TabPage();
            this.tabPageDeleteFilm = new System.Windows.Forms.TabPage();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelAgeLimit = new System.Windows.Forms.Label();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.labelPoster = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxAgeLimit = new System.Windows.Forms.ComboBox();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPoster = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageEditShedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShedule)).BeginInit();
            this.tabPageAddFilm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageEditShedule);
            this.tabControl.Controls.Add(this.tabPageAddFilm);
            this.tabControl.Controls.Add(this.tabPageEditFilm);
            this.tabControl.Controls.Add(this.tabPageDeleteFilm);
            this.tabControl.Location = new System.Drawing.Point(1, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(757, 404);
            this.tabControl.TabIndex = 34;
            // 
            // tabPageEditShedule
            // 
            this.tabPageEditShedule.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageEditShedule.Controls.Add(this.pictureBox3);
            this.tabPageEditShedule.Controls.Add(this.buttonAddSave);
            this.tabPageEditShedule.Controls.Add(this.pictureBox1);
            this.tabPageEditShedule.Controls.Add(this.buttonDeleteSave);
            this.tabPageEditShedule.Controls.Add(this.buttonSaveEdit);
            this.tabPageEditShedule.Controls.Add(this.buttonEdit);
            this.tabPageEditShedule.Controls.Add(this.buttonAdd);
            this.tabPageEditShedule.Controls.Add(this.buttonUpdate);
            this.tabPageEditShedule.Controls.Add(this.dataGridViewShedule);
            this.tabPageEditShedule.Controls.Add(this.dateTimePickerShedule);
            this.tabPageEditShedule.Controls.Add(this.labelChoiceDate);
            this.tabPageEditShedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageEditShedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditShedule.Name = "tabPageEditShedule";
            this.tabPageEditShedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditShedule.Size = new System.Drawing.Size(749, 378);
            this.tabPageEditShedule.TabIndex = 0;
            this.tabPageEditShedule.Text = "Редактирование расписания";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Kino.Properties.Resources.arrow;
            this.pictureBox3.Location = new System.Drawing.Point(537, 106);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 46;
            this.pictureBox3.TabStop = false;
            // 
            // buttonAddSave
            // 
            this.buttonAddSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddSave.Location = new System.Drawing.Point(585, 98);
            this.buttonAddSave.Name = "buttonAddSave";
            this.buttonAddSave.Size = new System.Drawing.Size(133, 46);
            this.buttonAddSave.TabIndex = 45;
            this.buttonAddSave.Text = "Сохранить изменения";
            this.buttonAddSave.UseVisualStyleBackColor = true;
            this.buttonAddSave.Click += new System.EventHandler(this.buttonAddSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kino.Properties.Resources.arrow;
            this.pictureBox1.Location = new System.Drawing.Point(537, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDeleteSave
            // 
            this.buttonDeleteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteSave.Location = new System.Drawing.Point(386, 229);
            this.buttonDeleteSave.Name = "buttonDeleteSave";
            this.buttonDeleteSave.Size = new System.Drawing.Size(133, 46);
            this.buttonDeleteSave.TabIndex = 42;
            this.buttonDeleteSave.Text = "Удалить сеанс";
            this.buttonDeleteSave.UseVisualStyleBackColor = true;
            this.buttonDeleteSave.Click += new System.EventHandler(this.buttonDeleteSave_Click);
            // 
            // buttonSaveEdit
            // 
            this.buttonSaveEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveEdit.Location = new System.Drawing.Point(585, 165);
            this.buttonSaveEdit.Name = "buttonSaveEdit";
            this.buttonSaveEdit.Size = new System.Drawing.Size(133, 46);
            this.buttonSaveEdit.TabIndex = 41;
            this.buttonSaveEdit.Text = "Сохранить изменения";
            this.buttonSaveEdit.UseVisualStyleBackColor = true;
            this.buttonSaveEdit.Click += new System.EventHandler(this.buttonSaveEdit_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEdit.Location = new System.Drawing.Point(386, 165);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(133, 46);
            this.buttonEdit.TabIndex = 39;
            this.buttonEdit.Text = "Редактировать сеанс";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(386, 98);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(133, 46);
            this.buttonAdd.TabIndex = 38;
            this.buttonAdd.Text = "Добавить сеанс";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpdate.Location = new System.Drawing.Point(35, 297);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(326, 46);
            this.buttonUpdate.TabIndex = 37;
            this.buttonUpdate.Text = "Обновить данные";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // dataGridViewShedule
            // 
            this.dataGridViewShedule.AllowUserToAddRows = false;
            this.dataGridViewShedule.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewShedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewShedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewShedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShedule.Location = new System.Drawing.Point(35, 98);
            this.dataGridViewShedule.Name = "dataGridViewShedule";
            this.dataGridViewShedule.Size = new System.Drawing.Size(326, 177);
            this.dataGridViewShedule.TabIndex = 36;
            this.dataGridViewShedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShedule_CellContentClick);
            this.dataGridViewShedule.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewShedule_CellValueChanged);
            this.dataGridViewShedule.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewShedule_DataError);
            // 
            // dateTimePickerShedule
            // 
            this.dateTimePickerShedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerShedule.Location = new System.Drawing.Point(197, 36);
            this.dateTimePickerShedule.MinDate = new System.DateTime(2021, 6, 6, 0, 0, 0, 0);
            this.dateTimePickerShedule.Name = "dateTimePickerShedule";
            this.dateTimePickerShedule.Size = new System.Drawing.Size(164, 21);
            this.dateTimePickerShedule.TabIndex = 35;
            this.dateTimePickerShedule.TabStop = false;
            this.dateTimePickerShedule.ValueChanged += new System.EventHandler(this.dateTimePickerShedule_ValueChanged);
            // 
            // labelChoiceDate
            // 
            this.labelChoiceDate.AutoSize = true;
            this.labelChoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChoiceDate.Location = new System.Drawing.Point(33, 36);
            this.labelChoiceDate.Name = "labelChoiceDate";
            this.labelChoiceDate.Size = new System.Drawing.Size(98, 15);
            this.labelChoiceDate.TabIndex = 34;
            this.labelChoiceDate.Text = "Выберите дату:";
            // 
            // tabPageAddFilm
            // 
            this.tabPageAddFilm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageAddFilm.Controls.Add(this.label2);
            this.tabPageAddFilm.Controls.Add(this.buttonSave);
            this.tabPageAddFilm.Controls.Add(this.textBoxPoster);
            this.tabPageAddFilm.Controls.Add(this.label1);
            this.tabPageAddFilm.Controls.Add(this.textBoxPeriod);
            this.tabPageAddFilm.Controls.Add(this.comboBoxAgeLimit);
            this.tabPageAddFilm.Controls.Add(this.textBoxDescription);
            this.tabPageAddFilm.Controls.Add(this.textBoxName);
            this.tabPageAddFilm.Controls.Add(this.labelPoster);
            this.tabPageAddFilm.Controls.Add(this.labelPeriod);
            this.tabPageAddFilm.Controls.Add(this.labelAgeLimit);
            this.tabPageAddFilm.Controls.Add(this.labelDescription);
            this.tabPageAddFilm.Controls.Add(this.labelName);
            this.tabPageAddFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageAddFilm.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddFilm.Name = "tabPageAddFilm";
            this.tabPageAddFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddFilm.Size = new System.Drawing.Size(749, 378);
            this.tabPageAddFilm.TabIndex = 1;
            this.tabPageAddFilm.Text = "Добавление фильма";
            // 
            // tabPageEditFilm
            // 
            this.tabPageEditFilm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageEditFilm.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditFilm.Name = "tabPageEditFilm";
            this.tabPageEditFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditFilm.Size = new System.Drawing.Size(749, 378);
            this.tabPageEditFilm.TabIndex = 2;
            this.tabPageEditFilm.Text = "Редактирование фильма";
            // 
            // tabPageDeleteFilm
            // 
            this.tabPageDeleteFilm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageDeleteFilm.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeleteFilm.Name = "tabPageDeleteFilm";
            this.tabPageDeleteFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeleteFilm.Size = new System.Drawing.Size(749, 378);
            this.tabPageDeleteFilm.TabIndex = 3;
            this.tabPageDeleteFilm.Text = "Удаление фильма";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(47, 35);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(118, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Введите название:";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.Location = new System.Drawing.Point(312, 35);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(118, 15);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Введите описание:";
            // 
            // labelAgeLimit
            // 
            this.labelAgeLimit.AutoSize = true;
            this.labelAgeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAgeLimit.Location = new System.Drawing.Point(45, 97);
            this.labelAgeLimit.Name = "labelAgeLimit";
            this.labelAgeLimit.Size = new System.Drawing.Size(217, 15);
            this.labelAgeLimit.TabIndex = 2;
            this.labelAgeLimit.Text = "Выберите возрастное ограничение:";
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPeriod.Location = new System.Drawing.Point(45, 160);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(183, 15);
            this.labelPeriod.TabIndex = 3;
            this.labelPeriod.Text = "Введите продолжительность:";
            // 
            // labelPoster
            // 
            this.labelPoster.AutoSize = true;
            this.labelPoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPoster.Location = new System.Drawing.Point(47, 227);
            this.labelPoster.Name = "labelPoster";
            this.labelPoster.Size = new System.Drawing.Size(169, 15);
            this.labelPoster.TabIndex = 4;
            this.labelPoster.Text = "Введите название постера:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(48, 56);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(216, 21);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(315, 56);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(403, 293);
            this.textBoxDescription.TabIndex = 6;
            // 
            // comboBoxAgeLimit
            // 
            this.comboBoxAgeLimit.FormattingEnabled = true;
            this.comboBoxAgeLimit.Location = new System.Drawing.Point(48, 118);
            this.comboBoxAgeLimit.Name = "comboBoxAgeLimit";
            this.comboBoxAgeLimit.Size = new System.Drawing.Size(216, 23);
            this.comboBoxAgeLimit.TabIndex = 7;
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Location = new System.Drawing.Point(48, 181);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.Size = new System.Drawing.Size(174, 21);
            this.textBoxPeriod.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = ", мин";
            // 
            // textBoxPoster
            // 
            this.textBoxPoster.Location = new System.Drawing.Point(48, 249);
            this.textBoxPoster.Name = "textBoxPoster";
            this.textBoxPoster.Size = new System.Drawing.Size(174, 21);
            this.textBoxPoster.TabIndex = 10;
            // 
            // buttonSave
            // 
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Location = new System.Drawing.Point(48, 294);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(216, 55);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Добавить фильм";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = ".jpg";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 406);
            this.Controls.Add(this.tabControl);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Admin";
            this.Text = "Кинотеатр \"Звёздный\"";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageEditShedule.ResumeLayout(false);
            this.tabPageEditShedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShedule)).EndInit();
            this.tabPageAddFilm.ResumeLayout(false);
            this.tabPageAddFilm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageEditShedule;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.DataGridView dataGridViewShedule;
        private System.Windows.Forms.DateTimePicker dateTimePickerShedule;
        private System.Windows.Forms.Label labelChoiceDate;
        private System.Windows.Forms.TabPage tabPageAddFilm;
        private System.Windows.Forms.Button buttonSaveEdit;
        private System.Windows.Forms.Button buttonDeleteSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddSave;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabPage tabPageEditFilm;
        private System.Windows.Forms.TabPage tabPageDeleteFilm;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPoster;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.Label labelAgeLimit;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxAgeLimit;
        private System.Windows.Forms.TextBox textBoxPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPoster;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label2;
    }
}