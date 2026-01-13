using AVM.Business;
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
    public partial class PersonnelForm : DevExpress.XtraEditors.XtraForm
    {
        private int _userId;
        private PersonnelManager _manager;

        public PersonnelForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _manager = new PersonnelManager();

            // Navigation Handlers
            accDashboard.Click += (s, e) => LoadModule(new UCPersonnelDashboard(_userId));
            accShifts.Click += (s, e) => LoadModule(new UCShifts(_userId));
            accTasks.Click += (s, e) => LoadModule(new UCTasks(_userId));
            accLeave.Click += (s, e) => LoadModule(new UCLeaveRequests(_userId));
            accMessages.Click += (s, e) => {
                var inbox = new PersonnelInboxForm(_userId);
                inbox.ShowDialog();
            };
            accLogout.Click += (s, e) => this.Close();

            // Default
            LoadModule(new UCPersonnelDashboard(_userId));
        }

        private void LoadModule(UserControl module)
        {
            panelMain.Controls.Clear();
            module.Dock = DockStyle.Fill;
            panelMain.Controls.Add(module);
        }
    }
}
