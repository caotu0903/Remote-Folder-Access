using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class DoAnMenu : Form
    {
        public DoAnMenu()
        {
            InitializeComponent();
        }

        private void btServer_Click(object sender, EventArgs e)
        {
            DoAnServer sv = new DoAnServer();
            sv.Show();
        }

        private void btClient_Click(object sender, EventArgs e)
        {
            DoAnClientLogin cl = new DoAnClientLogin();
            cl.Show();
        }
    }
}
