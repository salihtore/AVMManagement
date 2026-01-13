using AVM.Business;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AVM.UI
{
    public partial class UCPersonnel : DevExpress.XtraEditors.XtraUserControl
    {
        private PersonnelManager _manager;

        public UCPersonnel()
        {
            try {
                InitializeComponent();
                _manager = new PersonnelManager();
                LoadData();

                // Grid Styling
                gridView.OptionsBehavior.Editable = false;
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.Appearance.Row.BackColor = Color.White;
                gridView.Appearance.Row.ForeColor = Color.Black; // FORCE READABILITY
                gridView.Appearance.Row.Options.UseForeColor = true;
                gridView.Appearance.Row.BackColor2 = Color.FromArgb(245, 245, 247);
                
                // Font Adjustment
                gridView.Appearance.Row.Font = new Font("Segoe UI", 8.25F);
                
                // Header Styling: Black Bold Text, Pale Gray Background
                gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 240, 240);
                gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
                gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
                gridView.Appearance.HeaderPanel.Options.UseForeColor = true;

                gridView.OptionsView.EnableAppearanceEvenRow = true;
                gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
                gridView.OptionsView.ShowIndicator = false;

                // Button Styling (Safe runtime update)
                btnAdd.Height = 45;
                btnEdit.Height = 45;
                btnDelete.Height = 45;
            } catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("Personel Formu yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                gridControl.DataSource = _manager.GetAllEmployees();
                gridView.PopulateColumns();

                if (gridView.Columns["Salary"] != null)
                {
                    gridView.Columns["Salary"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView.Columns["Salary"].DisplayFormat.FormatString = "c2";
                }
                
                gridView.BestFitColumns();
            }
            catch (Exception ex)
            {
                // Log or silently fail to prevent crash
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new PersonnelEditForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try 
            {
                var row = gridView.GetFocusedRow();
                var emp = row as AVM.Core.Entities.Employee;

                if (emp == null) return;
                
                int id = emp.EmployeeId;

                using (var form = new PersonnelEditForm(id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
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
                var emp = row as AVM.Core.Entities.Employee;

                if (emp == null) return;

                int id = emp.EmployeeId;

                if (XtraMessageBox.Show("Bu personeli silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _manager.DeleteEmployee(id);
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
