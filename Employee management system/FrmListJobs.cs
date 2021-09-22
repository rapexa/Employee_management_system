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
using Stimulsoft.Report;

namespace Employee_management_system
{
    public partial class FrmListJobs : Form
    {
        public FrmListJobs()
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
            adp.SelectCommand.CommandText = "select * from Jobs";
            adp.Fill(ds, "Jobs");
            dgv_list_jobs.DataSource = ds;
            dgv_list_jobs.DataMember = "Jobs";
            dgv_list_jobs.Columns[0].HeaderText = "Code";
            dgv_list_jobs.Columns[1].HeaderText = "JobName";
            dgv_list_jobs.Columns[2].HeaderText = "Pay";
            dgv_list_jobs.Columns[3].HeaderText = "Etc";

            dgv_list_jobs.Columns[0].Width = 50;
            dgv_list_jobs.Columns[3].Width = 500;
            dgv_list_jobs.Columns[1].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmListJobs_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                int x = Convert.ToInt32(dgv_list_jobs.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Jobs where idJob=@N";
                cmd.Parameters.AddWithValue("@N", x);
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Jobs where idJob Like '%'+ @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s",txtCode.Text + "%");
            adp.Fill(ds, "Jobs");
            dgv_list_jobs.DataSource = ds;
            dgv_list_jobs.DataMember = "Jobs";
        }

        private void txt_job_name_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Jobs where JobName Like '%'+ @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txt_job_name.Text + "%");
            adp.Fill(ds, "Jobs");
            dgv_list_jobs.DataSource = ds;
            dgv_list_jobs.DataMember = "Jobs";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport rpt = new StiReport();
            rpt.Load("Reports/RptJobs.mrt");
            rpt.Compile();
            rpt.ShowWithRibbonGUI();
        }
    }
}
