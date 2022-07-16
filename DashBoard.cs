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
    public partial class DashBoard : DevExpress.XtraEditors.XtraForm
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrimeSuplierInformation on1 = new TrimeSuplierInformation(); 
          //  on1.TopLevel = false;
            on1.Location = new Point(1,1);
          //  panelControl1.Controls.Add(on1);
            on1.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
           // FactoryList on2 = new FactoryList();
            TrimeQuotationList on2 = new TrimeQuotationList();on2.Show();

        }
    }
}