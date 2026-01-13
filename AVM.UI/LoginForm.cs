using AVM.DataAccess;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork _uow;

        public LoginForm()
        {
            InitializeComponent();
            _uow = new UnitOfWork();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                XtraMessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = _uow.Users
                .GetAll()
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

                if (user == null)
                {
                    XtraMessageBox.Show("Kullanıcı adı veya şifre hatalı olabilir.", "Giriş Başarısız",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Role Validation
                if (rdoRole.EditValue == null)
                {
                    XtraMessageBox.Show("Lütfen bir giriş türü seçiniz (Yönetici, Personel, Mağaza).", "Uyarı",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedRoleId = Convert.ToInt32(rdoRole.EditValue);

                if (user.RoleId != selectedRoleId)
                {
                     XtraMessageBox.Show("Seçtiğiniz giriş türü ile kullanıcı yetkiniz uyuşmuyor.", "Yetkisiz Giriş",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                }

                // Removed early welcome message to prevent confusion on error

                if (user.RoleId == 1) // Yönetici
                {
                    XtraMessageBox.Show($"Hoş geldiniz {user.FullName}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var adminForm = new AdminForm();
                    adminForm.FormClosed += (s, args) => { this.Show(); txtPassword.Text = ""; };
                    adminForm.Show();
                }
                else if (user.RoleId == 2) // Personel
                {
                    XtraMessageBox.Show($"Hoş geldiniz {user.FullName}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var personnelForm = new PersonnelForm(user.UserId);
                    personnelForm.FormClosed += (s, args) => { this.Show(); txtPassword.Text = ""; };
                    personnelForm.Show();
                }
                else // Mağaza (Tenant)
                {
                    // Check StoreId
                    if (user.StoreId == null)
                    {
                        XtraMessageBox.Show("Bu kullanıcıya tanımlı bir Mağaza bulunamadı! Lütfen yönetici ile iletişime geçin.", 
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    XtraMessageBox.Show($"Hoş geldiniz {user.FullName}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var tenantForm = new TenantForm(user.StoreId.Value);
                    tenantForm.FormClosed += (s, args) => { this.Show(); txtPassword.Text = ""; };
                    tenantForm.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Giriş sırasında beklenmeyen bir hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Properties.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
