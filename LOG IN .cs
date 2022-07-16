using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Purchesed.DevForm
{
    public partial class LOG_IN : DevExpress.XtraEditors.XtraForm
    {
        public LOG_IN()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Tb_Login Where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ",con);
            DataTable aDataTable=new DataTable();
            sda.Fill(aDataTable);
            if(aDataTable.Rows[0][0].ToString()=="1")
            {
                Deshboard aDeshboard = new Deshboard();
                aDeshboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Cheak UserName And Password");
            }
            
        }

        private void LOG_IN_Load(object sender, EventArgs e)
        {

        }
    }
}