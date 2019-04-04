using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wes
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        List<Form>   formList = new List<Form>();
        List<SYBase> baseList = new List<SYBase>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqLiteHelper sqlHelper = new SqLiteHelper();
            sqlHelper.SqliteOpen();
            try
            {
                //读取整张表
                SQLiteDataReader reader = sqlHelper.ReadFullTable("user");
                if (reader != null)
                {
                    List<string> item = new List<string>();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string username = reader.GetString(reader.GetOrdinal("username"));
                        string password = reader.GetString(reader.GetOrdinal("password"));
                        int uid = reader.GetInt32(reader.GetOrdinal("uid"));
                        string coinSymbol = reader.GetString(reader.GetOrdinal("coinSymbol"));
                        string reamrks = reader.GetString(reader.GetOrdinal("remarks"));

                        ListViewItem lvt = new ListViewItem();
                        lvt.Text = id + "";
                        lvt.SubItems.Add(username);
                        lvt.SubItems.Add("********");
                        lvt.SubItems.Add(uid + "");
                        lvt.SubItems.Add(coinSymbol);
                        lvt.SubItems.Add(getRunStatus(uid).ToString());
                        lvt.SubItems.Add(reamrks);
                        strategyList.Items.Add(lvt);
                    }
                }
                sqlHelper.SqliteClose();

                //设置顶时任务
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Enabled = true;
                timer.Interval = 10000;//执行间隔时间,单位为毫秒    
                timer.Start();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            }
            catch
            {
                sqlHelper.SqliteClose();
            }
        }

        private void strategyList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            au.ShowDialog();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if(strategyList.SelectedItems.Count != 1)
            { return; }
            DialogResult result = MessageBox.Show("确定删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            string strid = strategyList.SelectedItems[0].SubItems[3].Text;

            foreach (var v in baseList)
            {
                if (strid == v.userId + "")
                {
                    if (v.runStatus == EnumRunStatus.运行中)
                    {
                        MessageBox.Show("运行中无法删除");
                        return;
                    }
                }
            }

            try
            {
                int uid = int.Parse(strid);
                SqLiteHelper sqlHelper = new SqLiteHelper();
                sqlHelper.SqliteOpen();

                sqlHelper.DeleteValuesAND(
                    "attrbute",
                    new string[] {"fk_uid" },
                    new string[] {strid },
                    new string[] { "=" }
                );
                sqlHelper.DeleteValuesAND(
                   "user",
                   new string[] { "uid" },
                   new string[] { strid },
                   new string[] { "=" }
                );
                sqlHelper.SqliteClose();
                strategyList.Items.RemoveAt(strategyList.SelectedItems[0].Index);
            }
            catch
            {
                return;
            }
        }

        private void btn_Flush_Click(object sender, EventArgs e)
        {
            try
            {
                SqLiteHelper sqlHelper = new SqLiteHelper();
                strategyList.Items.Clear();
                sqlHelper.SqliteOpen();
                //读取整张表
                SQLiteDataReader reader = sqlHelper.ReadFullTable("user");
                if (reader != null)
                {
                    List<string> item = new List<string>();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string username = reader.GetString(reader.GetOrdinal("username"));
                        string password = reader.GetString(reader.GetOrdinal("password"));
                        int uid = reader.GetInt32(reader.GetOrdinal("uid"));
                        string coinSymbol = reader.GetString(reader.GetOrdinal("coinSymbol"));
                        string reamrks = reader.GetString(reader.GetOrdinal("remarks"));

                        ListViewItem lvt = new ListViewItem();
                        lvt.Text = id + "";
                        lvt.SubItems.Add(username);
                        lvt.SubItems.Add("********");
                        lvt.SubItems.Add(uid + "");
                        lvt.SubItems.Add(coinSymbol);
                        lvt.SubItems.Add(getRunStatus(uid).ToString());
                        lvt.SubItems.Add(reamrks);
                        strategyList.Items.Add(lvt);
                    }
                }
                sqlHelper.SqliteClose();
            }catch
            {

            }
        }

        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strategyList.SelectedItems.Count != 1)
            { return; }

            string uid = strategyList.SelectedItems[0].SubItems[3].Text;
            string coinsymbol = strategyList.SelectedItems[0].SubItems[4].Text;
            foreach (var v in baseList)
            {
                if (uid == v.userId + "")
                {
                    if (v.runStatus == EnumRunStatus.运行中)
                    {
                        MessageBox.Show("已在运行中");
                        return;
                    }
                }
            }
            SYBase bs = new SYStrategy();
            OutPut ot = new OutPut();

            ot.uid = uid;
            ot.coinSymbol = coinsymbol;

            bs.setPrintDlg(ot);
            // 启动
            bs.Start(uid, coinsymbol);
            strategyList.SelectedItems[0].SubItems[5].Text = EnumRunStatus.运行中.ToString();
            baseList.Add(bs);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strategyList.SelectedItems.Count != 1)
            { return; }

            string uid = strategyList.SelectedItems[0].SubItems[3].Text;
            for (int i =0; i < baseList.Count; i++)
            {
               if(baseList[i].userId+"" == uid)
                {
                    baseList[i].closeTrade();
                    baseList[i].setPrintDlg(null);
                    baseList.RemoveAt(i);
                    strategyList.SelectedItems[0].SubItems[5].Text = EnumRunStatus.已停止.ToString();
                    return;
                }
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strategyList.SelectedItems.Count != 1)
            { return; }

            Setting sett = new Setting();
            string uid = strategyList.SelectedItems[0].SubItems[3].Text;
            if (uid == null || uid.Length == 0)
                return;
            bool nub = System.Text.RegularExpressions.Regex.IsMatch(uid, "^[0-9]*$");
            if (!nub)
            {
                MessageBox.Show("uid,只能是数字");
                return;
            }
            //
            sett.uid = uid;
            sett.ShowDialog();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strategyList.SelectedItems.Count != 1)
            { return; }
            string uid = strategyList.SelectedItems[0].SubItems[3].Text;
            foreach (var v in baseList)
            {
                if(v.userId+"" == uid)
                {
                    v.Show();
                    return;
                }
            }
        }

        private EnumRunStatus getRunStatus(long _uid)
        {
            foreach(var v in baseList)
            {
                if(v.userId == _uid)
                {
                    return v.runStatus;
                }
            }
            return EnumRunStatus.未启动;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            if(baseList.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("有程序在运行无法关闭！");
                return;
            }
        }

        /// <summary>
        /// 定时器检查当前程序的运行状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                int index = -1;
                string uid = "";
                foreach (var v in baseList)
                {
                    if (v.runStatus == EnumRunStatus.行情接收异常|| v.runStatus == EnumRunStatus.行情连接异常 ||
                        v.runStatus == EnumRunStatus.交易异常停止)
                    {
                        uid = v.userId + "";
                        foreach (ListViewItem item in strategyList.Items)
                        {
                            if (item.SubItems[3].Text == uid)
                            {
                                index = item.Index;
                                break;
                            }
                        }
                        if (index >= 0)
                        {
                            strategyList.Items[index].SubItems[5].Text = v.runStatus.ToString();
                        }
                    }
                    if (v.runStatus == EnumRunStatus.运行中)
                    {
                        uid = v.userId + "";
                        foreach (ListViewItem item in strategyList.Items)
                        {
                            if (item.SubItems[3].Text == uid)
                            {
                                index = item.Index;
                                break;
                            }
                        }
                        if (index >= 0)
                        {
                            string text = strategyList.Items[index].SubItems[5].Text;
                            if(text != v.runStatus.ToString())
                                strategyList.Items[index].SubItems[5].Text = v.runStatus.ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
