using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCTurnover : XtraUserControl
    {
        private TurnoverManager _manager;
        private int _storeId;

        // UI Controls
        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private SimpleButton btnAdd;
        private DateEdit dateEdit;
        private TextEdit txtAmount;
        private GroupControl groupInput;

        public UCTurnover(int storeId)
        {
            InitializeComponent();
            _storeId = storeId;
            _manager = new TurnoverManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupInput = new GroupControl();
            this.btnAdd = new SimpleButton();
            this.dateEdit = new DateEdit();
            this.txtAmount = new TextEdit();
            LabelControl lblDate = new LabelControl();
            LabelControl lblAmount = new LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).BeginInit();
            this.groupInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            this.SuspendLayout();

            // Group Layout
            this.groupInput.Text = "Ciro Girişi";
            this.groupInput.Dock = DockStyle.Top;
            this.groupInput.Height = 120;

            lblDate.Text = "Tarih:";
            lblDate.Location = new Point(20, 35);
            this.groupInput.Controls.Add(lblDate);

            this.dateEdit.DateTime = DateTime.Today;
            this.dateEdit.Location = new Point(80, 32);
            this.dateEdit.Width = 150;
            this.groupInput.Controls.Add(this.dateEdit);

            lblAmount.Text = "Tutar:";
            lblAmount.Location = new Point(20, 65);
            this.groupInput.Controls.Add(lblAmount);

            this.txtAmount.Location = new Point(80, 62);
            this.txtAmount.Width = 150;
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Properties.Mask.EditMask = "c2";
            this.groupInput.Controls.Add(this.txtAmount);

            this.btnAdd.Text = "Ciro Bildir";
            this.btnAdd.Location = new Point(80, 90);
            this.btnAdd.Width = 150;
            this.btnAdd.Click += BtnAdd_Click;
            this.groupInput.Controls.Add(this.btnAdd);

            // Grid
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            
            // Grid Styling
            this.gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            this.gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            this.gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new Font("Segoe UI", 9);
            this.gridView.Appearance.Row.ForeColor = Color.Black;
            this.gridView.Appearance.Row.Options.UseForeColor = true;

            // Form
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupInput);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).EndInit();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetTurnoversByStore(_storeId);
            gridView.PopulateColumns();
            if(gridView.Columns["TurnoverId"] != null) gridView.Columns["TurnoverId"].Visible = false;
             if(gridView.Columns["StoreId"] != null) gridView.Columns["StoreId"].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount;
                if(!decimal.TryParse(txtAmount.Text.Replace("₺","").Trim(), out amount))
                {
                     XtraMessageBox.Show("Lütfen geçerli bir tutar giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                }

                Turnover t = new Turnover()
                {
                    StoreId = _storeId,
                    Date = dateEdit.DateTime,
                    Amount = amount,
                    CreatedAt = DateTime.Now
                };

                _manager.AddTurnover(t);
                LoadData();
                XtraMessageBox.Show("Ciro başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Text = "";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
