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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            dateTimePickerShedule.MinDate = DateTime.Today;
            dateTimePickerShedule.MaxDate = dateTimePickerShedule.MinDate.AddDays(2);

            //dataGridViewShedule.ClearSelection();
            //this.StartPosition = FormStartPosition.CenterScreen;
            //TabControl.SelectTab(tabPage_Registration);

            buttonBuyTicket.Select();
            outputSheduleForClient();
        }
        public void outputSheduleForClient()
        {
            string yDate = dateFromFormToString(dateTimePickerShedule.Value);

            DB db = new DB();
            MySqlCommand myCom = new MySqlCommand("CALL showSheduleForDate(@ydate);", 
                db.getConnection());
            myCom.Parameters.Add("@ydate", MySqlDbType.Date).Value = yDate;

            db.OpenConnection();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dataGridViewShedule.DataSource = table;

            db.CloseConnection();

            //dataGridViewShedule.EnableHeadersVisualStyles = false;

            dataGridViewShedule.ScrollBars = ScrollBars.None;
            dataGridViewShedule.RowHeadersVisible = false;
            dataGridViewShedule.AllowUserToResizeRows = false;

            dataGridViewShedule.Columns[0].Width = 140;
            dataGridViewShedule.Columns[1].Width = 60;
            dataGridViewShedule.Columns[2].Width = 130;
            dataGridViewShedule.Columns[3].Width = 70;
            dataGridViewShedule.Columns[4].Width = 65;

            dataGridViewShedule.Columns[0].HeaderText = "Название фильма";
            dataGridViewShedule.Columns[2].HeaderText = "Продолжительность, мин";
            dataGridViewShedule.Columns[4].HeaderText = "Цена, руб";

            int sumWidthcolumn = 0;
            for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
                sumWidthcolumn += dataGridViewShedule.Columns[i].Width;

            dataGridViewShedule.Size = new Size(sumWidthcolumn, dataGridViewShedule.Size.Height);

            for (int i = 0; i < dataGridViewShedule.ColumnCount; i++)
            {
                dataGridViewShedule.Columns[i].Resizable = DataGridViewTriState.False;
                dataGridViewShedule.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridViewShedule.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewShedule.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void dateTimePickerShedule_ValueChanged(object sender, EventArgs e)
        {
            outputSheduleForClient();
        }
        public string dateFromFormToString (DateTime yDate)
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            outputSheduleForClient();
        }

        private void buttonAboutFilm_Click(object sender, EventArgs e)
        {
            AboutFilm form = new AboutFilm(this.dataGridViewShedule);
            form.ShowDialog();
        }

        private void buttonBuyTicket_Click(object sender, EventArgs e)
        {
            BuyTicket form = new BuyTicket();
            form.ShowDialog();
        }
    }
}
