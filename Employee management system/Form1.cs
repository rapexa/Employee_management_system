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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void expandablePanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            new frmUser().ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmsetting().ShowDialog();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_req_leave_Click(object sender, EventArgs e)
        {
            new frmleaves().ShowDialog();
        }

        private void btn_def_jobs_Click(object sender, EventArgs e)
        {
            new frmjobs().ShowDialog();
        }

        private void btn_list_jobs_Click(object sender, EventArgs e)
        {
            new FrmListJobs().ShowDialog();
        }

        private void btn_workspace_Click(object sender, EventArgs e)
        {
            new frmLocation().ShowDialog();
        }

        private void btn_def_employee_Click(object sender, EventArgs e)
        {
            new frmEmployee().ShowDialog();
        }

        private void btn_list_employee_Click(object sender, EventArgs e)
        {
            new FrmlistEmployee().ShowDialog();
        }

        private void btn_workspace_Click_1(object sender, EventArgs e)
        {
            new frmLocation().ShowDialog();
        }
    }
}
