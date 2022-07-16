using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Purchesed.DevForm
{
    public partial class SuplierDelete : DevExpress.XtraEditors.XtraForm
    {
        public SuplierDelete()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private void SuplierDelete_Load(object sender, EventArgs e)
        {



            SqlDataAdapter ada =
                new SqlDataAdapter("select TpId,TrimeCode,TrimeClass,Description,Spece,Dyeing,Finishing from TbTrime",
                                   con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["TpId"].ToString());
                //  listitem.SubItems.Add(dr["TpId"].ToString());

                listitem.SubItems.Add(dr["TrimeCode"].ToString());
                listitem.SubItems.Add(dr["TrimeClass"].ToString());
                listitem.SubItems.Add(dr["Description"].ToString());
                listitem.SubItems.Add(dr["Spece"].ToString());
                listitem.SubItems.Add(dr["Dyeing"].ToString());
                listitem.SubItems.Add(dr["Finishing"].ToString());
                listView1.Items.Add(listitem);}



        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

       }
        
    }