using AVM.Core.Entities;
using AVM.DataAccess;
using DevExpress.Utils;
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
    public partial class UCKiracilar : XtraUserControl
    {
        private UnitOfWork _uow;

        // UI Controls
        private LayoutControl layoutControl;
        private GridControl gridTenants;
        private GridView gridView1;
        private SimpleButton btnAdd;
        private SimpleButton btnEdit;
        private SimpleButton btnDelete;

        public UCKiracilar()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            InitializeTenantUI();
            LoadTenants();
        }

        private void InitializeTenantUI()
        {
            layoutControl = new LayoutControl();
            layoutControl.Dock = DockStyle.Fill;
            this.Controls.Add(layoutControl);

            // Grid Setup
            gridTenants = new GridControl();
            gridView1 = new GridView(gridTenants);
            gridTenants.MainView = gridView1;
            
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsFind.AlwaysVisible = true;
            gridView1.OptionsFind.FindNullPrompt = "Aramak istediğiniz metni buraya yazın...";
            gridView1.OptionsBehavior.Editable = false;
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
            
            // Columns
            // We'll map data source columns: CompanyName, ContactPhone, etc.
            // Using logic to hide ID columns after binding.

            // Buttons
            btnAdd = CreateButton("Kiracı Ekle", Color.FromArgb(46, 204, 113));
            btnAdd.Click += BtnAdd_Click;

            btnEdit = CreateButton("Düzenle", Color.FromArgb(52, 152, 219));
            btnEdit.Click += BtnEdit_Click;

            btnDelete = CreateButton("Sözleşme Feshet", Color.FromArgb(231, 76, 60)); // Special usage for tenants
            btnDelete.Click += BtnDelete_Click;

            // Layout
            LayoutControlGroup root = layoutControl.Root;
            root.GroupBordersVisible = false;
            root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);

            // Header (Title + Buttons)
            LayoutControlGroup header = root.AddGroup();
            header.GroupBordersVisible = false;
            header.TextVisible = false;
            
            LabelControl lblTitle = new LabelControl();
            lblTitle.Text = "Kiracı Listesi";
            lblTitle.Appearance.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(44, 62, 80);
            
            LayoutControlItem itemTitle = header.AddItem("Title", lblTitle);
            itemTitle.TextVisible = false;
            itemTitle.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            
            EmptySpaceItem spacer = new EmptySpaceItem();
            header.AddItem(spacer).Move(itemTitle, DevExpress.XtraLayout.Utils.InsertType.Right);
            
            LayoutControlItem itemAdd = header.AddItem("Add", btnAdd);
            SetupButtonItem(itemAdd);
            itemAdd.Move(spacer, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemEdit = header.AddItem("Edit", btnEdit);
            SetupButtonItem(itemEdit);
            itemEdit.Move(itemAdd, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemDelete = header.AddItem("Delete", btnDelete);
            SetupButtonItem(itemDelete);
            itemDelete.Move(itemEdit, DevExpress.XtraLayout.Utils.InsertType.Right);

            // Grid Layout
            LayoutControlItem itemGrid = root.AddItem("Grid", gridTenants);
            itemGrid.TextVisible = false;
            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            BtnEdit_Click(null, null); // Re-use existing edit logic
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

        private void SetupButtonItem(LayoutControlItem item)
        {
            item.TextVisible = false;
            item.MaxSize = new Size(140, 45);
            item.MinSize = new Size(140, 45);
            item.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
        }

        private void LoadTenants()
        {
            // Join Tenants with Stores to show StoreName
            var tenants = _uow.Tenants.GetAll().ToList();
            var stores = _uow.Stores.GetAll().ToList();

            var list = from t in tenants
                       join s in stores on t.StoreId equals s.StoreId into ts
                       from subStore in ts.DefaultIfEmpty()
                       select new
                       {
                           t.TenantId,
                           CompanyName = t.CompanyName,
                           StoreName = subStore != null ? subStore.StoreName : "-",
                           ContactName = t.ContactName,
                           Phone = t.ContactPhone,
                           Email = t.Email,
                           Status = t.Status ? "Aktif" : "Pasif" // Formatting bool
                       };

            gridTenants.DataSource = list.ToList();
            gridView1.PopulateColumns(); // Force column creation
            
            // Adjust Columns (Safe Check)
            if(gridView1.Columns["TenantId"] != null) gridView1.Columns["TenantId"].Visible = false;
            if(gridView1.Columns["StoreId"] != null) gridView1.Columns["StoreId"].Visible = false;
            if(gridView1.Columns["CompanyName"] != null) gridView1.Columns["CompanyName"].Caption = "Firma Adı";
            if(gridView1.Columns["StoreName"] != null) gridView1.Columns["StoreName"].Caption = "Mağaza";
            if(gridView1.Columns["ContactName"] != null) gridView1.Columns["ContactName"].Caption = "Yetkili";
            if(gridView1.Columns["Phone"] != null) gridView1.Columns["Phone"].Caption = "Telefon";
            if(gridView1.Columns["Email"] != null) gridView1.Columns["Email"].Caption = "E-Posta";
            if(gridView1.Columns["Status"] != null) gridView1.Columns["Status"].Caption = "Durum";

            // Search Customization
            gridView1.OptionsFind.FindNullPrompt = "Ara...";
            gridView1.OptionsFind.ShowFindButton = false; // Hides the 'Find' button for a cleaner look
            gridView1.OptionsFind.ShowClearButton = false; // Optional: Hide clear button too or keep it
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new KiraciEkleForm())
            {
                if(f.ShowDialog() == DialogResult.OK) LoadTenants();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Need to fetch original entity ID from the anonymous object in grid
            var row = gridView1.GetFocusedRow();
            if (row == null) return;

            // Reflection to get ID because it's anonymous type
            int id = (int)row.GetType().GetProperty("TenantId").GetValue(row, null);
            var tenant = _uow.Tenants.Get(id);
            
            using (var f = new KiraciDuzenleForm(tenant))
            {
                if (f.ShowDialog() == DialogResult.OK) LoadTenants();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try 
            {
                var row = gridView1.GetFocusedRow();
                if (row == null) return;
            
                var prop = row.GetType().GetProperty("TenantId");
                if (prop == null) return;

                int id = (int)prop.GetValue(row, null);

                if (MessageBox.Show("Kiracı sözleşmesini sonlandırmak (silmek) istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _uow.Tenants.Delete(id);
                    _uow.Save(); // Persist the deletion
                    LoadTenants();
                }
            } 
            catch (Exception ex) 
            {
                 MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message);
            }
        }

        private void UCKiracilar_Load(object sender, EventArgs e)
        {

        }
    }
}
