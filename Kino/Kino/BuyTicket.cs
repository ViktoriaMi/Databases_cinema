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

            designTableLayoutPanel();
        }

        public void designTableLayoutPanel()
        {
            tableLayoutPanel.AutoScroll = false;
            tableLayoutPanel.AllowDrop = false;
            //tableLayoutPanel.Controls.Add(b00, 0, 0);

            int w = tableLayoutPanel.Width;
            int h = tableLayoutPanel.Height;

        }
    }
}
