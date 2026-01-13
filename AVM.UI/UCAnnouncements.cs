using AVM.Business;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class UCAnnouncements : DevExpress.XtraEditors.XtraUserControl
    {
        private CommunicationManager _manager;

        public UCAnnouncements()
        {
            InitializeComponent();
            _manager = new CommunicationManager();
            LoadData();

            // Styling
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
            gridView.RowHeight = 35;
            
            // Search is requested to be hidden for Announcements? No, user said "add search to all EXCEPT personnel and announcements".
            // So we skip enabling search here, but we still apply colors.
            
            // Vibrant Style -> Pale Gray Style
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; // Added based on original gridView settings
            
            gridView.Appearance.Row.BackColor = Color.White;
            gridView.Appearance.Row.ForeColor = Color.Black; // FORCE READABILITY
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.BackColor2 = Color.FromArgb(245, 245, 247);
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.Appearance.Row.Font = new Font("Segoe UI", 10);
            gridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; // Added based on original gridView settings
            
            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(52, 152, 219);
            gridView.Appearance.FocusedRow.ForeColor = Color.White;
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False; // Added based on original gridView settings
            gridView.OptionsView.ColumnAutoWidth = true; // Added based on original gridView settings
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetActiveAnnouncements();
            gridView.PopulateColumns();
            if(gridView.Columns["AnnouncementId"] != null) gridView.Columns["AnnouncementId"].Visible = false;
            if(gridView.Columns["Title"] != null) gridView.Columns["Title"].Caption = "Başlık";
            if(gridView.Columns["Content"] != null) gridView.Columns["Content"].Caption = "İçerik";
            if(gridView.Columns["CreatedAt"] != null) gridView.Columns["CreatedAt"].Caption = "Oluşturulma Tarihi";
            
            gridView.BestFitColumns();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(memContent.Text))
                {
                    XtraMessageBox.Show("Başlık ve içerik zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _manager.SendAnnouncement(txtTitle.Text, memContent.Text);
                XtraMessageBox.Show("Duyuru yayınlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtTitle.Text = "";
                memContent.Text = "";
                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var row = gridView.GetFocusedRow();
                if (row == null) return;

                int id = 0;
                var prop = row.GetType().GetProperty("AnnouncementId");
                if (prop != null)
                {
                     id = (int)prop.GetValue(row, null);
                }
                else
                {
                    XtraMessageBox.Show("Seçili satır verisi okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (XtraMessageBox.Show("Bu duyuruyu silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _manager.DeleteAnnouncement(id);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
