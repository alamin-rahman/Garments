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
    public partial class TrimeQuotationList : DevExpress.XtraEditors.XtraForm
    {
        public TrimeQuotationList()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private  void atuoloadlist()
        {


            SqlDataAdapter ada = new SqlDataAdapter("select TpId,TrimeClass,Description,Spece,Dyeing,Finishing from TbTrime", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["TpId"].ToString());
              //  listitem.SubItems.Add(dr["TpId"].ToString());

               // listitem.SubItems.Add(dr["TrimeCode"].ToString());
                listitem.SubItems.Add(dr["TrimeClass"].ToString());
                listitem.SubItems.Add(dr["Description"].ToString());
                listitem.SubItems.Add(dr["Spece"].ToString());
                listitem.SubItems.Add(dr["Dyeing"].ToString());
                listitem.SubItems.Add(dr["Finishing"].ToString());
                listView2.Items.Add(listitem);
            } 


        }

        private void TrimeQuotationList_Load(object sender, EventArgs e)
        {
            atuoloadlist();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {




            if (listView2.SelectedItems.Count > 0)
            {
                 TrimeQuotation f1=new TrimeQuotation();
                 ListViewItem items = listView2.SelectedItems[0];
               f1.comboBoxEdit1.Text = listView2.SelectedItems[0].SubItems[0].Text;



               
               
                
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

       
        private void BtnSave_Click(object sender, EventArgs e)
        {
            TrimeQuotationList f3=new TrimeQuotationList();

            this.Hide();Trimes f2 = new Trimes();
            f2.Show();
            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                TrimeSampleRequest f1 = new TrimeSampleRequest();
              //  ListViewItem items = listView2.SelectedItems[0];
                f1.comboBox1.Text = listView2.SelectedItems[0].SubItems[0].Text;




                f1.Show();
            }
            else
            {
                MessageBox.Show("Please Select Row");
            }
            

        }





    }
}