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
        public AboutFilm()
        {
            InitializeComponent();

            comboBoxSelectFilm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectFilm.MaxDropDownItems = 9;
            showInfoAboutFilm();
        }

        public void showInfoAboutFilm ()
        {
            //posterPictureBox.Image = Properties.Resources._5;

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
            
            comboBoxSelectFilm.SelectedIndex = 2;


        }
    }
}
