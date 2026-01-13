using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using DevExpress.XtraGrid;
using System.Linq;
using AVM.DataAccess;

namespace AVM.UI
{
    public partial class UCTenantDashboard : XtraUserControl
    {
        private int _storeId;
        private UnitOfWork _uow;

        private LabelControl lblDebt;
        private GridControl gridAnnouncements;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private PanelControl pnlTop;

        public UCTenantDashboard(int storeId)
        {
            InitializeComponent();
            _storeId = storeId;
            _uow = new AVM.DataAccess.UnitOfWork(); // Quick access
            LoadData();
        }

        private void InitializeComponent()
        {
            this.pnlTop = new PanelControl();
            this.lblDebt = new LabelControl();
            this.gridAnnouncements = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnouncements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop (Debt Section)
            // 
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 100;
            this.pnlTop.Controls.Add(this.lblDebt);

            // 
            // lblDebt
            // 
            this.lblDebt.Appearance.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblDebt.Appearance.ForeColor = Color.Red;
            this.lblDebt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDebt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDebt.AutoSizeMode = LabelAutoSizeMode.None;
            this.lblDebt.Dock = DockStyle.Fill;
            this.lblDebt.Text = "Toplam Borç: 0.00 ₺";

            // 
            // gridAnnouncements
            // 
            this.gridAnnouncements.MainView = this.gridView;
            this.gridAnnouncements.Dock = DockStyle.Fill;
            this.gridAnnouncements.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView });

            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridAnnouncements;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsBehavior.Editable = false;
             // Styling
            this.gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            this.gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            this.gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new Font("Segoe UI", 9);
            this.gridView.Appearance.Row.ForeColor = Color.Black;
            this.gridView.Appearance.Row.Options.UseForeColor = true;

            // 
            // Form Controls
            // 
            this.Controls.Add(this.gridAnnouncements);
            this.Controls.Add(this.pnlTop);

            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnouncements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            // Simulate Debt Calculation (Sum of unpaid rents? For now dummy or simple logic)
            // Real logic: _uow.Rents.GetAll().Where(r => r.Tenant.StoreId == _storeId && !r.IsPaid).Sum(r => r.Amount);
            // Assuming we have relation. For now, random or 0.
            decimal debt = 12500.50m; // Mock
            lblDebt.Text = $"Toplam Borç: {debt:C2}";

            // Announcements
            var announcements = _uow.Announcements.GetAll().OrderByDescending(a => a.CreatedDate).Take(10).ToList();
            gridAnnouncements.DataSource = announcements;
        }
    }
}
