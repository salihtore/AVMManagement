namespace AVM.UI
{
    partial class PersonnelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accDashboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accShifts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accTasks = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accLeave = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accMessages = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accLogout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accDashboard,
            this.accShifts,
            this.accTasks,
            this.accLeave,
            this.accMessages,
            this.accLogout});
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.Size = new System.Drawing.Size(260, 450);
            this.accordionControl1.TabIndex = 0;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accDashboard
            // 
            this.accDashboard.Name = "accDashboard";
            this.accDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accDashboard.Text = "Ana Sayfa";
            // 
            // accShifts
            // 
            this.accShifts.Name = "accShifts";
            this.accShifts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accShifts.Text = "Vardiya Takvimim";
            // 
            // accTasks
            // 
            this.accTasks.Name = "accTasks";
            this.accTasks.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accTasks.Text = "Görevlerim";
            // 
            // accLeave
            // 
            this.accLeave.Name = "accLeave";
            this.accLeave.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accLeave.Text = "İzin İşlemleri";
            // 
            // accMessages
            // 
            this.accMessages.Name = "accMessages";
            this.accMessages.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accMessages.Text = "Duyurular & Mesajlar";
            // 
            // accLogout
            // 
            this.accLogout.Name = "accLogout";
            this.accLogout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accLogout.Text = "Çıkış Yap";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(260, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(540, 450);
            this.panelMain.TabIndex = 1;
            // 
            // PersonnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.accordionControl1);
            this.Name = "PersonnelForm";
            this.Text = "Personel Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accDashboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accShifts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accTasks;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accLeave;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accMessages;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accLogout;
        private DevExpress.XtraEditors.PanelControl panelMain;
    }
}
