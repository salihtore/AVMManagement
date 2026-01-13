namespace AVM.UI
{
    partial class MagazaEkleForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.TextEdit txtStoreCode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCategory;
        private DevExpress.XtraEditors.SpinEdit numFloorNumber;
        private DevExpress.XtraEditors.SpinEdit numSquareMeter;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblCategory;
        private DevExpress.XtraEditors.LabelControl lblFloor;
        private DevExpress.XtraEditors.LabelControl lblArea;
        private DevExpress.XtraEditors.LabelControl lblDesc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.txtStoreCode = new DevExpress.XtraEditors.TextEdit();
            this.cmbCategory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.numFloorNumber = new DevExpress.XtraEditors.SpinEdit();
            this.numSquareMeter = new DevExpress.XtraEditors.SpinEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblFloor = new DevExpress.XtraEditors.LabelControl();
            this.lblArea = new DevExpress.XtraEditors.LabelControl();
            this.lblDesc = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSquareMeter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();

            // Labels
            this.lblName.Text = "Mağaza Adı:";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            
            this.lblCode.Text = "Mağaza Kodu:";
            this.lblCode.Location = new System.Drawing.Point(20, 50);

            this.lblCategory.Text = "Kategori:";
            this.lblCategory.Location = new System.Drawing.Point(20, 80);

            this.lblFloor.Text = "Kat No:";
            this.lblFloor.Location = new System.Drawing.Point(20, 110);

            this.lblArea.Text = "Metrekare:";
            this.lblArea.Location = new System.Drawing.Point(20, 140);

            this.lblDesc.Text = "Açıklama:";
            this.lblDesc.Location = new System.Drawing.Point(20, 170);

            // Controls
            this.txtStoreName.Location = new System.Drawing.Point(120, 17);
            this.txtStoreName.Size = new System.Drawing.Size(200, 20);

            this.txtStoreCode.Location = new System.Drawing.Point(120, 47);
            this.txtStoreCode.Size = new System.Drawing.Size(200, 20);

            this.cmbCategory.Location = new System.Drawing.Point(120, 77);
            this.cmbCategory.Size = new System.Drawing.Size(200, 20);
            this.cmbCategory.Properties.Items.AddRange(new object[] { "Giyim", "Teknoloji", "Gıda", "Eğlence", "Kozmetik", "Diğer" });

            this.numFloorNumber.Location = new System.Drawing.Point(120, 107);
            this.numFloorNumber.Size = new System.Drawing.Size(200, 20);

            this.numSquareMeter.Location = new System.Drawing.Point(120, 137);
            this.numSquareMeter.Size = new System.Drawing.Size(200, 20);

            this.txtDescription.Location = new System.Drawing.Point(120, 167);
            this.txtDescription.Size = new System.Drawing.Size(200, 60);

            // Save Button
            this.btnSave.Text = "Kaydet";
            this.btnSave.Location = new System.Drawing.Point(120, 240);
            this.btnSave.Size = new System.Drawing.Size(200, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.lblName); this.Controls.Add(this.txtStoreName);
            this.Controls.Add(this.lblCode); this.Controls.Add(this.txtStoreCode);
            this.Controls.Add(this.lblCategory); this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblFloor); this.Controls.Add(this.numFloorNumber);
            this.Controls.Add(this.lblArea); this.Controls.Add(this.numSquareMeter);
            this.Controls.Add(this.lblDesc); this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mağaza Ekle";
            
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSquareMeter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
