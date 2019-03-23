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

        SYBase stag;
        List<Form> forms = new List<Form>();

        Button btnShow;
        SqLiteHelper sqlHelper;

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            stag = new SYStrategy();
            OutPut op = new OutPut();
            stag.setOutPut(op);
            forms.Add(op);
            */
            try
            {
                int last = strategyList.Columns.Count;
                btnShow = new Button();
                btnShow.Text = "交易明细";
                this.strategyList.Controls.Add(btnShow);
                List<string> iiitm = new List<string>();

                int colen = strategyList.Columns.Count;
                for (int i = 0; i < colen; i++)
                {
                    iiitm.Add("11");
                }
                string[] llitem = iiitm.ToArray();
                ListViewItem llv = new ListViewItem(llitem);
                strategyList.Items.Add(llv);

                this.btnShow.Size = new Size(this.strategyList.Items[0].SubItems[colen - 1].Bounds.Width,
                this.strategyList.Items[0].SubItems[colen - 1].Bounds.Height);
                this.btnShow.Click += this.button_Show;

                strategyList.Items.RemoveAt(0);
                btnShow.Visible = false;

                sqlHelper = new SqLiteHelper();
                sqlHelper.SqliteOpen("data source=D:\\VC\\Sqlite\\wes\\wes.db");
                //读取整张表
                SQLiteDataReader reader = sqlHelper.ReadFullTable("user");
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
                    lvt.SubItems.Add(password);
                    lvt.SubItems.Add(uid + "");
                    lvt.SubItems.Add(coinSymbol);
                    lvt.SubItems.Add("未运行");
                    lvt.SubItems.Add("");
                    strategyList.Items.Add(lvt);
                }
                sqlHelper.SqliteClose();
            }
            catch
            {

            }
        }
        private void button_Show(object sender, System.EventArgs e)
        {

        }
    }
}
