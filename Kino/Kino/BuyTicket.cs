using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class BuyTicket : Form
    {
        public BuyTicket()
        {
            InitializeComponent();

            formDesign();
        }

        public void formDesign()
        {
            // КАЛЕНДАРЬ

            dateTimePickerTicket.MinDate = DateTime.Today;
            dateTimePickerTicket.MaxDate = dateTimePickerTicket.MinDate.AddDays(2);

            // ВЫПАДАЮЩИЙ СПИСОК - COMBOBOX



            // ТАБЛИЦА МЕСТ - TABLE_LAYOUT_PANEL

            tableLayoutPanel.AutoScroll = false;
            tableLayoutPanel.AllowDrop = false;


            int w = tableLayoutPanel.Width;
            int h = tableLayoutPanel.Height;

            
            
        }
    }
}
