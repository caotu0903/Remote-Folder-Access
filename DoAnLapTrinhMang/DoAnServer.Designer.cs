
namespace DoAnLapTrinhMang
{
    partial class DoAnServer
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
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.lbIP = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.tbList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(284, 12);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(87, 20);
            this.tbPort.TabIndex = 19;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(252, 16);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 18;
            this.lbPort.Text = "Port";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(52, 12);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(194, 20);
            this.tbIP.TabIndex = 17;
            // 
            // lbIP
            // 
            this.lbIP.AutoSize = true;
            this.lbIP.Location = new System.Drawing.Point(32, 16);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(17, 13);
            this.lbIP.TabIndex = 16;
            this.lbIP.Text = "IP";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(376, 10);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(102, 23);
            this.btStart.TabIndex = 14;
            this.btStart.Text = "Bắt đầu";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbList
            // 
            this.tbList.Location = new System.Drawing.Point(30, 42);
            this.tbList.Multiline = true;
            this.tbList.Name = "tbList";
            this.tbList.ReadOnly = true;
            this.tbList.Size = new System.Drawing.Size(449, 331);
            this.tbList.TabIndex = 13;
            // 
            // DoAnServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 383);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tbList);
            this.Name = "DoAnServer";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label lbIP;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbList;
    }
}