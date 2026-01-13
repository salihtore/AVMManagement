using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCAdminServiceRequests : XtraUserControl
    {
        private ServiceRequestManager _manager;
        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private SimpleButton btnResolve;
        private PanelControl pnlTop;

        public UCAdminServiceRequests()
        {
            InitializeComponent();
            _manager = new ServiceRequestManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop = new PanelControl();
            this.btnResolve = new SimpleButton { Text = "Çözüldü Olarak İşaretle", BackColor = Color.LightGreen };

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // Panel
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Height = 60;

            this.btnResolve.Location = new Point(20, 15);
            this.btnResolve.Width = 150;
            this.btnResolve.Click += BtnResolve_Click;
            this.pnlTop.Controls.Add(this.btnResolve);

            // Grid
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsView.ShowGroupPanel = true;
            this.gridView.GroupPanelText = "Talepleri gruplamak için sütun başlığını buraya sürükleyin";
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
            try
            {
                var list = _manager.GetAllRequestsDetailed();
                gridControl.DataSource = list;
                gridView.PopulateColumns();
                gridView.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Veri yüklenirken hata: " + ex.Message);
            }
        }

        private void BtnResolve_Click(object sender, EventArgs e)
        {
            // We use dynamic object in grid, need to get property safely
            // But DevExpress GridView.GetFocusedRow() returns the underlying object
            // If it's anonymous type, accessing property via reflection or dynamic is needed
            
            var row = gridView.GetFocusedRow();
            if (row == null) return;

            try 
            {
                // Access 'RequestId' property via dynamic
                dynamic selectedItem = row;
                int reqId = selectedItem.RequestId;

                if (XtraMessageBox.Show("Bu talebi çözüldü olarak işaretlemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _manager.UpdateStatus(reqId, "Resolved");
                    LoadData();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("İşlem hatası: " + ex.Message);
            }
        }
    }
}
