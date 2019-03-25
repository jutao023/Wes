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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        public string uid { get; set; }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.Location = (Point)new Size(Control.MousePosition.X - 50, Control.MousePosition.Y -80);

            SqLiteHelper sqlHelper = new SqLiteHelper();
            sqlHelper.SqliteOpen();
            try
            {
                string sql = "SELECT * FROM attrbute WHERE fk_uid=" + uid;
                //读取整张表
                SQLiteDataReader reader = sqlHelper.Execute(sql);
                if (reader != null)
                {
                    reader.Read();

                    reader.GetInt32(reader.GetOrdinal("attrbute_id"));
                    fk_uid.Text = reader.GetInt32(reader.GetOrdinal("fk_uid"))+"";
                    mustMore.Text = reader.GetInt32(reader.GetOrdinal("mustMore")) + "";
                    OtherMore.Text = reader.GetInt32(reader.GetOrdinal("OtherMore"))+"";
                    minPrice.Text = reader.GetDouble(reader.GetOrdinal("minPrice"))+"";
                    timerGrade.Text = reader.GetInt32(reader.GetOrdinal("timerGrade"))+"";
                    mustToSell.Text = reader.GetInt32(reader.GetOrdinal("mustToSell"))+"";
                    mustToBuy.Text = reader.GetInt32(reader.GetOrdinal("mustToBuy"))+"";
                    otherToBuy.Text = reader.GetInt32(reader.GetOrdinal("otherToBuy")) + "";
                    otherToSell.Text = reader.GetInt32(reader.GetOrdinal("otherToSell"))+"";
                    maxOrderCount.Text = reader.GetInt32(reader.GetOrdinal("maxOrderCount"))+"";

                    reader.GetString(reader.GetOrdinal("updateDate"));
                    reader.GetString(reader.GetOrdinal("createDate"));
                   
                }
                sqlHelper.SqliteClose();
            }
            catch
            {
                sqlHelper.SqliteClose();
            }
        }

        private void fk_uid_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                bool b_mustMore = System.Text.RegularExpressions.Regex.IsMatch(mustMore.Text, @"^\+?[1-9][0-9]*$");
                bool b_OtherMore = System.Text.RegularExpressions.Regex.IsMatch(OtherMore.Text, @"^\+?[1-9][0-9]*$");
                bool b_minPrice = System.Text.RegularExpressions.Regex.IsMatch(minPrice.Text, @"^\d+(\.\d+)?$");
                bool b_timerGrade = System.Text.RegularExpressions.Regex.IsMatch(timerGrade.Text, @"^\+?[1-9][0-9]*$");
                bool b_mustToSell = System.Text.RegularExpressions.Regex.IsMatch(mustToSell.Text, @"^\+?[1-9][0-9]*$");
                bool b_mustToBuy = System.Text.RegularExpressions.Regex.IsMatch(mustToBuy.Text, @"^\+?[1-9][0-9]*$");
                bool b_otherToBuy = System.Text.RegularExpressions.Regex.IsMatch(otherToBuy.Text, @"^\+?[1-9][0-9]*$");
                bool b_otherToSell = System.Text.RegularExpressions.Regex.IsMatch(otherToSell.Text, @"^\+?[1-9][0-9]*$");
                bool b_maxOrderCount = System.Text.RegularExpressions.Regex.IsMatch(maxOrderCount.Text, @"^\+?[1-9][0-9]*$");

                if (!b_mustMore ||
                    !b_OtherMore ||
                    !b_minPrice ||
                    !b_timerGrade ||
                    !b_mustToSell ||
                    !b_mustToBuy ||
                    !b_otherToBuy ||
                    !b_otherToSell ||
                    !b_maxOrderCount)
                {
                    MessageBox.Show("输入的值不合法");
                }

                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = "UPDATE attrbute SET " +
                    "mustMore=" + mustMore.Text +
                    ",OtherMore=" + OtherMore.Text +
                    ",minPrice=" + minPrice.Text +
                    ",timerGrade=" + timerGrade.Text +
                    ",mustToSell=" + mustToSell.Text +
                    ",mustToBuy=" + mustToBuy.Text +
                    ",otherToBuy=" + otherToBuy.Text +
                    ",otherToSell=" + otherToSell.Text +
                    ",maxOrderCount=" + maxOrderCount.Text +
                    ",updateDate='" + time+"'"+
                    " WHERE fk_uid=" + uid;

                SqLiteHelper sqlHelper = new SqLiteHelper();
                sqlHelper.SqliteOpen();

                SQLiteDataReader srd = sqlHelper.Execute(sql);
                if(srd != null)
                {
                    MessageBox.Show("修改成功");
                    sqlHelper.SqliteClose();
                    Close();
                    return;
                }
                sqlHelper.SqliteClose();
            }
            catch
            {
                return;
            }
        }
    }
}
