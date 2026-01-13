using AVM.Business;
using AVM.Core.Entities;
using AVM.DataAccess;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class UCRentManagement : XtraUserControl
    {
        private UnitOfWork _uow;
        private RentManager _rentManager;

        // UI Controls
        private LayoutControl layoutControl;
        private GridControl gridRents;
        private GridView gridView1;
        private SimpleButton btnGenerateRents;
        private SimpleButton btnMakePayment;

        public UCRentManagement()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            _rentManager = new RentManager();
            InitializeRentUI();
            LoadRents();
        }

        private void InitializeRentUI()
        {
            layoutControl = new LayoutControl();
            layoutControl.Dock = DockStyle.Fill;
            this.Controls.Add(layoutControl);

            // Grid Setup
            gridRents = new GridControl();
            gridView1 = new GridView(gridRents);
            gridRents.MainView = gridView1;
            
            // Grid Styling
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsBehavior.Editable = false;
            
            gridView1.OptionsFind.AlwaysVisible = true;
            gridView1.OptionsFind.FindNullPrompt = "Ara...";
            gridView1.OptionsFind.ShowFindButton = false; 
            gridView1.OptionsFind.ShowClearButton = false; 
            
            gridView1.RowHeight = 35;
            
            // Vibrant Style -> Pale Gray Style
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            
            gridView1.Appearance.Row.BackColor = Color.White;
            gridView1.Appearance.Row.ForeColor = Color.Black; // FORCE READABILITY
            gridView1.Appearance.Row.Options.UseForeColor = true;
            gridView1.Appearance.Row.BackColor2 = Color.FromArgb(245, 245, 247);
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 10);
            
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(52, 152, 219);
            gridView1.Appearance.FocusedRow.ForeColor = Color.White;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            
            // Buttons
            btnGenerateRents = CreateButton("Bu Ayın Kiralarını Oluştur", Color.FromArgb(46, 204, 113));
            btnGenerateRents.Click += BtnGenerateRents_Click;

            btnMakePayment = CreateButton("Ödeme Al", Color.FromArgb(52, 152, 219));
            btnMakePayment.Click += BtnMakePayment_Click;

            // Layout
            LayoutControlGroup root = layoutControl.Root;
            root.GroupBordersVisible = false;
            root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);

            // Header
            LayoutControlGroup header = root.AddGroup();
            header.GroupBordersVisible = false;
            header.TextVisible = false;
            
            LabelControl lblTitle = new LabelControl();
            lblTitle.Text = "Kira ve Ödeme Yönetimi";
            lblTitle.Appearance.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(44, 62, 80);
            
            LayoutControlItem itemTitle = header.AddItem("Title", lblTitle);
            itemTitle.TextVisible = false;
            itemTitle.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            
            EmptySpaceItem spacer = new EmptySpaceItem();
            header.AddItem(spacer).Move(itemTitle, DevExpress.XtraLayout.Utils.InsertType.Right);
            
            LayoutControlItem itemGen = header.AddItem("Gen", btnGenerateRents);
            SetupButtonItem(itemGen, 200);
            itemGen.Move(spacer, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemPay = header.AddItem("Pay", btnMakePayment);
            SetupButtonItem(itemPay, 140);
            itemPay.Move(itemGen, DevExpress.XtraLayout.Utils.InsertType.Right);

            // Grid Layout
            LayoutControlItem itemGrid = root.AddItem("Grid", gridRents);
            itemGrid.TextVisible = false;
        }

        private SimpleButton CreateButton(string text, Color color)
        {
            SimpleButton btn = new SimpleButton();
            btn.Text = text;
            btn.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Appearance.BackColor = color;
            btn.Appearance.ForeColor = Color.White;
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            btn.LookAndFeel.UseDefaultLookAndFeel = false;
            return btn;
        }

        private void SetupButtonItem(LayoutControlItem item, int width)
        {
            item.TextVisible = false;
            item.MaxSize = new Size(width, 45);
            item.MinSize = new Size(width, 45);
            item.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
        }

        private void LoadRents()
        {
            gridRents.DataSource = _rentManager.GetAllRentsDetailed();
            
            gridView1.PopulateColumns();
            if(gridView1.Columns["RentId"] != null) gridView1.Columns["RentId"].Visible = false;
            if(gridView1.Columns["TenantId"] != null) gridView1.Columns["TenantId"].Visible = false;
            if(gridView1.Columns["Period"] != null) gridView1.Columns["Period"].Caption = "Dönem";
            if(gridView1.Columns["StoreName"] != null) gridView1.Columns["StoreName"].Caption = "Mağaza";
            if(gridView1.Columns["TenantName"] != null) gridView1.Columns["TenantName"].Caption = "Kiracı";
            if(gridView1.Columns["Amount"] != null) 
            {
                gridView1.Columns["Amount"].Caption = "Tutar";
                gridView1.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Amount"].DisplayFormat.FormatString = "c2";
            }
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
            if(gridView1.Columns["PaidDate"] != null) gridView1.Columns["PaidDate"].Caption = "Ödeme T.";
        }

        private void BtnGenerateRents_Click(object sender, EventArgs e)
        {
            try 
            {
                _rentManager.GenerateCurrentMonthRents();
                MessageBox.Show("Bu ayın kiraları başarıyla kontrol edildi ve oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRents();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMakePayment_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) 
            {
                MessageBox.Show("Lütfen ödeme almak için bir kira kaydı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rentId = (int)row.GetType().GetProperty("RentId").GetValue(row, null);
            string tenantName = (string)row.GetType().GetProperty("TenantName").GetValue(row, null);

            // We want RemainingAmount, not total Amount. However in LoadGrid we have "RemainingAmount" property in anonymous object.
            decimal remaining = (decimal)row.GetType().GetProperty("RemainingAmount").GetValue(row, null);
            
            // Open PaymentForm
            using (var f = new PaymentForm(rentId, tenantName, remaining))
            {
                if(f.ShowDialog() == DialogResult.OK)
                {
                    LoadRents();
                }
            }
        }

        private void UCRentManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
