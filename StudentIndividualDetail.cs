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
    public partial class StudentIndividualDetail : Form
    {
        public StudentIndividualDetail()
        {
            InitializeComponent();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(local); database = college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewAdmission where NAID = " + textBox1.Text + "";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                labelFullName.Text = ds.Tables[0].Rows[0][1].ToString();
                labelFatherName.Text = ds.Tables[0].Rows[0][2].ToString();
                labelGender.Text = ds.Tables[0].Rows[0][3].ToString();
                labelDateOfBirth.Text = ds.Tables[0].Rows[0][4].ToString();
                labelMobile.Text = ds.Tables[0].Rows[0][5].ToString();
                labelEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                labelStandard.Text = ds.Tables[0].Rows[0][7].ToString();
                labelCourse.Text = ds.Tables[0].Rows[0][8].ToString();
                labelSchoolName.Text = ds.Tables[0].Rows[0][9].ToString();
                labelYear.Text = ds.Tables[0].Rows[0][10].ToString();
                labelAddress.Text = ds.Tables[0].Rows[0][11].ToString();
            }
            else
            {
                labelFullName.Text = "________";
                labelFatherName.Text = "________";
                labelGender.Text = "________";
                labelDateOfBirth.Text = "________";
                labelMobile.Text = "________";
                labelEmail.Text = "________";
                labelStandard.Text = "________";
                labelCourse.Text = "________";
                labelSchoolName.Text = "________";
                labelYear.Text = "________";
                labelAddress.Text = "________";
                MessageBox.Show("Record Not Found", "No Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            labelFullName.Text = "________";
            labelFatherName.Text = "________";
            labelGender.Text = "________";
            labelDateOfBirth.Text = "________";
            labelMobile.Text = "________";
            labelEmail.Text = "________";
            labelStandard.Text = "________";
            labelCourse.Text = "________";
            labelSchoolName.Text = "________";
            labelYear.Text = "________";
            labelAddress.Text = "________";

            textBox1.Text = "";
        }
    }
}
