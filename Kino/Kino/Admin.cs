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

            dateTimePickerShedule.MinDate = DateTime.Today;
            dateTimePickerShedule.MaxDate = dateTimePickerShedule.MinDate.AddDays(29);

            buttonUpdate.Select();

            //dataGridViewShedule.Enabled = false;
            //dataGridViewShedule.AllowDrop = false;

            //if (dataGridViewShedule.Rows.Count >= 5)
            //dataGridViewShedule.AllowUserToAddRows = false;
            //dataGridViewShedule.allo

            dataGridViewShedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShedule.MultiSelect = false;
            dataGridViewShedule.BackgroundColor = Color.WhiteSmoke;

            outputSheduleForAdmin();
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
            dataGridViewShedule.Columns[2].Width = 60;
            dataGridViewShedule.Columns[3].Width = 85;

            //dataGridViewShedule.Columns[0].HeaderText = "№";
            dataGridViewShedule.Columns[1].HeaderText = "Название фильма";
            dataGridViewShedule.Columns[3].HeaderText = "Цена, руб";

            dataGridViewShedule.ScrollBars = ScrollBars.Vertical;

            dataGridViewShedule.Columns[0].ReadOnly = true;
            dataGridViewShedule.Columns[3].ReadOnly = true;

            for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
            {
                dataGridViewShedule.Columns[i].Resizable = DataGridViewTriState.False;
                dataGridViewShedule.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridViewShedule.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dataGridViewShedule.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            dataGridViewShedule.Columns[0].Visible = false;
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
            if (e.ColumnIndex == 0)
                MessageBox.Show("Недопустимое название фильма!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            else if (e.ColumnIndex == 1)
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
            }

            // ПРОВЕРИТЬ БУДЕТ ЛИ ДОСТУПНА НОВАЯ ДОБАВЛЕННАЯ ЯЧЕЙКА ДЛЯ РЕДАКТИРОВАНИЯ
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;

            //dataGridViewShedule.SelectedRows
            int numStr = dataGridViewShedule.CurrentCell.RowIndex;

            dataGridViewShedule.Rows[numStr].Cells[1].ReadOnly = false;
            dataGridViewShedule.Rows[numStr].Cells[2].ReadOnly = false;

            


        }

        private void dateTimePickerShedule_ValueChanged(object sender, EventArgs e)
        {
            outputSheduleForAdmin();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            outputSheduleForAdmin();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // объявляем все ячейки недоступными для редактирования
            for (int i = 0; i < dataGridViewShedule.RowCount; i++)
                for (int j = 0; j < dataGridViewShedule.ColumnCount; j++)
                    dataGridViewShedule.Rows[i].Cells[j].ReadOnly = true;


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

                // Делать АПДЕЙТ для названия и времени с str !!!!!

                DB db = new DB();

                DataTable table = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand myCom = new MySqlCommand("SELECT Название FROM Фильм", db.getConnection());

                //myCom.Parameters.Add("@em", MySqlDbType.VarChar).Value = client_email;

                dataAdapter.SelectCommand = myCom;
                dataAdapter.Fill(table);

                // помещаем таблицу в новый DataGrid
                DataGridView helpDGV = new DataGridView();
                helpDGV.DataSource = table;

                // Сравнение, что в БД уже есть фильм с названием, как отредактированное
                for (int i = 0; i < helpDGV.RowCount; i++)
                    if (str[1] == helpDGV.Rows[i].Cells[0].ToString())
                    {
                        MessageBox.Show("Такое название для фильма уже существует!",
                            "Редактирование названия",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);

                        // как-то очистить ячейку с некорректным названием фильма???

                        return;
                    }

                //if (table.Rows.Count > 0)
                //{}
                //else
                // процесс апдейта названия фильма
                //{
                    try
                    {
                        MySqlCommand commUpdateNameFilm =
                            new MySqlCommand("CALL updateFilm(@numberFilm, @newName);",
                            db.getConnection());
                        commUpdateNameFilm.Parameters.Add("@numberFilm", MySqlDbType.Int32).Value = str[0];
                        commUpdateNameFilm.Parameters.Add("@newName", MySqlDbType.VarChar).Value = str[1];

                        db.OpenConnection();

                        if (commUpdateNameFilm.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Мы успешно поменяли название фильма!",
                                "Редактирование названия",
                            MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        }
                        else
                            MessageBox.Show("Название не может быть изменено :(",
                                "Редактирование названия",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);

                        db.CloseConnection();
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.ToString());
                    }
                //}
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

                // Делать АПДЕЙТ для названия и времени с str1 !!!!!
                // Делать АПДЕЙТ для названия и времени с str2 !!!!!
            }
        }
    }
}
