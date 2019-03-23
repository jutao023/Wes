using WeifenLuo.WinFormsUI.Docking;

namespace JHWinUI
{
    partial class manSHJH : DockContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manSHJH));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_UserAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Strategy = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.notifyBubble = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmnuNotifyBubble = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.cmnuNotifyBubble.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.视图ToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1043, 28);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_UserAccount,
            this.MenuItem_Strategy});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // MenuItem_UserAccount
            // 
            this.MenuItem_UserAccount.Name = "MenuItem_UserAccount";
            this.MenuItem_UserAccount.Size = new System.Drawing.Size(144, 26);
            this.MenuItem_UserAccount.Text = "配置账户";
            this.MenuItem_UserAccount.Click += new System.EventHandler(this.MenuItem_UserAccount_Click);
            // 
            // MenuItem_Strategy
            // 
            this.MenuItem_Strategy.Name = "MenuItem_Strategy";
            this.MenuItem_Strategy.Size = new System.Drawing.Size(144, 26);
            this.MenuItem_Strategy.Text = "策略管理";
            this.MenuItem_Strategy.Click += new System.EventHandler(this.MenuItem_Strategy_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.Color.White;
            this.dockPanel1.BackgroundImage = global::JHWinUI.Properties.Resources.a044ad345982b2b7d7c5524b3badcbef77099be2;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.Color.White;
            this.dockPanel1.Location = new System.Drawing.Point(0, 28);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.Size = new System.Drawing.Size(1043, 636);
            this.dockPanel1.TabIndex = 0;
            // 
            // notifyBubble
            // 
            this.notifyBubble.ContextMenuStrip = this.cmnuNotifyBubble;
            this.notifyBubble.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyBubble.Icon")));
            this.notifyBubble.Text = "教汇做市商";
            this.notifyBubble.Visible = true;
            this.notifyBubble.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyBubble_MouseClick);
            // 
            // cmnuNotifyBubble
            // 
            this.cmnuNotifyBubble.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmnuNotifyBubble.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOpen,
            this.cmnuExit});
            this.cmnuNotifyBubble.Name = "cmnuNotifyBubble";
            this.cmnuNotifyBubble.Size = new System.Drawing.Size(109, 52);
            // 
            // cmnuOpen
            // 
            this.cmnuOpen.Name = "cmnuOpen";
            this.cmnuOpen.Size = new System.Drawing.Size(108, 24);
            this.cmnuOpen.Text = "打开";
            this.cmnuOpen.Click += new System.EventHandler(this.cmnuOpen_Click);
            // 
            // cmnuExit
            // 
            this.cmnuExit.Name = "cmnuExit";
            this.cmnuExit.Size = new System.Drawing.Size(108, 24);
            this.cmnuExit.Text = "退出";
            this.cmnuExit.Click += new System.EventHandler(this.cmnuExit_Click);
            // 
            // manSHJH
            // 
            this.ClientSize = new System.Drawing.Size(1043, 664);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "manSHJH";
            this.Text = "教汇";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.manSHJH_FormClosing);
            this.Load += new System.EventHandler(this.manSHJH_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.cmnuNotifyBubble.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        public DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_UserAccount;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Strategy;
        private System.Windows.Forms.NotifyIcon notifyBubble;
        private System.Windows.Forms.ContextMenuStrip cmnuNotifyBubble;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpen;
        private System.Windows.Forms.ToolStripMenuItem cmnuExit;
    }
}

