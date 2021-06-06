using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kino
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pictureBox3.Image = Properties.Resources.kinolenta2;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.HelpButton = true;

            emailTextBox1.Text = "Введите email";
            emailTextBox1.ForeColor = Color.Gray;
            passTextBox1.Text = "Введите пароль";
            passTextBox1.ForeColor = Color.Gray;
            emailTextBox2.Text = "Введите email";
            emailTextBox2.ForeColor = Color.Gray;
            passTextBox2.Text = "Введите пароль";
            passTextBox2.ForeColor = Color.Gray;
            passTextBoxRepeat.Text = "Повторите пароль";
            passTextBoxRepeat.ForeColor = Color.Gray;
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            if (emailTextBox1.Text == "" || emailTextBox1.Text == "Введите email")
            {
                MessageBox.Show("Пожалуйста, введите email для входа.", "Войти",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            else if (passTextBox1.Text == "" || passTextBox1.Text == "Введите пароль")
            {
                MessageBox.Show("Пожалуйста, введите пароль для входа.", "Войти",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            else
            {
                String email = emailTextBox1.Text;
                String pass = passTextBox1.Text;

                DB db = new DB();

                DataTable table = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand myCom = new MySqlCommand("SELECT * FROM админ WHERE Email = @em AND Пароль = @pa", db.getConnection());

                myCom.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
                myCom.Parameters.Add("@pa", MySqlDbType.VarChar).Value = pass;

                dataAdapter.SelectCommand = myCom;
                dataAdapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    Admin form = new Admin();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Войти",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    if (passTextBox1.Text != "Введите пароль")
                    {
                        passTextBox1.Text = "Введите пароль";
                        passTextBox1.ForeColor = Color.Gray;
                        passTextBox1.UseSystemPasswordChar = false;
                    }
                }
            }
        }
        private void clientButton_Click(object sender, EventArgs e)
        {
            if (emailTextBox1.Text == "" || emailTextBox1.Text == "Введите email")
            {
                MessageBox.Show("Пожалуйста, введите email для входа.", "Войти",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            else if (passTextBox1.Text == "" || passTextBox1.Text == "Введите пароль")
            {
                MessageBox.Show("Пожалуйста, введите пароль для входа.", "Войти",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            else
            {
                String email = emailTextBox1.Text;
                String pass = passTextBox1.Text;

                DB db = new DB();

                DataTable table = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand myCom = new MySqlCommand("SELECT * FROM клиент WHERE Email = @em AND Пароль = @pa", db.getConnection());

                myCom.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
                myCom.Parameters.Add("@pa", MySqlDbType.VarChar).Value = pass;

                dataAdapter.SelectCommand = myCom;
                dataAdapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    ClientForm form = new ClientForm();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Войти",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    if (passTextBox1.Text != "Введите пароль")
                    {
                        passTextBox1.Text = "Введите пароль";
                        passTextBox1.ForeColor = Color.Gray;
                        passTextBox1.UseSystemPasswordChar = false;
                    }
                }
            }
        }
        private void emailTextBox_Enter(object sender, EventArgs e)
        {
            if (emailTextBox1.Text == "Введите email")
            {
                emailTextBox1.Text = "";
                emailTextBox1.ForeColor = Color.Black;
            }
        }

        private void emailTextBox_Leave(object sender, EventArgs e)
        {
            if (emailTextBox1.Text == "")
            {
                emailTextBox1.Text = "Введите email";
                emailTextBox1.ForeColor = Color.Gray;
            }
        }

        private void passTextBox_Enter(object sender, EventArgs e)
        {
            if (passTextBox1.Text == "Введите пароль")
            {
                passTextBox1.Text = "";
                passTextBox1.ForeColor = Color.Black;
                passTextBox1.UseSystemPasswordChar = true;
            }
        }

        private void passTextBox_Leave(object sender, EventArgs e)
        {
            if (passTextBox1.Text == "")
            {
                passTextBox1.Text = "Введите пароль";
                passTextBox1.ForeColor = Color.Gray;
                passTextBox1.UseSystemPasswordChar = false;
            }
        }

        private void emailTextBox2_Enter(object sender, EventArgs e)
        {
            if (emailTextBox2.Text == "Введите email")
            {
                emailTextBox2.Text = "";
                emailTextBox2.ForeColor = Color.Black;
            }
        }

        private void emailTextBox2_Leave(object sender, EventArgs e)
        {
            if (emailTextBox2.Text == "")
            {
                emailTextBox2.Text = "Введите email";
                emailTextBox2.ForeColor = Color.Gray;
            }
        }

        private void passTextBox2_Enter(object sender, EventArgs e)
        {
            if (passTextBox2.Text == "Введите пароль")
            {
                passTextBox2.Text = "";
                passTextBox2.ForeColor = Color.Black;
                passTextBox2.UseSystemPasswordChar = true;
            }
        }

        private void passTextBox2_Leave(object sender, EventArgs e)
        {
            if (passTextBox2.Text == "")
            {
                passTextBox2.Text = "Введите пароль";
                passTextBox2.ForeColor = Color.Gray;
                passTextBox2.UseSystemPasswordChar = false;
            }
        }

        private void passTextBoxRepeat_Enter(object sender, EventArgs e)
        {
            if (passTextBoxRepeat.Text == "Повторите пароль")
            {
                passTextBoxRepeat.Text = "";
                passTextBoxRepeat.ForeColor = Color.Black;
                passTextBoxRepeat.UseSystemPasswordChar = true;
            }
        }

        private void passTextBoxRepeat_Leave(object sender, EventArgs e)
        {
            if (passTextBoxRepeat.Text == "")
            {
                passTextBoxRepeat.Text = "Повторите пароль";
                passTextBoxRepeat.ForeColor = Color.Gray;
                passTextBoxRepeat.UseSystemPasswordChar = false;
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (emailTextBox2.Text == "" || emailTextBox2.Text == "Введите email")
            {
                MessageBox.Show("Пустое имя пользователя!", "Зарегистрироваться",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                return;
            }
            else if (passTextBox2.Text == "" || passTextBox2.Text == "Введите пароль" 
                || passTextBoxRepeat.Text == "" || passTextBoxRepeat.Text == "Повторите пароль")
            {
                MessageBox.Show("Введите пароли в оба поля!", "Зарегистрироваться",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                passTextBox2.Text = "Введите пароль";
                passTextBox2.ForeColor = Color.Gray;
                passTextBox2.UseSystemPasswordChar = false;
                passTextBoxRepeat.Text = "Повторите пароль";
                passTextBoxRepeat.ForeColor = Color.Gray;
                passTextBoxRepeat.UseSystemPasswordChar = false;
                return;
            }
            else if (passTextBox2.Text != passTextBoxRepeat.Text)
            {
                MessageBox.Show("Пароли не совпадают!", "Зарегистрироваться",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                passTextBox2.Text = "Введите пароль";
                passTextBox2.ForeColor = Color.Gray;
                passTextBox2.UseSystemPasswordChar = false;
                passTextBoxRepeat.Text = "Повторите пароль";
                passTextBoxRepeat.ForeColor = Color.Gray;
                passTextBoxRepeat.UseSystemPasswordChar = false;
                return;
            }
            else
            {
                String client_email = emailTextBox2.Text;

                DB db = new DB();

                DataTable table = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand myCom = new MySqlCommand("SELECT * FROM клиент WHERE Email = @em", db.getConnection());

                myCom.Parameters.Add("@em", MySqlDbType.VarChar).Value = client_email;

                dataAdapter.SelectCommand = myCom;
                dataAdapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Такой пользователь уже существует!", "Зарегистрироваться",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                }
                else
                // процесс регистрации
                {
                    try
                    {
                        MySqlCommand comm_insert_client =
                            new MySqlCommand("INSERT INTO клиент (Email, Пароль) VALUES (@ce, @pw);",
                            db.getConnection());
                        comm_insert_client.Parameters.Add("@ce", MySqlDbType.VarChar).Value = client_email;
                        comm_insert_client.Parameters.Add("@pw", MySqlDbType.VarChar).Value = passTextBox2.Text;

                        db.OpenConnection();

                        if (comm_insert_client.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Регистрация прошла успешно", "Зарегистрироваться",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);

                            ClientForm form = new ClientForm();
                            form.ShowDialog();
                        }
                        else
                            MessageBox.Show("Регистрация не была совершена", "Зарегистрироваться",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);

                        db.CloseConnection();
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
                    }
                }
            }
        }
    }
}
