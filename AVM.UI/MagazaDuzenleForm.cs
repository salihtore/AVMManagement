using System;
using System.Windows.Forms;
using AVM.Core.Entities;
using AVM.DataAccess;

namespace AVM.UI
{
    public partial class MagazaDuzenleForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly UnitOfWork _uow;
        private readonly Store _store;

        public MagazaDuzenleForm(Store store)
        {
            InitializeComponent();
            _uow = new UnitOfWork();
            _store = store;

            LoadStoreData();
        }

        private void LoadStoreData()
        {
            txtStoreName.Text = _store.StoreName;
            txtFloorNumber.Text = _store.FloorNumber.ToString();
            txtSquareMeter.Text = _store.SquareMeter.ToString();
            txtCategory.Text = _store.Category;
            chkIsActive.Checked = _store.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // basit validasyon
            if (string.IsNullOrWhiteSpace(txtStoreName.Text))
            {
                MessageBox.Show("Mağaza adı boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtFloorNumber.Text, out var floor))
            {
                MessageBox.Show("Kat sayısı geçerli bir sayı olmalı.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSquareMeter.Text, out var sqm))
            {
                MessageBox.Show("Metrekare geçerli bir sayı olmalı.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _store.StoreName = txtStoreName.Text.Trim();
                _store.FloorNumber = floor;
                _store.SquareMeter = sqm;
                _store.Category = txtCategory.Text.Trim();
                _store.IsActive = chkIsActive.Checked;
                _store.UpdatedAt = DateTime.Now;

                _uow.Stores.Update(_store);   // Repository.Update içinde SaveChanges var

                MessageBox.Show("Mağaza başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
