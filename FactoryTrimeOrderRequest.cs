using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace Purchesed.DevForm
{
    public partial class FactoryTrimeOrderRequest : DevExpress.XtraEditors.XtraForm
    {
        public FactoryTrimeOrderRequest()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private void CmbFacId_SelectedIndexChanged(object sender, EventArgs e)
        {
            autoloadfactoryCode();
        }

        private void autoloadfactoryCode()
        {

            con.Open();
            command =
                new SqlCommand(
                    "SELECT FactoryCode,FactorName  from  Tb_Factory where FacId='" + CmbFacId.Text +
                    "' ", con);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                 TxtFactroyCode.Text = reader[0].ToString();
                 TxFactory.Text = reader[1].ToString();

                }


            con.Close();






            }
        private void AutoIncreamenFTORid()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(FTORid+1) FROM Tb_FactoryTrimeOrderRequest"; command = new SqlCommand(incre_BillNo);
            command.Connection = con;

            if (Convert.IsDBNull(command.ExecuteScalar()))
            {
                Num = 1;
                //txtPatientName.Text = Convert.ToString(Num);
                LbFTOR.Text = Convert.ToString(Num);
            }
            else
            {
                Num = (int)(command.ExecuteScalar());
                LbFTOR.Text = Convert.ToString(Num);
                LbFTOR.Text = Convert.ToString(Num);

            }
            command.Dispose();
            con.Close();


        }

        private void FactoryTrimeOrderRequest_Load(object sender, EventArgs e)
        {
            AutoIncreamenFTORid();//  Combolist();
            FactoryIdLoad();
            trimeIdLoad();
            autoloadfactoryCode();


            coloreCodeLoad();
        }

        private void AutoLoadTrimeCode()
        {

            command =
                new SqlCommand(
                    "SELECT TrimeCode,TrimeClass,Description,Spece,Dyeing,Finishing from  TbTrime where TpId='" +
                    CmbTrimeId.Text + "' ", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TxTrimecode.Text = reader[0].ToString();
                TxTrimeClass.Text = reader[1].ToString();
                TxDecription.Text = reader[2].ToString();
                TxSepc.Text = reader[3].ToString();
                TxDyeing.Text = reader[4].ToString();
                TxFinishing.Text = reader[5].ToString();

            }
            con.Close();










        }

        private void trimeIdLoad()
        {
            try
            {

                string query = "SELECT  TpId,id  from  TbTrime";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandText = query;
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())

                {

                    CmbTrimeId.Items.Add(drd["TpId"].ToString());
                    CmbTrimeId.ValueMember = drd["id"].ToString();
                    CmbTrimeId.DisplayMember = drd["TpId"].ToString();

                    // 
                }


                con.Close();
            }
            catch
            {
                MessageBox.Show("Eroor");
            }



        }

        private void CmbTrimeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // CmbOrigin.Items.Clear();

           
                AutoLoadTrimeCode();
                originLoad();
                CmbUnite.Items.Clear();
                CmbUnite.Text = "";
        
        }


        private void BtnSelect_Click(object sender, EventArgs e)
        {


            openFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
            ;
            DialogResult drs = openFileDialog1.ShowDialog();

            if (drs == DialogResult.OK)
            {
                PbPicture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void coloreCodeLoad()
        {
            try
            {

                string query = "SELECT  ColorDescription,id  from  Tb_Color";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandText = query;
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {

                    CmbColoreCode.Items.Add(drd["ColorDescription"].ToString());
                    CmbColoreCode.ValueMember = drd["id"].ToString();
                    CmbColoreCode.DisplayMember = drd["ColorDescription"].ToString();

                    //

                }


                con.Close();
            }
            catch
            {
                MessageBox.Show("Eroor");
            }


        }

        private void CmbColoreCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT ColorId,Color from  Tb_Color where ColorDescription='" + CmbColoreCode.Text + "' ", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TxColorCode.Text = reader[0].ToString();
                TxtColoreName.Text = reader[1].ToString();
            }

            con.Close();
        }

        private void originLoad()
        {
              CmbOrigin.Items.Clear();
             
                  string q = "select distinct Origin from Tb_TrimeQuotation where TpId= '" + CmbTrimeId.Text + "'";
                  SqlDataAdapter da = new SqlDataAdapter(q, con);
                  DataTable dt = new DataTable();

                  da.Fill(dt);

                  CmbOrigin.Items.Add("--Select--");
                  foreach (DataRow row in dt.Rows)
                  {
                      CmbOrigin.Items.Add(row["Origin"]);
                  }
                  CmbOrigin.SelectedIndex = 0;
             
       
        }

        private void uniteLoad ()
            {
                
        
            if(CmbOrigin.Text!="--Select--" && CmbTrimeId.Text!=" ")
            {
                string q = "select distinct Unite from Tb_TrimeQuotation where (TpId= '" + CmbTrimeId.Text +
                           "' and Origin= '" + CmbOrigin.Text + "')"; //  CmbUnite.SelectedIndex = 0;
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                CmbUnite.Items.Add("--Select--");
                foreach (DataRow row in dt.Rows)
                {
                    CmbUnite.Items.Add(row["Unite"]);

                }
                CmbUnite.SelectedIndex = 0;
            }
           
            
        }
        private void CmbOrigin_SelectedIndexChanged (object sender, EventArgs e)
        {
            CmbUnite.Items.Clear();
            uniteLoad();
        }


       
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FactoryIdLoad()
        {
            try
            {

                string query = "SELECT  FacId,id  from  Tb_Factory";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandText = query;
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {

                    CmbFacId.Items.Add(drd["FacId"].ToString());
                    CmbFacId.ValueMember = drd["id"].ToString();
                    CmbFacId.DisplayMember = drd["FacId"].ToString();

                    // 
                }


                con.Close();
            }
            catch
            {
                MessageBox.Show("Eroor");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                string insert = "insert Into Tb_FactoryTrimeOrderRequest(FTORid,RequestDate,FacId,TrimeId,ColorId,Origin,Quentity,Unite,Purpose,RequestBy,PriId,NeedDate,Picture,Remark) VALUES (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14)";

                command = new SqlCommand(insert, con);
                MemoryStream stream = new MemoryStream();
                command.Connection = con;
                command.Parameters.AddWithValue("@a1", LbFTOR.Text);

                command.Parameters.AddWithValue("@a2", DtpDate.Text);
                command.Parameters.AddWithValue("@a3", CmbFacId.Text);
                command.Parameters.AddWithValue("@a4", CmbTrimeId.Text);
                command.Parameters.AddWithValue("@a5", TxColorCode.Text);
                command.Parameters.AddWithValue("@a6", CmbOrigin.Text);
                command.Parameters.AddWithValue("@a7", TxQuentity.Text);
                command.Parameters.AddWithValue("@a8", CmbUnite.Text);
                command.Parameters.AddWithValue("@a9", TxPurpase.Text);
                command.Parameters.AddWithValue("@a10", TxRequestBy.Text);
                command.Parameters.AddWithValue("@a11", TxPreId.Text);
                command.Parameters.AddWithValue("@a12", dtNeed.Text);

               PbPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                command.Parameters.AddWithValue("@a13", pic);
                command.Parameters.AddWithValue("@a14",MoAddress.Text);

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


           




            


        



        }
       

        }


        }
    