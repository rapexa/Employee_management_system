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
    public partial class frmleaves : Form
    {
        public frmleaves()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmleaves_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Insert into Leaves (Codep,codeM,Jobname,Date,Count,Nameemployee,Lastnameemployee,Info) values (@A,@B,@C,@D,@E,@F,@G,@H);";
                cmd.Parameters.AddWithValue("@A",txt_p_code.Text);
                cmd.Parameters.AddWithValue("@B", txt_leave_code.Text);
                cmd.Parameters.AddWithValue("@C", txt_job.Text);
                cmd.Parameters.AddWithValue("@D", msk_date.Text);
                cmd.Parameters.AddWithValue("@E", txt_leave_days.Text);
                cmd.Parameters.AddWithValue("@F", txt_first_name.Text);
                cmd.Parameters.AddWithValue("@G", txt_lastname.Text);
                cmd.Parameters.AddWithValue("@H", txt_info.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Information saved successfully!");

                txt_p_code.Text = "";
                txt_leave_code.Text = "";
                txt_job.Text = "";
                msk_date.Text = "";
                txt_leave_days.Text = "";
                txt_first_name.Text = "";
                txt_lastname.Text = "";
                txt_info.Text = "";

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Leaves where codeM=%N;";
                cmd.Parameters.AddWithValue("@N",txt_leave_code.Text);
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "update Leaves set Codep='"+txt_p_code.Text+"',codeM='"+ txt_leave_code.Text + "',Jobname='"+txt_job.Text+"',Date='"+msk_date.Text+"',Count='"+txt_leave_days.Text+"',Nameemployee='"+txt_first_name.Text+"',Lastnameemployee='"+txt_lastname.Text+"',Info='"+txt_info.Text+"' where codeM=;"+ txt_leave_code.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Edit operation completed successfully!");

                txt_p_code.Text = "";
                txt_leave_code.Text = "";
                txt_job.Text = "";
                msk_date.Text = "";
                txt_leave_days.Text = "";
                txt_first_name.Text = "";
                txt_lastname.Text = "";
                txt_info.Text = "";

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnS_leave_code_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Leaves where codeM=@Z;";
            cmd.Parameters.AddWithValue("@Z", txt_leave_code.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read()) 
            {

                txt_p_code.Text = dr["Codep"].ToString();
                txt_leave_code.Text = dr["codeM"].ToString();
                txt_job.Text = dr["Jobname"].ToString();
                msk_date.Text = dr["Date"].ToString();
                txt_leave_days.Text = dr["Count"].ToString();
                txt_first_name.Text = dr["Nameemployee"].ToString();
                txt_lastname.Text = dr["Lastnameemployee"].ToString();
                txt_info.Text = dr["Info"].ToString();

            }
            else
            {

                MessageBox.Show("Nothing found!");
                txt_leave_code.Text = "";
                txt_leave_code.Focus();

            }
            con.Close();

        }

        private void btns_p_code_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Employment where CodeP=@Z;";
            cmd.Parameters.AddWithValue("@Z", txt_p_code.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                txt_p_code.Text = dr["CodeP"].ToString();
                txt_job.Text = dr["JobName"].ToString();
                txt_first_name.Text = dr["NameEmployee"].ToString();
                txt_lastname.Text = dr["LastName"].ToString();

            }
            else
            {

                MessageBox.Show("Nothing found!");
                txt_p_code.Text = "";
                txt_p_code.Focus();

            }
            con.Close();
        }
    }
}
