using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AVM.Business;
using AVM.Core.Entities;
using DevExpress.XtraGrid;

namespace AVM.UI
{
    public partial class UCStorePersonnel : XtraUserControl
    {
        private EmployeeManager _manager;
        private int _storeId;

        private GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private TextEdit txtName;
        private TextEdit txtPosition;
        private TextEdit txtPhone;
        private SimpleButton btnAdd;
        private SimpleButton btnRemove;
        private GroupControl groupInput;

        public UCStorePersonnel(int storeId)
        {
            InitializeComponent();
            _storeId = storeId;
            _manager = new EmployeeManager();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.gridControl = new GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupInput = new GroupControl();
            this.txtName = new TextEdit();
            this.txtPosition = new TextEdit();
            this.txtPhone = new TextEdit();
            this.btnAdd = new SimpleButton { Text = "Personel Ekle" };
            this.btnRemove = new SimpleButton { Text = "Seçileni Çıkar" };
            
            LabelControl lblName = new LabelControl();
            LabelControl lblPos = new LabelControl();
            LabelControl lblPhone = new LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).BeginInit();
            this.groupInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            this.SuspendLayout();

            // Group
            this.groupInput.Text = "Personel Ekle";
            this.groupInput.Dock = DockStyle.Top;
            this.groupInput.Height = 160;

            lblName.Text = "Ad Soyad:";
            lblName.Location = new Point(20, 35);
            this.groupInput.Controls.Add(lblName);
            this.txtName.Location = new Point(100, 32);
            this.txtName.Width = 150;
            this.groupInput.Controls.Add(this.txtName);

            lblPos.Text = "Pozisyon:";
            lblPos.Location = new Point(20, 65);
            this.groupInput.Controls.Add(lblPos);
            this.txtPosition.Location = new Point(100, 62);
            this.txtPosition.Width = 150;
            this.groupInput.Controls.Add(this.txtPosition);

            lblPhone.Text = "Telefon:";
            lblPhone.Location = new Point(20, 95);
            this.groupInput.Controls.Add(lblPhone);
            this.txtPhone.Location = new Point(100, 92);
            this.txtPhone.Width = 150;
            this.groupInput.Controls.Add(this.txtPhone);

            this.btnAdd.Location = new Point(100, 120);
            this.btnAdd.Width = 90;
            this.groupInput.Controls.Add(this.btnAdd);

            this.btnRemove.Location = new Point(200, 120);
            this.btnRemove.Width = 90;
            this.groupInput.Controls.Add(this.btnRemove);

            this.btnAdd.Click += BtnAdd_Click;
            this.btnRemove.Click += BtnRemove_Click;

            // Grid
            this.gridControl.MainView = this.gridView;
            this.gridControl.Dock = DockStyle.Fill;
            this.gridView.GridControl = this.gridControl;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsBehavior.Editable = false;
            
            // Grid Columns (Will populate automatically but we can check debug)
            // Employee entity has many fields.
            
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.groupInput);

            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInput)).EndInit();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadData()
        {
            gridControl.DataSource = _manager.GetEmployeesByStore(_storeId);
            gridView.PopulateColumns();
            // Hide internal IDs or unused fields
            if(gridView.Columns["EmployeeId"] != null) gridView.Columns["EmployeeId"].Visible = false;
            if(gridView.Columns["UserId"] != null) gridView.Columns["UserId"].Visible = false;
            if(gridView.Columns["StoreId"] != null) gridView.Columns["StoreId"].Visible = false;
            if(gridView.Columns["ShiftStart"] != null) gridView.Columns["ShiftStart"].Visible = false;
            if(gridView.Columns["ShiftEnd"] != null) gridView.Columns["ShiftEnd"].Visible = false;
            if(gridView.Columns["WorkedDays"] != null) gridView.Columns["WorkedDays"].Visible = false;
             if(gridView.Columns["Salary"] != null) gridView.Columns["Salary"].Visible = false;
            gridView.BestFitColumns();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var emp = new Employee
                {
                    StoreId = _storeId,
                    FullName = txtName.Text,
                    Position = txtPosition.Text,
                    Phone = txtPhone.Text,
                    Status = "Active",
                    StartDate = DateTime.Now,
                    Salary = 0 // Default
                };
                _manager.AddEmployee(emp);
                LoadData();
                txtName.Text = ""; txtPosition.Text = ""; txtPhone.Text = "";
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var row = gridView.GetFocusedRow() as Employee;
            if(row != null)
            {
                if(XtraMessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _manager.RemoveEmployee(row.EmployeeId);
                    LoadData();
                }
            }
        }
    }
}
