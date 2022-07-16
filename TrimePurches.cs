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
    public partial class BtnAdd1 : DevExpress.XtraEditors.XtraForm
    {
        public BtnAdd1()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private void TrimePurches_Load(object sender, EventArgs e)
        {
            AtuoIncermentPoId();
            SuplierLoad();
            coloreLoad();
            groupControl5.Hide();
            groupControl3.Hide();
            TxPrice.Text = "0";
        }



        private void SuplierLoad()
        {


            string q = "select distinct Suplier from TB_TrimeSuplier";
            SqlDataAdapter db = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();

            db.Fill(dt);


            foreach (DataRow row in dt.Rows)
            {
                cmbCompanyName.Items.Add(row["Suplier"]);


            }



        }

        private void AtuoIncermentPoId()
        {



            int Num = 0;
            con.Open();

            string incre_BillNo = "SELECT MAX(PoId+1) FROM Tb_Purcess ";
            command = new SqlCommand(incre_BillNo);
            command.Connection = con;

            if (Convert.IsDBNull(command.ExecuteScalar()))
            {
                Num = 1;
                //txtPatientName.Text = Convert.ToString(Num);
                PoId.Text = Convert.ToString(Num);
            }
            else
            {
                Num = (int) (command.ExecuteScalar());
                PoId.Text = Convert.ToString(Num);
                PoId.Text = Convert.ToString(Num);
            }
            command.Dispose();
            con.Close();

        }

        private void atuoloadlist()
        {

            con.Open();
            SqlCommand command = new SqlCommand("Tb_Newquation", con);
            command.Parameters.AddWithValue("@id", cmbCompanyName.Text);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem listitem = new ListViewItem(reader["TpId"].ToString());

                listitem.SubItems.Add(reader["TrimeClass"].ToString());
                listitem.SubItems.Add(reader["Description"].ToString());
                listitem.SubItems.Add(reader["Spece"].ToString());
                listitem.SubItems.Add(reader["Dyeing"].ToString());
                listitem.SubItems.Add(reader["Finishing"].ToString());
                listitem.SubItems.Add(reader["Origin"].ToString());
                listitem.SubItems.Add(reader["MinMoq"].ToString());
                listitem.SubItems.Add(reader["Price"].ToString());
                listitem.SubItems.Add(reader["Unite"].ToString());
                listitem.SubItems.Add(reader["Curency"].ToString());
                listView3.Items.Add(listitem);
            }
            con.Close();


        }
    
    private void coloreLoad()
     {
        
         SqlDataAdapter ada = new SqlDataAdapter("select Serial,Color,ColorDescription from Tb_Color", con);
         DataTable dt = new DataTable();
         ada.Fill(dt);
       
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             DataRow dr = dt.Rows[i];
             ListViewItem listitem = new ListViewItem(dr["Color"].ToString());
          listitem.SubItems.Add(dr["ColorDescription"].ToString());
        listView2.Items.Add(listitem);
         }
         
     }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CmbColoreName.Text = listView2.SelectedItems[0].SubItems[0].Text;
            TxColoreDesc.Text = listView2.SelectedItems[0].SubItems[1].Text;
            groupControl5.Hide();
        }

       
        private void CmbColoreName_Click(object sender, EventArgs e)
        {
            groupControl3.Hide();
            groupControl5.Show();
        }

        

        private void TxColoreDesc_Click(object sender, EventArgs e)
        {
            groupControl5.Hide();
            groupControl3.Hide();}

        private void CmbTrimeId_Click(object sender, EventArgs e)
        {
            groupControl5.Hide();
            if(cmbCompanyName.Text=="")
            {
                MessageBox.Show("Please Select The Suplier Name");
            }
            else
            {
                atuoloadlist();
                groupControl3.Show(); 
            }
            
        }

        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            
            
           
        }

        private void TxOrderQut_TextChanged(object sender, EventArgs e)
        {

           
            double valueOne = 0;
            double valueTwo = 0;
            double.TryParse(txcalculation.Text, out valueOne);
            double.TryParse(TxOrderQut.Text, out valueTwo);
            valueOne = Math.Round(valueOne, 2);
            valueTwo = Math.Round(valueTwo, 2);
            double price = (valueOne * valueTwo);
            price = Math.Round(price, 2);
            TxPrice.Text = price.ToString();
        }

      private void totalprice()
      {
          
          
          double valueOne = 0;
          double valueTwo = 0;
          double.TryParse(TxPrice.Text, out valueOne);
          double.TryParse(TxOrderQut.Text, out valueTwo);
          valueOne = Math.Round(valueOne, 2);
          valueTwo = Math.Round(valueTwo, 2);
          double price = (valueOne * valueTwo);
          price = Math.Round(price, 2);
          TxPrice.Text = price.ToString();
        
          
        

        //  double price = (valueOne * valueTwo);


      }

      private void BtnDelete_Click(object sender, EventArgs e)
      {

      }

      private void listView3_MouseDoubleClick_1(object sender, MouseEventArgs e)
      {
          CmbTrimeId.Text = listView3.SelectedItems[0].SubItems[0].Text;
          TxClass.Text = listView3.SelectedItems[0].SubItems[1].Text;
          TxDescription.Text = listView3.SelectedItems[0].SubItems[2].Text;
          TxSpec.Text = listView3.SelectedItems[0].SubItems[3].Text;
          TxDeying.Text = listView3.SelectedItems[0].SubItems[4].Text;
          TxFinishing.Text = listView3.SelectedItems[0].SubItems[5].Text;
          TxOrigin.Text = listView3.SelectedItems[0].SubItems[6].Text;
          txcalculation.Text = listView3.SelectedItems[0].SubItems[8].Text;
          TxUnite.Text = listView3.SelectedItems[0].SubItems[9].Text;
          TxCurrency.Text = listView3.SelectedItems[0].SubItems[10].Text;
          groupControl3.Hide();}

      private void simpleButton_Click(object sender, EventArgs e)
      {
          ListViewItem items = new ListViewItem(CmbTrimeId.Text.Trim());
          items.SubItems.Add(TxClass.Text);
          items.SubItems.Add(TxDescription.Text);
          items.SubItems.Add(TxSpec.Text);
          items.SubItems.Add(TxDeying.Text);
          items.SubItems.Add(TxFinishing.Text);
          items.SubItems.Add(TxOrigin.Text);
          items.SubItems.Add(CmbColoreName.Text);
          items.SubItems.Add(TxColoreDesc.Text);
          items.SubItems.Add(TxOrderQut.Text);
          items.SubItems.Add(TxPrice.Text);
          items.SubItems.Add(TxUnite.Text);
          items.SubItems.Add(TxCurrency.Text);

          listView1.Items.Add(items);
          
          
       
          
          
          
         
          
         }

      private void BtnRemove_Click(object sender, EventArgs e)
      {
          if (listView1.SelectedItems.Count > 0)
          {
              ListViewItem items = listView1.SelectedItems[0];



              foreach (ListViewItem list in listView1.SelectedItems)
              {
                  list.Remove();


              }

          }
          else
          {
              MessageBox.Show("Please Select Row");
          }
      }

          
      }


       }
