using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCLeaveRequests : XtraUserControl
    {
        private LeaveRequestManager _manager;
        private int _employeeId;

        // UI
        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DateEdit dateStart;
        private DateEdit dateEnd;
        private ComboBoxEdit cmbType;
        private MemoEdit memReason;
        private SimpleButton btnSend;
        private GroupControl groupInput;

        public UCLeaveRequests(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            _manager = new LeaveRequestManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupInput = new GroupControl();
            
            this.dateStart = new DateEdit();
            this.dateEnd = new DateEdit();
            this.cmbType = new ComboBoxEdit();
            this.memReason = new MemoEdit();
            this.btnSend = new SimpleButton { Text = "İzin Talep Et" };

            LabelControl lblType = new LabelControl();
            LabelControl lblStart = new LabelControl();
            LabelControl lblEnd = new LabelControl();
            LabelControl lblReason = new LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).BeginInit();
            this.groupInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memReason.Properties)).BeginInit();
            this.SuspendLayout();

            // Group Layout
            this.groupInput.Text = "Yeni İzin Talebi";
            this.groupInput.Dock = DockStyle.Top;
            this.groupInput.Height = 190;

            lblType.Text = "İzin Türü:";
            lblType.Location = new Point(20, 35);
            this.groupInput.Controls.Add(lblType);
            this.cmbType.Location = new Point(120, 32);
            this.cmbType.Width = 150;
            this.cmbType.Properties.Items.AddRange(new object[] { "Yıllık İzin", "Mazeret", "Hastalık", "Diğer" });
            this.cmbType.SelectedIndex = 0;
            this.groupInput.Controls.Add(this.cmbType);

            lblStart.Text = "Başlangıç:";
            lblStart.Location = new Point(20, 65);
            this.groupInput.Controls.Add(lblStart);
            this.dateStart.Location = new Point(120, 62);
            this.dateStart.Width = 150;
            this.dateStart.DateTime = DateTime.Today;
            this.groupInput.Controls.Add(this.dateStart);

            lblEnd.Text = "Bitiş:";
            lblEnd.Location = new Point(300, 65);
            this.groupInput.Controls.Add(lblEnd);
            this.dateEnd.Location = new Point(350, 62);
            this.dateEnd.Width = 150;
            this.dateEnd.DateTime = DateTime.Today;
            this.groupInput.Controls.Add(this.dateEnd);

            lblReason.Text = "Açıklama / Sebep:";
            lblReason.Location = new Point(20, 95);
            this.groupInput.Controls.Add(lblReason);
            this.memReason.Location = new Point(120, 92);
            this.memReason.Size = new Size(380, 50);
            this.groupInput.Controls.Add(this.memReason);

            this.btnSend.Location = new Point(120, 150);
            this.btnSend.Width = 150;
            this.btnSend.Click += BtnSend_Click;
            this.groupInput.Controls.Add(this.btnSend);


            // Grid Setup
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridView.GridControl = this.gridControl;
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

            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupInput);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).EndInit();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memReason.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetRequestsByEmployee(_employeeId);
            gridView.PopulateColumns();
            if(gridView.Columns["LeaveId"] != null) gridView.Columns["LeaveId"].Visible = false;
            if(gridView.Columns["EmployeeId"] != null) gridView.Columns["EmployeeId"].Visible = false;
            gridView.BestFitColumns();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveRequest req = new LeaveRequest
                {
                    EmployeeId = _employeeId,
                    LeaveType = cmbType.Text,
                    StartDate = dateStart.DateTime,
                    EndDate = dateEnd.DateTime,
                    Reason = memReason.Text,
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                };
                _manager.AddRequest(req);
                LoadData();
                XtraMessageBox.Show("Talep iletildi.", "Başarılı");
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
