using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Operation1
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool isChecked = radioMale.Checked;

            if(isChecked)
            {
                gender = radioMale.Text;
            }
            else
            {
                gender = radioFemale.Text;
            }
            
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(local); database = college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into teacher (fname,gender,dob,mobile,email,semester,course,yer,adr) values ('"+txtFullName.Text+"','"+gender+"','"+dateTimePickerDOB.Text+"',"+txtMobile.Text+",'"+txtEmail.Text+"','"+txtSemester.Text+"','"+txtCourse.Text+"','"+txtDuration.Text+"','"+txtAddress.Text+"')";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtAddress.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            radioMale.Checked = false;
            radioFemale.Checked = false;
            txtCourse.ResetText();
            txtSemester.ResetText();
            txtDuration.ResetText();
        }
    }
}
