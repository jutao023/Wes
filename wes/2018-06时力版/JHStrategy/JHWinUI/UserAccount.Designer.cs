namespace JHWinUI
{
    partial class UserAccount
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccount));
            this.listUserInfo = new System.Windows.Forms.ListView();
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instrument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valsign = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trade_addr_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.market_addr_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.http_addr_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopuMenu_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContractID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxSelectValsign = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxSelectHttp = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxSelectMarketAddr = new System.Windows.Forms.ComboBox();
            this.cboxSelectTradeAddr = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip_delete.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listUserInfo
            // 
            this.listUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.listUserInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.username,
            this.password,
            this.instrument,
            this.valsign,
            this.trade_addr_port,
            this.market_addr_port,
            this.http_addr_port});
            this.listUserInfo.ContextMenuStrip = this.contextMenuStrip_delete;
            this.listUserInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.listUserInfo.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listUserInfo.FullRowSelect = true;
            this.listUserInfo.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listUserInfo.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listUserInfo.Location = new System.Drawing.Point(84, 160);
            this.listUserInfo.Name = "listUserInfo";
            this.listUserInfo.ShowGroups = false;
            this.listUserInfo.Size = new System.Drawing.Size(1214, 526);
            this.listUserInfo.TabIndex = 0;
            this.listUserInfo.UseCompatibleStateImageBehavior = false;
            this.listUserInfo.View = System.Windows.Forms.View.Details;
            this.listUserInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listUserInfo_MouseClick);
            // 
            // username
            // 
            this.username.Text = "账户";
            this.username.Width = 90;
            // 
            // password
            // 
            this.password.Text = "密码";
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.Width = 90;
            // 
            // instrument
            // 
            this.instrument.Text = "品种";
            this.instrument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.instrument.Width = 90;
            // 
            // valsign
            // 
            this.valsign.Text = "特征码";
            this.valsign.Width = 90;
            // 
            // trade_addr_port
            // 
            this.trade_addr_port.Text = "交易地址";
            this.trade_addr_port.Width = 180;
            // 
            // market_addr_port
            // 
            this.market_addr_port.Text = "行情地址";
            this.market_addr_port.Width = 180;
            // 
            // http_addr_port
            // 
            this.http_addr_port.Text = "HTTP";
            this.http_addr_port.Width = 180;
            // 
            // contextMenuStrip_delete
            // 
            this.contextMenuStrip_delete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contextMenuStrip_delete.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_delete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopuMenu_delete});
            this.contextMenuStrip_delete.Name = "contextMenuStrip_delete";
            this.contextMenuStrip_delete.Size = new System.Drawing.Size(124, 34);
            // 
            // PopuMenu_delete
            // 
            this.PopuMenu_delete.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PopuMenu_delete.ForeColor = System.Drawing.Color.Red;
            this.PopuMenu_delete.Image = global::JHWinUI.Properties.Resources.cancel;
            this.PopuMenu_delete.Name = "PopuMenu_delete";
            this.PopuMenu_delete.Size = new System.Drawing.Size(123, 30);
            this.PopuMenu_delete.Text = "删除";
            this.PopuMenu_delete.Click += new System.EventHandler(this.PopuMenu_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(82, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "账户";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(123, 117);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(111, 27);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(281, 117);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(101, 27);
            this.txtPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(239, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // txtContractID
            // 
            this.txtContractID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContractID.Location = new System.Drawing.Point(431, 117);
            this.txtContractID.Name = "txtContractID";
            this.txtContractID.Size = new System.Drawing.Size(98, 27);
            this.txtContractID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(389, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "合同";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(1175, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.cboxSelectValsign);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboxSelectHttp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboxSelectMarketAddr);
            this.groupBox1.Controls.Add(this.cboxSelectTradeAddr);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(48, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1282, 651);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // cboxSelectValsign
            // 
            this.cboxSelectValsign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxSelectValsign.FormattingEnabled = true;
            this.cboxSelectValsign.Items.AddRange(new object[] {
            "SHJH000"});
            this.cboxSelectValsign.Location = new System.Drawing.Point(525, 41);
            this.cboxSelectValsign.Name = "cboxSelectValsign";
            this.cboxSelectValsign.Size = new System.Drawing.Size(70, 28);
            this.cboxSelectValsign.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(484, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "特征";
            // 
            // cboxSelectHttp
            // 
            this.cboxSelectHttp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxSelectHttp.FormattingEnabled = true;
            this.cboxSelectHttp.Items.AddRange(new object[] {
            "101.132.235.139:9018"});
            this.cboxSelectHttp.Location = new System.Drawing.Point(1029, 42);
            this.cboxSelectHttp.Name = "cboxSelectHttp";
            this.cboxSelectHttp.Size = new System.Drawing.Size(136, 28);
            this.cboxSelectHttp.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(976, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "HTTP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(790, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "行情";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(602, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "交易";
            // 
            // cboxSelectMarketAddr
            // 
            this.cboxSelectMarketAddr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxSelectMarketAddr.FormattingEnabled = true;
            this.cboxSelectMarketAddr.Items.AddRange(new object[] {
            "101.132.235.139:4001"});
            this.cboxSelectMarketAddr.Location = new System.Drawing.Point(834, 41);
            this.cboxSelectMarketAddr.Name = "cboxSelectMarketAddr";
            this.cboxSelectMarketAddr.Size = new System.Drawing.Size(138, 28);
            this.cboxSelectMarketAddr.TabIndex = 9;
            // 
            // cboxSelectTradeAddr
            // 
            this.cboxSelectTradeAddr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxSelectTradeAddr.FormattingEnabled = true;
            this.cboxSelectTradeAddr.Items.AddRange(new object[] {
            "101.132.235.139:18003"});
            this.cboxSelectTradeAddr.Location = new System.Drawing.Point(646, 41);
            this.cboxSelectTradeAddr.Name = "cboxSelectTradeAddr";
            this.cboxSelectTradeAddr.Size = new System.Drawing.Size(137, 28);
            this.cboxSelectTradeAddr.TabIndex = 8;
            // 
            // UserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1359, 727);
            this.Controls.Add(this.listUserInfo);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContractID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.groupBox1);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserAccount";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "配置账户";
            this.Load += new System.EventHandler(this.UserAccount_Load);
            this.contextMenuStrip_delete.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listUserInfo;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader instrument;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContractID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_delete;
        private System.Windows.Forms.ToolStripMenuItem PopuMenu_delete;
        private System.Windows.Forms.ColumnHeader trade_addr_port;
        private System.Windows.Forms.ColumnHeader market_addr_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxSelectMarketAddr;
        private System.Windows.Forms.ComboBox cboxSelectTradeAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxSelectHttp;
        private System.Windows.Forms.ColumnHeader valsign;
        private System.Windows.Forms.ColumnHeader http_addr_port;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxSelectValsign;
    }
}