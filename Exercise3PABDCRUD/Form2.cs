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
    public partial class Form2 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;

        public Form2()
        {
            InitializeComponent();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exe3PABDCRUDDataSet1.Pegawai' table. You can move, or remove it, as needed.
            this.pegawaiTableAdapter.Fill(this.exe3PABDCRUDDataSet1.Pegawai);
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            txtId.Enabled = true;
            txtNIK.Enabled = true;
            txtNama.Enabled = true;
            txtStatus.Enabled = true;
            txtId.Text = "";
            txtNIK.Text = "";
            txtNama.Text = "";
            txtStatus.Text = "";
            

            cmdSave.Enabled = true;
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = exe3PABDCRUDDataSet1.Tables["Pegawai"];
            dr = dt.NewRow();
            dr[0] = txtId.Text;
            dr[1] = txtNIK.Text;
            dr[2] = txtNama.Text;
            dr[3] = txtStatus.Text;
            dt.Rows.Add(dr);
            pegawaiTableAdapter.Update(exe3PABDCRUDDataSet1);
            txtId.Text = System.Convert.ToString(dr[0]);
            txtNIK.Enabled = false;
            txtNama.Enabled = false;
            txtStatus.Enabled = false;
            this.pegawaiTableAdapter.Fill(this.exe3PABDCRUDDataSet1.Pegawai);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string code;
            code = txtId.Text;
            dr = exe3PABDCRUDDataSet1.Tables["Pegawai"].Rows.Find(code);
            dr.Delete();
            pegawaiTableAdapter.Update(exe3PABDCRUDDataSet1);
        }
    }
}
