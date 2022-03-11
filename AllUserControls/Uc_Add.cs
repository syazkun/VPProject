using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPP.AllUserControls
{
    public partial class Uc_Add : UserControl
    {
        function fn = new function();
        String query;
        private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamadsyazwan\source\repos\VPP\Database1.mdf;Integrated Security = True";
        int picno = 1;
        public Uc_Add()
        {
            InitializeComponent();
        }

        private void ImageSlideshow()
        {
            if (picno == 5)
            {
                picno = 1;
            }
            pictureBox1.ImageLocation = String.Format(@"C:\Users\mohamadsyazwan\source\repos\VPP\ImageSlideshow\Pic{0}.jpg", picno);
            picno++;
            
            if (picno == 2)
            {

                label1.Text = "Butterscotch Cake";
            }
            else if (picno == 3)
            {

                label1.Text = "Pandan Cake";
            }
            else if (picno == 4)
            {

                label1.Text = "Red Velvet Cake";
            }
            else if (picno == 5)
            {

                label1.Text = "Chocolate Cake";
            }

        }

        public void clearAll()
        {
            txtName.Text = "";
            txtCake.SelectedIndex = -1;
            numQuantity.ResetText();
            txtTotal.Text = "";
        }

        public void FocusAll()
        {
            txtName.Focus();
            txtCake.Focus();
            numQuantity.Focus();
            txtTotal.Focus();
        }
        private void Uc_Add_Load(object sender, EventArgs e)
        {
            dbLoad();
        }

        public void dbLoad()
        {
            query = "select * from Ordering";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ImageSlideshow();
        }

        protected int n, total=0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        public void Add()
        {
            try
            {
                if ((txtName.Text != "") && (txtCake.Text != "") && (txtTotal.Text != ""))
                {
                    SqlConnection conn = new SqlConnection(connString);
                    string qryadd = "INSERT into [Ordering] VALUES(@Name,@Cake,@Quantity,@Total)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qryadd, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Cake", txtCake.Text);
                    cmd.Parameters.AddWithValue("@Quantity", numQuantity.Value);
                    cmd.Parameters.AddWithValue("@Total", txtTotal.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if (txtTotal.Text != "0" && txtTotal.Text != "")
                    {

                        total += int.Parse(txtTotal.Text);
                    }
                    else
                    {
                        MessageBox.Show("Minimum Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MessageBox.Show("Successfully inserted");
                    dbLoad();
                    clearAll();
                }//if
                else
                {
                    MessageBox.Show("You must fill all the information!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    FocusAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error add " + ex.Message);
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            totalCal();
        }

        public void totalCal()
        {
            int quan = int.Parse(numQuantity.Value.ToString());
            txtTotal.Text = (quan * a).ToString();
        }

        int a = 0;
        int id;
        int quantity;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                String name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                String cake = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                quantity = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                txtName.Text = name;
                txtCake.Text = cake;
                numQuantity.Value = quantity;

            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        public void Remove()
        {
            try
            {
               
                guna2DataGridView1.Rows.RemoveAt(guna2DataGridView1.SelectedRows[0].Index);
                query = "DELETE from Ordering where id = " + id + "";
                fn.setData(query);
                dbLoad();
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        
        public void Search()
        {
            query = "select * from Ordering where name like'" + txtName.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            clearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updates();
        }

        public void Updates()
        {
            if ((txtName.Text != "") && (txtCake.Text != "") && (numQuantity.Text != "0") && (txtTotal.Text != ""))
            {
                query = "UPDATE Ordering set name='" + txtName.Text + "',cake='" + txtCake.Text + "',quantity='" + numQuantity.Value + "',total=" + txtTotal.Text + " where Id = " + id + "";
                fn.setData(query);
                clearAll();
                dbLoad();
            }
            else
            {
                MessageBox.Show("You must fill all the information!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                FocusAll();
            }

        }

        private void txtCake_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = txtCake.Text;
            if (selection == "Butterscotch Cake - RM100")
            {
                a = 100;
            }
            else if (selection == "Pandan Cake -  RM70")
            {
                a = 70;
            }
            else if (selection == "Red Velvet Cake - RM 150")
            {
                a = 150;
            }
            else if (selection == "Chocolate Cake - RM120")
            {
                a = 120;
            }
            totalCal();
        }
    }
}
