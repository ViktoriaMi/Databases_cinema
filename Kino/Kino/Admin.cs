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
            buttonAddSave.Enabled = false;
            if (dataGridViewShedule.RowCount < 1)
            {
                buttonEdit.Enabled = false;
                buttonSaveEdit.Enabled = false;
                buttonDeleteSave.Enabled = false;
            }
            else if (dataGridViewShedule.RowCount == 6)
            {
                string[] str = new string[dataGridViewShedule.Columns.Count];

                // кладем в массив строк выделенную строку в DataGridView
                for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                    str[i] = dataGridViewShedule[i, 5].Value.ToString();

                if (str[1] == "" || str[3] == "")
                {
                    dataGridViewShedule.AllowUserToAddRows = false;
                    buttonAdd.Enabled = false;
                    buttonAddSave.Enabled = true;
                }
                else
                {
                    buttonAddSave.Enabled = false;
                }
            }
            else
            {
                buttonAddSave.Enabled = false;
            }
            DateTime tomorrow = DateTime.Today, dayAfterTomorrow = DateTime.Today;
            tomorrow = tomorrow.AddDays(1);
            dayAfterTomorrow = dayAfterTomorrow.AddDays(2);
            if (dateTimePickerShedule.Value == DateTime.Today || dateTimePickerShedule.Value == tomorrow
                || dateTimePickerShedule.Value == dayAfterTomorrow)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }

            // ВКЛАДКА ДОБАВЛЕНИЕ ФИЛЬМА

            comboBoxAgeLimit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAgeLimit.MaxDropDownItems = 5;

            comboBoxAgeLimit.Items.Add("0+");
            comboBoxAgeLimit.Items.Add("6+");
            comboBoxAgeLimit.Items.Add("12+");
            comboBoxAgeLimit.Items.Add("16+");
            comboBoxAgeLimit.Items.Add("18+");
            comboBoxAgeLimit.SelectedIndex = 0;

            // ВКЛАДКА РЕДАКТИРОВАНИЕ ФИЛЬМА
            comboBoxChooseFilm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChooseFilm.Sorted = false;
            comboBoxEditAge.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxEditAge.MaxDropDownItems = 5;

            comboBoxEditAge.Items.Add("0+");
            comboBoxEditAge.Items.Add("6+");
            comboBoxEditAge.Items.Add("12+");
            comboBoxEditAge.Items.Add("16+");
            comboBoxEditAge.Items.Add("18+");
            comboBoxEditAge.SelectedIndex = 0;

            // отключаем описание, флажок, новое имя
            textBoxEditDescription.Enabled = false;
            checkBox.Enabled = false;
            textBoxNewName.Enabled = false;
            // отключаем возраст, продолжительность, постер
            comboBoxEditAge.Enabled = false;
            textBoxEditPeriod.Enabled = false;
            textBoxEditPoster.Enabled = false;

            fillingComboBoxChooseFilm();
            string[] info = getAllInfoAboutFilmFromDB(comboBoxChooseFilm.Text);
            fillingFields(info);
            enableFields();

            // ВКЛАДКА УДАЛЕНИЕ ФИЛЬМА

            fillingGridForRemove();
            dataGridViewRemoveFilm.BackgroundColor = Color.WhiteSmoke;
            dataGridViewRemoveFilm.ScrollBars = ScrollBars.Vertical;
            dataGridViewRemoveFilm.AllowDrop = false;
            dataGridViewRemoveFilm.AllowUserToResizeColumns = false;
            foreach (DataGridViewColumn column in dataGridViewRemoveFilm.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewRemoveFilm.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRemoveFilm.MultiSelect = false;
            dataGridViewRemoveFilm.Columns[0].Visible = false;
            dataGridViewRemoveFilm.Columns[1].Width = 270;
            dataGridViewRemoveFilm.Height = 260;
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

            dataGridViewShedule.Columns[1].Width = 140;
            dataGridViewShedule.Columns[3].Width = 60;
            dataGridViewShedule.Columns[4].Width = 85;

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

            //foreach (DataGridViewColumn column in dataGridViewShedule.Columns)
                //column.SortMode = DataGridViewColumnSortMode.NotSortable;

            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            dataGridViewShedule.Columns[0].Visible = false;
            dataGridViewShedule.Columns[2].Visible = false;

            DateTime tomorrow = DateTime.Today, dayAfterTomorrow = DateTime.Today;
            tomorrow = tomorrow.AddDays(1);
            dayAfterTomorrow = dayAfterTomorrow.AddDays(2);
            if (dateTimePickerShedule.Value == DateTime.Today || dateTimePickerShedule.Value == tomorrow
                || dateTimePickerShedule.Value == dayAfterTomorrow)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
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
            buttonAddSave.Enabled = true;

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

            if (dataGridViewShedule.CurrentCell == null)
            {
                MessageBox.Show("Нельзя редактировать пустую строку. " +
                    "Пожалуйста, выберите строку или добавьте новый сеанс.",
                    "Редактирование",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                int numStr = dataGridViewShedule.CurrentCell.RowIndex;

                //dataGridViewShedule.Rows[numStr].Cells[1].ReadOnly = false;
                dataGridViewShedule.Rows[numStr].Cells[3].ReadOnly = false;
            }
            //dataGridViewShedule.SelectedRows
        }

        private void dateTimePickerShedule_ValueChanged(object sender, EventArgs e)
        {
            outputSheduleForAdmin();

            // закрываем все ячейки для редактрования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            dataGridViewShedule.AllowUserToAddRows = false;

            DateTime tomorrow = DateTime.Today, dayAfterTomorrow = DateTime.Today;
            tomorrow = tomorrow.AddDays(1);
            dayAfterTomorrow = dayAfterTomorrow.AddDays(2);
            if (dateTimePickerShedule.Value == DateTime.Today || dateTimePickerShedule.Value == tomorrow
                || dateTimePickerShedule.Value == dayAfterTomorrow)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
            else
            {
                if (dataGridViewShedule.RowCount == 0)
                {
                    buttonEdit.Enabled = false;
                    buttonSaveEdit.Enabled = false;
                    buttonDeleteSave.Enabled = false;

                    buttonAdd.Enabled = true;
                    buttonAddSave.Enabled = false;

                    dataGridViewShedule.AllowUserToAddRows = true;
                }
                else if (dataGridViewShedule.RowCount > 0 && dataGridViewShedule.RowCount < 6)
                {
                    buttonEdit.Enabled = true;
                    buttonSaveEdit.Enabled = true;
                    buttonDeleteSave.Enabled = true;

                    buttonAdd.Enabled = true;
                    buttonAddSave.Enabled = false;

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
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            outputSheduleForAdmin();
            DateTime tomorrow = DateTime.Today, dayAfterTomorrow = DateTime.Today;
            tomorrow = tomorrow.AddDays(1);
            dayAfterTomorrow = dayAfterTomorrow.AddDays(2);
            if (dateTimePickerShedule.Value == DateTime.Today || dateTimePickerShedule.Value == tomorrow
                || dateTimePickerShedule.Value == dayAfterTomorrow)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
            else
            {
                dataGridViewShedule.AllowUserToAddRows = false;

                if (dataGridViewShedule.RowCount == 0)
                {
                    buttonEdit.Enabled = false;
                    buttonSaveEdit.Enabled = false;
                    buttonDeleteSave.Enabled = false;

                    buttonAdd.Enabled = true;
                    buttonAddSave.Enabled = false;

                    dataGridViewShedule.AllowUserToAddRows = true;
                }
                else if (dataGridViewShedule.RowCount > 0 && dataGridViewShedule.RowCount < 6)
                {
                    buttonEdit.Enabled = true;
                    buttonSaveEdit.Enabled = true;
                    buttonDeleteSave.Enabled = true;

                    buttonAdd.Enabled = true;
                    buttonAddSave.Enabled = false;

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

            if (dataGridViewShedule.CurrentCell == null)
            {
                MessageBox.Show("Нельзя редактировать пустую строку. " +
                    "Пожалуйста, выберите строку или добавьте новый сеанс.",
                    "Редактирование",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
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
                if (dataGridViewShedule.CurrentCell == null)
                {
                    if (dataGridViewShedule.SelectedRows.Count == 1)
                    {
                        buttonEdit.Enabled = false;
                        buttonSaveEdit.Enabled = false;
                        buttonDeleteSave.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Нельзя удалить пустую строку.", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // получаем номер выделенной строки
                    int numStr = dataGridViewShedule.CurrentCell.RowIndex;

                    string[] str = new string[dataGridViewShedule.ColumnCount];

                    // кладем в массив строк выделенную строку в DataGridView
                    for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                        str[i] = dataGridViewShedule[i, numStr].Value.ToString();

                    try
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить.",
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

                            outputSheduleForAdmin();

                            MessageBox.Show("Сеанс был успешно удален.", "Удаление",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
                    }
                }
            }

            if (dataGridViewShedule.RowCount < 6)
            {
                buttonAdd.Enabled = true;
                buttonAddSave.Enabled = true;
                if (dataGridViewShedule.RowCount < 1)
                {
                    buttonEdit.Enabled = false;
                    buttonSaveEdit.Enabled = false;
                    buttonDeleteSave.Enabled = false;
                }
            }
        }

        private void dataGridViewShedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridViewShedule.RowCount > 0)
            //{
            //buttonEdit.Enabled = true;
            //buttonSaveEdit.Enabled = true;
            //buttonDeleteSave.Enabled = true;
            //}
            DateTime tomorrow = DateTime.Today, dayAfterTomorrow = DateTime.Today;
            tomorrow = tomorrow.AddDays(1);
            dayAfterTomorrow = dayAfterTomorrow.AddDays(2);
            if (dateTimePickerShedule.Value == DateTime.Today || dateTimePickerShedule.Value == tomorrow
                || dateTimePickerShedule.Value == dayAfterTomorrow)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
            else
            {
                if (dataGridViewShedule.RowCount >= 6)
                {
                    if (dataGridViewShedule.RowCount == 6)
                    {
                        string[] str = new string[dataGridViewShedule.Columns.Count];

                        // кладем в массив строк выделенную строку в DataGridView
                        for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                            str[i] = dataGridViewShedule[i, 5].Value.ToString();

                        if (str[1] == "" || str[3] == "")
                        {
                            dataGridViewShedule.AllowUserToAddRows = false;
                            buttonAdd.Enabled = false;
                            buttonAddSave.Enabled = true;
                        }
                    }
                    else
                    {
                        dataGridViewShedule.AllowUserToAddRows = false;

                        buttonAdd.Enabled = false;
                        buttonAddSave.Enabled = false;
                    }
                }
            }
        }

        private void dataGridViewShedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime tomorrow = DateTime.Today, dayAfterTomorrow = DateTime.Today;
            tomorrow = tomorrow.AddDays(1);
            dayAfterTomorrow = dayAfterTomorrow.AddDays(2);
            if (dateTimePickerShedule.Value == DateTime.Today || dateTimePickerShedule.Value == tomorrow
                || dateTimePickerShedule.Value == dayAfterTomorrow)
            {
                buttonAdd.Enabled = false;
                buttonAddSave.Enabled = false;
            }
            else if (dataGridViewShedule.RowCount > 0)
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

            if (dataGridViewShedule.SelectedRows.Count < 1)
                MessageBox.Show("Пожалуйста, выберите строку для добавления.", "Добавление сеанса",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
            else if (dataGridViewShedule.CurrentCell == null)
            {
                MessageBox.Show("Пожалуйста, введите данные для добавления.", "Добавление сеанса",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                    for (int j = 0; j < dataGridViewShedule.ColumnCount-1; j++)
                        dataGridViewShedule.Rows[i].Cells[j].ReadOnly = false;
            }
            else
            {
                int numStr = dataGridViewShedule.CurrentCell.RowIndex;
                string[] str = new string[dataGridViewShedule.Columns.Count];

                // кладем в массив строк выделенную строку в DataGridView
                for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                    str[i] = dataGridViewShedule[i, numStr].Value.ToString();

                if (str[1] == "")
                {
                    MessageBox.Show("Пожалуйста, введите название фильма.", "Добавление сеанса",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                        for (int j = 0; j < dataGridViewShedule.ColumnCount - 1; j++)
                            dataGridViewShedule.Rows[i].Cells[j].ReadOnly = false;
                }
                else if (str[3] == "")
                {
                    MessageBox.Show("Пожалуйста, введите время сеанса.", "Добавление сеанса",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                    for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                        for (int j = 0; j < dataGridViewShedule.ColumnCount - 1; j++)
                            dataGridViewShedule.Rows[i].Cells[j].ReadOnly = false;
                }
                else
                {
                    if (TimeSpan.TryParse(str[3], out TimeSpan ts))
                    {
                        DB db = new DB();

                        DataTable table = new DataTable();
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                        MySqlCommand myCom = new MySqlCommand("CALL getNumFilm(@nameFilm);",
                            db.getConnection());

                        //myCom.Parameters.Add("@nameFilm", MySqlDbType.VarChar).Value = str[1];
                        myCom.Parameters.AddWithValue("nameFilm", str[1]);

                        dataAdapter.SelectCommand = myCom;
                        dataAdapter.Fill(table);

                        // если фильма с таким названием нет в БД
                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("Фильма с таким названием не существует, мы не можем добавить для него сеанс." +
                                "\nЧтобы добавить фильм, пожалуйста, перейдите на вкладку \"Добавление фильма\".", "Добавление сеанса",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                                for (int j = 0; j < dataGridViewShedule.ColumnCount - 1; j++)
                                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = false;
                        }
                        else
                        {
                            // ПРОВЕРКА НА ДИАПАЗОН ВРЕМЕНИ ОТ 09:00 до 23:59
                            TimeSpan tsFrom = new TimeSpan(8, 59, 0);
                            TimeSpan tsTo = new TimeSpan(0, 0, 0);
                            if (TimeSpan.Parse(str[3]) <= tsFrom && TimeSpan.Parse(str[3]) >= tsTo)
                            {
                                MessageBox.Show("Недопустимое начало сеанса. " +
                                    "Пожалуйста, укажите время в промежутке от 09:00 до 23:59.",
                                    "Добавление сеанса",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);

                                dataGridViewShedule.Rows[dataGridViewShedule.SelectedRows[0].Index].Cells[1].ReadOnly = false;
                                dataGridViewShedule.Rows[dataGridViewShedule.SelectedRows[0].Index].Cells[3].ReadOnly = false;
                            }
                            else
                            {
                                // Здесь начиналась бы проверка для трех значений цены:
                                // 180/200/220 в завис. от времени

                                string numberFilm = table.Rows[0].ItemArray[0].ToString();
                                string yDate = dateFromFormToString(dateTimePickerShedule.Value);

                                MySqlCommand myCom3 =
                                    new MySqlCommand("INSERT INTO Сеанс_дата (№_фильма, Дата) VALUES (@numFilm, @date);",
                                    db.getConnection());

                                string poster = textBoxPoster.Text;

                                myCom3.Parameters.AddWithValue("numFilm", numberFilm);
                                myCom3.Parameters.AddWithValue("date", yDate);

                                db.OpenConnection();

                                //try
                                //{
                                if (myCom3.ExecuteNonQuery() == 1)
                                {
                                    //MessageBox.Show("Мы добавили запись в сеанс_дату!!!", "Добавить сеанс",
                                    //MessageBoxButtons.OK, MessageBoxIcon.Information,
                                    //MessageBoxDefaultButton.Button1);
                                    db.CloseConnection();

                                    // пункт 3, получаем новый id_сеанс_дата
                                    DataTable table2 = new DataTable();
                                    MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter();
                                    MySqlCommand myCom4 = new MySqlCommand("SELECT MAX(id_сеанс_дата) FROM Сеанс_дата", db.getConnection());

                                    dataAdapter2.SelectCommand = myCom4;
                                    dataAdapter2.Fill(table2);

                                    string idSessionDate = table2.Rows[0].ItemArray[0].ToString();

                                    db.OpenConnection();
                                    ////////////////////////////////////////////////////////
                                    //else
                                    //{
                                    MySqlCommand commUpdateTimeSession =
                                        new MySqlCommand("CALL updTimeSession(@newTime, @numberTime);",
                                    db.getConnection());

                                    commUpdateTimeSession.Parameters.AddWithValue("newTime", str[3]);
                                    commUpdateTimeSession.Parameters.AddWithValue("numberTime", idSessionDate);

                                    try
                                    {
                                        if (commUpdateTimeSession.ExecuteNonQuery() == 2)
                                        {
                                            MessageBox.Show("Новый сеанс был успешно добавлен.",
                                                "Добавление сеанса",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1);

                                            buttonAddSave.Enabled = false;
                                        }
                                        //////////////////////////////////////////////////
                                        ///
                                        else
                                        {
                                            MessageBox.Show("При добавлении нового сеанса возникла ошибка. " +
                                                "Сеанс не был добавлен.",
                                                "Добавление сеанса",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                                MessageBoxDefaultButton.Button1);
                                        }
                                    }
                                    catch (Exception e1)
                                    {
                                        MessageBox.Show("Сеанс не был добавлен. Возможно допущена ошибка в формате ввода времени. " +
                                            "Введите время в виде: ЧЧ:ММ.",
                                            "Добавление сеанса",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    }
                                    //}
                                }
                                else
                                {
                                    MessageBox.Show("Упс! Мы не смогли добавить запись в табл. Сеанс_дата.",
                                        "Добавить сеанс", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                    db.CloseConnection();
                                }
                            }

                            if (dataGridViewShedule.RowCount > 6)
                            {
                                buttonAdd.Enabled = false;
                                buttonAddSave.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите значение времени в формате: \"ЧЧ:ММ\".",
                            "Добавление сеанса", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
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

        public void fillingGridForRemove()
        {
            DB db = new DB();

            MySqlCommand myCom = new MySqlCommand("SELECT №_фильма, Название FROM Фильм;",
                db.getConnection());

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            db.OpenConnection();

            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridViewRemoveFilm.DataSource = table;

            db.CloseConnection();
        }

        private void buttonUpdChanges_Click(object sender, EventArgs e)
        {
            fillingGridForRemove();
        }

        private void buttonRemoveFilm_Click(object sender, EventArgs e)
        {
            string[] str = new string[dataGridViewRemoveFilm.Columns.Count];

            // получаем номер выделенной строки
            int numStr = dataGridViewRemoveFilm.CurrentCell.RowIndex;

            // кладем в массив строк выделенную строку в DataGridView
            for (int i = 0; i < dataGridViewRemoveFilm.ColumnCount; i++)
                str[i] = dataGridViewRemoveFilm[i, numStr].Value.ToString();

            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить фильм? " +
                    "Это действие нельзя будет отменить.",
                    "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DB db = new DB();
                    MySqlCommand myCom = new MySqlCommand("DELETE FROM Фильм WHERE №_фильма = @id",
                        db.getConnection());
                    myCom.Parameters.AddWithValue("id", str[0]);

                    db.OpenConnection();
                    myCom.ExecuteNonQuery();
                    db.CloseConnection();

                    MessageBox.Show("Фильм был успешно удален.", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        public void fillingComboBoxChooseFilm(bool changeIndex = true)
        {
            comboBoxChooseFilm.Items.Clear();

            DB db = new DB();
            // получаем все названия фильмов
            MySqlCommand myCom = new MySqlCommand("SELECT Название FROM Фильм;",
                db.getConnection());

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            db.OpenConnection();

            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            db.CloseConnection();

            for (int i = 0; i < table.Rows.Count; i++)
                comboBoxChooseFilm.Items.Add(table.Rows[i][0].ToString());

            if (changeIndex == true)
                comboBoxChooseFilm.SelectedIndex = 0;
        }

        public string[] getAllInfoAboutFilmFromDB (string filmName, bool cropJPG = true)
        {
            //string filmName = comboBoxChooseFilm.Text;

            DB db = new DB();
            // получаем всю информацию о фильме с названием из combo-бокса
            MySqlCommand myCom = new MySqlCommand("CALL selectFilmFromName(@name);",
                db.getConnection());

            myCom.Parameters.AddWithValue("name", filmName);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            db.OpenConnection();

            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            db.CloseConnection();

            string[] infoAboutFilm = new string[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
                infoAboutFilm[i] = table.Rows[0][i].ToString();

            if (cropJPG)
            {
                if (infoAboutFilm[5] != "")
                {
                    // обрезаем окончание ".jpg"
                    infoAboutFilm[5] = infoAboutFilm[5].Substring(0, infoAboutFilm[5].Length - 4);
                }
            }

            return infoAboutFilm;
        }

        public void fillingFields (string[] strInfo)
        {
            // заполняем описание
            textBoxEditDescription.Text = strInfo[2];

            string[] ageCollection = new string[comboBoxEditAge.Items.Count];

            // заполняем возраст
            for (int i = 0; i < comboBoxEditAge.Items.Count; i++)
            {
                ageCollection[i] = comboBoxEditAge.Items[i].ToString();
                if (ageCollection[i] == strInfo[3])
                {
                    comboBoxEditAge.SelectedIndex = i;
                    break;
                }
            }

            // заполняем продолжительность
            textBoxEditPeriod.Text = strInfo[4];

            // заполняем постер
            textBoxEditPoster.Text = strInfo[5];
        }

        public void enableFields ()
        {
            // активируем флажок
            checkBox.Enabled = true;
            // активируем описание
            textBoxEditDescription.Enabled = true;
            // активируем возраст
            comboBoxEditAge.Enabled = true;
            // активируем продолжительность
            textBoxEditPeriod.Enabled = true;
            // активируем постер
            textBoxEditPoster.Enabled = true;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // если флажка нет
            if (checkBox.CheckState == CheckState.Unchecked)
            {
                textBoxNewName.Enabled = false;
                textBoxNewName.Text = "";
            }
            // если установлен флажок
            else if (checkBox.CheckState == CheckState.Checked)
            {
                textBoxNewName.Enabled = true;
            }
        }

        private void comboBoxChooseFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] info = getAllInfoAboutFilmFromDB(comboBoxChooseFilm.Text);
            fillingFields(info);
        }

        public void readingToStringWithOldName ()
        {
            string[] oldData = getAllInfoAboutFilmFromDB(comboBoxChooseFilm.Text, false);

            string numFilm = oldData[0];
            string newDesc = textBoxEditDescription.Text;
            string newAge = comboBoxEditAge.Text;
            string newPeriod = textBoxEditPeriod.Text;
            string newPoster = textBoxEditPoster.Text;

            if (newDesc.Length == 0)
            {
                MessageBox.Show("Описание фильма не может быть пустым. Пожалуйста, введите описание.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newPeriod.Length == 0)
            {
                MessageBox.Show("Продолжительность фильма не может быть пустой. " +
                    "Укажите старую продолжительность фильма или введите новую.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newPoster.Length == 0)
            {
                MessageBox.Show("Название постера не может быть пустым. " +
                    "Укажите старое название постера или введите название нового.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // проверки на корректность периода (что не буквы и допустимый диапазон)
            else if (checkCorrectPeriod(newPeriod) == -1)
            {
                MessageBox.Show("Пожалуйста, введите продолжительность фильма числом.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkCorrectPeriod(newPeriod) == -2)
            {
                MessageBox.Show("Пожалуйста, введите продолжительность фильма в диапазоне от 60 до 130 минут.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // если период введен правильно
            else if (checkCorrectPeriod(newPeriod) == 1)
            {
                // если название постера некорректно
                if (!checkCorrectPoster(newPoster))
                {
                    MessageBox.Show("Название постера не должно превышать 10 символов.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // постер корректный
                else if (checkCorrectPoster(newPoster))
                {
                    // добавляем расширение для постера ".jpg"
                    newPoster = newPoster + ".jpg";

                    // значит апдейтим данные в базе
                    DB db = new DB();

                    MySqlCommand myCom =
                    new MySqlCommand("UPDATE Фильм SET Описание = @desc, Возрастное_огр = @age, Продолжительность = @period, Постер = @poster WHERE №_фильма = @numFilm;",
                    db.getConnection());

                    myCom.Parameters.AddWithValue("numFilm", numFilm);
                    myCom.Parameters.AddWithValue("desc", newDesc);
                    myCom.Parameters.AddWithValue("age", newAge);
                    myCom.Parameters.AddWithValue("period", newPeriod);
                    myCom.Parameters.AddWithValue("poster", newPoster);

                    db.OpenConnection();

                    if (myCom.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Изменения были успешно сохранены.",
                            "Сохранить изменения",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось сохранить изменения.",
                            "Сохранить изменения",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        public void readingToStringWithNewName()
        {
            string[] oldData = getAllInfoAboutFilmFromDB(comboBoxChooseFilm.Text, false);

            string numFilm = oldData[0];
            string newName = textBoxNewName.Text;
            string newDesc = textBoxEditDescription.Text;
            string newAge = comboBoxEditAge.Text;
            string newPeriod = textBoxEditPeriod.Text;
            string newPoster = textBoxEditPoster.Text;

            if (newName.Length == 0)
            {
                MessageBox.Show("Название фильма не может быть пустым. " +
                    "Пожалуйста, введите новое название или уберите флажок из поля \"Редактировать название\".",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newDesc.Length == 0)
            {
                MessageBox.Show("Описание фильма не может быть пустым. Пожалуйста, введите описание.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newPeriod.Length == 0)
            {
                MessageBox.Show("Продолжительность фильма не может быть пустой. " +
                    "Укажите старую продолжительность фильма или введите новую.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newPoster.Length == 0)
            {
                MessageBox.Show("Название постера не может быть пустым. " +
                    "Укажите старое название постера или введите название нового.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newName.Length > 30)
            {
                MessageBox.Show("Слишком длинное название фильма. " +
                    "Пожалуйста, введите не более 30 символов.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // проверки на корректность периода (что не буквы и допустимый диапазон)
            else if (checkCorrectPeriod(newPeriod) == -1)
            {
                MessageBox.Show("Пожалуйста, введите продолжительность фильма числом.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkCorrectPeriod(newPeriod) == -2)
            {
                MessageBox.Show("Пожалуйста, введите продолжительность фильма в диапазоне от 60 до 130 минут.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkCorrectPeriod(newPeriod) == 1)
            {
                // если название постера некорректно
                if (!checkCorrectPoster(newPoster))
                {
                    MessageBox.Show("Название постера не должно превышать 10 символов.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // постер корректный
                else if (checkCorrectPoster(newPoster))
                {
                    // добавляем расширение для постера ".jpg"
                    newPoster = newPoster + ".jpg";

                    // значит апдейтим данные в базе
                    DB db = new DB();

                    MySqlCommand myCom =
                    new MySqlCommand("UPDATE Фильм SET Название = @name, Описание = @desc, Возрастное_огр = @age, Продолжительность = @period, Постер = @poster WHERE №_фильма = @numFilm;",
                    db.getConnection());

                    myCom.Parameters.AddWithValue("name", newName);
                    myCom.Parameters.AddWithValue("numFilm", numFilm);
                    myCom.Parameters.AddWithValue("desc", newDesc);
                    myCom.Parameters.AddWithValue("age", newAge);
                    myCom.Parameters.AddWithValue("period", newPeriod);
                    myCom.Parameters.AddWithValue("poster", newPoster);

                    db.OpenConnection();

                    if (myCom.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Изменения были успешно сохранены.",
                            "Сохранить изменения",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось сохранить изменения.",
                            "Сохранить изменения",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void buttonSaveEditing_Click(object sender, EventArgs e)
        {
            if (checkBox.Checked == false)
            {
                readingToStringWithOldName();
            }
            else if (checkBox.Checked == true)
            {
                string newName = textBoxNewName.Text;
                if (newName.Length == 0)
                {
                    MessageBox.Show("Название фильма не может быть пустым. " +
                    "Пожалуйста, введите новое название или уберите флажок из поля \"Редактировать название\".",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (newName.Length > 30)
                {
                    MessageBox.Show("Слишком длинное название фильма. " +
                    "Пожалуйста, введите не более 30 символов.",
                    "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string[] info = getAllInfoAboutFilmFromDB(comboBoxChooseFilm.Text, false);

                    string numFilm2 = info[0];

                    DB db = new DB();

                    MySqlCommand myCom =
                    new MySqlCommand("UPDATE Фильм SET Название = @name WHERE №_фильма = @numFilm;",
                    db.getConnection());

                    myCom.Parameters.AddWithValue("name", newName);
                    myCom.Parameters.AddWithValue("numFilm", numFilm2);

                    db.OpenConnection();

                    if (myCom.ExecuteNonQuery() == 1)
                    {
                        //MessageBox.Show("Название фильма было обновлено.",
                        //    "Сохранить изменения",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Information,
                        //    MessageBoxDefaultButton.Button1);

                        ///////////////////////////////////////////////////////////////////////////
                        string[] oldData = getAllInfoAboutFilmFromDB(newName, false);

                        string numFilm = oldData[0];
                        //string newName = textBoxNewName.Text;
                        string newDesc = textBoxEditDescription.Text;
                        string newAge = comboBoxEditAge.Text;
                        string newPeriod = textBoxEditPeriod.Text;
                        string newPoster = textBoxEditPoster.Text;

                        if (newName.Length == 0)
                        {
                            MessageBox.Show("Название фильма не может быть пустым. " +
                                "Пожалуйста, введите новое название или уберите флажок из поля \"Редактировать название\".",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (newDesc.Length == 0)
                        {
                            MessageBox.Show("Описание фильма не может быть пустым. Пожалуйста, введите описание.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (newPeriod.Length == 0)
                        {
                            MessageBox.Show("Продолжительность фильма не может быть пустой. " +
                                "Укажите старую продолжительность фильма или введите новую.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (newPoster.Length == 0)
                        {
                            MessageBox.Show("Название постера не может быть пустым. " +
                                "Укажите старое название постера или введите название нового.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (newName.Length > 30)
                        {
                            MessageBox.Show("Слишком длинное название фильма. " +
                                "Пожалуйста, введите не более 30 символов.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        // проверки на корректность периода (что не буквы и допустимый диапазон)
                        else if (checkCorrectPeriod(newPeriod) == -1)
                        {
                            MessageBox.Show("Пожалуйста, введите продолжительность фильма числом.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (checkCorrectPeriod(newPeriod) == -2)
                        {
                            MessageBox.Show("Пожалуйста, введите продолжительность фильма в диапазоне от 60 до 130 минут.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (checkCorrectPeriod(newPeriod) == 1)
                        {
                            // если название постера некорректно
                            if (!checkCorrectPoster(newPoster))
                            {
                                MessageBox.Show("Название постера не должно превышать 10 символов.",
                                "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            // постер корректный
                            else if (checkCorrectPoster(newPoster))
                            {
                                // добавляем расширение для постера ".jpg"
                                newPoster = newPoster + ".jpg";

                                // значит апдейтим данные в базе
                                db = new DB();

                                MySqlCommand myCom2 =
                                new MySqlCommand("UPDATE Фильм SET Название = @name, Описание = @desc, Возрастное_огр = @age, Продолжительность = @period, Постер = @poster WHERE №_фильма = @numFilm;",
                                db.getConnection());

                                myCom2.Parameters.AddWithValue("name", newName);
                                myCom2.Parameters.AddWithValue("numFilm", numFilm);
                                myCom2.Parameters.AddWithValue("desc", newDesc);
                                myCom2.Parameters.AddWithValue("age", newAge);
                                myCom2.Parameters.AddWithValue("period", newPeriod);
                                myCom2.Parameters.AddWithValue("poster", newPoster);

                                db.OpenConnection();

                                if (myCom2.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Изменения были успешно сохранены.",
                                        "Сохранить изменения",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1);

                                    // обновить comboBoxChooseFilm
                                    fillingComboBoxChooseFilm(false);

                                    // поставить выбранным эл-т по индексу
                                    // выбрать тот, у которого Text = newName
                                    for (int i = 0; i < comboBoxChooseFilm.Items.Count; i++)
                                        if (comboBoxChooseFilm.Items[i].ToString() == newName)
                                            comboBoxChooseFilm.SelectedIndex = i;

                                    checkBox.Checked = false;
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось сохранить изменения.",
                                        "Сохранить изменения",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                }
                            }
                        }
                        ///////////////////////////////////////////////////////////////////////////
                        //readingToStringWithNewName();
                    }
                    else
                    {
                        MessageBox.Show("Не получилось имя поменять!",
                            "Сохранить изменения",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        public int checkCorrectPeriod (string period)
        {
            if (int.TryParse(period, out int intPeriod))
            {
                // проверка допустимого диапазона для продолжительности
                if (intPeriod < 60 || intPeriod > 130)
                {
                    // продолжительность указана в недопустимом диапазоне
                    return -2;
                }
                else
                {
                    // а тут всё корректно
                    return 1;
                }
            }
            else
            {
                // не получилось преобразовать в Int, скорее всего ввели строку!
                return -1;
            }
        }

        public bool checkCorrectPoster (string poster)
        {
            if (poster.Length > 10)
                return false;
            else
                return true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            string[] info = getAllInfoAboutFilmFromDB(comboBoxChooseFilm.Text);
            fillingFields(info);

            checkBox.Checked = false;
            textBoxNewName.Text = "";
            textBoxNewName.Enabled = false;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillingComboBoxChooseFilm();
        }
    }
}
