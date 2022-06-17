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
    public partial class Form4 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exe3PABDCRUDDataSet1.Pemilik' table. You can move, or remove it, as needed.
            this.pemilikTableAdapter.Fill(this.exe3PABDCRUDDataSet1.Pemilik);

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            txtNama.Enabled = true;
            txtId.Text = "";
            txtNama.Text = "";

            cmdSave.Enabled = true;
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = exe3PABDCRUDDataSet1.Tables["Pemilik"];
            dr = dt.NewRow();
            dr[0] = txtId.Text;
            dr[1] = txtNama.Text;
            dt.Rows.Add(dr);
            pemilikTableAdapter.Update(exe3PABDCRUDDataSet1);
            txtId.Text = System.Convert.ToString(dr[0]);
            txtNama.Enabled = false;
            this.pemilikTableAdapter.Fill(this.exe3PABDCRUDDataSet1.Pemilik);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtId.Text;
            dr = exe3PABDCRUDDataSet1.Tables["Pemilik"].Rows.Find(code);
            dr.Delete();
            pemilikTableAdapter.Update(exe3PABDCRUDDataSet1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
