using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using AVM.Core.Entities;

namespace AVM.UI
{
    public partial class TenantForm : DevExpress.XtraEditors.XtraForm
    {
        private AccordionControl accordionControl1;
        private AccordionControlElement accDashboard;
        private AccordionControlElement accTurnover;
        private AccordionControlElement accRequests;
        private AccordionControlElement accStorePersonnel;
        private AccordionControlElement accLeaveManagement;
        private AccordionControlElement accLogout;
        private PanelControl panelMain;
        
        private int _storeId;

        // Default constructor for Designer support (optional, but keep it safe)
        public TenantForm() : this(1) { } // Fallback to 1 if no ID passed (testing)

        public TenantForm(int storeId)
        {
            InitializeComponent(); 
            SetupControls();      
            _storeId = storeId;
            
            accDashboard.Click += (s,e) => LoadModule(new UCTenantDashboard(_storeId));
            accTurnover.Click += (s,e) => LoadModule(new UCTurnover(_storeId));
            accRequests.Click += (s,e) => LoadModule(new UCServiceRequests(_storeId));
            accStorePersonnel.Click += (s,e) => LoadModule(new UCStorePersonnel(_storeId));
            accLeaveManagement.Click += (s,e) => LoadModule(new UCManageLeaveRequests(_storeId));
            accLogout.Click += (s,e) => this.Close();

            // Default
            LoadModule(new UCTenantDashboard(_storeId));
            
            this.Text = "Mağaza Paneli - Mağaza ID: " + _storeId;
        }

        private void LoadModule(UserControl module)
        {
            panelMain.Controls.Clear();
            module.Dock = DockStyle.Fill;
            panelMain.Controls.Add(module);
        }

        private void SetupControls()
        {
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accDashboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accTurnover = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accRequests = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accStorePersonnel = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accLeaveManagement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accLogout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();

            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.SuspendLayout();

            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accDashboard,
            this.accTurnover,
            this.accRequests,
            this.accStorePersonnel,
            this.accLeaveManagement,
            this.accLogout});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.Size = new System.Drawing.Size(250, 600);
            
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Appearance.Item.Normal.ForeColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.Item.Normal.Options.UseForeColor = true;

            this.accDashboard.Name = "accDashboard";
            this.accDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accDashboard.Text = "Ana Sayfa";
            
            this.accTurnover.Name = "accTurnover";
            this.accTurnover.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accTurnover.Text = "Ciro Bildirimleri";

            this.accRequests.Name = "accRequests";
            this.accRequests.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accRequests.Text = "Talep Oluştur";

            this.accStorePersonnel.Name = "accStorePersonnel";
            this.accStorePersonnel.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accStorePersonnel.Text = "Personel Listesi";

            this.accLeaveManagement.Name = "accLeaveManagement";
            this.accLeaveManagement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accLeaveManagement.Text = "İzin Yönetimi";

            this.accLogout.Name = "accLogout";
            this.accLogout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accLogout.Text = "Çıkış Yap";

            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(250, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(550, 600);

            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.accordionControl1);
            this.Name = "TenantForm";
            this.Text = "Mağaza Paneli";
            this.WindowState = FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.ResumeLayout(false);
        }
    }
}