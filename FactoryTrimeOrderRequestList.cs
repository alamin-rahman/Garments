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
    public partial class FactoryTrimeOrderRequestList : DevExpress.XtraEditors.XtraForm
    {
        public FactoryTrimeOrderRequestList()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private void FactoryTrimeOrderRequestList_Load(object sender, EventArgs e)
        {
            atuoloadlist();
        }


        private void atuoloadlist()
        {


            SqlDataAdapter ada = new SqlDataAdapter("select FTORid,FacId,TrimeId,ColorId,Origin,Quentity,Unite,Purpose,NeedDate,RequestDate from Tb_FactoryTrimeOrderRequest", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["FTORid"].ToString());

              listitem.SubItems.Add(dr["FacId"].ToString());
                listitem.SubItems.Add(dr["TrimeId"].ToString());
                listitem.SubItems.Add(dr["ColorId"].ToString());
                listitem.SubItems.Add(dr["Origin"].ToString());
                listitem.SubItems.Add(dr["Quentity"].ToString());
                listitem.SubItems.Add(dr["Unite"].ToString());
                listitem.SubItems.Add(dr["Purpose"].ToString());
                

            
                listitem.SubItems.Add(dr["RequestDate"].ToString());
                listitem.SubItems.Add(dr["NeedDate"].ToString());
                
                listView1.Items.Add(listitem);
            }


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnSampleRequest_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
            
                TrimeSampleRequest f1=new TrimeSampleRequest();

            // f1.lb_FTORID.Text = listView1.SelectedItems[0].SubItems[0].Text;
                f1.comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
                f1.TxColorCode.Text = listView1.SelectedItems[0].SubItems[3].Text;
             f1.cmbOrigin.Text = listView1.SelectedItems[0].SubItems[4].Text;
                


                f1.Show();
            }
            else
            {
                MessageBox.Show("Please Select Row");
            }

        }
    }
}