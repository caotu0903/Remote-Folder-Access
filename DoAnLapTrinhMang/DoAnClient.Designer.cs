
namespace DoAnLapTrinhMang
{
    partial class DoAnClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoAnClient));
            this.lvInfo = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Extension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbNotification = new System.Windows.Forms.Label();
            this.lbAccountName = new System.Windows.Forms.Label();
            this.cbURL = new System.Windows.Forms.ComboBox();
            this.btBack = new System.Windows.Forms.Button();
            this.btForward = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.tsddbMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangeAccountName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsManageAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.cbHiddenItems = new System.Windows.Forms.CheckBox();
            this.tsToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvInfo
            // 
            this.lvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.Extension,
            this.FileType});
            this.lvInfo.HideSelection = false;
            this.lvInfo.Location = new System.Drawing.Point(12, 86);
            this.lvInfo.Name = "lvInfo";
            this.lvInfo.Size = new System.Drawing.Size(518, 232);
            this.lvInfo.TabIndex = 8;
            this.lvInfo.UseCompatibleStateImageBehavior = false;
            this.lvInfo.View = System.Windows.Forms.View.Details;
            this.lvInfo.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvInfo_ColumnClick);
            this.lvInfo.DoubleClick += new System.EventHandler(this.lvInfo_DoubleClick);
            // 
            // FileName
            // 
            this.FileName.Text = "Tên File";
            this.FileName.Width = 283;
            // 
            // Extension
            // 
            this.Extension.Text = "Đuôi mở rộng";
            this.Extension.Width = 78;
            // 
            // FileType
            // 
            this.FileType.Text = "Loại File";
            this.FileType.Width = 131;
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotification.ForeColor = System.Drawing.Color.Red;
            this.lbNotification.Location = new System.Drawing.Point(13, 325);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(75, 15);
            this.lbNotification.TabIndex = 9;
            this.lbNotification.Text = "Thông báo";
            // 
            // lbAccountName
            // 
            this.lbAccountName.AutoSize = true;
            this.lbAccountName.Location = new System.Drawing.Point(9, 33);
            this.lbAccountName.Name = "lbAccountName";
            this.lbAccountName.Size = new System.Drawing.Size(75, 13);
            this.lbAccountName.TabIndex = 10;
            this.lbAccountName.Text = "AccountName";
            // 
            // cbURL
            // 
            this.cbURL.FormattingEnabled = true;
            this.cbURL.Location = new System.Drawing.Point(66, 59);
            this.cbURL.Name = "cbURL";
            this.cbURL.Size = new System.Drawing.Size(435, 21);
            this.cbURL.TabIndex = 11;
            this.cbURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbURL_KeyPress);
            this.cbURL.Leave += new System.EventHandler(this.cbURL_Leave);
            // 
            // btBack
            // 
            this.btBack.BackgroundImage = global::DoAnLapTrinhMang.Properties.Resources.Back;
            this.btBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBack.Enabled = false;
            this.btBack.FlatAppearance.BorderSize = 0;
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBack.Location = new System.Drawing.Point(12, 59);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(26, 21);
            this.btBack.TabIndex = 16;
            this.btBack.Tag = "";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btForward
            // 
            this.btForward.BackgroundImage = global::DoAnLapTrinhMang.Properties.Resources.Forward;
            this.btForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btForward.Enabled = false;
            this.btForward.FlatAppearance.BorderSize = 0;
            this.btForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btForward.Location = new System.Drawing.Point(34, 59);
            this.btForward.Name = "btForward";
            this.btForward.Size = new System.Drawing.Size(26, 21);
            this.btForward.TabIndex = 17;
            this.btForward.Tag = "Forward";
            this.btForward.UseVisualStyleBackColor = true;
            this.btForward.Click += new System.EventHandler(this.btForward_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.BackgroundImage = global::DoAnLapTrinhMang.Properties.Resources.Refresh;
            this.btRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRefresh.FlatAppearance.BorderSize = 0;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.btRefresh.ForeColor = System.Drawing.Color.White;
            this.btRefresh.Location = new System.Drawing.Point(507, 58);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(23, 21);
            this.btRefresh.TabIndex = 18;
            this.btRefresh.Tag = "";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // tsToolBar
            // 
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbMenu});
            this.tsToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(542, 25);
            this.tsToolBar.TabIndex = 19;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // tsddbMenu
            // 
            this.tsddbMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAccount,
            this.tsManageAccount,
            this.tsLogOut});
            this.tsddbMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsddbMenu.Image")));
            this.tsddbMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbMenu.Name = "tsddbMenu";
            this.tsddbMenu.Size = new System.Drawing.Size(51, 22);
            this.tsddbMenu.Text = "Menu";
            // 
            // tsAccount
            // 
            this.tsAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsChangeAccountName,
            this.tsChangePassword});
            this.tsAccount.Name = "tsAccount";
            this.tsAccount.Size = new System.Drawing.Size(164, 22);
            this.tsAccount.Text = "Tài khoản";
            // 
            // tsChangeAccountName
            // 
            this.tsChangeAccountName.Name = "tsChangeAccountName";
            this.tsChangeAccountName.Size = new System.Drawing.Size(164, 22);
            this.tsChangeAccountName.Text = "Đổi tên tài khoản";
            this.tsChangeAccountName.Click += new System.EventHandler(this.tsChangeAccountName_Click);
            // 
            // tsChangePassword
            // 
            this.tsChangePassword.Name = "tsChangePassword";
            this.tsChangePassword.Size = new System.Drawing.Size(164, 22);
            this.tsChangePassword.Text = "Đổi mật khẩu";
            this.tsChangePassword.Click += new System.EventHandler(this.tsChangePassword_Click);
            // 
            // tsManageAccount
            // 
            this.tsManageAccount.Enabled = false;
            this.tsManageAccount.Name = "tsManageAccount";
            this.tsManageAccount.Size = new System.Drawing.Size(164, 22);
            this.tsManageAccount.Text = "Quản lí tài khoản";
            this.tsManageAccount.Visible = false;
            this.tsManageAccount.Click += new System.EventHandler(this.tsManageAccount_Click);
            // 
            // tsLogOut
            // 
            this.tsLogOut.Name = "tsLogOut";
            this.tsLogOut.Size = new System.Drawing.Size(164, 22);
            this.tsLogOut.Text = "Đăng xuất";
            this.tsLogOut.Click += new System.EventHandler(this.tsLogOut_Click);
            // 
            // cbHiddenItems
            // 
            this.cbHiddenItems.AutoSize = true;
            this.cbHiddenItems.Location = new System.Drawing.Point(443, 32);
            this.cbHiddenItems.Name = "cbHiddenItems";
            this.cbHiddenItems.Size = new System.Drawing.Size(87, 17);
            this.cbHiddenItems.TabIndex = 20;
            this.cbHiddenItems.Text = "Hidden items";
            this.cbHiddenItems.UseVisualStyleBackColor = true;
            this.cbHiddenItems.CheckedChanged += new System.EventHandler(this.cbHiddenItems_CheckedChanged);
            // 
            // DoAnClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 356);
            this.Controls.Add(this.cbHiddenItems);
            this.Controls.Add(this.tsToolBar);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btForward);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.cbURL);
            this.Controls.Add(this.lbAccountName);
            this.Controls.Add(this.lbNotification);
            this.Controls.Add(this.lvInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DoAnClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoAnClient_FormClosing);
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvInfo;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Extension;
        private System.Windows.Forms.ColumnHeader FileType;
        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.Label lbAccountName;
        private System.Windows.Forms.ComboBox cbURL;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btForward;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ToolStrip tsToolBar;
        private System.Windows.Forms.ToolStripDropDownButton tsddbMenu;
        private System.Windows.Forms.ToolStripMenuItem tsAccount;
        private System.Windows.Forms.ToolStripMenuItem tsChangeAccountName;
        private System.Windows.Forms.ToolStripMenuItem tsChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsLogOut;
        private System.Windows.Forms.ToolStripMenuItem tsManageAccount;
        private System.Windows.Forms.CheckBox cbHiddenItems;
    }
}