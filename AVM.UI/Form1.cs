using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AVM.DataAccess;
using AVM.Core.Entities;


namespace AVM.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var uow = new UnitOfWork();

            // 1 - Kullanıcıları veritabanından çek
            var users = uow.Users.GetAll();

            MessageBox.Show("Kullanıcı sayısı: " + users.Count());

           /* var newUser = new User
            {
                FullName = "Test Kullanıcı",
                Username = "testuser",
                PasswordHash = "12345",
                RoleId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            // veritabanına ekle
            uow.Users.Add(newUser);

            MessageBox.Show("Yeni kullanıcı eklendi!");*/

        }
    }
}
