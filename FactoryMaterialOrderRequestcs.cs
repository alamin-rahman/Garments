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
    public partial class FactoryMaterialOrderRequestcs : DevExpress.XtraEditors.XtraForm
    {
        public FactoryMaterialOrderRequestcs()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();


        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FactoryMaterialOrderRequestcs_Load(object sender, EventArgs e)
        {
            autoloadfactoryCode();
            MetarialIdLoad();
            coloreCodeLoad();
            FactoryIdLoad();
            groupControl2.Visible = false;
            groupControl3.Visible = false;

        }

        private void MetarialIdLoad()
        {
            try
            {

                string query = "SELECT  MpId,id  from  Tb_Meterial";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandText = query;
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {

                    CmbMetarialId.Items.Add(drd["MpId"].ToString());
                    CmbMetarialId.ValueMember = drd["id"].ToString();
                    CmbMetarialId.DisplayMember = drd["MpId"].ToString();

                    // 
                }


                con.Close();
            }
            catch
            {
                MessageBox.Show("Eroor");
            }
        }

        private void AutoLoadMetarialCode()
        {

            command =
                new SqlCommand(
                    "SELECT MeterialCode,MeterialClass,Description,MeterialContent,Constraction,Weight,Width,Dyeing,Finishing from  Tb_Meterial where MpId='" +
                    CmbMetarialId.Text + "' ", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TxMetarialcode.Text = reader[0].ToString();
                TxMclass.Text = reader[1].ToString();
                TxDescription.Text = reader[2].ToString();
                TxContent.Text = reader[3].ToString();
                TxConstruction.Text = reader[4].ToString();
                TxWeight.Text = reader[5].ToString();
                TxWidth.Text = reader[6].ToString();
                TxDyeing.Text = reader[7].ToString();
                TxFinishing.Text = reader[8].ToString();
                

            }
            con.Close();
        }

        private void coloreCodeLoad()
        {
            try
            {

                string query = "SELECT  ColorCode,id  from  Tb_Color";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandText = query;
                con.Open();
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {

                    CmbColoreCode.Items.Add(drd["ColorCode"].ToString());
                    CmbColoreCode.ValueMember = drd["id"].ToString();
                    CmbColoreCode.DisplayMember = drd["ColorCode"].ToString();

                    // 

                }


                con.Close();
            }
            catch
            {
                MessageBox.Show("Eroor");
            }


        }
        private void CmbMetarialId_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoLoadMetarialCode();
            CmbOrigin.Items.Clear();
            
            OriginLoad();
            CmbUnite.Items.Clear();
            CmbUnite.Text = "";








        }


        private void OriginLoad()
        {


            string q = "select distinct Origin from Tb_MetarialQuotation where TpId= '" + CmbMetarialId.Text + "'";
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

        private void CmbColoreCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            command = new SqlCommand("SELECT Color from  Tb_Color where ColorCode='" + CmbColoreCode.Text + "' ", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TxtColoreName.Text = reader[0].ToString();
            }

            con.Close();}

        private void CmbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbUnite.Items.Clear();
            uniteLoad();
        }

        private void uniteLoad()
        {

            if (CmbOrigin.Text != "--Select--" && CmbMetarialId.Text != "--Select--")
            {
                string q = "select distinct Unite from Tb_MetarialQuotation where (TpId= '" + CmbMetarialId.Text +
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


    }
}