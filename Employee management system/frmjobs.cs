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
    public partial class frmjobs : Form
    {
        public frmjobs()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void frmjobs_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Jobs(JobName,Pay,Etc)values(@a,@b,@c)";
                cmd.Parameters.AddWithValue("@a", txt_job_name.Text);
                cmd.Parameters.AddWithValue("@b", txt_payroll.Text);
                cmd.Parameters.AddWithValue("@c", txt_etc.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Information saved successfully!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update Jobs set JobName='" + txt_job_name.Text + "',Pay='" + txt_payroll.Text + "',Etc='" + txt_etc.Text + "' where idJob=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Edit operation completed successfully!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Jobs where idJob=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Removal operation completed successfully!");

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

        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * From Jobs where idJob=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtCode.Text = dr["idJob"].ToString();
                txt_job_name.Text = dr["JobName"].ToString();
                txt_payroll.Text = dr["Pay"].ToString();
                txt_etc.Text = dr["Etc"].ToString();
            }
            else
            {

                txtCode.Text = "";
                MessageBox.Show("Nothing found!");

            }
            con.Close();
        }
    }
}
