using AVM.Business;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class UCExpenses : XtraUserControl
    {
        private ExpenseManager _manager;
        
        // UI
        private LayoutControl layoutControl;
        private GridControl gridExpenses;
        private GridView gridView1;
        private SimpleButton btnAdd;

        public UCExpenses()
        {
            InitializeComponent();
            _manager = new ExpenseManager();
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            layoutControl = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layoutControl);

            gridExpenses = new GridControl();
            gridView1 = new GridView(gridExpenses);
            gridExpenses.MainView = gridView1;
            
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsFind.AlwaysVisible = true;
            gridView1.OptionsFind.FindNullPrompt = "Ara...";
            gridView1.OptionsFind.ShowFindButton = false;
            gridView1.OptionsFind.ShowClearButton = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            
            // Vibrant Style -> Pale Gray Style
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240); // Pale Gray
            gridView1.Appearance.HeaderPanel.ForeColor = Color.Black; // Black Text
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Bold
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            
            gridView1.Appearance.Row.BackColor = Color.White;
            gridView1.Appearance.Row.BackColor2 = Color.FromArgb(245, 245, 247); // Light gray stripe
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 10);
            gridView1.RowHeight = 35;
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(52, 152, 219);
            gridView1.Appearance.FocusedRow.ForeColor = Color.White;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;

            btnAdd = new SimpleButton { Text = "Gider Ekle" };
            btnAdd.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png");
            btnAdd.Click += BtnAdd_Click;

            LayoutControlGroup root = layoutControl.Root;
            root.GroupBordersVisible = false;

            // 1. Add Buttons (Side by Side)
            LayoutControlItem itemAdd = root.AddItem("Add", btnAdd);
            itemAdd.TextVisible = false;
            
            // 2. Add Grid (Below Buttons)
            LayoutControlItem itemGrid = root.AddItem("Grid", gridExpenses);
            itemGrid.TextVisible = false;
            itemGrid.Move(itemAdd, DevExpress.XtraLayout.Utils.InsertType.Bottom);

            // 3. Add Empty Space to Right of buttons (Detailed Layout adjustment)
            DevExpress.XtraLayout.EmptySpaceItem emptySpace = new DevExpress.XtraLayout.EmptySpaceItem();
            root.AddItem(emptySpace, itemAdd, DevExpress.XtraLayout.Utils.InsertType.Right);
        }

        private void LoadData()
        {
            gridExpenses.DataSource = _manager.GetAllExpensesDetailed();
            gridView1.PopulateColumns();

            gridView1.Appearance.Row.ForeColor = Color.Black; 
            gridView1.Appearance.Row.Options.UseForeColor = true;

            if (gridView1.Columns["ExpenseId"] != null) gridView1.Columns["ExpenseId"].Visible = false;
            if (gridView1.Columns["RawDate"] != null) gridView1.Columns["RawDate"].Visible = false;
            
            if(gridView1.Columns["Amount"] != null) 
            {
                gridView1.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["Amount"].DisplayFormat.FormatString = "c2";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ExpenseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void UCExpenses_Load(object sender, EventArgs e)
        {

        }
    }
}
