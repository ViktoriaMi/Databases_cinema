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
            buttonBuyTicketAbout.Image = Kino.Properties.Resources.tickets;
            buttonBuyTicketAbout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBuyTicketAbout.TextAlign = ContentAlignment.MiddleRight;
            buttonBuyTicketAbout.ImageAlign = ContentAlignment.MiddleCenter;

            textBoxFilmDesc.ReadOnly = true;

            showInfoAboutFilm(dataGridViewShedule);
        }

        public void showInfoAboutFilm (DataGridView dataGridViewShedule)
        {
            DB db = new DB();
            // получаем все названия фильмов, доступных на 3 дня
            MySqlCommand myCom = new MySqlCommand("SELECT * FROM movieSelection;",
                db.getConnection());

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            db.OpenConnection();
            
            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            db.CloseConnection();

            // передаем названия фильмов в массив строк
            // и добавляем их в combobox
            string[] films = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                films[i] = table.Rows[i][0].ToString();
                comboBoxSelectFilm.Items.Add(films[i]);
            }

            // проверяем, что выбрана какая-либо одна из ячеек 1-го столбца
            if (dataGridViewShedule.GetCellCount(DataGridViewElementStates.Selected) == 1
                && dataGridViewShedule.CurrentCell.ColumnIndex == 0)
            {
                //MessageBox.Show("выделена одна ячейка 1-го столбца");

                // извлекаем название фильма из выбранной ячейки
                string selectCell = dataGridViewShedule.CurrentCell.Value.ToString();

                int cnt = comboBoxSelectFilm.Items.Count;
                for (int i = 0; i < cnt; i++)
                {
                    // если название фильма совпадает с каким-либо из item-ов comboBox
                    if (selectCell == comboBoxSelectFilm.GetItemText(comboBoxSelectFilm.Items[i]))
                    {
                        comboBoxSelectFilm.SelectedIndex = i;
                        return;
                    } 
                }
            }
            else
            {
                comboBoxSelectFilm.SelectedIndex = 0;
                return;
            }
        }

        private void comboBoxSelectFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("мы внури SelectedIndexChanged");
            string curMovieTitle = comboBoxSelectFilm.Text;

            DB db = new DB();
            // извлекаем из базы описание и постер фильма по названию
            MySqlCommand myCom = new MySqlCommand("CALL selectDescAndPoster(@nameFilm);",
                db.getConnection());
            myCom.Parameters.Add("@nameFilm", MySqlDbType.VarChar).Value = curMovieTitle;

            db.OpenConnection();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = myCom;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            db.CloseConnection();

            try
            {
                // заполняем описание фильма
                textBoxFilmDesc.Text = table.Rows[0][0].ToString();
                //string str = String.Concat("imgs/", table.Rows[0][1].ToString());
                string pict = table.Rows[0][1].ToString();
                string path = String.Concat(Environment.CurrentDirectory, "\\", pict);

                Bitmap image1; // фото загрузки в pictureBox
                image1 = new Bitmap(path); // инициализация файл с фото
                posterPictureBox.Image = image1;
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.ToString());
                MessageBox.Show("Не получилось найти постер к этому фильму.",
                    "О фильме",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                posterPictureBox.Image = Properties.Resources.popcorn;
            }
        }

        private void textBoxFilmDesc_Enter(object sender, EventArgs e)
        {
            buttonBuyTicketAbout.Select();
        }

        private void buttonBuyTicketAbout_Click(object sender, EventArgs e)
        {
            BuyTicket form = new BuyTicket();
            form.ShowDialog();
        }

        private void buttonBuyTicketAbout_MouseHover(object sender, EventArgs e)
        {
            buttonBuyTicketAbout.Select();
        }
    }
}
