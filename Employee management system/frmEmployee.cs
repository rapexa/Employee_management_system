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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=EmployeeDB; integrated security = true");
        SqlCommand cmd = new SqlCommand();

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxAdv1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelX16_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "All Pictures(*.*)|*.jpg;*.bmp;*.png;*.ico;*.gif";
                op.ShowDialog();
                pictureBox1.ImageLocation = op.FileName;

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btn_delete_pic_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                if (pictureBox1.Image == null)
                {

                    MessageBox.Show("Choose picture for Employee !");
                    return;
                }
                con.Open();
                string path = pictureBox1.ImageLocation;
                byte[] ar = System.IO.File.ReadAllBytes(pictureBox1.ImageLocation);
                SqlCommand cmd = new SqlCommand("insert into Employment (CodeP,CodeM,NameEmployee,LastName,NameDad,Birth,IDCode,Education,Phone,Mobile,Maritalstat,Milatary,JobName,Salary,RoomNumber,RoomName,EmploymentDate,EmploymentType,Pic)values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s)", con);
                cmd.Parameters.AddWithValue("@a", txt_personal_Code.Text);
                cmd.Parameters.AddWithValue("@b", txt_national_code.Text);
                cmd.Parameters.AddWithValue("@c", txt_name.Text);
                cmd.Parameters.AddWithValue("@d", txt_last_name.Text);
                cmd.Parameters.AddWithValue("@e", txt_father_name.Text);
                cmd.Parameters.AddWithValue("@f", msk_date_birth.Text);
                cmd.Parameters.AddWithValue("@g", txt_id.Text);
                cmd.Parameters.AddWithValue("@h", cmb_education.Text);
                cmd.Parameters.AddWithValue("@i", txt_phone.Text);
                cmd.Parameters.AddWithValue("@j", txt_mobile.Text);
                cmd.Parameters.AddWithValue("@k", cmb_marital.Text);
                cmd.Parameters.AddWithValue("@l", cmb_milatary.Text);
                cmd.Parameters.AddWithValue("@m", txt_Job.Text);
                cmd.Parameters.AddWithValue("@n", txt_salary.Text);
                cmd.Parameters.AddWithValue("@o", txt_room_code.Text);
                cmd.Parameters.AddWithValue("@p", txt_room_name.Text);
                cmd.Parameters.AddWithValue("@q", msk_date_employ.Text);
                cmd.Parameters.AddWithValue("@r", cmb_employ_status.Text);
                cmd.Parameters.AddWithValue("@s", SqlDbType.VarBinary).Value = ar;
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Information saved successfully!");

                txt_personal_Code.Focus(); ;
                txt_personal_Code.Text = "";
                txt_national_code.Text = "";
                txt_name.Text = "";
                txt_last_name.Text = "";
                txt_father_name.Text = "";
                msk_date_birth.Text = "";
                txt_id.Text = "";
                // cmb_education.Text = "";
                txt_phone.Text = "";
                txt_mobile.Text = "";
                // cmb_marital.Text = "";
                // cmb_milatary.Text = "";
                txt_Job.Text = "";
                txt_salary.Text = "";
                txt_room_code.Text = "";
                txt_room_name.Text = "";
                txt_salary.Text = "";
                msk_date_employ.Text = "";
                // cmb_employ_status.Text = "";
                pictureBox1.Image = null;

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
                cmd.CommandText = "Delete from Employment where CodeP="+txt_personal_Code.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Removal operation completed successfully!");

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        Image imagebyte(byte [] bytes)
        {

            System.IO.MemoryStream m = new System.IO.MemoryStream(bytes);
            return Image.FromStream(m);
        
        }

        private void btnS_personal_code_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Employment where CodeP=@N";
            cmd.Parameters.AddWithValue("@N", txt_personal_Code.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_personal_Code.Text = dr["CodeP"].ToString();
                txt_national_code.Text = dr["CodeM"].ToString();
                txt_name.Text = dr["NameEmployee"].ToString();
                txt_last_name.Text = dr["LastName"].ToString();
                txt_father_name.Text = dr["NameDad"].ToString();
                msk_date_birth.Text = dr["Birth"].ToString();
                txt_id.Text = dr["IDCode"].ToString();
                cmb_education.Text = dr["Education"].ToString();
                txt_phone.Text = dr["Phone"].ToString();
                txt_mobile.Text = dr["Mobile"].ToString();
                cmb_marital.Text = dr["Maritalstat"].ToString();
                cmb_milatary.Text = dr["Milatary"].ToString();
                txt_Job.Text = dr["JobName"].ToString();
                txt_salary.Text = dr["Salary"].ToString();
                txt_room_code.Text = dr["RoomNumber"].ToString();
                txt_room_name.Text = dr["RoomName"].ToString();
                msk_date_employ.Text = dr["EmploymentDate"].ToString();
                cmb_employ_status.Text = dr["EmploymentType"].ToString();
                pictureBox1.Image = imagebyte((byte[]) dr[19]);

            }
            else
            {

                txt_personal_Code.Text = "";
                MessageBox.Show("Nothing found!");

            }
            con.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try
            {

                pictureBox1.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Bmp);

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            byte[] arPic = ms.GetBuffer();
            ms.Close();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            string UpdateEmployee = "Update Employment set CodeP='"+txt_personal_Code.Text+"',CodeM='"+txt_national_code.Text+"',NameEmployee='"+txt_name.Text+"',LastName='"+txt_last_name.Text+"',NameDad='"+txt_father_name.Text+"',Birth='"+msk_date_birth.Text+"',IDCode='"+txt_id.Text+"',Education='"+cmb_education.Text+"',Phone='"+txt_phone.Text+"',Mobile='"+txt_mobile.Text+"',Maritalstat='"+cmb_marital.Text+"',Milatary='"+cmb_milatary.Text+"',JobName='"+txt_Job.Text+"',Salary='"+txt_salary.Text+"',RoomNumber='"+txt_room_code.Text+ "',RoomName='"+txt_room_name.Text+"',EmploymentDate='"+msk_date_employ.Text+"',EmploymentType='"+cmb_employ_status.Text+"',Pic=@Pic";
            SqlCommand com = new SqlCommand(UpdateEmployee,con);
            com.Parameters.AddWithValue("@Pic",arPic);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Edit operation completed successfully!");
        }

        private void btnS_job_code_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * From Jobs where idJob=@N";
            cmd.Parameters.AddWithValue("@N", txt_job_code.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txt_job_code.Text = dr["idJob"].ToString();
                txt_Job.Text = dr["JobName"].ToString();
                txt_salary.Text = dr["Pay"].ToString();
            }
            else
            {

                MessageBox.Show("Nothing found!");
                txt_job_code.Text = "";
                txt_job_code.Focus();

            }
            con.Close();
        }

        private void btn_serach_room_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * From Rooms where NumberRoom=@N";
            cmd.Parameters.AddWithValue("@N", txt_room_code.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txt_room_code.Text = dr["NumberRoom"].ToString();
                txt_room_name.Text = dr["NameRoom"].ToString();
            }
            else
            {

                MessageBox.Show("Nothing found!");
                txt_room_code.Text = "";
                txt_room_code.Focus();

            }
            con.Close();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            new FrmlistEmployee().ShowDialog();
        }

        private void txt_last_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
