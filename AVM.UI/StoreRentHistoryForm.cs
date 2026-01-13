using AVM.Business;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class StoreRentHistoryForm : XtraForm
    {
        private int _storeId;
        private RentManager _rentManager;
        private GridControl gridRents;
        private GridView gridView1;

        public StoreRentHistoryForm(int storeId, string storeName)
        {
            InitializeComponent();
            _storeId = storeId;
            _rentManager = new RentManager();
            
            this.Text = $"{storeName} - Kira Geçmişi";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            InitializeGrid();
            LoadData();
        }

        private void InitializeGrid()
        {
            gridRents = new GridControl();
            gridRents.Dock = DockStyle.Fill;
            this.Controls.Add(gridRents);

            gridView1 = new GridView(gridRents);
            gridRents.MainView = gridView1;
            
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void LoadData()
        {
            gridRents.DataSource = _rentManager.GetRentsByStore(_storeId);
            
            gridView1.PopulateColumns();
            // Hide IDs if needed, format currency
            if(gridView1.Columns["RentId"] != null) gridView1.Columns["RentId"].Visible = false;
            
            if(gridView1.Columns["Period"] != null) gridView1.Columns["Period"].Caption = "Dönem";
            if(gridView1.Columns["Amount"] != null) 
            {
                gridView1.Columns["Amount"].Caption = "Tutar";
                gridView1.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Amount"].DisplayFormat.FormatString = "c2";
            }
            if(gridView1.Columns["PaidStatus"] != null) gridView1.Columns["PaidStatus"].Caption = "Durum";
            if(gridView1.Columns["PaidDate"] != null) gridView1.Columns["PaidDate"].Caption = "Ödeme Tarihi";
            if(gridView1.Columns["PaidAmount"] != null) 
            {
                gridView1.Columns["PaidAmount"].Caption = "Ödenen";
                gridView1.Columns["PaidAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["PaidAmount"].DisplayFormat.FormatString = "c2";
            }
            if(gridView1.Columns["RemainingAmount"] != null) 
            {
                gridView1.Columns["RemainingAmount"].Caption = "Kalan";
                gridView1.Columns["RemainingAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["RemainingAmount"].DisplayFormat.FormatString = "c2";
            }

            if(gridView1.Columns["PaidStatus"] != null) gridView1.Columns["PaidStatus"].Caption = "Durum";
            if(gridView1.Columns["PaidDate"] != null) gridView1.Columns["PaidDate"].Caption = "Ödeme Tarihi";
            if(gridView1.Columns["LateFee"] != null) gridView1.Columns["LateFee"].Visible = false;
        }
    }
}
