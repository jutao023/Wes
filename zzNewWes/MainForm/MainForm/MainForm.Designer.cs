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
            this.show = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.strategyListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.show});
            this.strategyList.ContextMenuStrip = this.strategyListMenu;
            this.strategyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.strategyList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.strategyList.FullRowSelect = true;
            this.strategyList.GridLines = true;
            this.strategyList.Location = new System.Drawing.Point(0, 0);
            this.strategyList.Name = "strategyList";
            this.strategyList.Size = new System.Drawing.Size(957, 539);
            this.strategyList.TabIndex = 0;
            this.strategyList.UseCompatibleStateImageBehavior = false;
            this.strategyList.View = System.Windows.Forms.View.Details;
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
            // show
            // 
            this.show.Text = "显示";
            this.show.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.show.Width = 110;
            // 
            // strategyListMenu
            // 
            this.strategyListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.strategyListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.strategyListMenu.Name = "strategyListMenu";
            this.strategyListMenu.Size = new System.Drawing.Size(211, 104);
            // 
            // 开启ToolStripMenuItem
            // 
            this.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            this.开启ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.开启ToolStripMenuItem.Text = "开启";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.关闭ToolStripMenuItem.Text = "关闭";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 539);
            this.Controls.Add(this.strategyList);
            this.Name = "MainForm";
            this.Text = "MainFrom";
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
        private System.Windows.Forms.ColumnHeader show;
        private System.Windows.Forms.ContextMenuStrip strategyListMenu;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
    }
}

