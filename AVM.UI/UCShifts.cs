using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCShifts : XtraUserControl
    {
        private ShiftManager _manager;
        private int _employeeId;

        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;


        public UCShifts(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            _manager = new ShiftManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            // LayoutControl removed for simplicity
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();


            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();

            // Grid
            this.gridControl.MainView = this.gridView;
            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            
             // Styling
            this.gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            this.gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            this.gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new Font("Segoe UI", 9);
            this.gridView.Appearance.Row.ForeColor = Color.Black;
            this.gridView.Appearance.Row.Options.UseForeColor = true;


            // Grid Docking
            this.gridControl.Dock = DockStyle.Fill;
            this.Controls.Add(gridControl);


            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetShiftsByEmployee(_employeeId);
            gridView.PopulateColumns();
            if(gridView.Columns["ShiftId"] != null) gridView.Columns["ShiftId"].Visible = false;
            if(gridView.Columns["EmployeeId"] != null) gridView.Columns["EmployeeId"].Visible = false;
            gridView.BestFitColumns();
        }
    }
}
