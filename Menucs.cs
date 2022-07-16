using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Purchesed.DevForm.Common
{
    public partial class Menucs : DevExpress.XtraEditors.XtraForm
    {
        public Menucs()
        {
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void groupboxhid()
        {
            groupControl1.Visible = false;
            groupControl1.Location = new Point(196, 25);
        }

        private void navBarGroup1_ItemChanged(object sender, EventArgs e)
        {

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Trimes aTrimes=new Trimes();
            aTrimes.Location = new Point(196, 25);
            aTrimes.Show();

        }
    }
}