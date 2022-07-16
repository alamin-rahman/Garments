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
    public partial class Unite : DevExpress.XtraEditors.XtraForm
    {
        public Unite()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);

        public SqlCommand command = new SqlCommand();
        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                string insert =
                    "insert Into Tb_Unite(Unite) VALUES (@a1)";

                command = new SqlCommand(insert, con);

                command.Connection = con;
                command.Parameters.AddWithValue("@a1", TxCountry.Text);




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
        }
    }
}