namespace NetworkTool
{
    partial class M_Form
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
            this.DBG_ = new System.Windows.Forms.TextBox();
            this.GetAllDataOut = new System.Windows.Forms.Button();
            this.DisableAllNetworks = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.EnableAllNetworks = new System.Windows.Forms.Button();
            this.ShowWifiAndEnthernetMac = new System.Windows.Forms.Button();
            this.SpoofAll = new System.Windows.Forms.Button();
            this.RESETMAC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DBG_
            // 
            this.DBG_.Dock = System.Windows.Forms.DockStyle.Right;
            this.DBG_.Location = new System.Drawing.Point(427, 0);
            this.DBG_.MinimumSize = new System.Drawing.Size(373, 450);
            this.DBG_.Multiline = true;
            this.DBG_.Name = "DBG_";
            this.DBG_.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DBG_.ShortcutsEnabled = false;
            this.DBG_.Size = new System.Drawing.Size(373, 450);
            this.DBG_.TabIndex = 1;
            this.DBG_.WordWrap = false;
            // 
            // GetAllDataOut
            // 
            this.GetAllDataOut.Location = new System.Drawing.Point(12, 12);
            this.GetAllDataOut.Name = "GetAllDataOut";
            this.GetAllDataOut.Size = new System.Drawing.Size(362, 191);
            this.GetAllDataOut.TabIndex = 2;
            this.GetAllDataOut.Text = "Get Net Info From System";
            this.GetAllDataOut.UseVisualStyleBackColor = true;
            this.GetAllDataOut.Click += new System.EventHandler(this.GetAllDataOut_Click);
            // 
            // DisableAllNetworks
            // 
            this.DisableAllNetworks.Location = new System.Drawing.Point(47, 220);
            this.DisableAllNetworks.Name = "DisableAllNetworks";
            this.DisableAllNetworks.Size = new System.Drawing.Size(292, 23);
            this.DisableAllNetworks.TabIndex = 3;
            this.DisableAllNetworks.Text = "Disable All WIFI/ENTHERNET Interface";
            this.DisableAllNetworks.UseVisualStyleBackColor = true;
            this.DisableAllNetworks.Click += new System.EventHandler(this.DisableAllNetworks_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(424, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // EnableAllNetworks
            // 
            this.EnableAllNetworks.Location = new System.Drawing.Point(47, 249);
            this.EnableAllNetworks.Name = "EnableAllNetworks";
            this.EnableAllNetworks.Size = new System.Drawing.Size(292, 23);
            this.EnableAllNetworks.TabIndex = 6;
            this.EnableAllNetworks.Text = "Enable All WIFI/ENTHERNET Interface";
            this.EnableAllNetworks.UseVisualStyleBackColor = true;
            this.EnableAllNetworks.Click += new System.EventHandler(this.EnableAllNetworks_Click);
            // 
            // ShowWifiAndEnthernetMac
            // 
            this.ShowWifiAndEnthernetMac.Location = new System.Drawing.Point(12, 304);
            this.ShowWifiAndEnthernetMac.Name = "ShowWifiAndEnthernetMac";
            this.ShowWifiAndEnthernetMac.Size = new System.Drawing.Size(383, 51);
            this.ShowWifiAndEnthernetMac.TabIndex = 7;
            this.ShowWifiAndEnthernetMac.Text = "Get Mac Address Infomation";
            this.ShowWifiAndEnthernetMac.UseVisualStyleBackColor = true;
            this.ShowWifiAndEnthernetMac.Click += new System.EventHandler(this.SpoofWifiAndEnthernet_Click);
            // 
            // SpoofAll
            // 
            this.SpoofAll.Location = new System.Drawing.Point(12, 362);
            this.SpoofAll.Name = "SpoofAll";
            this.SpoofAll.Size = new System.Drawing.Size(383, 37);
            this.SpoofAll.TabIndex = 8;
            this.SpoofAll.Text = "Spoof All WIFI/ENTHERNET Interface Mac Address\'s";
            this.SpoofAll.UseVisualStyleBackColor = true;
            this.SpoofAll.Click += new System.EventHandler(this.SpoofAll_Click);
            // 
            // RESETMAC
            // 
            this.RESETMAC.Location = new System.Drawing.Point(12, 403);
            this.RESETMAC.Name = "RESETMAC";
            this.RESETMAC.Size = new System.Drawing.Size(383, 37);
            this.RESETMAC.TabIndex = 9;
            this.RESETMAC.Text = "Reset All WIFI/ENTHERNET Interface Mac Address\'s";
            this.RESETMAC.UseVisualStyleBackColor = true;
            this.RESETMAC.Click += new System.EventHandler(this.RESETMAC_Click);
            // 
            // M_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RESETMAC);
            this.Controls.Add(this.SpoofAll);
            this.Controls.Add(this.ShowWifiAndEnthernetMac);
            this.Controls.Add(this.EnableAllNetworks);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.DisableAllNetworks);
            this.Controls.Add(this.GetAllDataOut);
            this.Controls.Add(this.DBG_);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "M_Form";
            this.Text = "NHA | Network Tool V0.1b";
            this.Load += new System.EventHandler(this.M_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox DBG_;
        private System.Windows.Forms.Button GetAllDataOut;
        private System.Windows.Forms.Button DisableAllNetworks;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button EnableAllNetworks;
        private System.Windows.Forms.Button ShowWifiAndEnthernetMac;
        private System.Windows.Forms.Button SpoofAll;
        private System.Windows.Forms.Button RESETMAC;
    }
}

