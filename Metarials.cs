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
    public partial class Metarials : DevExpress.XtraEditors.XtraForm
    {
        public Metarials()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            TxMcode.Text = "";
            TxMtype.Text = "";
            TxMclass.Text = "";
            TxDescription.Text = "";
            TxConstruction.Text = "";
            TxContent.Text = "";
            TxWidth.Text = "";
            TxWeight.Text = "";
            TxDyeing.Text = "";
            TxFinishing.Text = "";PbPicture.Text = "";
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void AutoIncreamenTsId()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(MpId+1) FROM Tb_Meterial"; command = new SqlCommand(incre_BillNo);
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string insert = "insert Into Tb_Meterial(MpId,Date,MeterialCode,MeterialType,MeterialClass,Description,MeterialContent,Constraction,Weight,Width,Dyeing,Finishing,Picture) VALUES (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13)";

                command = new SqlCommand(insert, con);
                MemoryStream stream = new MemoryStream();
                command.Connection = con;
                command.Parameters.AddWithValue("@a1", LbId.Text);

                command.Parameters.AddWithValue("@a2", DateTime.ParseExact(DtDate.Text, "dd/MM/yyyy", null));
                command.Parameters.AddWithValue("@a3", TxMcode.Text);
                command.Parameters.AddWithValue("@a4", TxMtype.Text);
                command.Parameters.AddWithValue("@a5", TxMclass.Text);
                command.Parameters.AddWithValue("@a6", TxDescription.Text);
                command.Parameters.AddWithValue("@a7", TxContent.Text);
                command.Parameters.AddWithValue("@a8", TxConstruction.Text);
                command.Parameters.AddWithValue("@a9", TxWeight.Text);
                command.Parameters.AddWithValue("@a10", TxWidth.Text);
                command.Parameters.AddWithValue("@a11", TxDyeing.Text);
                command.Parameters.AddWithValue("@a12", TxWeight.Text);
                PbPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                command.Parameters.AddWithValue("@a13", pic);

                con.Close();
                con.Open();
                command.ExecuteNonQuery();
                con.Close();




                MessageBox.Show("Record Successfully Added ", "Succed", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


            clear();

        }

        private void Metarials_Load(object sender, EventArgs e)
        {
            AutoIncreamenTsId();
        }
    }
}