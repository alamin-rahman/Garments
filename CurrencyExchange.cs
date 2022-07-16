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
    public partial class CurrencyExchange : DevExpress.XtraEditors.XtraForm
    {
        public CurrencyExchange()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void clear()
        {
            TxCurency.Text = "";
            TxCurencyDescription.Text = "";
            TxFaxRate.Text = "";
            DtDate.Text = "";
        }


        private void loadgrideview()
        {


        }




        private void BtnSave_Click(object sender, EventArgs e)
        {
            //this.listView1.Items.Clear();

            try
            {
                con.Open();

                string insert =
                    "insert Into Tb_CurencyExchange(Curency,CurencyDesc,FaxRate,UpDateDate) VALUES (@a1,@a2,@a3,@a4)";

                command = new SqlCommand(insert, con);

                command.Connection = con;
                command.Parameters.AddWithValue("@a1", TxCurency.Text);


                command.Parameters.AddWithValue("@a2", TxCurencyDescription.Text);
                command.Parameters.AddWithValue("@a3", TxFaxRate.Text);
              //  DateTime dt = new DateTime(DtDate).Date;
             //   DateTime dt = new DateTime(DtDate.Text).Date;
              //  DateTime dt = new DateTime.(11, 12, 1999).Date;//TxDate.Text = DtDate.Text;
               // command.Parameters.AddWithValue("@a4", DtDate.Text);  
              //  command.Parameters.AddWithValue("@a4", DtDate. // DateTime.ParseExact(DtDate.Text, "dd/MM/yyyy",);
                 
             command.Parameters.AddWithValue("@a4", DateTime.ParseExact(DtDate.Text, "dd/MM/yyyy", null));

                con.Close();
                con.Open();
                command.ExecuteNonQuery();
                con.Close();


                
                MessageBox.Show("Record Successfully Added ", "Succed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Text = "";
                autoloadCurencyExchange();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
           
        }




        private void autoloadCurencyExchange()
        {


            //SqlDataAdapter ada =
            //    new SqlDataAdapter("select  Curency ,CurencyDesc,FaxRate,UpDateDate from Tb_CurencyExchange", con);
            //DataTable dt = new DataTable();
            //ada.Fill(dt);
           
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow dr = dt.Rows[i];
            //        ListViewItem listitem = new ListViewItem(dr[0].ToString());
            //        listitem.SubItems.Add(" " + dr[1].ToString());
            //        listitem.SubItems.Add(" " + dr[2].ToString());
            //        listitem.SubItems.Add(" " + dr[3].ToString());
                    
            //        listView1.Items.Add(listitem);
            //    }


            //listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            //listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
            //listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
            //listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
            //  listView1.Items.Add(listitem);
              //  DataRow dr = dt.Rows[i];
              //  ListViewItem listitem = new ListViewItem(dr["Curency"].ToString());
              //  listitem.SubItems.Add(dr["CurencyDesc"].ToString());
              //  listitem.SubItems.Add(dr["FaxRate"].ToString());
              //  listitem.SubItems.Add(dr["UpDateDat"].ToString());
              //  listView1.Items.Add(listitem);
               
            }


        private  void call()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Tb_CurencyExchange", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = item["Curency"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["CurencyDesc"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["FaxRate"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["UpDateDate"].ToString();
            }
        }
        private void CurrencyExchange_Load(object sender, EventArgs e)
        {



            call();
            //  autoloadCurencyExchange();
            //command = new SqlCommand();
            //command.Connection = con;
            //command.CommandText = "select  Curency ,CurencyDesc,FaxRate,UpDateDate from Tb_CurencyExchange";
            //con.Open();
            //SqlDataReader reader = command.ExecuteReader();

            ////for (int i = 0; i < dataGridView1.Columns.Count; i++)
            ////{
            ////    int colw = dataGridView1.Columns[i].Width;
            ////    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ////    dataGridView1.Columns[i].Width = colw;

            ////} 
            //if (reader.HasRows)
            //{
            //    DataTable dt = new DataTable();
            //    dt.Load(reader);
            //    dataGridView1.DataSource = dt;
            //    //MessageBox.Show("Save");
            //} con.Close();





        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Curency,CurencyDesc,FaxRate,UpDateDate FROM Tb_CurencyExchange", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = item["Curency"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["CurencyDesc"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["FaxRate"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["UpDateDate"].ToString();
              
            }
            MessageBox.Show("Show");}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //private void CurrencyExchange_Load(object sender, EventArgs e)
        //{
        //    autoloadCurencyExchange();
        //}
    }

        
    }
