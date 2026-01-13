namespace AVM.UI
{
    partial class KiraciEkleForm
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
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.txtContactName = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtTenantCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.ContactName = new DevExpress.XtraEditors.LabelControl();
            this.Phone = new DevExpress.XtraEditors.LabelControl();
            this.chkStatus = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cmbStore = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStore.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(261, 71);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(125, 22);
            this.txtCompanyName.TabIndex = 0;
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(261, 124);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(125, 22);
            this.txtContactName.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(261, 178);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(125, 22);
            this.txtPhone.TabIndex = 2;
            // 
            // txtTenantCompanyName
            // 
            this.txtTenantCompanyName.Location = new System.Drawing.Point(112, 74);
            this.txtTenantCompanyName.Name = "txtTenantCompanyName";
            this.txtTenantCompanyName.Size = new System.Drawing.Size(55, 16);
            this.txtTenantCompanyName.TabIndex = 3;
            this.txtTenantCompanyName.Text = "Firma Adı";
            // 
            // ContactName
            // 
            this.ContactName.Location = new System.Drawing.Point(112, 127);
            this.ContactName.Name = "ContactName";
            this.ContactName.Size = new System.Drawing.Size(56, 16);
            this.ContactName.TabIndex = 4;
            this.ContactName.Text = "Yetkili Kişi";
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(112, 181);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(43, 16);
            this.Phone.TabIndex = 5;
            this.Phone.Text = "Telefon";
            // 
            // chkStatus
            // 
            this.chkStatus.Location = new System.Drawing.Point(118, 231);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Properties.Caption = "Aktif";
            this.chkStatus.Size = new System.Drawing.Size(94, 24);
            this.chkStatus.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(283, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbStore
            // 
            this.cmbStore.Location = new System.Drawing.Point(261, 232);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStore.Properties.NullText = "Mağaza Seçiniz";
            this.cmbStore.Size = new System.Drawing.Size(125, 22);
            this.cmbStore.TabIndex = 4;
            // 
            // KiraciEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 604);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.ContactName);
            this.Controls.Add(this.txtTenantCompanyName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.txtCompanyName);
            this.Name = "KiraciEkleForm";
            this.Text = "KiraciEkleForm";
            this.Load += new System.EventHandler(this.KiraciEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStore.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCompanyName;
        private DevExpress.XtraEditors.TextEdit txtContactName;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl txtTenantCompanyName;
        private DevExpress.XtraEditors.LabelControl ContactName;
        private DevExpress.XtraEditors.LabelControl Phone;
        private DevExpress.XtraEditors.CheckEdit chkStatus;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit cmbStore;
    }
}