using AVM.Core.Entities;
using AVM.DataAccess;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class KiraciDuzenleForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly UnitOfWork _uow;
        private readonly Tenant _tenant;

        public KiraciDuzenleForm(Tenant tenant)
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            _tenant = tenant;
            LoadStores();
            LoadTenant();
        }
        private void LoadTenant()
        {
            txtCompanyName.Text = _tenant.CompanyName;
            txtContactName.Text = _tenant.ContactName;
            txtPhone.Text = _tenant.ContactPhone;
            chkStatus.Checked = _tenant.Status;
            if (_tenant.StoreId.HasValue)
                cmbStore.EditValue = _tenant.StoreId.Value;
            else
                cmbStore.EditValue = null;
        }
        private void LoadStores()
        {
            var stores = _uow.Stores.GetAll().ToList();

            cmbStore.Properties.DataSource = stores;
            cmbStore.Properties.DisplayMember = "StoreName"; // sende neyse onu yaz
            cmbStore.Properties.ValueMember = "StoreId";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                XtraMessageBox.Show("Firma adı zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _tenant.CompanyName = txtCompanyName.Text.Trim();
                _tenant.ContactName = txtContactName.Text.Trim();
                _tenant.ContactPhone = txtPhone.Text.Trim();
                _tenant.Status = chkStatus.Checked;

                _tenant.StoreId = cmbStore.EditValue == null
                    ? (int?)null
                    : Convert.ToInt32(cmbStore.EditValue);

                _uow.Tenants.Update(_tenant);
                _uow.Save();





                XtraMessageBox.Show("Kiracı güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}