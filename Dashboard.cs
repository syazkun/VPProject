using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPP
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(string user)
        {
            InitializeComponent();

            if (user == "Guest")       
            {
                this.Show();

            }

            else if (user == "Admin")
            {
                this.Show();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            uc_Add1.clearAll();
        }

        private void btnRefreshClear_Click(object sender, EventArgs e)
        {
            uc_Add1.clearAll();
            uc_Add1.dbLoad();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            uc_Add1.Remove();
            uc_Add1.clearAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            uc_Add1.Add();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            uc_Add1.Search();   
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            uc_Add1.Updates();
        }

        public void Uc_AddShow()
        {
            uc_Add1.Visible = true;
            uc_Add1.BringToFront();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Uc_AddShow();
        }
        ToolTip t1 = new ToolTip();
        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Exit Application", btnExit);
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Add to Database", btnAdd);
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Find something on Database", btnSearch);
        }

        private void btnRefreshClear_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Refresh Database Table", btnRefreshClear);
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Update to Database", btnUpdate);
        }

        private void btnRemove_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Remove/Delete Data", btnRemove);
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Clear the input", btnClear);
        }
    }
}
