namespace JHWinUI
{
    partial class RunStrategy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunStrategy));
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.listStrategy = new System.Windows.Forms.ListView();
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RunState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssembleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StrategyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.describe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Start_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stop_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showHeartMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TestTickMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxSelectStrategy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxSelectAccount = new System.Windows.Forms.ComboBox();
            this.grbBox2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox2
            // 
            this.grbBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grbBox2.Controls.Add(this.listStrategy);
            this.grbBox2.Controls.Add(this.btnAddProject);
            this.grbBox2.Controls.Add(this.label4);
            this.grbBox2.Controls.Add(this.txtProjectName);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.cboxSelectStrategy);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.cboxSelectAccount);
            this.grbBox2.Location = new System.Drawing.Point(58, 63);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(1240, 645);
            this.grbBox2.TabIndex = 0;
            this.grbBox2.TabStop = false;
            // 
            // listStrategy
            // 
            this.listStrategy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listStrategy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.ProjectName,
            this.RunState,
            this.AssembleName,
            this.StrategyName,
            this.describe});
            this.listStrategy.ContextMenuStrip = this.contextMenuStrip;
            this.listStrategy.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listStrategy.FullRowSelect = true;
            this.listStrategy.GridLines = true;
            this.listStrategy.Location = new System.Drawing.Point(46, 104);
            this.listStrategy.Name = "listStrategy";
            this.listStrategy.Size = new System.Drawing.Size(1156, 507);
            this.listStrategy.TabIndex = 10;
            this.listStrategy.UseCompatibleStateImageBehavior = false;
            this.listStrategy.View = System.Windows.Forms.View.Details;
            this.listStrategy.SelectedIndexChanged += new System.EventHandler(this.listStrategy_SelectedIndexChanged);
            // 
            // UserName
            // 
            this.UserName.Text = "账户";
            this.UserName.Width = 100;
            // 
            // ProjectName
            // 
            this.ProjectName.Text = "工程名";
            this.ProjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProjectName.Width = 90;
            // 
            // RunState
            // 
            this.RunState.Text = "运行状态";
            this.RunState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RunState.Width = 80;
            // 
            // AssembleName
            // 
            this.AssembleName.Text = "策略文件名";
            this.AssembleName.Width = 150;
            // 
            // StrategyName
            // 
            this.StrategyName.Text = "策略名";
            this.StrategyName.Width = 240;
            // 
            // describe
            // 
            this.describe.Text = "描述";
            this.describe.Width = 150;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Start_MenuItem,
            this.Stop_MenuItem,
            this.Delete_MenuItem,
            this.toolStripSeparator1,
            this.输出ToolStripMenuItem,
            this.TestTickMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(211, 188);
            // 
            // Start_MenuItem
            // 
            this.Start_MenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start_MenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.Start_MenuItem.Name = "Start_MenuItem";
            this.Start_MenuItem.Size = new System.Drawing.Size(210, 30);
            this.Start_MenuItem.Text = "启动";
            this.Start_MenuItem.Click += new System.EventHandler(this.Start_MenuItem_Click);
            // 
            // Stop_MenuItem
            // 
            this.Stop_MenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Stop_MenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Stop_MenuItem.Name = "Stop_MenuItem";
            this.Stop_MenuItem.Size = new System.Drawing.Size(210, 30);
            this.Stop_MenuItem.Text = "停止";
            this.Stop_MenuItem.Click += new System.EventHandler(this.Stop_MenuItem_Click);
            // 
            // Delete_MenuItem
            // 
            this.Delete_MenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Delete_MenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Delete_MenuItem.Name = "Delete_MenuItem";
            this.Delete_MenuItem.Size = new System.Drawing.Size(210, 30);
            this.Delete_MenuItem.Text = "删除";
            this.Delete_MenuItem.Click += new System.EventHandler(this.Delete_MenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // 输出ToolStripMenuItem
            // 
            this.输出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMessageMenu,
            this.showHeartMenu});
            this.输出ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.输出ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.输出ToolStripMenuItem.Name = "输出ToolStripMenuItem";
            this.输出ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.输出ToolStripMenuItem.Text = "输出";
            // 
            // showMessageMenu
            // 
            this.showMessageMenu.Name = "showMessageMenu";
            this.showMessageMenu.Size = new System.Drawing.Size(166, 30);
            this.showMessageMenu.Text = "输出窗口";
            this.showMessageMenu.Click += new System.EventHandler(this.showMessageMenu_Click);
            // 
            // showHeartMenu
            // 
            this.showHeartMenu.Name = "showHeartMenu";
            this.showHeartMenu.Size = new System.Drawing.Size(166, 30);
            this.showHeartMenu.Text = "显示情报";
            this.showHeartMenu.Click += new System.EventHandler(this.showHeartMenu_Click);
            // 
            // TestTickMenuItem
            // 
            this.TestTickMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.TestTickMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestTickMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TestTickMenuItem.Name = "TestTickMenuItem";
            this.TestTickMenuItem.Size = new System.Drawing.Size(210, 30);
            this.TestTickMenuItem.Text = "点击测试";
            this.TestTickMenuItem.Click += new System.EventHandler(this.TestTickMenuItem_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddProject.Location = new System.Drawing.Point(909, 51);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(85, 33);
            this.btnAddProject.TabIndex = 9;
            this.btnAddProject.Text = "添加工程";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(687, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "工程名称";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProjectName.Location = new System.Drawing.Point(767, 54);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(129, 27);
            this.txtProjectName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(314, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "选择策略";
            // 
            // cboxSelectStrategy
            // 
            this.cboxSelectStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSelectStrategy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxSelectStrategy.FormattingEnabled = true;
            this.cboxSelectStrategy.Items.AddRange(new object[] {
            "无"});
            this.cboxSelectStrategy.Location = new System.Drawing.Point(389, 53);
            this.cboxSelectStrategy.Name = "cboxSelectStrategy";
            this.cboxSelectStrategy.Size = new System.Drawing.Size(283, 28);
            this.cboxSelectStrategy.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(108, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择账户";
            // 
            // cboxSelectAccount
            // 
            this.cboxSelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSelectAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxSelectAccount.FormattingEnabled = true;
            this.cboxSelectAccount.Items.AddRange(new object[] {
            "无"});
            this.cboxSelectAccount.Location = new System.Drawing.Point(183, 52);
            this.cboxSelectAccount.Name = "cboxSelectAccount";
            this.cboxSelectAccount.Size = new System.Drawing.Size(121, 28);
            this.cboxSelectAccount.TabIndex = 3;
            // 
            // RunStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1356, 757);
            this.Controls.Add(this.grbBox2);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RunStrategy";
            this.Text = "策略管理";
            this.Load += new System.EventHandler(this.RunStrategy_Load);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxSelectAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxSelectStrategy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.ListView listStrategy;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader ProjectName;
        private System.Windows.Forms.ColumnHeader RunState;
        private System.Windows.Forms.ColumnHeader AssembleName;
        private System.Windows.Forms.ColumnHeader StrategyName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Start_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Stop_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Delete_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageMenu;
        private System.Windows.Forms.ToolStripMenuItem showHeartMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader describe;
        private System.Windows.Forms.ToolStripMenuItem TestTickMenuItem;
    }
}