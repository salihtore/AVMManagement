using AVM.Business;
using DevExpress.XtraEditors;
using System;

namespace AVM.UI
{
    public partial class PersonnelInboxForm : DevExpress.XtraEditors.XtraForm
    {
        private CommunicationManager _manager;
        private int _userId;

        public PersonnelInboxForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            _manager = new CommunicationManager();
            LoadData();
        }

        private void LoadData()
        {
            // Load Announcements
            gridAnnouncements.DataSource = _manager.GetActiveAnnouncements();

            // Load Messages
            gridMessages.DataSource = _manager.GetMessagesForUser(_userId);
        }
    }
}
