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
    public partial class MetarialQuotationList : DevExpress.XtraEditors.XtraForm
    {
        public MetarialQuotationList()
        {
            InitializeComponent();
        }

        private void MetarialQuotationList_Load(object sender, EventArgs e)
        {
            atuoloadlist();}
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();
        private void atuoloadlist()
        {


            SqlDataAdapter ada = new SqlDataAdapter("select MpId,MeterialCode,MeterialType,MeterialClass,Description,MeterialContent,Constraction,Weight,Width,Dyeing,Finishing from Tb_Meterial", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["MpId"].ToString());
                //  listitem.SubItems.Add(dr["TpId"].ToString());

                listitem.SubItems.Add(dr["MeterialCode"].ToString());
                listitem.SubItems.Add(dr["MeterialType"].ToString());
                listitem.SubItems.Add(dr["MeterialClass"].ToString());
                listitem.SubItems.Add(dr["Description"].ToString());
                listitem.SubItems.Add(dr["MeterialContent"].ToString());
                listitem.SubItems.Add(dr["Constraction"].ToString());
                listitem.SubItems.Add(dr["Weight"].ToString());
                listitem.SubItems.Add(dr["Width"].ToString());
                listitem.SubItems.Add(dr["Dyeing"].ToString());
                listitem.SubItems.Add(dr["Finishing"].ToString());
                listView1.Items.Add(listitem);
            }


        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                MetarialQuotation f1 = new MetarialQuotation();

                f1.LbTpId.Text = listView1.SelectedItems[0].SubItems[0].Text;






                f1.Show();
           }
            else
            {
                MessageBox.Show("Please Select Row");
            }
            

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}