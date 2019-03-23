using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace JHWinUI
{
    public partial class manSHJH
    {
        public manSHJH()
        {
            InitializeComponent();
        }

        //单例模式主对话框
        static manSHJH mainFrame = null;
        public static manSHJH GetMainFrame()
        {
            return mainFrame;
        }

        RunStrategy rStrategy = null;
        UserAccount uAccount = null;

        //窗口初始化
        private void manSHJH_Load(object sender, EventArgs e)
        {
            
            if(mainFrame == null)
            {
                mainFrame = this;
            }

            uAccount = new UserAccount();
            rStrategy = new RunStrategy();

            uAccount.SetDataRecv(rStrategy);
            uAccount.Show(dockPanel1,DockState.Document);

            rStrategy.Show(dockPanel1, DockState.Document);


        }

        //【账户信息】菜单
        private void MenuItem_UserAccount_Click(object sender, EventArgs e)
        {
            if(uAccount != null)
            {
                uAccount.Show(dockPanel1);
            }
        }

        //【策略管理】菜单
        private void MenuItem_Strategy_Click(object sender, EventArgs e)
        {
            if(rStrategy != null)
            {
                rStrategy.Show(dockPanel1);
            }
        }

        //【关闭窗口前】
        private void manSHJH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                base.SetVisibleCore(false);
                this.notifyBubble.ShowBalloonTip(300, "提示", "看这里，系统仍在运行！", ToolTipIcon.None);
                return;
            }
            else
            {
                if (DialogResult.No == MessageBox.Show("您确定要退出吗?", "教汇", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                    return;
                }
                rStrategy.ExitOnClose();
                rStrategy.ExitOnClose();
            }
        }

        //【退出】
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }catch
            {

            }
        }

        //【菜单】打开
        private void cmnuOpen_Click(object sender, EventArgs e)
        {
            this.Show();
        }
        //【菜单】退出
        private void cmnuExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {

            }
        }

        private void notifyBubble_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }
    }
}
