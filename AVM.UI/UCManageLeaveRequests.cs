using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCManageLeaveRequests : XtraUserControl
    {
        private LeaveRequestManager _manager;
        private int _storeId;

        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private SimpleButton btnApprove;
        private SimpleButton btnReject;
        private PanelControl pnlTop;

        public UCManageLeaveRequests(int storeId)
        {
            InitializeComponent();
            _storeId = storeId;
            _manager = new LeaveRequestManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop = new PanelControl();
            this.btnApprove = new SimpleButton { Text = "Onayla", BackColor = Color.LightGreen };
            this.btnReject = new SimpleButton { Text = "Reddet", BackColor = Color.LightPink };

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // Panel
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;

            this.btnApprove.Location = new Point(20, 15);
            this.btnApprove.Width = 100;
            this.btnApprove.Click += BtnApprove_Click;
            this.pnlTop.Controls.Add(this.btnApprove);

            this.btnReject.Location = new Point(140, 15);
            this.btnReject.Width = 100;
            this.btnReject.Click += BtnReject_Click;
            this.pnlTop.Controls.Add(this.btnReject);

            // Grid
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsBehavior.Editable = false;

            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlTop);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            // Fetch requests for this store
            var list = _manager.GetRequestsByStore(_storeId);
            gridControl.DataSource = list;
            
            gridView.PopulateColumns();
            if(gridView.Columns["LeaveId"] != null) gridView.Columns["LeaveId"].Visible = false;
            if(gridView.Columns["EmployeeId"] != null) gridView.Columns["EmployeeId"].Visible = false;
            if(gridView.Columns["Employee"] != null) gridView.Columns["Employee"].Visible = false; // Hide object
            
            // Add custom column for Employee Name if not present, but Grid might show `Employee` string by default.
            // Better to show Employee.FullName.
            // Since we can't easily configure nested columns in code-behind blindly, 
            // we'll rely on gridView automatically handling it or we might miss the name.
            // If Grid doesn't show nested props, we might need a DTO or manually add column.
            // For now, let's see what it shows.
            
            gridView.BestFitColumns();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as LeaveRequest;
            if (row == null) return;

            if (XtraMessageBox.Show("Bu talebi onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _manager.UpdateStatus(row.LeaveId, "Approved");
                LoadData();
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as LeaveRequest;
            if (row == null) return;

            string reason = XtraInputBox.Show("Red sebebi giriniz:", "Reddet", "");
            if (!string.IsNullOrEmpty(reason))
            {
                _manager.UpdateStatus(row.LeaveId, "Rejected", reason);
                LoadData();
            }
        }
    }
}
