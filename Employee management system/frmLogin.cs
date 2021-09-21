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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                int i = 0;
                cmd = new SqlCommand("select count(*) from Employee where UName=@UName AND Password=@Password", con);
                cmd.Parameters.AddWithValue("@UName", textUname.Text);
                cmd.Parameters.AddWithValue("@Password", textPass.Text);
                con.Open();
                i = (int)cmd.ExecuteScalar();
                con.Close();

                if (i > 0)
                {
                    this.Hide();
                    new Form1().ShowDialog();
                    this.Close();
                
                }
                else
                {

                    MessageBox.Show("Wrong username or password");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            
            }
        }
    }
}
