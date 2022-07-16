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
    public partial class Trimes : DevExpress.XtraEditors.XtraForm
    {
        public Trimes()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();
        
        
        private void BtnSelectImage_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "jpg | *.jpg";
            DialogResult drs = openFileDialog1.ShowDialog();

            if (drs == DialogResult.OK)
            {
                PbTrime.Image = Image.FromFile(openFileDialog1.FileName);
                }
        }

        private void clear()
        {
           // TxTrimecode.Text = "";
            comboBoxEdit1.Text = "";
            TxTrimeClass.Text = "";
            TxDecription.Text = "";TxSepc.Text = "";
            TxDyeing.Text = "";
            TxFinishing.Text = "";
            PbTrime.Text = "";

            


        }
        private void AutoIncreamenTsId()
        {
            int Num = 0;
            con.Open();
            string incre_BillNo = "SELECT MAX(TpId+1) FROM TbTrime"; command = new SqlCommand(incre_BillNo);
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

                listView1.Items.Add(listitem);
            }


        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void Trimes_Load(object sender, EventArgs e)
        {
            AutoIncreamenTsId();


            atuoloadlist();
            hide();
            panel1.Hide();
            }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            clear();
            hideone();
            BtnSave.Enabled = true;
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
            LbId.Show();panel1.Hide();
            TxTrimeClass.Focus();}

        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {   
            
            if (TxTrimeClass.Text == "")
            {
                MessageBox.Show("Please Enter Trime Class", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxTrimeClass.Focus();
                return;

            }

            if (TxDecription.Text == "")
            {
                MessageBox.Show("Please Enter Trime Description", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxDecription.Focus(); return;
            }

            if (TxSepc.Text == "")
            {
                MessageBox.Show("Please Enter Trime Spec.", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxSepc.Focus(); return;
            }

            if (TxDyeing.Text == "")
            {
                MessageBox.Show("Please Enter Trime Deying Matod", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxDyeing.Focus(); return;
            }

            if (TxFinishing.Text == "")
            {
                MessageBox.Show("Please Enter Trime Finishing", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TxFinishing.Focus();
                return;
            }
            if (PbTrime.Text == "")
            {
                MessageBox.Show("Please Enter Trime Image", "Input Missing", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                BtnSelectImage.Focus();
                return;

            }



            else
            {
                try
                {
                    con.Open();

                    string insert = "insert Into TbTrime(TpId,Date,TrimeClass,Description,Spece,Dyeing,Finishing,Picture) VALUES (@a1,@a2,@a5,@a6,@a7,@a8,@a9,@a10)";

                    command = new SqlCommand(insert, con);
                    MemoryStream stream = new MemoryStream();
                    command.Connection = con;
                    command.Parameters.AddWithValue("@a1", LbId.Text);

                    command.Parameters.AddWithValue("@a2", DateTime.ParseExact(DtDate.Text, "dd/MM/yyyy", null));
                    // command.Parameters.AddWithValue("@a3", TxTrimecode.Text);
                    command.Parameters.AddWithValue("@a5", TxTrimeClass.Text);
                    command.Parameters.AddWithValue("@a6", TxDecription.Text);
                    command.Parameters.AddWithValue("@a7", TxSepc.Text);
                    command.Parameters.AddWithValue("@a8", TxDyeing.Text);
                    command.Parameters.AddWithValue("@a9", TxFinishing.Text);

                    PbTrime.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    command.Parameters.AddWithValue("@a10", pic);

                    con.Close();
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();




                    MessageBox.Show("Record Successfully Added ", "Succed", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }


                //  clear();
               
                comboBoxEdit1.Text = LbId.Text;
                AutoIncreamenTsId();
                LbId.Hide();
                BtnSave.Enabled = false;
                BtnDelete.Enabled = true;
                BtnUpdate.Enabled = true;atuoloadlist();

            }

           
        }

        private void Trimes_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void groupControl2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void comboBoxEdit1_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }
        private void hide()
        {
            BtnDelete.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnSave.Enabled = false;
            LbId.Hide();
          TxTrimeClass.Enabled = false;
           TxDecription.Enabled = false;
            TxSepc.Enabled = false;
            TxFinishing.Enabled = false;
            TxDyeing.Enabled = false;
            BtnSelectImage.Enabled = false;
            PbTrime.Enabled = false;

        }
        private  void hideone()
        {
            TxTrimeClass.Enabled = true;
            TxDecription.Enabled = true;
            TxSepc.Enabled = true;
            TxFinishing.Enabled = true;
            TxDyeing.Enabled = true;
            BtnSelectImage.Enabled = true;
            PbTrime.Enabled = true;
        }

        
        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
             BtnSave.Enabled = true;
             LbId.Show();
             hideone();
            clear();
            BtnDelete.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnUpdate.Enabled = false;

        }
        private void listocombobox()
        {
            if (listView1.SelectedItems.Count > 0)
            {





                foreach (ListViewItem list in listView1.SelectedItems)
                {

                    comboBoxEdit1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                   

                }
                panel1.Hide();
                trimeLoad();
                LbId.Hide();
                hideone();
            }


        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listocombobox();
        }
        private void trimeLoad()
        {

            con.Open();
            command =
                new SqlCommand(
                    "SELECT TrimeClass,Description,Spece,Dyeing,Finishing,Picture from  TbTrime where TpId='" + comboBoxEdit1.Text +"' ", con);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TxTrimeClass.Text = reader[0].ToString();
               TxDecription.Text = reader[1].ToString();
               TxSepc.Text = reader[2].ToString();
               TxDyeing.Text = reader[3].ToString();
               TxFinishing.Text = reader[4].ToString();
               byte[] b = new byte[0];
               b = (Byte[])(reader[5]);
               MemoryStream ms = new MemoryStream(b);
               PbTrime.Image = Image.FromStream(ms);

            }

            con.Close();

            BtnUpdate.Enabled = true;
            BtnDelete.Enabled = true;
            BtnSave.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            hide();}

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AfterDeleteAndUpdate()
        {
            clear();
            hide(); comboBoxEdit1.Text = "";
            listView1.Items.Clear();
            atuoloadlist();
           // groupControl3.Hide();

        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" You want to delete? ", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                 con.Open();
            command.CommandText = "DELETE  FROM TbTrime where TpId ='" + comboBoxEdit1.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully"); AutoIncreamenTsId(); AfterDeleteAndUpdate();
            }
          
           
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text != null)
            {
                command.Connection = con;
                con.Open();
                command.CommandText = "UPDATE TbTrime SET TrimeClass = @a1,Description = @a2, Spece= @a3, Dyeing=@a4, Finishing=@a5,Picture=@a6 WHERE TpId ='" + comboBoxEdit1.Text + "'";

                command.Parameters.AddWithValue("@a1", TxTrimeClass.Text);
                command.Parameters.AddWithValue("@a2", TxDecription.Text);
                command.Parameters.AddWithValue("@a3", TxSepc.Text);
                command.Parameters.AddWithValue("@a4", TxDyeing.Text);
                command.Parameters.AddWithValue("@a5", TxFinishing.Text);
                MemoryStream stream = new MemoryStream();
               PbTrime.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                command.Parameters.AddWithValue("@a6", pic);
                
                command.ExecuteNonQuery();
                con.Close(); MessageBox.Show("Update Sucessfully");
                AfterDeleteAndUpdate();

            }
            else
            {
                MessageBox.Show("Missing TsId");
            }
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            TrimeQuotationList f1=new TrimeQuotationList();
            f1.Show();
        }

       

       
        

     
    }
}