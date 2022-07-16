namespace Purchesed.DevForm
{
    partial class TrimeQuotationList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.BtnClose = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSample = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = global::Purchesed.Properties.Resources._76_481;
            this.groupControl1.Controls.Add(this.btnSample);
            this.groupControl1.Controls.Add(this.BtnSave);
            this.groupControl1.Controls.Add(this.BtnClose);
            this.groupControl1.Controls.Add(this.simpleButton9);
            this.groupControl1.Controls.Add(this.simpleButton7);
            this.groupControl1.Controls.Add(this.BtnAdd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1143, 60);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Trime";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.Appearance.Options.UseForeColor = true;
            this.BtnSave.Image = global::Purchesed.Properties.Resources._47_48;
            this.BtnSave.Location = new System.Drawing.Point(100, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(127, 48);
            this.BtnSave.TabIndex = 29;
            this.BtnSave.Text = "New Trime";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnClose.Appearance.Options.UseFont = true;
            this.BtnClose.Appearance.Options.UseForeColor = true;
            this.BtnClose.Image = global::Purchesed.Properties.Resources.Close_Box_Red;
            this.BtnClose.Location = new System.Drawing.Point(918, 7);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(125, 48);
            this.BtnClose.TabIndex = 28;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // simpleButton9
            // 
            this.simpleButton9.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton9.Appearance.Options.UseFont = true;
            this.simpleButton9.Appearance.Options.UseForeColor = true;
            this.simpleButton9.Image = global::Purchesed.Properties.Resources.refresh_folder_48;
            this.simpleButton9.Location = new System.Drawing.Point(784, 7);
            this.simpleButton9.Name = "simpleButton9";
            this.simpleButton9.Size = new System.Drawing.Size(128, 48);
            this.simpleButton9.TabIndex = 26;
            this.simpleButton9.Text = "UPDATE";
            // 
            // simpleButton7
            // 
            this.simpleButton7.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButton7.Appearance.Options.UseFont = true;
            this.simpleButton7.Appearance.Options.UseForeColor = true;
            this.simpleButton7.Image = global::Purchesed.Properties.Resources.free_27_48;
            this.simpleButton7.Location = new System.Drawing.Point(643, 7);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(117, 48);
            this.simpleButton7.TabIndex = 24;
            this.simpleButton7.Text = "DELETE";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Appearance.Options.UseFont = true;
            this.BtnAdd.Image = global::Purchesed.Properties.Resources.image_add;
            this.BtnAdd.Location = new System.Drawing.Point(233, 5);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(134, 48);
            this.BtnAdd.TabIndex = 23;
            this.BtnAdd.Text = "Quotation";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(0, 60);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1143, 599);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "TP ID.";
            this.columnHeader1.Width = 138;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trime Class";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Spece";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Deyeing";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Finishing";
            this.columnHeader7.Width = 200;
            // 
            // btnSample
            // 
            this.btnSample.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSample.Appearance.Options.UseFont = true;
            this.btnSample.Image = global::Purchesed.Properties.Resources.image_add;
            this.btnSample.Location = new System.Drawing.Point(373, 5);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(168, 48);
            this.btnSample.TabIndex = 30;
            this.btnSample.Text = "Sample request";
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // TrimeQuotationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 659);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TrimeQuotationList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrimeQuotationList";
            this.Load += new System.EventHandler(this.TrimeQuotationList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.SimpleButton BtnClose;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraEditors.SimpleButton BtnAdd;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private DevExpress.XtraEditors.SimpleButton btnSample;
    }
}