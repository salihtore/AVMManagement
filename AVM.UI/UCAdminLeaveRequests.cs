using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCAdminLeaveRequests : XtraUserControl
    {
        private LeaveRequestManager _manager;
        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private SimpleButton btnApprove;
        private SimpleButton btnReject;
        private PanelControl pnlTop;

        public UCAdminLeaveRequests()
        {
            InitializeComponent();
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
            var list = _manager.GetAVMPersonnelRequests();
            gridControl.DataSource = list;
            
            gridView.PopulateColumns();
            if(gridView.Columns["LeaveId"] != null) gridView.Columns["LeaveId"].Visible = false;
            if(gridView.Columns["EmployeeId"] != null) gridView.Columns["EmployeeId"].Visible = false;
            
            gridView.BestFitColumns();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as LeaveRequest;
            if (row == null) return;

            if (XtraMessageBox.Show("Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
