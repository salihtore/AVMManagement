using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCTasks : XtraUserControl
    {
        private TaskManager _manager;
        private int _employeeId;
        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private SimpleButton btnComplete;
        private PanelControl pnlBottom;

        public UCTasks(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            _manager = new TaskManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnComplete = new SimpleButton();
            this.pnlBottom = new PanelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // gridControl
            // 
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView });

            // 
            // gridView
            // 
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

            // 
            // btnComplete
            // 
            this.btnComplete.Text = "Görevi Tamamla";
            this.btnComplete.Appearance.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            this.btnComplete.Dock = DockStyle.Right;
            this.btnComplete.Width = 150;
            this.btnComplete.Click += BtnComplete_Click;

            // 
            // pnlBottom
            // 
            this.pnlBottom.Height = 50;
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Controls.Add(this.btnComplete);
            
            // 
            // Controls
            // 
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlBottom);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetTasksByEmployee(_employeeId);
            gridView.PopulateColumns();
            if(gridView.Columns["TaskId"] != null) gridView.Columns["TaskId"].Visible = false;
            if(gridView.Columns["EmployeeId"] != null) gridView.Columns["EmployeeId"].Visible = false;
            gridView.BestFitColumns();
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            var task = gridView.GetFocusedRow() as AVM.Core.Entities.EmployeeTask;
            if(task != null && !task.IsCompleted)
            {
                 if(XtraMessageBox.Show("Görevi tamamladınız mı?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     _manager.CompleteTask(task.TaskId);
                     LoadData();
                 }
            }
        }
    }
}
