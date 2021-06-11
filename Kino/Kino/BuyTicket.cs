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
    public partial class BuyTicket : Form
    {
        public BuyTicket()
        {
            InitializeComponent();

            formDesign();
            loadFilms();

            b03.BackColor = Color.DarkMagenta;
            b05.BackColor = Color.DarkMagenta;
            b06.BackColor = Color.DarkMagenta;
            b07.BackColor = Color.DarkMagenta;
            b13.BackColor = Color.DarkMagenta;
            b14.BackColor = Color.DarkMagenta;
            b15.BackColor = Color.DarkMagenta;
            b16.BackColor = Color.DarkMagenta;
            b18.BackColor = Color.DarkMagenta;
            b22.BackColor = Color.DarkMagenta;
            b23.BackColor = Color.DarkMagenta;
            b24.BackColor = Color.DarkMagenta;
            b26.BackColor = Color.DarkMagenta;
            b27.BackColor = Color.DarkMagenta;
            b31.BackColor = Color.DarkMagenta;
            b32.BackColor = Color.DarkMagenta;
            b34.BackColor = Color.DarkMagenta;
            b35.BackColor = Color.DarkMagenta;
            b37.BackColor = Color.DarkMagenta;
            b39.BackColor = Color.DarkMagenta;
            b42.BackColor = Color.DarkMagenta;
            b43.BackColor = Color.DarkMagenta;
            b44.BackColor = Color.DarkMagenta;
            b45.BackColor = Color.DarkMagenta;
            b46.BackColor = Color.DarkMagenta;
            b47.BackColor = Color.DarkMagenta;
            b51.BackColor = Color.DarkMagenta;
            b52.BackColor = Color.DarkMagenta;
            b53.BackColor = Color.DarkMagenta;
            b54.BackColor = Color.DarkMagenta;
            b55.BackColor = Color.DarkMagenta;
            b56.BackColor = Color.DarkMagenta;
            b57.BackColor = Color.DarkMagenta;
            b62.BackColor = Color.DarkMagenta;
            b63.BackColor = Color.DarkMagenta;
            b64.BackColor = Color.DarkMagenta;
            b65.BackColor = Color.DarkMagenta;
            b66.BackColor = Color.DarkMagenta;
            b67.BackColor = Color.DarkMagenta;
            b68.BackColor = Color.DarkMagenta;
            b75.BackColor = Color.DarkMagenta;
            b76.BackColor = Color.DarkMagenta;
            b80.BackColor = Color.DarkMagenta;
            b82.BackColor = Color.DarkMagenta;
            b83.BackColor = Color.DarkMagenta;
            b84.BackColor = Color.DarkMagenta;
            b88.BackColor = Color.DarkMagenta;
            b95.BackColor = Color.DarkMagenta;
            b94.BackColor = Color.DarkMagenta;
        }

        public void formDesign()
        {
            // КАЛЕНДАРЬ

            dateTimePickerTicket.MinDate = DateTime.Today;
            dateTimePickerTicket.MaxDate = dateTimePickerTicket.MinDate.AddDays(2);

            // ТАБЛИЦА МЕСТ - TABLE_LAYOUT_PANEL

            b00.Cursor = Cursors.Default;
            b01.Cursor = Cursors.Default;
            b02.Cursor = Cursors.Default;
            b03.Cursor = Cursors.Default;
            b04.Cursor = Cursors.Default;
            b05.Cursor = Cursors.Default;
            b06.Cursor = Cursors.Default;
            b07.Cursor = Cursors.Default;
            b08.Cursor = Cursors.Default;
            b09.Cursor = Cursors.Default;
            b11.Cursor = Cursors.Default;
            b12.Cursor = Cursors.Default;
            b13.Cursor = Cursors.Default;
            b14.Cursor = Cursors.Default;
            b15.Cursor = Cursors.Default;
            b16.Cursor = Cursors.Default;
            b17.Cursor = Cursors.Default;
            b18.Cursor = Cursors.Default;
            b19.Cursor = Cursors.Default;
            b20.Cursor = Cursors.Default;
            b21.Cursor = Cursors.Default;
            b22.Cursor = Cursors.Default;
            b23.Cursor = Cursors.Default;
            b24.Cursor = Cursors.Default;
            b25.Cursor = Cursors.Default;
            b26.Cursor = Cursors.Default;
            b27.Cursor = Cursors.Default;
            b28.Cursor = Cursors.Default;
            b29.Cursor = Cursors.Default;
            b30.Cursor = Cursors.Default;
            b31.Cursor = Cursors.Default;
            b32.Cursor = Cursors.Default;
            b33.Cursor = Cursors.Default;
            b34.Cursor = Cursors.Default;
            b35.Cursor = Cursors.Default;
            b36.Cursor = Cursors.Default;
            b37.Cursor = Cursors.Default;
            b38.Cursor = Cursors.Default;
            b39.Cursor = Cursors.Default;
            b40.Cursor = Cursors.Default;
            b41.Cursor = Cursors.Default;
            b42.Cursor = Cursors.Default;
            b43.Cursor = Cursors.Default;
            b44.Cursor = Cursors.Default;
            b45.Cursor = Cursors.Default;
            b46.Cursor = Cursors.Default;
            b47.Cursor = Cursors.Default;
            b48.Cursor = Cursors.Default;
            b49.Cursor = Cursors.Default;
            b50.Cursor = Cursors.Default;
            b51.Cursor = Cursors.Default;
            b52.Cursor = Cursors.Default;
            b53.Cursor = Cursors.Default;
            b54.Cursor = Cursors.Default;
            b55.Cursor = Cursors.Default;
            b56.Cursor = Cursors.Default;
            b57.Cursor = Cursors.Default;
            b58.Cursor = Cursors.Default;
            b59.Cursor = Cursors.Default;
            b60.Cursor = Cursors.Default;
            b61.Cursor = Cursors.Default;
            b62.Cursor = Cursors.Default;
            b63.Cursor = Cursors.Default;
            b64.Cursor = Cursors.Default;
            b65.Cursor = Cursors.Default;
            b66.Cursor = Cursors.Default;
            b67.Cursor = Cursors.Default;
            b68.Cursor = Cursors.Default;
            b69.Cursor = Cursors.Default;
            b70.Cursor = Cursors.Default;
            b71.Cursor = Cursors.Default;
            b72.Cursor = Cursors.Default;
            b73.Cursor = Cursors.Default;
            b74.Cursor = Cursors.Default;
            b75.Cursor = Cursors.Default;
            b76.Cursor = Cursors.Default;
            b77.Cursor = Cursors.Default;
            b78.Cursor = Cursors.Default;
            b79.Cursor = Cursors.Default;
            b80.Cursor = Cursors.Default;
            b81.Cursor = Cursors.Default;
            b82.Cursor = Cursors.Default;
            b83.Cursor = Cursors.Default;
            b84.Cursor = Cursors.Default;
            b85.Cursor = Cursors.Default;
            b86.Cursor = Cursors.Default;
            b87.Cursor = Cursors.Default;
            b88.Cursor = Cursors.Default;
            b89.Cursor = Cursors.Default;
            b90.Cursor = Cursors.Default;
            b91.Cursor = Cursors.Default;
            b92.Cursor = Cursors.Default;
            b93.Cursor = Cursors.Default;
            b94.Cursor = Cursors.Default;
            b95.Cursor = Cursors.Default;
            b96.Cursor = Cursors.Default;
            b97.Cursor = Cursors.Default;
            b98.Cursor = Cursors.Default;
            b99.Cursor = Cursors.Default;

            tableLayoutPanel.AutoScroll = false;
            tableLayoutPanel.AllowDrop = false;

            b00.BackColor = Color.LightGray;
            b00.FlatStyle = FlatStyle.Flat;
            b00.FlatAppearance.BorderColor = Color.Gray;

            b01.BackColor = Color.LightGray;
            b01.FlatStyle = FlatStyle.Flat;
            b01.FlatAppearance.BorderColor = Color.Gray;

            b02.BackColor = Color.LightGray;
            b02.FlatStyle = FlatStyle.Flat;
            b02.FlatAppearance.BorderColor = Color.Gray;

            b03.BackColor = Color.LightGray;
            b03.FlatStyle = FlatStyle.Flat;
            b03.FlatAppearance.BorderColor = Color.Gray;

            b04.BackColor = Color.LightGray;
            b04.FlatStyle = FlatStyle.Flat;
            b04.FlatAppearance.BorderColor = Color.Gray;

            b05.BackColor = Color.LightGray;
            b05.FlatStyle = FlatStyle.Flat;
            b05.FlatAppearance.BorderColor = Color.Gray;

            b06.BackColor = Color.LightGray;
            b06.FlatStyle = FlatStyle.Flat;
            b06.FlatAppearance.BorderColor = Color.Gray;

            b07.BackColor = Color.LightGray;
            b07.FlatStyle = FlatStyle.Flat;
            b07.FlatAppearance.BorderColor = Color.Gray;

            b08.BackColor = Color.LightGray;
            b08.FlatStyle = FlatStyle.Flat;
            b08.FlatAppearance.BorderColor = Color.Gray;

            b09.BackColor = Color.LightGray;
            b09.FlatStyle = FlatStyle.Flat;
            b09.FlatAppearance.BorderColor = Color.Gray;

            b10.BackColor = Color.LightGray;
            b10.FlatStyle = FlatStyle.Flat;
            b10.FlatAppearance.BorderColor = Color.Gray;

            b11.BackColor = Color.LightGray;
            b11.FlatStyle = FlatStyle.Flat;
            b11.FlatAppearance.BorderColor = Color.Gray;

            b12.BackColor = Color.LightGray;
            b12.FlatStyle = FlatStyle.Flat;
            b12.FlatAppearance.BorderColor = Color.Gray;

            b13.BackColor = Color.LightGray;
            b13.FlatStyle = FlatStyle.Flat;
            b13.FlatAppearance.BorderColor = Color.Gray;

            b14.BackColor = Color.LightGray;
            b14.FlatStyle = FlatStyle.Flat;
            b14.FlatAppearance.BorderColor = Color.Gray;

            b15.BackColor = Color.LightGray;
            b15.FlatStyle = FlatStyle.Flat;
            b15.FlatAppearance.BorderColor = Color.Gray;

            b16.BackColor = Color.LightGray;
            b16.FlatStyle = FlatStyle.Flat;
            b16.FlatAppearance.BorderColor = Color.Gray;

            b17.BackColor = Color.LightGray;
            b17.FlatStyle = FlatStyle.Flat;
            b17.FlatAppearance.BorderColor = Color.Gray;

            b18.BackColor = Color.LightGray;
            b18.FlatStyle = FlatStyle.Flat;
            b18.FlatAppearance.BorderColor = Color.Gray;

            b19.BackColor = Color.LightGray;
            b19.FlatStyle = FlatStyle.Flat;
            b19.FlatAppearance.BorderColor = Color.Gray;

            b20.BackColor = Color.LightGray;
            b20.FlatStyle = FlatStyle.Flat;
            b20.FlatAppearance.BorderColor = Color.Gray;

            b21.BackColor = Color.LightGray;
            b21.FlatStyle = FlatStyle.Flat;
            b21.FlatAppearance.BorderColor = Color.Gray;

            b22.BackColor = Color.LightGray;
            b22.FlatStyle = FlatStyle.Flat;
            b22.FlatAppearance.BorderColor = Color.Gray;

            b23.BackColor = Color.LightGray;
            b23.FlatStyle = FlatStyle.Flat;
            b23.FlatAppearance.BorderColor = Color.Gray;

            b24.BackColor = Color.LightGray;
            b24.FlatStyle = FlatStyle.Flat;
            b24.FlatAppearance.BorderColor = Color.Gray;

            b25.BackColor = Color.LightGray;
            b25.FlatStyle = FlatStyle.Flat;
            b25.FlatAppearance.BorderColor = Color.Gray;

            b26.BackColor = Color.LightGray;
            b26.FlatStyle = FlatStyle.Flat;
            b26.FlatAppearance.BorderColor = Color.Gray;

            b27.BackColor = Color.LightGray;
            b27.FlatStyle = FlatStyle.Flat;
            b27.FlatAppearance.BorderColor = Color.Gray;

            b28.BackColor = Color.LightGray;
            b28.FlatStyle = FlatStyle.Flat;
            b28.FlatAppearance.BorderColor = Color.Gray;

            b29.BackColor = Color.LightGray;
            b29.FlatStyle = FlatStyle.Flat;
            b29.FlatAppearance.BorderColor = Color.Gray;

            b30.BackColor = Color.LightGray;
            b30.FlatStyle = FlatStyle.Flat;
            b30.FlatAppearance.BorderColor = Color.Gray;

            b31.BackColor = Color.LightGray;
            b31.FlatStyle = FlatStyle.Flat;
            b31.FlatAppearance.BorderColor = Color.Gray;

            b32.BackColor = Color.LightGray;
            b32.FlatStyle = FlatStyle.Flat;
            b32.FlatAppearance.BorderColor = Color.Gray;

            b33.BackColor = Color.LightGray;
            b33.FlatStyle = FlatStyle.Flat;
            b33.FlatAppearance.BorderColor = Color.Gray;

            b34.BackColor = Color.LightGray;
            b34.FlatStyle = FlatStyle.Flat;
            b34.FlatAppearance.BorderColor = Color.Gray;

            b35.BackColor = Color.LightGray;
            b35.FlatStyle = FlatStyle.Flat;
            b35.FlatAppearance.BorderColor = Color.Gray;

            b36.BackColor = Color.LightGray;
            b36.FlatStyle = FlatStyle.Flat;
            b36.FlatAppearance.BorderColor = Color.Gray;

            b37.BackColor = Color.LightGray;
            b37.FlatStyle = FlatStyle.Flat;
            b37.FlatAppearance.BorderColor = Color.Gray;

            b38.BackColor = Color.LightGray;
            b38.FlatStyle = FlatStyle.Flat;
            b38.FlatAppearance.BorderColor = Color.Gray;

            b39.BackColor = Color.LightGray;
            b39.FlatStyle = FlatStyle.Flat;
            b39.FlatAppearance.BorderColor = Color.Gray;

            b40.BackColor = Color.LightGray;
            b40.FlatStyle = FlatStyle.Flat;
            b40.FlatAppearance.BorderColor = Color.Gray;

            b41.BackColor = Color.LightGray;
            b41.FlatStyle = FlatStyle.Flat;
            b41.FlatAppearance.BorderColor = Color.Gray;

            b42.BackColor = Color.LightGray;
            b42.FlatStyle = FlatStyle.Flat;
            b42.FlatAppearance.BorderColor = Color.Gray;

            b43.BackColor = Color.LightGray;
            b43.FlatStyle = FlatStyle.Flat;
            b43.FlatAppearance.BorderColor = Color.Gray;

            b44.BackColor = Color.LightGray;
            b44.FlatStyle = FlatStyle.Flat;
            b44.FlatAppearance.BorderColor = Color.Gray;

            b45.BackColor = Color.LightGray;
            b45.FlatStyle = FlatStyle.Flat;
            b45.FlatAppearance.BorderColor = Color.Gray;

            b46.BackColor = Color.LightGray;
            b46.FlatStyle = FlatStyle.Flat;
            b46.FlatAppearance.BorderColor = Color.Gray;

            b47.BackColor = Color.LightGray;
            b47.FlatStyle = FlatStyle.Flat;
            b47.FlatAppearance.BorderColor = Color.Gray;

            b48.BackColor = Color.LightGray;
            b48.FlatStyle = FlatStyle.Flat;
            b48.FlatAppearance.BorderColor = Color.Gray;

            b49.BackColor = Color.LightGray;
            b49.FlatStyle = FlatStyle.Flat;
            b49.FlatAppearance.BorderColor = Color.Gray;

            b50.BackColor = Color.LightGray;
            b50.FlatStyle = FlatStyle.Flat;
            b50.FlatAppearance.BorderColor = Color.Gray;

            b51.BackColor = Color.LightGray;
            b51.FlatStyle = FlatStyle.Flat;
            b51.FlatAppearance.BorderColor = Color.Gray;

            b52.BackColor = Color.LightGray;
            b52.FlatStyle = FlatStyle.Flat;
            b52.FlatAppearance.BorderColor = Color.Gray;

            b53.BackColor = Color.LightGray;
            b53.FlatStyle = FlatStyle.Flat;
            b53.FlatAppearance.BorderColor = Color.Gray;

            b54.BackColor = Color.LightGray;
            b54.FlatStyle = FlatStyle.Flat;
            b54.FlatAppearance.BorderColor = Color.Gray;

            b55.BackColor = Color.LightGray;
            b55.FlatStyle = FlatStyle.Flat;
            b55.FlatAppearance.BorderColor = Color.Gray;

            b56.BackColor = Color.LightGray;
            b56.FlatStyle = FlatStyle.Flat;
            b56.FlatAppearance.BorderColor = Color.Gray;

            b57.BackColor = Color.LightGray;
            b57.FlatStyle = FlatStyle.Flat;
            b57.FlatAppearance.BorderColor = Color.Gray;

            b58.BackColor = Color.LightGray;
            b58.FlatStyle = FlatStyle.Flat;
            b58.FlatAppearance.BorderColor = Color.Gray;

            b59.BackColor = Color.LightGray;
            b59.FlatStyle = FlatStyle.Flat;
            b59.FlatAppearance.BorderColor = Color.Gray;

            b60.BackColor = Color.LightGray;
            b60.FlatStyle = FlatStyle.Flat;
            b60.FlatAppearance.BorderColor = Color.Gray;

            b61.BackColor = Color.LightGray;
            b61.FlatStyle = FlatStyle.Flat;
            b61.FlatAppearance.BorderColor = Color.Gray;

            b62.BackColor = Color.LightGray;
            b62.FlatStyle = FlatStyle.Flat;
            b62.FlatAppearance.BorderColor = Color.Gray;

            b63.BackColor = Color.LightGray;
            b63.FlatStyle = FlatStyle.Flat;
            b63.FlatAppearance.BorderColor = Color.Gray;

            b64.BackColor = Color.LightGray;
            b64.FlatStyle = FlatStyle.Flat;
            b64.FlatAppearance.BorderColor = Color.Gray;

            b65.BackColor = Color.LightGray;
            b65.FlatStyle = FlatStyle.Flat;
            b65.FlatAppearance.BorderColor = Color.Gray;

            b66.BackColor = Color.LightGray;
            b66.FlatStyle = FlatStyle.Flat;
            b66.FlatAppearance.BorderColor = Color.Gray;

            b67.BackColor = Color.LightGray;
            b67.FlatStyle = FlatStyle.Flat;
            b67.FlatAppearance.BorderColor = Color.Gray;

            b68.BackColor = Color.LightGray;
            b68.FlatStyle = FlatStyle.Flat;
            b68.FlatAppearance.BorderColor = Color.Gray;

            b69.BackColor = Color.LightGray;
            b69.FlatStyle = FlatStyle.Flat;
            b69.FlatAppearance.BorderColor = Color.Gray;

            b70.BackColor = Color.LightGray;
            b70.FlatStyle = FlatStyle.Flat;
            b70.FlatAppearance.BorderColor = Color.Gray;

            b71.BackColor = Color.LightGray;
            b71.FlatStyle = FlatStyle.Flat;
            b71.FlatAppearance.BorderColor = Color.Gray;

            b72.BackColor = Color.LightGray;
            b72.FlatStyle = FlatStyle.Flat;
            b72.FlatAppearance.BorderColor = Color.Gray;

            b73.BackColor = Color.LightGray;
            b73.FlatStyle = FlatStyle.Flat;
            b73.FlatAppearance.BorderColor = Color.Gray;

            b74.BackColor = Color.LightGray;
            b74.FlatStyle = FlatStyle.Flat;
            b74.FlatAppearance.BorderColor = Color.Gray;

            b75.BackColor = Color.LightGray;
            b75.FlatStyle = FlatStyle.Flat;
            b75.FlatAppearance.BorderColor = Color.Gray;

            b76.BackColor = Color.LightGray;
            b76.FlatStyle = FlatStyle.Flat;
            b76.FlatAppearance.BorderColor = Color.Gray;

            b77.BackColor = Color.LightGray;
            b77.FlatStyle = FlatStyle.Flat;
            b77.FlatAppearance.BorderColor = Color.Gray;

            b78.BackColor = Color.LightGray;
            b78.FlatStyle = FlatStyle.Flat;
            b78.FlatAppearance.BorderColor = Color.Gray;

            b79.BackColor = Color.LightGray;
            b79.FlatStyle = FlatStyle.Flat;
            b79.FlatAppearance.BorderColor = Color.Gray;

            b80.BackColor = Color.LightGray;
            b80.FlatStyle = FlatStyle.Flat;
            b80.FlatAppearance.BorderColor = Color.Gray;

            b81.BackColor = Color.LightGray;
            b81.FlatStyle = FlatStyle.Flat;
            b81.FlatAppearance.BorderColor = Color.Gray;

            b82.BackColor = Color.LightGray;
            b82.FlatStyle = FlatStyle.Flat;
            b82.FlatAppearance.BorderColor = Color.Gray;

            b83.BackColor = Color.LightGray;
            b83.FlatStyle = FlatStyle.Flat;
            b83.FlatAppearance.BorderColor = Color.Gray;

            b84.BackColor = Color.LightGray;
            b84.FlatStyle = FlatStyle.Flat;
            b84.FlatAppearance.BorderColor = Color.Gray;

            b85.BackColor = Color.LightGray;
            b85.FlatStyle = FlatStyle.Flat;
            b85.FlatAppearance.BorderColor = Color.Gray;

            b86.BackColor = Color.LightGray;
            b86.FlatStyle = FlatStyle.Flat;
            b86.FlatAppearance.BorderColor = Color.Gray;

            b87.BackColor = Color.LightGray;
            b87.FlatStyle = FlatStyle.Flat;
            b87.FlatAppearance.BorderColor = Color.Gray;

            b88.BackColor = Color.LightGray;
            b88.FlatStyle = FlatStyle.Flat;
            b88.FlatAppearance.BorderColor = Color.Gray;

            b89.BackColor = Color.LightGray;
            b89.FlatStyle = FlatStyle.Flat;
            b89.FlatAppearance.BorderColor = Color.Gray;

            b90.BackColor = Color.LightGray;
            b90.FlatStyle = FlatStyle.Flat;
            b90.FlatAppearance.BorderColor = Color.Gray;

            b91.BackColor = Color.LightGray;
            b91.FlatStyle = FlatStyle.Flat;
            b91.FlatAppearance.BorderColor = Color.Gray;

            b92.BackColor = Color.LightGray;
            b92.FlatStyle = FlatStyle.Flat;
            b92.FlatAppearance.BorderColor = Color.Gray;

            b93.BackColor = Color.LightGray;
            b93.FlatStyle = FlatStyle.Flat;
            b93.FlatAppearance.BorderColor = Color.Gray;

            b94.BackColor = Color.LightGray;
            b94.FlatStyle = FlatStyle.Flat;
            b94.FlatAppearance.BorderColor = Color.Gray;

            b95.BackColor = Color.LightGray;
            b95.FlatStyle = FlatStyle.Flat;
            b95.FlatAppearance.BorderColor = Color.Gray;

            b96.BackColor = Color.LightGray;
            b96.FlatStyle = FlatStyle.Flat;
            b96.FlatAppearance.BorderColor = Color.Gray;

            b97.BackColor = Color.LightGray;
            b97.FlatStyle = FlatStyle.Flat;
            b97.FlatAppearance.BorderColor = Color.Gray;

            b98.BackColor = Color.LightGray;
            b98.FlatStyle = FlatStyle.Flat;
            b98.FlatAppearance.BorderColor = Color.Gray;

            b99.BackColor = Color.LightGray;
            b99.FlatStyle = FlatStyle.Flat;
            b99.FlatAppearance.BorderColor = Color.Gray;

            //int w = tableLayoutPanel.Width;
            //int h = tableLayoutPanel.Height;

            // КНОПКИ СПРАВА

            buttonFree.Enabled = false;
            buttonOccupied.Enabled = false;
            buttonChosen.Enabled = false;

            buttonFree.BackColor = Color.LightGray;
            buttonFree.FlatStyle = FlatStyle.Flat;
            buttonFree.FlatAppearance.BorderColor = Color.Gray;

            buttonOccupied.BackColor = Color.DarkMagenta;
            buttonOccupied.FlatStyle = FlatStyle.Flat;
            buttonOccupied.FlatAppearance.BorderColor = Color.Gray;

            buttonChosen.BackColor = Color.BlueViolet;
            buttonChosen.FlatStyle = FlatStyle.Flat;
            buttonChosen.FlatAppearance.BorderColor = Color.Gray;

            // КНОПКА КУПИТЬ
            buttonBuyTicket.Select();
            buttonBuyTicket.Image = Kino.Properties.Resources.tickets;
            buttonBuyTicket.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBuyTicket.TextAlign = ContentAlignment.MiddleRight;
            buttonBuyTicket.ImageAlign = ContentAlignment.MiddleCenter;
        }

        public void loadFilms ()
        {
            comboBoxSelectFilmTicket.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectFilmTicket.MaxDropDownItems = 9;

            comboBoxSelectFilmTicket.Items.Clear();

            string yDate = dateFromFormToString(dateTimePickerTicket.Value);

            DB db = new DB();
            MySqlCommand myCom = new MySqlCommand("CALL selectFilmByDate(@ydate);",
                db.getConnection());
            myCom.Parameters.Add("@ydate", MySqlDbType.Date).Value = yDate;

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
                comboBoxSelectFilmTicket.Items.Add(films[i]);
            }

            comboBoxSelectFilmTicket.SelectedIndex = 0;
        }

        private void buttonBuyTicket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Покупка прошла успешно! Билеты отправлены на вашу электронную почту.", "Покупка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }

        private void b00_Click(object sender, EventArgs e)
        {
            if (b00.BackColor == Color.LightGray)
                b00.BackColor = Color.BlueViolet;
            else if (b00.BackColor == Color.BlueViolet)
                b00.BackColor = Color.LightGray;
            else if (b00.BackColor == Color.DarkMagenta)
                b00.Cursor = Cursors.Default;
        }

        private void b01_Click(object sender, EventArgs e)
        {
            if (b01.BackColor == Color.LightGray)
                b01.BackColor = Color.BlueViolet;
            else if (b01.BackColor == Color.BlueViolet)
                b01.BackColor = Color.LightGray;
        }

        private void b02_Click(object sender, EventArgs e)
        {
            if (b02.BackColor == Color.LightGray)
                b02.BackColor = Color.BlueViolet;
            else if (b02.BackColor == Color.BlueViolet)
                b02.BackColor = Color.LightGray;
        }

        private void b03_Click(object sender, EventArgs e)
        {
            if (b03.BackColor == Color.LightGray)
                b03.BackColor = Color.BlueViolet;
            else if (b03.BackColor == Color.BlueViolet)
                b03.BackColor = Color.LightGray;
        }

        private void b04_Click(object sender, EventArgs e)
        {
            if (b04.BackColor == Color.LightGray)
                b04.BackColor = Color.BlueViolet;
            else if (b04.BackColor == Color.BlueViolet)
                b04.BackColor = Color.LightGray;
        }

        private void b05_Click(object sender, EventArgs e)
        {
            if (b05.BackColor == Color.LightGray)
                b05.BackColor = Color.BlueViolet;
            else if (b05.BackColor == Color.BlueViolet)
                b05.BackColor = Color.LightGray;
        }

        private void b06_Click(object sender, EventArgs e)
        {
            if (b06.BackColor == Color.LightGray)
                b06.BackColor = Color.BlueViolet;
            else if (b06.BackColor == Color.BlueViolet)
                b06.BackColor = Color.LightGray;
        }

        private void b07_Click(object sender, EventArgs e)
        {
            if (b07.BackColor == Color.LightGray)
                b07.BackColor = Color.BlueViolet;
            else if (b07.BackColor == Color.BlueViolet)
                b07.BackColor = Color.LightGray;
        }

        private void b08_Click(object sender, EventArgs e)
        {
            if (b08.BackColor == Color.LightGray)
                b08.BackColor = Color.BlueViolet;
            else if (b08.BackColor == Color.BlueViolet)
                b08.BackColor = Color.LightGray;
        }

        private void b09_Click(object sender, EventArgs e)
        {
            if (b09.BackColor == Color.LightGray)
                b09.BackColor = Color.BlueViolet;
            else if (b09.BackColor == Color.BlueViolet)
                b09.BackColor = Color.LightGray;
        }

        private void b10_Click(object sender, EventArgs e)
        {
            if (b10.BackColor == Color.LightGray)
                b10.BackColor = Color.BlueViolet;
            else if (b10.BackColor == Color.BlueViolet)
                b10.BackColor = Color.LightGray;
        }

        private void b11_Click(object sender, EventArgs e)
        {
            if (b11.BackColor == Color.LightGray)
                b11.BackColor = Color.BlueViolet;
            else if (b11.BackColor == Color.BlueViolet)
                b11.BackColor = Color.LightGray;
        }

        private void b12_Click(object sender, EventArgs e)
        {
            if (b12.BackColor == Color.LightGray)
                b12.BackColor = Color.BlueViolet;
            else if (b12.BackColor == Color.BlueViolet)
                b12.BackColor = Color.LightGray;
        }

        private void b13_Click(object sender, EventArgs e)
        {
            if (b13.BackColor == Color.LightGray)
                b13.BackColor = Color.BlueViolet;
            else if (b13.BackColor == Color.BlueViolet)
                b13.BackColor = Color.LightGray;
        }

        private void b14_Click(object sender, EventArgs e)
        {
            if (b14.BackColor == Color.LightGray)
                b14.BackColor = Color.BlueViolet;
            else if (b14.BackColor == Color.BlueViolet)
                b14.BackColor = Color.LightGray;
        }

        private void b15_Click(object sender, EventArgs e)
        {
            if (b15.BackColor == Color.LightGray)
                b15.BackColor = Color.BlueViolet;
            else if (b15.BackColor == Color.BlueViolet)
                b15.BackColor = Color.LightGray;
        }

        private void b16_Click(object sender, EventArgs e)
        {
            if (b16.BackColor == Color.LightGray)
                b16.BackColor = Color.BlueViolet;
            else if (b16.BackColor == Color.BlueViolet)
                b16.BackColor = Color.LightGray;
        }

        private void b17_Click(object sender, EventArgs e)
        {
            if (b17.BackColor == Color.LightGray)
                b17.BackColor = Color.BlueViolet;
            else if (b17.BackColor == Color.BlueViolet)
                b17.BackColor = Color.LightGray;
        }

        private void b18_Click(object sender, EventArgs e)
        {
            if (b18.BackColor == Color.LightGray)
                b18.BackColor = Color.BlueViolet;
            else if (b18.BackColor == Color.BlueViolet)
                b18.BackColor = Color.LightGray;
        }

        private void b19_Click(object sender, EventArgs e)
        {
            if (b19.BackColor == Color.LightGray)
                b19.BackColor = Color.BlueViolet;
            else if (b19.BackColor == Color.BlueViolet)
                b19.BackColor = Color.LightGray;
        }

        private void b20_Click(object sender, EventArgs e)
        {
            if (b20.BackColor == Color.LightGray)
                b20.BackColor = Color.BlueViolet;
            else if (b20.BackColor == Color.BlueViolet)
                b20.BackColor = Color.LightGray;
        }

        private void b21_Click(object sender, EventArgs e)
        {
            if (b21.BackColor == Color.LightGray)
                b21.BackColor = Color.BlueViolet;
            else if (b21.BackColor == Color.BlueViolet)
                b21.BackColor = Color.LightGray;
        }

        private void b22_Click(object sender, EventArgs e)
        {
            if (b22.BackColor == Color.LightGray)
                b22.BackColor = Color.BlueViolet;
            else if (b22.BackColor == Color.BlueViolet)
                b22.BackColor = Color.LightGray;
        }

        private void b23_Click(object sender, EventArgs e)
        {
            if (b23.BackColor == Color.LightGray)
                b23.BackColor = Color.BlueViolet;
            else if (b23.BackColor == Color.BlueViolet)
                b23.BackColor = Color.LightGray;
        }

        private void b24_Click(object sender, EventArgs e)
        {
            if (b24.BackColor == Color.LightGray)
                b24.BackColor = Color.BlueViolet;
            else if (b24.BackColor == Color.BlueViolet)
                b24.BackColor = Color.LightGray;
        }

        private void b25_Click(object sender, EventArgs e)
        {
            if (b25.BackColor == Color.LightGray)
                b25.BackColor = Color.BlueViolet;
            else if (b25.BackColor == Color.BlueViolet)
                b25.BackColor = Color.LightGray;
        }

        private void b26_Click(object sender, EventArgs e)
        {
            if (b26.BackColor == Color.LightGray)
                b26.BackColor = Color.BlueViolet;
            else if (b26.BackColor == Color.BlueViolet)
                b26.BackColor = Color.LightGray;
        }

        private void b27_Click(object sender, EventArgs e)
        {
            if (b27.BackColor == Color.LightGray)
                b27.BackColor = Color.BlueViolet;
            else if (b27.BackColor == Color.BlueViolet)
                b27.BackColor = Color.LightGray;
        }

        private void b28_Click(object sender, EventArgs e)
        {
            if (b28.BackColor == Color.LightGray)
                b28.BackColor = Color.BlueViolet;
            else if (b28.BackColor == Color.BlueViolet)
                b28.BackColor = Color.LightGray;
        }

        private void b29_Click(object sender, EventArgs e)
        {
            if (b29.BackColor == Color.LightGray)
                b29.BackColor = Color.BlueViolet;
            else if (b29.BackColor == Color.BlueViolet)
                b29.BackColor = Color.LightGray;
        }

        private void b30_Click(object sender, EventArgs e)
        {
            if (b30.BackColor == Color.LightGray)
                b30.BackColor = Color.BlueViolet;
            else if (b30.BackColor == Color.BlueViolet)
                b30.BackColor = Color.LightGray;
        }

        private void b31_Click(object sender, EventArgs e)
        {
            if (b31.BackColor == Color.LightGray)
                b31.BackColor = Color.BlueViolet;
            else if (b31.BackColor == Color.BlueViolet)
                b31.BackColor = Color.LightGray;
        }

        private void b32_Click(object sender, EventArgs e)
        {
            if (b32.BackColor == Color.LightGray)
                b32.BackColor = Color.BlueViolet;
            else if (b32.BackColor == Color.BlueViolet)
                b32.BackColor = Color.LightGray;
        }

        private void b33_Click(object sender, EventArgs e)
        {
            if (b33.BackColor == Color.LightGray)
                b33.BackColor = Color.BlueViolet;
            else if (b33.BackColor == Color.BlueViolet)
                b33.BackColor = Color.LightGray;
        }

        private void b34_Click(object sender, EventArgs e)
        {
            if (b34.BackColor == Color.LightGray)
                b34.BackColor = Color.BlueViolet;
            else if (b34.BackColor == Color.BlueViolet)
                b34.BackColor = Color.LightGray;
        }

        private void b35_Click(object sender, EventArgs e)
        {
            if (b35.BackColor == Color.LightGray)
                b35.BackColor = Color.BlueViolet;
            else if (b35.BackColor == Color.BlueViolet)
                b35.BackColor = Color.LightGray;
        }

        private void b36_Click(object sender, EventArgs e)
        {
            if (b36.BackColor == Color.LightGray)
                b36.BackColor = Color.BlueViolet;
            else if (b36.BackColor == Color.BlueViolet)
                b36.BackColor = Color.LightGray;
        }

        private void b37_Click(object sender, EventArgs e)
        {
            if (b37.BackColor == Color.LightGray)
                b37.BackColor = Color.BlueViolet;
            else if (b37.BackColor == Color.BlueViolet)
                b37.BackColor = Color.LightGray;
        }

        private void b38_Click(object sender, EventArgs e)
        {
            if (b38.BackColor == Color.LightGray)
                b38.BackColor = Color.BlueViolet;
            else if (b38.BackColor == Color.BlueViolet)
                b38.BackColor = Color.LightGray;
        }

        private void b39_Click(object sender, EventArgs e)
        {
            if (b39.BackColor == Color.LightGray)
                b39.BackColor = Color.BlueViolet;
            else if (b39.BackColor == Color.BlueViolet)
                b39.BackColor = Color.LightGray;
        }

        private void b40_Click(object sender, EventArgs e)
        {
            if (b40.BackColor == Color.LightGray)
                b40.BackColor = Color.BlueViolet;
            else if (b40.BackColor == Color.BlueViolet)
                b40.BackColor = Color.LightGray;
        }

        private void b41_Click(object sender, EventArgs e)
        {
            if (b41.BackColor == Color.LightGray)
                b41.BackColor = Color.BlueViolet;
            else if (b41.BackColor == Color.BlueViolet)
                b41.BackColor = Color.LightGray;
        }

        private void b42_Click(object sender, EventArgs e)
        {
            if (b42.BackColor == Color.LightGray)
                b42.BackColor = Color.BlueViolet;
            else if (b42.BackColor == Color.BlueViolet)
                b42.BackColor = Color.LightGray;
        }

        private void b43_Click(object sender, EventArgs e)
        {
            if (b43.BackColor == Color.LightGray)
                b43.BackColor = Color.BlueViolet;
            else if (b43.BackColor == Color.BlueViolet)
                b43.BackColor = Color.LightGray;
        }

        private void b44_Click(object sender, EventArgs e)
        {
            if (b44.BackColor == Color.LightGray)
                b44.BackColor = Color.BlueViolet;
            else if (b44.BackColor == Color.BlueViolet)
                b44.BackColor = Color.LightGray;
        }

        private void b45_Click(object sender, EventArgs e)
        {
            if (b45.BackColor == Color.LightGray)
                b45.BackColor = Color.BlueViolet;
            else if (b45.BackColor == Color.BlueViolet)
                b45.BackColor = Color.LightGray;
        }

        private void b46_Click(object sender, EventArgs e)
        {
            if (b46.BackColor == Color.LightGray)
                b46.BackColor = Color.BlueViolet;
            else if (b46.BackColor == Color.BlueViolet)
                b46.BackColor = Color.LightGray;
        }

        private void b47_Click(object sender, EventArgs e)
        {
            if (b47.BackColor == Color.LightGray)
                b47.BackColor = Color.BlueViolet;
            else if (b47.BackColor == Color.BlueViolet)
                b47.BackColor = Color.LightGray;
        }

        private void b48_Click(object sender, EventArgs e)
        {
            if (b48.BackColor == Color.LightGray)
                b48.BackColor = Color.BlueViolet;
            else if (b48.BackColor == Color.BlueViolet)
                b48.BackColor = Color.LightGray;
        }

        private void b49_Click(object sender, EventArgs e)
        {
            if (b49.BackColor == Color.LightGray)
                b49.BackColor = Color.BlueViolet;
            else if (b49.BackColor == Color.BlueViolet)
                b49.BackColor = Color.LightGray;
        }

        private void b50_Click(object sender, EventArgs e)
        {
            if (b50.BackColor == Color.LightGray)
                b50.BackColor = Color.BlueViolet;
            else if (b50.BackColor == Color.BlueViolet)
                b50.BackColor = Color.LightGray;
        }

        private void b51_Click(object sender, EventArgs e)
        {
            if (b51.BackColor == Color.LightGray)
                b51.BackColor = Color.BlueViolet;
            else if (b51.BackColor == Color.BlueViolet)
                b51.BackColor = Color.LightGray;
        }

        private void b52_Click(object sender, EventArgs e)
        {
            if (b52.BackColor == Color.LightGray)
                b52.BackColor = Color.BlueViolet;
            else if (b52.BackColor == Color.BlueViolet)
                b52.BackColor = Color.LightGray;
        }

        private void b53_Click(object sender, EventArgs e)
        {
            if (b53.BackColor == Color.LightGray)
                b53.BackColor = Color.BlueViolet;
            else if (b53.BackColor == Color.BlueViolet)
                b53.BackColor = Color.LightGray;
        }

        private void b54_Click(object sender, EventArgs e)
        {
            if (b54.BackColor == Color.LightGray)
                b54.BackColor = Color.BlueViolet;
            else if (b54.BackColor == Color.BlueViolet)
                b54.BackColor = Color.LightGray;
        }

        private void b55_Click(object sender, EventArgs e)
        {
            if (b55.BackColor == Color.LightGray)
                b55.BackColor = Color.BlueViolet;
            else if (b55.BackColor == Color.BlueViolet)
                b55.BackColor = Color.LightGray;
        }

        private void b56_Click(object sender, EventArgs e)
        {
            if (b56.BackColor == Color.LightGray)
                b56.BackColor = Color.BlueViolet;
            else if (b56.BackColor == Color.BlueViolet)
                b56.BackColor = Color.LightGray;
        }

        private void b57_Click(object sender, EventArgs e)
        {
            if (b57.BackColor == Color.LightGray)
                b57.BackColor = Color.BlueViolet;
            else if (b57.BackColor == Color.BlueViolet)
                b57.BackColor = Color.LightGray;
        }

        private void b58_Click(object sender, EventArgs e)
        {
            if (b58.BackColor == Color.LightGray)
                b58.BackColor = Color.BlueViolet;
            else if (b58.BackColor == Color.BlueViolet)
                b58.BackColor = Color.LightGray;
        }

        private void b59_Click(object sender, EventArgs e)
        {
            if (b59.BackColor == Color.LightGray)
                b59.BackColor = Color.BlueViolet;
            else if (b59.BackColor == Color.BlueViolet)
                b59.BackColor = Color.LightGray;
        }

        private void b60_Click(object sender, EventArgs e)
        {
            if (b60.BackColor == Color.LightGray)
                b60.BackColor = Color.BlueViolet;
            else if (b60.BackColor == Color.BlueViolet)
                b60.BackColor = Color.LightGray;
        }

        private void b61_Click(object sender, EventArgs e)
        {
            if (b61.BackColor == Color.LightGray)
                b61.BackColor = Color.BlueViolet;
            else if (b61.BackColor == Color.BlueViolet)
                b61.BackColor = Color.LightGray;
        }

        private void b62_Click(object sender, EventArgs e)
        {
            if (b62.BackColor == Color.LightGray)
                b62.BackColor = Color.BlueViolet;
            else if (b62.BackColor == Color.BlueViolet)
                b62.BackColor = Color.LightGray;
        }

        private void b63_Click(object sender, EventArgs e)
        {
            if (b63.BackColor == Color.LightGray)
                b63.BackColor = Color.BlueViolet;
            else if (b63.BackColor == Color.BlueViolet)
                b63.BackColor = Color.LightGray;
        }

        private void b64_Click(object sender, EventArgs e)
        {
            if (b64.BackColor == Color.LightGray)
                b64.BackColor = Color.BlueViolet;
            else if (b64.BackColor == Color.BlueViolet)
                b64.BackColor = Color.LightGray;
        }

        private void b65_Click(object sender, EventArgs e)
        {
            if (b65.BackColor == Color.LightGray)
                b65.BackColor = Color.BlueViolet;
            else if (b65.BackColor == Color.BlueViolet)
                b65.BackColor = Color.LightGray;
        }

        private void b66_Click(object sender, EventArgs e)
        {
            if (b66.BackColor == Color.LightGray)
                b66.BackColor = Color.BlueViolet;
            else if (b66.BackColor == Color.BlueViolet)
                b66.BackColor = Color.LightGray;
        }

        private void b67_Click(object sender, EventArgs e)
        {
            if (b67.BackColor == Color.LightGray)
                b67.BackColor = Color.BlueViolet;
            else if (b67.BackColor == Color.BlueViolet)
                b67.BackColor = Color.LightGray;
        }

        private void b68_Click(object sender, EventArgs e)
        {
            if (b68.BackColor == Color.LightGray)
                b68.BackColor = Color.BlueViolet;
            else if (b68.BackColor == Color.BlueViolet)
                b68.BackColor = Color.LightGray;
        }

        private void b69_Click(object sender, EventArgs e)
        {
            if (b69.BackColor == Color.LightGray)
                b69.BackColor = Color.BlueViolet;
            else if (b69.BackColor == Color.BlueViolet)
                b69.BackColor = Color.LightGray;
        }

        private void b70_Click(object sender, EventArgs e)
        {
            if (b70.BackColor == Color.LightGray)
                b70.BackColor = Color.BlueViolet;
            else if (b70.BackColor == Color.BlueViolet)
                b70.BackColor = Color.LightGray;
        }

        private void b71_Click(object sender, EventArgs e)
        {
            if (b71.BackColor == Color.LightGray)
                b71.BackColor = Color.BlueViolet;
            else if (b71.BackColor == Color.BlueViolet)
                b71.BackColor = Color.LightGray;
        }

        private void b72_Click(object sender, EventArgs e)
        {
            if (b72.BackColor == Color.LightGray)
                b72.BackColor = Color.BlueViolet;
            else if (b72.BackColor == Color.BlueViolet)
                b72.BackColor = Color.LightGray;
        }

        private void b73_Click(object sender, EventArgs e)
        {
            if (b73.BackColor == Color.LightGray)
                b73.BackColor = Color.BlueViolet;
            else if (b73.BackColor == Color.BlueViolet)
                b73.BackColor = Color.LightGray;
        }

        private void b74_Click(object sender, EventArgs e)
        {
            if (b74.BackColor == Color.LightGray)
                b74.BackColor = Color.BlueViolet;
            else if (b74.BackColor == Color.BlueViolet)
                b74.BackColor = Color.LightGray;
        }

        private void b75_Click(object sender, EventArgs e)
        {
            if (b75.BackColor == Color.LightGray)
                b75.BackColor = Color.BlueViolet;
            else if (b75.BackColor == Color.BlueViolet)
                b75.BackColor = Color.LightGray;
        }

        private void b76_Click(object sender, EventArgs e)
        {
            if (b76.BackColor == Color.LightGray)
                b76.BackColor = Color.BlueViolet;
            else if (b76.BackColor == Color.BlueViolet)
                b76.BackColor = Color.LightGray;
        }

        private void b77_Click(object sender, EventArgs e)
        {
            if (b77.BackColor == Color.LightGray)
                b77.BackColor = Color.BlueViolet;
            else if (b77.BackColor == Color.BlueViolet)
                b77.BackColor = Color.LightGray;
        }

        private void b78_Click(object sender, EventArgs e)
        {
            if (b78.BackColor == Color.LightGray)
                b78.BackColor = Color.BlueViolet;
            else if (b78.BackColor == Color.BlueViolet)
                b78.BackColor = Color.LightGray;
        }

        private void b79_Click(object sender, EventArgs e)
        {
            if (b79.BackColor == Color.LightGray)
                b79.BackColor = Color.BlueViolet;
            else if (b79.BackColor == Color.BlueViolet)
                b79.BackColor = Color.LightGray;
        }

        private void b80_Click(object sender, EventArgs e)
        {
            if (b80.BackColor == Color.LightGray)
                b80.BackColor = Color.BlueViolet;
            else if (b80.BackColor == Color.BlueViolet)
                b80.BackColor = Color.LightGray;
        }

        private void b81_Click(object sender, EventArgs e)
        {
            if (b81.BackColor == Color.LightGray)
                b81.BackColor = Color.BlueViolet;
            else if (b81.BackColor == Color.BlueViolet)
                b81.BackColor = Color.LightGray;
        }

        private void b82_Click(object sender, EventArgs e)
        {
            if (b82.BackColor == Color.LightGray)
                b82.BackColor = Color.BlueViolet;
            else if (b82.BackColor == Color.BlueViolet)
                b82.BackColor = Color.LightGray;
        }

        private void b83_Click(object sender, EventArgs e)
        {
            if (b83.BackColor == Color.LightGray)
                b83.BackColor = Color.BlueViolet;
            else if (b83.BackColor == Color.BlueViolet)
                b83.BackColor = Color.LightGray;
        }

        private void b84_Click(object sender, EventArgs e)
        {
            if (b84.BackColor == Color.LightGray)
                b84.BackColor = Color.BlueViolet;
            else if (b84.BackColor == Color.BlueViolet)
                b84.BackColor = Color.LightGray;
        }

        private void b85_Click(object sender, EventArgs e)
        {
            if (b85.BackColor == Color.LightGray)
                b85.BackColor = Color.BlueViolet;
            else if (b85.BackColor == Color.BlueViolet)
                b85.BackColor = Color.LightGray;
        }

        private void b86_Click(object sender, EventArgs e)
        {
            if (b86.BackColor == Color.LightGray)
                b86.BackColor = Color.BlueViolet;
            else if (b86.BackColor == Color.BlueViolet)
                b86.BackColor = Color.LightGray;
        }

        private void b87_Click(object sender, EventArgs e)
        {
            if (b87.BackColor == Color.LightGray)
                b87.BackColor = Color.BlueViolet;
            else if (b87.BackColor == Color.BlueViolet)
                b87.BackColor = Color.LightGray;
        }

        private void b88_Click(object sender, EventArgs e)
        {
            if (b88.BackColor == Color.LightGray)
                b88.BackColor = Color.BlueViolet;
            else if (b88.BackColor == Color.BlueViolet)
                b88.BackColor = Color.LightGray;
        }

        private void b89_Click(object sender, EventArgs e)
        {
            if (b89.BackColor == Color.LightGray)
                b89.BackColor = Color.BlueViolet;
            else if (b89.BackColor == Color.BlueViolet)
                b89.BackColor = Color.LightGray;
        }

        private void b90_Click(object sender, EventArgs e)
        {
            if (b90.BackColor == Color.LightGray)
                b90.BackColor = Color.BlueViolet;
            else if (b90.BackColor == Color.BlueViolet)
                b90.BackColor = Color.LightGray;
        }

        private void b91_Click(object sender, EventArgs e)
        {
            if (b91.BackColor == Color.LightGray)
                b91.BackColor = Color.BlueViolet;
            else if (b91.BackColor == Color.BlueViolet)
                b91.BackColor = Color.LightGray;
        }

        private void b92_Click(object sender, EventArgs e)
        {
            if (b92.BackColor == Color.LightGray)
                b92.BackColor = Color.BlueViolet;
            else if (b92.BackColor == Color.BlueViolet)
                b92.BackColor = Color.LightGray;
        }

        private void b93_Click(object sender, EventArgs e)
        {
            if (b93.BackColor == Color.LightGray)
                b93.BackColor = Color.BlueViolet;
            else if (b93.BackColor == Color.BlueViolet)
                b93.BackColor = Color.LightGray;
        }

        private void b94_Click(object sender, EventArgs e)
        {
            if (b94.BackColor == Color.LightGray)
                b94.BackColor = Color.BlueViolet;
            else if (b94.BackColor == Color.BlueViolet)
                b94.BackColor = Color.LightGray;
        }

        private void b95_Click(object sender, EventArgs e)
        {
            if (b95.BackColor == Color.LightGray)
                b95.BackColor = Color.BlueViolet;
            else if (b95.BackColor == Color.BlueViolet)
                b95.BackColor = Color.LightGray;
        }

        private void b96_Click(object sender, EventArgs e)
        {
            if (b96.BackColor == Color.LightGray)
                b96.BackColor = Color.BlueViolet;
            else if (b96.BackColor == Color.BlueViolet)
                b96.BackColor = Color.LightGray;
        }

        private void b97_Click(object sender, EventArgs e)
        {
            if (b97.BackColor == Color.LightGray)
                b97.BackColor = Color.BlueViolet;
            else if (b97.BackColor == Color.BlueViolet)
                b97.BackColor = Color.LightGray;
        }

        private void b98_Click(object sender, EventArgs e)
        {
            if (b98.BackColor == Color.LightGray)
                b98.BackColor = Color.BlueViolet;
            else if (b98.BackColor == Color.BlueViolet)
                b98.BackColor = Color.LightGray;
        }

        private void b99_Click(object sender, EventArgs e)
        {
            if (b99.BackColor == Color.LightGray)
                b99.BackColor = Color.BlueViolet;
            else if (b99.BackColor == Color.BlueViolet)
                b99.BackColor = Color.LightGray;
        }

        private void dateTimePickerTicket_ValueChanged(object sender, EventArgs e)
        {
            loadFilms();
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

        private void buttonBuyTicket_MouseHover(object sender, EventArgs e)
        {
            buttonBuyTicket.Select();
        }
    }
}
