using AVM.Core.Entities;
using AVM.DataAccess;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class KiraciEkleForm : XtraForm
    {
        private readonly UnitOfWork _uow;

        public KiraciEkleForm()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                XtraMessageBox.Show("Firma adı zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStore.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen bir mağaza seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tenant = new Tenant
            {
                CompanyName = txtCompanyName.Text.Trim(),
                ContactName = txtContactName.Text.Trim(),
                ContactPhone = txtPhone.Text.Trim(),
                Status = chkStatus.Checked,
                StoreId = cmbStore.EditValue != null ? (int?)Convert.ToInt32(cmbStore.EditValue) : null
            };

            try
            {
                _uow.Tenants.Add(tenant);
                _uow.Save();

                XtraMessageBox.Show("Kiracı başarıyla eklendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Exception current = ex;
                string msg = "";

                while (current != null)
                {
                    msg += current.GetType().Name + ":\n";
                    msg += current.Message + "\n\n";
                    current = current.InnerException;
                }

                XtraMessageBox.Show(msg, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void KiraciEkleForm_Load(object sender, EventArgs e)
        {
            LoadStores();
        }

        private void LoadStores()
        {
            try {
                var stores = _uow.Stores.GetAll().ToList();
                cmbStore.Properties.DataSource = stores;
                cmbStore.Properties.DisplayMember = "StoreName";
                cmbStore.Properties.ValueMember = "StoreId";
                
                // Add "Select Store" prompt (NullText handles visual, but data binding needs care)
                cmbStore.Properties.Columns.Clear();
                cmbStore.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreName", "Mağaza Adı"));
                cmbStore.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreCode", "Kod"));
            } catch (Exception ex) {
                 System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
