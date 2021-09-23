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
    public partial class frmLocation : Form
    {
        public frmLocation()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        private void frmLocation_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Rooms(NumberRoom,NameRoom,Info)values(@A,@B,@C)";
                cmd.Parameters.AddWithValue("@A", txtCode.Text);
                cmd.Parameters.AddWithValue("@B", txtLocation.Text);
                cmd.Parameters.AddWithValue("@C", txtInfo.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Information saved successfully!");

            }
            catch(Exception ex)
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
                cmd.CommandText = "Delete from Rooms where NumberRoom = " + txtCode.Text;
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
            cmd.CommandText = "select * From Rooms where NumberRoom=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtCode.Text = dr["NumberRoom"].ToString();
                txtLocation.Text = dr["NameRoom"].ToString();
                txtInfo.Text = dr["Info"].ToString();
            }
            else
            {

                MessageBox.Show("Nothing found!");
                txtCode.Text = "";
                txtCode.Focus();
            }
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update Rooms set NameRoom='" + txtLocation.Text + "',Info='" + txtInfo.Text + "' where NumberRoom=" + txtCode.Text;
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
    }
}
