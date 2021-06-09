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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            // ВКЛАДКА РЕДАКТИРОВАНИЕ РАСПИСАНИЯ

            dateTimePickerShedule.MinDate = DateTime.Today;
            dateTimePickerShedule.MaxDate = dateTimePickerShedule.MinDate.AddDays(29);

            buttonUpdate.Select();

            dataGridViewShedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShedule.MultiSelect = false;
            dataGridViewShedule.BackgroundColor = Color.WhiteSmoke;

            outputSheduleForAdmin();

            // ВКЛАДКА ДОБАВЛЕНИЕ ФИЛЬМА

            comboBoxAgeLimit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAgeLimit.MaxDropDownItems = 5;

            comboBoxAgeLimit.Items.Add("0+");
            comboBoxAgeLimit.Items.Add("6+");
            comboBoxAgeLimit.Items.Add("12+");
            comboBoxAgeLimit.Items.Add("16+");
            comboBoxAgeLimit.Items.Add("18+");
            comboBoxAgeLimit.SelectedIndex = 0;
        }

        public void outputSheduleForAdmin()
        {
            string yDate = dateFromFormToString(dateTimePickerShedule.Value);

            DB db = new DB();
            MySqlCommand myCom = new MySqlCommand("CALL sheduleForAdmin(@ydate);",
                db.getConnection());
            myCom.Parameters.Add("@ydate", MySqlDbType.Date).Value = yDate;

            db.OpenConnection();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridViewShedule.DataSource = table;

            db.CloseConnection();

            dataGridViewShedule.AllowUserToResizeRows = false;

            //dataGridViewShedule.Columns[0].Width = 35;
            dataGridViewShedule.Columns[1].Width = 140;
            dataGridViewShedule.Columns[3].Width = 60;
            dataGridViewShedule.Columns[4].Width = 85;

            //dataGridViewShedule.Columns[0].HeaderText = "№";
            dataGridViewShedule.Columns[1].HeaderText = "Название фильма";
            dataGridViewShedule.Columns[4].HeaderText = "Цена, руб";

            dataGridViewShedule.ScrollBars = ScrollBars.Vertical;

            dataGridViewShedule.Columns[1].ReadOnly = true;
            dataGridViewShedule.Columns[4].ReadOnly = true;

            for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
            {
                dataGridViewShedule.Columns[i].Resizable = DataGridViewTriState.False;
                dataGridViewShedule.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridViewShedule.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridViewShedule.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            dataGridViewShedule.Columns[0].Visible = false;
            dataGridViewShedule.Columns[2].Visible = false;

            if (dataGridViewShedule.Rows.Count >= 6)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
        }

        public string dateFromFormToString(DateTime yDate)
        {
            int intYear = yDate.Year;
            int intMonth = yDate.Month;
            int intDay = yDate.Day;
            string strYear = String.Concat(intYear, '-');
            string strMonth = intMonth.ToString();
            string strDay = intDay.ToString();
            if (strMonth.Length == 1)
                strMonth = String.Concat('0', strMonth);
            if (strDay.Length == 1)
                strDay = String.Concat('0', strDay);
            string result = String.Concat(strYear, strMonth, '-', strDay);
            return result;
        }

        private void dataGridViewShedule_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 1)
                MessageBox.Show("Недопустимое название фильма!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            else if (e.ColumnIndex == 3)
                MessageBox.Show("Недопустимое значение для времени! " +
                    "Пожалуйста, введите время в следующем формате: \"ЧЧ:ММ\".", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Error happened " + e.Context.ToString() + e.ColumnIndex);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            if (dataGridViewShedule.Rows.Count < 6)
            {
                dataGridViewShedule.AllowUserToAddRows = true;

                for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                    for (int j = 0; j < dataGridViewShedule.ColumnCount-1; j++)
                        dataGridViewShedule.Rows[i].Cells[j].ReadOnly = false;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            //dataGridViewShedule.SelectedRows
            int numStr = dataGridViewShedule.CurrentCell.RowIndex;

            //dataGridViewShedule.Rows[numStr].Cells[1].ReadOnly = false;
            dataGridViewShedule.Rows[numStr].Cells[3].ReadOnly = false;
        }

        private void dateTimePickerShedule_ValueChanged(object sender, EventArgs e)
        {
            outputSheduleForAdmin();

            // закрываем все ячейки для редактрования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            dataGridViewShedule.AllowUserToAddRows = false;

            if (dataGridViewShedule.RowCount == 0)
            {
                buttonEdit.Enabled = false;
                buttonSaveEdit.Enabled = false;
                buttonDeleteSave.Enabled = false;

                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;

                dataGridViewShedule.AllowUserToAddRows = true;
            }
            else if (dataGridViewShedule.RowCount > 0 && dataGridViewShedule.RowCount < 6)
            {
                buttonEdit.Enabled = true;
                buttonSaveEdit.Enabled = true;
                buttonDeleteSave.Enabled = true;

                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;

                dataGridViewShedule.AllowUserToAddRows = true;
            }
            else if (dataGridViewShedule.RowCount >= 6)
            {
                buttonEdit.Enabled = true;
                buttonSaveEdit.Enabled = true;
                buttonDeleteSave.Enabled = true;

                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;

                dataGridViewShedule.AllowUserToAddRows = false;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            outputSheduleForAdmin();

            dataGridViewShedule.AllowUserToAddRows = false;

            if (dataGridViewShedule.RowCount == 0)
            {
                buttonEdit.Enabled = false;
                buttonSaveEdit.Enabled = false;
                buttonDeleteSave.Enabled = false;

                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;

                dataGridViewShedule.AllowUserToAddRows = true;
            }
            else if (dataGridViewShedule.RowCount > 0 && dataGridViewShedule.RowCount < 6)
            {
                buttonEdit.Enabled = true;
                buttonSaveEdit.Enabled = true;
                buttonDeleteSave.Enabled = true;

                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;

                dataGridViewShedule.AllowUserToAddRows = true;
            }
            else if (dataGridViewShedule.RowCount >= 6)
            {
                buttonEdit.Enabled = true;
                buttonSaveEdit.Enabled = true;
                buttonDeleteSave.Enabled = true;

                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;

                dataGridViewShedule.AllowUserToAddRows = false;
            }
            else
            {
                buttonEdit.Enabled = false;
                buttonSaveEdit.Enabled = false;
                buttonDeleteSave.Enabled = false;

                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;

                dataGridViewShedule.AllowUserToAddRows = false;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;
        }

        private void buttonSaveEdit_Click(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            // получаем номер выделенной строки
            int numStr = dataGridViewShedule.CurrentCell.RowIndex;

            if (numStr == 0)
            {
                string[] str = new string[dataGridViewShedule.ColumnCount];

                // кладем в массив строк выделенную строку в DataGridView
                for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                {
                    str[i] = dataGridViewShedule[i, numStr].Value.ToString();
                }

                DB db = new DB();

                try
                {
                    db.OpenConnection();

                    MySqlCommand commUpdateTimeFilm =
                    new MySqlCommand("CALL update_сеанс_время(@newTime, @numberTime);",
                    db.getConnection());

                    commUpdateTimeFilm.Parameters.AddWithValue("newTime", str[3]);
                    commUpdateTimeFilm.Parameters.AddWithValue("numberTime", str[2]);

                    commUpdateTimeFilm.ExecuteNonQuery();

                    if (commUpdateTimeFilm.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Время показа фильма было успешно изменено.",
                            "Редактирование времени показа",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Недопустимое значение для времени.",
                            "Редактирование времени показа",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }

                    db.CloseConnection();
                }
                catch (Exception e1)
                {
                    //MessageBox.Show(e1.ToString());

                    //MessageBox.Show("Тут что-то не так со временем",
                    //"Редактирование времени",
                    //MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    //MessageBoxDefaultButton.Button1);

                    MessageBox.Show("Недопустимое значение для времени.",
                        "Редактирование времени показа",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    //dataGridViewShedule.Rows.RemoveAt()
                    db.CloseConnection();
                }
            }
            else
            {
                string[] str1 = new string[dataGridViewShedule.ColumnCount];
                string[] str2 = new string[dataGridViewShedule.ColumnCount];

                // считываем редактированные данные в массив строк
                for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                {
                    str1[i] = dataGridViewShedule[i, numStr - 1].Value.ToString();
                }

                // считываем редактированные данные в массив строк
                for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                {
                    str2[i] = dataGridViewShedule[i, numStr].Value.ToString();
                }

                DB db = new DB();

                try
                {
                    db.OpenConnection();

                    MySqlCommand commUpdateTimeFilm1 =
                    new MySqlCommand("CALL update_сеанс_время(@newTime, @numberTime);",
                    db.getConnection());

                    commUpdateTimeFilm1.Parameters.AddWithValue("newTime", str1[3]);
                    commUpdateTimeFilm1.Parameters.AddWithValue("numberTime", str1[2]);

                    MySqlCommand commUpdateTimeFilm2 =
                    new MySqlCommand("CALL update_сеанс_время(@newTime, @numberTime);",
                    db.getConnection());

                    commUpdateTimeFilm2.Parameters.AddWithValue("newTime", str2[3]);
                    commUpdateTimeFilm2.Parameters.AddWithValue("numberTime", str2[2]);

                    if (commUpdateTimeFilm1.ExecuteNonQuery() == 1 && commUpdateTimeFilm2.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Время показа фильма было успешно изменено.",
                            "Редактирование времени показа",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Недопустимое значение для времени.",
                            "Редактирование времени показа",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }

                    db.CloseConnection();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Недопустимое значение для времени.",
                        "Редактирование времени показа",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    db.CloseConnection();
                }
            }
            if (dataGridViewShedule.RowCount < 6)
            {
                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;
            }
        }

        private void buttonDeleteSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewShedule.SelectedRows.Count > 0)
            {
                // получаем номер выделенной строки
                int numStr = dataGridViewShedule.CurrentCell.RowIndex;

                string[] str = new string[dataGridViewShedule.ColumnCount];

                // кладем в массив строк выделенную строку в DataGridView
                for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                    str[i] = dataGridViewShedule[i, numStr].Value.ToString();

                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить",
                    "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        DB db = new DB();
                        MySqlCommand myCom = new MySqlCommand("DELETE FROM сеанс_время WHERE id_сеанс_время = @id",
                            db.getConnection());
                        myCom.Parameters.AddWithValue("id", str[2]);

                        db.OpenConnection();
                        myCom.ExecuteNonQuery();
                        db.CloseConnection();

                        MessageBox.Show("Сеанс был успешно удален.", "Удаление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        outputSheduleForAdmin();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
            }

            if (dataGridViewShedule.RowCount < 6)
            {
                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;
            }
        }

        private void dataGridViewShedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewShedule.RowCount > 0)
            {
                buttonEdit.Enabled = true;
                buttonSaveEdit.Enabled = true;
                buttonDeleteSave.Enabled = true;
            }

            if (dataGridViewShedule.RowCount >= 6)
            {
                dataGridViewShedule.AllowUserToAddRows = false;

                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
        }

        private void dataGridViewShedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewShedule.RowCount > 0)
            {
                buttonEdit.Enabled = true;
                buttonSaveEdit.Enabled = true;
                buttonDeleteSave.Enabled = true;
            }
        }

        private void buttonAddSave_Click(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            MessageBox.Show("Данные были успешно добавлены.", "Добавление",
                MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите название фильма!", "Добавить фильм",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            else if (textBoxDescription.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите описание фильма!", "Добавить фильм",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            else if (textBoxDescription.Text.Length >= 750)
            {
                MessageBox.Show("Слишком большое описание фильма. Пожалуйста, введите менее 750 знаков.",
                    "Добавить фильм",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                string filmName = textBoxName.Text;
                string filmDescription = textBoxDescription.Text;
                string ageLimit = comboBoxAgeLimit.Text;

                DB db = new DB();

                if (textBoxPeriod.Text == "" || textBoxPoster.Text == "")
                {
                    // ПРОВЕРИТЬ НА ПУСТОТУ ПО ОДИНОЧКЕ

                    if (textBoxPeriod.Text == "")
                    {
                        DataTable table = new DataTable();
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                        MySqlCommand myCom = new MySqlCommand("SELECT * FROM фильм WHERE Название = @name", db.getConnection());

                        myCom.Parameters.Add("@name", MySqlDbType.VarChar).Value = filmName;

                        dataAdapter.SelectCommand = myCom;
                        dataAdapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Фильм с таким названием уже существует!", "Добавить фильм",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            // делаем запрос на добавление в БД Названия, Описания, Возраста, Постера
                            MySqlCommand myCom2 =
                                new MySqlCommand("INSERT INTO Фильм (Название, Описание, Возрастное_огр, Постер) VALUES (@name, @desc, @age, @poster);",
                                db.getConnection());

                            string poster = textBoxPoster.Text;

                            myCom2.Parameters.AddWithValue("name", filmName);
                            myCom2.Parameters.AddWithValue("desc", filmDescription);
                            myCom2.Parameters.AddWithValue("age", ageLimit);
                            myCom2.Parameters.AddWithValue("poster", poster);

                            db.OpenConnection();

                            try
                            {
                                if (myCom2.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Фильм был успешно добавлен.", "Добавить фильм",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1);
                                    db.CloseConnection();

                                    textBoxName.Text = "";
                                    textBoxDescription.Text = "";
                                    textBoxPeriod.Text = "";
                                    textBoxPoster.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось добавить фильм.", "Добавить фильм",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                    db.CloseConnection();
                                }
                            }
                            catch (Exception e1)
                            {
                                MessageBox.Show(e1.Message, "Добавить фильм",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    else if (textBoxPoster.Text == "")
                    {
                        DataTable table = new DataTable();
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                        MySqlCommand myCom = new MySqlCommand("SELECT * FROM фильм WHERE Название = @name", db.getConnection());

                        myCom.Parameters.Add("@name", MySqlDbType.VarChar).Value = filmName;

                        dataAdapter.SelectCommand = myCom;
                        dataAdapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Фильм с таким названием уже существует!", "Добавить фильм",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            // делаем запрос на добавление в БД Названия, Описания, Возраста, Продолжительности
                            string strPeriod = textBoxPeriod.Text;
                            int intPeriod;
                            if (int.TryParse(strPeriod, out intPeriod))
                            {
                                if (intPeriod >= 60 && intPeriod <= 130)
                                {
                                    MySqlCommand myCom2 =
                                        new MySqlCommand("INSERT INTO Фильм (Название, Описание, Возрастное_огр, Продолжительность) VALUES (@name, @desc, @age, @period);",
                                        db.getConnection());

                                    myCom2.Parameters.AddWithValue("name", filmName);
                                    myCom2.Parameters.AddWithValue("desc", filmDescription);
                                    myCom2.Parameters.AddWithValue("age", ageLimit);
                                    myCom2.Parameters.AddWithValue("period", strPeriod);

                                    db.OpenConnection();

                                    try
                                    {
                                        if (myCom2.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Фильм был успешно добавлен.", "Добавить фильм",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1);
                                            db.CloseConnection();

                                            textBoxName.Text = "";
                                            textBoxDescription.Text = "";
                                            textBoxPeriod.Text = "";
                                            textBoxPoster.Text = "";
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не удалось добавить фильм.", "Добавить фильм",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                                MessageBoxDefaultButton.Button1);
                                                db.CloseConnection();
                                        }
                                    }
                                    catch (Exception e1)
                                    {
                                        MessageBox.Show(e1.Message, "Добавить фильм",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, введите продолжительность фильма от 60 до 130 минут.",
                                    "Добавить фильм",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пожалуйста, введите продолжительность фильма в виде числа. " +
                                    "Продолжительность должна быть от 60 до 130 минут.", "Добавить фильм",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                                textBoxPeriod.Text = "";
                            }
                        }
                    }
                    else
                    {
                        DataTable table = new DataTable();
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                        MySqlCommand myCom = new MySqlCommand("SELECT * FROM фильм WHERE Название = @name", db.getConnection());

                        myCom.Parameters.Add("@name", MySqlDbType.VarChar).Value = filmName;

                        dataAdapter.SelectCommand = myCom;
                        dataAdapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Фильм с таким названием уже существует!", "Добавить фильм",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            MySqlCommand myCom2 =
                                new MySqlCommand("INSERT INTO Фильм (Название, Описание, Возрастное_огр) VALUES (@name, @desc, @age);",
                                db.getConnection());

                            myCom2.Parameters.AddWithValue("name", filmName);
                            myCom2.Parameters.AddWithValue("desc", filmDescription);
                            myCom2.Parameters.AddWithValue("age", ageLimit);

                            db.OpenConnection();

                            try
                            {
                                if (myCom2.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Фильм был успешно добавлен.", "Добавить фильм",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1);
                                    db.CloseConnection();

                                    textBoxName.Text = "";
                                    textBoxDescription.Text = "";
                                    textBoxPeriod.Text = "";
                                    textBoxPoster.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось добавить фильм.", "Добавить фильм",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                    db.CloseConnection();
                                }
                            }
                            catch (Exception e1)
                            {
                                MessageBox.Show(e1.Message, "Добавить фильм",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
                else
                {
                    string strPeriod = textBoxPeriod.Text;
                    int intPeriod;
                    if (int.TryParse(strPeriod, out intPeriod))
                    {
                        if (intPeriod >= 60 && intPeriod <= 130)
                        {
                            DataTable table = new DataTable();
                            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                            MySqlCommand myCom = new MySqlCommand("SELECT * FROM фильм WHERE Название = @name", db.getConnection());

                            myCom.Parameters.Add("@name", MySqlDbType.VarChar).Value = filmName;

                            dataAdapter.SelectCommand = myCom;
                            dataAdapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Фильм с таким названием уже существует!", "Добавить фильм",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                string poster = String.Concat(textBoxPoster.Text, ".jpg");

                                MySqlCommand myCom2 =
                                new MySqlCommand("INSERT INTO Фильм (Название, Описание, Возрастное_огр, Продолжительность, Постер) VALUES (@name, @desc, @age, @period, @poster);",
                                db.getConnection());

                                myCom2.Parameters.AddWithValue("name", filmName);
                                myCom2.Parameters.AddWithValue("desc", filmDescription);
                                myCom2.Parameters.AddWithValue("age", ageLimit);
                                myCom2.Parameters.AddWithValue("period", intPeriod);
                                myCom2.Parameters.AddWithValue("poster", poster);

                                db.OpenConnection();

                                try
                                {
                                    if (myCom2.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Фильм был успешно добавлен.", "Добавить фильм",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                                            MessageBoxDefaultButton.Button1);
                                        db.CloseConnection();

                                        textBoxName.Text = "";
                                        textBoxDescription.Text = "";
                                        textBoxPeriod.Text = "";
                                        textBoxPoster.Text = "";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Не удалось добавить фильм.", "Добавить фильм",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                        db.CloseConnection();
                                    }
                                }
                                catch (Exception e1)
                                {
                                    MessageBox.Show(e1.Message, "Добавить фильм",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, введите продолжительность фильма от 60 до 130 минут.", 
                                "Добавить фильм",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите продолжительность фильма в виде числа. " +
                            "Продолжительность должна быть от 60 до 130 минут.", "Добавить фильм",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        textBoxPeriod.Text = "";
                    }
                }
            }
        }
    }
}
