using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Seates_REG
{
    public partial class Seat : UserControl
    {
        public Seat()
        {
            InitializeComponent();
            this.BringToFront();
        }
        public void setname(string name)
        {

            this.lbname.Invoke(new Action(delegate { this.lbname.Text = name; }));
        }
        public void setcolor(Color color)
        {

            this.lncoclr.Invoke(new Action(delegate { this.lncoclr.BackColor = color; }));
        }

        private void lbname_Click(object sender, EventArgs e)
        {

        }

       
    }
}
