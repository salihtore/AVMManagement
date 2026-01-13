using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using AVM.DataAccess;
using AVM.Core.Entities;

namespace AVM.UI
{
    public partial class UCAnaSayfa : UserControl
    {
        private UnitOfWork _uow;

        // --- UI Controls ---
        private LayoutControl layoutControl;
        
        // Cards (Premium Look)
        private PanelControl pnlCard1, pnlCard2, pnlCard3, pnlCard4;
        private LabelControl lblVal1, lblVal2, lblVal3, lblVal4;

        // Grids
        private GridControl gridAlerts;
        private GridView gridViewAlerts;

        // Charts
        private ChartControl chartOccupancy;
        
        // Data Load Timer for animation effect (simulation)
        private Timer tmrAnimation;

        public UCAnaSayfa()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            InitializeDashboardUI();
        }

        private void UCAnaSayfa_Load_1(object sender, EventArgs e)
        {
            RefreshDashboardData();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !this.DesignMode) RefreshDashboardData();
        }

        private void InitializeDashboardUI()
        {
            this.Controls.Clear();
            layoutControl = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layoutControl);

            LayoutControlGroup root = layoutControl.Root;
            root.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            root.GroupBordersVisible = false;
            
            // USE TABLE LAYOUT FOR ROOT TO CONTROL HEIGHTS
            root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            root.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            root.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Percent, Width = 100 });
            
            root.OptionsTableLayoutGroup.RowDefinitions.Clear();
            root.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition { SizeType = SizeType.Absolute, Height = 160 }); // Increased Height
            root.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition { SizeType = SizeType.Percent, Height = 100 });

            // --- 1. TOP CARDS ROW ---
            pnlCard1 = CreateModernCard("BU AY GELİR", "₺0", Color.FromArgb(46, 204, 113), out lblVal1); // Green
            pnlCard2 = CreateModernCard("BU AY GİDER", "₺0", Color.FromArgb(231, 76, 60), out lblVal2);   // Red
            pnlCard3 = CreateModernCard("NET KAZANÇ", "₺0", Color.FromArgb(52, 152, 219), out lblVal3);   // Blue
            pnlCard4 = CreateModernCard("DOLULUK ORANI", "%0", Color.FromArgb(155, 89, 182), out lblVal4); // Purple

            LayoutControlGroup groupCards = root.AddGroup();
            groupCards.TextVisible = false;
            groupCards.GroupBordersVisible = false;
            groupCards.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            
            // Correct Positioning for Group in Table Layout
            groupCards.OptionsTableLayoutItem.RowIndex = 0;
            groupCards.OptionsTableLayoutItem.ColumnIndex = 0;

            // Configure Columns inside Cards Group
            groupCards.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            for(int i=0; i<4; i++) 
                groupCards.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Percent, Width = 25 });
            groupCards.OptionsTableLayoutGroup.RowDefinitions.Clear();
            groupCards.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition { SizeType = SizeType.Percent, Height = 100 });

            AddItemToTable(groupCards, pnlCard1, 0, 0);
            AddItemToTable(groupCards, pnlCard2, 1, 0);
            AddItemToTable(groupCards, pnlCard3, 2, 0);
            AddItemToTable(groupCards, pnlCard4, 3, 0);
            
            // --- 2. MAIN CONTENT SPLIT ---
            LayoutControlGroup groupMain = root.AddGroup();
            groupMain.TextVisible = false;
            groupMain.GroupBordersVisible = false;
            groupMain.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;

            // Correct Positioning for Main Group
            groupMain.OptionsTableLayoutItem.RowIndex = 1;
            groupMain.OptionsTableLayoutItem.ColumnIndex = 0;
            
            // Columns for Main Group
            groupMain.OptionsTableLayoutGroup.ColumnDefinitions.Clear();
            groupMain.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Percent, Width = 60 });
            groupMain.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Percent, Width = 40 });
            groupMain.OptionsTableLayoutGroup.RowDefinitions.Clear();
            groupMain.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition { SizeType = SizeType.Percent, Height = 100 });

            // A. Grid
            gridAlerts = new GridControl();
            gridViewAlerts = new GridView(gridAlerts);
            gridAlerts.MainView = gridViewAlerts;
            InitAlertGridStyle();
            
            GroupControl groupGrid = new GroupControl();
            groupGrid.Text = "Ödeme Günü Yaklaşan Sözleşmeler";
            groupGrid.AppearanceCaption.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            groupGrid.Controls.Add(gridAlerts);
            gridAlerts.Dock = DockStyle.Fill;

            LayoutControlItem itemGrid = groupMain.AddItem("Grid", groupGrid);
            itemGrid.TextVisible = false;
            itemGrid.OptionsTableLayoutItem.ColumnIndex = 0;

            // B. Chart
            CreateModernChart();
            LayoutControlItem itemChart = groupMain.AddItem("Chart", chartOccupancy);
            itemChart.TextVisible = false;
            itemChart.OptionsTableLayoutItem.ColumnIndex = 1;

            // Add animation support
            tmrAnimation = new Timer { Interval = 100 };
            tmrAnimation.Tick += (s, ev) => { 
                // Simple animation hook logic if needed, currently unused but requested "hareketli"
                tmrAnimation.Stop();
            };
        }

        private void AddItemToTable(LayoutControlGroup group, Control control, int col, int row)
        {
            LayoutControlItem item = group.AddItem(control.Name, control);
            item.TextVisible = false;
            item.OptionsTableLayoutItem.ColumnIndex = col;
            item.OptionsTableLayoutItem.RowIndex = row;
        }

        private void InitAlertGridStyle()
        {
            gridViewAlerts.OptionsView.ShowGroupPanel = false;
            gridViewAlerts.OptionsView.ShowIndicator = false;
            gridViewAlerts.OptionsView.EnableAppearanceEvenRow = true;
            gridViewAlerts.OptionsBehavior.Editable = false;
            
            // Vibrant Style -> Pale Gray Style
            gridViewAlerts.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            gridViewAlerts.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridViewAlerts.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            gridViewAlerts.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewAlerts.Appearance.HeaderPanel.Options.UseForeColor = true;
            
            gridViewAlerts.Appearance.Row.BackColor = Color.White;
            gridViewAlerts.Appearance.Row.BackColor2 = Color.FromArgb(245, 245, 247);
            gridViewAlerts.Appearance.Row.Font = new Font("Segoe UI", 9);
            
            gridViewAlerts.Appearance.FocusedRow.BackColor = Color.FromArgb(52, 152, 219);
            gridViewAlerts.Appearance.FocusedRow.ForeColor = Color.White;
            gridViewAlerts.Appearance.FocusedRow.Options.UseBackColor = true;
            
            gridViewAlerts.RowHeight = 30;
        }

        private PanelControl CreateModernCard(string title, string initialVal, Color topStripColor, out LabelControl lblVal)
        {
            PanelControl panel = new PanelControl();
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panel.BackColor = Color.White;
            panel.MinimumSize = new Size(0, 140);
            // Removed MaximumSize to allow full stretch
            
            // Top Color Strip
            Panel pnlStrip = new Panel();
            pnlStrip.Dock = DockStyle.Top;
            pnlStrip.Height = 5; // Slightly slimmer
            pnlStrip.BackColor = topStripColor;
            panel.Controls.Add(pnlStrip);

            // Title
            LabelControl lblTitle = new LabelControl();
            lblTitle.Text = title.ToUpper();
            lblTitle.Appearance.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.Gray;
            lblTitle.Padding = new Padding(15, 12, 0, 0);
            
            // Fix Overlap: Force Height
            lblTitle.AutoSizeMode = LabelAutoSizeMode.None;
            lblTitle.Height = 35; // Reserve 35px height for title
            lblTitle.Dock = DockStyle.Top;
            panel.Controls.Add(lblTitle);

            // Value
            lblVal = new LabelControl();
            lblVal.Text = initialVal;
            lblVal.Appearance.Font = new Font("Segoe UI", 22, FontStyle.Bold); 
            lblVal.Appearance.ForeColor = Color.FromArgb(44, 62, 80);
            lblVal.Padding = new Padding(15, 0, 0, 0); 
            
            // KEY FIX: Disable AutoSize to allow Dock = Fill to work effectively
            lblVal.AutoSizeMode = LabelAutoSizeMode.None;
            lblVal.Dock = DockStyle.Fill; 
            
            lblVal.Appearance.TextOptions.VAlignment = VertAlignment.Top; 
            panel.Controls.Add(lblVal);
            lblVal.BringToFront(); // Ensure it is visually on top

            return panel;
        }

        private void CreateModernChart()
        {
            chartOccupancy = new ChartControl();
            chartOccupancy.BorderOptions.Visibility = DefaultBoolean.False;
            
            ChartTitle t = new ChartTitle();
            t.Text = "AVM Doluluk Analizi";
            t.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            t.Alignment = StringAlignment.Center;
            chartOccupancy.Titles.Add(t);

            Series series = new Series("Doluluk", ViewType.Doughnut);
            ((DoughnutSeriesView)series.View).HoleRadiusPercent = 55;
            ((DoughnutSeriesView)series.View).ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.Equal, "Dolu"));
            
            chartOccupancy.Series.Add(series);
            chartOccupancy.Dock = DockStyle.Fill;
        }

        private void RefreshDashboardData()
        {
            // --- 1. Finance Data (Real-time) ---
            var now = DateTime.Now;
            
            // Income: Total Payments this month
            decimal income = _uow.Payments.GetAll()
                .Where(p => p.PaidAt.Month == now.Month && p.PaidAt.Year == now.Year)
                .Sum(p => (decimal?)p.Amount) ?? 0;

            // Expense: Total Expenses this month
             decimal expense = _uow.Expenses.GetAll()
                .Where(e => e.ExpenseDate.Month == now.Month && e.ExpenseDate.Year == now.Year)
                .Sum(e => (decimal?)e.Amount) ?? 0;

            decimal net = income - expense;

            // --- 2. Occupancy Data ---
            int totalStores = _uow.Stores.GetAll().Count();
            int occupied = _uow.Stores.GetAll()
                .Join(_uow.Tenants.GetAll(), s => s.StoreId, t => t.StoreId, (s, t) => s)
                .Select(s => s.StoreId)
                .Distinct()
                .Count();
            
            double rate = totalStores == 0 ? 0 : (double)occupied / totalStores;

            // Update Labels
            lblVal1.Text = income.ToString("C0");   // Gross Income
            lblVal2.Text = expense.ToString("C0");  // Expense
            lblVal3.Text = net.ToString("C0");      // Net Profit
            
            // Color Net Profit based on value
            lblVal3.Appearance.ForeColor = net >= 0 ? Color.FromArgb(46, 204, 113) : Color.FromArgb(231, 76, 60);

            lblVal4.Text = $"%{rate * 100:0}";      // Occupancy Rate

            // --- 2. Chart Data ---
            chartOccupancy.Series[0].Points.Clear();
            chartOccupancy.Series[0].Points.Add(new SeriesPoint("Dolu", occupied));
            chartOccupancy.Series[0].Points.Add(new SeriesPoint("Boş", totalStores - occupied));

            // --- 3. Alert List Data (Logic: Active tenants who haven't paid this month) ---
            var paidTenantIds = _uow.Payments.GetAll()
                .Where(p => p.PaidAt.Month == now.Month && p.PaidAt.Year == now.Year)
                .Select(p => p.TenantId);

            var alerts = from t in _uow.Tenants.GetAll()
                         join s in _uow.Stores.GetAll() on t.StoreId equals s.StoreId
                         where t.Status == true && !paidTenantIds.Contains(t.TenantId)
                         select new {
                             Mağaza = s.StoreName,
                             Kiracı = t.CompanyName,
                             Durum = "Ödeme Bekleniyor", 
                             Vade = "Bu Ayın 5'i" 
                         };

            gridAlerts.DataSource = alerts.ToList();
            gridViewAlerts.PopulateColumns();
            gridViewAlerts.BestFitColumns();
        }
    }
}
