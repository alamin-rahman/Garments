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
    public partial class FactoryList : DevExpress.XtraEditors.XtraForm
    {
        public FactoryList()
        {
            InitializeComponent();
        }


        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void atuoloadlist()
        {


            SqlDataAdapter ada = new SqlDataAdapter("select FacId,FactoryCode,FactorName,Tel,Fax,Mobile,Email,ContractPerson from Tb_Factory", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["FacId"].ToString());
                
                listitem.SubItems.Add(dr["FactoryCode"].ToString());
                listitem.SubItems.Add(dr["FactorName"].ToString());
                listitem.SubItems.Add(dr["Tel"].ToString());
                listitem.SubItems.Add(dr["Fax"].ToString());
                listitem.SubItems.Add(dr["Mobile"].ToString());
                listitem.SubItems.Add(dr["Email"].ToString());
                listitem.SubItems.Add(dr["ContractPerson"].ToString());
                
                listView1.Items.Add(listitem);
            }


        }

        private void FactoryList_Load(object sender, EventArgs e)
        {
            atuoloadlist();
        }

        private void BtnTOR_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                FactoryTrimeOrderRequest f1 = new FactoryTrimeOrderRequest();
                f1.CmbFacId.Text = listView1.SelectedItems[0].SubItems[0].Text;






                f1.Show();
            }
            else
            {
                MessageBox.Show("Please Select Row");
            }
            

            
        }

        private void BtnMOR_Click(object sender, EventArgs e)
        {


            if (listView1.SelectedItems.Count > 0)
            {
                FactoryMaterialOrderRequestcs f1 = new FactoryMaterialOrderRequestcs();f1.CmbFacId.Text = listView1.SelectedItems[0].SubItems[0].Text;






                f1.Show();
            }
            else
            {
                MessageBox.Show("Please Select Row");
            }
            

        }

    }
}