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
    public partial class FactoryInformation : DevExpress.XtraEditors.XtraForm
    {
        public FactoryInformation()
        {
            InitializeComponent();
        
        }
        private SqlConnection con =
                                     new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        private SqlCommand command = null;

        private void AutoIncreamenFacId()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(FacId+1) FROM Tb_Factory"; command = new SqlCommand(incre_BillNo);
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

        private void FactoryInformation_Load(object sender, EventArgs e)
        {
            AutoIncreamenFacId();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            con.Open();

            string insert = "insert Into Tb_Factory(FacId,FactoryCode,FactorName,Tel,Fax,Mobile,Email,WebSite,Address,ContractPerson,ConMobile,ConEmail) VALUES ('" + LbId.Text + "','" + TxtFactroyCode.Text + "','" + TxFactory.Text + "','" + TxTel.Text + "','" + TxFax.Text + "','" + TxMobile.Text + "','" + TxEmail.Text + "','" + TxWeb.Text + "','" + MoAddress.Text + "','" + TxContrac.Text + "', '" + TxConMobile.Text + "','" + TxConEmail.Text + "')";
            command = new SqlCommand(insert); command.Connection = con;
            command.ExecuteReader();
            MessageBox.Show("Data Save");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();
            Clear();AutoIncreamenFacId();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Clear()
        {
            TxtFactroyCode.Text = "";
            TxFactory.Text = "";
            TxFax.Text = "";
            TxTel.Text = "";
            TxMobile.Text = "";
            TxWeb.Text = "";
            TxEmail.Text = "";
            TxContrac.Text = "";
            TxConEmail.Text = "";
            TxConMobile.Text = "";
            MoAddress.Text = "";


        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Clear();}


    }





}