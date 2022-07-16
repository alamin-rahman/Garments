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
    public partial class TrimeLab : DevExpress.XtraEditors.XtraForm
    {
        public TrimeLab()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);
      //  HospitalERPDataContext dataContext=new HospitalERPDataContext();
        DataClasses1DataContext dataContext =new DataClasses1DataContext();

        public SqlCommand command = new SqlCommand();

        private void TrimeLab_Load(object sender, EventArgs e)
        {

            atuoloadlist();
            groupControl2.Hide();
            }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void trimeLoad()
        {

            con.Open();
            command =
                new SqlCommand(
                    "SELECT TrimeClass,Description,Spece,Dyeing,Finishing from  TbTrime where TpId='" + CmbTrimeId.Text +
                    "' ", con);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TxTrimeClass.Text = reader[0].ToString();
                TxDecription.Text = reader[1].ToString();
                TxSepc.Text = reader[2].ToString();
                TxDyeing.Text = reader[3].ToString();
                TxFinishing.Text = reader[4].ToString();


            }

            con.Close();



        }
        private void atuoloadlist()
        {

            con.Open();
            SqlCommand command = new SqlCommand("spLabTrime", con);
            command.Parameters.AddWithValue("@id", CmbTrimeId.Text);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem listitem = new ListViewItem(reader["TrimeClass"].ToString());//  listitem.SubItems.Add(dr["TpId"].ToString());

                //listitem.SubItems.Add(reader["TrimeClass"].ToString());
                listitem.SubItems.Add(reader["Description"].ToString());
                listitem.SubItems.Add(reader["Spece"].ToString());
                listView3.Items.Add(listitem);
            } con.Close();


        }
        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CmbTrimeId.Text = listView3.SelectedItems[0].SubItems[0].Text;
            
            trimeLoad();
            groupControl2.Hide();
            }

        private void labelControl23_Click(object sender, EventArgs e)
        {
            groupControl2.Hide();
        }

        private void CmbTrimeId_Click(object sender, EventArgs e)
        {
           // groupControl2.Show();
            groupControl3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            atuoloadlist();
        }
    }
}