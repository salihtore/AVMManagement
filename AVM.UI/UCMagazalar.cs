using AVM.Core.Entities;
using AVM.DataAccess;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class UCMagazalar : XtraUserControl
    {
        private UnitOfWork _uow;
        
        // UI Controls
        private LayoutControl layoutControl;
        private GridControl gridStores;
        private TileView tileView1;
        private SimpleButton btnAdd;
        private SimpleButton btnEdit;
        private SimpleButton btnDelete;
        private SimpleButton btnRentHistory;

        public UCMagazalar()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            InitializeStoreUI();
            LoadStores();
        }

        private void InitializeStoreUI()
        {
            layoutControl = new LayoutControl();
            layoutControl.Dock = DockStyle.Fill;
            this.Controls.Add(layoutControl);

            gridStores = new GridControl();
            tileView1 = new TileView(gridStores);
            gridStores.MainView = tileView1;
            
            // --- Tile Settings ---
            tileView1.OptionsTiles.ItemSize = new Size(280, 150);
            tileView1.OptionsTiles.LayoutMode = TileViewLayoutMode.Default; 
            tileView1.OptionsTiles.Orientation = Orientation.Vertical;
            tileView1.OptionsTiles.RowCount = 0; 
            tileView1.OptionsTiles.Padding = new Padding(20);
            tileView1.OptionsTiles.IndentBetweenItems = 20;
            tileView1.OptionsTiles.IndentBetweenItems = 20;
            
            // Search Localization
            tileView1.OptionsFind.AlwaysVisible = true; 
            tileView1.OptionsFind.FindNullPrompt = "Mağaza Ara...";
            tileView1.OptionsFind.ShowFindButton = false;
            tileView1.OptionsFind.ShowClearButton = false;
            
            // Background
            tileView1.Appearance.EmptySpace.BackColor = Color.FromArgb(236, 240, 241); // Clouds
            
            // Item Appearance (The Card)
            tileView1.Appearance.ItemNormal.BackColor = Color.White;
            tileView1.Appearance.ItemNormal.BorderColor = Color.Gainsboro;
            tileView1.Appearance.ItemNormal.ForeColor = Color.Black;
            
            // Columns
            tileView1.Columns.AddVisible("StoreName", "Mağaza Adı");
            tileView1.Columns.AddVisible("StoreCode", "Kod");
            tileView1.Columns.AddVisible("Category", "Kategori");

            SetupColorfulTileTemplate();

            // --- VISIBLE Buttons ---
            // We use 'Standard' paint style to make sure background color IS visible.
            btnAdd = CreateVisibleButton("Yeni Mağaza", Color.FromArgb(46, 204, 113)); // Emerald Green
            btnAdd.Click += BtnAdd_Click;

            btnEdit = CreateVisibleButton("Düzenle", Color.FromArgb(52, 152, 219)); // Peter River Blue
            btnEdit.Click += BtnEdit_Click;

            btnDelete = CreateVisibleButton("Sil", Color.FromArgb(231, 76, 60)); // Alizarin Red
            btnDelete.Click += BtnDelete_Click;

            btnRentHistory = CreateVisibleButton("Kira Geçmişi", Color.FromArgb(142, 68, 173)); // Wisteria Purple
            btnRentHistory.Click += BtnRentHistory_Click;

            // Layout
            LayoutControlGroup root = layoutControl.Root;
            root.GroupBordersVisible = false;
            root.Padding = new DevExpress.XtraLayout.Utils.Padding(25, 25, 25, 25);

            // Header Group
            LayoutControlGroup headerGroup = root.AddGroup();
            headerGroup.GroupBordersVisible = false;
            headerGroup.TextVisible = false;
            
            LabelControl lblTitle = new LabelControl();
            lblTitle.Text = "Mağazalar";
            lblTitle.Appearance.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(44, 62, 80);
            LayoutControlItem itemTitle = headerGroup.AddItem("Title", lblTitle);
            itemTitle.TextVisible = false;
            itemTitle.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;

            EmptySpaceItem spacer = new EmptySpaceItem();
            headerGroup.AddItem(spacer).Move(itemTitle, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemAdd = headerGroup.AddItem("Add", btnAdd);
            ConfigureButtonLayout(itemAdd);
            itemAdd.Move(spacer, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemEdit = headerGroup.AddItem("Edit", btnEdit);
            ConfigureButtonLayout(itemEdit);
            itemEdit.Move(itemAdd, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemDelete = headerGroup.AddItem("Delete", btnDelete);
            ConfigureButtonLayout(itemDelete);
            itemDelete.Move(itemEdit, DevExpress.XtraLayout.Utils.InsertType.Right);

            LayoutControlItem itemHistory = headerGroup.AddItem("History", btnRentHistory);
            ConfigureButtonLayout(itemHistory);
            itemHistory.Move(itemDelete, DevExpress.XtraLayout.Utils.InsertType.Right);

            // Grid
            LayoutControlItem itemGrid = root.AddItem("Grid", gridStores);
            itemGrid.TextVisible = false;
        }

        private SimpleButton CreateVisibleButton(string text, Color backColor)
        {
            SimpleButton btn = new SimpleButton();
            btn.Text = text;
            btn.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Appearance.ForeColor = Color.White;
            btn.Appearance.Options.UseForeColor = true;
            
            // Critical for visibility
            btn.Appearance.BackColor = backColor;
            btn.Appearance.Options.UseBackColor = true;
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat; // Solid flat color
            btn.LookAndFeel.UseDefaultLookAndFeel = false; // Force custom colors
            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            
            return btn;
        }

        private void ConfigureButtonLayout(LayoutControlItem item)
        {
            item.TextVisible = false;
            item.SizeConstraintsType = SizeConstraintsType.Custom;
            item.MaxSize = new Size(130, 45); // Slightly larger
            item.MinSize = new Size(130, 45);
            item.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5); // Gap between buttons
        }

        private void SetupColorfulTileTemplate()
        {
            // 1. Decorative Left Strip (Accent Color)
            // Using a text element with width and background color to simulate a strip
            TileViewItemElement stripElement = new TileViewItemElement();
            stripElement.StretchVertical = true;
            stripElement.Width = 8;
            stripElement.TextAlignment = TileItemContentAlignment.MiddleLeft;
            stripElement.Appearance.Normal.BackColor = Color.FromArgb(52, 152, 219); // Blue strip for all, or dynamic based on cat
            
            // 2. Badge (Store Code) - More vibrant
            TileViewItemElement codeElement = new TileViewItemElement();
            codeElement.Column = tileView1.Columns["StoreCode"];
            codeElement.TextAlignment = TileItemContentAlignment.TopRight;
            codeElement.Appearance.Normal.Font = new Font("Consolas", 10, FontStyle.Bold);
            codeElement.Appearance.Normal.ForeColor = Color.White;
            codeElement.Appearance.Normal.BackColor = Color.FromArgb(230, 126, 34); // Pumpkin Orange
            codeElement.StretchHorizontal = false;
            codeElement.Width = 70;
            codeElement.TextLocation = new Point(-10, 10); // Offset padding

            // 3. Name (Big & Bold)
            TileViewItemElement nameElement = new TileViewItemElement();
            nameElement.Column = tileView1.Columns["StoreName"];
            nameElement.TextAlignment = TileItemContentAlignment.MiddleCenter;
            nameElement.Appearance.Normal.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            nameElement.Appearance.Normal.ForeColor = Color.FromArgb(44, 62, 80);
            
            // 4. Category (Subtle)
            TileViewItemElement catElement = new TileViewItemElement();
            catElement.Column = tileView1.Columns["Category"];
            catElement.TextAlignment = TileItemContentAlignment.BottomCenter;
            catElement.Appearance.Normal.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            catElement.Appearance.Normal.ForeColor = Color.Gray;
            catElement.TextLocation = new Point(0, -10);

            tileView1.TileTemplate.Add(stripElement);
            tileView1.TileTemplate.Add(codeElement);
            tileView1.TileTemplate.Add(nameElement);
            tileView1.TileTemplate.Add(catElement);
            tileView1.ItemDoubleClick += TileView1_ItemDoubleClick;
        }

        private void TileView1_ItemDoubleClick(object sender, TileViewItemClickEventArgs e)
        {
            BtnEdit_Click(null, null);
        }

        private void LoadStores()
        {
            var list = _uow.Stores.GetAll().ToList();
            gridStores.DataSource = list;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new MagazaEkleForm())
            {
                if (f.ShowDialog() == DialogResult.OK) LoadStores();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var store = tileView1.GetFocusedRow() as Store;
            if (store == null) return;
            using (var f = new MagazaDuzenleForm(store))
                if (f.ShowDialog() == DialogResult.OK) LoadStores();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var store = tileView1.GetFocusedRow() as Store;
                if (store == null) return;
                
                if (MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _uow.Stores.Delete(store.StoreId);
                    _uow.Save(); // Persist deletion
                    LoadStores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnRentHistory_Click(object sender, EventArgs e)
        {
            var store = tileView1.GetFocusedRow() as Store;
            if (store == null) return;

            using (var f = new StoreRentHistoryForm(store.StoreId, store.StoreName))
            {
                f.ShowDialog();
            }
        }

        private void UCMagazalar_Load(object sender, EventArgs e)
        {

        }
    }
}
