using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace JHWinUI
{
    public partial class UserAccount : DockContent
    {
        private DataRecv m_datarecv_send = null;
        private List<UserInfoConfig> listUsers = new List<UserInfoConfig>();


        public void SetDataRecv(DataRecv dr)
        {
            m_datarecv_send = dr;
        }

        public UserAccount()
        {
            InitializeComponent();
        }

        //保存用户信息
        private void SaveUserInfo()
        {
            OperFile.SaveUserInfoConfig(listUsers);
        }

        //导入用户配置信息
        private void ReadUserInfo()
        {
            List<UserInfoConfig> tmpListUsers = OperFile.GetUserInfoByFile();
            if (tmpListUsers == null)
                return;
            listUsers = tmpListUsers;
            listUserInfo.Items.Clear();
            foreach(UserInfoConfig uif in listUsers)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = uif.username;
                lvi.SubItems.Add("********");
                lvi.SubItems.Add(uif.contractID);
                lvi.SubItems.Add(uif.valsign);
                lvi.SubItems.Add(uif.trade_addr_port);
                lvi.SubItems.Add(uif.market_addr_port);
                lvi.SubItems.Add(uif.http_addr_port);
                listUserInfo.Items.Add(lvi);
            }
            if(m_datarecv_send != null)
            {
                m_datarecv_send.OnUserInfoList(listUsers);
            }
        }

        //主窗口退出通知
        public void ExitOnClose()
        {

        }

        //添加账户
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Text;
            string cont = txtContractID.Text;
            

            if(user == "" || pass == "" || cont == "" || cboxSelectHttp.Text=="" ||
                cboxSelectValsign.Text == "" || cboxSelectMarketAddr.Text == "" || cboxSelectTradeAddr.Text == "")
            {
                MessageBox.Show("输入信息不能为空","提示");
                return;
            }

            string[] market = cboxSelectMarketAddr.Text.Split(new char[] { ':' });
            string[] trade = cboxSelectTradeAddr.Text.Split(new char[] { ':' });
            string[] http = cboxSelectHttp.Text.Split(new char[] { ':' });
            if(market.Length != 2 || trade.Length != 2 || http.Length != 2 )
            {
                MessageBox.Show("输入的地址格式不正确!", "提示");
                return;
            }
            

            int ItemCount = listUserInfo.Items.Count;
            if( ItemCount >= 10)
            {
                MessageBox.Show("添加最大不能超过10个", "提示");
                return;
            }

            foreach(ListViewItem item in listUserInfo.Items)
            {
                if(user == item.Text)
                {
                    MessageBox.Show("账户不能重复", "提示");
                    return;
                }
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = user;
            lvi.SubItems.Add("********");
            lvi.SubItems.Add(cont);
            lvi.SubItems.Add(cboxSelectValsign.Text);
            lvi.SubItems.Add(cboxSelectTradeAddr.Text);
            lvi.SubItems.Add(cboxSelectMarketAddr.Text);
            lvi.SubItems.Add(cboxSelectHttp.Text);
            listUserInfo.Items.Add(lvi);

            UserInfoConfig uif = new UserInfoConfig();
            uif.username = user;
            uif.password = pass;
            uif.contractID = cont;
            uif.valsign = cboxSelectValsign.Text;
            uif.trade_addr_port = cboxSelectTradeAddr.Text;
            uif.market_addr_port = cboxSelectMarketAddr.Text;
            uif.http_addr_port = cboxSelectHttp.Text;
            listUsers.Add(uif);

            //保存到文件
            SaveUserInfo();

            //数据更新到. . .
            if(m_datarecv_send != null)
            {
                m_datarecv_send.OnUserInfoList(listUsers);
            }
        }

        //
        private void listUserInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {

            }
        }

        //删除信息
        private void PopuMenu_delete_Click(object sender, EventArgs e)
        {
            if(listUserInfo.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listUserInfo.SelectedItems[0];

                for(int i = 0; i < listUsers.Count; i++)
                {
                    if(listUsers[i].username == lvi.Text)
                    {
                        listUsers.RemoveAt(i);
                        break;
                    }
                }
                listUserInfo.Items.Remove(lvi);
                SaveUserInfo();
                //
                if (m_datarecv_send != null)
                {
                    m_datarecv_send.OnUserInfoList(listUsers);
                }
            }
        }

        //Load 加载或初始化
        private void UserAccount_Load(object sender, EventArgs e)
        {
            ReadUserInfo();
        }
    }
}
