
namespace Kino
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Enter = new System.Windows.Forms.TabPage();
            this.passTextBox1 = new System.Windows.Forms.TextBox();
            this.emailTextBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.emailPicture = new System.Windows.Forms.PictureBox();
            this.clientButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.adminButton = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.tabPage_Registration = new System.Windows.Forms.TabPage();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.passTextBoxRepeat = new System.Windows.Forms.TextBox();
            this.passTextBox2 = new System.Windows.Forms.TextBox();
            this.emailTextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.TabControl.SuspendLayout();
            this.tabPage_Enter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage_Registration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage_Enter);
            this.TabControl.Controls.Add(this.tabPage_Registration);
            this.TabControl.Location = new System.Drawing.Point(-2, -1);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(434, 530);
            this.TabControl.TabIndex = 18;
            // 
            // tabPage_Enter
            // 
            this.tabPage_Enter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Enter.Controls.Add(this.passTextBox1);
            this.tabPage_Enter.Controls.Add(this.emailTextBox1);
            this.tabPage_Enter.Controls.Add(this.pictureBox1);
            this.tabPage_Enter.Controls.Add(this.emailPicture);
            this.tabPage_Enter.Controls.Add(this.clientButton);
            this.tabPage_Enter.Controls.Add(this.pictureBox3);
            this.tabPage_Enter.Controls.Add(this.pictureBox4);
            this.tabPage_Enter.Controls.Add(this.adminButton);
            this.tabPage_Enter.Controls.Add(this.pictureBox5);
            this.tabPage_Enter.Controls.Add(this.pictureBox2);
            this.tabPage_Enter.Controls.Add(this.titleLabel);
            this.tabPage_Enter.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Enter.Name = "tabPage_Enter";
            this.tabPage_Enter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Enter.Size = new System.Drawing.Size(426, 504);
            this.tabPage_Enter.TabIndex = 0;
            this.tabPage_Enter.Text = "Войти";
            // 
            // passTextBox1
            // 
            this.passTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextBox1.Location = new System.Drawing.Point(105, 246);
            this.passTextBox1.MaximumSize = new System.Drawing.Size(281, 50);
            this.passTextBox1.MinimumSize = new System.Drawing.Size(281, 38);
            this.passTextBox1.Name = "passTextBox1";
            this.passTextBox1.Size = new System.Drawing.Size(281, 35);
            this.passTextBox1.TabIndex = 28;
            this.passTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.passTextBox1.Enter += new System.EventHandler(this.passTextBox_Enter);
            this.passTextBox1.Leave += new System.EventHandler(this.passTextBox_Leave);
            // 
            // emailTextBox1
            // 
            this.emailTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextBox1.Location = new System.Drawing.Point(105, 172);
            this.emailTextBox1.Multiline = true;
            this.emailTextBox1.Name = "emailTextBox1";
            this.emailTextBox1.Size = new System.Drawing.Size(281, 38);
            this.emailTextBox1.TabIndex = 27;
            this.emailTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emailTextBox1.Enter += new System.EventHandler(this.emailTextBox_Enter);
            this.emailTextBox1.Leave += new System.EventHandler(this.emailTextBox_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kino.Properties.Resources._lock;
            this.pictureBox1.Location = new System.Drawing.Point(40, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // emailPicture
            // 
            this.emailPicture.Image = global::Kino.Properties.Resources.email;
            this.emailPicture.Location = new System.Drawing.Point(40, 172);
            this.emailPicture.Name = "emailPicture";
            this.emailPicture.Size = new System.Drawing.Size(40, 40);
            this.emailPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.emailPicture.TabIndex = 25;
            this.emailPicture.TabStop = false;
            // 
            // clientButton
            // 
            this.clientButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientButton.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientButton.Location = new System.Drawing.Point(227, 319);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(159, 50);
            this.clientButton.TabIndex = 24;
            this.clientButton.Text = "Клиент";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            this.clientButton.MouseHover += new System.EventHandler(this.clientButton_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox3.Location = new System.Drawing.Point(105, 417);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(325, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox4.Location = new System.Drawing.Point(-2, 417);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(325, 86);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // adminButton
            // 
            this.adminButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminButton.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.Location = new System.Drawing.Point(40, 319);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(159, 50);
            this.adminButton.TabIndex = 19;
            this.adminButton.Text = "Администратор";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            this.adminButton.MouseHover += new System.EventHandler(this.adminButton_MouseHover);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox5.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(325, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox2.Location = new System.Drawing.Point(104, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(325, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Mistral", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(-2, 94);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(432, 70);
            this.titleLabel.TabIndex = 18;
            this.titleLabel.Text = "Кинотеатр \"Звёздный\"";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage_Registration
            // 
            this.tabPage_Registration.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Registration.Controls.Add(this.RegistrationButton);
            this.tabPage_Registration.Controls.Add(this.passTextBoxRepeat);
            this.tabPage_Registration.Controls.Add(this.passTextBox2);
            this.tabPage_Registration.Controls.Add(this.emailTextBox2);
            this.tabPage_Registration.Controls.Add(this.label1);
            this.tabPage_Registration.Controls.Add(this.pictureBox12);
            this.tabPage_Registration.Controls.Add(this.pictureBox10);
            this.tabPage_Registration.Controls.Add(this.pictureBox11);
            this.tabPage_Registration.Controls.Add(this.pictureBox8);
            this.tabPage_Registration.Controls.Add(this.pictureBox9);
            this.tabPage_Registration.Controls.Add(this.pictureBox6);
            this.tabPage_Registration.Controls.Add(this.pictureBox7);
            this.tabPage_Registration.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Registration.Name = "tabPage_Registration";
            this.tabPage_Registration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Registration.Size = new System.Drawing.Size(426, 504);
            this.tabPage_Registration.TabIndex = 1;
            this.tabPage_Registration.Text = "Регистрация";
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrationButton.Font = new System.Drawing.Font("Bad Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.Location = new System.Drawing.Point(104, 343);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(282, 50);
            this.RegistrationButton.TabIndex = 35;
            this.RegistrationButton.Text = "Зарегистрироваться";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            this.RegistrationButton.MouseHover += new System.EventHandler(this.RegistrationButton_MouseHover);
            // 
            // passTextBoxRepeat
            // 
            this.passTextBoxRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextBoxRepeat.Location = new System.Drawing.Point(105, 286);
            this.passTextBoxRepeat.MaximumSize = new System.Drawing.Size(281, 50);
            this.passTextBoxRepeat.MinimumSize = new System.Drawing.Size(281, 38);
            this.passTextBoxRepeat.Name = "passTextBoxRepeat";
            this.passTextBoxRepeat.Size = new System.Drawing.Size(281, 35);
            this.passTextBoxRepeat.TabIndex = 34;
            this.passTextBoxRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.passTextBoxRepeat.Enter += new System.EventHandler(this.passTextBoxRepeat_Enter);
            this.passTextBoxRepeat.Leave += new System.EventHandler(this.passTextBoxRepeat_Leave);
            // 
            // passTextBox2
            // 
            this.passTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextBox2.Location = new System.Drawing.Point(105, 229);
            this.passTextBox2.MaximumSize = new System.Drawing.Size(281, 50);
            this.passTextBox2.MinimumSize = new System.Drawing.Size(281, 38);
            this.passTextBox2.Name = "passTextBox2";
            this.passTextBox2.Size = new System.Drawing.Size(281, 35);
            this.passTextBox2.TabIndex = 32;
            this.passTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.passTextBox2.Enter += new System.EventHandler(this.passTextBox2_Enter);
            this.passTextBox2.Leave += new System.EventHandler(this.passTextBox2_Leave);
            // 
            // emailTextBox2
            // 
            this.emailTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailTextBox2.Location = new System.Drawing.Point(105, 172);
            this.emailTextBox2.Multiline = true;
            this.emailTextBox2.Name = "emailTextBox2";
            this.emailTextBox2.Size = new System.Drawing.Size(281, 38);
            this.emailTextBox2.TabIndex = 31;
            this.emailTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.emailTextBox2.Enter += new System.EventHandler(this.emailTextBox2_Enter);
            this.emailTextBox2.Leave += new System.EventHandler(this.emailTextBox2_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Mistral", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-2, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 70);
            this.label1.TabIndex = 26;
            this.label1.Text = "Кинотеатр \"Звёздный\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::Kino.Properties.Resources.unlock;
            this.pictureBox12.Location = new System.Drawing.Point(38, 228);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(44, 44);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 33;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::Kino.Properties.Resources._lock;
            this.pictureBox10.Location = new System.Drawing.Point(40, 283);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(40, 40);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 30;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::Kino.Properties.Resources.email;
            this.pictureBox11.Location = new System.Drawing.Point(40, 172);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(40, 40);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 29;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox8.Location = new System.Drawing.Point(105, 417);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(325, 86);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 25;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox9.Location = new System.Drawing.Point(-2, 417);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(325, 86);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 24;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox6.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(325, 86);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 22;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Kino.Properties.Resources.kinolenta2;
            this.pictureBox7.Location = new System.Drawing.Point(104, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(325, 86);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 23;
            this.pictureBox7.TabStop = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.clientButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(430, 531);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Кинотеатр \"Звёздный\"";
            this.TabControl.ResumeLayout(false);
            this.tabPage_Enter.ResumeLayout(false);
            this.tabPage_Enter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage_Registration.ResumeLayout(false);
            this.tabPage_Registration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage_Enter;
        private System.Windows.Forms.TextBox passTextBox1;
        private System.Windows.Forms.TextBox emailTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox emailPicture;
        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TabPage tabPage_Registration;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passTextBox2;
        private System.Windows.Forms.TextBox emailTextBox2;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.TextBox passTextBoxRepeat;
        private System.Windows.Forms.Button RegistrationButton;
    }
}

