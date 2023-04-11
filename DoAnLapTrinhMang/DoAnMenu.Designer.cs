
namespace DoAnLapTrinhMang
{
    partial class DoAnMenu
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
            this.btServer = new System.Windows.Forms.Button();
            this.btClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btServer
            // 
            this.btServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btServer.Location = new System.Drawing.Point(12, 12);
            this.btServer.Name = "btServer";
            this.btServer.Size = new System.Drawing.Size(139, 43);
            this.btServer.TabIndex = 0;
            this.btServer.Text = "Server";
            this.btServer.UseVisualStyleBackColor = true;
            this.btServer.Click += new System.EventHandler(this.btServer_Click);
            // 
            // btClient
            // 
            this.btClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClient.Location = new System.Drawing.Point(157, 12);
            this.btClient.Name = "btClient";
            this.btClient.Size = new System.Drawing.Size(139, 43);
            this.btClient.TabIndex = 1;
            this.btClient.Text = "Client";
            this.btClient.UseVisualStyleBackColor = true;
            this.btClient.Click += new System.EventHandler(this.btClient_Click);
            // 
            // DoAnMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 67);
            this.Controls.Add(this.btClient);
            this.Controls.Add(this.btServer);
            this.Name = "DoAnMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btServer;
        private System.Windows.Forms.Button btClient;
    }
}