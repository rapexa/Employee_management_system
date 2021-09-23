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
    public partial class FrmlistEmployee : Form
    {
        public FrmlistEmployee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Employment";
            adp.Fill(ds, "Employment");
            dgvEmployee.DataSource = ds;
            dgvEmployee.DataMember = "Employment";

            dgvEmployee.Columns[0].HeaderText = "number";
            dgvEmployee.Columns[1].HeaderText = "Personal code";
            dgvEmployee.Columns[2].HeaderText = "National code";
            dgvEmployee.Columns[3].HeaderText = "Name";
            dgvEmployee.Columns[4].HeaderText = "Last name";
            dgvEmployee.Columns[5].HeaderText = "Father's name";
            dgvEmployee.Columns[6].HeaderText = "Birth date";
            dgvEmployee.Columns[7].HeaderText = "ID";
            dgvEmployee.Columns[8].HeaderText = "Education";
            dgvEmployee.Columns[9].HeaderText = "Phone";
            dgvEmployee.Columns[10].HeaderText = "Mobile";
            dgvEmployee.Columns[11].HeaderText = "Marital status";
            dgvEmployee.Columns[12].HeaderText = "Military";
            dgvEmployee.Columns[13].HeaderText = "Job";
            dgvEmployee.Columns[14].HeaderText = "Salary";
            dgvEmployee.Columns[15].HeaderText = "Room code";
            dgvEmployee.Columns[16].HeaderText = "Room name";
            dgvEmployee.Columns[17].HeaderText = "Employment date";
            dgvEmployee.Columns[18].HeaderText = "Employment status";
            dgvEmployee.Columns[19].HeaderText = "Picture";
        }

        private void FrmlistEmployee_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_personal_Code_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Employment where CodeP Like '%'+@S+'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S",txt_personal_Code.Text);
            adp.Fill(ds, "Employment");
            dgvEmployee.DataSource = ds;
            dgvEmployee.DataMember = "Employment";
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void txt_last_name_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Employment where LastName Like '%'+@S+'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txt_last_name.Text);
            adp.Fill(ds, "Employment");
            dgvEmployee.DataSource = ds;
            dgvEmployee.DataMember = "Employment";
        }

        private void txt_Job_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Employment where JobName Like '%'+@S+'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txt_Job.Text);
            adp.Fill(ds, "Employment");
            dgvEmployee.DataSource = ds;
            dgvEmployee.DataMember = "Employment";
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try 
            {

                int x = Convert.ToInt32(dgvEmployee.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "delete from Employment where Id=@N";
                cmd.Parameters.AddWithValue("@N",x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Removal operation completed successfully!");

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
