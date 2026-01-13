namespace AVM.UI
{
    partial class AdminForm
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
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accAnaSayfa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accMagazalar = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accKiracilar = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accKiraOdemeleri = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accGiderler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accPersoneller = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accDuyuruMesaj = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accCikisYap = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControl2 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accAnaSayfa,
            this.accMagazalar,
            this.accKiracilar,
            this.accKiraOdemeleri,
            this.accGiderler,
            this.accPersoneller,
            this.accDuyuruMesaj,
            this.accCikisYap});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.Size = new System.Drawing.Size(260, 587);
            this.accordionControl1.TabIndex = 0;
            
            // --- UI REVAMP START ---
            // Vibrant Background
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80))))); // Dark Blue-Gray
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            
            // Item Colors
            this.accordionControl1.Appearance.Item.Normal.ForeColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.Item.Normal.Options.UseForeColor = true;
            this.accordionControl1.Appearance.Item.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219))))); // Bright Blue
            this.accordionControl1.Appearance.Item.Hovered.Options.UseBackColor = true;
            this.accordionControl1.Appearance.Item.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185))))); // Darker Blue
            this.accordionControl1.Appearance.Item.Pressed.Options.UseBackColor = true;
            
            // Readable Fonts
            this.accordionControl1.Appearance.Item.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.accordionControl1.Appearance.Item.Normal.Options.UseFont = true;
            this.accordionControl1.Appearance.Group.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))); // If groups used
            this.accordionControl1.Appearance.Group.Normal.Options.UseFont = true;
            // --- UI REVAMP END ---
            // 
            // accAnaSayfa
            // 
            this.accAnaSayfa.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accAnaSayfa.Name = "accAnaSayfa";
            this.accAnaSayfa.Text = "Ana Sayfa";
            this.accAnaSayfa.Click += new System.EventHandler(this.accAnaSayfa_Click_1);
            // 
            // accMagazalar
            // 
            this.accMagazalar.Name = "accMagazalar";
            this.accMagazalar.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accMagazalar.Text = "Mağazalar";
            this.accMagazalar.Click += new System.EventHandler(this.accMagazalar_Click);
            // 
            // accKiracilar
            // 
            this.accKiracilar.Name = "accKiracilar";
            this.accKiracilar.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accKiracilar.Text = "Kiracılar";
            this.accKiracilar.Click += new System.EventHandler(this.accKiracilar_Click);
            // 
            // accKiraOdemeleri
            // 
            this.accKiraOdemeleri.Name = "accKiraOdemeleri";
            this.accKiraOdemeleri.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accKiraOdemeleri.Text = "Kira Ödemeleri";
            // 
            // accGiderler
            // 
            this.accGiderler.Name = "accGiderler";
            this.accGiderler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accGiderler.Text = "Giderler";
            // 
            // accPersoneller
            // 
            this.accPersoneller.Name = "accPersoneller";
            this.accPersoneller.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accPersoneller.Text = "Personeller";
            // 
            // accDuyuruMesaj
            // 
            this.accDuyuruMesaj.Name = "accDuyuruMesaj";
            this.accDuyuruMesaj.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accDuyuruMesaj.Text = "Duyurular / Mesajlar";
            // 
            // accCikisYap
            // 
            this.accCikisYap.Name = "accCikisYap";
            this.accCikisYap.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accCikisYap.Text = "Çıkış Yap";
            // 
            // accordionControl2
            // 
            this.accordionControl2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2});
            this.accordionControl2.Location = new System.Drawing.Point(297, 259);
            this.accordionControl2.Name = "accordionControl2";
            this.accordionControl2.Size = new System.Drawing.Size(8, 8);
            this.accordionControl2.TabIndex = 1;
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Element2";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(260, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(357, 587);
            this.panelMain.TabIndex = 2;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 587);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.accordionControl2);
            this.Controls.Add(this.accordionControl1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // Maximize by default
            this.ClientSize = new System.Drawing.Size(1200, 800); // Larger default size
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accAnaSayfa;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accMagazalar;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accKiracilar;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accKiraOdemeleri;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accGiderler;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accPersoneller;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accDuyuruMesaj;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accCikisYap;
    }
}