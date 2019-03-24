﻿using System;
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

                        ListViewItem lvt = new ListViewItem();
                        lvt.Text = id + "";
                        lvt.SubItems.Add(username);
                        lvt.SubItems.Add("********");
                        lvt.SubItems.Add(uid + "");
                        lvt.SubItems.Add(coinSymbol);
                        lvt.SubItems.Add("未运行");
                        lvt.SubItems.Add("");
                        strategyList.Items.Add(lvt);
                    }
                }
                sqlHelper.SqliteClose();
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
            try
            {
                string strid = strategyList.SelectedItems[0].SubItems[3].Text;
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
                strategyList.Items.RemoveAt(0);
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

                        ListViewItem lvt = new ListViewItem();
                        lvt.Text = id + "";
                        lvt.SubItems.Add(username);
                        lvt.SubItems.Add("********");
                        lvt.SubItems.Add(uid + "");
                        lvt.SubItems.Add(coinSymbol);
                        lvt.SubItems.Add("未运行");
                        lvt.SubItems.Add("");
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

        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        }

    }
}
