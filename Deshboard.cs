using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Purchesed.DevForm
{
    public partial class Deshboard : Form
    {
        public Deshboard()
        {
            InitializeComponent();
        }

        private void Deshboard_Load(object sender, EventArgs e)
        {

        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeSuplierInformation aTrimeSuplierInformation= new TrimeSuplierInformation();

            aTrimeSuplierInformation.Show();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeSuplierList aTrimeSuplierList=new TrimeSuplierList();
            aTrimeSuplierList.Show();
            
            
           }

        private void tileItem6_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeSuplierInformation aTrimeSuplierInformation = new TrimeSuplierInformation();

            aTrimeSuplierInformation.Show();}

        private void tileItem2_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeSuplierList aTrimeSuplierList = new TrimeSuplierList();
            aTrimeSuplierList.Show();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Trimes aTrimes =new Trimes();
            aTrimes.Show();
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeQuotationList aQuotationList=new TrimeQuotationList();
            aQuotationList.Show();
        }

        private void tileItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeQuotation aTrimeQuotation=new TrimeQuotation();
            aTrimeQuotation.Show();
        }

        private void tileItem11_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            TrimeSampleRequest aSampleRequest=new TrimeSampleRequest();
            aSampleRequest.Show();
        }
    }
}
