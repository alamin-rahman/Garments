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
    public partial class TrimeQuotation : DevExpress.XtraEditors.XtraForm
    {
        public TrimeQuotation()
        {
            InitializeComponent();
        }
        private SqlConnection con =
                                 new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        private SqlCommand command = null;
       

           

        

        private  void autoloadSuplier()
        {



           

            try
            {
                TxSupliers.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxSupliers.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                con.Open();
                command = new SqlCommand("SELECT DISTINCT Suplier  from TB_TrimeSuplier ", con);
                SqlDataReader sdr = null;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    col.Add(sdr["Suplier"].ToString());
                }
                sdr.Close();

                TxSupliers.AutoCompleteCustomSource = col;
                con.Close();
            }
            catch
            {

            }

           

        }

        private void autoloadOrigin()
        {
            try
            {
                TxOrigin.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxOrigin.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
                con.Open();
                command = new SqlCommand("SELECT DISTINCT Country  from Tb_Country ", con);
                SqlDataReader sdr = null;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    col1.Add(sdr["Country"].ToString());
                }
                sdr.Close();

                TxOrigin.AutoCompleteCustomSource = col1;
                con.Close();
            }
            catch
            {

            }





          

            
        }
        private void autoloadCurrency()
        {

            try
            {
                TxCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxCurrency.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
                con.Open();
                command = new SqlCommand("SELECT DISTINCT Curency  from Tb_CurencyExchange ", con);
                SqlDataReader sdr = null;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    col1.Add(sdr["Curency"].ToString());
                }
                sdr.Close();

                TxCurrency.AutoCompleteCustomSource = col1;
                con.Close();
            }
            catch
            {
                
            }
            
           
        }
        private void autoloadunite()
        {


            try
            {
                TxUnite.AutoCompleteMode = AutoCompleteMode.Suggest;
                TxUnite.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
                con.Open();
                command = new SqlCommand("SELECT DISTINCT Unite  from Tb_Unite ", con);
                SqlDataReader sdr = null;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    col1.Add(sdr["Unite"].ToString());
                }
                sdr.Close();

                TxUnite.AutoCompleteCustomSource = col1;con.Close();
            }
            catch
            {

            }
            
         
            
        }

        



      private void AutoLoadTrimeCode()
      {

          con.Close();con.Open();
            command = new SqlCommand("SELECT TrimeClass,Description,Spece,Dyeing,Finishing,Picture  from  TbTrime where TpId='" + comboBoxEdit1.Text + "' ", con);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

             TxDecription.Text = reader[0].ToString();
                TxTrimeClass.Text = reader[1].ToString();
                TxSepc.Text = reader[2].ToString();
                TxDyeing.Text = reader[3].ToString();
                TxFinishing.Text = reader[4].ToString();

                byte[] b = new byte[0];
                b = (Byte[])(reader[5]);
                MemoryStream ms = new MemoryStream(b);
                PbTrime.Image = Image.FromStream(ms);
            }


            con.Close();



         

            




        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxTrimecode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TrimeQuotation_Load(object sender, EventArgs e)
        {
          
            groupControl5.Hide();
            autoincrement();
           atuoloadlist();
          AutoLoadTrimeCode();
           autoloadSuplier();
            autoloadOrigin();
            autoloadCurrency();
           autoloadunite();
           list2load();

        }
        private void autoincrement()
        {
             int Num = 0;
            con.Open();

            string incre_BillNo = "SELECT MAX(IncrementId+1) FROM Tb_TrimeQuotation where TpId='" + comboBoxEdit1.Text + "'";
            command = new SqlCommand(incre_BillNo);
            command.Connection = con;

            if (Convert.IsDBNull(command.ExecuteScalar()))
            {
                Num = 1;
                //txtPatientName.Text = Convert.ToString(Num);
                txIncrement.Text = Convert.ToString(Num);
            }
            else
            {
                Num = (int) (command.ExecuteScalar());
                txIncrement.Text = Convert.ToString(Num);
                txIncrement.Text = Convert.ToString(Num);

            }
            command.Dispose();
            con.Close();
        }

       
        private void atuoloadlist()
        {


            SqlDataAdapter ada = new SqlDataAdapter("select TpId,TrimeClass,Description,Spece,Dyeing,Finishing from TbTrime", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["TpId"].ToString());
                listitem.SubItems.Add(dr["TrimeClass"].ToString());
                listitem.SubItems.Add(dr["Description"].ToString());
                listitem.SubItems.Add(dr["Spece"].ToString());
                listitem.SubItems.Add(dr["Dyeing"].ToString());
                listitem.SubItems.Add(dr["Finishing"].ToString());

                listView2.Items.Add(listitem);
            }


        }
        private  void restrecttare()
        {
        }
     
        private void BtnSave_Click(object sender, EventArgs e)
        {



            if (TxSupliers.Text == "")
            {
                MessageBox.Show("Please Enter Trime Suplier", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxSupliers.Focus();
                return;

            }

            if (TxOrigin.Text == "")
            {
                MessageBox.Show("Please Enter Trime Origin", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxOrigin.Focus(); return;
            }

            if (TxMinMOQ.Text == "")
            {
                MessageBox.Show("Please Enter Min MOQ.", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxMinMOQ.Focus(); return;
            }

            if (TxtDelivery.Text == "")
            {
                MessageBox.Show("Please Enter Delivery ", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxtDelivery.Focus(); return;
            }

            if (TxCurrency.Text == "")
            {
                MessageBox.Show("Please Enter Currency", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxCurrency.Focus();
                return;
            }
            if (TxPrice.Text == "")
            {
                MessageBox.Show("Please Enter Price", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxPrice.Focus();
                return;

            }
            if (TxUnite.Text == "")
            {
                MessageBox.Show("Please Enter Unite", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxUnite.Focus();
                return;

            }
            else
            {
                if (comboBoxEdit1.Text == "")
                {
                    MessageBox.Show("Enter  The TP ID ");
                }
                else
                {
                    try
                    {


                        con.Open();

                        string insert =
                            "insert Into Tb_TrimeQuotation(TpId,DateQuat,Suplier,Origin,MinMoq,Delivery,Curency,Price,Unite,IncrementId) VALUES ('" +
                          comboBoxEdit1.Text + "'," +
                            "'" + DtAdd.Text + "','" + TxSupliers.Text + "','" + TxOrigin.Text + "','" + TxMinMOQ.Text +
                            "','" + TxtDelivery.Text + "'," +
                            "'" + TxCurrency.Text + "','" + TxPrice.Text + "','" + TxUnite.Text + "','" + txIncrement.Text + "')";
                        command = new SqlCommand(insert);
                        command.Connection = con;
                        command.ExecuteReader();
                        MessageBox.Show("Record Successfully Added ", "Succed", MessageBoxButtons.OK, MessageBoxIcon.Information);if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Close();

                        


                        
                       
                        AutoLoadTrimeCode();
                        list2load();
                        autoincrement();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                }
                
            }


           
               
        }
        private void list2load()
        {


            listView1.Items.Clear();
            SqlDataAdapter ada = new SqlDataAdapter("select  IncrementId,DateQuat,Suplier,Origin,MinMoq,Delivery,Curency,Price,Unite from Tb_TrimeQuotation where TpId='" + comboBoxEdit1.Text + "' ", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["IncrementId"].ToString());
                listitem.SubItems.Add(dr["DateQuat"].ToString());
              //  listitem.SubItems.Add(dr["TpId"].ToString());

                
                listitem.SubItems.Add(dr["Suplier"].ToString());
                listitem.SubItems.Add(dr["Origin"].ToString());
                listitem.SubItems.Add(dr["MinMoq"].ToString());
                listitem.SubItems.Add(dr["Delivery"].ToString());
                listitem.SubItems.Add(dr["Curency"].ToString());
                listitem.SubItems.Add(dr["Price"].ToString());
                listitem.SubItems.Add(dr["Unite"].ToString());
                listView1.Items.Add(listitem);
            } 
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void TrimeQuotation_Click(object sender, EventArgs e)
        {
            groupControl5.Hide();
        }

        private void comboBoxEdit1_Click(object sender, EventArgs e)
        {
            groupControl5.Show();
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
            groupControl5.Hide();
        }

     
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            





            comboBoxEdit1.Text = listView2.SelectedItems[0].SubItems[0].Text;
            
                
                groupControl5.Hide();
            autoincrement();AutoLoadTrimeCode();
            listView1.Items.Clear();list2load();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            Txdelete.Text = listView1.SelectedItems[0].SubItems[0].Text;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(Txdelete.Text=="")
            {
                MessageBox.Show("Slect Delete Item");
            }
            else
            {
                con.Open();
                command.CommandText = "DELETE  FROM Tb_TrimeQuotation  WHERE TpId='" + comboBoxEdit1.Text + "' and IncrementId ='" + Txdelete.Text + "'";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                autoincrement();
                Txdelete.Text = "";

                list2load();
 
            }
           
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            
            
            
                if (Txdelete.Text !="" )
                {
                    if (TxSupliers.Text == "")
                    {
                        MessageBox.Show("Please Enter Trime Suplier", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxSupliers.Focus();
                        return;

                    }

                    if (TxOrigin.Text == "")
                    {
                        MessageBox.Show("Please Enter Trime Origin", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxOrigin.Focus(); return;
                    }

                    if (TxMinMOQ.Text == "")
                    {
                        MessageBox.Show("Please Enter Min MOQ.", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxMinMOQ.Focus(); return;
                    }

                    if (TxtDelivery.Text == "")
                    {
                        MessageBox.Show("Please Enter Delivery ", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxtDelivery.Focus(); return;
                    }

                    if (TxCurrency.Text == "")
                    {
                        MessageBox.Show("Please Enter Currency", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxCurrency.Focus();
                        return;
                    }
                    if (TxPrice.Text == "")
                    {
                        MessageBox.Show("Please Enter Price", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxPrice.Focus();
                        return;

                    }
                    if (TxUnite.Text == "")
                    {
                        MessageBox.Show("Please Enter Unite", "Input Missing", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        TxUnite.Focus();
                        return;

                    }


                    else
                    {
                        command.Connection = con;
                        con.Open();
                        command.CommandText = "UPDATE Tb_TrimeQuotation SET DateQuat = @a1,Suplier= @a2, Origin= @a3, MinMoq=@a4, Delivery=@a5,Curency=@a6,Price=@a7, Unite=@a8  WHERE TpId='" + comboBoxEdit1.Text + "' and IncrementId ='" + Txdelete.Text + "'";
                        command.Parameters.AddWithValue("@a1", DateTime.ParseExact(DtAdd.Text, "dd/MM/yyyy", null));
                        command.Parameters.AddWithValue("@a2", TxSupliers.Text);
                        command.Parameters.AddWithValue("@a3", TxOrigin.Text);
                        command.Parameters.AddWithValue("@a4", TxMinMOQ.Text);
                        command.Parameters.AddWithValue("@a5", TxtDelivery.Text);
                        command.Parameters.AddWithValue("@a6", TxCurrency.Text);
                        command.Parameters.AddWithValue("@a7", TxPrice.Text);
                        command.Parameters.AddWithValue("@a8", TxUnite.Text);

                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Update Sucessfully");

                      
                        Txdelete.Text = "";
                        AutoLoadTrimeCode();
                        list2load();
                    }

                }
                else
                {
                    MessageBox.Show("Selecte Data");
                }
                 
                

            }

        private void BtnList_Click(object sender, EventArgs e)
        {

        }
            
        }

        }
