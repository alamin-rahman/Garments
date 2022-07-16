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
    public partial class MetarialQuotation : DevExpress.XtraEditors.XtraForm
    {
        public MetarialQuotation()
        {
            InitializeComponent();
        }

        private SqlConnection con =
            new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        private SqlCommand command = null;

        private void AutoLoadMetarialCode()
        {

            con.Open();
            command =
                new SqlCommand(
                    "select MeterialCode,MeterialType,MeterialClass,Description,MeterialContent,Constraction,Weight,Width,Dyeing,Finishing,Picture  from  Tb_Meterial where MpId='" +
                    LbTpId.Text + "' ", con);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TxMcode.Text = reader[0].ToString();
                TxMtype.Text = reader[1].ToString();
                TxMclass.Text = reader[2].ToString();
                TxDescription.Text = reader[3].ToString();
                TxContent.Text = reader[4].ToString();
                TxConstruction.Text = reader[5].ToString();
                TxWeight.Text = reader[6].ToString();
                TxWidth.Text = reader[7].ToString();
                TxDyeing.Text = reader[8].ToString();
                TxFinishing.Text = reader[9].ToString();


                byte[] b = new byte[0];
                b = (Byte[]) (reader[10]);
                MemoryStream ms = new MemoryStream(b);
                PbPicture.Image = Image.FromStream(ms);
            }
            con.Close();

        }
        private void autoloadSuplier()
        {

            con.Open();
            command = new SqlCommand("SELECT DISTINCT Suplier  from Tb_MaterialSuplier ", con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds, "Tb_MaterialSuplier");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["Suplier"].ToString());

            }
            TxSupliers.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TxSupliers.AutoCompleteCustomSource = col;
            TxSupliers.AutoCompleteMode = AutoCompleteMode.Suggest;


            con.Close();
        }


        private void autoloadOrigin()
        {
            con.Open();
            command = new SqlCommand("SELECT DISTINCT Country  from Tb_Country ", con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds, "Tb_Countryr");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["Country"].ToString());

            }
            TxOrigin.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TxOrigin.AutoCompleteCustomSource = col;
            TxOrigin.AutoCompleteMode = AutoCompleteMode.Suggest;


            con.Close();


        }
        private void autoloadCurrency()
        {

            con.Open();
            command = new SqlCommand("SELECT DISTINCT Curency  from Tb_CurencyExchange ", con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds, "Tb_CurencyExchange");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["Curency"].ToString());

            }
            TxCurrency.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TxCurrency.AutoCompleteCustomSource = col;
            TxCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;


            con.Close();
        }
        private void autoloadunite()
        {

            con.Open();
            command = new SqlCommand("SELECT DISTINCT Unite  from Tb_Unite ", con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds, "Tb_Unite");
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["Unite"].ToString());

            }
            TxUnite.AutoCompleteSource = AutoCompleteSource.CustomSource;

            TxUnite.AutoCompleteCustomSource = col;
            TxUnite.AutoCompleteMode = AutoCompleteMode.Suggest;
            command.ExecuteReader().Close();

            con.Close();

        }

        private void AutoIncreamenTqId()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(Mqid+1) FROM Tb_MetarialQuotation"; command = new SqlCommand(incre_BillNo);
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

        private void MetarialQuotation_Load(object sender, EventArgs e)
        {
         autoloadSuplier();
            autoloadOrigin();
            autoloadCurrency();
           autoloadunite();
           AutoIncreamenTqId();
            AutoLoadMetarialCode();
          
        }

        private void BtnAddToCard_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.FindItemWithText(DtAdd.Text.Trim());
            ListViewItem item1 = listView1.FindItemWithText(TxSupliers.Text.Trim());
            ListViewItem item2 = listView1.FindItemWithText(TxOrigin.Text.Trim());
            ListViewItem item3 = listView1.FindItemWithText(TxMinMOQ.Text.Trim());
            ListViewItem item4 = listView1.FindItemWithText(TxtDelivery.Text.Trim());
            ListViewItem item5 = listView1.FindItemWithText(TxCurrency.Text.Trim());
            ListViewItem item6 = listView1.FindItemWithText(TxPrice.Text.Trim());
            ListViewItem item7 = listView1.FindItemWithText(TxUnite.Text.Trim());

            if (item == null || item1 == null || item2 == null || item3 == null || item4 == null || item5 == null || item6 == null || item7 == null)
            {
                ListViewItem items = new ListViewItem(DtAdd.Text);
                items.SubItems.Add(TxSupliers.Text);
                items.SubItems.Add(TxOrigin.Text);
                items.SubItems.Add(TxMinMOQ.Text);
                items.SubItems.Add(TxtDelivery.Text);
                items.SubItems.Add(TxCurrency.Text);
                items.SubItems.Add(TxPrice.Text);
                items.SubItems.Add(TxUnite.Text);

                listView1.Items.Add(items);



            }

            else
            {
                MessageBox.Show("Already added");
            }}

        private void BtnRemoveToCard_Click(object sender, EventArgs e)
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

        private void BtnEdite_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {





                foreach (ListViewItem list in listView1.SelectedItems)
                {

                    DtAdd.Text = listView1.SelectedItems[0].SubItems[0].Text;
                    TxSupliers.Text = listView1.SelectedItems[0].SubItems[1].Text;
                    TxOrigin.Text = listView1.SelectedItems[0].SubItems[2].Text;
                    TxMinMOQ.Text = listView1.SelectedItems[0].SubItems[3].Text;
                    TxtDelivery.Text = listView1.SelectedItems[0].SubItems[4].Text;
                    TxCurrency.Text = listView1.SelectedItems[0].SubItems[5].Text;
                    TxPrice.Text = listView1.SelectedItems[0].SubItems[6].Text;
                    TxUnite.Text = listView1.SelectedItems[0].SubItems[7].Text;
                    list.Remove();
                }

            }
            else
            {
                MessageBox.Show("Please Select Row");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= listView1.Items.Count - 1; i++)
            {
                con.Open();
                string insert =
                    "insert Into Tb_MetarialQuotation(Mqid,TpId,DateQuat,Suplier,Origin,MinMoq,Delivery,Curency,Price,Unite) VALUES ('" +
                    LbId.Text + "'," +
                    "'" + LbTpId.Text + "','" + listView1.Items[i].SubItems[0].Text + "','" +
                    listView1.Items[i].SubItems[1].Text + "','" + listView1.Items[i].SubItems[2].Text + "','" +
                    listView1.Items[i].SubItems[3].Text + "','" + listView1.Items[i].SubItems[4].Text + "','" +
                    listView1.Items[i].SubItems[5].Text + "','" + listView1.Items[i].SubItems[6].Text + "','" +
                    listView1.Items[i].SubItems[7].Text + "')";
                command = new SqlCommand(insert);
                command.Connection = con;
                command.ExecuteReader();
                con.Close();
            }
            MessageBox.Show("Data Save");
        }
    }
}