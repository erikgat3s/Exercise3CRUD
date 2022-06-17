using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3PABDCRUD
{
    public partial class Form3 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exe3PABDCRUDDataSet1.Kasir' table. You can move, or remove it, as needed.
            this.kasirTableAdapter.Fill(this.exe3PABDCRUDDataSet1.Kasir);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            txtUser.Enabled = true;
            txtKasir.Enabled = true;
            txtHp.Enabled = true;
            txtId.Text = "";
            txtUser.Text = "";
            txtKasir.Text = "";
            txtHp.Text = "";


            cmdSave.Enabled = true;
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = exe3PABDCRUDDataSet1.Tables["Kasir"];
            dr = dt.NewRow();
            dr[0] = txtId.Text;
            dr[1] = txtUser.Text;
            dr[2] = txtKasir.Text;
            dr[3] = txtHp.Text;
            dt.Rows.Add(dr);
            kasirTableAdapter.Update(exe3PABDCRUDDataSet1);
            txtId.Text = System.Convert.ToString(dr[0]);
            txtUser.Enabled = false;
            txtKasir.Enabled = false;
            txtHp.Enabled = false;
            this.kasirTableAdapter.Fill(this.exe3PABDCRUDDataSet1.Kasir);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtId.Text;
            dr = exe3PABDCRUDDataSet1.Tables["Kasir"].Rows.Find(code);
            dr.Delete();
            kasirTableAdapter.Update(exe3PABDCRUDDataSet1);
        }
    }
}
