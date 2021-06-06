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
    public partial class AboutFilm : Form
    {
        public AboutFilm(DataGridView dataGridViewShedule)
        {
            InitializeComponent();

            comboBoxSelectFilm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectFilm.MaxDropDownItems = 9;
            buttonBuyTicketAbout.Select();
            //textBoxFilmDesc.BorderStyle = BorderStyle.None;
            textBoxFilmDesc.ReadOnly = true;
            //textBoxFilmDesc.Enabled = false;
            //textBoxFilmDesc.ForeColor = Color.Black;
            showInfoAboutFilm(dataGridViewShedule);
        }

        public void showInfoAboutFilm (DataGridView dataGridViewShedule)
        {
            DB db = new DB();
            MySqlCommand myCom = new MySqlCommand("SELECT * FROM movieSelection;",
                db.getConnection());

            db.OpenConnection();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            db.CloseConnection();

            string[] films = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                films[i] = table.Rows[i][0].ToString();
                comboBoxSelectFilm.Items.Add(films[i]);
            }

            comboBoxSelectFilm.SelectedIndex = 0;

            // проверяем, что выбрана какая-либо из ячеек 1-го столбца
            if (dataGridViewShedule.GetCellCount(DataGridViewElementStates.Selected) == 1
                && dataGridViewShedule.CurrentCell.ColumnIndex == 0)
            {
                // извлекаем название фильма из выбранной ячейки
                string selectCell = dataGridViewShedule.CurrentCell.Value.ToString();

                // если название фильма не равно активному тексту в comboBox
                if (selectCell != comboBoxSelectFilm.Text)
                {
                    for (int i = 0; i < comboBoxSelectFilm.Items.Count; i++)
                    {
                        // если название фильма совпадает с каким-либо из item-ов comboBox
                        if (selectCell == comboBoxSelectFilm.GetItemText(comboBoxSelectFilm.Items[i]))
                            comboBoxSelectFilm.SelectedIndex = i;
                    }
                }
                //MessageBox.Show("выделена ячейка 1-го столбца");
            }

            changeInfoAboutFilm();

            //posterPictureBox.Image = Properties.Resources._1;
        }

        public void changeInfoAboutFilm ()
        {
            string curMovieTitle = comboBoxSelectFilm.Text;

            DB db = new DB();
            MySqlCommand myCom = new MySqlCommand("CALL selectDesc(@nameFilm);",
                db.getConnection());
            myCom.Parameters.Add("@nameFilm", MySqlDbType.VarChar).Value = curMovieTitle;

            db.OpenConnection();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            db.CloseConnection();

            textBoxFilmDesc.Text = table.Rows[0][0].ToString();
        }

        private void buttonBuyTicketAbout_Click(object sender, EventArgs e)
        {
            BuyTicket form = new BuyTicket();
            form.ShowDialog();
        }

        private void comboBoxSelectFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeInfoAboutFilm();
        }

        private void textBoxFilmDesc_Enter(object sender, EventArgs e)
        {
            buttonBuyTicketAbout.Select();
        }
    }
}
