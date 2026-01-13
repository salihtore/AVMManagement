namespace AVM.UI
{
    partial class PersonnelEditForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtPosition = new DevExpress.XtraEditors.TextEdit();
            this.txtSalary = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.cmbStore = new DevExpress.XtraEditors.LookUpEdit();
            this.txtShiftStart = new DevExpress.XtraEditors.TimeEdit();
            this.txtShiftEnd = new DevExpress.XtraEditors.TimeEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem(); 
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            this.SuspendLayout();

            // layoutControl1
            this.layoutControl1.Controls.Add(this.txtFullName);
            this.layoutControl1.Controls.Add(this.txtPosition);
            this.layoutControl1.Controls.Add(this.txtSalary);
            this.layoutControl1.Controls.Add(this.txtPhone);
            this.layoutControl1.Controls.Add(this.cmbStore);
            this.layoutControl1.Controls.Add(this.txtShiftStart);
            this.layoutControl1.Controls.Add(this.txtShiftEnd);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Name = "layoutControl1";

            // Controls
            this.txtFullName.Name = "txtFullName";
            this.txtPosition.Name = "txtPosition";
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Properties.Mask.EditMask = "c2";
            this.txtSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            
            this.txtPhone.Name = "txtPhone";
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Properties.NullText = "Merkez (Mağaza Seçiniz)";
            
            this.txtShiftStart.Name = "txtShiftStart";
            this.txtShiftStart.Properties.Mask.EditMask = "t";
            this.txtShiftEnd.Name = "txtShiftEnd";
            this.txtShiftEnd.Properties.Mask.EditMask = "t";

            this.btnSave.Text = "Kaydet";
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "İptal";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Groups
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutControlItem1,
                this.layoutControlItem2,
                this.layoutControlItem3,
                this.layoutControlItem4,
                this.layoutControlItem5,
                this.layoutControlItem6,
                this.layoutControlItem7,
                this.layoutControlItem8,
                this.layoutControlItem9
            });

            // Layout Items
            this.layoutControlItem1.Control = this.txtFullName;
            this.layoutControlItem1.Text = "Ad Soyad";
            
            this.layoutControlItem2.Control = this.txtPosition;
            this.layoutControlItem2.Text = "Pozisyon";
            
            this.layoutControlItem3.Control = this.txtSalary;
            this.layoutControlItem3.Text = "Maaş";
            
            this.layoutControlItem4.Control = this.txtPhone;
            this.layoutControlItem4.Text = "Telefon";
            
            this.layoutControlItem5.Control = this.cmbStore;
            this.layoutControlItem5.Text = "Atanan Mağaza";
            
            this.layoutControlItem6.Control = this.txtShiftStart;
            this.layoutControlItem6.Text = "Vardiya Başlangıç";
            
            this.layoutControlItem7.Control = this.txtShiftEnd;
            this.layoutControlItem7.Text = "Vardiya Bitiş";
            
            this.layoutControlItem8.Control = this.btnSave;
            this.layoutControlItem8.TextVisible = false;
            
            this.layoutControlItem9.Control = this.btnCancel;
            this.layoutControlItem9.TextVisible = false;
            
            // Adding
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PersonnelEditForm";
            this.Text = "Personel Düzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtPosition;
        private DevExpress.XtraEditors.TextEdit txtSalary;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LookUpEdit cmbStore;
        private DevExpress.XtraEditors.TimeEdit txtShiftStart;
        private DevExpress.XtraEditors.TimeEdit txtShiftEnd;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
