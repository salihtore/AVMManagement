using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class ExpenseForm : XtraForm
    {
        private ExpenseManager _manager;

        // Controls
        private LayoutControl layoutControl;
        private LookUpEdit cmbCategory;
        private SpinEdit txtAmount;
        private DateEdit txtDate;
        private MemoEdit txtDescription;
        private SimpleButton btnSave;
        private SimpleButton btnCancel;

        public ExpenseForm()
        {
            InitializeComponent();
            _manager = new ExpenseManager();
            InitializeFormUI();
        }

        private void InitializeFormUI()
        {
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterParent;

            layoutControl = new LayoutControl { Dock = DockStyle.Fill };
            this.Controls.Add(layoutControl);

            // Category Combo
            cmbCategory = new LookUpEdit();
            cmbCategory.Properties.DataSource = _manager.GetCategories();
            cmbCategory.Properties.DisplayMember = "CategoryName";
            cmbCategory.Properties.ValueMember = "ExpenseCategoryId";
            cmbCategory.Properties.NullText = "Kategori Seçiniz";

            // Amount
            txtAmount = new SpinEdit();
            txtAmount.Properties.Mask.EditMask = "c2";
            txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            
            // Date
            txtDate = new DateEdit();
            txtDate.DateTime = DateTime.Now;

            // Description
            txtDescription = new MemoEdit();

            // Buttons
            btnSave = new SimpleButton { Text = "Kaydet" };
            btnSave.Click += BtnSave_Click;

            btnCancel = new SimpleButton { Text = "İptal" };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; };

            // Layout Items
            LayoutControlGroup root = layoutControl.Root;
            root.GroupBordersVisible = false;

            root.AddItem("Kategori:", cmbCategory);
            root.AddItem("Tutar:", txtAmount);
            root.AddItem("Tarih:", txtDate);
            root.AddItem("Açıklama:", txtDescription);

            LayoutControlItem itemSave = root.AddItem("Save", btnSave);
            itemSave.TextVisible = false;
            
            LayoutControlItem itemCancel = root.AddItem("Cancel", btnCancel);
            itemCancel.TextVisible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.EditValue == null)
                {
                    MessageBox.Show("Lütfen kategori seçiniz.");
                    return;
                }

                if (txtAmount.Value <= 0)
                {
                    MessageBox.Show("Tutar 0'dan büyük olmalıdır.");
                    return;
                }

                int categoryId = (int)cmbCategory.EditValue;
                decimal amount = txtAmount.Value;
                DateTime date = txtDate.DateTime;
                string desc = txtDescription.Text;

                _manager.AddExpense(categoryId, amount, date, desc);
                
                MessageBox.Show("Gider kaydedildi.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
