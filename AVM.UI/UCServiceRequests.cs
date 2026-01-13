using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCServiceRequests : XtraUserControl
    {
        private ServiceRequestManager _manager;
        private int _storeId;

        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private ComboBoxEdit cmbType;
        private MemoEdit memDescription;
        private SimpleButton btnSend;
        private GroupControl groupInput;

        public UCServiceRequests(int storeId)
        {
            InitializeComponent();
            _storeId = storeId;
            _manager = new ServiceRequestManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupInput = new GroupControl();
            this.cmbType = new ComboBoxEdit();
            this.memDescription = new MemoEdit();
            this.btnSend = new SimpleButton { Text = "Talep Oluştur" };

            LabelControl lblType = new LabelControl();
            LabelControl lblDesc = new LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).BeginInit();
            this.groupInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
            this.SuspendLayout();

            // Group Layout
            this.groupInput.Text = "Yeni Destek Talebi";
            this.groupInput.Dock = DockStyle.Top;
            this.groupInput.Height = 170;

            lblType.Text = "Talep Türü:";
            lblType.Location = new Point(20, 35);
            this.groupInput.Controls.Add(lblType);

            this.cmbType.Location = new Point(120, 32);
            this.cmbType.Width = 200;
            this.cmbType.Properties.Items.AddRange(new object[] { "Elektrik", "Mekanik", "Temizlik", "Güvenlik", "Diğer" });
            this.cmbType.SelectedIndex = 0;
            this.groupInput.Controls.Add(this.cmbType);

            lblDesc.Text = "Açıklama:";
            lblDesc.Location = new Point(20, 65);
            this.groupInput.Controls.Add(lblDesc);

            this.memDescription.Location = new Point(120, 62);
            this.memDescription.Size = new Size(300, 60);
            this.groupInput.Controls.Add(this.memDescription);

            this.btnSend.Location = new Point(120, 130);
            this.btnSend.Width = 150;
            this.btnSend.Click += BtnSend_Click;
            this.groupInput.Controls.Add(this.btnSend);

            // Grid
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
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

            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupInput);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).EndInit();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetRequestsByStore(_storeId);
            gridView.PopulateColumns();
            if(gridView.Columns["RequestId"] != null) gridView.Columns["RequestId"].Visible = false;
            if(gridView.Columns["StoreId"] != null) gridView.Columns["StoreId"].Visible = false;
            gridView.BestFitColumns();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceRequest req = new ServiceRequest
                {
                    StoreId = _storeId,
                    RequestType = cmbType.Text,
                    Description = memDescription.Text,
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                };

                _manager.AddRequest(req);
                LoadData();
                memDescription.Text = "";
                XtraMessageBox.Show("Talep oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
