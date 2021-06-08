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

            dataGridViewShedule.Columns[0].Width = 140;
            dataGridViewShedule.Columns[1].Width = 60;
            dataGridViewShedule.Columns[2].Width = 85;

            dataGridViewShedule.Columns[0].HeaderText = "Название фильма";
            //dataGridViewShedule.Columns[2].HeaderText = "Продолжительность, мин";
            dataGridViewShedule.Columns[2].HeaderText = "Цена, руб";

            //int sumWidthColumn = 0;
            //for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
            //    sumWidthColumn += dataGridViewShedule.Columns[i].Width;

            //int sumHeightRows = 0;
            //for (int i = 0; i < dataGridViewShedule.RowCount; i++)
            //    sumHeightRows += dataGridViewShedule.Rows[i].Height;

            //dataGridViewShedule.Size = new Size(sumWidthColumn, dataGridViewShedule.Size.Height);
            //dataGridViewShedule.Size = new Size(sumWidthColumn, sumHeightRows);

            dataGridViewShedule.ScrollBars = ScrollBars.Vertical;

            dataGridViewShedule.Columns[2].ReadOnly = true;

            for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
            {
                dataGridViewShedule.Columns[i].Resizable = DataGridViewTriState.False;
                dataGridViewShedule.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridViewShedule.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewShedule.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void dateTimePickerShedule_ValueChanged(object sender, EventArgs e)
        {
            outputSheduleForAdmin();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            outputSheduleForAdmin();
        }

        private void dataGridViewShedule_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 0)
                MessageBox.Show("Недопустимое название фильма!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            else if (e.ColumnIndex == 1)
                MessageBox.Show("Недопустимое значение возрастного ограничения!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
            else if (e.ColumnIndex == 2)
                MessageBox.Show("Недопустимое значение продолжительности фильма! " +
                    "Пожалуйста, введите число в минутах.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            else if (e.ColumnIndex == 3)
                MessageBox.Show("Недопустимое значение для времени! " +
                    "Пожалуйста, введите время в следующем формате: \"ЧЧ:ММ\".", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

            //MessageBox.Show("Error happened " + e.Context.ToString() + e.ColumnIndex);
        }
    }
}
