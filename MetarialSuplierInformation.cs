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
    public partial class MetarialSuplierInformation : DevExpress.XtraEditors.XtraForm
    {
        public MetarialSuplierInformation()
        {
            InitializeComponent();
        }

        private SqlConnection con =
                                       new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        private SqlCommand command = null;
        private void MetarialSuplierInformation_Load(object sender, EventArgs e)
        {
            AutoIncreamenTsId();
            BtnDelete.Enabled = false;
            BtnUpdate.Enabled = false;
           // loadTsId();
        }

        private void AutoIncreamenTsId()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(Ts_Id+1) FROM Tb_MaterialSuplier"; command = new SqlCommand(incre_BillNo);
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







        private void clear()
        {
            //TxTsId.Text = "";
            TxCompany.Text = "";
            TxConEmail.Text = "";
            TxConMobile.Text = "";
            TxTel.Text = "";
            TxWeb.Text = "";
            TxFax.Text = "";
            TxEmail.Text = "";
            TxWeb.Text = "";
            TxContrac.Text = "";
            TxMobile.Text = "";
            MoAddress.Text = "";
            TxCountry.Text = "";
        }
      

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            con.Open();

            string insert = "insert Into Tb_MaterialSuplier(Date,Ts_Id,Suplier,Country,Tel,Fax,Mobile,Email,WebSite,Address,ContPerson,ContEmail,ContMobile) VALUES ('" + DateTime.ParseExact(DtpDate.Text, "dd/MM/yyyy", null) + "'," +
                         "'" + LbId.Text + "','" + TxCompany.Text + "','" + TxCountry.Text + "','" + TxTel.Text + "','" + TxFax.Text + "','" + TxMobile.Text + "','" + TxEmail.Text + "','" + TxWeb.Text + "','" + MoAddress.Text + "','" + TxContrac.Text + "', '" + TxConEmail.Text + "', '" + TxConMobile.Text + "')";
            command = new SqlCommand(insert); command.Connection = con;
            command.ExecuteReader();
            MessageBox.Show("Data Save");
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();
            clear(); AutoIncreamenTsId();
        }

        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }
       

    }
}