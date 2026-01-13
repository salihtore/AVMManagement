namespace AVM.UI
{
    partial class UCAnnouncements
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.memContent = new DevExpress.XtraEditors.MemoEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupCreate = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemContent = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemSend = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemDelete = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.gridControl);
            this.layoutControl.Controls.Add(this.txtTitle);
            this.layoutControl.Controls.Add(this.memContent);
            this.layoutControl.Controls.Add(this.btnSend);
            this.layoutControl.Controls.Add(this.btnDelete);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.root;
            this.layoutControl.Size = new System.Drawing.Size(800, 600);
            this.layoutControl.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1360, 860);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(125, 22);
            this.txtTitle.StyleController = this.layoutControl;
            this.txtTitle.TabIndex = 5;
            // 
            // memContent
            // 
            this.memContent.Location = new System.Drawing.Point(0, 0);
            this.memContent.Name = "memContent";
            this.memContent.Size = new System.Drawing.Size(100, 96);
            this.memContent.StyleController = this.layoutControl;
            this.memContent.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(0, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 29);
            this.btnSend.StyleController = this.layoutControl;
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Duyuru Yayınla";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.StyleController = this.layoutControl;
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Seçili Duyuruyu Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 600);
            // 
            // root
            // 
            this.root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.root.GroupBordersVisible = false;
            this.root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupCreate,
            this.layoutControlItemGrid,
            this.layoutControlItemDelete});
            this.root.Location = new System.Drawing.Point(0, 0);
            this.root.Name = "root";
            this.root.Size = new System.Drawing.Size(800, 600);
            this.root.TextVisible = false;
            // 
            // layoutControlGroupCreate
            // 
            this.layoutControlGroupCreate.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemTitle,
            this.layoutControlItemContent,
            this.layoutControlItemSend});
            this.layoutControlGroupCreate.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupCreate.Name = "layoutControlGroupCreate";
            this.layoutControlGroupCreate.Size = new System.Drawing.Size(780, 147);
            this.layoutControlGroupCreate.Text = "Yeni Duyuru Oluştur";
            // 
            // layoutControlItemTitle
            // 
            this.layoutControlItemTitle.Control = this.txtTitle;
            this.layoutControlItemTitle.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemTitle.Name = "layoutControlItemTitle";
            this.layoutControlItemTitle.Size = new System.Drawing.Size(772, 32);
            this.layoutControlItemTitle.Text = "Konu Başlığı";
            this.layoutControlItemTitle.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemTitle.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItemContent
            // 
            this.layoutControlItemContent.Control = this.memContent;
            this.layoutControlItemContent.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItemContent.MaxSize = new System.Drawing.Size(0, 100);
            this.layoutControlItemContent.MinSize = new System.Drawing.Size(100, 50);
            this.layoutControlItemContent.Name = "layoutControlItemContent";
            this.layoutControlItemContent.Size = new System.Drawing.Size(772, 50);
            this.layoutControlItemContent.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemContent.Text = "Duyuru İçeriği";
            this.layoutControlItemContent.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemContent.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItemSend
            // 
            this.layoutControlItemSend.Control = this.btnSend;
            this.layoutControlItemSend.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItemSend.Name = "layoutControlItemSend";
            this.layoutControlItemSend.Size = new System.Drawing.Size(772, 37);
            this.layoutControlItemSend.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            this.layoutControlItemGrid.Control = this.gridControl;
            this.layoutControlItemGrid.Location = new System.Drawing.Point(0, 113);
            this.layoutControlItemGrid.Name = "layoutControlItemGrid";
            this.layoutControlItemGrid.Size = new System.Drawing.Size(780, 442);
            this.layoutControlItemGrid.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlItemDelete
            // 
            this.layoutControlItemDelete.Control = this.btnDelete;
            this.layoutControlItemDelete.Location = new System.Drawing.Point(0, 555);
            this.layoutControlItemDelete.Name = "layoutControlItemDelete";
            this.layoutControlItemDelete.Size = new System.Drawing.Size(780, 29);
            this.layoutControlItemDelete.TextVisible = false;
            // 
            // UCAnnouncements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "UCAnnouncements";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDelete)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.MemoEdit memContent;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlGroup root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemTitle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemContent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupCreate;
    }
}
