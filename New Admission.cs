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

namespace CRUD_Operation1
{
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text;
            string fname = txtFatherName.Text;
            string gender = "";
            bool isChecked = radioButtonMale.Checked;
            if (isChecked)
            {
                gender = radioButtonMale.Text;
            }
            else
            {
                gender = radioButtonFemale.Text;
            }
            string dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            string email = txtEmail.Text;
            string semester = txtSemester.Text;
            string course = txtCourse.Text;
            string sname = txtSchoolName.Text;
            string duration = txtDuration.Text;
            string add = txtAddress.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(local); database = college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into NewAdmission (name,fname,gender,dob,mobile,email,semester,course,sname,duration,addres) values ('" + name + "','" + fname + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + semester + "','" + course + "','" + sname + "','" + duration + "','" + add + "')";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            MessageBox.Show("Data saved remember the Registration ID", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            txtMobile.Clear();
            txtSchoolName.Clear();
            txtEmail.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            txtCourse.ResetText();
            txtSemester.ResetText();
            txtDuration.ResetText();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{0,68}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    txtEmail.Focus();
                    txtEmail.BackColor = Color.Red;
                }
                else
                {
                    txtEmail.Focus();
                    txtEmail.BackColor = Color.White;
                }
            }
        }

        private void New_Admission_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(local); database = college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select MAX(NAID)from NewAdmission";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            Int64 abc = Convert.ToInt64(DS.Tables[0].Rows[0][0]);
            label13.Text = (abc+1).ToString();
        }
    }
}
