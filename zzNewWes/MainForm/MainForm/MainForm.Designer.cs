namespace wes
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.strategyList = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coinSymbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.strategyListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Flush = new System.Windows.Forms.Button();
            this.strategyListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // strategyList
            // 
            this.strategyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.username,
            this.password,
            this.uid,
            this.coinSymbol,
            this.status,
            this.remarks});
            this.strategyList.ContextMenuStrip = this.strategyListMenu;
            this.strategyList.Dock = System.Windows.Forms.DockStyle.Left;
            this.strategyList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.strategyList.FullRowSelect = true;
            this.strategyList.GridLines = true;
            this.strategyList.Location = new System.Drawing.Point(0, 0);
            this.strategyList.Name = "strategyList";
            this.strategyList.Size = new System.Drawing.Size(1096, 643);
            this.strategyList.TabIndex = 0;
            this.strategyList.UseCompatibleStateImageBehavior = false;
            this.strategyList.View = System.Windows.Forms.View.Details;
            this.strategyList.SelectedIndexChanged += new System.EventHandler(this.strategyList_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 80;
            // 
            // username
            // 
            this.username.Text = "账户";
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.username.Width = 100;
            // 
            // password
            // 
            this.password.Text = "密码";
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.Width = 100;
            // 
            // uid
            // 
            this.uid.Text = "UID";
            this.uid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uid.Width = 100;
            // 
            // coinSymbol
            // 
            this.coinSymbol.Text = "产品编码";
            this.coinSymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.coinSymbol.Width = 110;
            // 
            // status
            // 
            this.status.Text = "状态";
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.status.Width = 110;
            // 
            // remarks
            // 
            this.remarks.Text = "备注";
            this.remarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.remarks.Width = 220;
            // 
            // strategyListMenu
            // 
            this.strategyListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.strategyListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.显示ToolStripMenuItem});
            this.strategyListMenu.Name = "strategyListMenu";
            this.strategyListMenu.Size = new System.Drawing.Size(109, 100);
            // 
            // 开启ToolStripMenuItem
            // 
            this.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            this.开启ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.开启ToolStripMenuItem.Text = "启动";
            this.开启ToolStripMenuItem.Click += new System.EventHandler(this.开启ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.关闭ToolStripMenuItem.Text = "停止";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.设置ToolStripMenuItem.Text = "配置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Location = new System.Drawing.Point(1098, -1);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(53, 47);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "+";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Location = new System.Drawing.Point(1098, 46);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(53, 47);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "-";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Flush
            // 
            this.btn_Flush.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Flush.Location = new System.Drawing.Point(1098, 94);
            this.btn_Flush.Name = "btn_Flush";
            this.btn_Flush.Size = new System.Drawing.Size(53, 47);
            this.btn_Flush.TabIndex = 3;
            this.btn_Flush.Text = "o";
            this.btn_Flush.UseVisualStyleBackColor = true;
            this.btn_Flush.Click += new System.EventHandler(this.btn_Flush_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 643);
            this.Controls.Add(this.btn_Flush);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.strategyList);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "做市商";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.strategyListMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView strategyList;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader password;
        private System.Windows.Forms.ColumnHeader uid;
        private System.Windows.Forms.ColumnHeader coinSymbol;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader remarks;
        private System.Windows.Forms.ContextMenuStrip strategyListMenu;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.Button btn_Flush;
    }
}

