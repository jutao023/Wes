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

        SqLiteHelper sqlHelper;

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

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
                    lvt.SubItems.Add("********");
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

        private void strategyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.strategyList.SelectedItems.Count == 1)
            {
       
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
