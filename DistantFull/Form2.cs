using System;
using System.Windows.Forms;

namespace DistantFull
{
    public partial class InpIP : Form
    {
        public string IP = string.Empty;
        public InpIP()
        {
            InitializeComponent();
        }

        private void ok_b_Click(object sender, EventArgs e)
        {
            IP = IPS.Text;
            this.Close();
        }
    }
}
