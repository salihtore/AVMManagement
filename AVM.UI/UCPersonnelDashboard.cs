using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;
using AVM.Business;
using DevExpress.XtraLayout;
using System;

namespace AVM.UI
{
    public partial class UCPersonnelDashboard : XtraUserControl
    {
        private int _employeeId;
        private LabelControl lblWelcome;
        // In future can add 'Next Shift' summary here
        
        public UCPersonnelDashboard(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
        }

        private void InitializeComponent()
        {
            // LayoutControl removed for simplicity and stability for single label
            
            lblWelcome = new LabelControl 
            { 
                Text = "Personel Bilgi Sistemine Hoş Geldiniz",
                AutoSizeMode = LabelAutoSizeMode.None
            };
            lblWelcome.Appearance.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblWelcome.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblWelcome.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblWelcome.Dock = DockStyle.Fill;
            
            this.Controls.Add(lblWelcome);
        }
    }
}
