
namespace DoAnLapTrinhMang
{
    partial class DoAnClientAdminManageAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoAnClientAdminManageAccount));
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNofication = new System.Windows.Forms.ToolStripLabel();
            this.lvAccountInfo = new System.Windows.Forms.ListView();
            this.chCheckBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolBar
            // 
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdd,
            this.toolStripSeparator1,
            this.tsDelete,
            this.toolStripSeparator2,
            this.tsRefresh,
            this.toolStripSeparator3,
            this.tsNofication});
            this.tsToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(642, 25);
            this.tsToolBar.TabIndex = 0;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // tsAdd
            // 
            this.tsAdd.AutoSize = false;
            this.tsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsAdd.Image")));
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(100, 22);
            this.tsAdd.Text = "Thêm tài khoản";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsDelete
            // 
            this.tsDelete.AutoSize = false;
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(100, 22);
            this.tsDelete.Text = "Xóa tài khoản";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsRefresh
            // 
            this.tsRefresh.AutoSize = false;
            this.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(120, 22);
            this.tsRefresh.Text = "Cập nhật danh sách";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsNofication
            // 
            this.tsNofication.ActiveLinkColor = System.Drawing.Color.Red;
            this.tsNofication.ForeColor = System.Drawing.Color.Red;
            this.tsNofication.Name = "tsNofication";
            this.tsNofication.Size = new System.Drawing.Size(64, 22);
            this.tsNofication.Text = "Thông báo";
            this.tsNofication.Visible = false;
            // 
            // lvAccountInfo
            // 
            this.lvAccountInfo.CheckBoxes = true;
            this.lvAccountInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCheckBox,
            this.chUserName,
            this.chPassword,
            this.chAccountName,
            this.chStatus,
            this.chCreateTime});
            this.lvAccountInfo.HideSelection = false;
            this.lvAccountInfo.Location = new System.Drawing.Point(0, 28);
            this.lvAccountInfo.Name = "lvAccountInfo";
            this.lvAccountInfo.Size = new System.Drawing.Size(642, 332);
            this.lvAccountInfo.TabIndex = 1;
            this.lvAccountInfo.UseCompatibleStateImageBehavior = false;
            this.lvAccountInfo.View = System.Windows.Forms.View.Details;
            // 
            // chCheckBox
            // 
            this.chCheckBox.Text = "";
            this.chCheckBox.Width = 19;
            // 
            // chUserName
            // 
            this.chUserName.Text = "USERNAME";
            this.chUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chUserName.Width = 126;
            // 
            // chPassword
            // 
            this.chPassword.Text = "PASSWORD";
            this.chPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPassword.Width = 126;
            // 
            // chAccountName
            // 
            this.chAccountName.Text = "ACCOUNTNAME";
            this.chAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAccountName.Width = 126;
            // 
            // chStatus
            // 
            this.chStatus.Text = "STATUS";
            this.chStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chCreateTime
            // 
            this.chCreateTime.Text = "CREATETIME";
            this.chCreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCreateTime.Width = 150;
            // 
            // DoAnClientAdminManageAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 360);
            this.Controls.Add(this.lvAccountInfo);
            this.Controls.Add(this.tsToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DoAnClientAdminManageAccount";
            this.Text = "Quản lí tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoAnClientAdminManageAccount_FormClosing);
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsToolBar;
        private System.Windows.Forms.ListView lvAccountInfo;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tsNofication;
        private System.Windows.Forms.ColumnHeader chCheckBox;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chPassword;
        private System.Windows.Forms.ColumnHeader chAccountName;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chCreateTime;
    }
}