using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_management_system
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();


        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void lblcode_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Employee(UName,Password)values(@UName,@Password)";
                cmd.Parameters.AddWithValue("@UName", textUname.Text);
                cmd.Parameters.AddWithValue("@Password", textPass.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("User successfully registered!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Display() 
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Employee";
            adp.Fill(ds, "Employee");
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "Employee";
            dgvUser.Columns[0].HeaderText = "Code"; 
            dgvUser.Columns[1].HeaderText = "Username"; 
            dgvUser.Columns[2].HeaderText = "Password";

            dgvUser.Columns[0].Width = 50;
        }


        private void frmUser_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                int x = Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete From Employee where id=@ID";
                cmd.Parameters.AddWithValue("@ID", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("User successfully removed!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            
            }
        }
    }
}
