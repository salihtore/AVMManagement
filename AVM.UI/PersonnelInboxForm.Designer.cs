namespace AVM.UI
{
    partial class PersonnelInboxForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabAnnouncements = new DevExpress.XtraTab.XtraTabPage();
            this.gridAnnouncements = new DevExpress.XtraGrid.GridControl();
            this.viewAnnouncements = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabMessages = new DevExpress.XtraTab.XtraTabPage();
            this.gridMessages = new DevExpress.XtraGrid.GridControl();
            this.viewMessages = new DevExpress.XtraGrid.Views.Grid.GridView();

            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabAnnouncements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnouncements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAnnouncements)).BeginInit();
            this.tabMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessages)).BeginInit();
            this.SuspendLayout();

            // xtraTabControl1
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabAnnouncements;
            this.xtraTabControl1.Size = new System.Drawing.Size(800, 450);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAnnouncements,
            this.tabMessages});

            // tabAnnouncements
            this.tabAnnouncements.Controls.Add(this.gridAnnouncements);
            this.tabAnnouncements.Name = "tabAnnouncements";
            this.tabAnnouncements.Size = new System.Drawing.Size(798, 420);
            this.tabAnnouncements.Text = "Duyurular";

            // gridAnnouncements
            this.gridAnnouncements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAnnouncements.MainView = this.viewAnnouncements;
            this.gridAnnouncements.Name = "gridAnnouncements";
            this.gridAnnouncements.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewAnnouncements});

            // viewAnnouncements
            this.viewAnnouncements.GridControl = this.gridAnnouncements;
            this.viewAnnouncements.Name = "viewAnnouncements";
            this.viewAnnouncements.OptionsBehavior.Editable = false;
            this.viewAnnouncements.OptionsView.ShowGroupPanel = false;

            // tabMessages
            this.tabMessages.Controls.Add(this.gridMessages);
            this.tabMessages.Name = "tabMessages";
            this.tabMessages.Size = new System.Drawing.Size(798, 420);
            this.tabMessages.Text = "Mesajlarım";

            // gridMessages
            this.gridMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMessages.MainView = this.viewMessages;
            this.gridMessages.Name = "gridMessages";
            this.gridMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMessages});

            // viewMessages
            this.viewMessages.GridControl = this.gridMessages;
            this.viewMessages.Name = "viewMessages";
            this.viewMessages.OptionsBehavior.Editable = false;
            this.viewMessages.OptionsView.ShowGroupPanel = false;

            // PersonnelInboxForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "PersonnelInboxForm";
            this.Text = "Mesaj ve Duyurular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabAnnouncements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnouncements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAnnouncements)).EndInit();
            this.tabMessages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMessages)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabAnnouncements;
        private DevExpress.XtraTab.XtraTabPage tabMessages;
        private DevExpress.XtraGrid.GridControl gridAnnouncements;
        private DevExpress.XtraGrid.Views.Grid.GridView viewAnnouncements;
        private DevExpress.XtraGrid.GridControl gridMessages;
        private DevExpress.XtraGrid.Views.Grid.GridView viewMessages;
    }
}
