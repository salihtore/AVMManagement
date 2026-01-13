using AVM.Business;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class PaymentForm : XtraForm
    {
        private int _rentId;
        private RentManager _rentManager;

        private LayoutControl layoutControl;
        private TextEdit txtTenant;
        private SpinEdit txtAmount;
        private ComboBoxEdit cmbType;
        private MemoEdit txtDescription;
        private SimpleButton btnSave;
        private SimpleButton btnCancel;

        private decimal _remainingAmount;

        public PaymentForm(int rentId, string tenantName, decimal remainingAmount)
        {
            InitializeComponent();
            _rentId = rentId;
            _rentManager = new RentManager();

            _remainingAmount = remainingAmount;
            InitializeFormUI(tenantName, remainingAmount);
        }

        private void InitializeFormUI(string tenantName, decimal amount)
        {
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterParent;

            layoutControl = new LayoutControl();
            layoutControl.Dock = DockStyle.Fill;
            this.Controls.Add(layoutControl);

            txtTenant = new TextEdit();
            txtTenant.Text = tenantName;
            txtTenant.Properties.ReadOnly = true;

            txtAmount = new SpinEdit();
            txtAmount.Properties.Mask.EditMask = "c2";
            txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtAmount.Value = amount;

            cmbType = new ComboBoxEdit();
            cmbType.Properties.Items.Add("Nakit");
            cmbType.Properties.Items.Add("Banka Havalesi");
            cmbType.Properties.Items.Add("Kredi Kartı");
            cmbType.SelectedIndex = 1;

            txtDescription = new MemoEdit();

            btnSave = new SimpleButton();
            btnSave.Text = "Ödemeyi Kaydet";
            btnSave.Click += BtnSave_Click;

            btnCancel = new SimpleButton();
            btnCancel.Text = "İptal";
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            LayoutControlGroup root = layoutControl.Root;
            root.GroupBordersVisible = false;
            
            root.AddItem("Kiracı:", txtTenant);
            root.AddItem("Tutar:", txtAmount);
            root.AddItem("Ödeme Tipi:", cmbType);
            root.AddItem("Açıklama:", txtDescription);

            LayoutControlGroup buttons = root.AddGroup();
            buttons.GroupBordersVisible = false;
            buttons.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            // Simplified button layout or standard
            // Let's just add them as regular items side by side
            
            // Re-doing button layout clearer
            LayoutControlItem itemSave = root.AddItem("Save", btnSave);
            itemSave.TextVisible = false;
            
            LayoutControlItem itemCancel = root.AddItem("Cancel", btnCancel);
            itemCancel.TextVisible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = txtAmount.Value;
                string type = cmbType.Text;
                string desc = txtDescription.Text;

                if (amount <= 0)
                {
                    MessageBox.Show("Tutar 0'dan büyük olmalıdır.");
                    return;
                }

                if (amount > _remainingAmount)
                {
                    MessageBox.Show($"Tutar, kalan borç tutarından ({_remainingAmount:C2}) fazla olamaz.");
                    return;
                }

                _rentManager.MakePayment(_rentId, amount, type, desc);

                MessageBox.Show("Ödeme başarıyla alındı.");
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
