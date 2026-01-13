using System;
using System.Windows.Forms;
using AVM.DataAccess;
using AVM.Core.Entities;   // 🔥 DOĞRU NAMESPACE

namespace AVM.UI
{
    public partial class MagazaEkleForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly UnitOfWork _uow;

        public MagazaEkleForm()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtStoreName.Text.Trim();
            var code = txtStoreCode.Text.Trim();
            var category = cmbCategory.Text;
            var floor = Convert.ToInt32(numFloorNumber.Value);
            var area = numSquareMeter.Value;
            var desc = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Mağaza adı boş olamaz.");
                return;
            }

            try
            {
                var store = new Store
                {
                    StoreName = name,
                    StoreCode = code,
                    Category = category,
                    FloorNumber = floor,
                    SquareMeter = area,
                    Description = desc,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                _uow.Stores.Add(store);
                _uow.Save(); // Persist changes
               
                MessageBox.Show("Mağaza başarıyla eklendi.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
