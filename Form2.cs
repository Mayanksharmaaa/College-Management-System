using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Operation1
{
    public partial class Form2 : Form
    {
        int a = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (a == 0)
                label1.Text = "Loading....";
            if (a == 10)
                label1.Text = "Loading Students Information...";
            if (a == 20)
                label1.Text = "Please wait....!";
            if (a == 30)
                label1.Text = "Loading Students Information...";
            if (a == 40)
                label1.Text = "Please wait....!";
            if (a == 50)
                label1.Text = "Loading....";
            if (a == 60)
                label1.Text = "Loading Students Information...";
            if (a == 70)
                label1.Text = "Please wait....!";
            if (a == 80)
                label1.Text = "Loading Students Information...";
            if (a == 90)
                label1.Text = "Almost Done...";
            if (a == 95)
                label1.Text = "Done!";
            //a++;
            a += 1;
            if (a >= 100)
            {
                this.Hide();
                timer1.Enabled = false;
                Form4 frm = new Form4();
                frm.ShowDialog();
            }
            progressBar1.Value = a;
        }
    }
}
