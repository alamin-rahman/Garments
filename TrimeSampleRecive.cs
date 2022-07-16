using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Purchesed.DevForm
{
    public partial class TrimeSampleRecive : DevExpress.XtraEditors.XtraForm
    {
        public TrimeSampleRecive()
        {
            InitializeComponent();
        }

        private void TrimeSampleRecive_Load(object sender, EventArgs e)
        {

        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            TxStatus.Text = "Received";
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void TxStatus_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnProgars_Click(object sender, EventArgs e)
        {
            TxStatus.Text = "Progras";
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            TxStatus.Text = "Cancel";
        }
    }
}