using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Purchesed.DevForm
{
    public partial class Color : DevExpress.XtraEditors.XtraForm
    {
        public Color()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxColoreDescription.Text == "")
            {
                MessageBox.Show("Please Enter Color Decription", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
               TxColoreDescription.Focus();
                return;

            }
            if (TxColorName.Text == "")
            {
                MessageBox.Show("Please Enter Color Name", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxColorName.Focus();
                return;

            }
            if (PbPicture.Text == "")
            {
                MessageBox.Show("Please Enter Enter Color Image", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
               BtnSelect.Focus();
                return;

            }
            else
            {
                try
                {

                    con.Open();string insert = "insert Into Tb_Color(Serial,ColorDescription,Color,ColorImage) VALUES (@a1,@a2,@a3,@a4)";

                    command = new SqlCommand(insert, con);
                    MemoryStream stream = new MemoryStream();
                    command.Connection = con;
                    command.Parameters.AddWithValue("@a1", LbId.Text);

                    command.Parameters.AddWithValue("@a2", TxColoreDescription.Text);
                    command.Parameters.AddWithValue("@a3", TxColorName.Text);

                    PbPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    command.Parameters.AddWithValue("@a4", pic);


                    command.ExecuteNonQuery();
                    con.Close();




                    MessageBox.Show("Record Successfully Added ", "Succed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();



                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }

           


           

        }
        private void clear()
        {
          
            TxColoreDescription.Text = "";
            TxColorName.Text = "";
            PbPicture.Text = "";
        }

       

        private void ColorIdLoading()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(Serial+1) FROM Tb_Color"; 
            command = new SqlCommand(incre_BillNo);
            command.Connection = con;

            if (Convert.IsDBNull(command.ExecuteScalar()))
            {
                Num = 1;
                
                LbId.Text = Convert.ToString(Num);
            }
            else
            {
                Num = (int)(command.ExecuteScalar());
                LbId.Text = Convert.ToString(Num);
                LbId.Text = Convert.ToString(Num);

            }
            command.Dispose();
            MessageBox.Show("helo");
            con.Close();

        }

        
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            {
                openFileDialog1.Filter = "jpg | *.jpg";
                DialogResult drs = openFileDialog1.ShowDialog();

                if (drs == DialogResult.OK)
                {
                    PbPicture.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
        }

        private void Color_Load(object sender, EventArgs e)
        {
          ;
            AutoIncreamenserial();

        }
        private void AutoIncreamenserial()
        {

            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(Serial+1) FROM Tb_Color"; 
            command = new SqlCommand(incre_BillNo);
            command.Connection = con;

            if (Convert.IsDBNull(command.ExecuteScalar()))
            {
                Num = 1;
                //txtPatientName.Text = Convert.ToString(Num);
                LbId.Text = Convert.ToString(Num);
            }
            else
            {
                Num = (int)(command.ExecuteScalar());
                LbId.Text = Convert.ToString(Num);
                LbId.Text = Convert.ToString(Num);

            }
            command.Dispose();
            con.Close();


        }
        }
}