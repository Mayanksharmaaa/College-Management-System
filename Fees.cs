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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void txtRegNumber_TextChanged(object sender, EventArgs e)
        {
            if(txtRegNumber.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =(local); database = college;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select name,fname,duration from NewAdmission where NAID = " + txtRegNumber.Text + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                if (DS.Tables[0].Rows.Count != 0)
                {
                    NameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    FnameLabel.Text = DS.Tables[0].Rows[0][1].ToString();
                    DurationLabel.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    NameLabel.Text = "________";
                    FnameLabel.Text = "________";
                    DurationLabel.Text = "________";
                }
            }
            else
            {
                txtRegNumber.Text = "";
                txtFees.Text = "";
                NameLabel.Text = "________";
                FnameLabel.Text = "________";
                DurationLabel.Text = "________";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =(local); database = college;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from fees where NAID = " + txtRegNumber.Text + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            if(DS.Tables[0].Rows.Count == 0)
            {

                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source =(local); database = college;integrated security=True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                cmd1.CommandText = "insert into fees (NAID,fees) values (" + txtRegNumber.Text + "," + txtFees.Text + ")";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);

                if (MessageBox.Show("Fees Submittion Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegNumber.Text = "";
                    txtFees.Text = "";
                    NameLabel.Text = "________";
                    FnameLabel.Text = "________";
                    DurationLabel.Text = "________";
                }
            }

            else
            {
                MessageBox.Show("The fees is already submitted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegNumber.Text = "";
                txtFees.Text = "";
                NameLabel.Text = "________";
                FnameLabel.Text = "________";
                DurationLabel.Text = "________";
            }
        }
    }
}
