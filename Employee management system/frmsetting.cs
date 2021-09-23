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
    public partial class frmsetting : Form
    {
        public frmsetting()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();
        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Setting(NameCompany,Tel,Address)values(@a,@b,@c)";
                cmd.Parameters.AddWithValue("@a", txtCompany.Text);
                cmd.Parameters.AddWithValue("@b", txtPhone.Text);
                cmd.Parameters.AddWithValue("@c", txtAddress.Text);
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Setting where id=" + txtCode.Text;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update Setting set NameCompany='"+txtCompany.Text+ "',Tel='" + txtPhone.Text + "',Address='" + txtAddress.Text + "' where id="+txtCode.Text;
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

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * From Setting where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtCode.Text = dr["id"].ToString();
                txtCompany.Text = dr["NameCompany"].ToString();
                txtPhone.Text = dr["Tel"].ToString();
                txtAddress.Text = dr["Address"].ToString();
            }
            else
            {

                MessageBox.Show("Nothing found!");
                txtCode.Text = "";
                txtCode.Focus();

            }
            con.Close();
        }

        private void frmsetting_Load(object sender, EventArgs e)
        {

        }
    }
}
