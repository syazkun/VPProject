using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPP.AllUserControls
{
    public partial class Uc_Welcome : UserControl
    {
        public Uc_Welcome()
        {
            InitializeComponent();
        }

        int counter = 0;
        int len = 0;
        string txt;

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter > len)
            {
                counter = 0;
                lblWelcome.Text = "";
            }

            else
            {

                lblWelcome.Text = txt.Substring(0, counter);
            }

        }

        private void Uc_Welcome_Load(object sender, EventArgs e)
        {
            txt = lblWelcome.Text;
            len = txt.Length;
            lblWelcome.Text = "";
            timer1.Start();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
  
        }
    }
}
